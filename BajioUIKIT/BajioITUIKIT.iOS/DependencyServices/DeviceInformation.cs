using System;
using System.Threading.Tasks;
using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.iOS.DependencyServices;
using Foundation;
using ObjCRuntime;
using Security;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceInformation))]
namespace BajioITUIKIT.iOS.DependencyServices
{
    public class DeviceInformation : IDeviceInformation
    {
        #region Public Methods

        /// <summary>
        /// Gets phone number.
        /// </summary>
        /// <returns></returns>
        public string GetPhoneNumber()
        {
            return "";
        }

        /// <summary>
        /// Gets device model.
        /// </summary>
        /// <returns></returns>
        public string GetModel()
        {
            return UIDevice.CurrentDevice.Model;
        }

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <returns></returns>
        public string GetLanguage()
        {
            return NSLocale.CurrentLocale.LocaleIdentifier;
        }

        /// <summary>
        /// Gets the display bounds.
        /// </summary>
        /// <returns></returns>
        public string GetDisplay()
        {
            return UIScreen.MainScreen.Bounds.Width + "|" + UIScreen.MainScreen.Bounds.Height;
        }

        /// <summary>
        /// Gets the sim identifier.
        /// </summary>
        /// <returns></returns>
        public string GetSimId()
        {
            return UIDevice.CurrentDevice.IdentifierForVendor.ToString();
        }

        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        /// <returns></returns>
        public string GetDeviceId()
        {
            return UIDevice.CurrentDevice.GetNativeHash().ToString();
        }

        /// <summary>
        /// Gets the os version.
        /// </summary>
        /// <returns></returns>
        public string GetOSVersion()
        {
            return UIDevice.CurrentDevice.SystemVersion;
        }

        /// <summary>
        /// Gets the ip address.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetIPAddress()
        {
            //Private IP
            //string ipAddress = string.Empty;
            //foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            //{
            //    if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
            //        netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            //    {
            //        foreach (var addrInfo in netInterface.GetIPProperties().UnicastAddresses)
            //        {
            //            if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
            //            {
            //                ipAddress = addrInfo.Address.ToString();
            //            }
            //        }
            //    }
            //}

            //Public IP
            //var client = ServiceHelper.GetClient(Api.Default);
            //string publicIP = await client.GetStringAsync("https://icanhazip.com/");
            //publicIP = publicIP?.Trim();
            //return publicIP;
            return "";
        }

        /// <summary>
        /// Gets if is emulator.
        /// </summary>
        /// <returns></returns>
        public bool GetIsEmulator()
        {
            if (Runtime.Arch == Arch.SIMULATOR)
                return true;
            return false;
        }

        /// <summary>
        /// Gets the is compromised.
        /// </summary>
        /// <returns></returns>
        public bool GetIsCompromised()
        {
            if (UIApplication.SharedApplication.CanOpenUrl(new NSUrl("cydia://package/com.exapmle.package")))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the application key.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationKey()
        {
            string deviceIDValue = "";

            //TODO: return sha1 code

            return deviceIDValue;
        }

        /// <summary>
        /// Gets the application version number.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationVersionNumber()
        {
            string version = NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
            return version;
        }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <returns></returns>
        public string GetApplicationName()
        {
            var appName = NSBundle.MainBundle.InfoDictionary["CFBundleName"]?.ToString();
            return appName;
        }

        /// <summary>
        /// Gets the device model.
        /// </summary>
        /// <returns>The device model.</returns>
        public string GetDeviceModel()
        {
            string version = DeviceHardware.Version();
            string Model = DeviceHardware.Model;
            return Model;
        }

        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <returns>The manufacturer.</returns>
        public string GetManufacturer()
        {
            return "Apple"; //Only needed in iOS
        }


        /// <summary>
        /// Gets the device has turn off animations.
        /// </summary>
        /// <returns><c>true</c>, if device has turn off animations was gotten, <c>false</c> otherwise.</returns>
        public bool GetDeviceHasTurnOffAnimations()
        {
            return false;
        }

        /// <summary>
        /// Gets the device has turned on developer options.
        /// </summary>
        /// <returns><c>true</c>, if device has turned on developer options, <c>false</c> otherwise.</returns>
        public bool GetDeviceHasTurnedOnDeveloperOptions()
        {
            return false;
        }

        /// <summary>
        /// Go to developer options page
        /// </summary>
        public void GoToDeveloperOptions()
        {

        }

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <returns>The unique identifier.</returns>
        public string GetUniqueID()
        {
            try
            {
                var query = new SecRecord(SecKind.GenericPassword);
                query.Service = NSBundle.MainBundle.BundleIdentifier;
                query.Account = "UniqueID";

                NSData uniqueId = SecKeyChain.QueryAsData(query);
                if (uniqueId == null)
                {
                    query.ValueData = NSData.FromString(Guid.NewGuid().ToString());
                    var err = SecKeyChain.Add(query);
                    if (err != SecStatusCode.Success && err != SecStatusCode.DuplicateItem)
                    {
                        return string.Empty;
                    }

                    return query.ValueData.ToString();
                }
                return uniqueId.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
