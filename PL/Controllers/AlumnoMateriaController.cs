using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();

            if (result.Correct)
            {
                alumno.Alumnos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de alumnos" + result.ErrorMessage;
            }

            return View(alumno);
        }

        [HttpGet]
        public ActionResult GetMateriaAsignada(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.AlumnoGetMateriaAsignada(IdAlumno);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);

            if (result.Correct)
            {
                alumnoMateria.AlumnosMaterias = result.Objects;
                alumnoMateria.Alumno = (ML.Alumno)resultalumno.Object;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al hacer la consulta de alumnos" + result.ErrorMessage;
            }

            return View(alumnoMateria);
        }

        public ActionResult Delete(ML.AlumnoMateria alumnoMateria)
        {
            
            if(alumnoMateria.AlumnosMaterias != null)
            {
                foreach(var IdMateria in alumnoMateria.AlumnosMaterias)
                {
                    BL.AlumnoMateria.DeleteMateria(alumnoMateria.Alumno.IdAlumno,Convert.ToInt32(IdMateria));
                }
                ViewBag.Message = "Se eliminado el alumno";
            }
            else
            {
                ViewBag.Message = "Error al eliminar la materia";
            }

            return View("Modal");
        }



        [HttpGet]
        public ActionResult GetMateriaSinAsignar(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.AlumnoGetMateriaSinAsignar(IdAlumno);
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);

            alumnomateria.AlumnosMaterias = result.Objects;
            alumnomateria.Alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }
        [HttpPost]

        public ActionResult GetMateriaSinAsignar(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            if (alumnoMateria.AlumnosMaterias != null)
            {
                foreach (string IdMateria in alumnoMateria.AlumnosMaterias)
                {
                    ML.AlumnoMateria alumnoMateriaD = new ML.AlumnoMateria();

                    alumnoMateriaD.Alumno = new ML.Alumno();
                    alumnoMateriaD.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    alumnoMateriaD.Materia = new ML.Materia();
                    alumnoMateriaD.Materia.IdMateria = int.Parse(IdMateria);

                    ML.Result resul = BL.AlumnoMateria.AlumnoAddMateria(alumnoMateriaD);
                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizado al alumno";
                //ViewBag.MateriasAsignadas = true;
                //ViewBag.IdAlumno = alumnoMateria.Alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("Modal");
        }


    }
}