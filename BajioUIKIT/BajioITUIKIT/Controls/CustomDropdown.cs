using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BajioITUIKIT.Controls.ControlModels;
using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class CustomDropdown : StackLayout
    {
        #region Private Properties
        /// <summary>
        /// The placeholder
        /// </summary>
        private readonly Label _placeholder = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            TextColor = Theme.TextColorSecondary,
            FontSize = 10,
            VerticalOptions = LayoutOptions.StartAndExpand,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Margin = new Thickness(0, 0, 0, 0),
            LineBreakMode = LineBreakMode.TailTruncation
        };

        /// <summary>
        /// The description
        /// </summary>
        private readonly Label _description = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            TextColor = Theme.TextColorSecondary,
            FontSize = 12,
            IsVisible = false,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.StartAndExpand
        };

        /// <summary>
        /// The value picker.
        /// </summary>
        private readonly Label _valuePicker = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            TextColor = Theme.TextColorSecondary,
            FontSize = 10,
            IsVisible = false,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            LineBreakMode = LineBreakMode.TailTruncation
        };

        /// <summary>
        /// The picker container
        /// </summary>
        private readonly BajioContainerControl _pickerContainer;

        /// <summary>
        /// The chevron
        /// </summary>
        private readonly BajioSvgIcon _chevron = new BajioSvgIcon()
        {
            Icon = "arrow_drop_down.svg",
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            WidthRequest = 44,
            HeightRequest = 25
        };

        /// <summary>
        /// The error message label
        /// </summary>
        private Label _errorMessageLabel = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            HorizontalOptions = LayoutOptions.StartAndExpand,
            TextColor = Theme.InvalidColorPrimary,
            FontSize = 12d,
            FontAttributes = FontAttributes.Bold
        };

        /// <summary>
        /// The content of the description.
        /// </summary>
        private Grid _descriptionContent;

        /// <summary>
        /// The description content a.
        /// </summary>
        private StackLayout _descriptionContentA;

        /// <summary>
        /// The gesture.
        /// </summary>
        private TapGestureRecognizer _gesture;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CustomDropdown"/> is
        /// Bajio question.
        /// </summary>
        /// <value><c>true</c> if is bajio question; otherwise, <c>false</c>.</value>
        public bool IsBajioQuestion { get; set; }

        /// <summary>
        /// Occurs when [selected index changed].
        /// </summary>
        public event EventHandler SelectedIndexChanged;
        /// <summary>
        /// The items property
        /// </summary>
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items),
            typeof(IList<DropdownItem>), typeof(CustomDropdown), null, BindingMode.OneWay, propertyChanged: ChangeItems);

        /// <summary>
        /// The selected item property
        /// </summary>
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem),
            typeof(DropdownItem), typeof(CustomDropdown), null, BindingMode.TwoWay, propertyChanged: SelectedItemChanged);

        /// <summary>
        /// The enabled property
        /// </summary>
        public static readonly BindableProperty EnabledProperty = BindableProperty.Create(nameof(Enabled),
            typeof(bool), typeof(CustomDropdown), true, BindingMode.TwoWay, propertyChanged: ToggleEnabled);

        /// <summary>
        /// The is title visible property
        /// </summary>
        public static readonly BindableProperty IsTitleVisibleProperty = BindableProperty.Create(nameof(IsTitleVisible),
            typeof(bool), typeof(CustomDropdown), true, BindingMode.TwoWay);

        /// <summary>
        /// The title property
        /// </summary>
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title),
            typeof(string), typeof(CustomDropdown), string.Empty, BindingMode.OneWay, propertyChanged: TitleChange);

        /// <summary>
        /// The error message property
        /// </summary>
        public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage),
            typeof(string), typeof(BajioEntryBase), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// The error property
        /// </summary>
        public static readonly BindableProperty ErrorProperty = BindableProperty.Create(nameof(Error),
            typeof(bool), typeof(BajioEntryBase), false, BindingMode.TwoWay);


        /// <summary>
        /// The is place holder visible property
        /// </summary>
        public static readonly BindableProperty IsPlaceHolderVisibleProperty = BindableProperty.Create(nameof(IsPlaceHolderVisible),
            typeof(bool), typeof(CustomDropdown), false, BindingMode.TwoWay);

        /// <summary>
        /// The height request bajio dropdown property
        /// </summary>
        public static readonly BindableProperty HeightRequestCustomDropdownProperty = BindableProperty.Create(nameof(HeightRequestCustomDropdown),
          typeof(int), typeof(CustomDropdown), 64, BindingMode.TwoWay);


        /// <summary>
        /// The font size title property
        /// </summary>
        public static readonly BindableProperty FontSizeTitleProperty = BindableProperty.Create(nameof(FontSizeTitle),
         typeof(int), typeof(CustomDropdown), 14, BindingMode.TwoWay);


        /// <summary>
        /// The width request bajio dropdown property.
        /// </summary>
        public static readonly BindableProperty WidthRequestCustomDropdownProperty = BindableProperty.Create(nameof(WidthRequestCustomDropdown),
            typeof(int), typeof(BajioDropdownEditable), 60, BindingMode.TwoWay);

        /// <summary>
        /// The error message label style property
        /// </summary>
        public static readonly BindableProperty ErrorMessageLabelStyleProperty = BindableProperty.Create(nameof(ErrorMessageLabelStyle),
            typeof(Xamarin.Forms.Style), typeof(BajioEntryBase), default, BindingMode.TwoWay);

        /// <summary>
        /// The error message label font size property
        /// </summary>
        public static readonly BindableProperty ErrorMessageLabelFontSizeProperty = BindableProperty.Create(nameof(ErrorMessageLabelFontSize),
            typeof(double), typeof(BajioEntryBase), Device.GetNamedSize(NamedSize.Micro, typeof(Label)), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the font size title.
        /// </summary>
        /// <value>
        /// The font size title.
        /// </value>
        public int FontSizeTitle
        {
            get
            {
                return (int)GetValue(FontSizeTitleProperty);
            }
            set
            {
                SetValue(FontSizeTitleProperty, value);
            }
        }

        /// <summary>
        /// The font size of the description property
        /// </summary>
        public static readonly BindableProperty FontSizeDescriptionProperty = BindableProperty.Create(nameof(FontSizeDescription),
         typeof(int), typeof(CustomDropdown), 10, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the font size of the description.
        /// </summary>
        /// <value>
        /// The font size of the description.
        /// </value>
        public int FontSizeDescription
        {
            get
            {
                return (int)GetValue(FontSizeDescriptionProperty);
            }
            set
            {
                SetValue(FontSizeDescriptionProperty, value);
            }
        }

        /// <summary>
        /// The font size for the picker property
        /// </summary>
        public static readonly BindableProperty FontSizePickerProperty = BindableProperty.Create(nameof(FontSizePicker),
         typeof(int), typeof(CustomDropdown), 12, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the font size of the picker.
        /// </summary>
        /// <value>
        /// The font size of the picker.
        /// </value>
        public int FontSizePicker
        {
            get
            {
                return (int)GetValue(FontSizePickerProperty);
            }
            set
            {
                SetValue(FontSizePickerProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the width request bajio dropdown.
        /// </summary>
        /// <value>The width request bajio dropdown.</value>
        public int WidthRequestCustomDropdown
        {
            get
            {
                return (int)GetValue(WidthRequestCustomDropdownProperty);
            }
            set
            {
                SetValue(WidthRequestCustomDropdownProperty, value);
            }
        }

        /// <summary>
        /// Titles the change.
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldvalue">The oldvalue.</param>
        /// <param name="newvalue">The newvalue.</param>
        private static void TitleChange(BindableObject bindable, object oldvalue, object newvalue)
        {
            var dropdown = ((CustomDropdown)bindable);
            var title = newvalue.ToString();

            dropdown._placeholder.Text = title;
            if (Device.RuntimePlatform == Device.iOS)
            {
                dropdown.Picker.Title = title;
            }

        }

        public CustomPicker Picker;

        /// <summary>
        /// Togle is enable flag.
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void ToggleEnabled(BindableObject bindable, object oldValue, object newValue)
        {
            var dropdown = ((CustomDropdown)bindable);
            if (dropdown.Enabled)
            {
                dropdown.Picker.IsEnabled = true;
                dropdown._pickerContainer.Enabled = true;
                if (Device.RuntimePlatform == Device.iOS)
                {
                    dropdown.Picker.BackgroundColor = Theme.EntryEnabledBackground;
                }
            }
            else
            {
                dropdown.Picker.IsEnabled = false;
                dropdown._pickerContainer.Enabled = false;
                if (Device.RuntimePlatform == Device.iOS)
                {
                    dropdown.Picker.BackgroundColor = Color.Transparent;
                }
            }
        }

        /// <summary>
        /// Items Change handler
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void ChangeItems(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null) return;

            var picker = ((CustomDropdown)bindable).Picker;
            var items = (IList<DropdownItem>)newValue;

            picker.Items.Clear();
            foreach (var i in items)
            {
                picker.Items.Add(i.Title);
            }
        }

        /// <summary>
        /// Selecteds the item changed.
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        private static void SelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var dropdown = ((CustomDropdown)bindable);
            if (dropdown.SelectedItem == null)
            {
                dropdown.Picker.SelectedIndex = -1;
            }
            else
            {
                if (dropdown.Items != null)
                {
                    dropdown.Picker.SelectedIndex = dropdown.Items.IndexOf(dropdown.SelectedItem);
                }
                else
                {
                    dropdown.Picker.SelectedIndex = -1;
                }
            }
        }

        /// <summary>
        /// Is enable property
        /// </summary>
        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is title visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is title visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsTitleVisible
        {
            get { return (bool)GetValue(IsTitleVisibleProperty); }
            set { SetValue(IsTitleVisibleProperty, value); }
        }

        /// <summary>
        /// IsSelected Item property
        /// </summary>
        public DropdownItem SelectedItem
        {
            get { return (DropdownItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// Items property
        /// </summary>
        public IList<DropdownItem> Items
        {
            get { return (IList<DropdownItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        /// <summary>
        /// Title property is plain string non bindable.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CustomDropdown"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        public bool Error
        {
            get { return (bool)GetValue(ErrorProperty); }
            set
            {
                SetValue(ErrorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set
            {
                SetValue(ErrorMessageProperty, value);
                _errorMessageLabel.IsVisible = !string.IsNullOrEmpty(_errorMessageLabel.Text);
            }
        }

        /// <summary>
        /// Gets or sets the error message label style.
        /// </summary>
        /// <value>
        /// The error message label style.
        /// </value>
        public Xamarin.Forms.Style ErrorMessageLabelStyle
        {
            get
            {
                return (Xamarin.Forms.Style)GetValue(ErrorMessageLabelStyleProperty);
            }
            set
            {
                SetValue(ErrorMessageLabelStyleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the error message label font size.
        /// </summary>
        /// <value>
        /// The error message label font size.
        /// </value>
        public double ErrorMessageLabelFontSize
        {
            get
            {
                return (double)GetValue(ErrorMessageLabelFontSizeProperty);
            }
            set
            {
                SetValue(ErrorMessageLabelFontSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is place holder visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is place holder visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlaceHolderVisible
        {
            get
            {
                return (bool)GetValue(IsPlaceHolderVisibleProperty);
            }
            set
            {
                SetValue(IsPlaceHolderVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height request bajio dropdown.
        /// </summary>
        /// <value>
        /// The height request bajio dropdown.
        /// </value>
        public int HeightRequestCustomDropdown
        {
            get
            {
                return (int)GetValue(HeightRequestCustomDropdownProperty);
            }
            set
            {
                SetValue(HeightRequestCustomDropdownProperty, value);
            }
        }

        /// <summary>
        /// The on focus error property.
        /// </summary>
        public static readonly BindableProperty OnFocusErrorProperty =
            BindableProperty.Create(nameof(OnFocusError), typeof(bool), typeof(CustomDropdown), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CustomDropdown"/> on
        /// focus error.
        /// </summary>
        /// <value><c>true</c> if on focus error; otherwise, <c>false</c>.</value>
        public bool OnFocusError
        {
            get
            {
                return (bool)GetValue(OnFocusErrorProperty);
            }
            set
            {
                SetValue(OnFocusErrorProperty, value);
            }
        }

        /// <summary>
        /// The place holder text property.
        /// </summary>
        public static readonly BindableProperty PlaceHolderTextProperty = BindableProperty.Create(nameof(PlaceHolderText),
            typeof(string), typeof(CustomDropdown), string.Empty, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets the place holder text.
        /// </summary>
        /// <value>The place holder text.</value>
        public string PlaceHolderText
        {
            get
            {
                return (string)GetValue(PlaceHolderTextProperty);
            }
            set
            {
                SetValue(PlaceHolderTextProperty, value);
            }
        }

        /// <summary>
        /// The font attributes title property.
        /// </summary>
        public static readonly BindableProperty StyleTitleProperty = BindableProperty.Create(nameof(TitleStyle),
            typeof(Xamarin.Forms.Style), typeof(CustomDropdown), (Xamarin.Forms.Style)Application.Current.Resources["label-primary"], BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets the font attributes title.
        /// </summary>
        /// <value>The font attributes title.</value>
        public Xamarin.Forms.Style TitleStyle
        {
            get
            {
                return (Xamarin.Forms.Style)GetValue(StyleTitleProperty);
            }
            set
            {
                SetValue(StyleTitleProperty, value);
            }
        }

        /// <summary>
        /// The is enabled picker property.
        /// </summary>
        public static readonly BindableProperty IsEnabledPickerProperty = BindableProperty.Create(nameof(IsEnabledPicker),
        typeof(bool), typeof(CustomPicker), true, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CustomPicker"/> is
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

        /// <summary>
        /// The on focus picker property.
        /// </summary>
        public static readonly BindableProperty OnFocusPickerProperty =
            BindableProperty.Create(nameof(OnFocusPicker), typeof(bool), typeof(CustomDropdown), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CustomDropdown"/> on
        /// focus picker.
        /// </summary>
        /// <value><c>true</c> if on focus picker; otherwise, <c>false</c>.</value>
        public bool OnFocusPicker
        {
            get
            {
                return (bool)GetValue(OnFocusPickerProperty);
            }
            set
            {
                SetValue(OnFocusPickerProperty, value);
            }
        }

        /// <summary>
        /// The is visible picker property.
        /// </summary>
        public static readonly BindableProperty IsVisiblePickerProperty =
            BindableProperty.Create(nameof(IsVisiblePicker), typeof(bool), typeof(CustomDropdown), true, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CustomDropdown"/> is
        /// visible picker.
        /// </summary>
        /// <value><c>true</c> if is visible picker; otherwise, <c>false</c>.</value>
        public bool IsVisiblePicker
        {
            get
            {
                return (bool)GetValue(IsVisiblePickerProperty);
            }
            set
            {
                SetValue(IsVisiblePickerProperty, value);
            }
        }

        /// <summary>
        /// The is enabled picker property.
        /// </summary>
        public static readonly BindableProperty TitleMarginProperty = BindableProperty.Create(nameof(TitleMargin),
        typeof(Thickness), typeof(CustomDropdown), new Thickness(0, 0, 0, 12), BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:CustomPicker"/> is
        /// enabled picker.
        /// </summary>
        /// <value><c>true</c> if is enabled picker; otherwise, <c>false</c>.</value>
        public Thickness TitleMargin
        {
            get
            {
                return (Thickness)GetValue(TitleMarginProperty);
            }
            set
            {
                SetValue(TitleMarginProperty, value);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public CustomDropdown()
        {
            // Container config
            Orientation = StackOrientation.Vertical;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Start;
            Spacing = 0;
            Padding = new Thickness(0, 0, 0, 20);

            Picker = new CustomPicker()
            {
                TextColor = Theme.TextColorSecondary,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Title = string.Empty,
                FontSize = FontSizePicker,
            };

            Picker.SelectedIndexChanged += OnSelectedItem;

            _gesture = new TapGestureRecognizer
            {
                Command = new Command((o) =>
                {
                    if (Enabled && !Picker.IsFocused)
                    {
                        Device.BeginInvokeOnMainThread(() => {
                            Picker.Focus();
                        });
                    }
                })
            };

            // Trigger picker on chevron tap
            _valuePicker.GestureRecognizers.Add(_gesture);
            _chevron.GestureRecognizers.Add(_gesture);

            var contentGrid = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal
            };

            _pickerContainer = new BajioContainerControl()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 50,
            };

            _pickerContainer.Children.Add(contentGrid);

            // Pass same bindings that this class uses
            _pickerContainer.BindingContext = this;
            _pickerContainer.SetBinding(BajioContainerControl.EnabledProperty, "Enabled");
            _pickerContainer.SetBinding(BajioContainerControl.ErrorProperty, "Error");


            _description.FontSize = FontSizeDescription;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    _descriptionContent = new Grid()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.Center,
                        RowSpacing = 0,
                        Margin = new Thickness(10, 0, 0, 0)
                    };
                    _descriptionContent.Children.Add(Picker, 0, 0);
                    _descriptionContent.Children.Add(_valuePicker, 0, 0);
                    _descriptionContent.GestureRecognizers.Add(_gesture);


                    contentGrid.Children.Add(_descriptionContent);

                    break;

                case Device.Android:
                    _descriptionContentA = new StackLayout()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Orientation = StackOrientation.Vertical,
                        VerticalOptions = LayoutOptions.Center,
                        Spacing = 0
                    };

                    _descriptionContentA.Children.Add(Picker);
                    _descriptionContentA.Children.Add(_description);
                    //_descriptionContentA.GestureRecognizers.Add(_gesture);

                    contentGrid.Children.Add(_descriptionContentA);

                    break;
            }

            if (Device.RuntimePlatform == Device.Android)
            {
                _description.Margin = new Thickness(0, 0, 0, 0);
                contentGrid.Padding = new Thickness(10, 0, 0, 0);
            }
            else
            {
                _description.Margin = new Thickness(5, 0, 0, 0);
            }
            contentGrid.Children.Add(_chevron);

            // Trigger picker on description tap
            contentGrid.GestureRecognizers.Add(_gesture);

            _errorMessageLabel.BindingContext = this;
            _errorMessageLabel.SetBinding(Label.TextProperty, "ErrorMessage");
            _errorMessageLabel.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));

            _errorMessageLabel.IsVisible = false;

            _placeholder.FontSize = FontSizeTitle;
            _placeholder.BindingContext = this;
            _placeholder.SetBinding(IsVisibleProperty, nameof(IsPlaceHolderVisible));

            Children.Add(_placeholder);
            Children.Add(_pickerContainer);
            Children.Add(_errorMessageLabel);
            this.GestureRecognizers.Add(_gesture);
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Method that is called when a bound property is changed.
        /// </summary>
        /// <param name="propertyName">The name of the bound property that changed.</param>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ErrorProperty.PropertyName)
            {
                OnError();
            }

            if (propertyName == IsPlaceHolderVisibleProperty.PropertyName)
            {
                Picker.Title = Title;
            }

            if (propertyName == HeightRequestCustomDropdownProperty.PropertyName)
            {
                HeightRequest = HeightRequestCustomDropdown;
            }
            if (propertyName == WidthRequestCustomDropdownProperty.PropertyName)
            {
                WidthRequest = WidthRequestCustomDropdown;
            }

            if (propertyName == FontSizeTitleProperty.PropertyName)
            {
                _placeholder.FontSize = FontSizeTitle;
            }

            if (propertyName == FontSizeDescriptionProperty.PropertyName)
            {
                _description.FontSize = FontSizeDescription;
            }

            if (propertyName == FontSizePickerProperty.PropertyName)
            {
                Picker.FontSize = FontSizePicker;
            }

            if (propertyName == OnFocusErrorProperty.PropertyName)
            {
                if (OnFocusError && !Picker.IsFocused)
                    Picker.Focus();
            }

            if (propertyName == IsEnabledProperty.PropertyName)
            {
                if (Picker != null)
                {
                    Picker.IsEnabled = IsEnabled;
                }

                if (IsEnabled)
                {
                    Picker?.GestureRecognizers.Clear();
                    Picker?.GestureRecognizers.Add(_gesture);

                    _chevron?.GestureRecognizers.Clear();
                    _chevron?.GestureRecognizers.Add(_gesture);

                    _valuePicker?.GestureRecognizers.Clear();
                    _valuePicker?.GestureRecognizers.Add(_gesture);

                    _descriptionContent?.GestureRecognizers.Clear();
                    _descriptionContent?.GestureRecognizers.Add(_gesture);

                    _descriptionContentA?.GestureRecognizers.Clear();
                    _descriptionContentA?.GestureRecognizers.Add(_gesture);

                    _pickerContainer?.GestureRecognizers.Clear();
                    _pickerContainer?.GestureRecognizers.Add(_gesture);

                    GestureRecognizers.Clear();
                    GestureRecognizers.Add(_gesture);
                }
                else
                {
                    Picker.IsEnabled = false;
                    Picker?.GestureRecognizers.Clear();
                    _chevron?.GestureRecognizers.Clear();
                    _description?.GestureRecognizers.Clear();
                    _valuePicker?.GestureRecognizers.Clear();
                    _descriptionContent?.GestureRecognizers.Clear();
                    _descriptionContentA?.GestureRecognizers.Clear();
                    _pickerContainer?.GestureRecognizers.Clear();
                    GestureRecognizers.Clear();
                }
            }

            if (propertyName == nameof(Items))
            {
                Picker.IsEnabled = Items?.Count() > 0;
                if ((Items == null || Items.Count == 0) && Picker.IsFocused)
                {
                    Picker.Unfocus();
                }
            }
            if (propertyName == TitleProperty.PropertyName)
            {
                if (!string.IsNullOrEmpty(Title))
                {
                    IsPlaceHolderVisible = true;
                }

            }
            if (propertyName == PlaceHolderTextProperty.PropertyName)
            {
                if (!string.IsNullOrEmpty(PlaceHolderText))
                {
                    Picker.Title = PlaceHolderText;
                    Picker.TitleColor = Theme.EntryPlaceholderColor;
                }
            }

            if (propertyName == StyleTitleProperty.PropertyName)
            {
                _placeholder.Style = TitleStyle;
            }

            if (propertyName == TitleMarginProperty.PropertyName)
            {
                _placeholder.Margin = TitleMargin;
            }

            if (propertyName == IsEnabledPickerProperty.PropertyName)
            {
                Picker.IsEnabledPicker = IsEnabledPicker;
            }

            if (propertyName == OnFocusPickerProperty.PropertyName)
            {
                if (OnFocusPicker)
                {
                    Picker.Focus();
                }
            }

            if (propertyName == IsVisiblePickerProperty.PropertyName)
            {
                if (!IsVisiblePicker)
                {
                    Picker.IsVisible = false;
                    Picker.IsEnabled = false;
                }
            }

            if (propertyName == ErrorMessageLabelStyleProperty.PropertyName)
            {
                _errorMessageLabel.Style = ErrorMessageLabelStyle;
            }

            if (propertyName == ErrorMessageLabelFontSizeProperty.PropertyName)
            {
                _errorMessageLabel.FontSize = ErrorMessageLabelFontSize;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Handle item change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectedItem(object sender, EventArgs e)
        {
            var index = ((Picker)sender).SelectedIndex;
            if (index == -1)
            {
                _description.IsVisible = false;
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        if (_descriptionContent.Children.Count() > 2)
                        {
                            _descriptionContent.Children.RemoveAt(2);
                        }
                        break;
                }
            }
            else
            {
                if (Items?.Count > 0)
                {
                    if (!IsBajioQuestion)
                    {
                        SelectedItem = Items.ElementAt(index);
                    }
                    _description.Text = SelectedItem.Description;
                    // Show description only if there is a description
                    if (!string.IsNullOrEmpty(SelectedItem?.Description))
                    {
                        switch (Device.RuntimePlatform)
                        {
                            case Device.Android:
                                _description.IsVisible = true;
                                break;
                            case Device.iOS:
                                _descriptionContent.Children.Add(_description, 0, 1);
                                _description.IsVisible = true;
                                _valuePicker.VerticalTextAlignment = TextAlignment.Start;
                                _description.VerticalTextAlignment = TextAlignment.Start;
                                break;
                        }
                    }
                    else
                    {
                        switch (Device.RuntimePlatform)
                        {
                            case Device.iOS:
                                if (_descriptionContent.Children.Count() > 2)
                                {
                                    _descriptionContent.Children.RemoveAt(2);
                                }
                                break;
                        }

                    }
                    _description.LineBreakMode = LineBreakMode.TailTruncation;
                    _valuePicker.Text = SelectedItem.Value;
                    if (Device.RuntimePlatform == Device.Android)
                    {
                        Device.BeginInvokeOnMainThread(() => {
                            Picker.Unfocus();
                            DependencyService.Get<IForceKeyboardDismissalService>().DismissKeyboard();
                        });
                    }
                }
            }

            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);

        }

        /// <summary>
        /// Called when [error].
        /// </summary>
        private void OnError()
        {
            _errorMessageLabel.IsVisible = Error;
            if (Error)
            {
                _placeholder.TextColor = Theme.InvalidColorPrimary;
            }
            else
            {
                _placeholder.TextColor = Theme.TextColorSecondary;
            }
        }
        #endregion
    }
}
