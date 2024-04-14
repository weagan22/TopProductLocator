Imports System.IO

Class TopProductLocate_Core

    Shared Sub Execute(FilePath As String, OutputParts As Boolean, StatusLabel As ToolStripStatusLabel, OutputBox As ListBox)
        'Load the list of products (get their children)
        Dim ProductList = GetProducts(FilePath, OutputParts, StatusLabel)

        'Check each product to see if it is a child of any of the others
        Call CheckChildren(ProductList)

        'Sort the product list so products are first
        ProductList.Sort(New ProductFileComparer())

        'Output back to the form
        OutputTopProducts(ProductList, OutputBox)
    End Sub

    Private Shared Function GetProducts(FilePath As String, OutputParts As Boolean, StatusLabel As ToolStripStatusLabel) As List(Of ProductFile)
        Dim FileList() As String = Directory.GetFiles(FilePath, "*", SearchOption.TopDirectoryOnly)
        Dim RetProductList = New List(Of ProductFile)

        'Get the number of files that are going to be checked to provide status
        Dim StatusFileCount As Integer = StatusCount(FileList)

        'Get all of the products and their children in the directory
        Dim StatusCnt As Integer = 0
        For i As Integer = 0 To UBound(FileList)

            Dim StrFile As String = FileList(i)
            Dim ExtType As String = Path.GetExtension(StrFile)

            If ExtType = ".CATProduct" Or (OutputParts And ExtType = ".CATPart") Then 'This conditional limits the search to only .CATProduct files unless Get Parts is checked.

                If ExtType = ".CATProduct" Then 'Only status products since they are what take time to load in CATIA
                    StatusCnt += 1
                    StatusLabel.Text = $"Running Locate | Files: {StatusCnt}/{StatusFileCount} | Current File: {Path.GetFileName(StrFile)}"
                End If

                RetProductList.Add(New ProductFile(StrFile))
            End If
        Next

        Return RetProductList
    End Function

    Private Shared Function StatusCount(FileList() As String) As Integer
        'Get the number of files that are going to be checked to provide status
        Dim ReturnFileCount As Integer
        For Each StrFile As String In FileList
            Dim ExtType As String = Path.GetExtension(StrFile)

            If ExtType = ".CATProduct" Then 'Only status products since they are what take time to load in CATIA
                ReturnFileCount += 1
            End If
        Next

        Return ReturnFileCount
    End Function

    Private Shared Sub CheckChildren(ProductList As List(Of ProductFile))
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

    Private Shared Sub OutputTopProducts(ProductList As List(Of ProductFile), OutputBox As ListBox)

        'For each of the products, output to the listbox if the IsChild handle has not been set
        For Each Prod In ProductList
            If Not Prod.Child Then
                OutputBox.Items.Add(Prod.Name)
            End If
        Next

        'Handle no products in the directory
        If OutputBox.Items.Count = 0 Then
            OutputBox.Items.Add("No products located in the specified directory")
        End If
    End Sub
End Class
