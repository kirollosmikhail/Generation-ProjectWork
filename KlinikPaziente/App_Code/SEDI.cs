using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per SEDI
/// </summary>
public class SEDI
{
    public int? idSede;
    public string Indirizzo;
    public string CAP;
    public string Citta;
    public string Provincia;
    public string Telefono;
    public string Email;
    public PRENOTAZIONI Prenotazione;

    public SEDI()
    {
        
    }


    /// <summary>
    /// Esegue una query di selezione - id come unico parametro - serve per resettare e ricaricare il valore
    /// </summary>
    public void SelectId()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idSede", idSede != null ? idSede : (object)DBNull.Value);
        c.Select("SEDI_SelectId");
        if (c.dt.Rows.Count == 0)
        {
            return;
        }

        Indirizzo = c.dt.Rows[0]["Indirizzo"].ToString();
        CAP = c.dt.Rows[0]["CAP"].ToString();
        Citta = c.dt.Rows[0]["Citta"].ToString();
        Provincia = c.dt.Rows[0]["Provincia"].ToString();
        Telefono = c.dt.Rows[0]["Telefono"].ToString();
        Email = c.dt.Rows[0]["Email"].ToString();

    }


    /// <summary>
    /// Esegue una query di selezione
    /// </summary>
    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("SEDI_Select");
        return c.dt;
    }


    /// <summary>
    /// Esegue una query di comando-update passata tramite parametro (@idSede, @Indirizzo, @CAP, @Citta, @Provincia, @Telefono, @Email)
    /// </summary>
    public void Modifica()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idSede", idSede != null ? idSede : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Indirizzo", Indirizzo != null ? Indirizzo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@CAP", CAP != null ? CAP : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Citta", Citta != null ? Citta : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Provincia", Provincia != null ? Provincia : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Telefono", Telefono != null ? Telefono : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Email", Email != null ? Email : (object)DBNull.Value);
        c.Command("SEDI_Modifica");
    }
    
    /// <summary>
    /// Esegue una query di comando-insert passata tramite parametro (@Indirizzo, @CAP, @Citta, @Provincia, @Telefono, @Email)
    /// </summary>
    public void Inserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@Indirizzo", Indirizzo != null ? Indirizzo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@CAP", CAP != null ? CAP : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Citta", Citta != null ? Citta : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Provincia", Provincia != null ? Provincia : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Telefono", Telefono != null ? Telefono : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Email", Email != null ? Email : (object)DBNull.Value);
        c.Command("SEDI_Inserisci");
    }
}