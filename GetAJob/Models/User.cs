using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GetAJob.Persistence.Entities
{
	public partial class User
	{

		/// <summary>
        /// This method creates a random password salt and returns it as a string
        /// </summary>
        /// <returns></returns>
        public static string CreateSalt()
        {
            byte[] saltData = new byte[4];
		    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltData);

            return BitConverter.ToString(saltData).Replace("-", "");
        }
		
		
		/// <summary>
        /// This method receives the password entered by the user and returns the calculated hash
        /// </summary>
        /// <param name="password">Password entered by the user</param>
        /// <param name="salt">Salt generated with the CreateSalt() mehtod</param>
        /// <returns></returns>
        public static string CalculateSHA1(string password, string salt)
        {
            return CalculateSHA1(password + salt, Encoding.Default);
        }

        static string CalculateSHA1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }

	}
}

