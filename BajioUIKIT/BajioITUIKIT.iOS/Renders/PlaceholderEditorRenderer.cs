using BajioITUIKIT.Controls;
using BajioITUIKIT.iOS.Renders;
using BajioITUIKIT.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PlaceholderEditor), typeof(PlaceholderEditorRenderer))]
namespace BajioITUIKIT.iOS.Renders
{
    [Preserve(AllMembers = true)]
    public class PlaceholderEditorRenderer : EditorRenderer
    {
        public static new void Init() { }

        private string _placeholder;

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            var field = this.Control;
            var placeholderEditor = (PlaceholderEditor)Element;
            if (placeholderEditor == null)
                return;
            if (field.Text == placeholderEditor.Placeholder)
            {
                field.TextColor = placeholderEditor.PlaceholderColor.ToUIColor();
            }
            else
            {
                field.TextColor = placeholderEditor.TextColor.ToUIColor();
            }
            
            string placeholder = placeholderEditor.CustomPlaceholder;

            field.Text = placeholderEditor.CustomPlaceholder;
            field.Tag = 1000;

            field.Started += (sender, ee) =>
            {
                if (field.Text == placeholder)
                {
                    field.Text = "";
                    field.TextColor = placeholderEditor.TextColor.ToUIColor();
                }

                field.BecomeFirstResponder();
            };

            field.Ended += (sender, ee) =>
            {
                if (string.IsNullOrEmpty(field.Text))
                {
                    field.Text = placeholder;
                    field.TextColor = placeholderEditor.PlaceholderColor.ToUIColor();
                }
                field.ResignFirstResponder();
            };

            Control.TintColor = Theme.PrimaryColor.ToUIColor();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            //if (e.PropertyName == "Text")
            //{
            //    var field = this.Control;
            //    var placeholderEditor = (PlaceholderEditor)Element;
            //    string placeholder = placeholderEditor.Placeholder;

            //    if (field != null && string.IsNullOrEmpty(placeholderEditor.Text))
            //    {

            //        field.TextColor = placeholderEditor.PlaceholderColor.ToUIColor();
            //        field.Text = placeholder;
            //        field.ResignFirstResponder();


            //    }
            //}

            //if (e.PropertyName == "Placeholder")
            //{
            //    var field = this.Control;
            //    var placeholderEditor = (PlaceholderEditor)Element;
            //    string placeholder = placeholderEditor.Placeholder;

            //    if (field != null && placeholderEditor != null && !string.IsNullOrEmpty(placeholder))
            //    {
            //        _placeholder = placeholder;
            //        field.Text = _placeholder;
            //        placeholderEditor.Placeholder = "";
            //    }
            //}
        }
    }
}
