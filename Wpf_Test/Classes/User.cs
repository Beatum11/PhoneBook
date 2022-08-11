using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Test.Classes
{
    internal class User
    {
        public string Role { get; set; }


        #region Конструкторы

        public User(string role)
        {
            Role = role;
        }

        #endregion


    }
}
