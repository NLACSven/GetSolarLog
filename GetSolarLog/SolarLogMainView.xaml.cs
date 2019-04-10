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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonPost, Encoding.UTF8,"application/json");
                HttpResponseMessage response = await client.PostAsync(resourceAddress, content).ConfigureAwait(true);
                string resp = await response.Content.ReadAsStringAsync().ConfigureAwait(true);

                JObject jObject = JObject.Parse(resp);
                

                LiveData liveData = new LiveData(jObject);
            }
        }
    }

    public class LiveData
    {
        public LiveData(JObject jObject)
        {
            string d100 = jObject["801"]["170"]["100"].Value<string>();
            LastUpdateTime = DateTime.Parse(d100);

            long d101 = jObject["801"]["170"]["101"].Value<long>();
            long d102 = jObject["801"]["170"]["102"].Value<long>();
            long d103 = jObject["801"]["170"]["103"].Value<long>();
            long d104 = jObject["801"]["170"]["104"].Value<long>();
            long d105 = jObject["801"]["170"]["105"].Value<long>();
            long d106 = jObject["801"]["170"]["106"].Value<long>();
            long d107 = jObject["801"]["170"]["107"].Value<long>();
            long d108 = jObject["801"]["170"]["108"].Value<long>();
            long d109 = jObject["801"]["170"]["109"].Value<long>();
            long d110 = jObject["801"]["170"]["110"].Value<long>();
            long d111 = jObject["801"]["170"]["111"].Value<long>();
            long d112 = jObject["801"]["170"]["112"].Value<long>();
            long d113 = jObject["801"]["170"]["113"].Value<long>();
            long d114 = jObject["801"]["170"]["114"].Value<long>();
            long d115 = jObject["801"]["170"]["115"].Value<long>();
            long d116 = jObject["801"]["170"]["116"].Value<long>();

            Pac = Convert.ToDouble(d101);
            Pdc = Convert.ToDouble(d102);
            Uac = Convert.ToDouble(d103);
            Udc = Convert.ToDouble(d104);
            YieldDay = Convert.ToDouble(d105);
            YieldYesterday = Convert.ToDouble(d106);
            YieldMonth = Convert.ToDouble(d107);
            YieldYear = Convert.ToDouble(d108);
            YieldTotal = Convert.ToDouble(d109);
            ConsPac = Convert.ToDouble(d110);
            ConsYieldDay = Convert.ToDouble(d111);
            ConsYieldYesterday = Convert.ToDouble(d112);
            ConsYieldMonth = Convert.ToDouble(d113);
            ConsYieldYear = Convert.ToDouble(d114);
            ConsYieldTotal = Convert.ToDouble(d115);
            TotalPower = Convert.ToDouble(d116);
        }

        private DateTime LastUpdateTime { get; set; }
        private double Pac { get; set; }
        private double Pdc { get; set; }
        private double Uac { get; set; }
        private double Udc { get; set; }
        private double YieldDay { get; set; }
        private double YieldYesterday { get; set; }
        private double YieldMonth { get; set; }
        private double YieldYear { get; set; }
        private double YieldTotal { get; set; }
        private double ConsPac { get; set; }
        private double ConsYieldDay { get; set; }
        private double ConsYieldYesterday { get; set; }
        private double ConsYieldMonth { get; set; }
        private double ConsYieldYear { get; set; }
        private double ConsYieldTotal { get; set; }
        private double TotalPower { get; set; }
    }
}
