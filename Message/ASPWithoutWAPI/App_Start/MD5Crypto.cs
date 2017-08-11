using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace ASPWithoutWAPI.App_Start
{
    public class MD5Crypto
    {
        static MD5CryptoServiceProvider MD5provider = new MD5CryptoServiceProvider();
        public static string getHashOfString(string input)
        {
            byte[] resByte = MD5provider.ComputeHash(Encoding.Unicode.GetBytes(input));
            string output = "";
            foreach (byte b in resByte)
                output += string.Format("{0:x2}", b);
            return output;
        } 
    }
}