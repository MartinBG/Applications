using Application_Database_Provider.Repository;
using Application_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Application_Server.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApplicationController : ApiController
    {
        private ApplicationRepository repository = new ApplicationRepository();

        //SEARCH-------------------------------------------------
        [HttpPost]//get by subject
        [Route("api/Applications/filterApplications/")]
        public IHttpActionResult filterApplications(FilterObject filter)
        {
            return Ok(repository.filterApplications(filter));
        }

        //GET----------------------------------------------------
        [HttpGet]
        [Route("api/Applications/getAllApplications")]
        public IHttpActionResult getAllApplications()
        {
            return Ok(repository.getAllActiveApplications());
        }


        [HttpGet]
        [Route("api/Applications/getApplicationById/{id:int}")]
        public IHttpActionResult getApplicationById(int Id)
        {
            return Ok(repository.getApplicationById(Id));
        }

        //POST--------------------------------------------------
        [Route("api/Applications/postApplication")]
        [HttpPost]
        public IHttpActionResult postApplication(Application newApplication)
        {
            return Ok(repository.postApplication(newApplication));
        }
        //UPDATE------------------------------------------------
        [HttpPut]
        [Route("api/Applications/updateApplication/{id:int}")]
        public IHttpActionResult updateApplication(int id, Application newApplication)
        {
            return Ok(repository.updateApplication(id, newApplication));
        }
        //DELETE------------------------------------------------
        [HttpDelete]
        [Route("api/Applications/deleteApplication/{id:int}")]
        public IHttpActionResult deleteApplication(int id)
        {
            return Ok(repository.deleteApplication(id));
        }
    }
}