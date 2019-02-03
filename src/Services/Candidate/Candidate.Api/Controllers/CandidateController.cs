using Microsoft.AspNetCore.Mvc;
using Candidate.Api.Models;
using Candidate.Api.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Candidate.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private CandidateContext _context;

        public CandidateController(CandidateContext context)
        {
            _context = context;    
        }

        [Route("get")]
        [HttpGet]
        public ActionResult<IList<CandidateItem>> GetAll()
        {
            return _context.Candidates
                .OrderBy(c => c.Name)
                .ToList();
        }

        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<CandidateItem> GetById(int id)
        {
            return _context.Candidates
                .Single(c => c.Id == id);
        }

        [Route("get/{name}")]
        [HttpGet]
        public ActionResult<IList<CandidateItem>> GetByName(string name)
        {
            return _context.Candidates
                .Where(c => c.Name == name)
                .OrderBy(c => c.Name)
                .ToList();
        }

        [Route("add")]
        [HttpPut]
        public ActionResult Add(CandidateItem candidate)
        {
            return PerformCrud(candidate, EntityState.Added);
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Update(CandidateItem candidate)
        {
            return PerformCrud(candidate, EntityState.Modified);
        }

        [Route("remove")]
        [HttpDelete]
        public ActionResult Remove(CandidateItem candidate)
        {
            return PerformCrud(candidate, EntityState.Deleted);
        }

        private ActionResult PerformCrud(CandidateItem candidate, EntityState state)
        {
            _context.Candidates.Attach(candidate).State = state;
            _context.SaveChanges();
            return Ok();
        }
    }
}