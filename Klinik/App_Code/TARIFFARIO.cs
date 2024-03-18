using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per TARIFFARIO
/// </summary>
public class TARIFFARIO
{
    public int? idTariffario;
    public string Tipo;
    public string Prestazione;
    public decimal? Prezzo;
    public PRENOTAZIONI Prenotazione;

    public TARIFFARIO()
    {
       
    }

    /// <summary>
    /// Esegue una query di selezione - id come unico parametro - serve per resettare e ricaricare il valore
    /// </summary>
    public void SelectId()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idTariffario", idTariffario != null ? idTariffario : (object)DBNull.Value);
        c.Select("TARIFFARIO_SelectId");
        if (c.dt.Rows.Count == 0)
        {
            return;
        }

        Tipo = c.dt.Rows[0]["Tipo"].ToString();
        Prestazione = c.dt.Rows[0]["Prestazione"].ToString();
        if (decimal.TryParse(c.dt.Rows[0]["Prezzo"].ToString(), out decimal prezzo))
        {
            Prezzo = prezzo;
        }

    }


    /// <summary>
    /// Esegue una query di selezione
    /// </summary>
    public DataTable Select()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.Select("TARIFFARIO_Select");
        return c.dt;
    }

    /// <summary>
    /// Esegue una query di comando-update passata tramite parametro (@idTariffario, @Tipo, @Prestazione, @Prezzo)
    /// </summary>
    public void Modifica()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@idTariffario", idTariffario != null ? idTariffario : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Tipo", Tipo != null ? Tipo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Prestazione", Prestazione != null ? Prestazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Prezzo", Prezzo != null ? Prezzo : (object)DBNull.Value);
        c.Command("TARIFFARIO_Modifica");
    }

    /// <summary>
    /// Esegue una query di comando-insert passata tramite parametro (@Tipo, @Prestazione, @Prezzo)
    /// </summary>
    public void Inserisci()
    {
        CONNESSIONE c = new CONNESSIONE();
        c.cmd.Parameters.AddWithValue("@Tipo", Tipo != null ? Tipo : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Prestazione", Prestazione != null ? Prestazione : (object)DBNull.Value);
        c.cmd.Parameters.AddWithValue("@Prezzo", Prezzo != null ? Prezzo : (object)DBNull.Value);
        c.Command("TARIFFARIO_Inserisci");
    }

}