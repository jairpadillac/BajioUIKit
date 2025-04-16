using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioContainerControl : Grid
    {
        #region Public Properties
        /// <summary>
        /// The is border displayed property.
        /// </summary>
        public static readonly BindableProperty IsBorderDisplayedProperty =
            BindableProperty.Create(nameof(IsBorderDisplayed), typeof(bool), typeof(BajioContainerControl), true);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioContainerControl"/>
        /// is border displayed.
        /// </summary>
        /// <value><c>true</c> if is border displayed; otherwise, <c>false</c>.</value>
        public bool IsBorderDisplayed
        {
            get { return (bool)GetValue(IsBorderDisplayedProperty); }
            set { SetValue(IsBorderDisplayedProperty, value); }
        }

        /// <summary>
        /// The stroke border property.
        /// </summary>
        public static readonly BindableProperty StrokeBorderProperty =
            BindableProperty.Create(nameof(StrokeBorder), typeof(Color), typeof(BajioContainerControl), Theme.EntryStrokeBorder, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the stroke border.
        /// </summary>
        /// <value>The stroke border.</value>
        public Color StrokeBorder
        {
            get { return (Color)GetValue(StrokeBorderProperty); }
            set { SetValue(StrokeBorderProperty, value); }
        }

        /// <summary>
        /// The invalid color property.
        /// </summary>
        public static readonly BindableProperty InvalidColorProperty =
            BindableProperty.Create(nameof(InvalidColor), typeof(Color), typeof(BajioContainerControl), Theme.InvalidColorPrimary, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the color of the invalid.
        /// </summary>
        /// <value>The color of the invalid.</value>
        public Color InvalidColor
        {
            get { return (Color)GetValue(InvalidColorProperty); }
            set { SetValue(InvalidColorProperty, value); }
        }

        /// <summary>
        /// The enabled background property.
        /// </summary>
        public static readonly BindableProperty EnabledBackgroundProperty =
            BindableProperty.Create(nameof(EnabledBackground), typeof(Color), typeof(BajioContainerControl), Theme.EntryEnabledBackground, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the enabled background.
        /// </summary>
        /// <value>The enabled background.</value>
        public Color EnabledBackground
        {
            get { return (Color)GetValue(EnabledBackgroundProperty); }
            set { SetValue(EnabledBackgroundProperty, value); }
        }

        /// <summary>
        /// The disabled background property.
        /// </summary>
        public static readonly BindableProperty DisabledBackgroundProperty =
            BindableProperty.Create(nameof(DisabledBackground), typeof(Color), typeof(BajioContainerControl), Theme.EntryDisabledBackground, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the disabled background.
        /// </summary>
        /// <value>The disabled background.</value>
        public Color DisabledBackground
        {
            get { return (Color)GetValue(DisabledBackgroundProperty); }
            set { SetValue(DisabledBackgroundProperty, value); }
        }

        /// <summary>
        /// The enabled property.
        /// </summary>
        public static readonly BindableProperty EnabledProperty =
            BindableProperty.Create(nameof(Enabled), typeof(bool), typeof(BajioContainerControl), true, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioContainerControl"/>
        /// is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        /// <summary>
        /// The error property.
        /// </summary>
        public static readonly BindableProperty ErrorProperty =
            BindableProperty.Create(nameof(Error), typeof(bool), typeof(BajioContainerControl), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioContainerControl"/>
        /// is error.
        /// </summary>
        /// <value><c>true</c> if error; otherwise, <c>false</c>.</value>
        public bool Error
        {
            get { return (bool)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        /// <summary>
        /// The error message property.
        /// </summary>
        public static readonly BindableProperty ErrorMessageProperty =
            BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(BajioContainerControl), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        /// <summary>
        /// The custom icon name property.
        /// </summary>
        public static readonly BindableProperty CustomIconNameProperty =
            BindableProperty.Create(nameof(CustomIconName), typeof(string), typeof(BajioContainerControl), string.Empty);

        /// <summary>
        /// Gets or sets the name of the custom icon.
        /// </summary>
        /// <value>The name of the custom icon.</value>
        public string CustomIconName
        {
            get { return (string)GetValue(CustomIconNameProperty); }
            set { SetValue(CustomIconNameProperty, value); }
        }

        /// <summary>
        /// The corner radius property.
        /// </summary>
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(BajioContainerControl), 4f);

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        /// <summary>
        /// The border width property.
        /// </summary>
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(BajioContainerControl), 2f);

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }
        #endregion

        #region Private Properties
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        #endregion
    }
}


