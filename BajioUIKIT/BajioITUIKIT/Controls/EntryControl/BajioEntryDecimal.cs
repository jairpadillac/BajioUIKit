using System;
using System.Runtime.CompilerServices;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioEntryDecimal : BajioEntryBase
    {
        #region Private Properties

        /// <summary>
        /// Editing flag to avoid loop on text change.
        /// </summary>
        private bool _editingValue = false;

        /// <summary>
        /// The entry
        /// </summary>
        private EntryBase _entry = new EntryBase()
        {
            Margin = new Thickness(0, 6, 0, 0),
            TextColor = Theme.TextColorSecondary,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.Center,
            Keyboard = Keyboard.Numeric,
            Text = "$0.00"
        };
        /// <summary>
        /// The entry container
        /// </summary>
        private StackLayout _entryContainer = new StackLayout()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Orientation = StackOrientation.Horizontal,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Spacing = 0
        };
        /// <summary>
        /// The description 
        /// </summary>
        private Label _description;
        #endregion

        #region Public Properties
        /// <summary>
        /// The value property
        /// </summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value),
            typeof(decimal), typeof(BajioEntryDecimal), default(decimal), BindingMode.TwoWay);

        /// <summary>
        /// The description property
        /// </summary>
        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description),
            typeof(string), typeof(BajioEntryDecimal), default(string), BindingMode.TwoWay);

        /// <summary>
        /// The size property
        /// </summary>
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size),
            typeof(double), typeof(BajioEntryDecimal), default(double), BindingMode.TwoWay);

        /// <summary>
        /// The color property
        /// </summary>
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color),
            typeof(Color), typeof(BajioEntryDecimal), default(Color), BindingMode.TwoWay);

        /// <summary>
        /// The alignment property
        /// </summary>
        public static readonly BindableProperty AlignmentProperty = BindableProperty.Create(nameof(Alignment),
            typeof(TextAlignment), typeof(BajioEntryDecimal), TextAlignment.Start, BindingMode.TwoWay);

        /// <summary>
        /// The is border displayed property
        /// </summary>
        public static readonly BindableProperty IsBorderDisplayedProperty = BindableProperty.Create(nameof(IsBorderDisplayed),
            typeof(bool), typeof(BajioEntryDecimal), true, BindingMode.TwoWay);

        /// <summary>
        /// The touched property
        /// </summary>
        public static readonly BindableProperty TouchedProperty = BindableProperty.Create(nameof(Touched),
            typeof(bool), typeof(BajioEntryDecimal), false, BindingMode.TwoWay);

        /// <summary>
        /// Bindable Value for decimal entry.
        /// </summary>
        public decimal Value
        {
            get
            {
                return (decimal)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        /// <summary>
        /// Bindable Description for decimal entry.
        /// </summary>
        public string Description
        {
            get
            {
                return (string)GetValue(DescriptionProperty);
            }
            set
            {
                SetValue(DescriptionProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public double Size
        {
            get
            {
                return (double)GetValue(SizeProperty);
            }
            set
            {
                SetValue(SizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public Color Color
        {
            get
            {
                return (Color)GetValue(ColorProperty);
            }
            set
            {
                SetValue(ColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        /// <value>
        /// The alignment.
        /// </value>
        public TextAlignment Alignment
        {
            get
            {
                return (TextAlignment)GetValue(AlignmentProperty);
            }
            set
            {
                SetValue(AlignmentProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is border displayed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is border displayed; otherwise, <c>false</c>.
        /// </value>
        public bool IsBorderDisplayed
        {
            get
            {
                return (bool)GetValue(IsBorderDisplayedProperty);
            }
            set
            {
                SetValue(IsBorderDisplayedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BajioEntryDecimal"/> is touched.
        /// </summary>
        /// <value>
        ///   <c>true</c> if touched; otherwise, <c>false</c>.
        /// </value>
        public bool Touched
        {
            get
            {
                return (bool)GetValue(TouchedProperty);
            }
            set
            {
                SetValue(TouchedProperty, value);
            }
        }

        /// <summary>
        /// The maximum length bajio entry property
        /// </summary>
        public static readonly BindableProperty MaxLengthBajioEntryProperty = BindableProperty.Create("MaxLengthBajioEntry",
        typeof(int), typeof(BajioEntry), 255, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets the maximum length bajio entry.
        /// </summary>
        /// <value>
        /// The maximum length bajio entry.
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
            typeof(bool), typeof(BajioEntryDecimal), false, BindingMode.TwoWay);

        /// <summary>
        /// Enabled Property
        /// </summary>
        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }


        /// <summary>
        /// The container for base entry.
        /// </summary>
        public BajioEntryBaseContainer Container = new BajioEntryBaseContainer();
        #endregion

        #region Public Methods 
        /// <summary>
        /// Initializes a new instance of the <see cref="BajioEntryDecimal"/> class.
        /// </summary>
        public BajioEntryDecimal()
        {
            _entry.TextChanged += ValueChanged;
            _entry.Focused += (sender, e) =>
            {
                Touched = true;
            };

            _description = new Label()
            {
                Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
                TextColor = Theme.TextColorSecondary,
                FontSize = 10,
                IsVisible = false,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };


            _entryContainer.Padding = new Thickness(10, 0, 0, 0);
            _entryContainer.Children.Add(_entry);
            _entryContainer.Children.Add(_description);

            // Use container to wrap with border
            Container.Children.Add(_entryContainer);
        }
        #endregion

        #region Private Methods 
        /// <summary>
        /// Values the changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void ValueChanged(object sender, TextChangedEventArgs e)
        {
            if (_editingValue)
            {
                _editingValue = false;
                return;
            }

            _editingValue = true;

            string val = e.NewTextValue.TrimStart('$');

            decimal numValue = 0;
            bool parsed = decimal.TryParse(val, out numValue);
            if (parsed)
            {
                // Move dot to next position
                if (e.OldTextValue.Length < e.NewTextValue.Length)
                {
                    // Move dot to the right
                    Value = numValue * 10;
                }
                else
                {
                    // Move dot to the left
                    Value = numValue / 10;
                }

            }
            else
            {
                Value = numValue;
            }

            ((Entry)sender).Text = Value.ToString("C");
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

            if (propertyName == DescriptionProperty.PropertyName)
            {
                if (Description != "")
                {
                    _description.IsVisible = true;
                    _description.Text = Description;
                }
                else
                {
                    _description.IsVisible = false;
                    _description.Text = "";
                }
            }

            if (propertyName == ValueProperty.PropertyName)
            {
                UpdateValue();
            }

            if (propertyName == ColorProperty.PropertyName)
            {
                if (Color != default(Color))
                {
                    _entry.CustomTextColor = Color;
                }
                else
                {
                    _entry.CustomTextColor = Theme.TextColorSecondary;
                }
            }

            if (propertyName == SizeProperty.PropertyName)
            {
                if (Size != default(double))
                {
                    _entry.FontSize = Size;
                }
            }

            if (propertyName == AlignmentProperty.PropertyName)
            {
                _entry.HorizontalTextAlignment = Alignment;

            }

            if (propertyName == IsBorderDisplayedProperty.PropertyName)
            {
                this.Container.IsBorderDisplayed = IsBorderDisplayed;
            }
            if (propertyName == MaxLengthBajioEntryProperty.PropertyName)
            {
                _entry.Behaviors.Add(new BajioEntryMaxLengthBehavior { MaxLength = MaxLengthBajioEntry });
            }
        }

        /// <summary>
        /// Updates the entry value on binding change.
        /// </summary>
        private void UpdateValue()
        {
            _editingValue = true;
            _entry.Text = Value.ToString("C");
        }
        #endregion
    }
}