using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class CustomPicker : Picker
    {
        #region public properties
        /// <summary>
        /// The font size property
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize),
         typeof(int), typeof(CustomPicker), 10, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets the font size of the label of the picker.
        /// </summary>
        /// <value>
        /// The font size of the pick.
        /// </value>
        public int FontSize
        {
            get
            {
                return (int)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        /// <summary>
        /// The picker focus property.
        /// </summary>
        public static readonly BindableProperty PickerFocusProperty =
            BindableProperty.Create(nameof(PickerFocus), typeof(bool), typeof(CustomPicker), false, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets a value indicating whether this
        /// picker focus.
        /// </summary>
        /// <value><c>true</c> if picker focus; otherwise, <c>false</c>.</value>
        public bool PickerFocus
        {
            get
            {
                return (bool)GetValue(PickerFocusProperty);
            }
            set
            {
                SetValue(PickerFocusProperty, value);
            }
        }

        /// <summary>
        /// The is enabled picker property.
        /// </summary>
        public static readonly BindableProperty IsEnabledPickerProperty = BindableProperty.Create(nameof(IsEnabledPicker),
        typeof(bool), typeof(CustomPicker), true, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets a value indicating whether this is
        /// enabled picker.
        /// </summary>
        /// <value><c>true</c> if is enabled picker; otherwise, <c>false</c>.</value>
        public bool IsEnabledPicker
        {
            get
            {
                return (bool)GetValue(IsEnabledPickerProperty);
            }
            set
            {
                SetValue(IsEnabledPickerProperty, value);
            }
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == PickerFocusProperty.PropertyName)
            {
                if (PickerFocus)
                {
                    Focus();
                }
            }
        }
        #endregion

    }
}
