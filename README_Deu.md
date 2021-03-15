# IFCTerrain Dokumentation

Dieses Dokument enthält eine Beschreibung und erläutert die Funktionalität des Software-Tools IFCTerrain. Der Hauptzweck von IFCTerrain ist die Umwandlung von Geländemodellen verschiedener Datenformate in IFC (Industry Foundation Classes), dem gängigen offenen Datenaustauschformat für BIM (Building Information Modeling).


- [IFCTerrain Dokumentation](#ifcterrain-documentation)
  * [Terrain-Modelle in IFC](#terrain-models-in-ifc)
    + [IfcGeometricCurveSet](#ifcgeometriccurveset)
    + [IfcShellBasedSurfaceModel](#ifcshellbasedsurfacemodel)
    + [IfcTriangulatedFaceSet](#ifctriangulatedfaceset)
    + [~~IfcTriangulatedIrregularNetwork~~](#IfcTriangulatedIrregularNetwork)
  * [Das IFCTerrain Tool](#the-ifcterrain-tool-(GUI))
    + [Import Einstellungen](#import-settings)
    + [Export Einstellungen](#export-settings)
      - [IFC Version](#ifc-version)
      - [Export Shape und Modell](#export-shape-and-model)
      - [Koordinatenursprung](#coordinate-origin)
  * [IFCTerrainCommand](#IFCTerrainCommand)
    + [JSON Attribute](#JSON-Attributes)
    + [Datei-Spezifische-Attribute](#FILE-SPECIFIC-Attributes)
  * [Logging](#logging)
  * [Anwendbarkeit von IFC Dateien in anderer Software](#usability-of-generated-ifc-files-in-other-software)
    + [Revit](#revit)
    + [Solibri](#solibri)
  * [Test-Software für Entwickler](#Testing-software-for-developer)  



## Geländemodelle in IFC

Das IFC-Datenformat bietet mehrere Möglichkeiten, Geländeinformationen zu speichern. Die folgenden Unterabschnitte enthalten Erläuterungen zu diesen Geländemodellkonzepten in IFC, die von IFCTerrain unterstützt werden.

### IfcGeometricCurveSet

Laut Entity-Definition wird das "IfcGeometricCurveSet" nur für den Austausch der Formdarstellung einer Sammlung von (2D- oder 3D-) Punkten und Kurven verwendet".

Sie enthält eine Liste von Elementen, die die Formdarstellung des IfcGeometricCurveSet-Objekts bilden. Im Gegensatz zum IfcGeometricSet, von dem es die Elementliste erbt, kann IfcGeometricCurveSet keine Flächenobjekte in seiner geometrischen Menge haben. Es besteht strikt aus Punkten und Kurven, wie oben angegeben.

[IfcGeometricCurveSet - buildingSMART](https://standards.buildingsmart.org/IFC/RELEASE/IFC4/ADD2_TC1/HTML/schema/ifcgeometricmodelresource/lexical/ifcgeometriccurveset.htm)



### IfcShellBasedSurfaceModel

IfcShellBasedSurfaceModel stellt eine Form durch eine Menge von offenen oder geschlossenen Schalen dar. Die einzelnen Schalen selbst haben eine Dimensionalität von 2 und dürfen sich nicht gegenseitig überlappen. Das vollständige IfcShellBasedSurfaceModel hat eine Dimensionalität von 3.

[IfcShellBasedSurfaceModel - buildingSMART](https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/schema/ifcgeometricmodelresource/lexical/ifcshellbasedsurfacemodel.htm)



### IfcTriangulatedFaceSet

Aus der IFC-Dokumentation von buildingsmart:

> Das IfcTriangulatedFaceSet ist ein tesselierter Flächensatz, bei dem alle Flächen durch Dreiecke gebunden sind. Die Flächen werden durch implizite Polylinien konstruiert, die durch drei kartesische Punkte definiert sind. Die Koordinaten jedes Punktes werden durch einen Index in einer geordneten Liste von kartesischen Punkten angegeben, die durch die zweidimensionale Liste CoordIndex bereitgestellt wird, wobei

> - die erste Dimension der zweidimensionalen Liste die Liste der Dreiecksflächen adressiert

> - die zweite Dimension der zweidimensionalen Liste genau drei Indizes in die IfcCartesianPointList liefert, die von Coordinates referenziert wird, das am Supertyp IfcTessellatedFaceSet definiert ist. Jeder Index zeigt auf einen kartesischen Punkt, der ein Scheitelpunkt des Dreiecks ist.

Der Typ IfcTriangulatedFaceSet ist nur im Schema IFC4 und nicht in IFC2x3 verfügbar.


[IfcTriangulatedFaceSet - buildingSMART](http://docs.buildingsmartalliance.org/MVD_SPARKIE/schema/ifcgeometricmodelresource/lexical/ifctriangulatedfaceset.htm)



### IfcTriangulatedIrregularNetwork

Ist geplant, aber noch nicht implementiert.

[IfcTriangulatedIrregularNetwork - buildingSMART](https://standards.buildingsmart.org/IFC/DEV/IFC4_2/FINAL/HTML/schema/ifcgeometricmodelresource/lexical/ifctriangulatedirregularnetwork.htm)

### Das IFCTerrain Tool (GUI)

![IfcTerrain Main Window](pic/IfcTerrainMainForm.PNG)



### Import Einstellungen

Das Hauptfenster des **IfcTerrain** Tools ist in *Import-* und *Exporteinstellungen* unterteilt.

Ins Tool können die folgenden Datentypen, welche allesamt Geländeinformationen enthalten, importiert werden:

- **LandXML** und **CityGML** mit entsprechenden TIN-Daten

  - der Anwender muss nach "TIN-Datei einlesen" zwischen LandXML und CityGML wählen.
  - Wenn "LandXML" gewählt wurde, kann anschließend ausgewählt werden, ob Bruchlinien verarbeitet werden sollen. Diese müssen im <Breaklines>-Tag enthalten sein. 
  - Für CityGML ist die Verarbeitung von Bruchkanten derzeit nicht möglich.

  ![TIN import](pic/TINimport.PNG)

- Drawing Interchange File Format (**DXF**), das Punkte und Linien <u>ODER</u> Flächen enthält

	- bei DXF muss der Anwender den Layer auswählen, in dem die Geländeinformation gespeichert ist und ob die Geländeinformation aus Punkten und/oder Linien ODER Flächen besteht und dann auf "Verarbeiten" klicken, um die Daten korrekt zu importieren.
	- Wenn Bruchlinien verarbeitet werden sollen, muss dies mit "Ja" ausgewählt werden. Wählen Sie dann den *Layer* aus, in dem die *Bruchlinien* gespeichert sind.
	- Die Einstellungen sind über die Schaltfläche "Verarbeiten" zu übernehmen.

![DXF import](pic/DXFimport.PNG)



- **REB Daten** (formats DA45, DA49 or DA58)
  - ähnlich wie bei DXF muss der Benutzer beim REB-Import den Horizont auswählen, in dem die Geländedaten gespeichert sind, und dann auf Verarbeiten klicken, um die Daten korrekt zu importieren

![REB import](pic/REBimport.PNG)



- **Gitter**, gemeint ist ein Höhengitter bestehend aus Punkten und einer regelmäßigen Größe der Gitter-"Kacheln" (einfaches .xyz-Datenformat)
  - der Benutzer muss die richtige Gittergröße welche in der Datei verwendet wurde auswählen
  - Weiterhin kann eine Bounding Box gesetzt werden, indem das Feld angekreuzt, die entsprechenden Werte (Einheit: Meter) eingegeben und der Knopf "Setzen" gedrückt wird.

![Grid import](pic/Gridimport.PNG)

- **GEOgraf** **OUT**, Projektaustauschformat
  - der Benutzer kann entscheiden, welche Arten verarbeitet werden sollen. Wenn diese leer gelassen werden, werden alle Arten gelesen.
  - der Benutzer kann entscheiden, ob ein Status (Position und Höhe) ignoriert werden soll.
  - der Benutzer kann wählen, ob *Flächen* oder *Punkte & Linien* verarbeitet werden sollen
  - die Verarbeitung von Bruchkanten ist möglich (wenn Punkte & Linien gewählt wurden), hier ist noch ein Linientyp anzugeben, der die Bruchkanten enthält
  - die Einstellungen sind über die Schaltfläche "Verarbeiten" zu übernehmen


![OUT import](pic/OUTimport.PNG)



- **PostGIS**, Datenbankverbindung zur Abfrage eines DGMs

 - Es wird ein Konto benötigt, das einen SELECT-Befehl an eine bestehende PostGIS-Datenbank senden kann. 
    <u>Hinweis</u>: Es werden keine Daten wie Passwörter gespeichert! Diese werden nur für den Aufbau einer Datenbankverbindung benötigt.
  
  - Es werden benötigt (ohne Bruchlinien): 
  
    - eine Datenbank, ein Schema, 
  
    - die Tabelle & Spalte mit der TIN,
  
    - die Spalte mit der TIN-ID (die sich in der gleichen Tabelle wie die TIN befindet) 
  
    - Der folgende SELECT-Befehl wird an die Datenbank gesendet:
  
      ```sql
      SELECT ST_AsEWKT(tincolumn) FROM schema.tintable WHERE tinidcolumn = tinid
      ```
  
      
  
  - Wenn Bruchlinien verarbeitet werden sollen, ist es weiterhin erforderlich:
  
    - Eine Tabelle & Spalte, die die Bruchzeilen enthält
  
    - Für die Verbindung zwischen Bruchlinie und TIN ist eine Spalte zu führen, die die entsprechende TIN-ID enthält
  
    - Der folgende SELECT-Befehl wird an die Datenbank gesendet: 
  
      ```sql
      SELECT ST_AsEWKT(bl_table.bl_column) FROM schema.bl_table JOIN schema.tintable ON (bl_table.bl_tinid = tintable. tinidcolumn) WHERE tintable.tinidcolumn = tinid
      ```
  
      

![PostGIS Import](pic/PostGISimport.PNG)

### Export Einstellungen

Unter Exporteinstellungen kann der Benutzer die IFC-Datei anpassen, die vom IFCTerrain-Tool erzeugt wird.



#### IFC Version

Innerhalb der IFC-Version-Box kann der Anwender entscheiden:

- zwischen den IFC-Versionen "2x3" und "4 add 1"

- ob IfcGeographicElement-Entities exportiert werden sollen (nur verfügbar, wenn IFC-Version 4 add 1 gewählt ist)

- ob eine reguläre IFC-Datei im STEP-Format oder IFCXML im XML-Format (Export IFC Checkbox aktiviert) erzeugt werden soll


![IfcVersion](pic/IfcVersion.PNG)


#### Export Shape und Modell


Innerhalb des Feldes "Shape" kann der Anwender zwischen den verschiedenen Möglichkeiten entscheiden, die Geländeinformationen in IFC zu speichern (wie oben im Kapitel "Geländemodelle in IFC" erwähnt). Beachten Sie, dass nicht jede BIM-Software in der Lage ist, diese verschiedenen Modelle auf die gleiche Weise darzustellen. Welcher Modelltyp exportiert werden soll, hängt von der Software ab, in die die erzeugte Ifc-Datei importiert werden soll.

Zusätzlich hat der Benutzer die Möglichkeit, einen Mindestabstand zwischen Punkten zu definieren, der im endgültigen Netz des Geländemodells erlaubt ist. Für Einsteiger sollte diese Eingabe auf dem Standardwert von 1 Meter belassen werden.

![Shape](pic/Shape.PNG)


#### Koordinatenursprung


Das Feld Koordinatenursprung bietet die Möglichkeit, den Koordinatenursprung der exportierten IFC-Datei anzupassen. Wenn Sie "Standard" wählen, wird der Koordinatenursprung in der Mitte der gesamten Projektfläche platziert und in der IfcSite-Entität gespeichert. Alle absoluten Eingabekoordinaten werden in Bezug auf diesen Koordinatenursprung transformiert.

Mit der Option "Benutzerdefiniert" kann der Benutzer den Projektkoordinatenursprung auf eine Position seiner Wahl festlegen.



![Shape](pic/CoordinateOrigin.PNG)



## IFCTerrain Command

Alternativ zur grafischen Benutzeroberfläche ist es möglich, das IFCTerrainCommand.exe zur Erzeugung von Geländemodellen im IFC-Format zu verwenden. Dazu wird eine *.json-Datei benötigt, die die Informationen enthält, die zum Ausführen der Anwendung benötigt werden.

Im Folgenden finden Sie ein Beispiel für eine solche json-Datei und eine Tabelle mit Beschreibungen für jedes mögliche Attribut. Einige Beispiel-Json-Datensätze befinden sich im Ordner: ``IFCTerrainTestData/ 99_JSON``

![JsonSettings](pic/JsonSettings.PNG)

### JSON Attribute

Die json-Attribute zur Konvertierung eines DGM sind unten aufgeführt. Diese sind unterteilt in: **NOTWENDIGE** und **Datei-Spezifische Attribute**. 
Hinweis: Groß- und Kleinschreibung muss beachtet werden!

#### **NOTWENDIGE - Attribute**

| Attribut | Wertebereich | Beschreibung |
|:-------|:-------|:-------|
|fileName|gültiger Dateipfad string|Pfad und Dateiname der Eingabedatei|
|fileType|LandXML; CityGML; DXF; REB; Grid; OUT [string]|Dateiformat der Eingabedatei|
|is3D|true; false|Beschreibt, ob das generierte Geländemodell 3-dimensional sein soll oder nicht|
|minDist|double|Legt den Mindestabstand zwischen Knoten im Geländemodell fest|
|destFileName|gültiger Dateipfad string|Pfad und Dateiname der Ausgabedatei|
|projectName|string|Der Projektname in der Ausgabe IFC-Datei|
|editorsFamilyName|string|Nachname des Bearbeiters in der Ausgabe IFC-Datei|
|editorsGivenName|string|Vorname des Bearbeiters in der Ausgabe IFC-Datei|
|editorsOrganisation|string|Firmenname des Bearbeiters in der Ausgabe IFC-Datei|
|outIFCType|IFC2x3; IFC4|Legt die IFC version in der Ausgabedatei fest|
|outFileType|Step; XML|Legt das Dateiformat der Ausgabedatei fest|
|surfaceType|GCS; SBSM; TFS|Legt den Geländemodelltyp für die Ausgabe-IFC-Datei fest: GCS=GeometricCurveSet; SBSM=ShellBasesSurfaceModel; TFS=TriangulatedFaceSet|
|geoElement|true; false|Einstellung, die entscheidet, ob die ausgegebene IFC-Datei ein IfcGeographicElement des Geländes enthalten soll oder nicht|
|customOrigin|true; false|Beschreibt, ob der Projektkoordinatenursprung auf die benutzerdefinierte Position gesetzt werden soll oder nicht. Wenn dies nicht der Fall ist, sind die folgenden drei Zeilen nicht notwendig!|
|xOrigin|double|Die x-Komponente des benutzerdefinierten Ursprungs|
|yOrigin|double|Die y-Komponente des benutzerdefinierten Ursprungs|
|zOrigin|double|Die z-Komponente des benutzerdefinierten Ursprungs|
|gridSize|integer|Der Abstand zwischen Punkten in der *Raster-Eingabedatei*|



#### **Datei-Spezifische-Attribute**

Die Attribute des jeweiligen Dateiformats sollen hinzugefügt werden.

##### Drawing Interchange File Format (DXF)

| Attribut | Wertebereich  | Beschreibung                                                  |
| --------- | ----------- | ------------------------------------------------------------ |
| layer     | string      | Name des Layers, der Geländeinformationen in einer DXF-Eingabedatei enthält |
| isTin     | true; false | Beschreibt, ob eine Eingabe-DXF-Datei TIN-informationen (Flächen) enthält oder nicht |

##### REB (DA45, DA49, DA58)

| Attribut | Wertebereich | Beschreibung                                             |
| --------- | ---------- | ------------------------------------------------------- |
| horizon   | integer    | Nummer des Horizonts, der Geländeinformationen enthält |

##### GRAFBAT (GEOgraf OUT)

| Attribut       | Wertebereich  | Beschreibung                                                  |
| --------------- | ----------- | ------------------------------------------------------------ |
| isTin           | true; false | Entscheidet, ob die Verarbeitung über Punkte & Linien (=false) oder Flächen (=true) erfolgen soll. |
| onlyTypes       | true; false | Entscheidet, ob alle Typen (=false) oder nur ausgewählte Typen (=true) verwendet werden sollen. Wenn eine Filterung verwendet werden soll, muss die Eingabe über "layer" erfolgen. |
| layer           | string      | Bezeichnung der Typen. Trennung über: "/" ";" "," zulässig |
| onlyHorizon     | true; false | Entscheidet, ob alle Horizonte (=false) oder nur ausgewählte Horizonte (=true) verwendet werden sollen. Wenn eine Filterung verwendet werden soll, muss die Eingabe über "horizonFilter" erfolgen. |
| horizonFilter   | string      | Eingabe nur, wenn "onlyHorizon" aktiv ist. Bezeichnung von bestimmten Horizonten. Trennung über: "/" ";" "," zulässig |
| ignPos          | true; false | Entscheidet, ob der Statuscode für die Standortposition ignoriert werden soll (=true). |
| ignHeight       | true; false | Entscheidet, ob der Statuscode für die Höhenposition ignoriert werden soll (=true). |
| breakline       | true; false | Entscheidet, ob Bruchkanten verarbeitet werden sollen (true).<br />Wenn dies nicht der Fall ist, ist die folgende Zeile nicht notwendig! |
| breakline_layer | string      | Name der Ebene, die die Bruchlinie enthält. (nur eine Ebene ist erlaubt) |

##### Database (PostGIS)

| Attribut        | Wertebereich | Beschreibung                                                 |
| ---------------- | ----------- | ------------------------------------------------------------ |
| host | string | Verweis auf die Host-Datenbank |
| port | integer | Angabe des Ports für die Datenbankverbindung |
| user | string | Angabe des Benutzernamens zur Authentifizierung bei der Datenbank |
| password | string | Angabe des Passworts für die Authentifizierung bei der Datenbank |
| database | string | Zieldatenbank |
| schema | string | Zielschema |
| tin_table | string | Angabe der Tabelle, die die TIN enthält |
| tin_column | string | Geben Sie die Spalte an, die die *Geometrie* der TIN enthält |
| tinid_column | sting | Angabe der Spalte, die die *ID* der TIN enthält |
| tin_id | integer | Angabe einer TIN-ID, die ausgelesen werden soll |
| breakline | true; false | Legt fest, ob Bruchkanten verarbeitet werden sollen (true). <br />Wenn dies nicht der Fall ist, sind die folgenden Zeilen nicht notwendig! |
| breakline_table | string | Legt die Tabelle fest, die die Geometrie der Bruchkanten enthält |
| breakline_column | string | Spezifizieren Sie die Spalte, die die Geometrie der Bruchlinien enthält |
| breakline_tin_id | string | Geben Sie die Spalte an, die die TIN-ID enthält <br />!Nicht zu verwechseln mit "tin_id". |

Sobald die json-Eingabedatei fertig ist, kann man die Konsole (cmd) verwenden, um das IFCTerrainCommand.exe mit dem Dateipfad der json-Eingabedatei als Befehlszeilenargument auszuführen. Zum Beispiel:

```powershell
IFCTerrainCommand.exe "D:\Data\input\Sample.json"
```

## Logging

### GUI-Log

Die GUI zeigt die wichtigsten Arbeitsschritte an. Wenn ein Fehler (Eingabe oder im Programm) auftritt, wird dieser hier ebenfalls protokolliert.

### Log-file

Für jeden Export wird eine Protokolldatei geschrieben. Diese befindet sich immer am Speicherort der IFC-Datei. Wenn eine Konvertierung nicht wie gewünscht funktioniert, werden hier die notwendigen Informationen gespeichert.

## Anwendbarkeit von IFC Dateien in anderer Software

Beachten Sie, dass das IFCTerrain Tool IFC-Dateien nach den vorgegebenen Standards von buildingSMART erzeugt. Leider ist nicht jede Software, die mit IFC-Dateien arbeitet, in der Lage, diese Dateien vollständig zu interpretieren. Der folgende Teil enthält Informationen darüber, wie einige verfügbare Softwares IFC-Dateien, die von IFCTerrain generiert wurden, interpretieren können.

### Revit

Wenn Sie die Geländedaten mit korrekten Koordinaten verwenden möchten, ist es wichtig, den "Projektbasispunkt" an die gewünschte Stelle zu setzen (identisch mit dem Koordinatenursprung der IFCTerrain-Datei), bevor Sie die generierte IfcTerrain-Datei in Revit importieren.

Außerdem ist Revit derzeit <u>nicht möglich</u>, *IfcTriangulatedFaceSet*-Entities darzustellen.

### Solibri

Solibri importiert im Allgemeinen fast alle IFC-Informationen korrekt, ist aber derzeit <u>unfähig</u>, *IfcGeometricCurveSet*-Entities anzuzeigen.


## Test-Software für Entwickler

Das Windows-Batch-Programm ist eine ausführende Testsoftware. Es liest aus den ``IFCTerrainTestData`` die Konfigurationsdaten (``IFCTerrainTestData/ 99_JSON``) und exportiert die Ergebnisse der Testdaten in das Exportverzeichnis (``IFCTerrainTestData/ 00_Export``). Dieser Ordner wird automatisch geöffnet. Er erzeugt Test-IFC-Daten für:

- [x] TIN (LandXML, CityGML)
- [x] CAD (DXF)
- [x] GRID (XYZ)
- [x] REB (DA45, DA49, DA58)
- [x] GEOgraf (OUT)
- [ ] ~~Database (PostGIS)~~ (currently not available) 
