using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP_NET.Models
{
    public class Conexion
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);


        //StopProcedure
        public void Insert(Calculo c)
        {

            SqlCommand com = new SqlCommand("InsertCalculo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Respuesta", c.Respuesta);
            com.Parameters.AddWithValue("@FechaHora", c.FechaHora);
            com.Parameters.AddWithValue("@UsuarioId", c.UsuarioId);
            con.Open();
            com.ExecuteNonQuery();
        }

        public DataSet Select()
        {
            SqlCommand com = new SqlCommand("GetCalculo", con);
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public Calculo SelectId(int id)
        {
            Calculo calculo = new Calculo();
            SqlCommand com = new SqlCommand("GetIdCalculo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count==1)
            {
                calculo.Id = Convert.ToInt32(dt.Rows[0][0].ToString());
                calculo.Respuesta = Convert.ToInt32(dt.Rows[0][1].ToString());
                calculo.FechaHora = Convert.ToDateTime(dt.Rows[0][2].ToString());
                calculo.UsuarioId = Convert.ToInt32(dt.Rows[0][3].ToString());
                return calculo;
            }
            return calculo;
        }

        public void Delete(int id)
        {
            SqlCommand com = new SqlCommand("DeleteCalculo", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            con.Open();
            com.ExecuteNonQuery();
        }

        //public void Update(Calculo et)
        //{

        //    SqlCommand com = new SqlCommand("UpdateEnterpriseDataSP", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@Id", et.Id);
        //    com.Parameters.AddWithValue("@Name", et.Name);
        //    com.Parameters.AddWithValue("@Nit", et.Nit);
        //    com.Parameters.AddWithValue("@Gln", et.Gln);
        //    con.Open();
        //    com.ExecuteNonQuery();
        //}

    }
}