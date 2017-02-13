using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GenoomApi.Services;
using GenoomApi.ViewModels;
using System;

namespace GenoomApi.Controllers
{
    [Route("api/people")]
    public class PeopleController : Controller
    {
        #region Fields

        private readonly IPeopleService service;

        #endregion

        #region Constructor

        public PeopleController(IPeopleService peopleService)
        {
            this.service = peopleService;
        }

        #endregion

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            try
            {
                var result = await this.service.GetPersonById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound();
            }
        }

        [Route("{id}/family")]
        [HttpGet]
        public async Task<IActionResult> GetFamilyById(int id)
        {
            try
            {
                var result = await this.service.GetFamilyById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }
        
        // POST: api/People
        [Route("{id}/parents​")]
        [HttpPost]
        public async Task<IActionResult> PostParents([FromBody]PersonVm value, int id)
        {
            try
            {
                var result = await this.service.SaveParent(value, id);
                if (result != -1)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: api/People/5
        [Route("{id}/children")]
        [HttpPost]
        public async Task<IActionResult> PostChildren([FromBody]PersonVm value, int id)
        {
            try
            {
                var result = await this.service.SaveChildren(value, id);
                if (result != -1)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("tree/{id}​")]
        [HttpGet]
        public async Task<IActionResult> GetTreeByPersonId(int id)
        {
            try
            {
                var result = await this.service.GetTreeByPersonId(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
