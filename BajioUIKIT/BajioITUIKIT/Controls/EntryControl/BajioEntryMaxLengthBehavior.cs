using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    /// <summary>
    /// Bajio entry max length behavior.
    /// </summary>
    public class BajioEntryMaxLengthBehavior : Behavior<Entry>
    {
        #region Public Properties
        /// <summary>
        /// The max length property.
        /// </summary>
        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(BajioEntryMaxLengthBehavior), 0);

        /// <summary>
        /// Gets or sets the length of the max.
        /// </summary>
        /// <value>The length of the max.</value>
        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
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
                bindable.TextChanged += Bindable_TextChanged;
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
            }
        }

        /// <summary>
        /// Bindables the text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null)
                return;

            if (e.NewTextValue.Length >= MaxLength)
                ((Entry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
        }
        #endregion
    }
}
