using System;
using System.Collections.Generic;
using System.Linq;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Keep> GetById(Vault v, string userId)
        {
            var found = _repo.GetById(v);
            if (found == null) { throw new Exception("Invalid id"); }
            // for each?? since found is list of keeps or check first and assume rest of keeps userIds are the same
            // if (userId != found.UserId) { throw new Exception("You don't own this vault."); }
            if (found.ElementAt(0).UserId != userId) { throw new Exception("Unauthorized"); }
            return found;
        }

        internal void Create(VaultKeep newData)
        {
            var found = _repo.Find(newData);
            if (found != null) { throw new Exception("Keep already saved."); }
            _repo.Create(newData);
        }

        internal string Delete(VaultKeep vk)
        {
            VaultKeep found = _repo.Find(vk);
            if (found != null) { throw new Exception("Keep already saved."); }
            _repo.Delete(vk.Id);
            return "Successfully removed";
        }

    }
}