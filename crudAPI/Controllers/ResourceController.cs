using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;

namespace crudAPI.Controllers
{

    [ApiController]
    [Route("api/customers/{id:int}/resources")]
    public class ResourceController : Controller
    {

        [HttpGet]
        public ActionResult<Collection<Resource>> GetResource()
        {
            var  resources = new Collection<Resource>();
            var r1 = new Resource("copper");
            resources.Add(r1);
            return resources;
        }
        
        [HttpGet("{resourceId:int}")]
        public ActionResult<Resource> GetResource(int id)
        {
            var r1 = new Resource("lead");
            return r1;
        }
        
        [HttpPost]
        public ActionResult<Resource> AddResource()
        {
            return new Resource("silver");
        }
        
        [HttpPut("{resourceId:int}")]
        public ActionResult<Resource> UpdateResource(int id)
        {
            return new Resource("gold");
        }

        [HttpDelete("{resourceId:int}")]
        public ActionResult<string> DeleteResource(int id)
        {
            return $"Well, resource {id} will not bother us again, will it?";
        }
    }
}