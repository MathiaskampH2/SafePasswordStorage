using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SafePasswordStorage
{
    /// <summary>
    /// InteractWithFile
    /// Class is responsible of getting and putting data to a file
    /// </summary>
    class InteractWithFile
    {
        // saves the password in base64String to a file
        public void SavePassword(string username, byte[] hashedPassword)
        {
            string path = (@".\userTable\" + username + "_pwd" + ".txt");


            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(Convert.ToBase64String(hashedPassword));
                sw.Close();
            }
        }

        // saves the salt in base64String to a file
        public void SaveSalt(string username, byte[] salt)
        {
            string path = (@".\userTable\" + username + "_salt" + ".txt");


            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(Convert.ToBase64String(salt));
                sw.Close();
            }
        }

        // method calls SavePassword and SaveSalt based on the inputs
        public void SaveCredentials(string username, byte[] hashedPassword, byte[] salt)
        {
            SavePassword(username, hashedPassword);
            SaveSalt(username, salt);
        }

        // method reads the password from the file based on the username
        public byte [] ReadPasswordFromFile(string username)
        {
            string path = (@".\userTable\" + username + "_pwd" + ".txt");
            string pwd = null;
            byte[] arrayPwd = null;
            using (StreamReader sr = new StreamReader(path))
            {
                pwd = sr.ReadLine();
            }

            return arrayPwd = Convert.FromBase64String(pwd);
        }

        // method reads the salt from the file based on the username
        public byte[] ReadSaltFromFile(string username)
        {
            string path = (@".\userTable\" + username + "_salt" + ".txt");
            string salt = null;
            byte[] arraySalt = null;
            using (StreamReader sr = new StreamReader(path))
            {
                salt = sr.ReadLine();
            }
            
            return arraySalt = Convert.FromBase64String(salt);
        }
    }
}