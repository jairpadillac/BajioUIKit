using Android.Content;
using Android.Widget;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BajioBaseControl), typeof(BajioBaseControlRenderer))]
namespace BajioITUIKIT.Droid.Renders
{
    public class BajioBaseControlRenderer : ViewRenderer<BajioBaseControl, GridView>
    {
        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BajioUIKit.Mobile.Droid.Renderers.BajioBaseControlRenderer"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public BajioBaseControlRenderer(Context context) : base(context)
        {
        }
        #endregion


        #region Protected Methods
        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<BajioBaseControl> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var BajioControl = e.NewElement as BajioBaseControl;
                BajioControl.OnAppearing(BajioControl.Args);
            }
        }
        #endregion
    }
}
