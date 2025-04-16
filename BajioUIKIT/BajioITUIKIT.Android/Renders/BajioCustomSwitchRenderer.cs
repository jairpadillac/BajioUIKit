using System;
using Android.Content;
using Android.Graphics;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BajioCustomSwitch), typeof(BajioCustomSwitchRenderer))]
namespace BajioITUIKIT.Droid.Renders
{
    public class BajioCustomSwitchRenderer: ViewRenderer   
    {
        public BajioCustomSwitchRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)   
        {   
            base.OnElementChanged(e);   
        }   

        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)   
        {   
            if (Element == null) return false;   
   
            BajioCustomSwitch rcv = (BajioCustomSwitch)Element;   
            this.SetClipChildren(true);   
   
            rcv.Padding = new Thickness(0, 0, 0, 0);   
           
            int radius = 3;
            // Check if make circle is set to true. If so, then we just use the width and   
            // height of the control to calculate the radius. RoundedCornerRadius will be ignored   
            // in this case.   
              
   
            // When we create a round rect, we will have to double the radius since it is not   
            // the same as creating a circle.   
            radius *= 3;   
   
            try   
            {   
                //Create path to clip the child    
                var path = new Path();  

                path.AddRoundRect(new RectF(0, 0, Width, Height),   
                              new float[] { radius, radius, radius, radius, radius, radius, radius, radius },   
                              Path.Direction.Ccw); 
   
                canvas.Save();   
                canvas.ClipPath(path);   
   
                // Draw the child first so that the border shows up above it.   
                var result = base.DrawChild(canvas, child, drawingTime);   
   
                canvas.Restore();   
   
                /*  
                 * If a border is specified, we use the same path created above to stroke  
                 * with the border color.  
                 * */   
                if (rcv.StrokeWidth > 0)   
                {   
                    // Draw a filled circle.   
                    var paint = new Paint();   

                    paint.AntiAlias = true;   
                    paint.StrokeWidth = rcv.StrokeWidth;   
                    paint.SetStyle(Paint.Style.Stroke);
                    paint.Color = rcv.BorderColor.ToAndroid();

                    canvas.DrawPath(path, paint);   
   
                    paint.Dispose();   
                }

                this.Background.SetTint(rcv.FillColor.ToAndroid());
   
                //Properly dispose   
                path.Dispose();   
                return result;   
            }   
            catch (Exception ex)   
            {   
                System.Console.Write(ex.Message);   
            }   
   
            return base.DrawChild(canvas, child, drawingTime);   
        }   
   

    }
}
