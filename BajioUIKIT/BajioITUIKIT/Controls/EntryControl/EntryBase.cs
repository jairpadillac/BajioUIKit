using System;
using System.Windows.Input;
using BajioITUIKIT.Enums;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    /// <summary>
    /// Entry base to fix xamarin renderer issues
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Entry" />
    public class EntryBase : Entry
    {
        #region custom keyboard
        /// <summary>
        /// The next view property.
        /// </summary>
        public static readonly BindableProperty NextViewProperty = BindableProperty.Create("NextView", typeof(View), typeof(EntryBase));

        /// <summary>
        /// Gets or sets the next view.
        /// </summary>
        /// <value>The next view.</value>
		public View NextView
        {
            get { return (View)GetValue(NextViewProperty); }
            set { SetValue(NextViewProperty, value); }
        }


        /// <summary>
        /// The should invoke action property.
        /// </summary>
        public static readonly BindableProperty ShouldInvokeActionProperty = BindableProperty.Create(propertyName: nameof(ShouldInvokeAction), returnType: typeof(bool),
                declaringType: typeof(EntryBase), defaultValue: false);

        /// <summary>
        /// Command Property that occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public static readonly BindableProperty ReturnCommandProperty =
            BindableProperty.Create(nameof(ReturnCommand), typeof(ICommand), typeof(EntryBase), null);

        /// <summary>
        /// Return Type Property of the Entry
        /// </summary>
        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(propertyName: nameof(ReturnType),
                returnType: typeof(ReturnTypeKeyboard),
                declaringType: typeof(EntryBase),
                defaultValue: ReturnTypeKeyboard.Done);

        /// <summary>
        /// Type of the Keyboard Return Key
        /// </summary>
        public ReturnTypeKeyboard ReturnType
        {
            get { return (ReturnTypeKeyboard)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.EntryBase"/>
        /// should invoke action.
        /// </summary>
        /// <value><c>true</c> if should invoke action; otherwise, <c>false</c>.</value>
        public bool ShouldInvokeAction
        {
            get { return (bool)GetValue(ShouldInvokeActionProperty); }
            set { SetValue(ShouldInvokeActionProperty, value); }
        }


        /// <summary>
        /// Occurs when the user finalizes the text in an entry with the return key
        /// </summary>
        public ICommand ReturnCommand
        {
            get { return (ICommand)GetValue(ReturnCommandProperty); }
            set { SetValue(ReturnCommandProperty, value); }
        }

        /// <summary>
        /// Invokes the completed.
        /// </summary>
		public void InvokeCompleted()
        {
            if (this.Completed != null)
                this.Completed.Invoke(this, null);
        }

        /// <summary>
        /// Ons the next.
        /// </summary>
        public void OnNext()
        {
            NextView?.Focus();
            if (this.NextViewCompleted != null)
                this.NextViewCompleted.Invoke(this, null);
        }

        /// <summary>
        /// Occurs when next view completed.
        /// </summary>
        public event EventHandler NextViewCompleted;

        /// <summary>
        /// Occurs when completed.
        /// </summary>
        public new event EventHandler Completed;

        #endregion

        #region Public Methods
        /// <summary>
        /// Gets or sets the color of the custom text.
        /// </summary>
        /// <value>The color of the custom text.</value>
        public Color CustomTextColor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryBase"/> class.
        /// </summary>
        public EntryBase()
        {
            CustomTextColor = Theme.TextColorSecondary;
            FontSize = 12;
        }
        #region Backspace Event
        /// <summary>
        /// Backspace event handler.
        /// </summary>
        public delegate void BackspaceEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Occurs when on backspace.
        /// </summary>
        public event BackspaceEventHandler OnBackspace;

        /// <summary>
        /// Ons the backspace pressed.
        /// </summary>
        public void OnBackspacePressed()
        {
            OnBackspace?.Invoke(this, null);
        }
        #endregion
        #endregion
    }
}
