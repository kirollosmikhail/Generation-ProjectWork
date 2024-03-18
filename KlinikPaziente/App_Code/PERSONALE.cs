using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per PERSONALE
/// </summary>
public class PERSONALE
{
    public int idPersonale;
    public string Tipologia;
    public string UserMail;
    public string Password;
    public string Cognome;
    public string Nome;
    public PRENOTAZIONI Prenotazione;

    public PERSONALE()
    {
        
    }


    /// <summary>
    /// Esegue una query di selezione - id come unico parametro - serve per resettare e ricaricare il valore
    /// </summary>
    public void SelectId()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPersonale", idPersonale);
        c.Select("PERSONALE_SelectId");
        if (c.dt.Rows.Count == 0)
        {
            return;
        }

        Tipologia = c.dt.Rows[0]["Tipologia"].ToString();
        UserMail = c.dt.Rows[0]["UserMail"].ToString();
        Password = c.dt.Rows[0]["Password"].ToString();
        Cognome = c.dt.Rows[0]["Cognome"].ToString();
        Nome = c.dt.Rows[0]["Nome"].ToString();

    }


    /// <summary>
    /// Esegue una query di selezione
    /// </summary>
    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("PERSONALE_Select");
        return c.dt;
    }

    /// <summary>
    /// Esegue una query di selezione passata tramite parametro (@Usermail, @Password)
    /// </summary>
    public DataTable Login()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail);
        c.cmd.Parameters.AddWithValue("@Password", Password);
        c.Select("PERSONALE_Login");
        return c.dt;
    }

    /// <summary>
    /// Esegue una query di comando-update passata tramite parametro (@UserMail, @Password, @NuovaPass)
    /// </summary>
    public void ModificaPassword(string NuovaPassword)
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail);
        c.cmd.Parameters.AddWithValue("@Password", Password); //Vecchia Password
        c.cmd.Parameters.AddWithValue("@NuovaPassword", NuovaPassword);
        c.Command("PERSONALE_ModificaPassword");
    }

    /// <summary>
    /// Esegue una query di selezione passata tramite parametro
    /// </summary>
    public string RecuperaPassword()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail);
        c.Select("PERSONALE_RecuperaPassword");

        if (c.dt.Rows.Count == 0)
        {
            return "";
        }
        return c.dt.Rows[0]["Password"].ToString();
    }

    /// <summary>
    /// Esegue una query di comando-update passata tramite parametro (@idPersonale, @Tipologia, @Cognome, @Nome)
    /// </summary>
    public void Modifica()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPersonale", idPersonale);
        c.cmd.Parameters.AddWithValue("@Tipologia", Tipologia != null ? Tipologia : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail != null ? UserMail : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Password", Password != null ? Password : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Cognome", Cognome != null ? Cognome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Nome", Nome != null ? Nome : (object)DBNull.Value);
        c.Command("PERSONALE_Modifica");
    }

   
    /// <summary>
    /// Esegue una query di comando-insert passata tramite parametro (@idPersonale, @UserMail, @Password, @Tipologia, @Cognome, @Nome)
    /// </summary>
    public void Inserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@Tipologia", Tipologia != null ? Tipologia : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail != null ? UserMail : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Password", Password != null ? Password : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Cognome", Cognome != null ? Cognome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Nome", Nome != null ? Nome : (object)DBNull.Value);
        c.Command("PERSONALE_Inserisci");
    }
}