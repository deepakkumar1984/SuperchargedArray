using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SpicyNLP
{
    public class Helper
    {
        private static MD5 md5 = System.Security.Cryptography.MD5.Create();
        public static string GetHash(string s)
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(s);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
