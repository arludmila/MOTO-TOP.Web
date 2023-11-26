using Contracts.DTOs.Relationships;
using Contracts.Utils;
using global::Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class Contact

    {
        private HttpClient _httpClient;
        private List<string> cities = new List<string>();
        private SellerClientDto sellerClientDto = new SellerClientDto();
        protected override void OnInitialized()
        {
            // Create and configure an HttpClient instance.
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ApiUrl.LocalUrl);
        }
        private void ProvinceChanged(ChangeEventArgs e)
        {
            string selectedProvince = e.Value.ToString();
            cities = GetCitiesForProvince(selectedProvince);
            province = selectedProvince;
        }

        private List<string> GetCitiesForProvince(string province)
        {
            if (province == "Corrientes")
            {
                return new List<string>
                {
                    "Corrientes",
                    "Goya",
                    "Mercedes",
                    "Curuz� Cuati�",
                    "Esquina",
                    "Ituzaing�",
                    "Paso de los Libres",
                    "Santo Tom�",
                    "Monte Caseros",
                    "Bella Vista"
                };
            }
            else if (province == "Chaco")
            {
                return new List<string>
                {
                    "Resistencia",
                    "Roque S�enz Pe�a",
                    "Villa �ngela",
                    "Charata",
                    "Juan Jos� Castelli",
                    "General Jos� de San Mart�n",
                    "Barranqueras"
                };
            }
            else if (province == "Misiones")
            {
                return new List<string>
                {
                    "Posadas",
                    "Puerto Iguaz�",
                    "Eldorado",
                    "Ober�",
                    "Apostoles",
                    "San Vicente",
                    "Garup�",
                    "Montecarlo",
                    "Alem",
                    "Jard�n Am�rica"
                };
            }
            else
            {
                return new List<string>();
            }
        }
        private string firstName;
        private string lastName;
        private string province;
        private string city;
        private string address;
        private string phoneNumber;
        private string email;
        private string message;


        private async Task CreateSellerClientVisit()
        {
            sellerClientDto = new SellerClientDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Location = $"{province}, {city}, {address}",
                PhoneNumber = phoneNumber,
                Email = email,
                Message = message
            };

            string response = await ApiHelper.PostAsync($"{ApiUrl.LocalUrl}seller-clients", sellerClientDto);

            if (response.Contains("error") || response.Contains("failed"))
            {
                // TODO: ?????
            }
            else
            {

            }



        }
    }
}