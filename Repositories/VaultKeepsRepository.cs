using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeeps Find(VaultKeeps vk)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId)";
            return _db.QueryFirstOrDefault(sql, vk);
        }
        internal void Create(VaultKeeps newData)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (vaultId, keepId)
            VALUES
            (@VaultId, @KeepId);
            SELECT LAST_INSERT_ID()";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}