using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class MaxLengthValidator : Behavior<Entry>
    {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += _bindableTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= _bindableTextChanged;
        }

        private void _bindableTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                if (e.NewTextValue.Length > 0 && e.NewTextValue.Length > MaxLength)
                {
                    ((Entry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
                }
            }
        }
    }

    /// <summary>
    /// Max length validator for editors.
    /// </summary>
    public class MaxLengthValidatorEditor : Behavior<Editor>
    {
        public int MaxLength { get; set; }

        protected override void OnAttachedTo(Editor bindable)
        {
            bindable.TextChanged += _bindableTextChanged;
        }

        protected override void OnDetachingFrom(Editor bindable)
        {
            bindable.TextChanged -= _bindableTextChanged;
        }

        private void _bindableTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                if (e.NewTextValue.Length > 0 && e.NewTextValue.Length > MaxLength)
                {
                    ((Editor)sender).Text = e.NewTextValue.Substring(0, MaxLength);
                }
            }
        }
    }
}
