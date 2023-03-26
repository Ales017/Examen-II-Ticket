using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class TicketDB
    {
        string cadena = "server=localhost; user=root; database=ticket; password=Alejandro017;";

        public bool Guardar(Ticket1 ticket, List<DetalleTicket> detalles)
        {
            bool inserto = false;
            int idticket = 0;
            try
            {
                StringBuilder sqlticket = new StringBuilder();
                sqlticket.Append(" INSERT INTO ticket (Fecha, IdentidadCliente, CodigoUsuario, ISV, Descuento, SubTotal, Total) VALUES (@Fecha, @IdentidadCliente, @CodigoUsuario, @ISV, @Descuento, @SubTotal, @Total); ");
                sqlticket.Append(" SELECT LAST_INSERT_ID(); ");

                StringBuilder sqlDetalle = new StringBuilder();
                sqlDetalle.Append(" INSERT INTO detalleticket (idTicket, CodigoServicio, Precio, Cantidad, Total) VALUES ( @idTicket, @CodigoServicio, @Precio, @Cantidad, @Total ); ");

                using (MySqlConnection con = new MySqlConnection(cadena))
                {
                    con.Open();

                    MySqlTransaction transaction = con.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                    try
                    {
                        using (MySqlCommand cmd1 = new MySqlCommand(sqlticket.ToString(), con, transaction))
                        {
                            cmd1.CommandType = System.Data.CommandType.Text;
                            cmd1.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = ticket.Fecha;
                            cmd1.Parameters.Add("@IdentidadCliente", MySqlDbType.VarChar, 25).Value = ticket.IdentidadCliente;
                            cmd1.Parameters.Add("@CodigoUsuario", MySqlDbType.VarChar, 50).Value = ticket.CodigoUsuario;
                            cmd1.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = ticket.ISV;
                            cmd1.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = ticket.Descuento;
                            cmd1.Parameters.Add("@SubTotal", MySqlDbType.Decimal).Value = ticket.SubTotal;
                            cmd1.Parameters.Add("@Total", MySqlDbType.Decimal).Value = ticket.Total;
                            idticket = Convert.ToInt32(cmd1.ExecuteScalar());
                        }

                        foreach (DetalleTicket detalle in detalles)
                        {
                            using (MySqlCommand cmd2 = new MySqlCommand(sqlDetalle.ToString(), con, transaction))
                            {
                                cmd2.CommandType = System.Data.CommandType.Text;
                                cmd2.Parameters.Add("@idTicket", MySqlDbType.Int32).Value = idticket;
                                cmd2.Parameters.Add("@CodigoServicio", MySqlDbType.VarChar, 80).Value = detalle.CodigoServicio;
                                cmd2.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = detalle.Precio;
                                cmd2.Parameters.Add("@Cantidad", MySqlDbType.Decimal).Value = detalle.cantidad;
                                cmd2.Parameters.Add("@total", MySqlDbType.Decimal).Value = detalle.Total;
                                cmd2.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        inserto = true;
                    }
                    catch (System.Exception)

                    {
                        inserto = false;
                        transaction.Rollback();
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return inserto;
        }
    }
}
