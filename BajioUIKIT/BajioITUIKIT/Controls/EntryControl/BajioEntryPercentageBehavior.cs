using System;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    /// <summary>
    /// Bajio entry currency behavior.
    /// </summary>
    public class BajioEntryPercentageBehavior : Behavior<Entry>
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        /// <value>The currency symbol.</value>
        public string PercentageSymbol { get; set; }

        /// <summary>
        /// The text property.
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(BajioEntryCurrencyBehavior), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// The edit value property.
        /// </summary>
        public static readonly BindableProperty EditValueProperty =
            BindableProperty.Create(nameof(EditValue), typeof(double), typeof(BajioEntryCurrencyBehavior), double.MinValue, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the edit value.
        /// </summary>
        /// <value>The edit value.</value>
        public double EditValue
        {
            get { return (double)GetValue(EditValueProperty); }
            set { SetValue(EditValueProperty, value); }
        }

        /// <summary>
        /// The decimal postions property.
        /// </summary>
        public static readonly BindableProperty DecimalPostionsProperty =
            BindableProperty.Create(nameof(DecimalPostions), typeof(int), typeof(BajioEntryCurrencyBehavior), 0);

        /// <summary>
        /// Gets or sets the decimal postions.
        /// </summary>
        /// <value>The decimal postions.</value>
        public int DecimalPostions
        {
            get { return (int)GetValue(DecimalPostionsProperty); }
            set { SetValue(DecimalPostionsProperty, value); }
        }

        /// <summary>
        /// The max length property.
        /// </summary>
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(BajioEntryCurrencyBehavior), 10, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the length of the max.
        /// </summary>
        /// <value>The length of the max.</value>
        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        /// <summary>
        /// The back value property.
        /// </summary>
        public static readonly BindableProperty BackValueProperty =
            BindableProperty.Create(nameof(BackValue), typeof(string), typeof(BajioEntryCurrencyBehavior), "0");

        /// <summary>
        /// Gets or sets the back value.
        /// </summary>
        /// <value>The back value.</value>
        public string BackValue
        {
            get { return (string)GetValue(BackValueProperty); }
            set { SetValue(BackValueProperty, value); }
        }

        #endregion

        #region Private Properties
        private double _initValue;
        private string _oldTextValue;
        private string _newTextValue;
        private bool _isTextEditing;
        private double _numValue;
        private string _numValueString;
        private int _integerPart;
        private string _decimalPart;
        private bool _parsedDecimal;
        private string _decimalFormat;
        private bool _isPercentageFocused;
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        /// <summary>
        /// Ons the attached to.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        protected override void OnAttachedTo(Entry bindable)
        {
            if (bindable != null)
            {
                base.OnAttachedTo(bindable);
                bindable.TextChanged += Bindable_TextChanged;
                bindable.Unfocused += Bindable_Unfocused;
                bindable.Focused += Bindable_Focused;
                _initValue = 0;
                _decimalFormat = "{0:###,###,##0." + "".PadRight(DecimalPostions, '0') + "}";
            }
        }

        /// <summary>
        /// Ons the detaching from.
        /// </summary>
        /// <param name="bindable">Bindable.</param>
        protected override void OnDetachingFrom(Entry bindable)
        {
            if (bindable != null)
            {
                base.OnDetachingFrom(bindable);
                bindable.TextChanged -= Bindable_TextChanged;
                bindable.Unfocused -= Bindable_Unfocused;
                bindable.Focused -= Bindable_Focused;
            }
        }

        /// <summary>
        /// Bindables the focused.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Bindable_Focused(object sender, FocusEventArgs e)
        {
            _isPercentageFocused = true;
            if (((Entry)sender).Text == $"{string.Format(_decimalFormat, _initValue)}{PercentageSymbol}")
            {
                ((Entry)sender).Text = "";
            }
            else
            {
                ((Entry)sender).Text = ((Entry)sender).Text.Replace(PercentageSymbol, string.Empty);
            }
            _isTextEditing = false;
        }

        /// <summary>
        /// Formats the decimals.
        /// </summary>
        private void FormatDecimals()
        {
            Text = $"{string.Format(_decimalFormat, EditValue)}{PercentageSymbol}";
        }

        /// <summary>
        /// Bindables the unfocused.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            _isPercentageFocused = false;
            FormatDecimals();
        }

        /// <summary>
        /// Bindables the text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (_isTextEditing)
                {
                    _isTextEditing = false;
                    return;
                }

                if (e.OldTextValue == e.NewTextValue)
                {
                    return;
                }

                _oldTextValue = e.OldTextValue;
                _newTextValue = e.NewTextValue;

                if (!_isPercentageFocused)
                    return;

                _numValueString = string.IsNullOrEmpty(_newTextValue.Replace(PercentageSymbol, string.Empty).Replace(",", string.Empty))
                          || (_newTextValue.Replace(PercentageSymbol, string.Empty) == ".") ? "0" :
                                       (_newTextValue.LastIndexOf(".") == _newTextValue.Length - 1 ? _newTextValue.Replace(PercentageSymbol, string.Empty).Replace(".", string.Empty) : _newTextValue.Replace(PercentageSymbol, string.Empty).Replace(",", string.Empty));

                _parsedDecimal = double.TryParse(_numValueString, out _numValue);

                _integerPart = (int)Math.Abs(_numValue);

                _decimalPart = _parsedDecimal ?
                    (_numValueString.Contains(".") ?
                     _numValueString.Substring(_numValueString.LastIndexOf(".") + 1, _numValueString.Length - (_numValueString.LastIndexOf(".") + 1)) : "0") : "0";

                if ((!_parsedDecimal)
                    || _newTextValue.Split('.').Length - 1 > 1
                    || (DecimalPostions > 0 && _integerPart.ToString().Length > MaxLength)
                    || (DecimalPostions > 0 && _newTextValue.Contains(".") && _decimalPart.Length > DecimalPostions)
                    || (DecimalPostions == 0 && _newTextValue.Contains("."))
                   )
                {
                    _isTextEditing = true;
                    ((Entry)sender).Text = _oldTextValue;
                    return;
                }
                if (((Entry)sender).Text == $".{PercentageSymbol}" || ((Entry)sender).Text == $".")
                {
                    _isTextEditing = true;
                    ((Entry)sender).Text = ((Entry)sender).IsFocused ? $"0" : $"0{PercentageSymbol}";
                }

                if (!((Entry)sender).Text.Contains(PercentageSymbol) && !_isPercentageFocused)
                {
                    _isTextEditing = true;
                    ((Entry)sender).Text = $"{string.Format(_decimalFormat, ((Entry)sender).Text)}{PercentageSymbol}";
                }

                EditValue = string.IsNullOrEmpty(((Entry)sender).Text.Replace(PercentageSymbol, string.Empty))
                                  || ((Entry)sender).Text.Replace(PercentageSymbol, string.Empty) == "." ?
                                  0 :
                                  double.Parse(((Entry)sender).Text.Replace(PercentageSymbol, string.Empty));
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion
    }
}
