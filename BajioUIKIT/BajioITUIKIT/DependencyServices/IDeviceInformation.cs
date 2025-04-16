using System.Threading.Tasks;

namespace BajioITUIKIT.DependencyServices
{
    public interface IDeviceInformation
    {
        /// <summary>
        /// Gets the phone number.
        /// </summary>
        /// <returns></returns>
        string GetPhoneNumber();
        /// <summary>
        /// Gets the device model.
        /// </summary>
        /// <returns></returns>
        string GetModel();
        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <returns></returns>
        string GetLanguage();
        /// <summary>
        /// Gets the display.
        /// </summary>
        /// <returns></returns>
        string GetDisplay();
        /// <summary>
        /// Gets the sim identifier.
        /// </summary>
        /// <returns></returns>
        string GetSimId();
        /// <summary>
        /// Gets the os version.
        /// </summary>
        /// <returns></returns>
        string GetOSVersion();
        /// <summary>
        /// Gets the ip address.
        /// </summary>
        /// <returns></returns>
        Task<string> GetIPAddress();
        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        /// <returns></returns>
        string GetDeviceId();
        /// <summary>
        /// Gets if device is emulator.
        /// </summary>
        /// <returns></returns>
        bool GetIsEmulator();
        /// <summary>
        /// Gets the is compromised.
        /// </summary>
        /// <returns></returns>
        bool GetIsCompromised();
        /// <summary>
        /// Gets the application key.
        /// </summary>
        /// <returns></returns>
        string GetApplicationKey();
        /// <summary>
        /// Gets the application version number.
        /// </summary>
        /// <returns></returns>
        string GetApplicationVersionNumber();
        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <returns></returns>
        string GetApplicationName();
        /// <summary>
        /// Gets the device model.
        /// </summary>
        /// <returns>The device model.</returns>
        string GetDeviceModel();
        /// <summary>
        /// Gets the manufacturer.
        /// </summary>
        /// <returns>The manufacturer.</returns>
        string GetManufacturer();
        /// <summary>
        /// Go to developer options page
        /// </summary>
        void GoToDeveloperOptions();
        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        /// <returns>The unique identifier.</returns>
        string GetUniqueID();
    }
}
