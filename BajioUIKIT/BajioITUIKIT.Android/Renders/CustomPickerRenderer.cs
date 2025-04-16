using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Text;
using Android.Views;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using BajioITUIKIT.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace BajioITUIKIT.Droid.Renders
{
    public class CustomPickerRenderer : PickerRenderer
    {
        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CustomPickerRenderer"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public CustomPickerRenderer(Context context) : base(context)
        {
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var element = Element as CustomPicker;

                // Change place holder color
                Control.SetHintTextColor(Color.Gray.ToAndroid());
                Control.SetPadding(5, 0, 0, 5);
                Control.TextSize = element.FontSize;
                Control.Ellipsize = TextUtils.TruncateAt.End;
                Control.SetSingleLine(true);

                //remove underline on entry
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);

                ChangeTextColor(Element);


                Control.FocusChange += Control_FocusChange;
            }
        }

        /// <summary>
        /// Controls the focus change.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            var cfocused = Control.IsFocused;
            var focus = e.HasFocus;
        }


        /// <summary>
        /// Ons the element property changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "IsEnabled")
            {
                ChangeTextColor(Element);
            }
            if (Element is CustomPicker)
            {
                var picker = Element as CustomPicker;
                if (picker.IsEnabledPicker)
                {
                    Control.Enabled = true;
                }
                else
                {
                    Control.Enabled = false;
                }
            }
        }
        #endregion

        #region private Methods
        /// <summary>
        /// Changes the color of the text.
        /// </summary>
        private void ChangeTextColor(Picker e)
        {
            var entry = (Picker)e;
            if (entry.IsEnabled)
            {
                Control.SetTextColor(Theme.TextColorSecondary.ToAndroid());
            }
            else
            {
                Control.SetTextColor(Theme.TextInactiveColorSecondary.ToAndroid());
            }
        }

        /// <summary>
        /// Ons the focus changed.
        /// </summary>
        /// <param name="gainFocus">If set to <c>true</c> gain focus.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="previouslyFocusedRect">Previously focused rect.</param>
        protected override void OnFocusChanged(bool gainFocus, [GeneratedEnum] FocusSearchDirection direction, Rect previouslyFocusedRect)
        {
            base.OnFocusChanged(gainFocus, direction, previouslyFocusedRect);
        }

        /// <summary>
        /// Calls the on click.
        /// </summary>
        /// <returns><c>true</c>, if on click was called, <c>false</c> otherwise.</returns>
        public override bool CallOnClick()
        {
            return base.CallOnClick();
        }

        /// <summary>
        /// Dispatchs the window focus changed.
        /// </summary>
        /// <param name="hasFocus">If set to <c>true</c> has focus.</param>
        public override void DispatchWindowFocusChanged(bool hasFocus)
        {
            base.DispatchWindowFocusChanged(hasFocus);
        }
        #endregion

    }
}