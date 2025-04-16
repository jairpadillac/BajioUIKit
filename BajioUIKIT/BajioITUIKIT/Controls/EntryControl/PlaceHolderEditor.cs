using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class PlaceholderEditor : Editor
    {
        /// <summary>
        /// The placholder property
        /// </summary>
        public static readonly BindableProperty CustomPlaceholderProperty = BindableProperty.Create(nameof(CustomPlaceholder),
            typeof(string), typeof(BajioCustomEditor), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string CustomPlaceholder
        {
            get { return (string)GetValue(CustomPlaceholderProperty); }
            set { SetValue(CustomPlaceholderProperty, value); }

        }
    }
}