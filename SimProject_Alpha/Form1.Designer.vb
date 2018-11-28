<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrefrencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeBackcolorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeNodesColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeGColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeHColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevelopersOpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListFunctionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListConnectionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListLoopsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CasesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Case1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Case2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Case3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Case4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Case5ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Case6ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListForwardPathsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListPathDeltasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowNonTouchingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportSystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.DevelopersOpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(847, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGraphToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewGraphToolStripMenuItem
        '
        Me.NewGraphToolStripMenuItem.Name = "NewGraphToolStripMenuItem"
        Me.NewGraphToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.NewGraphToolStripMenuItem.Text = "New Graph"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrefrencesToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'PrefrencesToolStripMenuItem
        '
        Me.PrefrencesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeBackcolorToolStripMenuItem, Me.ChangeNodesColorToolStripMenuItem, Me.ChangeGColorToolStripMenuItem, Me.ChangeHColorToolStripMenuItem})
        Me.PrefrencesToolStripMenuItem.Name = "PrefrencesToolStripMenuItem"
        Me.PrefrencesToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PrefrencesToolStripMenuItem.Text = "Prefrences"
        '
        'ChangeBackcolorToolStripMenuItem
        '
        Me.ChangeBackcolorToolStripMenuItem.Name = "ChangeBackcolorToolStripMenuItem"
        Me.ChangeBackcolorToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ChangeBackcolorToolStripMenuItem.Text = "Change Backcolor"
        '
        'ChangeNodesColorToolStripMenuItem
        '
        Me.ChangeNodesColorToolStripMenuItem.Name = "ChangeNodesColorToolStripMenuItem"
        Me.ChangeNodesColorToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ChangeNodesColorToolStripMenuItem.Text = "Change Nodes Color"
        '
        'ChangeGColorToolStripMenuItem
        '
        Me.ChangeGColorToolStripMenuItem.Name = "ChangeGColorToolStripMenuItem"
        Me.ChangeGColorToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ChangeGColorToolStripMenuItem.Text = "Change G color"
        '
        'ChangeHColorToolStripMenuItem
        '
        Me.ChangeHColorToolStripMenuItem.Name = "ChangeHColorToolStripMenuItem"
        Me.ChangeHColorToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ChangeHColorToolStripMenuItem.Text = "Change H color"
        '
        'DevelopersOpToolStripMenuItem
        '
        Me.DevelopersOpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListFunctionsToolStripMenuItem, Me.ListConnectionsToolStripMenuItem, Me.ListLoopsToolStripMenuItem, Me.CasesToolStripMenuItem, Me.ListForwardPathsToolStripMenuItem, Me.ListPathDeltasToolStripMenuItem, Me.ShowNonTouchingToolStripMenuItem, Me.ReportSystemToolStripMenuItem})
        Me.DevelopersOpToolStripMenuItem.Name = "DevelopersOpToolStripMenuItem"
        Me.DevelopersOpToolStripMenuItem.Size = New System.Drawing.Size(103, 20)
        Me.DevelopersOpToolStripMenuItem.Text = "Developer Tools"
        '
        'ListFunctionsToolStripMenuItem
        '
        Me.ListFunctionsToolStripMenuItem.Name = "ListFunctionsToolStripMenuItem"
        Me.ListFunctionsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ListFunctionsToolStripMenuItem.Text = "List Functions "
        '
        'ListConnectionsToolStripMenuItem
        '
        Me.ListConnectionsToolStripMenuItem.Name = "ListConnectionsToolStripMenuItem"
        Me.ListConnectionsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ListConnectionsToolStripMenuItem.Text = "List Connections"
        '
        'ListLoopsToolStripMenuItem
        '
        Me.ListLoopsToolStripMenuItem.Name = "ListLoopsToolStripMenuItem"
        Me.ListLoopsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ListLoopsToolStripMenuItem.Text = "List Loops"
        '
        'CasesToolStripMenuItem
        '
        Me.CasesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Case1ToolStripMenuItem, Me.Case2ToolStripMenuItem, Me.Case3ToolStripMenuItem, Me.Case4ToolStripMenuItem, Me.Case5ToolStripMenuItem, Me.Case6ToolStripMenuItem})
        Me.CasesToolStripMenuItem.Name = "CasesToolStripMenuItem"
        Me.CasesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CasesToolStripMenuItem.Text = "Cases"
        '
        'Case1ToolStripMenuItem
        '
        Me.Case1ToolStripMenuItem.Name = "Case1ToolStripMenuItem"
        Me.Case1ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.Case1ToolStripMenuItem.Text = "case 1"
        '
        'Case2ToolStripMenuItem
        '
        Me.Case2ToolStripMenuItem.Name = "Case2ToolStripMenuItem"
        Me.Case2ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.Case2ToolStripMenuItem.Text = "case 2"
        '
        'Case3ToolStripMenuItem
        '
        Me.Case3ToolStripMenuItem.Name = "Case3ToolStripMenuItem"
        Me.Case3ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.Case3ToolStripMenuItem.Text = "case 3"
        '
        'Case4ToolStripMenuItem
        '
        Me.Case4ToolStripMenuItem.Name = "Case4ToolStripMenuItem"
        Me.Case4ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.Case4ToolStripMenuItem.Text = "case 4"
        '
        'Case5ToolStripMenuItem
        '
        Me.Case5ToolStripMenuItem.Name = "Case5ToolStripMenuItem"
        Me.Case5ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.Case5ToolStripMenuItem.Text = "case 5"
        '
        'Case6ToolStripMenuItem
        '
        Me.Case6ToolStripMenuItem.Name = "Case6ToolStripMenuItem"
        Me.Case6ToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.Case6ToolStripMenuItem.Text = "case 6"
        '
        'ListForwardPathsToolStripMenuItem
        '
        Me.ListForwardPathsToolStripMenuItem.Name = "ListForwardPathsToolStripMenuItem"
        Me.ListForwardPathsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ListForwardPathsToolStripMenuItem.Text = "List Forward Paths"
        '
        'ListPathDeltasToolStripMenuItem
        '
        Me.ListPathDeltasToolStripMenuItem.Name = "ListPathDeltasToolStripMenuItem"
        Me.ListPathDeltasToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ListPathDeltasToolStripMenuItem.Text = "list path deltas"
        '
        'ShowNonTouchingToolStripMenuItem
        '
        Me.ShowNonTouchingToolStripMenuItem.Name = "ShowNonTouchingToolStripMenuItem"
        Me.ShowNonTouchingToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ShowNonTouchingToolStripMenuItem.Text = "list non touching"
        '
        'ReportSystemToolStripMenuItem
        '
        Me.ReportSystemToolStripMenuItem.Name = "ReportSystemToolStripMenuItem"
        Me.ReportSystemToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ReportSystemToolStripMenuItem.Text = "report system "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 509)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Signal Flow Graph Analyzer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewGraphToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrefrencesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeBackcolorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeNodesColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeGColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeHColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DevelopersOpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListFunctionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListConnectionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListLoopsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CasesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Case1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Case2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Case3ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Case4ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListForwardPathsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListPathDeltasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Case5ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowNonTouchingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportSystemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Case6ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorDialog1 As ColorDialog
End Class
