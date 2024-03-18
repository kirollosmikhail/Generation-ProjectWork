using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per PRENOTAZIONI
/// </summary>
public class PRENOTAZIONI
{
    public int? idPrenotazione;
    public DateTime? Data;
    public int? idPaziente;
    public int? idSede;
    public int? idPrestazione;
    public int? idTariffario;
    public decimal? Prezzo;
    public bool? Pagato;
    public DateTime? DataPagamento;
    public byte[] docFattura;
    public int? idPersonale;
    public int? idSanitario;
    public PAZIENTI Paziente;
    public PRESTAZIONI Prestazione;
    public PERSONALE Personale;
    public SEDI Sede;
    public TARIFFARIO Tariffario;

    public PRENOTAZIONI()
    {

    }

    /// <summary>
    /// Esegue una query di selezione - id come unico parametro - serve per resettare e ricaricare il valore
    /// </summary>
    public void SelectId()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPrenotazione", idPrenotazione != null ? idPrenotazione : (object)DBNull.Value);
        c.Select("PRENOTAZIONI_SelectId");
        if (c.dt.Rows.Count == 0)
        {
            return;
        }
        if (DateTime.TryParse(c.dt.Rows[0]["Data"].ToString(), out DateTime data))
        {
            Data = data;
        }

        if (int.TryParse(c.dt.Rows[0]["idPaziente"].ToString(), out int id_Paziente))
        {
            idPaziente = id_Paziente;
        }

        if (int.TryParse(c.dt.Rows[0]["idSede"].ToString(), out int id_Sede))
        {
            idSede = id_Sede;
        }

        if (int.TryParse(c.dt.Rows[0]["idPrestazione"].ToString(), out int id_Prestazione))
        {
            idPrestazione = id_Prestazione;
        }

        if (int.TryParse(c.dt.Rows[0]["idTariffario"].ToString(), out int id_Tariffario))
        {
            idTariffario = id_Tariffario;
        }

        if (decimal.TryParse(c.dt.Rows[0]["Prezzo"].ToString(), out decimal prezzo))
        {
            Prezzo = prezzo;
        }

        if (bool.TryParse(c.dt.Rows[0]["Pagato"].ToString(), out bool pagato))
        {
            Pagato = pagato;
        }

        if (DateTime.TryParse(c.dt.Rows[0]["DataPagamento"].ToString(), out DateTime Data_Pagamento))
        {
            DataPagamento = Data_Pagamento;
        }

        if (c.dt.Rows[0]["docFattura"] != null && c.dt.Rows[0]["docFattura"] != DBNull.Value)
        {
            docFattura = (byte[])c.dt.Rows[0]["docFattura"];
        }

        if (int.TryParse(c.dt.Rows[0]["idPersonale"].ToString(), out int id_Personale))
        {
            idPersonale = id_Personale;
        }

        if (int.TryParse(c.dt.Rows[0]["idSanitario"].ToString(), out int id_Sanitario))
        {
            idSanitario = id_Sanitario;
        }
    }


    /// <summary>
    /// Esegue una query di selezione
    /// </summary>
    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("PRENOTAZIONI_Select");
        return c.dt;
    }

    /// <summary>
    /// Esegue una query di comando-update passata tramite parametro (@idPrenotazione, @Data, @idPaziente, @idSede, @idPrestazione, @idTariffario, @Prezzo, @Pagato, @DataPagamento, @docFattura, @idPersonale)
    /// </summary>
    public void Modifica()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idPrenotazione", idPrenotazione);
        c.cmd.Parameters.AddWithValue("@Data", Data != null ? Data : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idPaziente", idPaziente != null ? idPaziente : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idSede", idSede != null ? idSede : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idPrestazione", idPrestazione != null ? idPrestazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idTariffario", idTariffario != null ? idTariffario : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Prezzo", Prezzo != null ? Prezzo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Pagato", Pagato != null ? Pagato : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataPagamento", DataPagamento!= null ? Data : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@docFattura", docFattura != null ? docFattura : new byte[] { });
        c.cmd.Parameters.AddWithValue("@idPersonale", idPersonale != null ? idPersonale : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario != null ? idSanitario : (object)DBNull.Value);
        c.Command("PRENOTAZIONI_Modifica");

    }
    
    /// <summary>
    /// Esegue una query di comando-insert passata tramite parametro (@Data, @idPaziente, @idSede, @idPrestazione, @idTariffario, @Prezzo, @Pagato, @DataPagamento, @docFattura, @idPersonale)
    /// </summary>
    public void Inserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@Data", Data != null ? Data : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idPaziente", idPaziente != null ? idPaziente : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idSede", idSede != null ? idSede : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idPrestazione", idPrestazione != null ? idPrestazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idTariffario", idTariffario != null ? idTariffario : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Prezzo", Prezzo != null ? Prezzo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Pagato", Pagato != null ? Pagato : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@DataPagamento", DataPagamento != null ? DataPagamento : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@docFattura", docFattura != null ? docFattura : new byte[] { });
        c.cmd.Parameters.AddWithValue("@idPersonale", idPersonale != null ? idPersonale : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@idSanitario", idSanitario != null ? idSanitario : (object)DBNull.Value);
        c.Command("PRENOTAZIONI_Inserisci");
    }
}