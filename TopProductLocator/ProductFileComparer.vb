Imports System.IO

Public Class ProductFileComparer
    Implements IComparer(Of ProductFile)

    Private Declare Unicode Function StrCmpLogicalW Lib "shlwapi" (ByVal s1 As String, ByVal s2 As String) As Integer

    Public Function Compare(F1 As ProductFile, F2 As ProductFile) As Integer Implements IComparer(Of ProductFile).Compare

        'Sort products before parts
        If F1.IsProduct And Not F2.IsProduct Then
            Return -1
        End If

        If Not F1.IsProduct And F2.IsProduct Then
            Return 1
        End If

        'If the same file type then just sort by name, ignore extensions for sorting purposes
        Return StrCmpLogicalW(Path.GetFileNameWithoutExtension(F1.Name), Path.GetFileNameWithoutExtension(F2.Name))

    End Function

End Class
