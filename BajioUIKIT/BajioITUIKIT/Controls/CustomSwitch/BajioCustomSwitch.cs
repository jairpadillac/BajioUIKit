using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioCustomSwitch : StackLayout
    {

        #region Private Properties

        #endregion


        #region Public Properties
        /// <summary>
        /// The is initial selected property.
        /// </summary>
        public static readonly BindableProperty IsInitialSelectedProperty =
            BindableProperty.Create(nameof(IsInitialSelected), typeof(bool), typeof(BajioCustomSwitch), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioCustomSwitch"/> is
        /// initial selected.
        /// </summary>
        /// <value><c>true</c> if is initial selected; otherwise, <c>false</c>.</value>
        public bool IsInitialSelected
        {
            get { return (bool)GetValue(IsInitialSelectedProperty); }
            set { SetValue(IsInitialSelectedProperty, value); }
        }

        /// <summary>
        /// The fill color property.
        /// </summary>
        public static readonly BindableProperty FillColorProperty =
            BindableProperty.Create(nameof(FillColor), typeof(Color), typeof(BajioCustomSwitch), Color.LightGray, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        /// <summary>
        /// The font size property.
        /// </summary>
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(int), typeof(BajioCustomSwitch), 12, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>The size of the font.</value>
        public int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        /// <summary>
        /// The is active property.
        /// </summary>
        public static readonly BindableProperty IsActiveProperty =
            BindableProperty.Create(nameof(IsActive), typeof(bool?), typeof(BajioCustomSwitch), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioCustomSwitch"/> is active.
        /// </summary>
        /// <value>The color of the tint.</value>
        public bool? IsActive
        {
            get { return (bool?)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        /// <summary>
        /// The stroke width property.
        /// </summary>
        public static readonly BindableProperty StrokeWidthProperty =
            BindableProperty.Create(nameof(StrokeWidth), typeof(int), typeof(BajioCustomSwitch), 1, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the width of the stroke.
        /// </summary>
        /// <value>The width of the stroke.</value>
        public int StrokeWidth
        {
            get { return (int)GetValue(StrokeWidthProperty); }
            set { SetValue(StrokeWidthProperty, value); }
        }

        /// <summary>
        /// The border color property.
        /// </summary>
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(BajioCustomSwitch), Color.Blue, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// The tint color property.
        /// </summary>
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(BajioCustomSwitch), Color.Blue, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the color of the tint.
        /// </summary>
        /// <value>The color of the tint.</value>
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        /// <summary>
        /// The inactive color property.
        /// </summary>
        public static readonly BindableProperty InactiveColorProperty =
            BindableProperty.Create(nameof(InactiveColor), typeof(Color), typeof(BajioCustomSwitch), Theme.InactiveColor, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the color of the inactive.
        /// </summary>
        /// <value>The color of the inactive.</value>
        public Color InactiveColor
        {
            get { return (Color)GetValue(InactiveColorProperty); }
            set { SetValue(InactiveColorProperty, value); }
        }

        /// <summary>
        /// The label yes text property.
        /// </summary>
        public static readonly BindableProperty LabelYesTextProperty =
            BindableProperty.Create(nameof(LabelYesText), typeof(string), typeof(BajioCustomSwitch), "Yes", BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the label yes text.
        /// </summary>
        /// <value>The label yes text.</value>
        public string LabelYesText
        {
            get { return (string)GetValue(LabelYesTextProperty); }
            set { SetValue(InactiveColorProperty, value); }
        }

        /// <summary>
        /// The label no text property.
        /// </summary>
        public static readonly BindableProperty LabelNoTextProperty =
            BindableProperty.Create(nameof(LabelNoText), typeof(string), typeof(BajioCustomSwitch), "No", BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the label no text.
        /// </summary>
        /// <value>The label no text.</value>
        public string LabelNoText
        {
            get { return (string)GetValue(LabelNoTextProperty); }
            set { SetValue(InactiveColorProperty, value); }
        }
        /// <summary>
        /// The label yes.
        /// </summary>
        public Label _labelYes = new Label()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center
        };

        /// <summary>
        /// The label no.
        /// </summary>
        public Label _labelNo = new Label()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalTextAlignment = TextAlignment.Center,
            VerticalTextAlignment = TextAlignment.Center
        };

        /// <summary>
        /// The boxview.
        /// </summary>
        public BoxView _boxview = new BoxView()
        {
            Color = Color.Blue,
            WidthRequest = 0.5,
            VerticalOptions = LayoutOptions.FillAndExpand
        };

        /// <summary>
        /// The left container.
        /// </summary>
        public Grid _leftContainer = new Grid()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand
        };

        /// <summary>
        /// The right container.
        /// </summary>
        public Grid _rightContainer = new Grid()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand
        };

        #endregion


        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BajioITUIKIT.Controls.BajioCustomSwitch"/> class.
        /// </summary>
        public BajioCustomSwitch()
        {
            _labelNo.Text = LabelNoText;
            _labelYes.Text = LabelYesText;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            Orientation = StackOrientation.Horizontal;
            CreateCustomSwitch();
            Spacing = 0;
        }
        /// <summary>
        /// Creates the custom switch.
        /// </summary>
        public void CreateCustomSwitch()
        {
            this.Children.Clear();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap  
                IsYesSelected();
            };
            _leftContainer.GestureRecognizers.Add(tapGestureRecognizer);

            var tapGestureRecognizerR = new TapGestureRecognizer();
            tapGestureRecognizerR.Tapped += (s, e) => {
                // handle the tap
                IsNoselected();
            };
            _rightContainer.GestureRecognizers.Add(tapGestureRecognizerR);

            _labelYes.TextColor = InactiveColor;
            _labelNo.TextColor = InactiveColor;

            _leftContainer.Children.Add(_labelYes);

            _rightContainer.Children.Add(_labelNo);

            this.Children.Add(_leftContainer);
            this.Children.Add(_boxview);
            this.Children.Add(_rightContainer);

        }
        /// <summary>
        /// Is the Yes selected.
        /// </summary>
        public void IsYesSelected()
        {
            _leftContainer.BackgroundColor = TintColor;
            _labelYes.TextColor = Color.White;
            _rightContainer.BackgroundColor = Color.Transparent;
            _labelNo.TextColor = InactiveColor;
            IsActive = true;
        }
        /// <summary>
        /// Is the No selected.
        /// </summary>
        public void IsNoselected()
        {
            _leftContainer.BackgroundColor = Color.Transparent;
            _labelYes.TextColor = InactiveColor;
            _rightContainer.BackgroundColor = TintColor;
            _labelNo.TextColor = Color.White;
            IsActive = false;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(FontSize))
            {
                _labelNo.FontSize = FontSize;
                _labelYes.FontSize = FontSize;
            }
            if (propertyName == nameof(InactiveColor))
            {
                _labelNo.TextColor = InactiveColor;
                _labelYes.TextColor = InactiveColor;
            }
            if (propertyName == nameof(BorderColor))
            {
                _boxview.Color = BorderColor;
            }
            if (propertyName == nameof(StrokeWidth))
            {
                _boxview.WidthRequest = (double)StrokeWidth;
            }
            if (propertyName == nameof(IsInitialSelected))
            {
                if (IsActive.HasValue && (bool)IsActive.Value)
                {
                    IsYesSelected();
                }
                else
                {
                    IsNoselected();
                }
            }
            if (propertyName == nameof(TintColor))
            {
                if (IsActive.HasValue && (bool)IsActive.Value)
                {
                    IsYesSelected();
                }
                else
                {
                    IsNoselected();
                }
            }
            if (propertyName == nameof(IsActive))
            {
                if (IsInitialSelected)
                {
                    if (IsActive.HasValue && (bool)IsActive.Value)
                    {
                        IsYesSelected();
                    }
                    else
                    {
                        IsNoselected();
                    }
                }
            }
            if (propertyName == nameof(LabelYesText))
            {
                _labelYes.Text = LabelYesText;
            }
            if (propertyName == nameof(LabelNoText))
            {
                _labelNo.Text = LabelNoText;
            }
        }
        #endregion


        #region Private Methods
        #endregion
    }
}

