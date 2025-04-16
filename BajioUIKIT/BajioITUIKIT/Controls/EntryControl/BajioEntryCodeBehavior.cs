using System.Windows.Input;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    /// <summary>
    /// Bajio entry code behavior.
    /// </summary>
    public class BajioEntryCodeBehavior : Behavior<Entry>
    {
        #region Public Properties
        /// <summary>
        /// The entry max length property.
        /// </summary>
        public static readonly BindableProperty EntryMaxLengthProperty =
            BindableProperty.Create(nameof(EntryMaxLength), typeof(int), typeof(BajioEntryCodeBehavior), 0, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the length of the entry max.
        /// </summary>
        /// <value>The length of the entry max.</value>
        public int EntryMaxLength
        {
            get { return (int)GetValue(EntryMaxLengthProperty); }
            set { SetValue(EntryMaxLengthProperty, value); }
        }

        /// <summary>
        /// The return entry command property.
        /// </summary>
        public static readonly BindableProperty ReturnEntryCommandProperty =
            BindableProperty.Create(nameof(ReturnEntryCommand), typeof(object), typeof(BajioEntryCodeBehavior), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the return entry command.
        /// </summary>
        /// <value>The return entry command.</value>
        public ICommand ReturnEntryCommand
        {
            get { return (ICommand)GetValue(ReturnEntryCommandProperty); }
            set { SetValue(ReturnEntryCommandProperty, value); }
        }

        /// <summary>
        /// The next property.
        /// </summary>
        public static readonly BindableProperty NextProperty =
            BindableProperty.Create(nameof(Next), typeof(BajioEntry), typeof(BajioEntryCodeBehavior), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the next.
        /// </summary>
        /// <value>The next.</value>
        public BajioEntry Next
        {
            get { return (BajioEntry)GetValue(NextProperty); }
            set { SetValue(NextProperty, value); }
        }

        /// <summary>
        /// The previous property.
        /// </summary>
        public static readonly BindableProperty PreviousProperty =
            BindableProperty.Create(nameof(Previous), typeof(BajioEntry), typeof(BajioEntryCodeBehavior), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the previous.
        /// </summary>
        /// <value>The previous.</value>
        public BajioEntry Previous
        {
            get { return (BajioEntry)GetValue(PreviousProperty); }
            set { SetValue(PreviousProperty, value); }
        }

        /// <summary>
        /// The text property.
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(BajioEntryCurrencyBehavior), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion

        #region Protected Methods
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
        #endregion

        #region Public Methods
        /// <summary>
        /// Ons the entry text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;

            // Assing to bindable property
            // to spread the text change - notification
            entry.Text = e.NewTextValue;
            // If the entry is filled and next entry is assigned
            // then change focus to next entry
            if (entry.Text.Length == EntryMaxLength && Next != null)
            {
                Next.EntryEditor.Focus();
            }
        }
        #endregion
    }
}
