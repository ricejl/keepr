using System;
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

        internal void Create(VaultKeeps newData)
        {
            VaultKeeps found = _repo.Find(newData);
            if (found != null) { throw new Exception("Keep already saved."); }
            _repo.Create(newData);
        }

        internal string Delete(VaultKeeps vk)
        {
            VaultKeeps found = _repo.Find(vk);
            if (found != null) { throw new Exception("Keep already saved."); }
            _repo.Delete(vk.Id);
            return "Successfully removed";
        }
    }
}