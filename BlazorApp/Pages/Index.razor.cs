using Contracts.Utils;
using Contracts.ViewModels;
using System.ComponentModel;
using System.Net.Http;

namespace BlazorApp.Pages
{
    public partial class Index
    {
        private List<DiscountedProductViewModel> discountedProductsVMs = new List<DiscountedProductViewModel>();
        protected async override void OnInitialized()
        {
            await UpdateDiscountedProducts();
        }

        private async Task UpdateDiscountedProducts()
        {
            var response = await ApiHelper.GetListAsync<DiscountedProductViewModel>($"{ApiUrl.AzureUrl}products/discounted");
            if (response == null)
            {
                // Manejar el caso cuando response es nulo
                // Puedes mostrar un mensaje de error o tomar otras acciones necesarias
            }
            else
            {
                discountedProductsVMs = response;
                Console.WriteLine("sdadsa");
            }
        }
    }
}