// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace LocalBox_iOS
{
	[Register ("DelenView")]
	partial class DelenView
	{
		[Outlet]
		MonoTouch.UIKit.UITextField NaamTextField { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton OkButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SluitenButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView TableView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel TitelTekst { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TitelTekst != null) {
				TitelTekst.Dispose ();
				TitelTekst = null;
			}

			if (NaamTextField != null) {
				NaamTextField.Dispose ();
				NaamTextField = null;
			}

			if (OkButton != null) {
				OkButton.Dispose ();
				OkButton = null;
			}

			if (SluitenButton != null) {
				SluitenButton.Dispose ();
				SluitenButton = null;
			}

			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
