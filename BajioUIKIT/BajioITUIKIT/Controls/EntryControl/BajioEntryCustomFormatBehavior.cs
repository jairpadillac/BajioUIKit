using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    /// <summary>
    /// Bajio entry custom format behavior.
    /// </summary>
    public class BajioEntryCustomFormatBehavior : Behavior<Entry>
    {
        #region Public Properties
        /// <summary>
        /// The text property.
        /// </summary>
        public static readonly BindableProperty TextProperty = 
            BindableProperty.Create(nameof(Text), typeof(string), typeof(BajioEntryCustomFormatBehavior), string.Empty, BindingMode.OneWayToSource);

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// The custom format property.
        /// </summary>
        public static readonly BindableProperty CustomFormatProperty = 
            BindableProperty.Create(nameof(CustomFormat), typeof(string), typeof(BajioEntryCustomFormatBehavior), string.Empty, BindingMode.OneWay);

        /// <summary>
        /// Gets or sets the custom format.
        /// </summary>
        /// <value>The custom format.</value>
        public string CustomFormat
        {
            get { return (string)GetValue(CustomFormatProperty); }
            set { SetValue(CustomFormatProperty, value); }
        }

        /// <summary>
        /// The custom place holder property.
        /// </summary>
        public static readonly BindableProperty CustomPlaceHolderProperty = 
            BindableProperty.Create(nameof(CustomPlaceHolder), typeof(string), typeof(BajioEntryCustomFormatBehavior), string.Empty, BindingMode.OneWay);

        /// <summary>
        /// Gets or sets the custom place holder.
        /// </summary>
        /// <value>The custom place holder.</value>
        public string CustomPlaceHolder
        {
            get { return (string)GetValue(CustomPlaceHolderProperty); }
            set { SetValue(CustomPlaceHolderProperty, value); }
        }

        /// <summary>
        /// The separator property.
        /// </summary>
        public static readonly BindableProperty SeparatorProperty = 
            BindableProperty.Create(nameof(Separator), typeof(List<string>), typeof(BajioEntryCustomFormatBehavior), default(List<string>), BindingMode.OneWay);

        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>The separator.</value>
        public List<string> Separator
        {
            get { return (List<string>)GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }

        /// <summary>
        /// The is password property.
        /// </summary>
        public static readonly BindableProperty IsValuePasswordProperty =
            BindableProperty.Create(nameof(IsValuePassword), typeof(bool), typeof(BajioEntryCustomFormatBehavior), default(bool), BindingMode.OneWay);

        /// <summary>
        /// Gets or sets a value indicating whether this is value password.
        /// </summary>
        /// <value><c>true</c> if is value password; otherwise, <c>false</c>.</value>
        public bool IsValuePassword
        {
            get { return (bool)GetValue(IsValuePasswordProperty); }
            set { SetValue(IsValuePasswordProperty, value); }
        }

        /// <summary>
        /// The formated value property.
        /// </summary>
        public static readonly BindableProperty FormatedValueProperty =
            BindableProperty.Create(nameof(FormatedValue), typeof(string), typeof(BajioEntryCustomFormatBehavior), default(string), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the formated value.
        /// </summary>
        /// <value>The formated value.</value>
        public string FormatedValue
        {
            get { return (string)GetValue(FormatedValueProperty); }
            set { SetValue(FormatedValueProperty, value); }
        }

        /// <summary>
        /// The value to send property.
        /// </summary>
        public static readonly BindableProperty ValueToSendProperty =
            BindableProperty.Create(nameof(ValueToSend), typeof(string), typeof(BajioEntryCustomFormatBehavior), default(string), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the value to send.
        /// </summary>
        /// <value>The value to send.</value>
        public string ValueToSend
        {
            get { return (string)GetValue(ValueToSendProperty); }
            set { SetValue(ValueToSendProperty, value); }
        }
        #endregion

        #region Private Properties
        private string _formatedValue;
        private string _formatedValueHidden;
        private BajioEntryCustomMaskBehavior MaskBehavior;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public BajioEntryCustomFormatBehavior()
        {
            _formatedValue = string.Empty;
            _formatedValueHidden = string.Empty;
            MaskBehavior = new BajioEntryCustomMaskBehavior();
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
                bindable.Placeholder = CustomPlaceHolder;
                bindable.TextChanged += Bindable_TextChanged;
                base.OnAttachedTo(bindable);
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
                bindable.TextChanged -= Bindable_TextChanged;
                OnDetachingFrom(bindable);
            }
        }

        /// <summary>
        /// Bindables the text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        private void Bindable_TextChanged(object sender, TextChangedEventArgs args)
        {
            try
            {
                var maskType = ((BajioEntry)((BajioEntryBase)sender).Parent.Parent).Mask;

                if ((args.NewTextValue == args.OldTextValue) ||
                   string.IsNullOrEmpty(args.NewTextValue))
                {
                    _formatedValue = string.Empty;
                    _formatedValueHidden = string.Empty;

                    ((BajioEntryBase)sender).ValueToSend = string.Empty;
                    ((BajioEntryBase)sender).FormatedValue = string.Empty;
                    ((BajioEntryBase)sender).FormatedValueHidden = string.Empty;
                    return;
                }
                
                if (args.NewTextValue.Length > CustomFormat.Length)
                {
                    ((Entry)sender).Text = args.OldTextValue;
                    return;
                }

                string newValue = string.Empty;
                string oldValue = string.Empty;
                foreach (var sep in Separator)
                {
                    newValue = args.NewTextValue.Replace(sep, string.Empty);
                    oldValue = args.OldTextValue == null ? string.Empty : args.OldTextValue.Replace(sep, string.Empty);
                }
                if (newValue.Length != oldValue.Length)
                {
                    if(((BajioEntryBase)sender).IsSSN)
                    {
                        int indexNewChar = ((BajioEntryBase)sender).IndexValue;
                        string newChar = ((BajioEntryBase)sender).NewValue;
                        SetBackupValue(newChar, indexNewChar);

                        var formated = MaskBehavior.ProcessMask(((Entry)sender).Text, args.OldTextValue, args.NewTextValue, CustomFormat);
                        _formatedValueHidden = ProcessPassword(formated);
                        ((BajioEntryBase)sender).FormatedValueHidden = _formatedValueHidden;
                        ((BajioEntryBase)sender).FormatedValue = _formatedValue;
                        if(((BajioEntryBase)sender).IsValuePassword)
                        {
                            ((Entry)sender).Text = _formatedValueHidden;
                        }
                        else
                        {
                            ((Entry)sender).Text = formated.Contains("•") ? _formatedValue : formated;
                        }
                        ValueToSend = Regex.Replace(_formatedValue, "[^0-9]", string.Empty);
                    }
                    else
                    {
                        _formatedValue = MaskBehavior.ProcessMask(((Entry)sender).Text, args.OldTextValue, args.NewTextValue, CustomFormat, maskType);
                        ((BajioEntryBase)sender).FormatedValue = _formatedValue;
                        ((Entry)sender).Text = _formatedValue;
                        ValueToSend = Regex.Replace(_formatedValue, "[^0-9]", string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// Processes the password.
        /// </summary>
        /// <returns>The password.</returns>
        /// <param name="ssn">Ssn.</param>
        private string ProcessPassword(string ssn)
        {            
            return Regex.Replace(ssn, "[0-9]", "•");
        }

        /// <summary>
        /// Sets the backup value.
        /// </summary>
        /// <param name="newChar">New char.</param>
        /// <param name="index">Index.</param>
        private void SetBackupValue(string newChar, int index)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newChar))
                {
                    _formatedValue = _formatedValue.Remove(index, 1);
                }
                else
                {
                    if (_formatedValue.Length != CustomFormat.Length)
                    {
                        if (index > _formatedValue.Length)
                        {
                            _formatedValue = _formatedValue.Insert(index - 2, Separator[0]);
                            _formatedValue = _formatedValue.Insert(index, newChar);
                        }
                        else
                        {
                            _formatedValue = _formatedValue.Insert(index, newChar);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"[SetBackupValue] - {ex.Message}");
            }
        }
        #endregion
    }
}
