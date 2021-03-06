using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get()
        {
            // NOTE get public keeps without login
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }

        internal IEnumerable<Keep> GetPrivateKeeps(string userId)
        {
            string sql = "SELECT * FROM keeps WHERE (isPrivate = 1 AND userId = @UserId)";
            return _db.Query<Keep>(sql, new { userId });
        }

        internal Keep GetById(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });
        }

        internal Keep Create(Keep KeepData)
        {
            string sql = @"
            INSERT INTO keeps (userId, name, description, img, isPrivate, views, shares, keeps)
            VALUES (@UserId, @Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, KeepData);
            KeepData.Id = id;
            return KeepData;
        }

        internal void Edit(Keep update)
        {
            string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            views = @Views,
            shares = @Shares,
            keeps = @Keeps
            WHERE id = @Id";
            _db.Execute(sql, update);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM keeps WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}