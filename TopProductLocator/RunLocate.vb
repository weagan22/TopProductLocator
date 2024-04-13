﻿Imports System.IO

Module RunLocate

    Sub Run(FilePath As String)
        'Load the list of products (get their children)
        Dim ProductList = GetProducts(FilePath)

        'Check each product to see if it is a child of any of the others
        Call CheckChildren(ProductList)

        'Sort the product list so products are first
        ProductList.Sort(New ProductFileComparer())

        'Output back to the form
        OutputTopProducts(ProductList)
    End Sub
    Function GetProducts(FilePath As String) As List(Of ProductFile)
        Dim FileList() As String = System.IO.Directory.GetFiles(FilePath)
        Dim RetProductList = New List(Of ProductFile)

        'Get the number of files that are going to be checked to provide status
        Dim StatusFileCount As Integer = StatusCount(FileList)

        'Get all of the products and their children in the directory
        Dim StatusCnt As Integer = 0
        For i As Integer = 0 To UBound(FileList)

            Dim StrFile As String = FileList(i)
            Dim ExtType As String = System.IO.Path.GetExtension(StrFile)

            If ExtType = ".CATProduct" Or (MainForm.Chk_GetParts.Checked And ExtType = ".CATPart") Then 'This conditional limits the search to only .CATProduct files unless Get Parts is checked.

                If ExtType = ".CATProduct" Then 'Only status products since they are what take time to load in CATIA
                    StatusCnt += 1
                    MainForm.ToolStripStatusLabel1.Text = $"Running Locate | Files: {StatusCnt}/{StatusFileCount} | Current File: {Path.GetFileName(StrFile)}"
                End If

                RetProductList.Add(New ProductFile(StrFile))
            End If
        Next

        Return RetProductList
    End Function

    Function StatusCount(FileList() As String) As Integer
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
                MainForm.List_OutValues.Items.Add(Prod.Name)
            End If
        Next

        'Handle no products in the directory
        If MainForm.List_OutValues.Items.Count = 0 Then
            MainForm.List_OutValues.Items.Add("No products located in the specified directory")
        End If
    End Sub
End Module
