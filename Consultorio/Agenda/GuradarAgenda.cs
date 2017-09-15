using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DalSic;

namespace Consultorio
{
    public class GuradarAgenda
    {
        public void guardarAgenda(ConAgenda agenda)
        {
            
            if (Conexion.conectar())
            {
                SqlCommand cmdAgenda = new SqlCommand("Con_GuardarAgenda", Conexion.conexion);
                cmdAgenda.CommandType = CommandType.StoredProcedure;

                cmdAgenda.Parameters.Add("@idEfector", SqlDbType.Int);
                cmdAgenda.Parameters.Add("@idServicio", SqlDbType.Int);
                cmdAgenda.Parameters.Add("@idEspecialidad", SqlDbType.Int);
                cmdAgenda.Parameters.Add("@idTipoPrestacion", SqlDbType.Int);                
                cmdAgenda.Parameters.Add("@idProfesional", SqlDbType.Int);
                cmdAgenda.Parameters.Add("@fecha", SqlDbType.DateTime);
                cmdAgenda.Parameters.Add("@horaInicio", SqlDbType.Char,5);
                cmdAgenda.Parameters.Add("@horaFin", SqlDbType.Char,5);
                cmdAgenda.Parameters.Add("@duracion", SqlDbType.Int);
                cmdAgenda.Parameters.Add("@idConsultorio", SqlDbType.Int);
                cmdAgenda.Parameters.Add("@citarPorBloques", SqlDbType.Bit);
                cmdAgenda.Parameters.Add("@maximoSobreTurnos", SqlDbType.Int);
                cmdAgenda.Parameters.Add("@cantidadInterconsulta", SqlDbType.Int);
                cmdAgenda.Parameters.Add("@idAgendaEstado", SqlDbType.Int);
                cmdAgenda.Parameters.Add("@turnosDisponibles", SqlDbType.Bit);
                cmdAgenda.Parameters.Add("@error", SqlDbType.NVarChar, 1000);


                cmdAgenda.Parameters["@error"].Direction = ParameterDirection.Output;

                cmdAgenda.Parameters[0].Value = agenda.IdEfector;
                cmdAgenda.Parameters[1].Value = agenda.IdServicio;
                cmdAgenda.Parameters[2].Value = agenda.IdEspecialidad;
                cmdAgenda.Parameters[3].Value = agenda.IdTipoPrestacion;
                cmdAgenda.Parameters[4].Value = agenda.IdProfesional;
                cmdAgenda.Parameters[5].Value = agenda.Fecha;
                cmdAgenda.Parameters[6].Value = agenda.HoraInicio;
                cmdAgenda.Parameters[7].Value = agenda.HoraFin;
                cmdAgenda.Parameters[8].Value = agenda.Duracion;
                cmdAgenda.Parameters[9].Value = agenda.IdConsultorio;
                cmdAgenda.Parameters[10].Value = agenda.CitarPorBloques;
                cmdAgenda.Parameters[11].Value = agenda.MaximoSobreturnos;
                cmdAgenda.Parameters[12].Value = agenda.CantidadInterconsulta;
                cmdAgenda.Parameters[13].Value = agenda.IdAgendaEstado;
                cmdAgenda.Parameters[14].Value = agenda.TurnosDisponibles;

                cmdAgenda.ExecuteNonQuery();

                string respuesta = cmdAgenda.Parameters["@error"].Value.ToString();
                //MessageBox.Show(respuesta);
            }
        }
    }
}