using HappinessPOC.Data;
using HappinessPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HappinessPOC.Controllers
{
    public class ItemController : ApiController
    {
        private IHappinessRepository _repo;

        public ItemController(IHappinessRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<HappyItem> Get()
        {
            var happyItems = _repo.GetHappyItems().ToList();
            return happyItems;
        }

        public HttpResponseMessage Post([FromBody]HappyItem item)
        {
            if( item.Created == default(DateTime))
            {
                item.Created = DateTime.UtcNow;
            }
            HappyItem newItem = _repo.AddHappyItem(item);
            if (!newItem.Equals(null) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, newItem);
            } else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        

               
        }
    }
}
