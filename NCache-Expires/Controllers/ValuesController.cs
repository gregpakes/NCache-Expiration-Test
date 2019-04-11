using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NCache_Expires.Controllers
{
    using Alachisoft.NCache.Runtime;
    using Alachisoft.NCache.Web.Caching;

    public class ValuesController : ApiController
    {
        private Cache _cache;

        public ValuesController()
        {
            _cache = NCache.InitializeCache("mycache");
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var cachedItem = this._cache.Get("key");

            if (cachedItem == null)
            {
                cachedItem = DateTime.Now.ToString();
                this._cache.Add("key", cachedItem, null, DateTime.Now.AddSeconds(10), Cache.NoSlidingExpiration, CacheItemPriority.Default);
            }

            return new string[] { cachedItem.ToString(), "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
