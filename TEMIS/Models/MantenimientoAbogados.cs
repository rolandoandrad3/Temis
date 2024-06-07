using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEMIS.Data;

namespace TEMIS.Models
{
    public class MantenimientoAbogados
    {
        private SqlConnection conexion;

        private void Conectar()
        {
            string cadConexion = ConfigurationManager.ConnectionStrings["TEMISContext"].ToString();
            conexion = new SqlConnection(cadConexion);
        }

        public void AgregarAbogado(Abogados abogado)
        {
            Conectar();
            
                using (SqlCommand command = new SqlCommand("INSERT INTO Abogados (NombreAbogado, ApellidosAbogado, DUIAbogado, EspecialidadAbogado, TelefonoAbogado, EmailAbogado, CSJ) VALUES (@NombreAbogado, @ApellidosAbogado, @DUIAbogado, @EspecialidadAbogado, @TelefonoAbogado, @EmailAbogado, @CSJ)", conexion))
                {
                    command.Parameters.AddWithValue("@NombreAbogado", abogado.NombreAbogado);
                    command.Parameters.AddWithValue("@ApellidosAbogado", abogado.ApellidosAbogado);
                    command.Parameters.AddWithValue("@DUIAbogado", abogado.DUIAbogado);
                    command.Parameters.AddWithValue("@EspecialidadAbogado", abogado.EspecialidadAbogado);
                    command.Parameters.AddWithValue("@TelefonoAbogado", abogado.TelefonoAbogado);
                    command.Parameters.AddWithValue("@EmailAbogado", abogado.EmailAbogado);
                    command.Parameters.AddWithValue("@CSJ", abogado.CSJ);
                
                conexion.Open();
                command.ExecuteNonQuery();
                }
            conexion.Close();
        }

    }
}