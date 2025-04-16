using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    /// <summary>
    /// Bajio entry currency converter.
    /// </summary>
    public class BajioEntryCurrencyConverter : Behavior<Entry>, IValueConverter
    {
        #region Public Properties
        /// <summary>
        /// The max length property.
        /// </summary>
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(BajioEntryCurrencyConverter), 0);

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
        /// The decimal postions property.
        /// </summary>
        public static readonly BindableProperty DecimalPostionsProperty =
            BindableProperty.Create(nameof(DecimalPostions), typeof(int), typeof(BajioEntryCurrencyConverter), 0);

        /// <summary>
        /// Gets or sets the decimal postions.
        /// </summary>
        /// <value>The decimal postions.</value>
        public int DecimalPostions
        {
            get { return (int)GetValue(DecimalPostionsProperty); }
            set { SetValue(DecimalPostionsProperty, value); }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Convert the specified value, targetType, parameter and culture.
        /// </summary>
        /// <returns>The convert.</returns>
        /// <param name="value">Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (MaxLength != 0 && value.ToString().Length >= MaxLength)
                value = value.ToString().Substring(0, MaxLength);

            return Decimal.Parse(value.ToString()).ToString("C2");
        }

        /// <summary>
        /// Converts the back.
        /// </summary>
        /// <returns>The back.</returns>
        /// <param name="value">Value.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

            if (valueFromString.Length <= 0)
                return 0m;

            long valueLong;
            if (!long.TryParse(valueFromString, out valueLong))
                return 0m;

            if (valueLong <= 0)
                return 0m;

            return valueLong / 100m;
        }
        #endregion
    }
}
