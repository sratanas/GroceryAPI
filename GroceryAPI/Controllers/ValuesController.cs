using GroceryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGroceryRepository _groceryrepo;

        public ValuesController(IGroceryRepository groceryrepo)
        {
            _groceryrepo = groceryrepo;
        }
        // GET api/values


        [HttpGet]
        public async Task<IActionResult> GetApiJson()
        {
            //var jsonresponse = _groceryrepo.GetAllItems();
            var jsonresponse = await _groceryrepo.GetAllItems();


            return Ok(jsonresponse);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
