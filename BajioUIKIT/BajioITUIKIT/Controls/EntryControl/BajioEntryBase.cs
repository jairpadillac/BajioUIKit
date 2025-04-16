using System;
using System.Windows.Input;
using BajioITUIKIT.Enums;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioEntryBase : Entry
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the color of the custom text.
        /// </summary>
        /// <value>The color of the custom text.</value>
        public Color CustomTextColor { get; set; }

        #region Dependency Properties
        /// <summary>
        /// The return type property.
        /// </summary>
        public static readonly new BindableProperty ReturnTypeProperty =
            BindableProperty.Create(nameof(ReturnType), typeof(ReturnTypeKeyboard), typeof(BajioEntryBase), ReturnTypeKeyboard.Done);

        /// <summary>
        /// Gets or sets the type of the return.
        /// </summary>
        /// <value>The type of the return.</value>
        public new ReturnTypeKeyboard ReturnType
        {
            get { return (ReturnTypeKeyboard)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        /// <summary>
        /// The next view property.
        /// </summary>
        public static readonly BindableProperty NextViewProperty =
            BindableProperty.Create(nameof(NextView), typeof(BajioEntry), typeof(BajioEntryBase));

        /// <summary>
        /// Gets or sets the next view.
        /// </summary>
        /// <value>The next view.</value>
        public BajioEntry NextView
        {
            get { return (BajioEntry)GetValue(NextViewProperty); }
            set { SetValue(NextViewProperty, value); }
        }

        /// <summary>
        /// The previous view property.
        /// </summary>
        public static readonly BindableProperty PrevViewProperty =
            BindableProperty.Create(nameof(PrevView), typeof(BajioEntry), typeof(BajioEntryBase));

        /// <summary>
        /// Gets or sets the previous view.
        /// </summary>
        /// <value>The previous view.</value>
        public BajioEntry PrevView
        {
            get { return (BajioEntry)GetValue(PrevViewProperty); }
            set { SetValue(PrevViewProperty, value); }
        }

        /// <summary>
        /// The should invoke action property.
        /// </summary>
        public static readonly BindableProperty ShouldInvokeActionProperty =
            BindableProperty.Create(nameof(ShouldInvokeAction), typeof(bool), typeof(BajioEntryBase), false);

        /// <summary>
        /// Gets or sets a value indicating whether this  should
        /// invoke action.
        /// </summary>
        /// <value><c>true</c> if should invoke action; otherwise, <c>false</c>.</value>
        public bool ShouldInvokeAction
        {
            get { return (bool)GetValue(ShouldInvokeActionProperty); }
            set { SetValue(ShouldInvokeActionProperty, value); }
        }

        /// <summary>
        /// The key board type property.
        /// </summary>
        public static readonly BindableProperty KeyBoardTypeProperty =
            BindableProperty.Create(nameof(KeyBoardType), typeof(EntryKeyBoardType), typeof(BajioEntryBase), EntryKeyBoardType.Text);

        /// <summary>
        /// Gets or sets the type of the key board.
        /// </summary>
        /// <value>The type of the key board.</value>
        public EntryKeyBoardType KeyBoardType
        {
            get { return (EntryKeyBoardType)GetValue(KeyBoardTypeProperty); }
            set { SetValue(KeyBoardTypeProperty, value); }
        }

        /// <summary>
        /// The on complete command property.
        /// </summary>
        public static readonly BindableProperty OnCompleteCommandProperty =
            BindableProperty.Create(nameof(OnCompleteCommand), typeof(ICommand), typeof(BajioBaseControl), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the on complete command.
        /// </summary>
        /// <value>The on complete command.</value>
        public ICommand OnCompleteCommand
        {
            get { return (ICommand)GetValue(OnCompleteCommandProperty); }
            set { SetValue(OnCompleteCommandProperty, value); }
        }

        /// <summary>
        /// The unfocused command property.
        /// </summary>
        public static readonly BindableProperty UnfocusedCommandProperty =
            BindableProperty.Create(nameof(UnfocusedCommand), typeof(ICommand), typeof(BajioBaseControl), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the unfocused command.
        /// </summary>
        /// <value>The unfocused command.</value>
        public ICommand UnfocusedCommand
        {
            get { return (ICommand)GetValue(UnfocusedCommandProperty); }
            set { SetValue(UnfocusedCommandProperty, value); }
        }

        /// <summary>
        /// The onfocused command property.
        /// </summary>
        public static readonly BindableProperty OnfocusedCommandProperty =
            BindableProperty.Create(nameof(OnfocusedCommand), typeof(ICommand), typeof(BajioBaseControl), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the onfocused command.
        /// </summary>
        /// <value>The onfocused command.</value>
        public ICommand OnfocusedCommand
        {
            get { return (ICommand)GetValue(OnfocusedCommandProperty); }
            set { SetValue(OnfocusedCommandProperty, value); }
        }

        /// <summary>
        /// The text changed command property.
        /// </summary>
        public static readonly BindableProperty TextChangedCommandProperty =
            BindableProperty.Create(nameof(TextChangedCommand), typeof(ICommand), typeof(BajioBaseControl), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the text changed command.
        /// </summary>
        /// <value>The text changed command.</value>
        public ICommand TextChangedCommand
        {
            get { return (ICommand)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }


        /// <summary>
        /// The command parameter property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(BajioBaseControl), null);

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        /// <value>The command parameter.</value>
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// The prevent keyboard suggestions property.
        /// </summary>
        public static readonly BindableProperty PreventKeyboardSuggestionsProperty =
            BindableProperty.Create(nameof(PreventKeyboardSuggestions), typeof(bool), typeof(BajioEntry), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this  prevent
        /// keyboard suggestions.
        /// </summary>
        /// <value><c>true</c> if prevent keyboard suggestions; otherwise, <c>false</c>.</value>
        public bool PreventKeyboardSuggestions
        {
            get
            {
                return (bool)GetValue(PreventKeyboardSuggestionsProperty);
            }
            set
            {
                SetValue(PreventKeyboardSuggestionsProperty, value);
            }
        }

        /// <summary>
        /// The index value property.
        /// </summary>
        public static readonly BindableProperty IndexValueProperty =
            BindableProperty.Create(nameof(IndexValue), typeof(int), typeof(BajioEntry), default(int), BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the index value.
        /// </summary>
        /// <value>The index value.</value>
        public int IndexValue
        {
            get
            {
                return (int)GetValue(IndexValueProperty);
            }
            set
            {
                SetValue(IndexValueProperty, value);
            }
        }

        /// <summary>
        /// The new value property.
        /// </summary>
        public static readonly BindableProperty NewValueProperty =
            BindableProperty.Create(nameof(NewValue), typeof(string), typeof(BajioEntry), default(string), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        /// <value>The new value.</value>
        public string NewValue
        {
            get
            {
                return (string)GetValue(NewValueProperty);
            }
            set
            {
                SetValue(NewValueProperty, value);
            }
        }

        /// <summary>
        /// The formated value property.
        /// </summary>
        public static readonly BindableProperty FormatedValueProperty =
            BindableProperty.Create(nameof(FormatedValue), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the formated value.
        /// </summary>
        /// <value>The formated value.</value>
        public string FormatedValue
        {
            get
            {
                return (string)GetValue(FormatedValueProperty);
            }
            set
            {
                SetValue(FormatedValueProperty, value);
            }
        }

        /// <summary>
        /// The formated value hidden property.
        /// </summary>
        public static readonly BindableProperty FormatedValueHiddenProperty =
            BindableProperty.Create(nameof(FormatedValueHidden), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the formated value hidden.
        /// </summary>
        /// <value>The formated value hidden.</value>
        public string FormatedValueHidden
        {
            get
            {
                return (string)GetValue(FormatedValueHiddenProperty);
            }
            set
            {
                SetValue(FormatedValueHiddenProperty, value);
            }
        }

        /// <summary>
        /// The value to send property.
        /// </summary>
        public static readonly BindableProperty ValueToSendProperty =
            BindableProperty.Create(nameof(ValueToSend), typeof(string), typeof(BajioEntry), default(string), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the value to send.
        /// </summary>
        /// <value>The value to send.</value>
        public string ValueToSend
        {
            get
            {
                return (string)GetValue(ValueToSendProperty);
            }
            set
            {
                SetValue(ValueToSendProperty, value);
            }
        }

        /// <summary>
        /// The is SSNP roperty.
        /// </summary>
        public static readonly BindableProperty IsSSNProperty =
            BindableProperty.Create(nameof(IsSSN), typeof(bool), typeof(BajioEntry), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this  is ssn.
        /// </summary>
        /// <value><c>true</c> if is ssn; otherwise, <c>false</c>.</value>
        public bool IsSSN
        {
            get
            {
                return (bool)GetValue(IsSSNProperty);
            }
            set
            {
                SetValue(IsSSNProperty, value);
            }
        }

        /// <summary>
        /// The is value password property.
        /// </summary>
        public static readonly BindableProperty IsValuePasswordProperty =
            BindableProperty.Create(nameof(IsValuePassword), typeof(bool), typeof(BajioEntry), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this  is
        /// value password.
        /// </summary>
        /// <value><c>true</c> if is value password; otherwise, <c>false</c>.</value>
        public bool IsValuePassword
        {
            get
            {
                return (bool)GetValue(IsValuePasswordProperty);
            }
            set
            {
                SetValue(IsValuePasswordProperty, value);
            }
        }

        /// <summary>
        /// The is center text property.
        /// </summary>
        public static readonly BindableProperty IsCenterTextProperty =
            BindableProperty.Create(nameof(IsCenterText), typeof(bool), typeof(BajioEntry), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this  is
        /// center text.
        /// </summary>
        /// <value><c>true</c> if is center text; otherwise, <c>false</c>.</value>
        public bool IsCenterText
        {
            get { return (bool)GetValue(IsCenterTextProperty); }
            set
            {
                SetValue(IsCenterTextProperty, value);
            }
        }

        #endregion

        #endregion

        #region Private Properties
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        public BajioEntryBase()
        {
            CustomTextColor = Theme.TextColorSecondary;
            FontSize = 12;
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
            NextView?.EntryEditor?.Focus();
        }

        /// <summary>
        /// Ons the previous.
        /// </summary>
        public void OnPrev()
        {
            PrevView?.EntryEditor?.Focus();
        }

        /// <summary>
        /// Occurs when completed.
        /// </summary>
        public new event EventHandler Completed;

        /// <summary>
        /// Sends the complete.
        /// </summary>
        public void SendComplete()
        {
            if (ReturnType != ReturnTypeKeyboard.Next)
            {
                Unfocus();
            }
            else
            {
                OnNext();
            }
            if (ShouldInvokeAction)
            {
                OnCompleteCommand?.Execute(this);
                // Call all the methods attached to custom_entry event handler Completed
                InvokeCompleted();
            }
            else
            {
                Unfocus();
            }
        }

        /// <summary>
        /// Values the changed.
        /// </summary>
        /// <param name="index">Start index.</param>
        /// <param name="newValue">New value.</param>
        public void ValueChanged(int index, string newValue)
        {
            NewValue = newValue;
            IndexValue = index;
        }
        #endregion

        #region Private Methods
        #endregion

        #region Protected Methods
        #endregion
    }
}
