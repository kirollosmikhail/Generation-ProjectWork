<%@ WebHandler Language="C#" Class="GestorePrenotazioni" %>

using System;
using System.Web;

public class GestorePrenotazioni : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        PRENOTAZIONI p = new PRENOTAZIONI();
        p.idPrenotazione = int.Parse(context.Request.QueryString["c"].ToString()); ;
        p.SelectId();
        byte[] Doc = p.docFattura;
        //SANITARI s = new SANITARI();
        //s.idSanitario = p.idSanitario;
        //s.SelectId();
        //if (s.Tipologia != "R")
        //{
        string tipo = "application/pdf";
        context.Response.Buffer = true;
        context.Response.Charset = "";
        //context.Response.AppendHeader("Content-Disposition", "attachement; filename=Referto.Pdf");
        context.Response.ContentType = tipo;
        context.Response.BinaryWrite(Doc);
        context.Response.Flush();
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}