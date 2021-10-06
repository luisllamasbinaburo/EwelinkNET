using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EwelinkNet.Helpers
{
    public static class CryptoHelper
    {

        internal static string MakeAuthorizationSign(string message)
        {
            var encoding = new UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(Constants.AppData.APP_SECRET);

            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        internal static (string output, string iv) Encrypt(string input, string password)
        {
            byte[] encrypted;
            byte[] IV;
            byte[] Salt = GetSalt();

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = CreateMD5(password);
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.GenerateIV();
                IV = aesAlg.IV;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(input);
                        }
                        encrypted = memoryStream.ToArray();
                    }
                }
            }

            return (Convert.ToBase64String(encrypted.ToArray()), Convert.ToBase64String(IV.ToArray()));
        }


        internal static string Decrypt(string input, string iv, string password)
        {
            string decrypted;

            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = CreateMD5(password);
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.IV = Convert.FromBase64String(iv);

                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                var encoded = Convert.FromBase64String(input);

                using (var memoryStream = new MemoryStream(encoded))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            decrypted = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }

        private static byte[] CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                return md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }


        private static readonly int iterations = 1000;
        private static byte[] CreateKey(string password, byte[] salt)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterations))
                return rfc2898DeriveBytes.GetBytes(32);
        }

        private static byte[] GetSalt()
        {
            var salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

    }
}

