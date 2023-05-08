using BlazorSyncfusionCrm.Server.Data;
using BlazorSyncfusionCrm.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorSyncfusionCrm.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        
        public NoteController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllNotes()
        {
            var notes = await context.Notes
                                              .Include(a => a.Contact)
                                              .OrderByDescending(a => a.DateCreated)
                                              .ToListAsync();

            return Ok(notes);
        }

        [HttpGet("{contactId}")]
        public async Task<ActionResult> GetNoteByContactId(int contactId)
        {
            var notes = await context.Notes
                                              .Where(a=>a.ContactId == contactId)
                                              .Include(a => a.Contact)
                                              .OrderByDescending(a => a.DateCreated)
                                              .ToListAsync();

            return Ok(notes);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Note note)
        {
            await context.Notes.AddAsync(note);
            await context.SaveChangesAsync();
            return await GetNoteByContactId(note.ContactId.Value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var note = await context.Notes.SingleAsync(a => a.Id == id);
            context.Notes.Remove(note);
            await context.SaveChangesAsync();
            return await GetNoteByContactId(note.ContactId.Value);
        }
    }
}
