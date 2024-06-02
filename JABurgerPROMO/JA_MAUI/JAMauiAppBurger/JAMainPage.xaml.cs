using Newtonsoft.Json;
using JAMauiAppBurger.Models;
namespace JAMauiAppBurger
{
    public partial class JAMainPage : ContentPage
    {

        public JAMainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5042/api/");
            var response = client.GetAsync("ja_burger").Result;
            if (response.IsSuccessStatusCode)
            {
                var burgers = response.Content.ReadAsStringAsync().Result;
                var burgersList = JsonConvert.DeserializeObject<List<JA_Burger>>(burgers);

                listView.ItemsSource = burgersList;

            }
        }
    }
}
