using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO 
    {
        #region atributos
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Statico
        /// </summary>
        static PaqueteDAO()
        {
            string connectionString = @"Server =.\SQLEXPRESS; Database =correo-sp-2017; Trusted_Connection = true;";
            conexion = new SqlConnection(connectionString);
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = System.Data.CommandType.Text;
            
        }
        #endregion

        #region metodos
        /// <summary>
        /// Metodo que permite insertar un paquete en la BD
        /// </summary>
        /// <param name="p"> De aca se sacaran todos los datos que se guardaran en la BD salvo mi nombre </param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            using (SqlConnection connection = new SqlConnection(@"Server =.\SQLEXPRESS; Database =correo-sp-2017; Trusted_Connection = true;"))
            {
                
                string comando = String.Format("INSERT INTO Paquetes(direccionEntrega,trackingID,alumno)VALUES (@direccionEntrega,@trackingID,'Matias Ezequiel Palmieri')");
                SqlCommand command = new SqlCommand(comando, connection);

                command.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
                command.Parameters.AddWithValue("@trackingID", p.TrackingID);
                connection.Open(); //abre la conexcion con la BD
                command.ExecuteNonQuery();//ejecuta
            }
            return true;
        }
        #endregion
    }
}
