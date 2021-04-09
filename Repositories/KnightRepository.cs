using System;
using System.Collections.Generic;
using System.Data;
using CastlesC_.Models;
using Dapper;

namespace CastlesC_.Repositories
{
    public class KnightRepository
    {
        private readonly IDbConnection _db;

        public KnightRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Knights> GetAll()
        {
            string sql = "SELECT * FROM knight;";
            return _db.Query<Knights>(sql);
        }

        internal Knights GetById(int id)
        {
            string sql = "SELECT * FROM knight WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Knights>(sql, new { id });
        }

        internal Knights Create(Knights newKnight)
        {
            string sql = @"
            INSERT INTO knight
            (name, age, castleId)
            VALUES
            (@Name, @Age, @CastleId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newKnight);
            newKnight.Id = id;
            return newKnight;
        }

        internal Knights Edit(Knights updatedKnight)
        {
            string sql = @"
      UPDATE knight
      SET
        name = @Name,
        age = @Age,
      WHERE id = @Id;
      SELECT * FROM knight WHERE id = @Id;";
            Knights returnKnight = _db.QueryFirstOrDefault<Knights>(sql, updatedKnight);
            return returnKnight;
        }


        internal void Delete(int id)
        {
            string sql = "DELETE FROM knight WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<Knights> GetByCastleId(int id)
        {
            string sql = @"
      SELECT 
      k.*,
      c.*
      FROM knight k
      JOIN castle c ON k.castleId = c.id
      WHERE castleId = @id;";

            return _db.Query<Knights, Castle, Knights>(sql, (knight, castle) =>
            {
                knight.Castle = castle;
                return knight;
            }, new { id }, splitOn: "id");
        }
    }
}