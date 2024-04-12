Imports INFITF
Imports ProductStructureTypeLib

Public Class MainForm

    Public Shared Property CATIA As Application = Nothing

    Private Sub Btn_GetTopProd_Click(sender As Object, e As EventArgs) Handles Btn_GetTopProd.Click
        Try
            'Clear the return box
            List_OutValues.Items.Clear()

            'Make sure CATIA is open and available
            If GetCATIA() Then
                Dim FilePath As String = Txt_FilePath.Text

                Dim FileList() As String = System.IO.Directory.GetFiles(FilePath)
                Dim ProductList = New List(Of ProductFile)

                For i As Integer = 0 To UBound(FileList)
                    Dim StrFile As String = FileList(i)

                    If System.IO.Path.GetExtension(StrFile) = ".CATProduct" Then
                        ProductList.Add(New ProductFile(StrFile))
                    End If
                Next


                For Each Prod In ProductList
                    For Each PotentialParent In ProductList
                        If PotentialParent.CheckIsChild(Prod.FullName) Then
                            Prod.IsChild = True
                            Exit For
                        End If
                    Next
                Next


                For Each Prod In ProductList
                    If Not Prod.IsChild Then
                        List_OutValues.Items.Add(Prod.Name)
                    End If
                Next

                If List_OutValues.Items.Count = 0 Then
                    List_OutValues.Items.Add("Error: No CATProducts found in the directory")
                End If


            End If

        Catch ex As Exception
            MsgBox("Error occured while locating top product." & vbNewLine & vbNewLine & ex.Message, MessageBoxIcon.Warning, "Error")
        End Try
    End Sub

    Private Sub Txt_FilePath_TextChanged(sender As Object, e As EventArgs) Handles Txt_FilePath.TextChanged
        If System.IO.Directory.Exists(Txt_FilePath.Text) Then
            Btn_GetTopProd.Enabled = True
            Txt_FilePath.BackColor = Color.White
        Else
            Btn_GetTopProd.Enabled = False
            Txt_FilePath.BackColor = Color.Salmon
        End If
    End Sub


    Function GetCATIA() As Boolean
        Dim countTest As Integer = 0

        For Each p As Process In Process.GetProcesses()
            If p.ProcessName = "CNEXT" Then
                If countTest = 1 Then
                    MsgBox("More than one instance of CATIA is running please make sure only one instance is running prior to running this macro",, "Error")
                    Return False
                End If
                countTest = 1
            End If
        Next


        If countTest = 0 Then
            MsgBox("CATIA is not running.", MessageBoxIcon.Warning, "Error")
            Return False
        End If


        'Get CATIA object
        Try
            CATIA = GetObject(, "CATIA.application")
        Catch
            Return False
        End Try

        Return True
    End Function
End Class

Class ProductFile
    Public FullName As String
    Public Name As String
    Public Children = New List(Of String)
    Public IsChild As Boolean = False

    Sub New(FilePath As String)
        FullName = FilePath
        Name = System.IO.Path.GetFileName(FilePath)

        Dim Doc As Document = MainForm.CATIA.Application.Documents.Read(FilePath)

        GetChildren(Doc.Product)

        Doc.Close()
    End Sub

    Function CheckIsChild(InFullName As String) As Boolean
        For Each Child In Children
            If Child = InFullName Then
                Return True
            End If
        Next

        Return False
    End Function

    Sub GetChildren(InProduct As Product)
        For Each ChildProd As Product In InProduct.Products
            Children.Add(ChildProd.ReferenceProduct.Parent.FullName)
            If ChildProd.Products.Count > 0 Then
                GetChildren(ChildProd)
            End If
        Next
    End Sub
End Class
