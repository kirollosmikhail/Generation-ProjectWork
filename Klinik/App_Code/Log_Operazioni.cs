using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

/// <summary>
/// Descrizione di riepilogo per Log_Operazioni
/// </summary>
public class Log_Operazioni
{
    public int idOperazione;
    public string UserMail;
    public DateTime? DataLog;
    public string Programma;
    public string Operazione;
    public PAZIENTI Paziente;
    
    public Log_Operazioni()
    {
        
    }

    /// <summary>
    /// Esegue una query di selezione
    /// </summary>
    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("Log_Operazioni_Select");
        return c.dt;
    }

    /// <summary>
    /// Esegue una query di comando-insert passata tramite parametro (@UserMail, @DataLog, @Programma, @Operazione)
    /// </summary>
    public void Inserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail != null ? UserMail : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataLog", @DataLog != null ? DataLog : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Programma", Programma != null ? Programma : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Operazione", Operazione != null ? Operazione : (object)DBNull.Value);
        c.Command("Log_Operazioni_Inserisci");
    }

    /// <summary>
    /// Esegue una query di comando-truncate tabella
    /// </summary>
    public void EliminaTutto()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Command("Log_Operazioni_EliminaTutto");
    }

}