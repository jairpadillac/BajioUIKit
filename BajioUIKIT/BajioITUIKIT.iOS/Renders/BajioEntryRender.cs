using System.ComponentModel;
using BajioITUIKIT.Controls;
using BajioITUIKIT.iOS.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BajioContainerControl), typeof(BajioEntryRender))]
namespace BajioITUIKIT.iOS.Renders
{
    public class BajioEntryRender : VisualElementRenderer<Grid>
    {
        #region Public Properties
        #endregion

        #region Private Properties
        private float CornerRadius = 2;
        private float BorderWidth = 1f;
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        protected override void OnElementChanged(ElementChangedEventArgs<Grid> e)
        {
            base.OnElementChanged(e);

            if (NativeView != null)
            {
                SetBackground(Element);
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Element == null) return;

            if (e.PropertyName == "Enabled")
            {
                SetBackground(Element);
            }
            if (e.PropertyName == "Error")
            {
                SetBackground(Element);
            }
            if(e.PropertyName == "IsBorderDisplayed")
            {
                SetBackground(Element);
            }
            if (e.PropertyName == "CornerRadius")
            {
                CornerRadius = (Element as BajioContainerControl).CornerRadius;
                SetBackground(Element);
            }
            if (e.PropertyName == "BorderWidth")
            {
                BorderWidth = (Element as BajioContainerControl).BorderWidth;
                SetBackground(Element);
            }
        }
        private void SetBackground(Grid element)
        {
            var entry = (BajioContainerControl)element;
            if (entry == null) return;

            if (entry.Enabled)
            {
                NativeView.Layer.BackgroundColor = entry.BackgroundColor.ToCGColor();
            }
            else
            {
                NativeView.Layer.BackgroundColor = entry.DisabledBackground.ToCGColor();
            }

            if (entry.IsBorderDisplayed)
            {
                NativeView.Layer.BorderColor = entry.StrokeBorder.ToCGColor();
                NativeView.Layer.BorderWidth = BorderWidth;
                NativeView.Layer.CornerRadius = CornerRadius;
            }

            if (entry.Error)
            {
                NativeView.Layer.BorderColor = entry.InvalidColor.ToCGColor();
            }

        }
        #endregion
    }
}
