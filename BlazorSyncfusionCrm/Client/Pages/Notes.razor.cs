using System.Net.Http.Json;
using BlazorSyncfusionCrm.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorSyncfusionCrm.Client.Pages
{
    public partial class Notes
    {
        private List<Note> NoteList = new List<Note>();

        public Notes(NavigationManager navigationManager)
        {
            NavigationManager = navigationManager;
        }

        protected NavigationManager NavigationManager { get; }

        protected override async Task OnInitializedAsync()
        {
            var result = await httpClient.GetFromJsonAsync<List<Note>>("api/Note");
            if (result is not null)
                NoteList = result;
        }


        private void NavigateToContact(int contactId)
        {
            NavigationManager.NavigateTo("contacts/edit/" + contactId);
        }
    }
}
