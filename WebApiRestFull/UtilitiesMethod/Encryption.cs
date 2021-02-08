using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

    public class Encryption
    {
        public static string PasswordEncrypt(string inText)
        {
            string key = "@!1372&Fa";
            byte[] bytesBuff = Encoding.Unicode.GetBytes(inText);
            using (Aes aes__1 = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] {
            0x49,
            0x76,
            0x61,
            0x6e,
            0x20,
            0x4d,
            0x65,
            0x64,
            0x76,
            0x65,
            0x64,
            0x65,
            0x76
        });
                aes__1.Key = crypto.GetBytes(32);
                aes__1.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes__1.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    inText = Convert.ToBase64String(mStream.ToArray());
                }
            }
            return inText;
        }

        public static string PasswordDecrypt(string cryptTxt)
        {
            string key = "@!1372&Fa";
            cryptTxt = cryptTxt.Replace(" ", "+");
            byte[] bytesBuff = Convert.FromBase64String(cryptTxt);
            using (Aes aes__1 = Aes.Create())
            {
                Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key, new byte[] {
            0x49,
            0x76,
            0x61,
            0x6e,
            0x20,
            0x4d,
            0x65,
            0x64,
            0x76,
            0x65,
            0x64,
            0x65,
            0x76
        });
                aes__1.Key = crypto.GetBytes(32);
                aes__1.IV = crypto.GetBytes(16);
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes__1.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cStream.Write(bytesBuff, 0, bytesBuff.Length);
                        cStream.Close();
                    }
                    cryptTxt = Encoding.Unicode.GetString(mStream.ToArray());
                }
            }
            return cryptTxt;
        }

    }
