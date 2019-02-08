using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicePoc.Service.Subject.Api.Data;
using MicroservicePoc.Service.Subject.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePoc.Service.Subject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private SubjectContext _context;

        public SubjectController(SubjectContext context)
        {
            _context = context;
        }

        [Route("get")]
        [HttpGet]
        public ActionResult<IList<SubjectItem>> GetAll()
        {
            return _context.Subjects
                .OrderBy(c => c.Name)
                .ToList();
        }

        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<SubjectItem> GetById(int id)
        {
            return _context.Subjects
                .Single(c => c.Id == id);
        }

        [Route("get/{name}")]
        [HttpGet]
        public ActionResult<IList<SubjectItem>> GetByName(string name)
        {
            return _context.Subjects
                .Where(c => c.Name == name)
                .OrderBy(c => c.Name)
                .ToList();
        }

        [Route("add")]
        [HttpPut]
        public ActionResult Add(SubjectItem subject)
        {
            return PerformCrud(subject, EntityState.Added);
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Update(SubjectItem subject)
        {
            return PerformCrud(subject, EntityState.Modified);
        }

        [Route("remove")]
        [HttpDelete]
        public ActionResult Remove(SubjectItem subject)
        {
            return PerformCrud(subject, EntityState.Deleted);
        }

        private ActionResult PerformCrud(SubjectItem subject, EntityState state)
        {
            _context.Subjects.Attach(subject).State = state;
            _context.SaveChanges();
            return Ok();
        }
    }
}