using System;
using System.Collections.Generic;
using CastlesC_.Models;
using CastlesC_.Repositories;

namespace CastlesC_.Service
{
    public class KnightService
    {

        private readonly KnightRepository _repo;

        public KnightService(KnightRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Knights> GetAll()
        {
            return _repo.GetAll();
        }

        internal Knights GetById(int id)
        {
            Knights data = _repo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Knights Create(Knights newKnight)
        {
            return _repo.Create(newKnight);
        }

        internal Knights Edit(Knights updated)
        {
            Knights data = GetById(updated.Id);

            //null check properties you are editing in repo
            data.Name = updated.Name != null ? updated.Name : data.Name;
            data.Age = updated.Age != null ? updated.Age : data.Age;
            return _repo.Edit(data);
        }

        internal string Delete(int id)
        {
            Knights data = GetById(id);
            _repo.Delete(id);
            return "Knight Retired";
        }

        internal IEnumerable<Knights> GetByCastleId(int id)
        {
            return _repo.GetByCastleId(id);
        }
    }
}