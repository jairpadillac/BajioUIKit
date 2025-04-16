using Android.Content;
using Android.Graphics.Drawables;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BajioContainerControl), typeof(BajioEntryRender))]
namespace BajioITUIKIT.Droid.Renders
{
    public class BajioEntryRender : VisualElementRenderer<Grid>
    {
        #region Private Properties
        private float CornerRadius = 6;
        private float BorderWidth = 2;
        #endregion

        #region protected Methods
        public BajioEntryRender(Context context) : base(context)
        {
        }
        #endregion

        #region Private Methods

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "CornerRadius")
            {
                CornerRadius = (Element as BajioContainerControl).CornerRadius;
            }
            if(e.PropertyName == "BorderWidth")
            {
                BorderWidth = (Element as BajioContainerControl).BorderWidth;
            }
            SetBackground(Element);
        }

        /// <summary>
        /// Sets the background.
        /// </summary>
        /// <param name="element">The element.</param>
        private void SetBackground(Grid element)
        {
            if (element == null)
                return;
            
            var BajioContainerControl = (BajioContainerControl)element;

            GradientDrawable gd = new GradientDrawable();

            if (BajioContainerControl.IsBorderDisplayed)
            {
                gd.SetCornerRadius(CornerRadius);
                gd.SetStroke((int)BorderWidth, BajioContainerControl.StrokeBorder.ToAndroid());

                if (BajioContainerControl.Error)
                {
                    gd.SetStroke((int)BorderWidth, BajioContainerControl.InvalidColor.ToAndroid());
                }
            }

            if (BajioContainerControl.Enabled)
            {
                gd.SetColor(BajioContainerControl.BackgroundColor.ToAndroid());
            }
            else
            {
                gd.SetColor(BajioContainerControl.DisabledBackground.ToAndroid());
            }

            Background = gd;
        }
        #endregion
    }
}

