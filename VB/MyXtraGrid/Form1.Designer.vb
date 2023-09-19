' Developer Express Code Central Example:
' How to customize the GridControl's print output.
' 
' This example demonstrates how to override the default exporting process to take
' into account a custom drawn content provided via the
' GridView.CustomDrawFooterCell Event
' (ms-help://DevExpress.NETv10.1/DevExpress.WindowsForms/DevExpressXtraGridViewsGridGridView_CustomDrawFooterCelltopic.htm)
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2667
Namespace MyXtraGrid

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.myGridControl1 = New MyXtraGrid.MyGridControl()
            Me.myGridView1 = New MyXtraGrid.MyGridView()
            Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.gridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.gridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.gridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.simpleButton1 = New DevExpress.XtraEditors.SimpleButton()
            CType((Me.myGridControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.myGridView1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' myGridControl1
            ' 
            Me.myGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.myGridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
            Me.myGridControl1.Location = New System.Drawing.Point(0, 0)
            Me.myGridControl1.MainView = Me.myGridView1
            Me.myGridControl1.Margin = New System.Windows.Forms.Padding(4)
            Me.myGridControl1.Name = "myGridControl1"
            Me.myGridControl1.Size = New System.Drawing.Size(887, 618)
            Me.myGridControl1.TabIndex = 1
            Me.myGridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.myGridView1})
            ' 
            ' myGridView1
            ' 
            Me.myGridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gridColumn1, Me.gridColumn2, Me.gridColumn3, Me.gridColumn4})
            Me.myGridView1.GridControl = Me.myGridControl1
            Me.myGridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "Number", Me.gridColumn2, "")})
            Me.myGridView1.IndicatorWidth = 100
            Me.myGridView1.Name = "myGridView1"
            Me.myGridView1.OptionsView.ShowFooter = True
            AddHandler Me.myGridView1.CustomDrawRowIndicator, New DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(AddressOf Me.myGridView1_CustomDrawRowIndicator)
            AddHandler Me.myGridView1.CustomDrawFooterCell, New DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(AddressOf Me.myGridView1_CustomDrawFooterCell)
            ' 
            ' gridColumn1
            ' 
            Me.gridColumn1.Caption = "gridColumn1"
            Me.gridColumn1.FieldName = "Name"
            Me.gridColumn1.Name = "gridColumn1"
            Me.gridColumn1.Visible = True
            Me.gridColumn1.VisibleIndex = 1
            ' 
            ' gridColumn2
            ' 
            Me.gridColumn2.Caption = "gridColumn2"
            Me.gridColumn2.FieldName = "Number"
            Me.gridColumn2.Name = "gridColumn2"
            Me.gridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
            Me.gridColumn2.Visible = True
            Me.gridColumn2.VisibleIndex = 0
            ' 
            ' gridColumn3
            ' 
            Me.gridColumn3.Caption = "gridColumn3"
            Me.gridColumn3.FieldName = "ID"
            Me.gridColumn3.Name = "gridColumn3"
            Me.gridColumn3.Visible = True
            Me.gridColumn3.VisibleIndex = 2
            ' 
            ' gridColumn4
            ' 
            Me.gridColumn4.Caption = "gridColumn4"
            Me.gridColumn4.FieldName = "Date"
            Me.gridColumn4.Name = "gridColumn4"
            Me.gridColumn4.Visible = True
            Me.gridColumn4.VisibleIndex = 3
            ' 
            ' simpleButton1
            ' 
            Me.simpleButton1.Location = New System.Drawing.Point(767, 16)
            Me.simpleButton1.Margin = New System.Windows.Forms.Padding(4)
            Me.simpleButton1.Name = "simpleButton1"
            Me.simpleButton1.Size = New System.Drawing.Size(100, 28)
            Me.simpleButton1.TabIndex = 2
            Me.simpleButton1.Text = "Print"
            AddHandler Me.simpleButton1.Click, New System.EventHandler(AddressOf Me.simpleButton1_Click)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(887, 618)
            Me.Controls.Add(Me.simpleButton1)
            Me.Controls.Add(Me.myGridControl1)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "Form1"
            Me.Text = "Form1"
            CType((Me.myGridControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.myGridView1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private myGridControl1 As MyXtraGrid.MyGridControl

        Private myGridView1 As MyXtraGrid.MyGridView

        Private gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn

        Private gridColumn2 As DevExpress.XtraGrid.Columns.GridColumn

        Private gridColumn3 As DevExpress.XtraGrid.Columns.GridColumn

        Private simpleButton1 As DevExpress.XtraEditors.SimpleButton

        Private gridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    End Class
End Namespace
