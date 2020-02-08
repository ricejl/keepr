using System;
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

        internal Vault Get(string userId)
        {
            //check if user is permitted to access and throw error if not
            //send along to repository
        }

        internal Vault GetById(int id, string userId)
        {
            throw new NotImplementedException();
        }

        internal Vault Create(Vault newVault)
        {
            throw new NotImplementedException();
        }

        internal Vault Edit(Vault update)
        {
            throw new NotImplementedException();
        }

        internal string Delete(string userId, int id)
        {
            throw new NotImplementedException();
        }
    }
}