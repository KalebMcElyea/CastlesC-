
using System;
using System.Collections.Generic;
using CastlesC_.Models;
using CastlesC_.Service;
using Microsoft.AspNetCore.Mvc;

namespace CastlesC_.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class KnightController : ControllerBase
    {


        private readonly KnightService _service;

        public KnightController(KnightService service)
        {
            _service = service;
        }

        [HttpGet] //Get All
        public ActionResult<IEnumerable<Knights>> GetAll()
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
        public ActionResult<Knights> GetById(int id)
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

        [HttpPost]
        public ActionResult<Knights> Create([FromBody] Knights newKnight)
        {
            try
            {
                return Ok(_service.Create(newKnight));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Knights> Edit([FromBody] Knights updated, int id)
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
        public ActionResult<Knights> Delete(int id)
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