using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.iOS.DependencyServices;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(AppVersion))]
namespace BajioITUIKIT.iOS.DependencyServices
{
    public class AppVersion : IAppVersion
    {
        public string GetVersion()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }
        public int GetBuild()
        {
            return int.Parse(NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString());
        }
    }
}
