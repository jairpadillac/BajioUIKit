using System;
using System.Diagnostics;
using Xamarin.Forms;
namespace BajioITUIKIT.Controls
{
    public class BajioEntryOnlyIntegerMaxZeroBehavior : Behavior<Entry>
    {
        #region Public Properties
        /// <summary>
        /// MaxLength
        /// </summary>
        public int MaxLength { get; set; }
        #endregion

        #region Protected Methods
        /// <summary>
        /// OnAttached Method
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += _bindableTextChanged;
        }

        /// <summary>
        /// OnDetached Method
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= _bindableTextChanged;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// _bindableTextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _bindableTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                int currentValue = 0;
                try
                {
                    currentValue = int.Parse(e.NewTextValue);

                    if (currentValue > 0)
                    {
                        if (e.NewTextValue.Length > 0 && e.NewTextValue.Length > MaxLength)
                        {
                            ((Entry)sender).Text = currentValue.ToString().Substring(0, MaxLength);
                        }
                    }
                    else
                    {
                        ((Entry)sender).Text = e.OldTextValue.Substring(0, MaxLength);
                    }
                }
                catch (Exception ex)
                {
#if DEBUG
                    Debug.WriteLine($"Soruce: {ex.Source}\n Message: {ex.Message}\n StackTrace: {ex.StackTrace}");
#endif
                    ((Entry)sender).Text = "0";
                }
            }
        }
        #endregion


    }
}
