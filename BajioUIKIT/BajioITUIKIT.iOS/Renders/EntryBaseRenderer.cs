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

[assembly: ExportRenderer(typeof(EntryBase), typeof(EntryBaseRenderer))]
namespace BajioITUIKIT.iOS.Renders
{
    public class EntryBaseRenderer : EntryRenderer, IUITextFieldDelegate
    {
        #region Private Properties
        private EntryBase entryBase;
        IElementController ElementController => Element as IElementController;
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
                Control.Layer.BorderColor = Theme.InvalidColorPrimary.ToCGColor();
                ChangeTextColor(Element);
                if (e.NewElement != null)
                {
                    Control.KeyboardType = UIKeyboardType.Twitter;
                    entryBase = Element as EntryBase;
                    AddReturnKeyButton(entryBase);
                    if (entryBase.ReturnType == ReturnTypeKeyboard.Next)
                    {
                        Control.ShouldReturn += (textField) =>
                        {
                            entryBase.OnNext();
                            return false;
                        };
                    }
                }
            }
            if (Element != null && Element.ClassId == "SSN")
            {
                var entry = (EntryBase)Element;
                var textF = new UIBackwardsTextField();
                textF.EditingChanged += OnEditingChanged;
                textF.OnDeleteBackward += (sender, a) =>
                {
                    entry.OnBackspacePressed();
                };

                SetNativeControl(textF);

                base.OnElementChanged(e);
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
        /// Ons the editing changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void OnEditingChanged(object sender, EventArgs eventArgs)
        {
            ElementController.SetValueFromRenderer(Entry.TextProperty, Control.Text);
        }

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
        /// Handles the event handler.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void HandleEventHandler(object sender, EventArgs e)
        {
            if (entryBase.ReturnType != ReturnTypeKeyboard.Next)
            {
                entryBase.Unfocus();
            }
            else
            {
                entryBase.OnNext();
            }
            if (entryBase.ShouldInvokeAction)
            {
                // Call all the methods attached to custom_entry event handler Completed
                entryBase.InvokeCompleted();
            }
            else
            {
                entryBase.Unfocus();
            }
        }

        /// <summary>
        /// Changes the color of the text.
        /// </summary>
        private void ChangeTextColor(Entry e)
        {
            var entry = (EntryBase)e;
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
        private void AddReturnKeyButton(EntryBase entry)
        {
            var toolbar = new UIToolbar(new CGRect(0.0f, 0.0f, Control.Frame.Size.Width, 44.0f));
            string titleButton = String.Empty;
            if (entry.Keyboard == Keyboard.Telephone)
            {
                Control.KeyboardType = UIKeyboardType.PhonePad;
            }
            if (entry.Keyboard == Keyboard.Numeric)
            {
                Control.KeyboardType = UIKeyboardType.NumberPad;
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
                    titleButton = "Done";
                    break;
            }
            toolbar.Items = new[]
            {
                        new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                        new UIBarButtonItem(titleButton, UIBarButtonItemStyle.Plain,HandleEventHandler)
                    };
            this.Control.InputAccessoryView = toolbar;
        }
        #endregion
    }

    /// <summary>
    /// Enum extensions.
    /// </summary>
	//public static class EnumExtensions
 //   {
 //       #region Public Methods
 //       /// <summary>
 //       /// Gets the value from description.
 //       /// </summary>
 //       /// <returns>The value from description.</returns>
 //       /// <param name="value">Value.</param>
 //       public static UIReturnKeyType GetValueFromDescription(this ReturnTypeKeyboard value)
 //       {
 //           var type = typeof(UIReturnKeyType);
 //           if (!type.IsEnum) throw new InvalidOperationException();
 //           foreach (var field in type.GetFields())
 //           {
 //               var attribute = Attribute.GetCustomAttribute(field,
 //                   typeof(DescriptionAttribute)) as DescriptionAttribute;
 //               if (attribute != null)
 //               {
 //                   if (attribute.Description == value.ToString())
 //                       return (UIReturnKeyType)field.GetValue(null);
 //               }
 //               else
 //               {
 //                   if (field.Name == value.ToString())
 //                       return (UIReturnKeyType)field.GetValue(null);
 //               }
 //           }
 //           throw new NotSupportedException($"Not supported on iOS: {value}");
 //       }
 //       #endregion
 //   }

    /// <summary>
    /// UIBackwards text field.
    /// </summary>
    public class UIBackwardsTextField : UITextField
    {
        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public UIBackwardsTextField() { }

        /// <summary>
        /// Delete backward event handler.
        /// </summary>
        public delegate void DeleteBackwardEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Occurs when on delete backward.
        /// </summary>
        public event DeleteBackwardEventHandler OnDeleteBackward;

        /// <summary>
        /// Ons the delete backward pressed.
        /// </summary>
        public void OnDeleteBackwardPressed()
        {
            OnDeleteBackward?.Invoke(null, null);
        }

        /// <summary>
        /// Deletes the backward.
        /// </summary>
        public override void DeleteBackward()
        {
            base.DeleteBackward();
            OnDeleteBackwardPressed();
        }
        #endregion
    }
}

