using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch;
using System.Drawing;
using MonoTouch.CoreGraphics;


namespace ClanceysLib
{

	[Register("RotatingViewController")]
	public partial class RotatingViewController : UIViewController
	{
		public NSObject notificationObserver;

		public RotatingViewController (IntPtr handle) : base(handle)
		{
			initialize ();
		}

		[Export("initWithCoder:")]
		public RotatingViewController (NSCoder coder) : base(coder)
		{
			initialize ();
		}

		public RotatingViewController (string nibName, NSBundle bundle) : base(nibName, bundle)
		{
			initialize ();
		}

		public RotatingViewController () : base()
		{
			initialize ();
		}
		private void initialize ()
		{
		}
		public UIView PortraitView { get; set; }
		public UIView LandscapeLeftView { get; set; }
		public UIView LandscapeRightView { get; set; }
		public bool viewControllerVisible { get; set; }

		public override void ViewDidLoad ()
		{
			//  SetView();
		}

		public override void ViewWillAppear (bool animated)
		{
			viewControllerVisible = true;
			SetView ();
		}

		private void _showView (UIView view)
		{
			_removeAllViews ();
			//view.Frame = View.Frame;
			View.AddSubview (view);
			//View = view;
		}

		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			if (toInterfaceOrientation == UIInterfaceOrientation.LandscapeLeft)
				return true; else if (toInterfaceOrientation == UIInterfaceOrientation.LandscapeRight)
				return true; else if (toInterfaceOrientation == UIInterfaceOrientation.Portrait)
				return true;
			return false;
		}

		public virtual void SetupNavBar ()
		{
			
		}

		private void SetView ()
		{
			//Console.WriteLine(InterfaceOrientation);
			var rect = this.View.Bounds;
			rect.Location = PointF.Empty;
			switch (UIApplication.SharedApplication.StatusBarOrientation) {
			case UIInterfaceOrientation.Portrait:
				PortraitView.Frame = rect;
				_showView (PortraitView);
				break;
			
			case UIInterfaceOrientation.LandscapeLeft:
				//rect = CGAffineTransform.CGRectApplyAffineTransform (rect, CGAffineTransform.MakeRotation ((float)(90f * Math.PI / 180f)));
				//rect.Location = PointF.Empty;
				LandscapeLeftView.Frame = rect;
				_showView (LandscapeLeftView);
				break;
			case UIInterfaceOrientation.LandscapeRight:
				//rect = CGAffineTransform.CGRectApplyAffineTransform (rect, CGAffineTransform.MakeRotation ((float)(90f * Math.PI / 180f)));
				//rect.Location = PointF.Empty;
				LandscapeRightView.Frame = rect;
				_showView (LandscapeRightView);
				break;
			}
			SetupNavBar ();
		}



		public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
		{
			SetView ();
		}



		private void _removeAllViews ()
		{
			PortraitView.RemoveFromSuperview ();
			LandscapeLeftView.RemoveFromSuperview ();
			LandscapeRightView.RemoveFromSuperview ();
		}

		public override void ViewDidDisappear (bool animated)
		{
			viewControllerVisible = false;
			base.ViewWillDisappear (animated);
		}
	}
}

