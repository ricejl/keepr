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

        internal IEnumerable<Keep> GetById(Vault v)
        {
            var found = _repo.GetById(v);
            // if (found == null) { throw new Exception("Invalid id"); }
            // if (found.ElementAt(0).UserId != userId) { throw new Exception("Unauthorized"); }
            return found;
        }

        internal void Create(VaultKeep newData)
        {
            VaultKeep found = _repo.Find(newData);
            if (found != null) { throw new Exception("Keep already saved to vault."); }
            _repo.Create(newData);
        }

        internal string Delete(VaultKeep vk)
        {
            VaultKeep found = _repo.Find(vk);
            if (found.UserId != vk.UserId) { throw new Exception("Unauthorized"); }
            _repo.Delete(vk.Id);
            return "Successfully removed";
        }

    }
}