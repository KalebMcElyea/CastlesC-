using System;
using System.Collections.Generic;
using CastlesC_.Models;
using CastlesC_.Repository;

namespace CastlesC_.Service
{
    public class CastleService
    {

        private readonly CastleRepository _repo;
        public CastleService(CastleRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Castle> GetAll()
        {
            return _repo.GetAll();
        }

        internal Castle GetById(int id)
        {
            Castle data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Castle Create(Castle newCastle)
        {
            return _repo.Create(newCastle);
        }

        internal Castle Edit(Castle updated)
        {
            Castle data = GetById(updated.Id);

            //null check properties you are editing in repo
            data.Name = updated.Name != null ? updated.Name : data.Name;
            data.King = updated.King != null ? updated.King : data.King;
            data.Country = updated.Country != null ? updated.Country : data.Country;

            return _repo.Edit(data);
        }

        internal string Delete(int id)
        {
            {
                Castle data = GetById(id);
                _repo.Delete(id);
                return "Castle Destroyed";
            }
        }
    }
}