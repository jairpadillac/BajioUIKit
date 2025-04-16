

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PinchToZoomContainer), typeof(PinchToZoomContainerRenderer))]
namespace BajioITUIKIT.Droid.Renders
{
    public class PinchToZoomContainerRenderer : ImageRenderer
    {
        /// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		public PinchToZoomContainerRenderer(Context context) : base(context)
        {
        }

        protected async override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new ImageView(Context));


                if (Element != null)
                    await TryUpdateBitmap();
            }
        }
        protected async override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == Image.SourceProperty.PropertyName)
                {
                    if (Element == null || Element.Source == null)
                        base.OnElementPropertyChanged(sender, e);
                    else
                        await TryUpdateBitmap();
                }
                else
                    base.OnElementPropertyChanged(sender, e);
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine(x.Message);
            }
        }
        async Task TryUpdateBitmap()
        {
            // By default we'll just catch and log any exceptions thrown by UpdateBitmap so they don't bring down
            // the application; a custom renderer can override this method and handle exceptions from
            // UpdateBitmap differently if it wants to

            try
            {
                ((IImageController)Element)?.SetIsLoading(true);
                var bmp = await AndroidImageHelper.GetBitmapFromImageSourceAsync(Element.Source, Context);
                Control.SetScaleType(ImageView.ScaleType.CenterCrop);
                Control.SetImageBitmap(bmp);
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine(x.Message);
            }
            finally
            {
                ((IImageController)Element)?.SetIsLoading(false);
            }
        }
    }

    class AndroidImageHelper
    {
        private static IImageSourceHandler GetHandler(ImageSource source)
        {
            IImageSourceHandler returnValue = null;
            if (source is UriImageSource)
            {
                returnValue = new ImageLoaderSourceHandler();
            }
            else if (source is FileImageSource)
            {
                returnValue = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                returnValue = new StreamImagesourceHandler();
            }
            return returnValue;
        }
        public static async Task<Bitmap> GetBitmapFromImageSourceAsync(ImageSource source, Context context)
        {
            var handler = GetHandler(source);
            var returnValue = (Bitmap)null;

            returnValue = await handler.LoadImageAsync(source, context);

            return returnValue;
        }
    }
}
