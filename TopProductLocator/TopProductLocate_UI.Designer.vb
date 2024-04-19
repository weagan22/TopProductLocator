<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopProductLocate_UI
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LayoutPanel_Global = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutPanel_PathButton = New System.Windows.Forms.TableLayoutPanel()
        Me.Box_TopProds = New System.Windows.Forms.GroupBox()
        Me.List_OutValues = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Btn_GetTopProd = New System.Windows.Forms.Button()
        Me.Chk_GetParts = New System.Windows.Forms.CheckBox()
        Me.Box_FilePath = New System.Windows.Forms.GroupBox()
        Me.Txt_FilePath = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LayoutPanel_Global.SuspendLayout()
        Me.LayoutPanel_PathButton.SuspendLayout()
        Me.Box_TopProds.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Box_FilePath.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutPanel_Global
        '
        Me.LayoutPanel_Global.ColumnCount = 1
        Me.LayoutPanel_Global.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPanel_Global.Controls.Add(Me.LayoutPanel_PathButton, 0, 1)
        Me.LayoutPanel_Global.Controls.Add(Me.Box_FilePath, 0, 0)
        Me.LayoutPanel_Global.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPanel_Global.Location = New System.Drawing.Point(0, 0)
        Me.LayoutPanel_Global.Name = "LayoutPanel_Global"
        Me.LayoutPanel_Global.RowCount = 2
        Me.LayoutPanel_Global.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.LayoutPanel_Global.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPanel_Global.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.LayoutPanel_Global.Size = New System.Drawing.Size(484, 186)
        Me.LayoutPanel_Global.TabIndex = 2
        '
        'LayoutPanel_PathButton
        '
        Me.LayoutPanel_PathButton.ColumnCount = 2
        Me.LayoutPanel_PathButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPanel_PathButton.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.LayoutPanel_PathButton.Controls.Add(Me.Box_TopProds, 0, 0)
        Me.LayoutPanel_PathButton.Controls.Add(Me.TableLayoutPanel1, 1, 0)
        Me.LayoutPanel_PathButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutPanel_PathButton.Location = New System.Drawing.Point(3, 53)
        Me.LayoutPanel_PathButton.Name = "LayoutPanel_PathButton"
        Me.LayoutPanel_PathButton.RowCount = 1
        Me.LayoutPanel_PathButton.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LayoutPanel_PathButton.Size = New System.Drawing.Size(478, 130)
        Me.LayoutPanel_PathButton.TabIndex = 2
        '
        'Box_TopProds
        '
        Me.Box_TopProds.Controls.Add(Me.List_OutValues)
        Me.Box_TopProds.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Box_TopProds.Location = New System.Drawing.Point(3, 3)
        Me.Box_TopProds.Name = "Box_TopProds"
        Me.Box_TopProds.Size = New System.Drawing.Size(322, 124)
        Me.Box_TopProds.TabIndex = 1
        Me.Box_TopProds.TabStop = False
        Me.Box_TopProds.Text = "Top Product(s)"
        Me.ToolTip1.SetToolTip(Me.Box_TopProds, "Top Product(s)")
        '
        'List_OutValues
        '
        Me.List_OutValues.Dock = System.Windows.Forms.DockStyle.Fill
        Me.List_OutValues.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List_OutValues.ItemHeight = 16
        Me.List_OutValues.Location = New System.Drawing.Point(3, 16)
        Me.List_OutValues.Name = "List_OutValues"
        Me.List_OutValues.Size = New System.Drawing.Size(316, 105)
        Me.List_OutValues.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.List_OutValues, "Search Results: Products that are not a child of any other products in the specif" &
        "ied directory.")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Btn_GetTopProd, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Chk_GetParts, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(331, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(144, 124)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Btn_GetTopProd
        '
        Me.Btn_GetTopProd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Btn_GetTopProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Btn_GetTopProd.Enabled = False
        Me.Btn_GetTopProd.Image = Global.TopProductLocator.My.Resources.Resources.MagGlass
        Me.Btn_GetTopProd.Location = New System.Drawing.Point(3, 3)
        Me.Btn_GetTopProd.Name = "Btn_GetTopProd"
        Me.Btn_GetTopProd.Size = New System.Drawing.Size(138, 44)
        Me.Btn_GetTopProd.TabIndex = 0
        Me.Btn_GetTopProd.Text = "Run Search"
        Me.Btn_GetTopProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.Btn_GetTopProd, "Locate the top product(s) within the specified file path.")
        Me.Btn_GetTopProd.UseVisualStyleBackColor = True
        '
        'Chk_GetParts
        '
        Me.Chk_GetParts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chk_GetParts.AutoSize = True
        Me.Chk_GetParts.Location = New System.Drawing.Point(3, 53)
        Me.Chk_GetParts.Name = "Chk_GetParts"
        Me.Chk_GetParts.Size = New System.Drawing.Size(138, 17)
        Me.Chk_GetParts.TabIndex = 1
        Me.Chk_GetParts.Text = "Include Parts"
        Me.ToolTip1.SetToolTip(Me.Chk_GetParts, "Return parts that do not have a parent product.")
        Me.Chk_GetParts.UseVisualStyleBackColor = True
        '
        'Box_FilePath
        '
        Me.Box_FilePath.Controls.Add(Me.Txt_FilePath)
        Me.Box_FilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Box_FilePath.Location = New System.Drawing.Point(3, 3)
        Me.Box_FilePath.Name = "Box_FilePath"
        Me.Box_FilePath.Size = New System.Drawing.Size(478, 44)
        Me.Box_FilePath.TabIndex = 0
        Me.Box_FilePath.TabStop = False
        Me.Box_FilePath.Text = "File Path/Directory"
        Me.ToolTip1.SetToolTip(Me.Box_FilePath, "File Path/Directory")
        '
        'Txt_FilePath
        '
        Me.Txt_FilePath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Txt_FilePath.Location = New System.Drawing.Point(3, 16)
        Me.Txt_FilePath.Name = "Txt_FilePath"
        Me.Txt_FilePath.Size = New System.Drawing.Size(472, 20)
        Me.Txt_FilePath.TabIndex = 0
        Me.Txt_FilePath.Text = "File path here..."
        Me.ToolTip1.SetToolTip(Me.Txt_FilePath, "File path here...")
        '
        'TopProductLocate_UI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LayoutPanel_Global)
        Me.Name = "TopProductLocate_UI"
        Me.Size = New System.Drawing.Size(484, 186)
        Me.LayoutPanel_Global.ResumeLayout(False)
        Me.LayoutPanel_PathButton.ResumeLayout(False)
        Me.Box_TopProds.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Box_FilePath.ResumeLayout(False)
        Me.Box_FilePath.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutPanel_Global As TableLayoutPanel
    Friend WithEvents LayoutPanel_PathButton As TableLayoutPanel
    Friend WithEvents Box_TopProds As GroupBox
    Friend WithEvents List_OutValues As ListBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Btn_GetTopProd As Button
    Friend WithEvents Chk_GetParts As CheckBox
    Friend WithEvents Box_FilePath As GroupBox
    Friend WithEvents Txt_FilePath As TextBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
