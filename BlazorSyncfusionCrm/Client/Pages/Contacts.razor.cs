using BlazorSyncfusionCrm.Shared;
using Syncfusion.Blazor.Popups;
using System.Net.Http.Json;

namespace BlazorSyncfusionCrm.Client.Pages
{
    public partial class Contacts
    {
        Contact? contactToDelete;

        private List<Contact> gridData = new List<Contact>();
        bool isVisible = false;
        private DialogEffect animationEffect = DialogEffect.Fade;


        protected override async Task OnInitializedAsync()
        {
            await GetGridData();
        }


        private void EditContact(int id)
        {
            NavigationManager.NavigateTo("contacts/edit/" + id);
        }

        private void DeleteContact(Contact contact)
        {
            isVisible = true;
            contactToDelete = contact;
        }

        private void CancelDelete()
        {
            this.isVisible = false;
        }

        private async Task ConfirmDelete()
        {
            this.isVisible = false;

            await HttpClient.DeleteAsync($"api/Contact/{contactToDelete!.Id}");

            await GetGridData();
        }

        private async Task GetGridData()
        {
            var result = await HttpClient.GetFromJsonAsync<List<Contact>>("api/Contact");

            if (result != null)
                gridData = result;
        }
    }
}
