using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using BlazorApp;
using System.Net.Http;
using Contracts.Utils;

namespace BlazorApp.Pages
{
    public partial class OrderStatus
    {
        private string orderIdInput;
        private string result;
        [Inject]
        private HttpClient _httpClient { get; set; }

        private async Task ConsultarPedido()
        {
            try
            {
                // Build the API URL using the orderIdInput value
                string apiUrl = $"{ApiUrl.LocalUrl}orders/getOrderStatus/{orderIdInput}";
                // Make the API call and get the response
                string response = await ApiHelper.GetAsync<string>(apiUrl);
                // Handle the response
                if (!string.IsNullOrEmpty(response))
                {
                    var responseTrans = string.Empty;
                    switch (response)
                    {
                        case "Received":
                            responseTrans = "Pedido Recibido";
                            break;
                        case "Preparing":
                            responseTrans = "Pedido en Preparación";
                            break;
                        case "Shipped":
                            responseTrans = "Pedido Enviado";
                            break;
                    }

                    result = responseTrans;
                }
                else
                {
                    // Handle the case where the response is empty or an error occurred
                    result = "Failed to fetch the order status.";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., log the error
                result = "An error occurred: " + ex.Message;
            }
        }
    }
}