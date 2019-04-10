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
using System.Net.Http.Headers;
using System.J;

namespace GetSolarLog
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string resourceAddress = "http://192.168.1.43/getjp";
            string jsonPost = "{\"801\":{\"170\":null}}";

            using (var client = new HttpClient())
            {
                var content = new StringContent(jsonPost, Encoding.UTF8,"application/json");
                var response = await client.PostAsync(resourceAddress, content).ConfigureAwait(true);
                string resp = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

                Json
                ResponseTextBox.Text = resp;
            }
        }
    }
}
