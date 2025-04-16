using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioEntryText : BajioEntryBase
    {
        #region Public Properties
        /// <summary>
        /// The font size property
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize),
            typeof(double), typeof(BajioEntryText), 12d, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>
        /// The size of the font.
        /// </value>
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        /// <summary>
        /// The keyboard property
        /// </summary>
        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard),
            typeof(string), typeof(BajioEntryText), "Default", BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Keyboard
        {
            get { return (string)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }
        /// <summary>
        /// The prefix property
        /// </summary>
        public static readonly BindableProperty PrefixProperty = BindableProperty.Create(nameof(Prefix),
            typeof(string), typeof(BajioEntryText), null, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>if (!string.IsNullOrEmpty(value) && _prefix != null) { _prefix.IsVisible = true; }
        /// <value>
        /// The prefix.
        /// </value>
        public string Prefix
        {
            get { return (string)GetValue(PrefixProperty); }
            set { SetValue(PrefixProperty, value); }
        }

        /// <summary>
        /// The prefix visible property
        /// </summary>
        public static readonly BindableProperty PrefixVisibleProperty = BindableProperty.Create(nameof(PrefixVisible),
            typeof(bool), typeof(BajioEntryText), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether [prefix visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [prefix visible]; otherwise, <c>false</c>.
        /// </value>
        public bool PrefixVisible
        {
            get { return string.IsNullOrEmpty(Prefix) ? false : (bool)GetValue(PrefixVisibleProperty); }
            set { SetValue(PrefixVisibleProperty, value); }
        }

        /// <summary>
        /// The value property
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value),
            typeof(string), typeof(BajioEntryText), string.Empty, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// The clear button visible property
        /// </summary>
        public static readonly BindableProperty ClearButtonVisibleProperty = BindableProperty.Create("ClearButtonVisible",
            typeof(bool), typeof(BajioEntryText), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether [clear button visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [clear button visible]; otherwise, <c>false</c>.
        /// </value>
        public bool ClearButtonVisible
        {
            get { return string.IsNullOrEmpty(Value) && ClearButtonEnable ? false : (bool)GetValue(ClearButtonVisibleProperty); }
            set { SetValue(ClearButtonVisibleProperty, value); }
        }

        /// <summary>
        /// The clear button enable property
        /// </summary>
        public static readonly BindableProperty ClearButtonEnableProperty = BindableProperty.Create("ClearButtonEnable",
            typeof(bool), typeof(BajioEntryText), false, BindingMode.TwoWay);

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
            typeof(object), typeof(BajioEntryText), null, BindingMode.TwoWay);

        /// <summary>
        /// ClickedIconParameter property
        /// </summary>
        public object ClearCommandParameter
        {
            get
            {
                return (object)GetValue(ClearCommandParameterProperty);
            }
            set
            {
                SetValue(ClearCommandParameterProperty, value);
            }
        }

        /// <summary>
        /// The clear command property
        /// </summary>
        public static readonly BindableProperty ClearCommandProperty = BindableProperty.Create("ClearCommand",
            typeof(ICommand), typeof(BajioEntryText), null, BindingMode.TwoWay);

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
        /// Unfocused Command property
        /// </summary>
        public static readonly BindableProperty UnfocusedCommandProperty = BindableProperty.Create("UnfocusedCommand",
            typeof(Command), typeof(BajioEntryText), null, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the unfocused command.
        /// </summary>
        public Command UnfocusedCommand
        {
            get { return (Command)GetValue(UnfocusedCommandProperty); }
            set { SetValue(UnfocusedCommandProperty, value); }
        }

        /// <summary>
        /// Focused Command property
        /// </summary>
        public static readonly BindableProperty FocusedCommandProperty = BindableProperty.Create("FocusedCommand",
            typeof(Command), typeof(BajioEntryText), null, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the focused command.
        /// </summary>
        public Command FocusedCommand
        {
            get { return (Command)GetValue(FocusedCommandProperty); }
            set { SetValue(FocusedCommandProperty, value); }
        }

        /// <summary>
        /// TextChanged Command property
        /// </summary>
        public static readonly BindableProperty TextChangedCommandProperty = BindableProperty.Create("TextChangedCommand",
            typeof(Command), typeof(BajioEntryText), null, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the textchanged command.
        /// </summary>
        public Command TextChangedCommand
        {
            get { return (Command)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        /// <summary>
        /// The placholder property
        /// </summary>
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
            typeof(string), typeof(BajioEntryText), string.Empty, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        /// <summary>
        /// The maximum length Bajio entry property
        /// </summary>
        public static readonly BindableProperty MaxLengthBajioEntryProperty = BindableProperty.Create("MaxLengthBajioEntry",
        typeof(int), typeof(BajioEntry), 255, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets the maximum length Bajio entry.
        /// </summary>
        /// <value>
        /// The maximum length Bajio entry.
        /// </value>
        public int MaxLengthBajioEntry
        {
            get
            {
                return (int)GetValue(MaxLengthBajioEntryProperty);
            }
            set
            {
                SetValue(MaxLengthBajioEntryProperty, value);
            }
        }

        /// <summary>
        /// EnabledProperty
        /// </summary>
        public static readonly BindableProperty EnabledProperty = BindableProperty.Create(nameof(Enabled),
            typeof(bool), typeof(BajioEntryText), false, BindingMode.TwoWay);

        /// <summary>
        /// Enabled Property
        /// </summary>
        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        #endregion

        #region Private Properties


        /// <summary>
        /// The clear icon
        /// </summary>
        BajioIcon _clearIcon = new BajioIcon()
        {
            Icon = "md-close",
            Size = (int)Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            VerticalOptions = LayoutOptions.Center,
            Color = Theme.EntryClearButtonColor,
            Margin = new Thickness(0, 0, 10, 0)
        };

        private Label _prefix = new Label()
        {
            IsVisible = false,
            TextColor = Theme.TextColorSecondary,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalTextAlignment = TextAlignment.Start
        };

        /// <summary>
        /// The entry
        /// </summary>
        private EntryBase _entry = new EntryBase()
        {
            Margin = new Thickness(0, 6, 5, 0),
            TextColor = Theme.TextColorSecondary,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Keyboard = Xamarin.Forms.Keyboard.Text
        };
        /// <summary>
        /// The entry container
        /// </summary>
        private StackLayout _entryContainer = new StackLayout()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Orientation = StackOrientation.Vertical,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Spacing = 0
        };

        /// <summary>
        /// The container for base entry.
        /// </summary>
        public BajioEntryBaseContainer Container = new BajioEntryBaseContainer();

        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="BajioEntryText"/> class.
        /// </summary>
        public BajioEntryText()
        {
            _entry.BindingContext = this;
            _entry.Unfocused += OnUnfocused;
            _entry.Focused += OnFocused;
            _entry.TextChanged += ValueChanged;
            _entry.SetBinding(Entry.FontSizeProperty, nameof(FontSize));
            UpdateKeyboard();
            _entryContainer.Children.Add(_entry);
            _entryContainer.Padding = new Thickness(10, 0, 0, 0);
            _clearIcon.BindingContext = this;
            _clearIcon.SetBinding(IsVisibleProperty, nameof(ClearButtonVisible));
            _clearIcon.SetBinding(BajioIcon.ClickedIconProperty, nameof(ClearButtonEnable));
            _clearIcon.ClickedIcon = new Command(ClearClicked);

            Container.HorizontalOptions = LayoutOptions.FillAndExpand;

            var columnDefinitionCollection = new ColumnDefinitionCollection();
            columnDefinitionCollection.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            columnDefinitionCollection.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            columnDefinitionCollection.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

            //Use grid, because when placeholder is bigger the clear icon is no centered.
            var clearTextContainer = new Grid();
            clearTextContainer.HorizontalOptions = LayoutOptions.FillAndExpand;
            clearTextContainer.VerticalOptions = LayoutOptions.CenterAndExpand;
            clearTextContainer.ColumnDefinitions = columnDefinitionCollection;

            _prefix.BindingContext = this;
            if (Device.RuntimePlatform == Device.Android)
            {
                _prefix.Margin = new Thickness(10, 0, 0, 0);
            }
            else
            {
                _prefix.Margin = new Thickness(5, 6, 0, 0);
            }
            _prefix.SetBinding(Label.FontSizeProperty, nameof(FontSize));
            _prefix.SetBinding(IsVisibleProperty, nameof(PrefixVisible));
            _prefix.SetBinding(Label.TextProperty, nameof(Prefix));

            clearTextContainer.Children.Add(_prefix, 0, 0);
            clearTextContainer.Children.Add(_entryContainer, 1, 0);
            clearTextContainer.Children.Add(_clearIcon, 2, 0);


            // Use container to wrap with border
            Container.Children.Add(clearTextContainer);
        }
        #endregion

        #region Private Methods 
        /// <summary>
        /// Clears the clicked.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void ClearClicked(object obj)
        {
            Value = string.Empty;
            ClearCommand?.Execute(ClearCommandParameter);
        }

        /// <summary>
        /// Values the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void ValueChanged(object sender, TextChangedEventArgs e)
        {
            Value = ((Entry)sender).Text;
            ClearButtonVisible = ClearButtonEnable && !string.IsNullOrEmpty(Value);
            TextChangedCommand?.Execute(e);
        }

        /// <summary>
        /// Method that is launched when entry is unfocused
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            UnfocusedCommand?.Execute(null);
        }

        /// <summary>
        /// Focuseds the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FocusEventArgs"/> instance containing the event data.</param>
        private void OnFocused(object sender, FocusEventArgs e)
        {
            FocusedCommand?.Execute(null);
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
            if (propertyName == EnabledProperty.PropertyName)
            {
                _entry.IsEnabled = Enabled;
            }

            if (propertyName == ValueProperty.PropertyName)
            {
                UpdateValue();
            }

            if (propertyName == KeyboardProperty.PropertyName)
            {
                UpdateKeyboard();
            }

            if (propertyName == PlaceholderProperty.PropertyName)
            {
                _entry.Placeholder = Placeholder;
                _entry.PlaceholderColor = Color.Gray;

            }
            if (propertyName == MaxLengthBajioEntryProperty.PropertyName)
            {
                _entry.Behaviors.Add(new BajioEntryMaxLengthBehavior { MaxLength = MaxLengthBajioEntry });
            }
        }
        /// <summary>
        /// Updates the value.
        /// </summary>
        private void UpdateValue()
        {
            _entry.Text = Value;
        }

        /// <summary>
        /// Update the keyboard.
        /// </summary>
        private void UpdateKeyboard()
        {
            if (!string.IsNullOrEmpty(this.Keyboard))
            {
                Keyboard k = null;

                switch (this.Keyboard)
                {
                    case "Chat":
                        k = Xamarin.Forms.Keyboard.Chat;
                        break;
                    case "Email":
                        k = Xamarin.Forms.Keyboard.Email;
                        break;
                    case "Numeric":
                        k = Xamarin.Forms.Keyboard.Numeric;
                        break;
                    case "Plain":
                        k = Xamarin.Forms.Keyboard.Plain;
                        break;
                    case "Telephone":
                        k = Xamarin.Forms.Keyboard.Telephone;
                        break;
                    case "Text":
                        k = Xamarin.Forms.Keyboard.Text;
                        break;
                    case "Url":
                        k = Xamarin.Forms.Keyboard.Url;
                        break;
                    default:
                        k = Xamarin.Forms.Keyboard.Default;
                        break;
                }

                _entry.Keyboard = k;
            }
        }
        #endregion
    }
}
