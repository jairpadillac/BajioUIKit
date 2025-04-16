using System;
using System.Runtime.CompilerServices;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioDatePicker : BajioBaseControl
    {
        #region Elements
        private BajioIcon _calendar;
        private DatePicker _datePicker;
        private Label _date;
        private BajioSvgIcon _chevron;
        #endregion

        #region Binding Properties
        /// <summary>
        /// The is border displayed property.
        /// </summary>
        public static readonly BindableProperty IsBorderDisplayedProperty =
            BindableProperty.Create(nameof(IsBorderDisplayed), typeof(bool), typeof(BajioDatePicker), true);

        /// <summary>
        /// The border width property.
        /// </summary>
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(BajioDatePicker), 2f);

        /// <summary>
        /// The corner radius property.
        /// </summary>
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(BajioDatePicker), 4f);

        /// <summary>
        /// The entry height property.
        /// </summary>
        public static readonly BindableProperty EntryHeightProperty =
            BindableProperty.Create(nameof(EntryHeight), typeof(double), typeof(BajioDatePicker), 45d, BindingMode.TwoWay);

        /// <summary>
        /// The entry font size property.
        /// </summary>
        public static readonly BindableProperty EntryFontSizeProperty =
            BindableProperty.Create(nameof(EntryFontSize), typeof(double), typeof(BajioDatePicker), 12d);

        /// <summary>
        /// The entry text color property.
        /// </summary>
        public static readonly BindableProperty EntryTextColorProperty =
            BindableProperty.Create(nameof(EntryTextColor), typeof(Color), typeof(BajioDatePicker), Theme.TextColorSecondary);

        /// <summary>
        /// The space title entry property.
        /// </summary>
        public static readonly BindableProperty EntryMarginProperty =
            BindableProperty.Create(nameof(EntryMargin), typeof(Thickness), typeof(BajioDatePicker), new Thickness(0, 0, 0, 0), BindingMode.TwoWay);

        /// <summary>
        /// The default value property.
        /// </summary>
        public static readonly BindableProperty DefaultValueProperty =
            BindableProperty.Create(nameof(DefaultValue), typeof(bool), typeof(BajioDatePicker), true, BindingMode.TwoWay);

        /// <summary>
        /// The date property.
        /// </summary>
        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime?), typeof(BajioDatePicker), null, BindingMode.TwoWay);

        /// <summary>
        /// The date format property.
        /// </summary>
        public static readonly BindableProperty DateFormatProperty =
            BindableProperty.Create(nameof(DateFormat), typeof(String), typeof(BajioDatePicker), "dd/MM/yyyy", BindingMode.TwoWay);

        /// <summary>
        /// The minimum date property.
        /// </summary>
        public static readonly BindableProperty MinDateProperty =
            BindableProperty.Create(nameof(MinDate), typeof(DateTime), typeof(BajioDatePicker), default(DateTime), BindingMode.TwoWay);

        /// <summary>
        /// The max date property.
        /// </summary>
        public static readonly BindableProperty MaxDateProperty =
            BindableProperty.Create(nameof(MaxDate), typeof(DateTime), typeof(BajioDatePicker), default(DateTime), BindingMode.TwoWay);
        #endregion

        #region Private Properties
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioUIKit.Mobile.Controls.BajioEntry"/> is border displayed.
        /// </summary>
        /// <value><c>true</c> if is border displayed; otherwise, <c>false</c>.</value>
        public bool IsBorderDisplayed
        {
            get { return (bool)GetValue(IsBorderDisplayedProperty); }
            set { SetValue(IsBorderDisplayedProperty, value); }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

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
        /// Gets or sets the height of the entry.
        /// </summary>
        /// <value>The height of the entry.</value>
        public double EntryHeight
        {
            get { return (double)GetValue(EntryHeightProperty); }
            set { SetValue(EntryHeightProperty, value); }
        }

        /// <summary>
        /// Gets or sets the size of the entry font.
        /// </summary>
        /// <value>The size of the entry font.</value>
        public double EntryFontSize
        {
            get { return (double)GetValue(EntryFontSizeProperty); }
            set { SetValue(EntryFontSizeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the color of the entry text.
        /// </summary>
        /// <value>The color of the entry text.</value>
        public Color EntryTextColor
        {
            get { return (Color)GetValue(EntryTextColorProperty); }
            set { SetValue(EntryTextColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the space title entry.
        /// </summary>
        /// <value>The space title entry.</value>
        public Thickness EntryMargin
        {
            get { return (Thickness)GetValue(EntryMarginProperty); }
            set { SetValue(EntryMarginProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioUIKit.Mobile.Controls.BajioDatePicker"/>
        /// default value.
        /// </summary>
        /// <value><c>true</c> if default value; otherwise, <c>false</c>.</value>
        public bool DefaultValue
        {
            get { return (bool)GetValue(DefaultValueProperty); }
            set { SetValue(DefaultValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        public DateTime? Date
        {
            get { return (DateTime?)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        /// <summary>
        /// Gets or sets the date format.
        /// </summary>
        /// <value>The date format.</value>
        public string DateFormat
        {
            get { return (string)GetValue(DateFormatProperty); }
            set { SetValue(DateFormatProperty, value); }
        }

        /// <summary>
        /// Gets or sets the minimum date.
        /// </summary>
        /// <value>The minimum date.</value>
        public DateTime MinDate
        {
            get { return (DateTime)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        /// <summary>
        /// Gets or sets the max date.
        /// </summary>
        /// <value>The max date.</value>
        public DateTime MaxDate
        {
            get { return (DateTime)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
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

            if (propertyName == DateProperty.PropertyName)
            {
                if (Date.HasValue)
                {
                    _datePicker.Date = Date.Value;

                    FormatDate();
                }
                else
                {
                    if (DefaultValue)
                    {
                        _datePicker.Date = DateTime.Today;

                        FormatDate();
                    }
                    else
                    {
                        _date.Text = "";
                    }
                }
            }

            if (propertyName == DateFormatProperty.PropertyName)
            {
                _datePicker.Format = DateFormat;

                if (Date.HasValue)
                {
                    FormatDate();
                }
                else
                {
                    if (DefaultValue)
                    {
                        FormatDate();
                    }
                    else
                    {
                        _date.Text = "";
                    }
                }
            }

            if (propertyName == MinDateProperty.PropertyName)
            {
                _datePicker.MinimumDate = MinDate;
            }

            if (propertyName == MaxDateProperty.PropertyName)
            {
                _datePicker.MaximumDate = MaxDate;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Ons the date selected.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            Date = e.NewDate;
            _date.Text = e.NewDate.ToString(DateFormat);
        }

        /// <summary>
        /// Ons the open date picker.
        /// </summary>
        private void OnOpenDatePicker()
        {
            if (_datePicker.IsFocused)
            {
                _datePicker.Unfocus();
            }

            _datePicker.Focus();
        }

        /// <summary>
        /// Formats the date.
        /// </summary>
        private void FormatDate()
        {
            var day = _datePicker.Date == DateTime.Today
                                 ? "" //"Today, "
                                 : string.Format("{0:dddd}, ", _datePicker.Date);

            _date.Text = _datePicker.Date.ToString(DateFormat); //day + _datePicker.Date.ToString(DateFormat);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BajioUIKit.Mobile.Controls.BajioDatePicker"/> class.
        /// </summary>
        public BajioDatePicker()
        {
            var tapGestureRecognizer = new TapGestureRecognizer
            {
                Command = new Command(OnOpenDatePicker)
            };

            _calendar = new BajioIcon
            {
                Icon = "today",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Size = 25,
                Color = Theme.TextColorSecondary
            };

            _date = new Label
            {
                TextColor = Theme.TextColorSecondary,
                VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start
            };

            _date.SetBinding(Label.HeightRequestProperty, nameof(EntryHeight));
            _date.SetBinding(Label.FontSizeProperty, nameof(EntryFontSize));
            _date.SetBinding(Label.TextColorProperty, nameof(EntryTextColor));
            _date.SetBinding(Label.MarginProperty, nameof(EntryMargin));

            _datePicker = new DatePicker();
            _datePicker.Margin = new Thickness(10, 0, 0, 0);
            _datePicker.IsVisible = false;
            _datePicker.DateSelected += OnDateSelected;

            if (DefaultValue)
            {
                _date.Text = "";//"Today, " + DateTime.Today.ToString(DateFormat);
                _datePicker.Date = DateTime.Today;

            }

            _chevron = new BajioSvgIcon
            {
                Icon = "arrow_drop_down.svg",
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                //Size = 25,
                //Color = Theme.TextColorSecondary
                WidthRequest = 44,
                HeightRequest = 25
            };

            _calendar.GestureRecognizers.Add(tapGestureRecognizer);
            _date.GestureRecognizers.Add(tapGestureRecognizer);
            _chevron.GestureRecognizers.Add(tapGestureRecognizer);

            ContainerControl = new BajioContainerControl();

            ContainerControl.RowDefinitions?.Clear();
            ContainerControl.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            ContainerControl.ColumnDefinitions?.Clear();
            ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = 10 });
            ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            ContainerControl.BindingContext = this;
            ContainerControl.SetBinding(BajioContainerControl.ErrorMessageProperty, nameof(ErrorMessage), BindingMode.TwoWay);
            ContainerControl.SetBinding(BajioContainerControl.ErrorProperty, nameof(Error), BindingMode.TwoWay);
            ContainerControl.SetBinding(BajioContainerControl.IsBorderDisplayedProperty, nameof(IsBorderDisplayed));
            ContainerControl.SetBinding(BajioContainerControl.BorderWidthProperty, nameof(BorderWidth));
            ContainerControl.SetBinding(BajioContainerControl.CornerRadiusProperty, nameof(CornerRadius));

            //ContainerControl.Children.Add(_calendar, 0, 0);
            ContainerControl.Children.Add(_date, 1, 0);
            ContainerControl.Children.Add(_datePicker, 1, 0);
            ContainerControl.Children.Add(_chevron, 2, 0);
            ContainerControl.HeightRequest = 50;

            this.Children.Add(ContainerControl);

            ClearButtonEnable = false;
        }
        #endregion
    }
}
