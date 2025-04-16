using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioCustomEditor : RoundedCornerView
    {
        #region private properties
        /// <summary>
        /// The error message label
        /// </summary>
        private Label _errorMessageLabel = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            HorizontalOptions = LayoutOptions.StartAndExpand,
            TextColor = Theme.InvalidColorPrimary,
            FontSize = 12
        };

        /// <summary>
        /// The entry
        /// </summary>
        private PlaceholderEditor _entry = new PlaceholderEditor()
        {
            FontSize = 14,
            Margin = new Thickness(5, 0, 5, 0),
            TextColor = Color.Black,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            Keyboard = Xamarin.Forms.Keyboard.Text,
            PlaceholderColor = Theme.TextColorThird,
            BackgroundColor = Color.White
        };
        #endregion

        #region public properties
        /// <summary>
        /// The font size property
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize),
            typeof(double), typeof(BajioCustomEditor), 12d, BindingMode.TwoWay);
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
        /// The placholder property
        /// </summary>
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder),
            typeof(string), typeof(BajioCustomEditor), string.Empty, BindingMode.TwoWay);

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
        /// The show border property
        /// </summary>
        public static readonly BindableProperty MaxLenghtProperty = BindableProperty.Create(nameof(MaxLenght),
            typeof(int), typeof(BajioCustomEditor), -1, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the show border value.
        /// </summary>
        /// <value>
        /// The sow border value.
        /// </value>
        public int MaxLenght
        {
            get
            {
                return (int)GetValue(MaxLenghtProperty);
            }
            set
            {
                SetValue(MaxLenghtProperty, value);
            }
        }

        /// <summary>
        /// The remaining text property.
        /// </summary>
        public static readonly BindableProperty RemainingTextProperty = BindableProperty.Create(nameof(RemainingText),
            typeof(string), typeof(BajioEntryBase), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the remaining text.
        /// </summary>
        /// <value>The remaining text.</value>
        public string RemainingText
        {
            get
            {
                return (string)GetValue(RemainingTextProperty);
            }
            set
            {
                SetValue(RemainingTextProperty, value);
            }
        }

        /// <summary>
        /// The value property
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value),
            typeof(string), typeof(BajioCustomEditor), string.Empty, BindingMode.TwoWay);

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
        /// The clear command property
        /// </summary>
        public static readonly BindableProperty ClearCommandProperty = BindableProperty.Create(nameof(ClearCommand),
            typeof(ICommand), typeof(BajioCustomEditor), null, BindingMode.TwoWay);

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
        /// ClickedIconParameter property to bind in the element
        /// </summary>
        public static readonly BindableProperty ClearCommandParameterProperty = BindableProperty.Create(nameof(ClearCommandParameter),
            typeof(object), typeof(BajioCustomEditor), null, BindingMode.TwoWay);

        /// <summary>
        /// ClickedIconParameter property
        /// </summary>
        public object ClearCommandParameter
        {
            get { return GetValue(ClearCommandParameterProperty); }
            set
            {
                SetValue(ClearCommandParameterProperty, value);
            }
        }

        /// <summary>
        /// The clear button visible property
        /// </summary>
        public static readonly BindableProperty ClearButtonVisibleProperty = BindableProperty.Create(nameof(ClearButtonVisible),
            typeof(bool), typeof(BajioCustomEditor), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether [clear button visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [clear button visible]; otherwise, <c>false</c>.
        /// </value>
        public bool ClearButtonVisible
        {
            get { return !string.IsNullOrEmpty(Value) || !ClearButtonEnable && (bool)GetValue(ClearButtonVisibleProperty); }
            set { SetValue(ClearButtonVisibleProperty, value); }
        }

        /// <summary>
        /// The clear button enable property
        /// </summary>
        public static readonly BindableProperty ClearButtonEnableProperty = BindableProperty.Create(nameof(ClearButtonEnable),
            typeof(bool), typeof(BajioCustomEditor), false, BindingMode.TwoWay);

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
        /// TextChanged Command property
        /// </summary>
        public static readonly BindableProperty TextChangedCommandProperty = BindableProperty.Create(nameof(TextChangedCommand),
            typeof(Command), typeof(BajioCustomEditor), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the textchanged command.
        /// </summary>
        public Command TextChangedCommand
        {
            get { return (Command)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        /// <summary>
        /// Unfocused Command property
        /// </summary>
        public static readonly BindableProperty UnfocusedCommandProperty = BindableProperty.Create(nameof(UnfocusedCommand),
            typeof(Command), typeof(BajioCustomEditor), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the unfocused command.
        /// </summary>
        public Command UnfocusedCommand
        {
            get { return (Command)GetValue(UnfocusedCommandProperty); }
            set { SetValue(UnfocusedCommandProperty, value); }
        }

        /// <summary>
        /// The parent scroll property
        /// </summary>
        public static readonly BindableProperty ParentScrollProperty = BindableProperty.Create(nameof(ParentScroll),
        typeof(ScrollView), typeof(BajioCustomEditor), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the size of the parent scroll.
        /// </summary>
        /// <value>
        /// The ParentScroll
        /// </value>
        public ScrollView ParentScroll
        {
            get { return (ScrollView)GetValue(ParentScrollProperty); }
            set { SetValue(ParentScrollProperty, value); }
        }

        /// <summary>
        /// The keyboard property
        /// </summary>
        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard),
            typeof(string), typeof(BajioCustomEditor), "Default", BindingMode.TwoWay);

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
        #endregion

        #region public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BajioCustomEditor"/> class.
        /// </summary>
        public BajioCustomEditor()
        {
            _entry.BindingContext = this;
            _entry.Focused += OnFocused;
            _entry.Unfocused += Unfocused;
            _entry.TextChanged += ValueChanged;
            _entry.SetBinding(Editor.FontSizeProperty, nameof(FontSize));
            _entry.SetBinding(Editor.PlaceholderProperty, nameof(Placeholder));
            UpdateKeyboard();
            _entry.TextChanged += (sender, e) =>
            {
                if (MaxLenght != -1)
                {
                    if (_entry.Text != Placeholder)
                    {
                        RemainingText = string.Format("{0}/{1}", _entry.Text.Length, MaxLenght);
                    }
                    else
                    {
                        RemainingText = string.Format("0/{0}", MaxLenght);
                    }
                }
            };
            Children.Add(_entry, 0, 0);
        }
        #endregion

        #region Private Methods 
        /// <summary>
        /// Clears the clicked.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void ClearClicked(object obj)
        {
            Value = string.Empty;
            ClearCommand?.Execute(ClearCommandParameter);

            if (!string.IsNullOrEmpty(Placeholder) && Device.RuntimePlatform == Device.iOS)
            {
                Value = Placeholder;
            }

            OnPropertyChanged(ValueProperty.PropertyName);
            OnPropertyChanged(PlaceholderProperty.PropertyName);
        }
        /// <summary>
        /// Values the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void ValueChanged(object sender, TextChangedEventArgs e)
        {
            Value = ((Editor)sender).Text;
            ClearButtonVisible = ClearButtonEnable && !string.IsNullOrEmpty(Value);
            TextChangedCommand?.Execute(e);
        }

        /// <summary>
        /// This method scrolls to editor position only for iOS
        /// because it is a knownissue
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FocusEventArgs"/> instance containing the event data.</param>
        private async void OnFocused(object sender, FocusEventArgs e)
        {
            if (ParentScroll == null || Device.RuntimePlatform != Device.iOS)
            {
                return;
            }

            await ParentScroll.ScrollToAsync(this._entry, ScrollToPosition.Start, true);
        }

        /// <summary>
        /// Method that is launched when entry is unfocused
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void Unfocused(object sender, FocusEventArgs e)
        {
            UnfocusedCommand?.Execute(null);
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
            if (!string.IsNullOrEmpty(Keyboard))
            {
                Keyboard k = null;

                switch (Keyboard)
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
            if (propertyName == ValueProperty.PropertyName)
            {
                UpdateValue();
            }

            if (propertyName == KeyboardProperty.PropertyName)
            {
                UpdateKeyboard();
            }

            if (propertyName == MaxLenghtProperty.PropertyName)
            {
                if (MaxLenght > 0)
                {
                    HeightRequest = 100;

                    _entry.Behaviors.Add(new MaxLengthValidatorEditor { MaxLength = MaxLenght });

                    if (_entry.Text != Placeholder)
                    {
                        if (!string.IsNullOrEmpty(_entry.Text))
                        {
                            RemainingText = string.Format("{0}/{1}", _entry.Text.Length, MaxLenght);
                        }
                        else
                        {
                            RemainingText = string.Format("0/{0}", MaxLenght);
                        }

                    }
                    else
                    {
                        RemainingText = string.Format("0/{0}", MaxLenght);
                    }
                }
                else
                {
                    RemainingText = string.Empty;
                }
            }

        }
        #endregion
    }
}
