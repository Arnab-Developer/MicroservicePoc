using Microsoft.AspNetCore.Mvc;
using Centre.Api.Models;
using Centre.Api.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Centre.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentreController : ControllerBase
    {
        private CentreContext _context;

        public CentreController(CentreContext context)
        {
            _context = context;
        }

        [Route("get")]
        [HttpGet]
        public ActionResult<IList<CentreItem>> GetAll()
        {
            var centres = _context.Centres
                .OrderBy(c => c.Name)
                .ToList();
            return centres;
        }

        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<CentreItem> GetById(int id)
        {
            var centre = _context.Centres
                .Single(c => c.Id == id);
            return centre;
        }

        [Route("get/{name}")]
        [HttpGet]
        public ActionResult<IList<CentreItem>> GetByName(string name)
        {
            var centres = _context.Centres
                .Where(c => c.Name == name)
                .OrderBy(c => c.Name)
                .ToList();
            return centres;
        }

        [Route("add")]
        [HttpPut]
        public ActionResult Add(CentreItem centre)
        {
            return PerformCrud(centre, EntityState.Added);
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Update(CentreItem centre)
        {
            return PerformCrud(centre, EntityState.Modified);
        }

        [Route("remove")]
        [HttpPost]
        public ActionResult Remove(CentreItem centre)
        {
            return PerformCrud(centre, EntityState.Deleted);
        }

        private ActionResult PerformCrud(CentreItem centre, EntityState state)
        {
            _context.Centres.Attach(centre).State = state;
            _context.SaveChanges();
            return Ok();
        }
    }
}