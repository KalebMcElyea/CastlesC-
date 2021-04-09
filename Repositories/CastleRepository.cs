using System;
using System.Collections.Generic;
using System.Data;
using CastlesC_.Models;
using Dapper;

namespace CastlesC_.Repository
{
    public class CastleRepository
    {
        private readonly IDbConnection _db;

        public CastleRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Castle> GetAll()
        {
            string sql = "SELECT * FROM castle;";
            return _db.Query<Castle>(sql);
        }

        internal Castle GetById(int id)
        {
            string sql = "SELECT * FROM castle WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Castle>(sql, new { id });
        }

        internal Castle Create(Castle newCastle)
        {
            string sql = @"
            INSERT INTO castle
            (name, king, country)
            VALUES
            (@Name, @King, @Country);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCastle);
            newCastle.Id = id;
            return newCastle;
        }

        internal Castle Edit(Castle updatedCastle)
        {
            string sql = @"
      UPDATE castle
      SET
        king = @King,
        name = @Name,
        country = @Country
      WHERE id = @Id;
      SELECT * FROM artists WHERE id = @Id;";
            Castle returnCastle = _db.QueryFirstOrDefault<Castle>(sql, updatedCastle);
            return returnCastle;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM castle WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}