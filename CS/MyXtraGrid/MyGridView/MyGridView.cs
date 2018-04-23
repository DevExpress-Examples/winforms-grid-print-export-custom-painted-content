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
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Drawing;

namespace MyXtraGrid {
    [System.ComponentModel.DesignerCategory("")]
	public class MyGridView : GridView {
		public MyGridView() : this(null) {}
		public MyGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) {
			// put your initialization code here
		}
		protected override string ViewName { get { return "MyGridView"; } }

        protected override DevExpress.XtraGrid.Views.Printing.BaseViewPrintInfo CreatePrintInfoInstance(DevExpress.XtraGrid.Views.Printing.PrintInfoArgs args)
        {

            return new MyGridViewPrintInfo(args);
        }

        public FooterCellCustomDrawEventArgs GetCustomDrawCellArgs(GraphicsCache cache, Rectangle rect, GridColumn col)
        {
            GridFooterCellInfoArgs styleArgs = new GridFooterCellInfoArgs(cache);
            styleArgs.Bounds = new Rectangle(new Point(0, 0), rect.Size);
            FooterCellCustomDrawEventArgs args = new FooterCellCustomDrawEventArgs(cache, -1, col, null, styleArgs);
            args.Handled = true;
            RaiseCustomDrawFooterCell(args);
            return args;
        }
        public RowIndicatorCustomDrawEventArgs GetCustomDrawRowIndicatorArgs(GraphicsCache cache, Rectangle rect)
        {
            IndicatorObjectInfoArgs styleArgs = new IndicatorObjectInfoArgs(cache);
            styleArgs.Bounds = new Rectangle(new Point(0, 0), rect.Size);
            RowIndicatorCustomDrawEventArgs args = new RowIndicatorCustomDrawEventArgs(cache, -1, null, styleArgs);
            args.Handled = true;
            RaiseCustomDrawRowIndicator(args);
            return args;
        }
	}
}