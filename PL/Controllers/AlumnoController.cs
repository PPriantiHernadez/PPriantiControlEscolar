using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            
            ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();
            var result = servicioAlumno.GetAll();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error al consultar la información";
                return View();
            }
            return View(alumno);
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {            
            ML.Alumno alumno = new ML.Alumno();

            if (IdAlumno == null)
            {
                //Mostrar el formulario vacio
                return View(alumno);
            }
            else
            {
                ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();

                alumno.IdAlumno = IdAlumno.Value;
                var result = servicioAlumno.GetById(alumno.IdAlumno);

                if (result.Correct)
                {

                    alumno = (ML.Alumno)result.Object; //unboxing

                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al hacer la consulta de la aseguradora" + result.ErrorMessage;
                    return View();
                }
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {

            ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();


            if (alumno.IdAlumno == 0)
            {
                var result = servicioAlumno.Add(alumno);
                if (result.Correct)
                {

                    ViewBag.Message = "Se ha insertado la aseguradora";
                }
                else
                {
                    ViewBag.Message = "No se ha insertado la aseguradora";
                }

            }
            else
            {
                //result = BL.Alumno.UpdateEF(alumno);

                var result = servicioAlumno.Update(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente el registro de la aseguradora";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el registro de la aseguradora" + result.ErrorMessage;
                }
            }

            return View(alumno);
        }

        public ActionResult Delete(int IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.IdAlumno = IdAlumno;

            //BL.Aseguradora.Delete(aseguradora);

            ServiceReferenceAlumno.AlumnoClient servicioAlumno = new ServiceReferenceAlumno.AlumnoClient();
            var result = servicioAlumno.Delete(alumno);

            return View("Modal");
        }
    }
}