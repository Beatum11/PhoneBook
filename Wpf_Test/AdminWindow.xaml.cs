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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Getting records via site API
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

                var notes = JsonConvert.DeserializeObject<List<Note>>(text);
                testText.Text = notes[0].Show();
            }
        }

        /// <summary>
        /// Adding a note via API to a database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void addNote_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
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

        /// <summary>
        /// Removing any notes by ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void deleteNote_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                await client.DeleteAsync
                    ("https://localhost:7292/api/Notes/" + deleteInput.Text);
                deleteInput.Text = "";
            }

        }

        private async void editNote_Click(object sender, RoutedEventArgs e)
        {
           

            using (HttpClient client = new HttpClient())
            {
                EditWindow editW = new EditWindow();
                var response = await client.GetAsync("https://localhost:7292/api/Notes");

                response.EnsureSuccessStatusCode();

                var text = await response.Content.ReadAsStringAsync();
                var notes = JsonConvert.DeserializeObject<List<Note>>(text);

                var editId = int.Parse(editInput.Text);

                

                foreach (var neededNote in notes)
                {
                    if(neededNote.Id == editId)
                    {
                        editW.inputId.Text = neededNote.Id.ToString();
                        editW.surnameInput.Text = neededNote.Surname;
                        editW.nameInput.Text = neededNote.Name;
                        editW.fathNameInput.Text = neededNote.FathName;
                        editW.phoneNumInput.Text = neededNote.PhoneNumber;
                        editW.adressInput.Text = neededNote.Adress;
                        editW.extraInput.Text = neededNote.Description;
                    }
                }

                editW.Show();
            }
        }
    }
}
