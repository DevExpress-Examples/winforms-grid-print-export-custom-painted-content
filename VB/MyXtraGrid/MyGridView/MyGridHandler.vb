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
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Namespace MyXtraGrid
    Public Class MyGridHandler
        Inherits DevExpress.XtraGrid.Views.Grid.Handler.GridHandler

        Public Sub New(ByVal gridView As GridView)
            MyBase.New(gridView)
        End Sub


    End Class
End Namespace
