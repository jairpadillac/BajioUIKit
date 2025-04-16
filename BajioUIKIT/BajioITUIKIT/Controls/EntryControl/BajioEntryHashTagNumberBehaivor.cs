using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioEntryHashTagNumberBehaivor : Behavior<Entry>
    {
		#region Public Properties
        /// <summary>
        /// The entry max length property.
        /// </summary>
        public static readonly BindableProperty EntryMaxLengthProperty =
			BindableProperty.Create(nameof(EntryMaxLength), typeof(int), typeof(BajioEntryHashTagNumberBehaivor), 0, BindingMode.TwoWay);

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
				bindable.Text = string.Format("#");
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
            if (e.OldTextValue == e.NewTextValue)
			{
				return;
			}

            if (e.NewTextValue == null)
			{
				return;
			}

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

			if(val.Length == 0)
			{
				val = "#";
			}

			entry.Text = val;

        }
        #endregion
    }
}
