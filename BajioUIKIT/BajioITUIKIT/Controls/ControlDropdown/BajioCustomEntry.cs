using System;
using System.Windows.Input;
using FFImageLoading.Svg.Forms;
using BajioITUIKIT.Enums;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls.ControlDropdown
{
    public class BajioCustomEntry : StackLayout
    {
        #region Public Properties
        /// <summary>
        /// Occurs when next view event.
        /// </summary>
        public event EventHandler NextViewEvent;

        /// <summary>
        /// The next view property.
        /// </summary>
        public static readonly BindableProperty NextViewProperty = BindableProperty.Create("NextView", typeof(View), typeof(EntryBase));

        /// <summary>
        /// Gets or sets the next view.
        /// </summary>
        /// <value>The next view.</value>
        public View NextView
        {
            get { return (View)GetValue(NextViewProperty); }
            set { SetValue(NextViewProperty, value); }
        }

        public static readonly BindableProperty FocusViewProperty =
            BindableProperty.Create(propertyName: nameof(FocusView),
                                    returnType: typeof(bool),
                declaringType: typeof(EntryBase),
                defaultValue: false);


        /// <summary>
        /// The should invoke action property.
        /// </summary>
        public static readonly BindableProperty ShouldInvokeActionProperty =
            BindableProperty.Create(propertyName: nameof(ShouldInvokeAction),
                                    returnType: typeof(bool),
                declaringType: typeof(EntryBase),
                defaultValue: false);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.PrestamoEntry"/>
        /// should invoke action.
        /// </summary>
        /// <value><c>true</c> if should invoke action; otherwise, <c>false</c>.</value>
		public bool ShouldInvokeAction
        {
            get { return (bool)GetValue(ShouldInvokeActionProperty); }
            set { SetValue(ShouldInvokeActionProperty, value); }
        }

        public bool FocusView
        {
            get { return (bool)GetValue(FocusViewProperty); }
            set { SetValue(FocusViewProperty, value); }
        }

        /// <summary>
        /// The return entry command property.
        /// </summary>
        public static readonly BindableProperty ReturnEntryCommandProperty = BindableProperty.Create("ReturnEntryCommand",
            typeof(object), typeof(BajioCustomEntry), null, BindingMode.TwoWay);

        public static readonly BindableProperty NextEntryCommandProperty = BindableProperty.Create("ReturnEntryCommand",
                   typeof(object), typeof(BajioCustomEntry), null, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets the return entry command.
        /// </summary>
        /// <value>The return entry command.</value>
        public ICommand ReturnEntryCommand
        {
            get { return (ICommand)GetValue(ReturnEntryCommandProperty); }
            set { SetValue(ReturnEntryCommandProperty, value); }
        }

        public ICommand NextEntryCommand
        {
            get { return (ICommand)GetValue(NextEntryCommandProperty); }
            set { SetValue(NextEntryCommandProperty, value); }
        }


        /// <summary>
        /// The input keyboard property.
        /// </summary>
		public static readonly BindableProperty InputKeyboardProperty = BindableProperty.Create("InputKeyboard",
                                                                                                typeof(ReturnTypeKeyboard), typeof(BajioCustomEntry), ReturnTypeKeyboard.Done, BindingMode.TwoWay);

        /// <summary>
        /// The clear button visible property
        /// </summary>
        public static readonly BindableProperty HeightEntryProperty = BindableProperty.Create("HeightEntry",
            typeof(int), typeof(BajioCustomEntry), 40, BindingMode.TwoWay);

        /// <summary>
        /// The clear button visible property
        /// </summary>
        public static readonly BindableProperty ClearButtonVisibleProperty = BindableProperty.Create("ClearButtonVisible",
            typeof(bool), typeof(BajioCustomEntry), false, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets a value indicating whether [clear button visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [clear button visible]; otherwise, <c>false</c>.
        /// </value>
        public bool ClearButtonVisible
        {
            get { return string.IsNullOrEmpty(Text) && ClearButtonEnable ? false : (bool)GetValue(ClearButtonVisibleProperty); }
            set
            {
                SetValue(ClearButtonVisibleProperty, value);
                OnPropertyChanged("ClearButtonVisible");
            }
        }
        /// <summary>
        /// The clear button enable property
        /// </summary>
        public static readonly BindableProperty ClearButtonEnableProperty = BindableProperty.Create("ClearButtonEnable",
            typeof(bool), typeof(BajioCustomEntry), false, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets a value indicating whether [clear button enable].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [clear button enable]; otherwise, <c>false</c>.
        /// </value>
        public bool ClearButtonEnable
        {
            get { return (bool)GetValue(ClearButtonEnableProperty); }
            set { SetValue(ClearButtonEnableProperty, value); }
        }
        /// <summary>
        /// ClickedIconParameter property to bind in the element
        /// </summary>
        public static readonly BindableProperty ClearCommandParameterProperty = BindableProperty.Create("ClearCommandParameter",
            typeof(object), typeof(BajioCustomEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// ClickedIconParameter property
        /// </summary>
        public object ClearCommandParameter
        {
            get { return (object)GetValue(ClearCommandParameterProperty); }
            set { SetValue(ClearCommandParameterProperty, value); }
        }
        /// <summary>
        /// The clear command property
        /// </summary>
        public static readonly BindableProperty ClearCommandProperty = BindableProperty.Create("ClearCommand",
            typeof(ICommand), typeof(BajioCustomEntry), null, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the clear command.
        /// </summary>
        /// <value>
        /// The clear command.
        /// </value>
        public ICommand ClearCommand
        {
            get { return (ICommand)GetValue(ClearCommandProperty); }
            set { SetValue(ClearCommandProperty, value); }
        }
        /// <summary>
        /// The text property
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(BajioCustomEntry), null, BindingMode.TwoWay);
        /// <summary>
        /// The status property
        /// </summary>
        public static readonly BindableProperty StatusProperty =
            BindableProperty.Create("Status", typeof(string), typeof(BajioCustomEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// The maximum length Bajio entry property
        /// </summary>
        public static readonly BindableProperty MaxLengthPrestamoEntryProperty = BindableProperty.Create("MaxLengthPrestamoEntry",
           typeof(int), typeof(BajioCustomEntry), 255, BindingMode.TwoWay);


        /// <summary>
        /// The icon left property
        /// </summary>
        public static readonly BindableProperty IconLeftProperty = BindableProperty.Create("IconLeft",
         typeof(bool), typeof(BajioCustomEntry), true, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets the maximum length Bajio entry.
        /// </summary>
        /// <value>
        /// The maximum length Bajio entry.
        /// </value>
        public int MaxLengthPrestamoEntry
        {
            get
            {
                return (int)GetValue(MaxLengthPrestamoEntryProperty);
            }
            set
            {
                SetValue(MaxLengthPrestamoEntryProperty, value);
            }
        }

        /// <summary>
        /// Set password entry type to hide characters
        /// </summary>
        public bool IsPassword
        {
            get { return _isPassword; }
            set
            {
                _isPassword = value;
                _entry.IsPassword = value;
            }
        }
        /// <summary>
        /// Text property to bind in the element
        /// </summary>
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                _entry.Text = value;
                SetValue(TextProperty, value);
            }
        }
        /// <summary>
        /// Status styles for the entry, live binding property
        /// </summary>
        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
        /// <summary>
        /// Icon property for entry
        /// </summary>
        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                var xfSource = _imageSourceConverter.ConvertFromInvariantString(value) as ImageSource;
                _svgIconImage.Source = new SvgImageSource(xfSource, 0, 0, true);
            }
        }
        /// <summary>
        /// Placeholder property for entry
        /// </summary>
        public string Placeholder
        {
            get { return _placeHolder; }
            set
            {
                _placeHolder = value;
                _entry.Placeholder = value;
            }
        }

        /// <summary>
        /// Gets or sets the height entry.
        /// </summary>
        /// <value>
        /// The height entry.
        /// </value>
        public int HeightEntry
        {
            get
            {
                return (int)GetValue(HeightEntryProperty);
            }
            set
            {
                SetValue(HeightEntryProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has icon left.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has icon left; otherwise, <c>false</c>.
        /// </value>
        public bool HasIconLeft
        {
            get
            {
                return (bool)GetValue(IconLeftProperty);
            }
            set
            {
                SetValue(IconLeftProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the input keyboard.
        /// </summary>
        /// <value>The input keyboard.</value>
		public ReturnTypeKeyboard InputKeyboard
        {
            get { return (ReturnTypeKeyboard)GetValue(InputKeyboardProperty); }
            set { SetValue(InputKeyboardProperty, value); }
        }




        #endregion

        #region Private Properties
        private readonly ImageSourceConverter _imageSourceConverter = new ImageSourceConverter();
        private string _icon = string.Empty;
        private string _placeHolder = string.Empty;
        private bool _isPassword = false;
        /// <summary>
        /// The svg image render
        /// </summary>
        private readonly SvgCachedImage _svgIconImage = new SvgCachedImage()
        {
            WidthRequest = 18,
            HeightRequest = 16,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 0, 0, 0)
        };
        /// <summary>
        /// The clear icon
        /// </summary>
        private readonly BajioIcon _clearIcon = new BajioIcon()
        {
            Icon = "md-close",
            Size = (int)Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            Color = Theme.EntryClearButtonColor,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 0, 0, 0)
        };
        /// <summary>
        /// Inner base entry element
        /// </summary>
        public EntryBase _entry = new EntryBase
        {
            PlaceholderColor = Theme.EntryPlaceholderColor,
            TextColor = Theme.TextColorTitleTabPage,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Margin = new Thickness(0, 0, 5, 0),
            ReturnType = ReturnTypeKeyboard.Done
        };
        /// <summary>
        /// Inner container for the entry to handle border
        /// </summary>
        private Grid _container = new Grid
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            MinimumWidthRequest = 330,
            BackgroundColor = Theme.EntryEnabledBackground,
            //Orientation = StackOrientation.Horizontal
        };
        #endregion

        #region Public Methods
        /// <summary>
        /// Constructor
        /// </summary>
        public BajioCustomEntry()
        {
            _clearIcon.BindingContext = this;
            _clearIcon.SetBinding(IsVisibleProperty, nameof(ClearButtonVisible));
            _clearIcon.ClickedIcon = new Command(ClearClicked);
            _clearIcon.VerticalOptions = LayoutOptions.Center;

            _entry.VerticalOptions = LayoutOptions.Center;
            _clearIcon.VerticalOptions = LayoutOptions.Center;

            _container.ColumnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition(){Width= GridLength.Auto},
                new ColumnDefinition(){Width= GridLength.Star},
                new ColumnDefinition(){Width= GridLength.Auto},
            };

            _container.Children.Add(_svgIconImage, 0, 0);
            _container.Children.Add(_entry, 1, 0);
            _container.Children.Add(_clearIcon, 2, 0);
            Children.Add(_container);

            _entry.BindingContext = this;
            // Broadcast changes on entry text changed
            _entry.TextChanged += textChange;
            // Keep listen to text changes
            _entry.SetBinding(TextProperty, "Text");


            _entry.BackgroundColor = Theme.EntryEnabledBackground;
            _entry.Completed += _entry_Completed;
            _entry.NextViewCompleted += _entry_NextViewCompleted;
            BackgroundColor = Theme.EntryEnabledBackground;

            Padding = 1;
        }

        public void InvokeCompleted()
        {
            if (this.NextViewEvent != null)
                this.NextViewEvent.Invoke(this, null);
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Property changes event handler for binding properties
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing</param>
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == StatusProperty.PropertyName)
            {
                SetStatusStyles(Status);
            }
            if (propertyName == MaxLengthPrestamoEntryProperty.PropertyName)
            {
                _entry.Behaviors.Add(new MaxLengthValidator { MaxLength = MaxLengthPrestamoEntry });
            }
            if (propertyName == HeightEntryProperty.PropertyName)
            {
                _entry.HeightRequest = HeightEntry;
                _entry.VerticalOptions = LayoutOptions.CenterAndExpand;
            }
            if (propertyName == IconLeftProperty.PropertyName)
            {
                if (!HasIconLeft)
                {
                    _container.Children.RemoveAt(0);
                }
            }
            if (propertyName == InputKeyboardProperty.PropertyName)
            {
                _entry.ReturnType = InputKeyboard;
            }
            if (propertyName == ShouldInvokeActionProperty.PropertyName)
            {
                if (ShouldInvokeAction)
                {
                    _entry.ShouldInvokeAction = ShouldInvokeAction;
                }
            }
            if (propertyName == NextViewProperty.PropertyName)
            {
                if (NextView != null)
                {
                    _entry.NextView = NextView;
                }
            }
            if (propertyName == FocusViewProperty.PropertyName)
            {
                if (FocusView)
                {
                    _entry.Focus();
                }
                else
                {
                    _entry.Unfocus();
                }
            }

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Entries the next view completed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void _entry_NextViewCompleted(object sender, EventArgs e)
        {
            NextEntryCommand?.Execute(null);
        }

        /// <summary>
        /// Entries the completed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void _entry_Completed(object sender, System.EventArgs e)
        {
            ReturnEntryCommand?.Execute(null);
        }


        /// <summary>
        /// Apply styles to entry
        /// </summary>
        /// <param name="status">Styles status</param>
        private void SetStatusStyles(string status)
        {
            switch (status)
            {
                case "error":
                    {
                        this.BackgroundColor = Theme.InvalidColorPrimary;
                    }
                    break;
                default:
                    {
                        this.BackgroundColor = Theme.EntryEnabledBackground;
                    }
                    break;
            }
        }
        /// <summary>
        /// Clears the clicked.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void ClearClicked(object obj)
        {
            Text = string.Empty;
            ClearCommand?.Execute(ClearCommandParameter);
        }
        /// <summary>
        /// Text change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textChange(object sender, TextChangedEventArgs e)
        {
            Text = e.NewTextValue;
            ClearButtonVisible = ClearButtonEnable && !string.IsNullOrEmpty(Text);
        }
        #endregion
    }
}
