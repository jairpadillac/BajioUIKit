using System;
using System.Diagnostics;
using BajioITUIKIT.Controls;
using BajioITUIKIT.iOS.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BajioCustomSwitch), typeof(BajioCustomSwitchRenderer))]
namespace BajioITUIKIT.iOS.Renders
{
    public class BajioCustomSwitchRenderer: ViewRenderer   
    {
        public BajioCustomSwitchRenderer()
        {
        }

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

        public override void Draw(CoreGraphics.CGRect rect)   
        {   
            base.Draw(rect);   
   
            this.LayoutIfNeeded();   
   
            BajioCustomSwitch rcv = (BajioCustomSwitch)Element;   
            //rcv.HasShadow = false;   
            rcv.Padding = new Thickness(0, 0, 0, 0);   
   
            this.BackgroundColor = rcv.FillColor.ToUIColor();   
            this.ClipsToBounds = true;   
            this.Layer.BackgroundColor = rcv.FillColor.ToCGColor();   
            this.Layer.MasksToBounds = true;
            // this.Layer.CornerRadius = (nfloat)1.5;   

            this.Layer.CornerRadius = 4;//(int)(Math.Min(Element.Width, Element.Height) / 2);   
              
            this.Layer.BorderWidth = 0;   
   
            if (rcv.StrokeWidth > 0 && rcv.BorderColor.A > 0.0)   
            {   
                this.Layer.BorderWidth = ((System.nfloat)(rcv.StrokeWidth / 2.0));   
                this.Layer.BorderColor =   
                    new UIKit.UIColor(   
                    (nfloat)rcv.BorderColor.R,   
                    (nfloat)rcv.BorderColor.G,   
                    (nfloat)rcv.BorderColor.B,   
                        (nfloat)rcv.BorderColor.A).CGColor;   
            }   
        }   
    }
}
