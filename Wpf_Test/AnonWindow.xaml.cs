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

namespace Wpf_Test
{
    /// <summary>
    /// Логика взаимодействия для AnonWindow.xaml
    /// </summary>
    public partial class AnonWindow : Window
    {
        public AnonWindow()
        {
            InitializeComponent();
        }

        private async void get_Button_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7292/api/Notes");

                response.EnsureSuccessStatusCode();
                testText.Text = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
