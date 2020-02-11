using System;
using System.Collections.Generic;
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

        internal VaultKeep Find(VaultKeep vk)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId)";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, vk);
        }

        internal VaultKeep FindById(int vaultId, int keepId)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId)";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultId, keepId });
        }

        internal IEnumerable<Keep> GetById(Vault v)
        {
            string sql = @"SELECT k.* FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId
            WHERE (vaultId = @Id AND vk.userId = @userId)";
            return _db.Query<Keep>(sql, v);
        }

        internal VaultKeep Create(VaultKeep newData)
        {
            string sql = @"
            INSERT INTO vaultkeeps
            (vaultId, keepId, userId)
            VALUES
            (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID()";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @Id";
            _db.Execute(sql, new { id });
        }
    }
}