using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppProject.Data.DTO;
using WebAppProject.Managers;
using WebAppProject.Managers.Interfaces;

namespace WebAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinksManager _drinksManager;
        public DrinksController(DrinksManager drinksManager)
        {
            _drinksManager = drinksManager;
        }

        [HttpGet]
        public ActionResult<List<Drink>> Get() =>
            _drinksManager.GetAll();

        [HttpGet("{name}", Name = "GetDrink")]
        public ActionResult<Drink> GetByName(string name)
        {
            var drink = _drinksManager.GetByName(name);

            if (drink == null)
            {
                return NotFound();
            }

            return drink;
        }

        /*[HttpGet(Name = "GetAll")]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                var returned = _drinksManager.GetAll();
                return Ok(returned);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{drink_name}", Name = "GetByName")]
        [Route("{drink_name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var returned = _drinksManager.GetByName(name);
                return Ok(returned);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}