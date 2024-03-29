' NX 1973
' Journal created by pierre.leroy on Thu Feb  1 10:59:49 2024 Paris, Madrid
'
Imports System
Imports NXOpen

Module NXJournal
Sub Main (ByVal args() As String) 

Dim theSession As NXOpen.Session = NXOpen.Session.GetSession()
Dim workPart As NXOpen.Part = theSession.Parts.Work

Dim displayPart As NXOpen.Part = theSession.Parts.Display

' ----------------------------------------------
'   Menu: Format->Move to Layer...
' ----------------------------------------------
Dim markId1 As NXOpen.Session.UndoMarkId = Nothing
markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Move Layer")

Dim objectArray1(0) As NXOpen.DisplayableObject
Dim sketchFeature1 As NXOpen.Features.SketchFeature = CType(workPart.Features.FindObject("SKETCH(1)"), NXOpen.Features.SketchFeature)

Dim sketch1 As NXOpen.Sketch = CType(sketchFeature1.FindObject("SKETCH_000"), NXOpen.Sketch)

objectArray1(0) = sketch1
workPart.Layers.MoveDisplayableObjects(60, objectArray1)

' ----------------------------------------------
'   Menu: Tools->Journal->Stop Recording
' ----------------------------------------------

End Sub
End Module