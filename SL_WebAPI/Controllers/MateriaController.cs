using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SL_WebAPI.Controllers
{
    public class MateriaController : ApiController
    {
        // GET: Materia
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Materia/Delete")]
        public IHttpActionResult Delete([FromBody] int IdMateria)
        {
            ML.Result result = BL.Materia.Delete(IdMateria);

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Materia/GetById/{IdMateria}")]
        public IHttpActionResult GetById(int IdMateria)
        {
            ML.Result result = BL.Materia.GetById(IdMateria);

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }
        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/Materia/Update/{IdMateria}")]
        public IHttpActionResult Update(int IdMateria, [FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.Update(materia);

            if (result.Correct)
            {
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                return Content(System.Net.HttpStatusCode.NotFound, result);
            }

        }


    }
}