using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per PRESTAZIONI
/// </summary>
public class PRESTAZIONI
{
    public int idPrestazione;
    public int? idSanitario;
    public DateTime? DataPrestazione; 
    public DateTime? DataChiusura;
    public string Anamnesi;
    public string Referto;
    public byte[] docPrestazione;
    public PRENOTAZIONI Prenotazione;
    public SANITARI Sanitario;

    
    public PRESTAZIONI()
    {
        
    }


    /// <summary>
    /// Esegue una query di selezione - id come unico parametro - serve per resettare e ricaricare il valore
    /// </summary>
    public void SelectId()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPrestazione", idPrestazione);
        c.Select("PRESTAZIONI_SelectId");
        if (c.dt.Rows.Count == 0)
        {
            return;
        }

        if (int.TryParse(c.dt.Rows[0]["idSanitario"].ToString(), out int id_Sanitario))
        {
            idSanitario = id_Sanitario;
        }

        if (DateTime.TryParse(c.dt.Rows[0]["DataPrestazione"].ToString(), out DateTime Data_Prestazione))
        {
            DataPrestazione = Data_Prestazione;
        }

        if (DateTime.TryParse(c.dt.Rows[0]["DataChiusura"].ToString(), out DateTime Data_Chiusura))
        {
            DataChiusura = Data_Chiusura;
        }

        Anamnesi = c.dt.Rows[0]["Anamnesi"].ToString();
        Referto = c.dt.Rows[0]["Referto"].ToString();

        if (c.dt.Rows[0]["docPrestazione"] != null && c.dt.Rows[0]["docPrestazione"] != DBNull.Value)
        {
            docPrestazione = (byte[])c.dt.Rows[0]["docPrestazione"];
        }

    }

    /// <summary>
    /// Esegue una query di selezione
    /// </summary>
    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("PRESTAZIONI_Select");
        return c.dt;
    }
   

    /// <summary>
    /// Esegue una query di selezione passata tramite parametro (@idPrestazione, @idSanitario, @DataPrestazione, @DataChiusura, @Anamnesi,@Referto, @docPrestazione)
    /// </summary>
    public void Modifica()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPrestazione", idPrestazione);
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario != null ? idSanitario : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataPrestazione", DataPrestazione != null ? DataPrestazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataChiusura", DataChiusura != null ? DataChiusura : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Anamnesi", Anamnesi != null ? Anamnesi : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Referto", Referto != null ? Referto : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@docPrestazione", docPrestazione != null ? docPrestazione : new byte[] { });
        c.Command("PRESTAZIONE_Modifica");
    }
    
    /// <summary>
    /// Esegue una query di comando-insert passata tramite parametro (@idSanitario, @DataPrestazione, @DataChiusura, @Anamnesi,@Referto, @docPrestazione)
    /// </summary>
    public void Inserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.AddParametro("@idPrenotazione");
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario != null ? idSanitario : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataPrestazione", DataPrestazione != null ? DataPrestazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataChiusura", DataChiusura != null ? DataChiusura : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Anamnesi", Anamnesi != null ? Anamnesi : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Referto", Referto != null ? Referto : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@docPrestazione", docPrestazione != null ? docPrestazione : new byte[] { });
        c.Command("PRESTAZIONE_Inserisci");
    }


    public void Inserisci(int? idPrenotazione, int? idPersonale)
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPrenotazione", idPrenotazione != null ? idPrenotazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idPersonale", idPersonale != null ? idPersonale : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario != null ? idSanitario : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataPrestazione", DataPrestazione != null ? DataPrestazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataChiusura", DataChiusura != null ? DataChiusura : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Anamnesi", Anamnesi != null ? Anamnesi : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Referto", Referto != null ? Referto : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@docPrestazione", docPrestazione != null ? docPrestazione : new byte[] { });
        c.Command("PRESTAZIONI_Inserisci");
    }


    public DataTable PrestazioniSelectAperte()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario);
        c.cmd.Parameters.AddWithValue("@DataPrestazione", DataPrestazione);
        c.Select("HomeMedici_PRESTAZIONI_SelectAperte");
        return c.dt;
    }

    public DataTable PrestazioniSelectChiuse()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario);
        c.cmd.Parameters.AddWithValue("@DataChiusura", DataChiusura);
        c.Select("HomeMedici_PRESTAZIONI_SelectChiuse");
        return c.dt;
    }

    public DataTable PrestazioniSelectPerId()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPrestazione", idPrestazione);
        c.Select("HomeMedici_PRESTAZIONI_SelectPerId");
        return c.dt;
    }

    public void PrestazioniInserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario);
        c.cmd.Parameters.AddWithValue("@DataPrestazione", DataPrestazione);
        c.cmd.Parameters.AddWithValue("@DataChiusura", DataChiusura);
        c.cmd.Parameters.AddWithValue("@Anamnesi", Anamnesi);
        c.cmd.Parameters.AddWithValue("@Referto", Referto);
        c.cmd.Parameters.AddWithValue("@docPrestazione", docPrestazione);
        c.Command("HomeMedici_PRESTAZIONI_Inserisci");
    }

    public void PrestazioniModifica()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPrestazione", idPrestazione);
        if (DataChiusura >= SqlDateTime.MinValue.Value && DataChiusura <= SqlDateTime.MaxValue.Value)
            c.cmd.Parameters.AddWithValue("@DataChiusura", DataChiusura);
        else
            c.cmd.Parameters.AddWithValue("@DataChiusura", DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Anamnesi", Anamnesi);
        c.cmd.Parameters.AddWithValue("@Referto", Referto);
        if (docPrestazione is null)
        {
            c.cmd.Parameters.AddWithValue("@docPrestazione", new byte[] { });
        }
        else
        {
            c.cmd.Parameters.AddWithValue("@docPrestazione", docPrestazione);
        }
        c.Command("HomeMedici_PRESTAZIONI_Modifica");
    }
}