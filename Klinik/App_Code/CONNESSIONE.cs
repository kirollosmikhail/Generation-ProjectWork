using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descrizione di riepilogo per CONNESSIONE
/// </summary>
public class CONNESSIONE
{
    private SqlConnection conn = new SqlConnection();
    private SqlDataAdapter DA = new SqlDataAdapter();
    public SqlCommand cmd = new SqlCommand();
    public DataTable dt = new DataTable();
    public CONNESSIONE()
    {
        //Scommentare la stringa di connessione per il db ufficiale
        conn.ConnectionString = "Data Source=5.134.124.100\\MSSQLSERVER2019;Initial Catalog=klinik;User ID=generationPro;Password=ProjectW0rk!;Connect Timeout=30;Encrypt=False;";
        //conn.ConnectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=KLINIK;Integrated Security=true";
        cmd.Connection = conn;
    }

    /// <summary>
    /// Esegue una query di selezione passata tramite parametro, popolando dt
    /// </summary>
    /// <param name="queryDiSelezione"></param>
    public void Select(string queryDiSelezione)
    {
        cmd.CommandText = queryDiSelezione;
        cmd.CommandType = CommandType.StoredProcedure;
        DA.SelectCommand = cmd;
        DA.Fill(dt);
    }
    /// <summary>
    /// Esegue una query di comando (insert, update, delete) passata tramite parametro, non restituisce nessun valore
    /// </summary>
    /// <param name="queryDiComando"></param>
    public void Command(string queryDiComando)
    {
        cmd.CommandText = queryDiComando;
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }


    //metodi OVERLOAD
    public void AddParametro(string NomeParametro)
    {
        cmd.Parameters.AddWithValue(NomeParametro, DBNull.Value);
    }
    public void AddParametro(string NomeParametro, string Parametro)
    {
        cmd.Parameters.AddWithValue(NomeParametro, Parametro);
    }

    public void AddParametro(string NomeParametro, DateTime Parametro)
    {
        cmd.Parameters.AddWithValue(NomeParametro, Parametro);
    }

    public void AddParametro(string NomeParametro, int Parametro)
    {
        cmd.Parameters.AddWithValue(NomeParametro, Parametro);
    }

    public void AddParametro(string NomeParametro, decimal Parametro)
    {
        cmd.Parameters.AddWithValue(NomeParametro, Parametro);
    }

    public void AddParametro(string NomeParametro, byte[] Parametro)
    {
        cmd.Parameters.AddWithValue(NomeParametro, Parametro);
    }

    public void AddParametro(string NomeParametro, bool Parametro)
    {
        cmd.Parameters.AddWithValue(NomeParametro, Parametro);
    }

}