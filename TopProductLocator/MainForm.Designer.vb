<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.TPL_UI = New TopProductLocator.TopProductLocate_UI()
        Me.SuspendLayout()
        '
        'TPL_UI
        '
        Me.TPL_UI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TPL_UI.Location = New System.Drawing.Point(0, 0)
        Me.TPL_UI.Name = "TPL_UI"
        Me.TPL_UI.Size = New System.Drawing.Size(484, 186)
        Me.TPL_UI.TabIndex = 0
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 186)
        Me.Controls.Add(Me.TPL_UI)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(325, 200)
        Me.Name = "MainForm"
        Me.Text = "Top Product Locator"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TPL_UI As TopProductLocate_UI
End Class
