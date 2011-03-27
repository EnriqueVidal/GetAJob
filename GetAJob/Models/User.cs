using System;
using System.Net;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace GetAJob.Models
{
	/// <summary>
    /// Represent a user
    /// </summary>
	public partial class User : EntityBase
	{
		private string password;
		
		[Required(ErrorMessage = "Password is Required")]
		[RegularExpression("[\\S]{6,}", ErrorMessage = "Must be at least 6 characters.")]
		public virtual string Password { 
			get { return this.password; } 
			set {
				this.password = value;
				this.Salt = this.CreateSalt();
				this.PasswordHash = this.CalculateSHA1();
			}
		}

		[Required(ErrorMessage = "Username is Required")]
		[StringLength(12, ErrorMessage = "Username must be under 12 characters")]
		public virtual string UserName { get; set; }
		
		[Required(ErrorMessage = "Email is Required")]
		[RegularExpression(@"^([\w\.%\+\-]+)@([\w\-]+\.)+([\w]{2,})$", ErrorMessage = "Not valid Email")]
		public virtual string Email { get; set; }
		
		public virtual string PasswordHash { get; private set; }
		public virtual string Salt { get; private set; }

		public virtual Person Person { get; set; }

		public User() { }

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