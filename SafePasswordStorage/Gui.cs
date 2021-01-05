using System;
using System.Threading;

namespace SafePasswordStorage
{
    class Gui
    {
        public void Menu()
        {
            Console.WriteLine("1. Create user");
            Console.WriteLine("2. Login");
        }

        public void HashMenu()
        {
            Console.WriteLine("1. SHA256");
            Console.WriteLine("2. PBKDF2");
        }
    }
}