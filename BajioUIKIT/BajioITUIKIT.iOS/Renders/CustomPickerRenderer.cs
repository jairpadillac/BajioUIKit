using System.ComponentModel;
using System.Linq;
using BajioITUIKIT.Controls;
using BajioITUIKIT.iOS.Renders;
using BajioITUIKIT.Styles;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace BajioITUIKIT.iOS.Renders
{
    public class CustomPickerRenderer : PickerRenderer
    {

        #region Private Methods

        /// <summary>
        /// Attach events and properties
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Change place holder color
                if (Control.AttributedPlaceholder != null)
                {
                    Control.AttributedPlaceholder = new Foundation.NSAttributedString(Control.AttributedPlaceholder.Value, foregroundColor: UIColor.Gray);
                }

                // Remove border
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;


                // Padding
                Control.LeftView = new UIView(new CGRect(0, 0, 5, 0));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIView(new CGRect(0, 0, 5, 0));
                Control.RightViewMode = UITextFieldViewMode.Always;

                Control.Font = UIFont.SystemFontOfSize(12);


                if (Element != null && Element is CustomPicker)
                {
                    var picker = Element as CustomPicker;
                    Control.Font = UIFont.SystemFontOfSize(picker.FontSize);
                }

                WordWrap();

                ChangeTextColor(Element);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Element == null) return;
            if (Control == null) return;

            if (e.PropertyName == "IsEnabled")
            {
                ChangeTextColor(Element);
            }
            if (Element is CustomPicker)
            {
                var picker = Element as CustomPicker;
                if (picker.IsEnabledPicker)
                {
                    Control.UserInteractionEnabled = true;
                }
                else
                {
                    Control.UserInteractionEnabled = false;
                }
            }

            if (e.PropertyName == CustomPicker.FontSizeProperty.PropertyName)
            {
                if (Element is CustomPicker)
                {
                    var picker = Element as CustomPicker;
                    Control.Font = UIFont.SystemFontOfSize(picker.FontSize);
                }
            }
        }

        private void WordWrap()
        {
            //TODO: set word wrap
            var lbl = (UILabel)Control.InputView.Subviews.FirstOrDefault(q => q.GetType() == typeof(UILabel));
            if (lbl != null) lbl.LineBreakMode = UILineBreakMode.MiddleTruncation;
        }

        /// <summary>
        /// Changes the color of the text.
        /// </summary>
        private void ChangeTextColor(Picker e)
        {
            var entry = (Picker)e;
            if (entry == null) return;
            if (entry.IsEnabled)
            {
                Control.TextColor = Theme.TextColorSecondary.ToUIColor();
            }
            else
            {
                Control.TextColor = Theme.TextInactiveColorSecondary.ToUIColor();
            }
        }

        #endregion
    }
}