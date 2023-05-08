using BlazorSyncfusionCrm.Client.Components;
using System.Net.Http.Json;
using BlazorSyncfusionCrm.Shared;
using Microsoft.AspNetCore.Components;


namespace BlazorSyncfusionCrm.Client.Pages
{
    public partial class EditContact
    {
        [Parameter]
        public int? Id { get; set; }

        public Contact Contact { get; set; } = new Contact();


        protected override async Task OnInitializedAsync()
        {
            if (Id is not null)
            {
                var result = await HttpClient.GetFromJsonAsync<Contact>($"api/Contact/{Id}");
                if (result != null)
                    Contact = result;
            }

        }

        private async Task HandleSubmit()
        {
            HttpResponseMessage response;

            if (Id is not null)
                response = await HttpClient.PutAsJsonAsync($"api/contact/{Contact.Id}", Contact);
            else
                response = await HttpClient.PostAsJsonAsync($"api/contact", Contact);

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadFromJsonAsync<Contact>();

                if (jsonResult is not null)
                    Contact = jsonResult;

                ShowToast();

                NavigationManager.NavigateTo("/contacts");
            }
        }

        private void ShowToast()
        {
            this.ToastService.ShowToast(new ToastOption()
            {
                Title = "successful",
                Content = "operation was successful"
            });
        }
    }
}
