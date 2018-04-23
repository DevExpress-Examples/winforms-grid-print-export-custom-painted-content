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

Imports System
Imports DevExpress.XtraGrid.Views.Base
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Drawing

Namespace MyXtraGrid
    <System.ComponentModel.DesignerCategory("")> _
    Public Class MyGridView
        Inherits GridView

        Public Sub New()
            Me.New(Nothing)
        End Sub
        Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
            MyBase.New(grid)
            ' put your initialization code here
        End Sub
        Protected Overrides ReadOnly Property ViewName() As String
            Get
                Return "MyGridView"
            End Get
        End Property

        Protected Overrides Function CreatePrintInfoInstance(ByVal args As DevExpress.XtraGrid.Views.Printing.PrintInfoArgs) As DevExpress.XtraGrid.Views.Printing.BaseViewPrintInfo

            Return New MyGridViewPrintInfo(args)
        End Function

        Public Function GetCustomDrawCellArgs(ByVal cache As GraphicsCache, ByVal rect As Rectangle, ByVal col As GridColumn) As FooterCellCustomDrawEventArgs
            Dim styleArgs As New GridFooterCellInfoArgs(cache)
            styleArgs.Bounds = New Rectangle(New Point(0, 0), rect.Size)
            Dim args As New FooterCellCustomDrawEventArgs(cache, -1, col, Nothing, styleArgs)
            args.Handled = True
            RaiseCustomDrawFooterCell(args)
            Return args
        End Function
        Public Function GetCustomDrawRowIndicatorArgs(ByVal cache As GraphicsCache, ByVal rect As Rectangle) As RowIndicatorCustomDrawEventArgs
            Dim styleArgs As New IndicatorObjectInfoArgs(cache)
            styleArgs.Bounds = New Rectangle(New Point(0, 0), rect.Size)
            Dim args As New RowIndicatorCustomDrawEventArgs(cache, -1, Nothing, styleArgs)
            args.Handled = True
            RaiseCustomDrawRowIndicator(args)
            Return args
        End Function
    End Class
End Namespace