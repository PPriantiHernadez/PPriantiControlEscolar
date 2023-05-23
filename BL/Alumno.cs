using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        //Add SQL CLIENT
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    //string query = "INSERT INTO Usuario VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,@Correo)";
                    string query = "AlumnoAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = alumno.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = alumno.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;

                        }

                    }
                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }

            return result;

        }

        //Update SQL CLIENT
        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    //string query = "UPDATE [Usuario] SET [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[FechaNacimiento] = @FechaNacimiento,[Correo] = @Correo WHERE IdUsuario = @IdUsuario";
                    string query = "AlumnoUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = alumno.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = alumno.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = alumno.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;

                        int RowAffected = cmd.ExecuteNonQuery();

                        if (RowAffected > 0)
                        {
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Alumno" + result.Ex;
                //throw;

            }
            return result;
        }

        //Delete SQL CLIENT
        public static ML.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    //string query = "DELETE FROM [Usuario] WHERE IdUsuario = @IdUsuario";
                    string query = "AlumnoDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumno.IdAlumno;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        cmd.CommandType = CommandType.StoredProcedure;

                        int RowAffected = cmd.ExecuteNonQuery();

                        if (RowAffected > 0)
                        {
                            result.Correct = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al eliminar el registro en la tabla Alumno" + result.Ex;
                //throw;
            }
            return result;
        }

        //GetAll SQL CLIENT
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "AlumnoGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        DataTable tablealumno = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablealumno);

                        if (tablealumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tablealumno.Rows)
                            {
                                ML.Alumno alumno = new ML.Alumno();

                                alumno.IdAlumno = int.Parse(row[0].ToString());
                                alumno.Nombre = row[1].ToString();
                                alumno.ApellidoPaterno = row[2].ToString();
                                alumno.ApellidoMaterno = row[3].ToString();
                                
                                result.Objects.Add(alumno);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al seleccionar los registros en la tabla Alumno";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al mostrar la tabla Usuario" + result.Ex;
                //throw;
            }
            return result;
        }

        //GetById SQL CLIENT
        public static ML.Result GetById(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "AlumnoGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;

                        cmd.Parameters.AddRange(collection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        DataTable tablealumno = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablealumno);

                        if (tablealumno.Rows.Count > 0)
                        {
                            
                            ML.Alumno alumno = new ML.Alumno();

                            DataRow row = tablealumno.Rows[0];

                            alumno.IdAlumno = byte.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();

                            result.Object = alumno;
                            
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al seleccionar el registro en la tabla Alumno";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al mostrar el registro de la tabla Alumno" + result.Ex;
                //throw;
            }
            return result;
        }
    }
}
