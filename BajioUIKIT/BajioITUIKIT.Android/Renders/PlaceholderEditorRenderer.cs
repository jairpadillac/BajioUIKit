using Android.Content;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PlaceholderEditor), typeof(PlaceholderEditorRenderer))]
namespace BajioITUIKIT.Droid.Renders
{
    [Preserve(AllMembers = true)]
	public class PlaceholderEditorRenderer : EditorRenderer
	{
		#region Public Methods
		/// <summary>
		/// Initializes a new instance of the <see cref="T:PlaceholderEditorRenderer"/> class.
		/// </summary>
		/// <param name="context">Context.</param>
		public PlaceholderEditorRenderer(Context context) : base(context)
		{
		}
		#endregion

		#region Protected Methods
		/// <summary>
		/// Ons the element changed.
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (Element == null)
				return;

			var element = (PlaceholderEditor)Element;

			Control.Hint = element.Placeholder;
			Control.SetHintTextColor(element.PlaceholderColor.ToAndroid());


			//Set the done button
			Control.SetRawInputType(Android.Text.InputTypes.ClassText);
			Control.ImeOptions = Android.Views.InputMethods.ImeAction.Done;
			Control.SetImeActionLabel("Done", Android.Views.InputMethods.ImeAction.Done);
			Control.SetMaxLines(int.MaxValue);
			Control.SetHorizontallyScrolling(false);
			// /done button
		}
		#endregion
	}
}