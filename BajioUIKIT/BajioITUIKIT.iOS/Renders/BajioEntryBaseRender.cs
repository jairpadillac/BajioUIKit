using System;
using System.ComponentModel;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Enums;
using BajioITUIKIT.iOS.Renders;
using BajioITUIKIT.Styles;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BajioEntryBase), typeof(BajioEntryBaseRender))]
namespace BajioITUIKIT.iOS.Renders
{
    public class BajioEntryBaseRender : EntryRenderer
    {
        #region Private Properties
        private BajioEntryBase entryBase;

        #endregion

        #region Protected Methods
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Entry}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                PrepareEntry();
                Control.Layer.BorderColor = Color.Red.ToCGColor();
                ChangeTextColor(Element);
                if (e.NewElement != null)
                {
                    Control.KeyboardType = UIKeyboardType.Twitter;
                    entryBase = Element as BajioEntryBase;
                    AddReturnKeyButton(entryBase);
                    if (entryBase != null)
                    {
                        if (entryBase.PreventKeyboardSuggestions)
                        {
                            Control.AutocorrectionType = UITextAutocorrectionType.No;           
                            Control.AutocapitalizationType = UITextAutocapitalizationType.None; 
                            Control.SpellCheckingType = UITextSpellCheckingType.No;             
                        }
                        Control.ShouldChangeCharacters = (UITextField textField, Foundation.NSRange range, string replacementString) =>
                        {
                            entryBase.ValueChanged((int)range.Location, replacementString);
                            return true;
                        };
                        Control.TintColor = Theme.PrimaryColor.ToUIColor();
                    }

                }
            }
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Element == null) return;

            if (e.PropertyName == "IsEnabled")
            {
                ChangeTextColor(Element);
            }
        }
        #endregion

        #region Private Methods              
        /// <summary>
        /// Prepares the entry.
        /// </summary>
        private void PrepareEntry()
        {
            // Remove entry border for ios.
            Control.BorderStyle = UITextBorderStyle.None;
            Control.Layer.BorderWidth = 0;
        }

        /// <summary>
        /// Handlers the event done.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void HandlerEvent_Done(object sender, EventArgs e)
        {
            entryBase.SendComplete();
        }

        /// <summary>
        /// Handlers the event next.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void HandlerEvent_Next(object sender, EventArgs e)
        {
            entryBase.OnNext();
        }

        /// <summary>
        /// Handlers the event previous.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void HandlerEvent_Prev(object sender, EventArgs e)
        {
            entryBase.OnPrev();
        }

        /// <summary>
        /// Changes the color of the text.
        /// </summary>
        private void ChangeTextColor(Entry e)
        {
            var entry = (BajioEntryBase)e;
            if (entry == null) return;
            if (entry.IsEnabled)
            {
                if (entry.CustomTextColor == Theme.TextColorSecondary)
                {
                    Control.TextColor = Theme.TextColorSecondary.ToUIColor();
                }
                else
                {
                    Control.TextColor = entry.CustomTextColor.ToUIColor();
                }
            }
            else
            {
                Control.TextColor = Theme.TextInactiveColorSecondary.ToUIColor();
            }
        }

        /// <summary>
        /// Adds the return key button.
        /// </summary>
        /// <param name="entry">Entry.</param>
        private void AddReturnKeyButton(BajioEntryBase entry)
        {
            var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));
            string titleButton = String.Empty;
            if (entry.KeyBoardType == EntryKeyBoardType.Numeric)
            {
                Control.KeyboardType = UIKeyboardType.NumberPad;
            }
            if (entry.KeyBoardType == EntryKeyBoardType.Decimal)
            {
                Control.KeyboardType = UIKeyboardType.DecimalPad;
            }
            if (entry.KeyBoardType == EntryKeyBoardType.Telephone)
            {
                Control.KeyboardType = UIKeyboardType.PhonePad;
            }
            switch (entry.ReturnType)
            {
                case ReturnTypeKeyboard.Done:
                    titleButton = "Hecho";
                    break;
                case ReturnTypeKeyboard.Next:
                    titleButton = "Siguiente";
                    break;
                case ReturnTypeKeyboard.Go:
                    titleButton = "Ir";
                    break;
                case ReturnTypeKeyboard.Search:
                    titleButton = "Buscar";
                    break;
                case ReturnTypeKeyboard.SignIn:
                    titleButton = "Entrar";
                    break;
                default:
                    titleButton = "Hecho";
                    break;
            }
            if (titleButton == "Hecho")
            {
                var prev = new UIBarButtonItem(" ▲ ", UIBarButtonItemStyle.Bordered, HandlerEvent_Prev);
                var next = new UIBarButtonItem(" ▼ ", UIBarButtonItemStyle.Bordered, HandlerEvent_Next);
                var space = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
                var done = new UIBarButtonItem(titleButton, UIBarButtonItemStyle.Bordered, HandlerEvent_Done);
                prev.Enabled = entryBase.PrevView != null;
                next.Enabled = entryBase.NextView != null;
                toolbar.Items = new UIBarButtonItem[]
                {
                    prev, next, space, done
                };
            }
            else
            {
                toolbar.Items = new UIBarButtonItem[]
                {
                    new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                    new UIBarButtonItem(titleButton, UIBarButtonItemStyle.Bordered,HandlerEvent_Done)
                };
            }
            Control.InputAccessoryView = toolbar;
        }
        #endregion
    }

    /// <summary>
    /// Enum extensions.
    /// </summary>
    public static class EnumExtensions
    {
        #region Public Methods
        /// <summary>
        /// Gets the value from description.
        /// </summary>
        /// <returns>The value from description.</returns>
        /// <param name="value">Value.</param>
        public static UIReturnKeyType GetValueFromDescription(this ReturnTypeKeyboard value)
        {
            var type = typeof(UIReturnKeyType);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == value.ToString())
                        return (UIReturnKeyType)field.GetValue(null);
                }
                else
                {
                    if (field.Name == value.ToString())
                        return (UIReturnKeyType)field.GetValue(null);
                }
            }
            throw new NotSupportedException($"Not supported on iOS: {value}");
        }
        #endregion
    }
}
