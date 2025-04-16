using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioSwitch : Xamarin.Forms.Switch
    {
        #region Public Properties

        /// <summary>
        ///     Identifies the Switch tint color bindable property.
        /// </summary>
        public static readonly BindableProperty TintColorProperty =
            BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(BajioSwitch), Color.Black, BindingMode.TwoWay);

        /// <summary>
        ///     Gets or sets the color of the tint.
        /// </summary>
        /// <value>The color of the tint.</value>
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        /// <summary>
        ///     Identifies the Switch inactive color bindable property.
        /// </summary>
        public static readonly BindableProperty InactiveColorProperty =
            BindableProperty.Create(nameof(InactiveColor), typeof(Color), typeof(BajioSwitch), Theme.InactiveColor, BindingMode.TwoWay);

        /// <summary>
        ///     Gets or sets the color of the inactive state.
        /// </summary>
        /// <value>The color of the inactive state.</value>
        public Color InactiveColor
        {
            get { return (Color)GetValue(InactiveColorProperty); }
            set { SetValue(InactiveColorProperty, value); }
        }
        #endregion

        #region Private Properties
        #endregion

        #region Public Methods
        #endregion

        #region Protected Methods
        #endregion

        #region Private Methods
        #endregion
    }
}

