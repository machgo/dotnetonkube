using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        //redis stuff
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis-master");
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var db = redis.GetDatabase();
            db.StringSet("blubb", "test");

            var enumerator = Environment.GetEnvironmentVariables().GetEnumerator();
            var ret = new List<string>();
            while (enumerator.MoveNext())
            {
                ret.Add($"{enumerator.Key}:{enumerator.Value}");
            }
            return ret;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var db = redis.GetDatabase();
            var ret = db.StringGet("blubb");
            return ret.ToString();
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
