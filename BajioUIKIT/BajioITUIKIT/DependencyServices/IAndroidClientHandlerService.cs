using System.Net.Http;

namespace BajioITUIKIT.DependencyServices
{
    public interface IAndroidClientHandlerService
    {
        HttpClientHandler GetInsecureHttpsClientHandler();
    }
}
