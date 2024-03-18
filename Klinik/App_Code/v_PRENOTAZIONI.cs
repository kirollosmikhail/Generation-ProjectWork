using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per v_PRENOTAZIONI
/// </summary>
public class v_PRENOTAZIONI
{
    public int? idPaziente;
    public int? idPrenotazione;
    public int? idPrestazione;
    public int? idSanitario;
    public int? idTariffario;
    public int? idPersonale;
    public int? idSede;
    public int? idSanitarioRichiesta;
    public bool? Pagato;
    public v_PRENOTAZIONI()
    {
        //
        // TODO: aggiungere qui la logica del costruttore
        //
    }

    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPaziente", idPaziente != null ? idPaziente : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idPrenotazione", idPrenotazione != null ? idPrenotazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idPrestazione", idPrestazione != null ? idPrestazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario != null ? idSanitario : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idTariffario", idTariffario != null ? idTariffario : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idPersonale", idPersonale != null ? idPersonale : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idSede", idSede != null ? idSede : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idSanitarioRichiesta", idSanitarioRichiesta != null ? idSanitarioRichiesta : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Pagato", Pagato != null ? Pagato : (object)DBNull.Value);
        c.Select("v_PRENOTAZIONI_Select");
        return c.dt;
       

    }
}