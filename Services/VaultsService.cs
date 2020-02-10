using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }

        // internal IEnumerable<Vault> Get()
        // {
        //     return _repo.Get();
        // }

        internal Vault GetById(int id, string userId)
        {
            var found = _repo.GetById(id);
            if (found == null) { throw new Exception("Invalid id"); }
            if (userId != found.UserId) { throw new Exception("You don't oooowwwwn me"); }
            return found;
        }

        internal Vault Create(Vault newVault)
        {
            return _repo.Create(newVault);
        }

        internal Vault Edit(Vault update)
        {
            var found = _repo.GetById(update.Id);
            if (found == null) { throw new Exception("Invalid id"); }
            if (update.UserId != found.UserId) { throw new Exception("Unauthorized unauthorized unauthorized"); }
            _repo.Edit(update);
            return update;
        }

        internal string Delete(int id, string userId)
        {
            var found = _repo.GetById(id);
            if (found == null) { throw new Exception("Invalid id sucka"); }
            if (userId != found.UserId) { throw new Exception("You don't own me"); }
            _repo.Delete(id);
            return "Successfully deleted";
        }
    }
}