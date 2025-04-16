using System;
using System.Diagnostics;
using BajioITUIKIT.Controls;
using BajioITUIKIT.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedCornerView), typeof(RoundedCornerViewRenderer))]
namespace BajioITUIKIT.iOS.Renders
{
    [Preserve(AllMembers = true)]
    public class RoundedCornerViewRenderer : ViewRenderer
    {
        #region Protected Methods
        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (this.Element == null) return;

            this.Element.PropertyChanged += (sender, e1) =>
            {
                try
                {
                    if (NativeView != null)
                    {
                        NativeView.SetNeedsDisplay();
                        NativeView.SetNeedsLayout();
                    }
                }
                catch (Exception exp)
                {
                    Debug.WriteLine("Handled Exception in RoundedCornerViewDemoRenderer. Just warngin : " + exp.Message);
                }
            };
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Draw the specified rect.
        /// </summary>
        /// <param name="rect">Rect.</param>
        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);

            this.LayoutIfNeeded();

            RoundedCornerView rcv = (RoundedCornerView)Element;
            //rcv.HasShadow = false;    
            rcv.Padding = new Thickness(0, 0, 0, 0);

            //this.BackgroundColor = rcv.FillColor.ToUIColor();    
            this.ClipsToBounds = true;
            this.Layer.BackgroundColor = rcv.FillColor.ToCGColor();
            this.Layer.MasksToBounds = true;
            this.Layer.CornerRadius = (nfloat)rcv.RoundedCornerRadius;
            if (rcv.MakeCircle)
            {
                this.Layer.CornerRadius = (int)(Math.Min(Element.Width, Element.Height) / 2);
            }
            this.Layer.BorderWidth = 0;

            if (rcv.BorderWidth > 0 && rcv.BorderColor.A > 0.0)
            {
                this.Layer.BorderWidth = rcv.BorderWidth;
                this.Layer.BorderColor =
                    new UIColor(
                    (nfloat)rcv.BorderColor.R,
                    (nfloat)rcv.BorderColor.G,
                    (nfloat)rcv.BorderColor.B,
                        (nfloat)rcv.BorderColor.A).CGColor;
            }
        }
        #endregion
    }
}
