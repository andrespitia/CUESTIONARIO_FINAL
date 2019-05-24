<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reporte
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.CUESTIONARIO_FINALDataSet3 = New cuestionario__proyecto.CUESTIONARIO_FINALDataSet3()
        Me.NIVELBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NIVELTableAdapter = New cuestionario__proyecto.CUESTIONARIO_FINALDataSet3TableAdapters.NIVELTableAdapter()
        CType(Me.CUESTIONARIO_FINALDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NIVELBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.NIVELBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.ServerReport.ReportPath = "/reporte3"
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'CUESTIONARIO_FINALDataSet3
        '
        Me.CUESTIONARIO_FINALDataSet3.DataSetName = "CUESTIONARIO_FINALDataSet3"
        Me.CUESTIONARIO_FINALDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'NIVELBindingSource
        '
        Me.NIVELBindingSource.DataMember = "NIVEL"
        Me.NIVELBindingSource.DataSource = Me.CUESTIONARIO_FINALDataSet3
        '
        'NIVELTableAdapter
        '
        Me.NIVELTableAdapter.ClearBeforeFill = True
        '
        'reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "reporte"
        Me.Text = "reporte"
        CType(Me.CUESTIONARIO_FINALDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NIVELBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents NIVELBindingSource As BindingSource
    Friend WithEvents CUESTIONARIO_FINALDataSet3 As CUESTIONARIO_FINALDataSet3
    Friend WithEvents NIVELTableAdapter As CUESTIONARIO_FINALDataSet3TableAdapters.NIVELTableAdapter
End Class
