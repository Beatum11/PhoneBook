using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf_Test.Classes;
using Newtonsoft.Json;

namespace Wpf_Test
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        private async void editNote_Click(object sender, RoutedEventArgs e)
        {

            using (HttpClient client = new HttpClient())
            {
                
                var note = new Note(surnameInput.Text, nameInput.Text, fathNameInput.Text,
                                    phoneNumInput.Text, adressInput.Text, extraInput.Text);

                var newPostJson = JsonConvert.SerializeObject(note);
                var payload = new StringContent (newPostJson, Encoding.UTF8, "application/json");

                await client.PutAsync("https://localhost:7292/api/Notes/" + 
                                       int.Parse(inputId.Text), 
                                       payload);
            }
        }
    }
}
