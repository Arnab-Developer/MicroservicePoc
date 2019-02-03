using System.Collections.Generic;
using MicroservicePoc.Service.Entry.Api.Data;
using MicroservicePoc.Service.Entry.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePoc.Service.Entry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private EntryContext _context;

        public EntryController(EntryContext context)
        {
            _context = context;    
        }

        [Route("get")]
        [HttpGet]
        public ActionResult<IList<EntryItem>> GetAll()
        {
            return _context.Entries
                .OrderByDescending(e => e.CreationDate)
                .ToList();
        }

        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<EntryItem> GetById(int id)
        {
            return _context.Entries
                .Single(c => c.Id == id);
        }

        [Route("add")]
        [HttpPut]
        public ActionResult Add(EntryItem entry)
        {
            return PerformCrud(entry, EntityState.Added);
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Update(EntryItem entry)
        {
            return PerformCrud(entry, EntityState.Modified);
        }

        [Route("remove")]
        [HttpDelete]
        public ActionResult Remove(EntryItem entry)
        {
            return PerformCrud(entry, EntityState.Deleted);
        }

        private ActionResult PerformCrud(EntryItem entry, EntityState state)
        {
            _context.Entries.Attach(entry).State = state;
            _context.SaveChanges();
            return Ok();
        }
    }
}