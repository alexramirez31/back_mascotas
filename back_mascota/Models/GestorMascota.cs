using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace back_mascota.Models
{
    public class GestorMascota
    {
        string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();
        
        //Listar
        public List<Mascota> GetMascotas()
        {
            List<Mascota> lista = new List<Mascota>();
            //string strConn = ConfigurationManager.ConnectionStrings["DBLocal"].ToString();

            using(SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Mascota_All";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    int edad = dr.GetInt32(2);
                    string desc = dr.GetString(3).Trim();

                    Mascota mascota = new Mascota(id,nombre,edad,desc);

                    lista.Add(mascota);
                }

                dr.Close();
                conn.Close();

            }

            return lista;
        }

        //Agregar
        public bool addMascota(Mascota mascota)
        {
            bool res = false;

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Mascota_Add";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", mascota.nombre);
                cmd.Parameters.AddWithValue("@edad", mascota.edad);
                cmd.Parameters.AddWithValue("@desc", mascota.descripcion);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();

                }

                return res;

            }

        }

        //Update
        public bool updateMascota(int id, Mascota mascota)
        {
            bool res = false;

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Mascota_Update";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Nombre", mascota.nombre);
                cmd.Parameters.AddWithValue("@edad", mascota.edad);
                cmd.Parameters.AddWithValue("@desc", mascota.descripcion);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();

                }

                return res;

            }

        }

        //delete
        public bool deleteMascota(int id)
        {
            bool res = false;

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Mascota_Delete";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
               

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();

                }

                return res;

            }

        }
    }
}
