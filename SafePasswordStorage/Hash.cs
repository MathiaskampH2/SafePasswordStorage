using System;
using System.Net.Configuration;
using System.Security.Cryptography;

namespace SafePasswordStorage
{
    /// <summary>
    /// class Hash
    /// has the purpose of hashing a password with either SHA256 or PBKDF2
    /// </summary>
    class Hash
    {
        // constant variables
        const int numberOfIterations = 50000;
        const int saltLength = 32;

        // method generates a 32bit random salt
        public byte[] GenerateSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[saltLength];
                rng.GetBytes(randomNumber);

                return randomNumber;
            }
        }
        
        // method combines the password and the salt
        private byte[] CombinePasswordAndSalt(byte[] password, byte[] salt)
        {
            byte[] result = new byte[password.Length + salt.Length];

            Buffer.BlockCopy(password, 0, result, 0, password.Length);
            Buffer.BlockCopy(salt, 0, result, password.Length, salt.Length);

            return result;
        }

        // method hashes the combined password
        public byte[] HashPasswordWithSaltSHA256(byte[] toBeHashed, byte[] salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(CombinePasswordAndSalt(toBeHashed, salt));
            }
        }

        // method hashes the salted password with RFC2898
        // it hashes the password 50000 times
        public byte[] hashPasswordWithSaltPBKDF2(byte[] toBeHashed, byte[] salt)
        {
            using (Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfIterations))
            {
                return rfc2898.GetBytes(saltLength);
            }
        }
    }
}