' NX 1973
' Journal created by pierre.leroy on Fri Jan 12 13:55:12 2024 Paris, Madrid
'
Imports System
Imports NXOpen

Module NXJournal
Sub Main (ByVal args() As String) 

Dim theSession As NXOpen.Session = NXOpen.Session.GetSession()
Dim workPart As NXOpen.Part = theSession.Parts.Work

Dim displayPart As NXOpen.Part = theSession.Parts.Display

Dim markId1 As NXOpen.Session.UndoMarkId = Nothing
markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Import Expressions")

Dim expModified1 As Boolean = Nothing
Dim errorMessages1() As String
Try
  ' Expression import failed.
    workPart.Expressions.ImportFromFile("C:\temp\Parametric.exp", NXOpen.ExpressionCollection.ImportMode.Replace, expModified1, errorMessages1)
    theSession.UpdateManager.UpdateModel(workPart, markId1)
Catch ex As NXException
  ex.AssertErrorCode(1050053)
End Try

' ----------------------------------------------
'   Menu: Tools->Journal->Stop Recording
' ----------------------------------------------

End Sub
End Module
