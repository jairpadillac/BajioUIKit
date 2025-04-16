using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioEntryBaseContainer : StackLayout
    {
        #region Public Properties
        /// <summary>
        /// The is border displayed property
        /// </summary>
        public static readonly BindableProperty IsBorderDisplayedProperty = BindableProperty.Create(nameof(IsBorderDisplayed),
            typeof(bool), typeof(BajioEntryBase), true, BindingMode.TwoWay);

        /// <summary>
        /// The enabled property
        /// </summary>
        public static readonly BindableProperty EnabledProperty = BindableProperty.Create(nameof(Enabled),
            typeof(bool), typeof(BajioEntryBase), true, BindingMode.TwoWay);

        /// <summary>
        /// The error property
        /// </summary>
        public static readonly BindableProperty ErrorProperty = BindableProperty.Create(nameof(Error),
            typeof(bool), typeof(BajioEntryBase), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this instance is border displayed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is border displayed; otherwise, <c>false</c>.
        /// </value>
        public bool IsBorderDisplayed
        {
            get { return (bool)GetValue(IsBorderDisplayedProperty); }
            set { SetValue(IsBorderDisplayedProperty, value); }
        }

        /// <summary>
        /// Enabled property to handle styles
        /// </summary>
        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BajioEntryBaseContainer"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        public bool Error
        {
            get { return (bool)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Initializes a new instance of the <see cref="BajioEntryBaseContainer"/> class.
        /// </summary>
        public BajioEntryBaseContainer()
        {
            Spacing = 0;
            HeightRequest = 50;
        }
        #endregion
    }
}

