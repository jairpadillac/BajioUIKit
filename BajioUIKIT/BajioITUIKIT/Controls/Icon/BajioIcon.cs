using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.Iconize;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioIcon : StackLayout
    {
        #region Private Properties
        IconImage _iconImage = new IconImage();
        #endregion

        #region Public Properties
        /// <summary>
        /// IsSelected property to bind in the element
        /// </summary>
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(BajioIcon), null, BindingMode.TwoWay);

        /// <summary>
        /// IsSelected property to bind in the element
        /// </summary>
        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(BajioIcon), false, BindingMode.TwoWay);

        /// <summary>
        /// IsSelectable property to bind in the element
        /// </summary>
        public static readonly BindableProperty IsSelectableProperty =
            BindableProperty.Create(nameof(IsSelectable), typeof(bool), typeof(BajioIcon), false, BindingMode.TwoWay);

        /// <summary>
        /// IsSelectable property to bind in the element
        /// </summary>
        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(BajioIcon), true, BindingMode.TwoWay);

        /// <summary>
        /// ClickedIcon property to bind in the element
        /// </summary>
        public static readonly BindableProperty ClickedIconProperty =
            BindableProperty.Create(nameof(ClickedIcon), typeof(ICommand), typeof(BajioIcon), null, BindingMode.TwoWay);

        /// <summary>
        /// ClickedIconParameter property to bind in the element
        /// </summary>
        public static readonly BindableProperty ClickedIconParameterProperty =
            BindableProperty.Create(nameof(ClickedIconParameter), typeof(object), typeof(BajioIcon), null, BindingMode.TwoWay);

        /// <summary>
        /// The color property.
        /// </summary>
        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(BajioIcon), Theme.PrimaryColor, BindingMode.TwoWay);

        /// <summary>
        /// The size property.
        /// </summary>
        public static readonly BindableProperty SizeProperty =
            BindableProperty.Create(nameof(Size), typeof(int), typeof(BajioIcon), 45, BindingMode.TwoWay);

        /// <summary>
        /// Enabled property to bind in the element
        /// </summary>
        public static readonly BindableProperty EnabledProperty =
            BindableProperty.Create(nameof(Enabled), typeof(bool), typeof(BajioIcon), true, BindingMode.TwoWay);

        /// <summary>
        /// Icon property
        /// </summary>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// IsSelected property
        /// </summary>
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        /// <summary>
        /// IsSelectable property
        /// </summary>
        public bool IsSelectable
        {
            get { return (bool)GetValue(IsSelectableProperty); }
            set { SetValue(IsSelectableProperty, value); }
        }

        /// <summary>
        /// IsValid property
        /// </summary>
        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        /// <summary>
        /// ClickedIcon property
        /// </summary>
        public ICommand ClickedIcon
        {
            get { return (ICommand)GetValue(ClickedIconProperty); }
            set { SetValue(ClickedIconProperty, value); }
        }

        /// <summary>
        /// ClickedIconParameter property
        /// </summary>
        public object ClickedIconParameter
        {
            get { return (object)GetValue(ClickedIconParameterProperty); }
            set { SetValue(ClickedIconParameterProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public int Size
        {
            get { return (int)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        /// <summary>
        /// Enabled property
        /// </summary>
        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BajioITUIKIT.Controls.BajioIcon"/> class.
        /// </summary>
        public BajioIcon()
        {
            // Attach gestures flip command
            GestureRecognizers.Add(
                new TapGestureRecognizer
                {
                    Command = new Command(OnTapped)
                });
            _iconImage.Icon = Icon;
            _iconImage.IconSize = Size;//45;
            _iconImage.IconColor = Theme.PrimaryColor;
            Color = Theme.PrimaryColor;
            Children.Add(_iconImage);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// When the <c>BajioIcon</c> gets tapped
        /// </summary>
        private void OnTapped()
        {
            if (!Enabled)
                return;

            if (IsValid)
            {
                IsSelected = !IsSelected;
            }

            ClickedIcon?.Execute(ClickedIconParameter);
        }

        /// <summary>
        /// Set the <c>BajioIcon</c> color
        /// </summary>
        private void SetIconColor()
        {
            if (IsValid)
            {
                if (IsSelectable)
                {
                    _iconImage.IconColor = IsSelected ? Color : Theme.InactiveColorPrimary;
                }
                else
                {
                    _iconImage.IconColor = Color;
                }
            }
            else
            {
                _iconImage.IconColor = Theme.InvalidColorPrimary;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Property changes event handler for binding properties
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsSelectedProperty.PropertyName && IsSelectable)
            {
                SetIconColor();
            }

            if (propertyName == IsSelectableProperty.PropertyName)
            {
                SetIconColor();
            }

            if (propertyName == IsValidProperty.PropertyName)
            {
                SetIconColor();
            }

            if (propertyName == ColorProperty.PropertyName)
            {
                SetIconColor();
            }

            if (propertyName == SizeProperty.PropertyName)
            {
                _iconImage.IconSize = Size;
            }

            if (propertyName == IconProperty.PropertyName)
            {
                if (!string.IsNullOrEmpty(Icon))
                {
                    if (!Icon.Contains("md-") && !Icon.Contains("fa-"))
                    {
                        Icon = "md-" + Icon;
                    }
                }

                if (Icon.Contains("md-") || Icon.Contains("fa-"))
                {
                    _iconImage.Icon = Icon;
                }
            }

            if (propertyName == nameof(Enabled))
            {
                _iconImage.IsEnabled = Enabled;
            }
        }
        #endregion
    }
}

