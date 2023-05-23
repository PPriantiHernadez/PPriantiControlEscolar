using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia resultMaterias = new ML.Materia();
            resultMaterias.Materias = new List<object>();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44327//api/");

                var responseTask = client.GetAsync("Materia/GetAll");
                responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());

                        resultMaterias.Materias.Add(resultItemList);
                    }
                }
            }
            return View(resultMaterias);
        }


        [HttpGet]
        public ActionResult Form(int? IdMateria)
        {
            ML.Materia materia = new ML.Materia();

            if (IdMateria == null)
            {
                //add
                //mostrar formulario vacio
                return View(materia);
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44327//api/");
                    var responseTask = client.GetAsync("Materia/GetById/" + IdMateria);
                    responseTask.Wait();

                    var resultMateria = responseTask.Result;

                    if (resultMateria.IsSuccessStatusCode)
                    {

                        var readTask = resultMateria.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Materia resultItemList = new ML.Materia();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());

                        materia = resultItemList;

                    }            
                }
                return View(materia);
            }
        }


        [HttpPost]
    public ActionResult Form(ML.Materia materia)
    {
            //ML.Result result = BL.Aseguradora.Add(aseguradora);
            ML.Result result = new ML.Result();

            if (materia.IdMateria == 0)
            {
                //add
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44327//api/");
                    var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
                    postTask.Wait();

                    var resultMateria = postTask.Result;

                    if (resultMateria.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha insertado correctamente la materia";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "La materia no se registro correctamente" + result.ErrorMessage;
                        return PartialView("Modal");
                    }
                }
            }
            else
            {
                //Update
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("https://localhost:44327//api/");

                    var postTask = client.PutAsJsonAsync<ML.Materia>("Materia/Update/" + materia.IdMateria, materia);
                    postTask.Wait();

                    var resultAseguradora = postTask.Result;

                    if (resultAseguradora.IsSuccessStatusCode)
                    {
                        
                        ViewBag.Message = "Se ha actualizado correctamente la aseguradora";
                        return PartialView("Modal");
                    }

                }
                return PartialView();
            }

        }

        public ActionResult Delete(int IdMateria)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44327//api/");

                //var postTask = client.PostAsJsonAsync<byte>("Aseguradora/Delete/" + IdAseguradora);
                var postTask = client.GetAsync("Materia/Delete/" + IdMateria);
                postTask.Wait();

                var resultAseguradora = postTask.Result;

                if (resultAseguradora.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Se ha eliminado correctamente la materia";
                    return View("Modal");
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al eliminar a la materia";
                }
            }

            return View("Modal");
        }




    }
}