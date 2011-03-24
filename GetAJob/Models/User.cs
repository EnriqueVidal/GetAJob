using System;
using System.Net;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace GetAJob.Models
{
	/// <summary>
    /// Represent a user
    /// </summary>
	public partial class User : EntityBase
	{
		public virtual string Password { get; set; }
		public virtual string UserName { get; set; }
		public virtual string Email { get; set; }
		public virtual string PasswordHash { get; set; }
		public virtual string Salt { get; set; }

		public virtual Person Person { get; set; }

		public User() { }

		/// <summary>
		/// This method returns true or false depending if the email is valid or not
		/// </summary>
		/// <returns>bool</returns>
		public bool EmailIsValid()
		{
			return Regex.IsMatch(this.Email, @"^([\w\.%\+\-]+)@([\w\-]+\.)+([\w]{2,})$");
		}

		/// <summary>
		/// This method creates a password salt and password hash for the user to be saved
		/// </summary>
		public void PrepareForSave()
		{
			this.CreateSalt();
			this.CalculateSHA1();
		}

		/// <summary>
        /// This method creates a random password salt and returns it as a string
        /// </summary>
        /// <returns>BitConverter</returns>
        private string CreateSalt()
        {
            byte[] saltData = new byte[4];
		    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(saltData);

            this.Salt = BitConverter.ToString(saltData).Replace("-", "");
			return this.Salt;
        }
		
		/// <summary>
        /// This method receives the password entered by the user and returns the calculated hash
        /// </summary>
        /// <returns></returns>
        private string CalculateSHA1()
        {
			this.PasswordHash = CalculateSHA1(this.Password + this.Salt, Encoding.Default);
            return this.PasswordHash;
        }

        static string CalculateSHA1(string text, Encoding enc)
        {
            byte[] buffer = enc.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }
	}
}