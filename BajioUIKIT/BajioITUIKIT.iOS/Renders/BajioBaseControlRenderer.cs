using BajioITUIKIT.Controls;
using BajioITUIKIT.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BajioBaseControl), typeof(BajioBaseControlRenderer))]
namespace BajioITUIKIT.iOS.Renders
{
    public class BajioBaseControlRenderer : ViewRenderer<BajioBaseControl, UIView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BajioBaseControl> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement != null)
            {
                var bofiControl = e.NewElement as BajioBaseControl;
                bofiControl.OnAppearing(bofiControl.Args);
            }
        }
    }
}
