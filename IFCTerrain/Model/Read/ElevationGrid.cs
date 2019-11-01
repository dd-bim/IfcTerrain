using BimGisCad.Representation.Geometry.Elementary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFCTerrain.Model.Read
{
    class ElevationGrid
    {
        public static Result ReadGrid(bool is3d, string fileName, double minDist, int size, bool bBox, double bbNorth, double bbEast, double bbSouth, double bbWest)
        {
            var result = new Result();
            var mesh = new BimGisCad.Collections.Mesh(is3d, minDist);

            #region Read File for extent
            int counter = 0;
            string line;
            List<double> xList = new List<double>();
            List<double> yList = new List<double>();
            List<double> zList = new List<double>();

            System.IO.StreamReader file = new System.IO.StreamReader(fileName);

            while ((line = file.ReadLine()) != null)
            {
                string[] str = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 2
                       && double.TryParse(str[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x)
                       && double.TryParse(str[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double y)
                       && double.TryParse(str[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double z))
                {
                    xList.Add(x);
                    yList.Add(y);
                    zList.Add(z);
                }
                counter++;
            }

            double xMin = xList.Min();
            double xMax = xList.Max();
            double yMin = yList.Min();
            double yMax = yList.Max();

            int xExtent = (int)(xMax - xMin);
            int yExtent = (int)(yMax - yMin);

            file.Close();
            #endregion

            #region Fill Grid

            //Size of the grid
            int xCount = xExtent / size;
            int yCount = yExtent / size;

            //!!!überprüfen ob 0 oder 1 !!!
            var grid = new List<Dictionary<int, Point3>>();
            for (int rowcount = 0; rowcount <= yCount; rowcount++)
            {
                grid.Add(new Dictionary<int, Point3>());
            }
            
            System.IO.StreamReader file2 = new System.IO.StreamReader(fileName);

            while ((line = file2.ReadLine()) != null)
            {
                string[] str = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 2
                       && double.TryParse(str[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double x)
                       && double.TryParse(str[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double y)
                       && double.TryParse(str[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double z))
                {
                    if(bBox)
                    {
                        if (y >= bbSouth && y <= bbNorth && x >= bbWest && x <= bbEast)
                        {
                            Point3 p = Point3.Create(x, y, z);
                            int xGrid = (int)(x - xMin);
                            int yGrid = (int)(y - yMin);

                            grid[yGrid].Add(xGrid, p);
                        }
                    }
                    else
                    {
                        Point3 p = Point3.Create(x, y, z);
                        int xGrid = (int)(x - xMin);
                        int yGrid = (int)(y - yMin);

                        grid[yGrid].Add(xGrid, p);
                    }
                    
                }
            }
            file2.Close();
            #endregion

            #region Create simple Mesh on Grid

            for (int row = 0; row < yCount; row++)
            {
                for (int column = 0; column <= xCount; column++)
                {
                    if (grid[row].ContainsKey(column))
                    {
                        Point3 cp = grid[row][column];
                        //mesh.AddPoint(cp);

                        //Triangle1 TopLeft
                        if (grid[row + 1].ContainsKey(column + 1) && grid[row + 1].ContainsKey(column))
                        {
                            Point3 tp = grid[row + 1][column];
                            Point3 tr = grid[row + 1][column + 1];

                            mesh.AddFace(new[] { cp, tp, tr });
                        }

                        //Triangle2 BottomRight
                        if (grid[row + 1].ContainsKey(column + 1) && grid[row].ContainsKey(column + 1))
                        {
                            Point3 br = grid[row][column + 1];
                            Point3 tr = grid[row + 1][column + 1];

                            mesh.AddFace(new[] { cp, tr, br });
                        }

                        //Triangle on left Edge of Terrain
                        if (grid[row].ContainsKey(column - 1) is false && grid[row + 1].ContainsKey(column) && grid[row + 1].ContainsKey(column - 1))
                        {
                            Point3 tp = grid[row + 1][column];
                            Point3 tl = grid[row + 1][column - 1];

                            mesh.AddFace(new[] { cp, tl, tp });
                        }
                    }
                }
            }
            #endregion

            result.Mesh = mesh;
            return result;
        }
    }
}
