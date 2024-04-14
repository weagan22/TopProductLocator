Imports INFITF
Imports ProductStructureTypeLib
Imports System.IO

Public Class ProductFile
    Public FullName As String 'Full file path for the product
    Public Name As String 'The name of the file
    Public Children = New List(Of String) 'List of all child products
    Public Child As Boolean = False 'Boolean for if this product is a child of others
    Public IsProduct As Boolean = False

    Sub New(FilePath As String)
        FullName = FilePath
        Name = Path.GetFileName(FilePath)

        If Path.GetExtension(FullName) = ".CATProduct" Then IsProduct = True

        If IsProduct Then 'Get the products children, skips this for parts
            'Open the file for reading in CATIA
            CATIA.DisplayFileAlerts = False
            Dim Doc As Document = CATIA.Application.Documents.Read(FilePath)
            CATIA.DisplayFileAlerts = True

            'Find all of its child products
            GetChildren(Doc.Product)

            'Close the document for reading
            Doc.Close()
        End If

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
