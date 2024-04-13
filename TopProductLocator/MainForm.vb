Imports INFITF
Imports ProductStructureTypeLib

Public Class MainForm

    Public Shared Property CATIA As Application = Nothing

    Private Sub Txt_FilePath_TextChanged(sender As Object, e As EventArgs) Handles Txt_FilePath.TextChanged
        If System.IO.Directory.Exists(Txt_FilePath.Text) Then
            Btn_GetTopProd.Enabled = True
            Txt_FilePath.BackColor = Color.White
        Else
            Btn_GetTopProd.Enabled = False
            Txt_FilePath.BackColor = Color.Salmon
        End If
    End Sub

    Private Sub Btn_GetTopProd_Click(sender As Object, e As EventArgs) Handles Btn_GetTopProd.Click
        Try
            'Clear the return box
            List_OutValues.Items.Clear()


            If GetCATIA() Then 'Make sure CATIA is open and available
                'Get the file path from the form
                Dim FilePath As String = Txt_FilePath.Text

                'Load the list of products (get their children)
                Dim ProductList = GetProducts(FilePath)

                'Check each product to see if it is a child of any of the others
                Call CheckChildren(ProductList)

                'Output back to the form
                OutputTopProducts(ProductList)

            End If

        Catch ex As Exception 'Handle catastrophic error
            MsgBox("Error occured while locating top product." & vbNewLine & vbNewLine & ex.Message, MessageBoxIcon.Warning, "Error")

            Try 'Finally, make sure file alerts get turned back on in CATIA
                MainForm.CATIA.DisplayFileAlerts = True
            Catch ex2 As Exception

            End Try
        End Try
    End Sub

    Function GetProducts(FilePath As String) As List(Of ProductFile)
        Dim FileList() As String = System.IO.Directory.GetFiles(FilePath)
        Dim RetProductList = New List(Of ProductFile)

        'Get all of the products and their children in the directory
        For i As Integer = 0 To UBound(FileList)
            Dim StrFile As String = FileList(i)

            Dim ExtType As String = System.IO.Path.GetExtension(StrFile)
            If ExtType = ".CATProduct" Or ExtType = ".CATPart" Then
                'This conditional limits the search to only .CATProduct files.
                'If you would also like to return other file types
                'in the directory that don't have a parent then you
                'can remove this conditional. You could also extend it to other
                'specific types like '... OR ExtType = ".CATPart" Then'
                'for example.

                RetProductList.Add(New ProductFile(StrFile))
            End If
        Next

        Return RetProductList
    End Function

    Sub CheckChildren(ProductList As List(Of ProductFile))
        'Check each of the products to see if they are a child of any of the others

        For Each Prod In ProductList 'Check each product
            For Each PotentialParent In ProductList 'Against each of the other products
                If PotentialParent.IsChild(Prod.FullName) Then 'If is child then set to true for that product
                    Prod.Child = True
                    Exit For
                End If
            Next
        Next
    End Sub

    Sub OutputTopProducts(ProductList As List(Of ProductFile))
        'For each of the products, output to the listbox if the IsChild handle has not been set
        For Each Prod In ProductList
            If Not Prod.Child Then
                List_OutValues.Items.Add(Prod.Name)
            End If
        Next

        'Handle no products in the directory
        If List_OutValues.Items.Count = 0 Then
            List_OutValues.Items.Add("Error: No CATProducts found in the directory")
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

Public Class ProductFile
    Public FullName As String 'Full file path for the product
    Public Name As String 'The name of the file
    Public Children = New List(Of String) 'List of all child products
    Public Child As Boolean = False 'Boolean for if this product is a child of others

    Sub New(FilePath As String)
        FullName = FilePath
        Name = System.IO.Path.GetFileName(FilePath)

        'Open the file for reading in CATIA
        MainForm.CATIA.DisplayFileAlerts = False
        Dim Doc As Document = MainForm.CATIA.Application.Documents.Read(FilePath)
        MainForm.CATIA.DisplayFileAlerts = True

        'Find all of its child products
        GetChildren(Doc.Product)

        'Close the document for reading
        Doc.Close()
    End Sub

    Function IsChild(InFullName As String) As Boolean
        'If the InFullName is contained in the children then it is a child, return true. Otherwise false.
        For Each MyChild In Children
            If MyChild = InFullName Then
                Return True
            End If
        Next

        Return False
    End Function

    Sub GetChildren(InProduct As Product)
        For Each ChildProd As Product In InProduct.Products
            'Add the child product to the Children list
            Children.Add(ChildProd.ReferenceProduct.Parent.FullName)

            If ChildProd.Products.Count > 0 Then 'If the child product has children of its own
                GetChildren(ChildProd) 'Recursively call GetChildren (this function) for any products that have sub-products
            End If
        Next
    End Sub
End Class
