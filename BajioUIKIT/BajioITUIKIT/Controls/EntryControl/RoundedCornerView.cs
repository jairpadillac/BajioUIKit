using System;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class RoundedCornerView : Grid
    {
        #region Public Properties


        /// <summary>
        /// The fill color property.
        /// </summary>
        public static readonly BindableProperty FillColorProperty =
            BindableProperty.Create<RoundedCornerView, Color>(w => w.FillColor, Color.White);

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        /// <summary>
        /// The rounded corner radius property.
        /// </summary>
        public static readonly BindableProperty RoundedCornerRadiusProperty =
            BindableProperty.Create<RoundedCornerView, double>(w => w.RoundedCornerRadius, 3);

        /// <summary>
        /// Gets or sets the rounded corner radius.
        /// </summary>
        /// <value>The rounded corner radius.</value>
        public double RoundedCornerRadius
        {
            get { return (double)GetValue(RoundedCornerRadiusProperty); }
            set { SetValue(RoundedCornerRadiusProperty, value); }
        }

        /// <summary>
        /// The make circle property.
        /// </summary>
        public static readonly BindableProperty MakeCircleProperty =
            BindableProperty.Create<RoundedCornerView, Boolean>(w => w.MakeCircle, false);

        /// <summary>
        /// Gets or sets a value indicating whether this make circle.
        /// </summary>
        /// <value><c>true</c> if make circle; otherwise, <c>false</c>.</value>
        public Boolean MakeCircle
        {
            get { return (Boolean)GetValue(MakeCircleProperty); }
            set { SetValue(MakeCircleProperty, value); }
        }

        /// <summary>
        /// The border color property.
        /// </summary>
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create<RoundedCornerView, Color>(w => w.BorderColor, Color.Black);

        /// <summary>
        /// Gets or sets the color of the border.
        /// </summary>
        /// <value>The color of the border.</value>
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        /// <summary>
        /// The border width property.
        /// </summary>
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create<RoundedCornerView, int>(w => w.BorderWidth, 1);

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        #endregion
    }
}
