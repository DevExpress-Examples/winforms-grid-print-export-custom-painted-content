// Developer Express Code Central Example:
// How to customize the GridControl's print output.
// 
// This example demonstrates how to override the default exporting process to take
// into account a custom drawn content provided via the
// GridView.CustomDrawFooterCell Event
// (ms-help://DevExpress.NETv10.1/DevExpress.WindowsForms/DevExpressXtraGridViewsGridGridView_CustomDrawFooterCelltopic.htm)
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2667

using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.Handler;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Registrator;

namespace MyXtraGrid {
	public class MyGridViewInfoRegistrator : GridInfoRegistrator {
		public override string ViewName { get { return "MyGridView"; } }
		public override BaseView CreateView(GridControl grid) { return new MyGridView(grid as GridControl); }
		public override BaseViewInfo CreateViewInfo(BaseView view) { return new MyGridViewInfo(view as MyGridView); } 
		public override BaseViewHandler CreateHandler(BaseView view) { return new MyGridHandler(view as MyGridView); }
	}
}
