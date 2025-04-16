using System;
using BajioITUIKIT.iOS.Renders;
using Foundation;
using PrestamosPerugia.Mobile.iOS.Renders;
using PrestamosPerugia.Mobile.Views.SharedViews;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewFotoPage), typeof(ViewFotoPageRender))]
namespace BajioITUIKIT.iOS.Renders
{
    public class ViewFotoPageRender : PageRenderer
    {

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Portrait)), new NSString("orientation"));
        }
    }

}
