using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCrm.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ContactController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Contact>> GetContacts()
        {
            return await context.Contacts.Where(a=>!a.IsDeleted).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Contact> GetContact(int id)
        {
            return await context.Contacts.SingleAsync(a=>a.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Contact contact,CancellationToken cancellationToken)
        {
            await context.Contacts.AddAsync(contact, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,Contact contact, CancellationToken cancellationToken)
        {
            var contactToUpdate = await context.Contacts.SingleAsync(a=>a.Id == id, cancellationToken: cancellationToken);

            contactToUpdate.FirstName = contact.FirstName;
            contactToUpdate.LastName = contact.LastName;
            contactToUpdate.NickName = contact.NickName;
            contactToUpdate.Place = contact.Place;
            contactToUpdate.DateOfBirth = contact.DateOfBirth;

            await context.SaveChangesAsync(cancellationToken);
            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var contact = await context.Contacts.SingleAsync(a => a.Id == id, cancellationToken: cancellationToken);
            contact.IsDeleted = true;
            contact.DateDeleted = DateTime.Now;
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
