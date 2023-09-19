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
Imports DevExpress.XtraGrid.Views.Printing
Imports DevExpress.XtraPrinting
Imports System.Drawing
Imports DevExpress.Data
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.Runtime.InteropServices

Namespace MyXtraGrid

    Public Class MyGridViewPrintInfo
        Inherits GridViewPrintInfo

        Public ReadOnly Property FooterPanelHeight As Integer
            Get
                Return CalcStyleHeight(AppearancePrint.FooterPanel) + 4
            End Get
        End Property

        Public Sub New(ByVal args As PrintInfoArgs)
            MyBase.New(args)
        End Sub

        Protected Overrides Sub CreatePrintColumnCollection()
            Dim width As Integer = 0
            fMaxRowWidth = 0
            For Each col As GridColumn In View.VisibleColumns
                width = View.IndicatorWidth \ View.VisibleColumns.Count
                Dim colInfo As PrintColumnInfo = New PrintColumnInfo()
                colInfo.Bounds = New Rectangle(fMaxRowWidth + View.IndicatorWidth, 0, col.VisibleWidth - width, headerRowHeight)
                colInfo.Column = col
                Columns.Add(colInfo)
                fMaxRowWidth += colInfo.Bounds.Width
            Next

            fMaxRowWidth += View.IndicatorWidth
        End Sub

        Protected Overrides Sub PrintRow(ByVal g As Graphics, ByVal graph As IBrickGraphics, ByVal rowHandle As Integer, ByVal level As Integer)
            MyBase.PrintRow(g, graph, rowHandle, level)
            PrintRowIndicator(g, graph, rowHandle)
        End Sub

        Private Sub PrintRowIndicator(ByVal g As Graphics, ByVal graph As IBrickGraphics, ByVal rowHandle As Integer)
            Dim displayText As String
            Dim ib As ImageBrick
            Dim rect As Rectangle = New Rectangle(New Point(Indent, Y - 21), New Size(View.IndicatorWidth, CurrentRowHeight))
            Dim bmp As Bitmap = New Bitmap(rect.Width, rect.Height)
            Dim cache As GraphicsCache = New GraphicsCache(Graphics.FromImage(bmp))
            Dim args As RowIndicatorCustomDrawEventArgs = TryCast(View, MyGridView).GetCustomDrawRowIndicatorArgs(cache, rect)
            displayText = args.Info.DisplayText
            Dim border As BorderSide = If(args.Appearance.Options.UseBorderColor, BorderSide.All, BorderSide.None)
            ib = New ImageBrick(border, 1, args.Appearance.BorderColor, args.Appearance.BackColor)
            ib.Rect = rect
            ib.Image = bmp
            If ib Is Nothing Then
            End If

            graph.DrawBrick(ib, rect)
        End Sub

        Public Overrides Sub PrintFooterPanel(ByVal graph As IBrickGraphics)
            MyBase.PrintFooterPanel(graph)
            CustomDrawFooterCells(graph)
        End Sub

        ' override Print
        Private Sub CustomDrawFooterCells(ByVal graph As IBrickGraphics)
            If Not View.OptionsPrint.PrintFooter Then Return
            For Each colInfo As PrintColumnInfo In Columns
                If colInfo.Column.SummaryItem.SummaryType = SummaryItemType.None Then Continue For
                Dim r As Rectangle = Rectangle.Empty
                r.X = colInfo.Bounds.X + Indent
                r.Y = colInfo.RowIndex * FooterPanelHeight + 2 + Y
                r.Width = colInfo.Bounds.Width
                r.Height = FooterPanelHeight * colInfo.RowCount
                r.X -= Indent
                r.Y -= r.Height
                Dim text As String = String.Empty
                Dim ib As ImageBrick = GetImageBrick(colInfo, r, text)
                If ib IsNot Nothing Then graph.DrawBrick(ib, ib.Rect)
            Next
        End Sub

        Private Function GetImageBrick(ByVal colInfo As PrintColumnInfo, ByVal rect As Rectangle, <Out> ByRef displayText As String) As ImageBrick
            Dim bmp As Bitmap = New Bitmap(rect.Width, rect.Height)
            Dim cache As GraphicsCache = New GraphicsCache(Graphics.FromImage(bmp))
            Dim args As FooterCellCustomDrawEventArgs = TryCast(View, MyGridView).GetCustomDrawCellArgs(cache, rect, colInfo.Column)
            displayText = args.Info.DisplayText
            If Not args.Handled Then Return Nothing
            Dim border As BorderSide = If(args.Appearance.Options.UseBorderColor, BorderSide.All, BorderSide.None)
            Dim ib As ImageBrick = New ImageBrick(border, 1, args.Appearance.BorderColor, args.Appearance.BackColor)
            ib.Rect = rect
            ib.Image = bmp
            Return ib
        End Function
    End Class
End Namespace
