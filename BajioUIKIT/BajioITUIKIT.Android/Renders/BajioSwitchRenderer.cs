using System;
using Android.Content;
using Android.Graphics;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BajioSwitch), typeof(BajioSwitchRenderer))]
namespace BajioITUIKIT.Droid.Renders
{
    public class BajioSwitchRenderer : ViewRenderer<BajioSwitch, Android.Widget.Switch>
    {
        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BajioUIKit.Mobile.Droid.Renderers.BajioSwitchRenderer"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public BajioSwitchRenderer(Context context) : base(context)
        {
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{BajioSwitch}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<BajioSwitch> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.Toggled -= ElementToggled;
            }

            if (e.NewElement != null)
            {
                SetNativeControl(new Android.Widget.Switch(Context));
                Control.Checked = e.NewElement.IsToggled;
                Control.CheckedChange += ControlValueChanged;
                SetTintColor(Element.TintColor.ToAndroid());
                Element.Toggled += ElementToggled;
            }
        }

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == BajioSwitch.IsToggledProperty.PropertyName)
            {
                SetTintColor(Element.TintColor.ToAndroid());
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.CheckedChange -= ControlValueChanged;
                Element.Toggled -= ElementToggled;
            }

            base.Dispose(disposing);
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Sets the color of the tint.
        /// </summary>
        /// <param name="color">The color.</param>
        private void SetTintColor(Android.Graphics.Color color)
        {
            if (Control.Checked)
            {
                Control.ThumbDrawable.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
                Control.TrackDrawable.SetColorFilter(color, PorterDuff.Mode.SrcAtop);
            }
            else
            {
                Control.ThumbDrawable.SetColorFilter(Element.InactiveColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                Control.TrackDrawable.SetColorFilter(Element.InactiveColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                //Control.ThumbDrawable.SetColorFilter(Theme.InactiveColorPrimary.ToAndroid(), PorterDuff.Mode.SrcAtop);
                //Control.TrackDrawable.SetColorFilter(Theme.InactiveColorPrimary.ToAndroid(), PorterDuff.Mode.SrcAtop);
            }
        }

        /// <summary>
        /// Elements the toggled.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ToggledEventArgs"/> instance containing the event data.</param>
        private void ElementToggled(object sender, ToggledEventArgs e)
        {
            Control.Checked = Element.IsToggled;
            SetTintColor(Element.TintColor.ToAndroid());
        }

        /// <summary>
        /// Controls the value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ControlValueChanged(object sender, EventArgs e)
        {
            Element.IsToggled = Control.Checked;
            SetTintColor(Element.TintColor.ToAndroid());
        }
        #endregion
    }
}
