
using BajioITUIKIT.Controls;
using BajioITUIKIT.iOS.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BoxViewRounded), typeof(BoxViewRoundedRenderer))]
namespace BajioITUIKIT.iOS.Renders
{
    public class BoxViewRoundedRenderer : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if (Element == null) return;
            Layer.MasksToBounds = true;
            Layer.CornerRadius = (float)((BoxViewRounded)this.Element).CornerRadius / 2.0f;
        }
    }
}
