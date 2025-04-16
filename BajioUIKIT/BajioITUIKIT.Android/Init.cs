using Xamarin.Forms.Platform.Android;

namespace BajioITUIKIT.Droid
{
    public class BajioITUIKITDroid
    {
		#region Public Properties
		public static FormsAppCompatActivity MainActivity { get; set; }
		#endregion

		#region Private Properties
		#endregion

		#region Public Methods
		public static void Init(FormsAppCompatActivity mainActivity)
		{
			MainActivity = mainActivity;
		}
		#endregion

		#region Private Methods
		#endregion
	}
}
