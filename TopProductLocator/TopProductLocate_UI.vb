Imports System.IO

Public Class TopProductLocate_UI
    Private Sub Txt_FilePath_TextChanged(sender As Object, e As EventArgs) Handles Txt_FilePath.TextChanged
        If System.IO.Directory.Exists(Txt_FilePath.Text) Then
            Btn_GetTopProd.Enabled = True
            Txt_FilePath.BackColor = Color.White

        ElseIf Txt_FilePath.Text = "File path here..." Then
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
                If Not Directory.Exists(FilePath) Then
                    Throw New Exception("Specified directory does not exist.")
                End If

                TopProductLocate_Core.Execute(FilePath, Chk_GetParts.Checked, ToolStripStatusLabel1, List_OutValues)

            End If

            ToolStripStatusLabel1.Text = "Ready..."

        Catch ex As Exception 'Handle catastrophic error
            MsgBox("Error occured while locating top product." & vbNewLine & vbNewLine & ex.Message, MessageBoxIcon.Warning, "Error")

            Try 'Finally, make sure file alerts get turned back on in CATIA
                ToolStripStatusLabel1.Text = "Ready..."
                CATIA.DisplayFileAlerts = True
            Catch ex2 As Exception

            End Try
        End Try
    End Sub


#Region "Enter key to run on all features"
    Private Sub Txt_FilePath_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_FilePath.KeyDown
        Call EnterKeyRun(sender, e)
    End Sub
    Private Sub Chk_GetParts_KeyDown(sender As Object, e As KeyEventArgs) Handles Chk_GetParts.KeyDown
        Call EnterKeyRun(sender, e)
    End Sub
    Private Sub List_OutValues_KeyDown(sender As Object, e As KeyEventArgs) Handles List_OutValues.KeyDown
        Call EnterKeyRun(sender, e)
    End Sub
    Private Sub Btn_GetTopProd_KeyDown(sender As Object, e As KeyEventArgs) Handles Btn_GetTopProd.KeyDown
        Call EnterKeyRun(sender, e)
    End Sub
    Sub EnterKeyRun(sender As Object, e As KeyEventArgs)
        If e.KeyValue = Keys.Enter Then
            If Btn_GetTopProd.Enabled Then
                Call Btn_GetTopProd_Click(sender, e)
            End If
        End If
    End Sub
#End Region
End Class
