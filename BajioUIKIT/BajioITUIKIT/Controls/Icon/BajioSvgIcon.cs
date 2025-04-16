using System;
using System.Runtime.CompilerServices;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioSvgIcon : StackLayout
    {
        #region Private Properties
        /// <summary>
        /// The image source converter
        /// </summary>
        private readonly ImageSourceConverter _imageSourceConverter = new ImageSourceConverter();

        /// <summary>
        /// The SVG icon image
        /// </summary>
        private readonly SvgCachedImage _svgIconImage = new SvgCachedImage()
        {
            WidthRequest = 22,
            HeightRequest = 22,
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(0, 2, 0, 6)
        };
        #endregion

        #region Public Properties
        /// <summary>
        /// The image frame
        /// </summary>
        public BoxView imageFrame = new BoxView
        {
            WidthRequest = 22,
            HeightRequest = 22,
            Margin = new Thickness(0, 2, 0, 6)
        };
        /// <summary>
        /// The icon property
        /// </summary>
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(BajioSvgIcon), string.Empty, BindingMode.OneWay);

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuIcon" /> class.
        /// </summary>
        public BajioSvgIcon()
        {

            var relativeLayout = new RelativeLayout();

            relativeLayout.Children.Add(_svgIconImage,
                Constraint.RelativeToParent((parent) => (parent.Width / 2) - 12),
                Constraint.RelativeToParent((parent) => parent.Y));

            relativeLayout.Children.Add(imageFrame,
                Constraint.RelativeToParent((parent) => (parent.Width / 2) - 12),
                Constraint.RelativeToParent((parent) => parent.Y));

            Children.Add(relativeLayout);
            HorizontalOptions = LayoutOptions.CenterAndExpand;
            Margin = new Thickness(0, 0, 0, 0);
            Spacing = 0;
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
            if (propertyName == IconProperty.PropertyName)
            {
                UpdateIcon();
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Updates the icon.
        /// </summary>
        private void UpdateIcon()
        {
            var xfSource = _imageSourceConverter.ConvertFromInvariantString(Icon) as ImageSource;
            _svgIconImage.Source = new SvgImageSource(xfSource, 0, 0, true);
        }

        #endregion
    }
}

