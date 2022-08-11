using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;

namespace Wpf_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if(roleInput.Text == "anon")
            {
                AnonWindow anonW = new AnonWindow();
                anonW.Show();
                this.Hide();
            } 
            else if(roleInput.Text == "author")
            {
                AuthorWindow authorW = new AuthorWindow();
                authorW.Show();
                this.Hide();
            } 
            else if(roleInput.Text == "admin")
            {
                AdminWindow adminW = new AdminWindow();
                adminW.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Wrong information!");
            }
            
        }
    }
}
