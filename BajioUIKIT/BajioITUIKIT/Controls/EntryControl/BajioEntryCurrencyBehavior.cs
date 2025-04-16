using System;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    /// <summary>
    /// Bajio entry currency behavior.
    /// </summary>
    public class BajioEntryCurrencyBehavior : Behavior<Entry>
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        /// <value>The currency symbol.</value>
        public string CurrencySymbol { get; set; }

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
        private double InitValue;
        private string OldTextValue;
        private string NewTextValue;
        private bool IsTextEditing;
        private double numValue;
        private string numValueString;
        private int integerPart;
        private string decimalPart;
        private bool parsedDecimal;
        private string decimalFormat;
        private bool isFocused;
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
                InitValue = 0;
                decimalFormat = "{0:###,###,##0." + "".PadRight(DecimalPostions, '0') + "}"; //"{0:0.000}"
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
            isFocused = true;
            if (((Entry)sender).Text == $"{CurrencySymbol}{string.Format(decimalFormat, InitValue)}")
            {
                ((Entry)sender).Text = CurrencySymbol;
            }
        }

        /// <summary>
        /// Formats the decimals.
        /// </summary>
        private void FormatDecimals()
        {
            Text = $"{CurrencySymbol}{string.Format(decimalFormat, EditValue)}";
        }

        /// <summary>
        /// Bindables the unfocused.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            FormatDecimals();
            isFocused = false;
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
                if (IsTextEditing)
                {
                    IsTextEditing = false;
                    return;
                }

                if (e.OldTextValue == e.NewTextValue)
                    return;

                OldTextValue = e.OldTextValue;
                NewTextValue = e.NewTextValue;

                if (!isFocused)
                    return;

                numValueString = string.IsNullOrEmpty(NewTextValue.Replace(CurrencySymbol, string.Empty).Replace(",", string.Empty))
                          || (NewTextValue.Replace(CurrencySymbol, string.Empty) == ".") ? "0" :
                                       (NewTextValue.LastIndexOf(".") == NewTextValue.Length - 1 ? NewTextValue.Replace(CurrencySymbol, string.Empty).Replace(".", string.Empty) : NewTextValue.Replace(CurrencySymbol, string.Empty).Replace(",", string.Empty));


                parsedDecimal = double.TryParse(numValueString, out numValue);

                integerPart = (int)Math.Abs(numValue);

                decimalPart = parsedDecimal ?
                    (numValueString.Contains(".") ?
                     numValueString.Substring(numValueString.LastIndexOf(".") + 1, numValueString.Length - (numValueString.LastIndexOf(".") + 1)) : "0")

                    : "0";

                if ((!parsedDecimal)
                    || NewTextValue.Split('.').Length - 1 > 1
                    || (DecimalPostions > 0 && integerPart.ToString().Length > MaxLength)
                    || (DecimalPostions > 0 && NewTextValue.Contains(".") && decimalPart.Length > DecimalPostions)
                    || (DecimalPostions == 0 && NewTextValue.Contains("."))
                   )
                {
                    IsTextEditing = true;
                    ((Entry)sender).Text = OldTextValue;
                    return;
                }
                if (((Entry)sender).Text == $"{CurrencySymbol}.")
                {
                    IsTextEditing = true;
                    ((Entry)sender).Text = $"{CurrencySymbol}0.";
                }
                if (!((Entry)sender).Text.Contains(CurrencySymbol))
                {
                    IsTextEditing = true;
                    ((Entry)sender).Text = $"{CurrencySymbol}{((Entry)sender).Text}";
                }

                EditValue = string.IsNullOrEmpty(((Entry)sender).Text.Replace(CurrencySymbol, string.Empty))
                                  || ((Entry)sender).Text.Replace(CurrencySymbol, string.Empty) == "." ?
                                  0 :
                                  double.Parse(((Entry)sender).Text.Replace(CurrencySymbol, string.Empty));
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion
    }
}
