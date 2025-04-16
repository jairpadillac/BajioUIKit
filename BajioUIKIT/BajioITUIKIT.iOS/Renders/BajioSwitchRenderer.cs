using System;
using BajioITUIKIT.Controls;
using BajioITUIKIT.iOS.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BajioSwitch), typeof(BajioSwitchRenderer))]
namespace BajioITUIKIT.iOS.Renders
{
    public class BajioSwitchRenderer : ViewRenderer<BajioSwitch, UISwitch>
    {
        #region Public Methods

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="Xamarin.Forms.Platform.iOS.ElementChangedEventArgs{BajioSwitch}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<BajioSwitch> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.Toggled -= ElementToggled;
            }

            if (e.NewElement != null)
            {
                SetNativeControl(new UISwitch());
                Control.On = e.NewElement.IsToggled;
                Control.ValueChanged += ControlValueChanged;
                SetTintColor(Element.TintColor.ToUIColor());
                Element.Toggled += ElementToggled;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the <see cref="E:ElementPropertyChanged" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == BajioSwitch.TintColorProperty.PropertyName)
            {
                SetTintColor(Element.TintColor.ToUIColor());
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
                Control.ValueChanged -= ControlValueChanged;
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
        private void SetTintColor(UIColor color)
        {
            if (Control == null || Element == null)
            {
                return;
            }
            if(Element.IsToggled)
            {
                Control.TintColor = color;
                Control.OnTintColor = color;   
            }
            else
            {
                Control.TintColor = Element.InactiveColor.ToUIColor();
                Control.OnTintColor = Element.InactiveColor.ToUIColor();
            }
        }

        /// <summary>
        /// Elements the toggled.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ToggledEventArgs"/> instance containing the event data.</param>
        private void ElementToggled(object sender, ToggledEventArgs e)
        {
            Control.SetState(Element.IsToggled, true);
        }

        /// <summary>
        /// Controls the value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ControlValueChanged(object sender, EventArgs e)
        {
            Element.IsToggled = Control.On;
            SetTintColor(Element.TintColor.ToUIColor());
        }

        #endregion
    }
}
