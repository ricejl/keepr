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

        internal string Delete(int vaultId, int keepId, string userId)
        {
            VaultKeep found = _repo.FindById(vaultId, keepId);
            if (found == null) { throw new Exception("Keep not saved to vault"); }
            if (found.UserId != userId) { throw new Exception("Unauthorized"); }
            _repo.Delete(found.Id);
            return "Successfully removed";
        }

    }
}