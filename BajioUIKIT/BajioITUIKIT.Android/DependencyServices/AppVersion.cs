using Android.Content.PM;
using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(AppVersion))]
namespace BajioITUIKIT.Droid.DependencyServices
{
    public class AppVersion : IAppVersion
    {
        public string GetVersion()
        {
            var context = global::Android.App.Application.Context;

            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionName;
        }

        public int GetBuild()
        {
            var context = global::Android.App.Application.Context;
            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionCode;
        }
    }
}
