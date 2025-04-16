using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using PrestamosPerugia.Mobile.Droid.DependencyServices;
using Xamarin.Forms;
using BajioITUIKIT.DependencyServices;

[assembly: Dependency(typeof(AesCryptEngine))]
namespace BajioITUIKIT.Droid.DependencyServices
{
    public class AesCryptEngine : IObjectCryptEngine
    {
        #region private properties
        private static readonly int cryptoKeySizeInBytes = 32;
        private static readonly int cryptoBlockSizeInBytes = 16;
        private string _cryptoKey;
        private byte[] _keyBytes;
        private bool _initialized;
        #endregion
        #region Private ByteArray methods​
        /// <summary>
        /// Converts a string to bytes array, with the given lenght
        /// </summary>
        private byte[] GetByteArray(string text, int requiredLength)
        {
            var result = new byte[requiredLength];
            byte[] textBytes = Encoding.UTF8.GetBytes(text);
            int offset = 0;
            while (offset < requiredLength)
            {
                int toCopy = (requiredLength >= (offset + textBytes.Length)) ?
                    textBytes.Length : requiredLength - offset;
                System.Buffer.BlockCopy(textBytes, 0, result, offset, toCopy);
                offset += toCopy;
            }
            return result;
        }

        /// <summary>
        /// Returns a random array of bytes for the encryptation
        /// </summary>
        private byte[] GetRandomBytes(int requiredLength)
        {
            if (requiredLength < 0) { requiredLength = 0; }
            byte[] result = (requiredLength == 0) ? new byte[] { } : new byte[requiredLength];

            if (requiredLength > 0)
            {
                (new Random()).NextBytes(result);
            }

            return result;
        }

        /// <summary>
        /// Splitting bytesToDecrypt into IV (Item1) and encrypted bytes (Item2)
        /// </summary>
        private Tuple<byte[], byte[]> SplitByteArray(byte[] byteArray, int firstArrayLength)
        {
            byte[] array1 = byteArray;
            byte[] array2 = null;

            if (firstArrayLength < 1) { throw new ArgumentOutOfRangeException(nameof(firstArrayLength)); }

            if (byteArray != null && byteArray.Length > firstArrayLength)
            {
                array1 = new byte[firstArrayLength];
                array2 = new byte[byteArray.Length - firstArrayLength];
                System.Buffer.BlockCopy(byteArray, 0, array1, 0, firstArrayLength);
                System.Buffer.BlockCopy(byteArray, firstArrayLength, array2, 0, array2.Length);
            }

            return Tuple.Create(array1, array2);
        }

        /// <summary>
        /// Reverts the split byte array process
        /// </summary>
        private byte[] JoinByteArrays(byte[] byteArray1, byte[] byteArray2)
        {
            byte[] result = byteArray1;

            if (byteArray2 != null)
            {
                if (byteArray1 == null || byteArray1.Length == 0)
                {
                    result = byteArray2;
                }
                else if (byteArray2.Length > 0)
                {
                    result = new byte[byteArray1.Length + byteArray2.Length];
                    System.Buffer.BlockCopy(byteArray1, 0, result, 0, byteArray1.Length);
                    System.Buffer.BlockCopy(byteArray2, 0, result, byteArray1.Length, byteArray2.Length);
                }
            }

            return result;
        }
        
        #endregion

        #region public methods
        //Parameterless constructor required for Xamarin.Forms when using Dependency Service
        public AesCryptEngine() { }

        public AesCryptEngine(string cryptoKey)
        {
            if (cryptoKey == null) { throw new ArgumentNullException(nameof(cryptoKey)); }
            if (String.IsNullOrWhiteSpace(cryptoKey)) { throw new ArgumentOutOfRangeException(nameof(cryptoKey)); }
            Initialize(new Dictionary<string, object>() { { "CryptoKey", cryptoKey } });
        }

        /// <summary>
        /// Initialices the encryptation engine with the given crypto key
        /// </summary>
        /// <returns>The initialize.</returns>
        /// <param name="cryptoKey">Crypto key.</param>
        public void Initialize(string cryptoKey)
        {
            if (cryptoKey == null) { throw new ArgumentNullException(nameof(cryptoKey)); }
            if (String.IsNullOrWhiteSpace(cryptoKey)) { throw new ArgumentOutOfRangeException(nameof(cryptoKey)); }
            Initialize(new Dictionary<string, object>() { { "CryptoKey", cryptoKey } });
        }

        /// <summary>
        /// Initialices the encrypation engine with the given params, must contain the CryptoKey Object
        /// </summary>
        public void Initialize(Dictionary<string, object> cryptoParams)
        {
            if (cryptoParams == null) { throw new ArgumentNullException(nameof(cryptoParams)); }
            if ((!cryptoParams.ContainsKey("CryptoKey"))
                || String.IsNullOrWhiteSpace(cryptoParams["CryptoKey"]?.ToString()))
            {
                throw new ArgumentException("The 'CryptoKey' value is missing or empty.", nameof(cryptoParams));
            }

            _cryptoKey = cryptoParams["CryptoKey"].ToString();

            if (_cryptoKey != _cryptoKey.Trim())
            {
                throw new ArgumentException("The 'CryptoKey' value cannot have leading or trailing whitespace.", nameof(cryptoParams));
            }

            _keyBytes = GetByteArray(_cryptoKey, cryptoKeySizeInBytes);
            _initialized = true;
        }

        /// <summary>
        /// Returns the unencrypted object
        /// </summary>
        public T DecryptObject<T>(string stringToDecrypt, bool throwExceptionOnNullObject = false)
        {
            if (!_initialized)
            {
                throw new Exception("Crypt engine is not initialized.");
            }
            T result = default(T);
            if (!String.IsNullOrWhiteSpace(stringToDecrypt))
            {
                byte[] bytesToDecrypt = Convert.FromBase64String(stringToDecrypt);
                byte[] decryptedBytes = null;
                using (var aesProvider = new AesCryptoServiceProvider()
                {
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    KeySize = (cryptoKeySizeInBytes * 8), //KeySize in bits
                    BlockSize = (cryptoBlockSizeInBytes * 8), //BlockSize in bits
                    Key = _keyBytes
                })
                {
                    //Splitting bytesToDecrypt into IV (Item1) and encrypted bytes (Item2)
                    var splitBytes = SplitByteArray(bytesToDecrypt, cryptoBlockSizeInBytes);
                    if (splitBytes.Item2 != null && splitBytes.Item2.Length > 0)
                    {
                        aesProvider.IV = splitBytes.Item1;
                        decryptedBytes = aesProvider.CreateDecryptor().TransformFinalBlock(splitBytes.Item2, 0, splitBytes.Item2.Length);
                    }
                }
                if (decryptedBytes != null)
                {
                    result = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(decryptedBytes));
                }
                else if (throwExceptionOnNullObject)
                {
                    throw new Exception("The object to be decrypted was null or empty.");
                }
            }
            else if (throwExceptionOnNullObject)
            {
                if (stringToDecrypt == null) { throw new ArgumentNullException(nameof(stringToDecrypt)); }
                if (String.IsNullOrWhiteSpace(stringToDecrypt)) { throw new ArgumentOutOfRangeException(nameof(stringToDecrypt)); }
            }
            return result;
        }

        //Encrytps any given object serialized
        public string EncryptObject(object objectToEncrypt)
        {
            if (!_initialized)
            {
                throw new Exception("Crypt engine is not initialized.");
            }
            string result = null;
            if (objectToEncrypt != null)
            {
                byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(objectToEncrypt));
                using (var aesProvider = new AesCryptoServiceProvider()
                {
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    KeySize = (cryptoKeySizeInBytes * 8), //KeySize in bits
                    BlockSize = (cryptoBlockSizeInBytes * 8), //BlockSize in bits
                    Key = _keyBytes
                })
                {
                    aesProvider.GenerateIV();
                    byte[] encryptedBytes = aesProvider.CreateEncryptor().TransformFinalBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);
                    result = Convert.ToBase64String(JoinByteArrays(aesProvider.IV, encryptedBytes));
                }
            }
            result = result ?? Convert.ToBase64String(GetRandomBytes(cryptoBlockSizeInBytes));

            return result;
        }

        //Disposes the crypto engine
        public void Dispose()
        {
            _cryptoKey = null;
            _keyBytes = null;
        }
        #endregion
    }
}