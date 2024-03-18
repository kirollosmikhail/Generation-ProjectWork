using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per SANITARI
/// </summary>
public class SANITARI
{
    public int? idSanitario;
    public int? idSede;
    public string Tipologia;
    public string UserMail;
    public string Password;
    public string Titolo;
    public string Cognome;
    public string Nome;
    public byte[] Foto;
    public decimal? Ricavo;
    public PRESTAZIONI Prestazione;

    public SANITARI()
    {
      
    }


    /// <summary>
    /// Esegue una query di selezione - id come unico parametro - serve per resettare e ricaricare il valore
    /// </summary>
    public void SelectId()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario != null ? idSanitario : (object)DBNull.Value);
        c.Select("SANITARI_SelectId");
        if (c.dt.Rows.Count == 0)
        {
            return;
        }

        if (int.TryParse(c.dt.Rows[0]["idSede"].ToString(), out int id_Sede))
        {
            idSede = id_Sede;
        }

        Tipologia = c.dt.Rows[0]["Tipologia"].ToString();
        UserMail = c.dt.Rows[0]["UserMail"].ToString();
        Password = c.dt.Rows[0]["Password"].ToString();
        Titolo = c.dt.Rows[0]["Titolo"].ToString();
        Cognome = c.dt.Rows[0]["Cognome"].ToString();
        Nome = c.dt.Rows[0]["Nome"].ToString();

        if (c.dt.Rows[0]["Foto"] != null && c.dt.Rows[0]["Foto"] != DBNull.Value)
        {
            Foto = (byte[])c.dt.Rows[0]["Foto"];
        }

        if (decimal.TryParse(c.dt.Rows[0]["Ricavo"].ToString(), out decimal ricavo))
        {
            Ricavo = ricavo;
        }

    }


    /// <summary>
    /// Esegue una query di selezione
    /// </summary>
    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("SANITARI_Select");
        return c.dt;
    }

    /// <summary>
    /// Esegue una query di selezione passata tramite parametro (@UserMail, @Password)
    /// </summary>
    public DataTable Login()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail);
        c.cmd.Parameters.AddWithValue("@Password", Password);
        c.Select("SANITARI_Login");
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
        c.Command("PAZIENTI_ModificaPassword");
    }


    /// <summary>
    /// Esegue una query di selezione passata tramite parametro (@UserMail)
    /// </summary>
    public string RecuperaPassword()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail);
        c.Select("SANITARI_RecuperaPassword");

        if (c.dt.Rows.Count == 0)
        {
            return "";
        }
        return c.dt.Rows[0]["Password"].ToString();
    }

    /// <summary>
    /// Esegue una query di comando-insert passata tramite parametro (@idSede, @Tipologia..)
    /// </summary>
    public void Inserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("idSede", idSede != null ? idSede : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Tipologia", Tipologia != null ? Tipologia : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail != null ? UserMail : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Password", Password != null ? Password : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Titolo", Titolo != null ? Titolo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Cognome", Cognome != null ? Cognome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Nome", Nome != null ? Nome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Foto", Foto != null ? Foto : new byte[] { });
        c.cmd.Parameters.AddWithValue("@Ricavo", Ricavo != null ? Ricavo : (object)DBNull.Value);
        c.Command("SANITARI_Inserisci");
    }
   
    /// <summary>
    /// Esegue una query di comando-update passata tramite parametro (@idSanitario, @idSede..)
    /// </summary>
    public void Modifica()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario);
        c.cmd.Parameters.AddWithValue("@idSede", idSede != null ? idSede : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Tipologia", Tipologia != null ? Tipologia : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@UserMail", UserMail != null ? UserMail : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Password", Password != null ? Password : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Titolo", Titolo != null ? Titolo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Cognome", Cognome != null ? Cognome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Nome", Nome != null ? Nome : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Foto", Foto != null ? Foto : new byte[] { });
        c.cmd.Parameters.AddWithValue("@Ricavo", Ricavo != null ? Ricavo : (object)DBNull.Value);
        c.Command("SANITARI_Modifica");
    }

}