using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }
        internal Keep GetById(int id, string userId)
        {
            var found = _repo.GetById(id);
            if (found == null) { throw new Exception("Invalid id"); }
            // if found.isPrivate is true and userId doesn't match found.UserId, throw error
            if (found.IsPrivate && userId != found.UserId) { throw new Exception("Must be logged in to see private keeps"); }
            return found;
        }
        public Keep Create(Keep newKeep)
        {
            _repo.Create(newKeep);
            return newKeep;
        }
        internal Keep Edit(Keep update)
        {
            Keep found = _repo.GetById(update.Id);
            if (found == null) { throw new Exception("Invalid id"); }
            if (found.UserId != update.UserId) { throw new Exception("Sorry, I cannot let you do that."); }
            _repo.Edit(update);
            return update;
        }
        internal string Delete(string userId, int id)
        {
            Keep found = _repo.GetById(id);
            if (found == null) { throw new Exception("Invalid id"); }
            if (found.UserId != userId) { throw new Exception("Sorry, I cannot let you do that."); }
            _repo.Delete(id);
            return "Successfully deleted.";
        }
    }
}