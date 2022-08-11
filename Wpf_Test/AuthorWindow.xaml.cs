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
using Newtonsoft.Json;
using Wpf_Test.Classes;

namespace Wpf_Test
{
    /// <summary>
    /// Логика взаимодействия для AuthorWindow.xaml
    /// </summary>
    public partial class AuthorWindow : Window
    {
        public AuthorWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получение записей через API сайта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void get_Button_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7292/api/Notes");

                response.EnsureSuccessStatusCode();

                var text = await response.Content.ReadAsStringAsync();

                testText.Text = text;




                //var notes = JsonConvert.DeserializeObject<List<Note>>(text);

                //foreach (var item in notes)
                //{
                //    testText.Text = item.Show();
                //}
            }
        }

        /// <summary>
        /// Добавление записи через API сайта в БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void addNote_Click(object sender, RoutedEventArgs e)
        {
            using(HttpClient client = new HttpClient())
            {

                var note = new Note(surnameInput.Text, nameInput.Text, fathNameInput.Text,
                                    phoneNumInput.Text, adressInput.Text, extraInput.Text);

                var newPostJson = JsonConvert.SerializeObject(note);

                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");

                await client.PostAsync("https://localhost:7292/api/Notes", payload);


                surnameInput.Text = "";
                nameInput.Text = "";
                fathNameInput.Text = "";
                phoneNumInput.Text = "";
                adressInput.Text = "";
                extraInput.Text = "";
            }
        }
    }
}
