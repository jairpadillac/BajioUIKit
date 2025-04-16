using System.Net.Http;
using Android.Net;
using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.Droid.DependencyServices;
using Javax.Net.Ssl;
using Xamarin.Android.Net;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidClientHandlerService))]
namespace BajioITUIKIT.Droid.DependencyServices
{
    #region Dependency service Methods
    /// <summary>
    /// IClientHandlerService implementation.
    /// </summary>
    public class AndroidClientHandlerService : IAndroidClientHandlerService
    {

        /// <summary>
        /// Returns the http client handler that bypasses ssl validation.
        /// </summary>
        /// <returns>The http client handler.</returns>
        public HttpClientHandler GetInsecureHttpsClientHandler()
        {
            return new BypassSslValidationClientHandler();
        }
    }
    #endregion

    #region public classes
    /// <summary>
    /// Bypass hostname verifier.
    /// </summary>
    public class BypassHostnameVerifier : Java.Lang.Object, IHostnameVerifier
    {
        /// <summary>
        /// Verify the specified hostname and session.
        /// </summary>
        /// <returns>The verify.</returns>
        /// <param name="hostname">Hostname.</param>
        /// <param name="session">Session.</param>
        public bool Verify(string hostname, ISSLSession session)
        {
            return true;
        }
    }

    /// <summary>
    /// Bypass ssl validation client handler.
    /// </summary>
    public class BypassSslValidationClientHandler : AndroidClientHandler
    {

        /// <summary>
        /// Bypass ssl validation client handler.
        /// </summary>
        protected override SSLSocketFactory ConfigureCustomSSLSocketFactory(HttpsURLConnection connection)
        {
            return SSLCertificateSocketFactory.GetInsecure(1000, null);
        }

        /// <summary>
        /// Gets the SSL Hostname verifier.
        /// </summary>
        /// <returns>The SSLH ostname verifier.</returns>
        /// <param name="connection">Connection.</param>
        protected override IHostnameVerifier GetSSLHostnameVerifier(HttpsURLConnection connection)
        {
            return new BypassHostnameVerifier();
        }
    }
    #endregion
}

