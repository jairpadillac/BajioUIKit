using System.ComponentModel;
using Android.Content;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using BajioITUIKIT.Enums;
using BajioITUIKIT.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryBase), typeof(EntryBaseRenderer))]
namespace BajioITUIKIT.Droid.Renders
{
    public class EntryBaseRenderer : EntryRenderer
    {

        #region Protected Methods
        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Entry}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
                return;

            //remove underline on entry
            Control.SetBackgroundColor(Android.Graphics.Color.Transparent);

            ChangeTextColor(Element);
            FixKeyboard();

            var entryBase = Element as EntryBase;
            SetReturnType(entryBase);
            Control.EditorAction += (object sender, TextView.EditorActionEventArgs args) =>
            {
                if (entryBase.ReturnType != ReturnTypeKeyboard.Next)
                    entryBase.Unfocus();
                else
                    entryBase.OnNext();
                if (entryBase.ShouldInvokeAction)
                {
                    // Call all the methods attached to custom_entry event handler Completed
                    entryBase.InvokeCompleted();
                }
                else
                {
                    entryBase.Unfocus();
                }

            };
        }

        /// <summary>
        /// Called when [element property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "IsEnabled")
            {
                ChangeTextColor(Element);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Fixes the keyboard.
        /// </summary>
        private void FixKeyboard()
        {
            if (Element.Keyboard != Keyboard.Numeric || !Element.IsPassword) return;
            Control.InputType = Android.Text.InputTypes.ClassNumber;
            Control.TransformationMethod = Android.Text.Method.PasswordTransformationMethod.Instance;
        }

        /// <summary>
        /// Changes the color of the text.
        /// </summary>
        private void ChangeTextColor(Entry e)
        {
            var entry = (EntryBase)e;
            if (entry.IsEnabled)
            {
                if (entry.CustomTextColor == Theme.TextColorSecondary)
                {
                    Control.SetTextColor(Theme.TextColorSecondary.ToAndroid());
                }
                else
                {
                    Control.SetTextColor(entry.CustomTextColor.ToAndroid());
                }
            }
            else
            {
                Control.SetTextColor(Theme.TextInactiveColorSecondary.ToAndroid());
            }
        }

        private void SetReturnType(EntryBase entry)
        {
            ReturnTypeKeyboard type = entry.ReturnType;

            switch (type)
            {
                case ReturnTypeKeyboard.Go:
                    Control.ImeOptions = ImeAction.Go;
                    Control.SetImeActionLabel("Ir", ImeAction.Go);
                    break;
                case ReturnTypeKeyboard.Next:
                    Control.ImeOptions = ImeAction.Next;
                    Control.SetImeActionLabel("Siguiente", ImeAction.Next);
                    break;
                case ReturnTypeKeyboard.Send:
                    Control.ImeOptions = ImeAction.Send;
                    Control.SetImeActionLabel("Enviar", ImeAction.Send);
                    break;
                case ReturnTypeKeyboard.Search:
                    Control.ImeOptions = ImeAction.Search;
                    Control.SetImeActionLabel("Buscar", ImeAction.Search);
                    break;
                case ReturnTypeKeyboard.Done:
                    Control.ImeOptions = ImeAction.Done;
                    Control.SetImeActionLabel("Hecho", ImeAction.Done);
                    break;
                case ReturnTypeKeyboard.SignIn:
                    Control.ImeOptions = ImeAction.Go;
                    Control.SetImeActionLabel("Entrar", ImeAction.Go);
                    break;
                default:
                    Control.ImeOptions = ImeAction.Done;
                    Control.SetImeActionLabel("Hecho", ImeAction.Done);
                    break;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Dispatchs the key event.
        /// </summary>
        /// <returns><c>true</c>, if key event was dispatched, <c>false</c> otherwise.</returns>
        /// <param name="e">E.</param>
        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (e.Action == KeyEventActions.Down)
            {
                if (e.KeyCode == Keycode.Del)
                {
                    if (string.IsNullOrWhiteSpace(Control.Text))
                    {
                        var entry = (EntryBase)Element;
                        entry.OnBackspacePressed();
                    }
                }
            }
            return base.DispatchKeyEvent(e);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EntryBaseRenderer"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public EntryBaseRenderer(Context context) : base(context)
        {
        }
        #endregion

    }
}