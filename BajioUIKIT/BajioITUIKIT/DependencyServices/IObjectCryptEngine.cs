using System.Collections.Generic;

namespace BajioITUIKIT.DependencyServices
{
    public interface IObjectCryptEngine
    {
        T DecryptObject<T>(string stringToDecrypt, bool throwExceptionPnNullObject = false);
        string EncryptObject(object objectToEncrypt);
        void Initialize(string cryptoKey);
        void Initialize(Dictionary<string, object> cryptoParams);
    }
}
