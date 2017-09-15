using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DalSic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace Consultorio.Turnos
{
    public class GuardarTurno
    {
        public void guardarTurno(ConTurno turno, out int idTurno)
        {

            int idTurnos = 0;

            if (Conexion.conectar())
            {
                SqlCommand cmdTurno = new SqlCommand("Con_GuardarTurno", Conexion.conexion);
                cmdTurno.CommandType = CommandType.StoredProcedure;

                cmdTurno.Parameters.Add("@idPaciente", SqlDbType.Int);
                cmdTurno.Parameters.Add("@idAgenda", SqlDbType.Int);
                cmdTurno.Parameters.Add("@idObraSocial", SqlDbType.Int);
                cmdTurno.Parameters.Add("@idTurnoEstado", SqlDbType.Int);
                cmdTurno.Parameters.Add("@idUsuario", SqlDbType.Int);
                cmdTurno.Parameters.Add("@fecha", SqlDbType.DateTime);
                cmdTurno.Parameters.Add("@hora", SqlDbType.Char, 5);
                cmdTurno.Parameters.Add("@sobreturno", SqlDbType.Bit);
                cmdTurno.Parameters.Add("@idTipoTurno", SqlDbType.Int);
                cmdTurno.Parameters.Add("@error", SqlDbType.NVarChar, 1000);
                cmdTurno.Parameters.Add("@idTurno", SqlDbType.Int);

                cmdTurno.Parameters["@error"].Direction = ParameterDirection.Output;
                cmdTurno.Parameters["@idTurno"].Direction = ParameterDirection.Output;

                cmdTurno.Parameters[0].Value = turno.IdPaciente;
                cmdTurno.Parameters[1].Value = turno.IdAgenda;
                cmdTurno.Parameters[2].Value = turno.IdObraSocial;
                cmdTurno.Parameters[3].Value = turno.IdTurnoEstado;
                cmdTurno.Parameters[4].Value = turno.IdUsuario;
                cmdTurno.Parameters[5].Value = turno.Fecha;
                cmdTurno.Parameters[6].Value = turno.Hora;
                cmdTurno.Parameters[7].Value = turno.Sobreturno;
                cmdTurno.Parameters[8].Value = turno.IdTipoTurno;

                cmdTurno.ExecuteNonQuery();

                string respuesta = cmdTurno.Parameters["@error"].Value.ToString();
                idTurnos = int.Parse(cmdTurno.Parameters["@idTurno"].Value.ToString());
                //MessageBox.Show(respuesta);
            }

            idTurno = idTurnos;
        }
    }
}