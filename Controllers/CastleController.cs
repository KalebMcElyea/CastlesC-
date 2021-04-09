using System;
using System.Collections.Generic;
using CastlesC_.Models;
using CastlesC_.Service;
using Microsoft.AspNetCore.Mvc;

namespace CastlesC_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastleController : ControllerBase
    {
        private readonly CastleService _service;
        private readonly KnightService _kservice;

        public CastleController(KnightService kservice, CastleService service)
        {
            _kservice = kservice;
            _service = service;
        }

        [HttpGet] //Get All
        public ActionResult<IEnumerable<Castle>> GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<Castle> GetById(int id)
        {
            try
            {
                return Ok(_service.GetById(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("{id}/knights")]
        public ActionResult<Knights> GetByCastleId(int id)
        {
            try
            {
                return Ok(_kservice.GetByCastleId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Castle> Create([FromBody] Castle newCastle)
        {
            try
            {
                return Ok(_service.Create(newCastle));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Castle> Edit([FromBody] Castle updated, int id)
        {
            try
            {
                updated.Id = id;
                return Ok(_service.Edit(updated));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Castle> Delete(int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}