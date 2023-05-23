using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        //ADDEF
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PPriantiControlEscolarEntities context = new DL.PPriantiControlEscolarEntities())
                {

                    var queryEF = context.MateriaAdd(materia.Nombre, materia.Costo);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar la materia" + ex;
            }
            return result;
        }

        //UpdateEF

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PPriantiControlEscolarEntities context = new DL.PPriantiControlEscolarEntities())
                {
                    int queryEF = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al actualizar la materia" + ex;
            }
            return result;
        }

        //DeleteEF
        public static ML.Result Delete(int IdMateria)
        {
            ML.Result result = new ML.Result();
            //ML.Usuario usuario = new ML.Usuario();
            ML.Materia materia = new ML.Materia();
            try
            {
                using (DL.PPriantiControlEscolarEntities context = new DL.PPriantiControlEscolarEntities())
                {
                    int queryEF = context.MateriaDelete(materia.IdMateria);

                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al eliminar la materia" + ex;
            }
            return result;
        }

        //GetAllEF
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PPriantiControlEscolarEntities context = new DL.PPriantiControlEscolarEntities())
                {
                    var queryEF = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();

                    foreach (var row in queryEF)
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = row.IdMateria;
                        materia.Nombre = row.Nombre;
                        materia.Costo = (int)row.Costo;

                        result.Objects.Add(materia); //boxing
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrio un error al mostrar la tabla de materia" + ex;
            }
            return result;
        }

        //GetByIdEF
        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PPriantiControlEscolarEntities context = new DL.PPriantiControlEscolarEntities())
                {

                    //int objUsuario = context.UsuarioGetById(usuario.IdUsuario);
                    var objMateria = context.MateriaGetById(IdMateria).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objMateria != null)
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = objMateria.IdMateria;
                        materia.Nombre = objMateria.Nombre;
                        materia.Costo = (int)objMateria.Costo;

                        result.Object = materia;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener el registro de materia";
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
