//using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Android.Content;
//using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using BajioITUIKIT.Enums;
using BajioITUIKIT.Styles;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BajioEntryBase), typeof(BajioEntryBaseRender))]
namespace BajioITUIKIT.Droid.Renders
{
    public class BajioEntryBaseRender : EntryRenderer
    {
        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BajioUIKit.Mobile.Droid.Renderers.BajioEntryBaseRender"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        public BajioEntryBaseRender(Context context) : base(context)
        {
        }

        /// <summary>
        /// Updates the type of the input.
        /// </summary>
        public void UpdateInputType()
        {
            if (Element != null)
            {
                if (Element.PreventKeyboardSuggestions)
                {
                    Control.InputType = Control.InputType | Android.Text.InputTypes.TextFlagNoSuggestions;
                }
            }
        }

        /// <summary>
        /// Injecteds the on text changed.
        /// </summary>
        /// <param name="s">S.</param>
        /// <param name="start">Start.</param>
        /// <param name="before">Before.</param>
        /// <param name="count">Count.</param>
        public void InjectedOnTextChanged(ICharSequence s, int start, int before, int count)
        {
            var val = s.ToString();
            val = val.Substring(start, count);
            Element.ValueChanged(start, val);
            (this as ITextWatcher).OnTextChanged(s, start, before, count);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Gets the element.
        /// </summary>
        /// <value>The element.</value>
        private new BajioEntryBase Element
        {
            get
            {
                return base.Element as BajioEntryBase;
            }
        }

        /// <summary>
        /// Controls the editor action.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void Control_EditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            Element?.SendComplete();
        }

        /// <summary>
        /// Forces text aligned to center async.
        /// </summary>
        private async Task ForceTextAlignedToCenterAsync()
        {
            await Task.Delay(150);
            if (Control != null)
            {
                Control.Gravity = GravityFlags.CenterVertical;
                Control.TextAlignment = Android.Views.TextAlignment.Center;
            }
        }

        /// <summary>
        /// Texts the aligned to center async.
        /// </summary>
        /// <returns>The aligned to center async.</returns>
        private async Task TextAlignedToCenterAsync()
        {
            await Task.Delay(150);
            if (Control != null)
            {
                Control.Gravity = GravityFlags.CenterHorizontal;
                Control.TextAlignment = Android.Views.TextAlignment.Center;
            }
        }

        /// <summary>
        /// Fixs the keyboard.
        /// </summary>
        /// <param name="entry">Entry.</param>
        private void FixKeyboard(BajioEntryBase entry)
        {
            if (entry.KeyBoardType != EntryKeyBoardType.Numeric || !entry.IsPassword)
            {
                return;
            }
            Control.InputType = InputTypes.ClassNumber;
            Control.TransformationMethod = Android.Text.Method.PasswordTransformationMethod.Instance;
        }

        /// <summary>
        /// Changes the color of the text.
        /// </summary>
        /// <param name="element">Element.</param>
        private void ChangeTextColor(Entry element)
        {
            if (element == null)
                return;

            var entry = (BajioEntryBase)element;
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

        /// <summary>
        /// Sets the type of the return.
        /// </summary>
        /// <param name="entry">Entry.</param>
        private void SetReturnType(BajioEntryBase entry)
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
                    Control.SetImeActionLabel("Next", ImeAction.Next);
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
                    Control.SetImeActionLabel("Done", ImeAction.Done);
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

        #region Protected Methods
        /// <summary>
        /// Ons the element changed.
        /// </summary>
        /// <param name="e">E.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
            //IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");

            //// my_cursor is the xml file name which we defined above
            //JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.abc_ab_share_pack_mtrl_alpha);

            if (Control == null)
            {
                return;
            }

            if (e.NewElement != null)
            {
                Control?.RemoveTextChangedListener(this);
                Control?.AddTextChangedListener(new ExtendedTextWatcher(this));

                Control.EditorAction += Control_EditorAction;

                Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
                ChangeTextColor(Element);
                FixKeyboard(Element);
                SetReturnType(Element);
                UpdateInputType();
            }
            if (e.OldElement != null)
            {
                Control.EditorAction -= Control_EditorAction;
            }
        }

        /// <summary>
        /// Ons the element property changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                if (e.PropertyName == "IsEnabled")
                {
                    ChangeTextColor(Element);
                }
                else if (e.PropertyName == "Renderer")
                {
                    if (Control?.TextAlignment != Android.Views.TextAlignment.Center)
                    {
                        ForceTextAlignedToCenterAsync().ConfigureAwait(false);
                    }
                }
                else if (e.PropertyName == Entry.IsPasswordProperty.PropertyName)
                {
                    UpdateInputType();
                }

                var element = (BajioEntryBase)Element;
                if (element.IsCenterText )
                {
                    TextAlignedToCenterAsync().ConfigureAwait(false);
                }
            }
        }
        #endregion
    }

    public class ExtendedTextWatcher : Object, ITextWatcher
    {
        #region Public Methods
        /// <summary>
        /// Gets the root object.
        /// </summary>
        /// <value>The root object.</value>
        public BajioEntryBaseRender RootObject { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BajioUIKit.Mobile.Droid.Renderers.ExtendedTextWatcher"/> class.
        /// </summary>
        /// <param name="rootObject">Root object.</param>
        public ExtendedTextWatcher(BajioEntryBaseRender rootObject)
        {
            RootObject = rootObject;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Android.s the text. IT ext watcher. after text changed.
        /// </summary>
        /// <param name="s">S.</param>
        void ITextWatcher.AfterTextChanged(IEditable s)
        {
            (RootObject as ITextWatcher).AfterTextChanged(s);
        }

        /// <summary>
        /// Android.s the text. IT ext watcher. before text changed.
        /// </summary>
        /// <param name="s">S.</param>
        /// <param name="start">Start.</param>
        /// <param name="count">Count.</param>
        /// <param name="after">After.</param>
        void ITextWatcher.BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            (RootObject as ITextWatcher).BeforeTextChanged(s, start, count, after);
        }

        /// <summary>
        /// Android.s the text. IT ext watcher. on text changed.
        /// </summary>
        /// <param name="s">S.</param>
        /// <param name="start">Start.</param>
        /// <param name="before">Before.</param>
        /// <param name="count">Count.</param>
        void ITextWatcher.OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            RootObject.InjectedOnTextChanged(s, start, before, count);
        }
        #endregion
    }
}
