using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Telephony;
using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.Droid.DependencyServices;
using Java.IO;
using Java.Lang;
using Java.Security;
using Java.Util;
using Xamarin.Forms;
using DebugSystem = System.Diagnostics.Debug;

[assembly: Dependency(typeof(DeviceInformation))]
namespace BajioITUIKIT.Droid.DependencyServices
{
    public class DeviceInformation : System.Object, IDeviceInformation
    {
        private TelephonyManager _telephonyManager;
        private ActivityManager _activityManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceInformation"/> class.
        /// </summary>
        public DeviceInformation()
        {
            _telephonyManager = (TelephonyManager)Android.App.Application.Context.GetSystemService(Context.TelephonyService);
            _activityManager = (ActivityManager)Android.App.Application.Context.GetSystemService(Context.ActivityService);
        }

        /// <summary>
        /// Gets device model.
        /// </summary>
        /// <returns></returns>
        public string GetModel()
        {
            return Build.Model;
        }

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <returns></returns>
        public string GetLanguage()
        {
            return Locale.Default.GetDisplayLanguage(Locale.Default);
        }

        /// <summary>
        /// Gets the display.
        /// </summary>
        /// <returns></returns>
        public string GetDisplay()
        {
            return "";//Resources.DisplayMetrics.WidthPixels + "|" + Resources.DisplayMetric.HeightPixels;
        }

        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <returns></returns>
        public string GetPhoneNumber()
        {
            return _telephonyManager.Line1Number;
        }

        /// <summary>
        /// Gets the sim identifier.
        /// </summary>
        /// <returns></returns>
        public string GetSimId()
        {
            return _telephonyManager.SubscriberId;
        }

        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        /// <returns></returns>
        public string GetDeviceId()
        {
            return _telephonyManager.DeviceId;
        }

        /// <summary>
        /// Gets the os version.
        /// </summary>
        /// <returns></returns>
        public string GetOSVersion()
        {
            return Build.VERSION.Sdk;
        }

        /// <summary>
        /// Gets the ip address.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetIPAddress()
        {
            await Task.Delay(0);
            string ipAddress = string.Empty;
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());
            if (addresses != null && addresses[0] != null)
            {
                ipAddress = addresses[0].ToString();
            }
            return ipAddress;
        }

        /// <summary>
        /// Gets the is emulator.
        /// </summary>
        /// <returns></returns>
        public bool GetIsEmulator()
        {
            string fingerPrint = Build.Fingerprint;
            bool isEmulator = false;
            if (fingerPrint != null)
            {
                isEmulator = fingerPrint.Contains("vbox") || fingerPrint.Contains("generic");
            }

            return isEmulator;
        }

        /// <summary>
        /// Gets the is compromised.
        /// </summary>
        /// <returns></returns>
        public bool GetIsCompromised()
        {
            return CheckBuildTagsHaveTestKeys() || CheckSUFileExist() || CheckPresenceOfSuspiciousAPKs();
        }

        /// <summary>
        /// Gets the application key.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationKey()
        {
            string deviceIDValue = "";

            byte[] deviceIDbytes = new byte[16];
            if (!getSecureRandomBytes(deviceIDbytes))
            {
                //Log.e("ApplicationKey", "unexpected error in getStoredApplicationKey, can't generate key");
                return "INVALID";
            }
            deviceIDValue = byteArrayToHexString(deviceIDbytes);

            return deviceIDValue;
        }

        public static string byteArrayToHexString(byte[] byteArray)
        {
            int byteArrayLen = byteArray.Length;
            StringBuffer strBuffer = new StringBuffer(byteArrayLen * 2);
            for (int i = 0; i < byteArrayLen; i++)
            {
                int value = byteArray[i] & 0xFF;
                if (value < 16)
                {
                    strBuffer.Append('0');
                }
                strBuffer.Append(Integer.ToHexString(value));
            }
            return strBuffer.ToString().ToUpper();
        }

        public static bool getSecureRandomBytes(byte[] secureBytesArray)
        {
            if ((null != secureBytesArray) && (0 != secureBytesArray.Length))
            {
                try
                {
                    SecureRandom ranGen = SecureRandom.GetInstance("SHA1PRNG");
                    ranGen.NextBytes(secureBytesArray);
                    return true;
                }
                catch (NoSuchAlgorithmException) { }
            }
            return false;
        }

        private bool CheckBuildTagsHaveTestKeys()
        {
            string buildTags = Build.Tags;
            return buildTags != null && buildTags.Contains("test-keys");
        }

        private bool CheckSUFileExist()
        {
            string[] paths = { "/system/app/Superuser.apk", "/sbin/su", "/system/bin/su", "/system/xbin/su", "/data/local/xbin/su", "/data/local/bin/su", "/system/sd/xbin/su",
                "/system/bin/failsafe/su", "/data/local/su" };
            foreach (string path in paths)
            {
                if (new File(path).Exists()) return true;
            }
            return false;
        }

        private bool CheckPresenceOfSuspiciousAPKs()
        {
            Java.Lang.Process process = null;
            try
            {
                process = Runtime.GetRuntime().Exec(new string[] { "/system/xbin/which", "su" });
                BufferedReader br = new BufferedReader(new InputStreamReader(process.OutputStream));
                if (br.ReadLine() != null) return true;
                return false;
            }
            catch (System.Exception ex)
            {
                return false;
            }
            finally
            {
                if (process != null) process.Dispose();
            }
        }

        /// <summary>
        /// Gets the application version number.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationVersionNumber()
        {
            //Version appVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //string version = string.Format("{0}.{1}.{2}.{3}", appVersion.Major, appVersion.Minor, appVersion.Build, appVersion.Revision);
            Context context = Forms.Context;
            var version = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
            return version;
        }


        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationName()
        {
            var context = Forms.Context;
            return context.PackageManager?.GetApplicationInfo(context.PackageName, 0)?.LoadLabel(context.PackageManager);
        }

        /// <summary>
        /// Gets the device model.
        /// </summary>
        /// <returns>The device model.</returns>
        public string GetDeviceModel()
        {
            var deviceModel = Android.OS.Build.Model;
            return deviceModel;
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <returns>The manufacturer.</returns>
        public string GetManufacturer()
        {
            var manufacturer = Android.OS.Build.Manufacturer;
            return manufacturer;
        }

        /// <summary>
        /// Go to developer options page.
        /// </summary>
        public void GoToDeveloperOptions()
        {
            Xamarin.Forms.Forms.Context.StartActivity(new Intent(Android.Provider.Settings.ActionApplicationDevelopmentSettings));
        }

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <returns>The unique identifier.</returns>
        public string GetUniqueID()
        {
            return _telephonyManager.Imei;
        }
    }

}
