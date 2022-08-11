using System.ComponentModel.DataAnnotations;

namespace ASP_MVC_Test.Models
{
    public class BookViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Surname { get; set; } 

        public string Name { get;set; }

        public string FathName { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }  

        public string Description { get; set; }

        #region Конструкторы
        public BookViewModel(int id, string surname, string name, string fathName, string phoneNumber, string adress, string description)
        {
            Id = id;
            Surname = surname;
            Name = name;
            FathName = fathName;
            PhoneNumber = phoneNumber;
            Adress = adress;
            Description = description;
        }

        public BookViewModel()
        {

        }
        #endregion
    }
}
