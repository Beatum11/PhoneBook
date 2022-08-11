using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Test.Classes
{
    internal class Note
    {

        #region Поля

        public int Id { get; set; }
        public string Surname { get; set; }

        public string Name { get; set; }

        public string FathName { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }

        public string Description { get; set; }
        #endregion

        #region Конструкторы
        public Note(string surname, string name, string fathName, string phoneNum, string adress,
                    string description)
        {
            Surname = surname;
            Name = name;
            FathName = fathName;
            PhoneNumber = phoneNum;
            Adress = adress;
            Description = description;
        }
        #endregion

        public string Show()
        {
            string s = $"Id: {Id}\nФамилия: {Surname}\nИмя: {Name}\nОтчество: {FathName}" +
                       $"\nНомер телефона: {PhoneNumber}" +
                       $"\nАдрес: {Adress}\nДоп. Информация: {Description}\n";
            return s;
        }

    }
}
