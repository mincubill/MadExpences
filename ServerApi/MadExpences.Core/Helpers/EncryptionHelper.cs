using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MadExpences.Core.Helpers
{
    public class EncryptionHelper
    {
        public class PasswordEncryptionHelper
        {
            private string _key = "Palito4018313";
            public string EncryptPass(string pass)
            {
                UTF8Encoding encoder = new UTF8Encoding();
                MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
                var key = md5Provider.ComputeHash(encoder.GetBytes(_key));
                using (TripleDESCryptoServiceProvider DESProvider = new TripleDESCryptoServiceProvider())
                {
                    DESProvider.Key = key;
                    DESProvider.Mode = CipherMode.ECB;
                    DESProvider.Padding = PaddingMode.PKCS7;
                    ICryptoTransform encryptor = DESProvider.CreateEncryptor();
                    var data = encoder.GetBytes(pass);
                    var result = encryptor.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(result);
                }
            }
            public string DescryptPass(string hash)
            {
                UTF8Encoding encoder = new UTF8Encoding();
                MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
                var key = md5Provider.ComputeHash(encoder.GetBytes(_key));
                using (TripleDESCryptoServiceProvider DESProvider = new TripleDESCryptoServiceProvider())
                {
                    DESProvider.Key = key;
                    DESProvider.Mode = CipherMode.ECB;
                    DESProvider.Padding = PaddingMode.PKCS7;
                    ICryptoTransform decryptor = DESProvider.CreateDecryptor();
                    var data = Convert.FromBase64String(hash);
                    var result = decryptor.TransformFinalBlock(data, 0, data.Length);
                    return encoder.GetString(result);
                }
            }
        }
    }
}
