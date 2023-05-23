using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {

        public static ML.Result AlumnoAddMateria(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PPriantiControlEscolarEntities context = new DL.PPriantiControlEscolarEntities())
                {

                    var queryEF = context.AlumnoAddMateria(alumnoMateria.Alumno.IdAlumno, alumnoMateria.Materia.IdMateria);
                  
                        if (queryEF >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se ha podido realizar el insert";
                        }
                    }
                }
           
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar la materia al alumno" + ex;
            }
            return result;
        }

        public static ML.Result DeleteMateria(int IdAlumno,int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PPriantiControlEscolarEntities context = new DL.PPriantiControlEscolarEntities())
                {
                    int queryEF = context.DeleteMateria(IdAlumno, IdMateria);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al eliminar la materia del alumno" + ex;
            }
            return result;
        }



        public static ML.Result AlumnoGetMateriaAsignada(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PPriantiControlEscolarEntities context = new DL.PPriantiControlEscolarEntities())
                {

                    //int objUsuario = context.UsuarioGetById(usuario.IdUsuario);
                    var objAlumnoMateria = context.AlumnoGetMateriaAsignada(IdAlumno).ToList();

                    result.Objects = new List<object>();

                    if (objAlumnoMateria != null)
                    {
                           
                        foreach (var obj in objAlumnoMateria)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;

                            alumnoMateria.Alumno = new ML.Alumno();
                            alumnoMateria.Alumno.IdAlumno = (int)obj.IdAlumno;

                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.Nombre = obj.Nombre;
                            alumnoMateria.Materia.Costo = (int)obj.Costo;

                            result.Objects.Add(alumnoMateria);
                            result.Correct = true;

                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener el registro de materia asigna del alumno";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result AlumnoGetMateriaSinAsignar(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PPriantiControlEscolarEntities context = new DL.PPriantiControlEscolarEntities())
                {

                    //int objUsuario = context.UsuarioGetById(usuario.IdUsuario);
                    var objAlumnoMateria = context.AlumnoGetMateriaSinAsignadar(IdAlumno).ToList();

                    result.Objects = new List<object>();

                    if (objAlumnoMateria != null)
                    {
                        foreach (var obj in objAlumnoMateria)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.Nombre = obj.Nombre;
                            alumnoMateria.Materia.Costo = (int)obj.Costo;

                            result.Objects.Add(alumnoMateria);
                            result.Correct = true;

                        }                          
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener el registro de materia sin asignar del alumno";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
