// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace LocalBox_iOS.Views.ItemView
{
	[Register ("BaseItemView")]
	partial class BaseItemView
	{
		[Outlet]
		MonoTouch.UIKit.UIView ContentViewContainer { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton FullScreenButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIView kleurenBalk { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton TerugButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel TitelLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ContentViewContainer != null) {
				ContentViewContainer.Dispose ();
				ContentViewContainer = null;
			}

			if (FullScreenButton != null) {
				FullScreenButton.Dispose ();
				FullScreenButton = null;
			}

			if (kleurenBalk != null) {
				kleurenBalk.Dispose ();
				kleurenBalk = null;
			}

			if (TerugButton != null) {
				TerugButton.Dispose ();
				TerugButton = null;
			}

			if (TitelLabel != null) {
				TitelLabel.Dispose ();
				TitelLabel = null;
			}
		}
	}
}
