using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BoxViewRounded : BoxView
    {
        //Create a Bindable Property For CornerRadius  
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(BoxViewRounded), 0.0);
        public double CornerRadius
        {
            get
            {
                return (double)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }
    }
}
