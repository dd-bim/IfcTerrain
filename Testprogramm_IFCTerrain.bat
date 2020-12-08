@echo OFF
color f0
rem color --> legt Farbe fest (f= Weiß (Hintergrund) und 0= Schwarz (Schrift))
title Testprogramm_IFCTerrain
rem Entwicklerprogramm Aenderung von Dateipfaden ggf notwendig
echo ==================================================================
echo Testprogramm fuer Entwickler des IFCTerrain gestartet...
echo ==================================================================
echo.
echo ========================01_LAND_XML===============================
echo Testdatei fuer Land XML wird erzeugt:
start "" IFCTerrainCommand\bin\x64\Debug\IFCTerrainCommand.exe "IFCTerrainTestData\06_JSON\sample_json_landxml_ifc4_tfs.json"
echo LandXML (TriangulatedFaceSet): IFC4 erzeugt
start "" IFCTerrainCommand\bin\x64\Debug\IFCTerrainCommand.exe "IFCTerrainTestData\06_JSON\sample_json_landxml_ifc4_sbsm.json"
echo LandXML (ShellBasesSurfaceModel): IFC4 erzeugt
echo ==================================================================
echo.
echo ========================02_CityGML================================
echo Testdatei fuer CityGML wird erzeugt:
start "" IFCTerrainCommand\bin\x64\Debug\IFCTerrainCommand.exe "IFCTerrainTestData\06_JSON\sample_json_citygml_ifc4_tfs.json"
echo CityGML (TriangulatedFaceSet): IFC4 erzeugt
echo ==================================================================
echo.
echo ========================03_DXF====================================
echo Testdatei fuer DXF wird NICHT erzeugt!
start "" IFCTerrainCommand\bin\x64\Debug\IFCTerrainCommand.exe "IFCTerrainTestData\06_JSON\sample_json_dxf_ifc4_gcs.json"
rem echo DXF (GCS): IFC4 erzeugt
echo ==================================================================
echo.
echo ========================04_RASTER_XYZ=============================
echo Testdatei fuer Rasterdaten wird erzeugt:
start "" IFCTerrainCommand\bin\x64\Debug\IFCTerrainCommand.exe "IFCTerrainTestData\06_JSON\sample_json_raster_ifc4_tfs.json"
echo Raster (TriangulatedFaceSet): IFC4 erzeugt
start "" IFCTerrainCommand\bin\x64\Debug\IFCTerrainCommand.exe "IFCTerrainTestData\06_JSON\sample_json_raster_ifc2x3_tfs.json"
echo Raster (TriangulatedFaceSet): IFC2x3 erzeugt
echo ==================================================================
echo.
echo ========================05_REB====================================
echo Testdatei fuer REB-Daten wird erzeugt:
start "" IFCTerrainCommand\bin\x64\Debug\IFCTerrainCommand.exe "IFCTerrainTestData\06_JSON\sample_json_reb_ifc4_tfs.json"
echo REB (TriangulatedFaceSet): IFC4 erzeugt
echo ==================================================================
echo.
echo ==================================================================
echo Die Ergebnisse sind im Ordner: 'IFCTerrainTestData/07_Export' zu finden.
start explorer "%CD%\IFCTerrainTestData\07_Export"
echo ==================================================================
pause
rem der nachfolgende Kommand schließt die IFCTerrainCommand.exe, sodass nicht ausführbare Prozesse nicht weiter im Hintergrund ausgeführt werden!
taskkill /F /IM IFCTerrainCommand.exe /T
pause
exit
