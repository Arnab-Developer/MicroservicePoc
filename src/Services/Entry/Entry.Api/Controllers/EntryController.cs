using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MicroservicePoc.Service.Entry.Domain;
using MicroservicePoc.Service.Entry.Infrastructure;
using MicroservicePoc.Service.Entry.Api.ViewModels;

namespace MicroservicePoc.Service.Entry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private IEntryRepository _repository;

        public EntryController(IEntryRepository repository)
        {
            _repository = repository;
        }

        [Route("get/{id:int}")]
        [HttpGet]
        public ActionResult<EntryItem> GetById(int id)
        {
            var entry = _repository.GetById(id);
            return entry;
        }

        [Route("get/centre/{id}")]
        [HttpGet]
        public ActionResult<List<EntryItem>> GetByCentre(int id)
        {
            var entries = _repository.GetByCentre(id);
            return entries;
        }

        [Route("add")]
        [HttpPut]
        public ActionResult Add(EntryViewModel entryViewModel)
        {
            var entry = CreateEntryObject(entryViewModel);
            _repository.Add(entry);
            _repository.UnitOfWork.SaveUnitChanges();
            return Ok();
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Update(EntryViewModel entryViewModel)
        {
            var entry = CreateEntryObject(entryViewModel);
            _repository.Update(entry);
            _repository.UnitOfWork.SaveUnitChanges();
            return Ok();
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            _repository.UnitOfWork.SaveUnitChanges();
            return Ok();
        }

        private EntryItem CreateEntryObject(EntryViewModel entryViewModel)
        {
            var entry = new EntryItem(entryViewModel.EntryId, entryViewModel.CentreId, entryViewModel.CentreName, 
                entryViewModel.CentreAddress, entryViewModel.SessionId, entryViewModel.SessionName,
                entryViewModel.SubjectId, entryViewModel.SubjectName, entryViewModel.SubjectTypeName,
                entryViewModel.CandidateId, entryViewModel.CandidateName);

            return entry;
        }
    }
}