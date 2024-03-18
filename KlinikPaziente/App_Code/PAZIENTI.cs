using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per PAZIENTI
/// </summary>
public class PAZIENTI
{
    public int? idPaziente;
    public string UserMail;
    public string Password;
    public string Cognome;
    public string Nome;
    public string Genere;
    public DateTime? DataNascita;
    public string CodFiscale;
    public string Indirizzo;
    public string CAP;
    public string Citta;
    public string Provincia;
    public string Telefono;
    public PRENOTAZIONI Prenotazione;

    public PAZIENTI()
    {

    }


    /// <summary>
    /// Esegue una query di selezione - id come unico parametro - serve per resettare e ricaricare il valore
    /// </summary>
    public void SelectId()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPaziente", idPaziente != null ? idPaziente : (object)DBNull.Value);
        c.Select("PAZIENTI_SelectId");
        if (c.dt.Rows.Count == 0)
        {
            return;
        }

        UserMail = c.dt.Rows[0]["UserMail"].ToString();
        Password = c.dt.Rows[0]["Password"].ToString();
        Cognome = c.dt.Rows[0]["Cognome"].ToString();
        Nome = c.dt.Rows[0]["Nome"].ToString();
        Genere = c.dt.Rows[0]["Genere"].ToString();
        if (DateTime.TryParse(c.dt.Rows[0]["DataNascita"].ToString(), out DateTime Data_Nascita))
        {
            DataNascita = Data_Nascita;
        }
        CodFiscale = c.dt.Rows[0]["CodFiscale"].ToString();
        Indirizzo = c.dt.Rows[0]["Indirizzo"].ToString();
        CAP = c.dt.Rows[0]["CAP"].ToString();
        Citta = c.dt.Rows[0]["Citta"].ToString();
        Provincia = c.dt.Rows[0]["Provincia"].ToString();
        Telefono = c.dt.Rows[0]["Telefono"].ToString();

    }

    /// <summary>
    /// Esegue una query di selezione
    /// </summary>
    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("PAZIENTI_Select");
        return c.dt;
    }

    /// <summary>
    /// Esegue una query di selezione per il LOGIN, passata tramite parametro (@UserMail, @Password)
    /// </summary>
    //public int Login()
    //{
    //    CONNESSIONE c = new CONNESSIONE();
    //    c.cmd.Parameters.AddWithValue("@UserMail", UserMail);
    //    c.cmd.Parameters.AddWithValue("@Password", Password);
    //    c.Select("PAZIENTI_Login");

    //    if (c.dt.Rows.Count == 0)
    //    {
    //        return 0;
    //    }
    //    int _idPaziente = int.Parse(c.dt.Rows[0]["idPaziente"].ToString());
    //    return _idPaziente;
    //}


    /// <summary>
    /// Esegue una query di comando-update passata tramite parametro (@UserMail, @Password, @NuovaPass)
    /// </summary>
    //public void ModificaPassword(string NuovaPassword)
    //{
    //    CONNESSIONE c = new CONNESSIONE();
    //    c.cmd.Parameters.AddWithValue("@UserMail", UserMail);
    //    c.cmd.Parameters.AddWithValue("@Password", Password); //Vecchia Password
    //    c.cmd.Parameters.AddWithValue("@NuovaPassword", NuovaPassword);
    //    c.Command("PAZIENTI_ModificaPassword");
    //}


    /// <summary>
    /// Esegue una query di selezione passata tramite parametro
    /// </summary>
    //public string RecuperaPassword()
    //{
    //    CONNESSIONE c = new CONNESSIONE();
    //    c.cmd.Parameters.AddWithValue("@UserMail", UserMail);
    //    c.Select("PAZIENTI_RecuperaPassword");

    //    if (c.dt.Rows.Count == 0)
    //    {
    //        return "";
    //    }
    //    return c.dt.Rows[0]["Password"].ToString();
    //}


    /// <summary>
    /// Esegue una query di comando-insert passata tramite parametro (@UserMail, @Password..)
    /// </summary>
    public void Pazienti_Inserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail != null ? UserMail : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Password", Password != null ? Password : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Cognome", Cognome != null ? Cognome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Nome", Nome != null ? Nome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Genere", Genere != null ? Genere : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataNascita", DataNascita != null ? DataNascita : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@CodFiscale", CodFiscale != null ? CodFiscale : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Indirizzo", Indirizzo != null ? Indirizzo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@CAP", CAP != null ? CAP : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Citta", Citta != null ? Citta : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Provincia", Provincia != null ? Provincia : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Telefono", Telefono != null ? Telefono : (object)DBNull.Value);
        c.Command("PAZIENTI_Inserisci");
    }



    /// <summary>
    /// Esegue una query di comando-update passata tramite parametro (@UserMail, @Password..)
    /// </summary>
    public void Pazienti_Modifica()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPaziente", idPaziente != null ? idPaziente : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail != null ? UserMail : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Password", Password != null ? Password : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Cognome", Cognome != null ? Cognome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Nome", Nome != null ? Nome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Genere", Genere != null ? Genere : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataNascita", DataNascita != null ? DataNascita : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@CodFiscale", CodFiscale != null ? CodFiscale : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Indirizzo", Indirizzo != null ? Indirizzo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@CAP", CAP != null ? CAP : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Citta", Citta != null ? Citta : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Provincia", Provincia != null ? Provincia : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Telefono", Telefono != null ? Telefono : (object)DBNull.Value);
        c.Command("PAZIENTI_Modifica");
    }

}