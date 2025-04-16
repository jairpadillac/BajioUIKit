using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    /// <summary>
    /// Bajio entry number behavior.
    /// </summary>
    public class BajioEntryNumberBehavior : Behavior<Entry>
    {
        #region Public Properties
        /// <summary>
        /// The entry max length property.
        /// </summary>
        public static readonly BindableProperty EntryMaxLengthProperty =
            BindableProperty.Create(nameof(EntryMaxLength), typeof(int), typeof(BajioEntryNumberBehavior), 0, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the length of the entry max.
        /// </summary>
        /// <value>The length of the entry max.</value>
        public int EntryMaxLength
        {
            get { return (int)GetValue(EntryMaxLengthProperty); }
            set { SetValue(EntryMaxLengthProperty, value); }
        }
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
                bindable.TextChanged += OnEntryTextChanged;

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
                bindable.TextChanged -= OnEntryTextChanged;
            }
        }

        /// <summary>
        /// Ons the entry text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.OldTextValue == e.NewTextValue) return;

            if (e.NewTextValue == null) return;

            string val = e.NewTextValue;

            if (val != null && val.Contains("."))
            {
                val = e.OldTextValue;
            }

            var entry = (Entry)sender;

            if (EntryMaxLength != 0 && val.Length > EntryMaxLength)
            {
                val = val.Remove(val.Length - 1); // remove last char
            }

            int numValue;
            bool parsed = int.TryParse(val, out numValue);

            if (parsed)
            {
                entry.Text = numValue.ToString();
            }
            else
            {
                entry.Text = "0";
            }
        }
        #endregion
    }
}
