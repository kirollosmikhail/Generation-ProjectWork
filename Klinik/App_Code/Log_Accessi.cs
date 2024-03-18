using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per Log_Accessi
/// </summary>
public class Log_Accessi
{
    public int idAccesso;
    public string IndirizzoIP ;
    public string Utente;
    public DateTime? DataLog;
    public bool? Esito;
    public Log_Accessi()
    {
        
    }

    /// <summary>
    /// Esegue una query di selezione
    /// </summary>
    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("Log_Accessi_Select");
        return c.dt;
    }

    /// <summary>
    /// Esegue una query di comando-insert passata tramite parametro (@IndirizzoIP, @Utente, @DataLog, @Esito)
    /// </summary>
    public void Inserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@IndirizzoIP", IndirizzoIP != null ? IndirizzoIP : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Utente", Utente != null ? Utente : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataLog", DataLog != null ? DataLog : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Esito", Esito != null ? Esito : (object)DBNull.Value);
        c.Command("Log_Accessi_Inserisci");
    }

    /// <summary>
    /// Esegue una query di comando-truncate tabella
    /// </summary>
    public void EliminaTutto()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Command("Log_Accessi_EliminaTutto");
    }
}