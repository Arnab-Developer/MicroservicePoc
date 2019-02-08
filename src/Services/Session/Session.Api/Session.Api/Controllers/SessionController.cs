using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicePoc.Service.Session.Api.Data;
using MicroservicePoc.Service.Session.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePoc.Service.Session.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private SessionContext _context;

        public SessionController(SessionContext context)
        {
            _context = context;
        }

        [Route("get")]
        [HttpGet]
        public ActionResult<IList<SessionItem>> GetAll()
        {
            return _context.Sessions
                .OrderBy(c => c.Name)
                .ToList();
        }

        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<SessionItem> GetById(int id)
        {
            return _context.Sessions
                .Single(c => c.Id == id);
        }

        [Route("get/{name}")]
        [HttpGet]
        public ActionResult<IList<SessionItem>> GetByName(string name)
        {
            return _context.Sessions
                .Where(c => c.Name == name)
                .OrderBy(c => c.Name)
                .ToList();
        }

        [Route("add")]
        [HttpPut]
        public ActionResult Add(SessionItem session)
        {
            return PerformCrud(session, EntityState.Added);
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Update(SessionItem session)
        {
            return PerformCrud(session, EntityState.Modified);
        }

        [Route("remove")]
        [HttpDelete]
        public ActionResult Remove(SessionItem session)
        {
            return PerformCrud(session, EntityState.Deleted);
        }

        private ActionResult PerformCrud(SessionItem session, EntityState state)
        {
            _context.Sessions.Attach(session).State = state;
            _context.SaveChanges();
            return Ok();
        }
    }
}