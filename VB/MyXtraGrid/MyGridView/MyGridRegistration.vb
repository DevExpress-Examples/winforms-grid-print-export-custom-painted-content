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
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.Handler
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Registrator

Namespace MyXtraGrid
    Public Class MyGridViewInfoRegistrator
        Inherits GridInfoRegistrator

        Public Overrides ReadOnly Property ViewName() As String
            Get
                Return "MyGridView"
            End Get
        End Property
        Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
            Return New MyGridView(TryCast(grid, GridControl))
        End Function
        Public Overrides Function CreateViewInfo(ByVal view As BaseView) As BaseViewInfo
            Return New MyGridViewInfo(TryCast(view, MyGridView))
        End Function
        Public Overrides Function CreateHandler(ByVal view As BaseView) As BaseViewHandler
            Return New MyGridHandler(TryCast(view, MyGridView))
        End Function
    End Class
End Namespace
