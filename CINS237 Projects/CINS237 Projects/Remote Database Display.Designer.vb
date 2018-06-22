<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Remote_Database_Display
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DB_24101_danielDataSet = New CINS237_Projects.DB_24101_danielDataSet()
        Me.DB24101danielDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UsridDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsrnameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_24101_danielDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB24101danielDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UsridDataGridViewTextBoxColumn, Me.UsrnameDataGridViewTextBoxColumn})
        Me.DataGridView1.DataMember = "tblUser"
        Me.DataGridView1.DataSource = Me.DB24101danielDataSetBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(556, 315)
        Me.DataGridView1.TabIndex = 0
        '
        'DB_24101_danielDataSet
        '
        Me.DB_24101_danielDataSet.DataSetName = "DB_24101_danielDataSet"
        Me.DB_24101_danielDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DB24101danielDataSetBindingSource
        '
        Me.DB24101danielDataSetBindingSource.DataSource = Me.DB_24101_danielDataSet
        Me.DB24101danielDataSetBindingSource.Position = 0
        '
        'UsridDataGridViewTextBoxColumn
        '
        Me.UsridDataGridViewTextBoxColumn.DataPropertyName = "usr_id"
        Me.UsridDataGridViewTextBoxColumn.HeaderText = "usr_id"
        Me.UsridDataGridViewTextBoxColumn.Name = "UsridDataGridViewTextBoxColumn"
        Me.UsridDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UsrnameDataGridViewTextBoxColumn
        '
        Me.UsrnameDataGridViewTextBoxColumn.DataPropertyName = "usr_name"
        Me.UsrnameDataGridViewTextBoxColumn.HeaderText = "usr_name"
        Me.UsrnameDataGridViewTextBoxColumn.Name = "UsrnameDataGridViewTextBoxColumn"
        '
        'Remote_Database_Display
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 315)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Remote_Database_Display"
        Me.Text = "Remote_Database_Display"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_24101_danielDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB24101danielDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DB24101danielDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DB_24101_danielDataSet As CINS237_Projects.DB_24101_danielDataSet
    Friend WithEvents UsridDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsrnameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
