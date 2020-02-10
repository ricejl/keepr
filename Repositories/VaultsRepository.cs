using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        //db
        private readonly IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        // internal IEnumerable<Vault> Get()
        // {
        //     string sql = "SELECT * FROM vaults";
        //     return _db.Query<Vault>(sql);
        // }

        internal Vault GetById(int id)
        {
            string sql = "SELECT * FROM vaults WHERE id = @id";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id });
        }

        internal Vault Create(Vault newVault)
        {
            string sql = @"
            INSERT INTO vaults (name, description, userId)
            VALUES (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID()";
            int id = _db.ExecuteScalar<int>(sql, newVault);
            newVault.Id = id;
            return newVault;
        }

        internal void Edit(Vault update)
        {
            string sql = @"
            UPDATE vaults
            SET
            name = @Name,
            description = @Description";
            _db.Execute(sql, update);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaults WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}