﻿Imports INFITF
Imports ProductStructureTypeLib
Imports System.Drawing.Imaging
Imports System.IO

Public Class MainForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim vers As Version = My.Application.Info.Version
        Me.Text = "Top Product Locator " & vers.Major & "." & vers.Minor & "." & vers.Build

        TPL_UI.StatusLabel = ToolStripStatusLabel1
    End Sub

End Class
