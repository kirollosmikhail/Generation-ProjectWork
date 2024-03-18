<%@ WebHandler Language="C#" Class="Gestore" %>

using System;
using System.Web;

public class Gestore : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        PRESTAZIONI p = new PRESTAZIONI();
        p.idPrestazione = int.Parse(context.Request.QueryString["c"].ToString()); ;
        p.SelectId();
        byte[] Doc = p.docPrestazione;
        //string tipo;
        SANITARI s = new SANITARI();
        s.idSanitario = p.idSanitario;
        s.SelectId();
        //if (s.Tipologia == "R")
        //    tipo = "image/*";
        //else
        //    tipo = "application/pdf";
        context.Response.Buffer = true;
        context.Response.Charset = "";
        //context.Response.AppendHeader("Content-Disposition", "attachement; filename=Referto.Pdf");
        string contentType = GetContentType(Doc);
        //context.Response.ContentType = tipo;
        context.Response.ContentType = contentType;
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

    private string GetContentType(byte[] fileData)
    {
        if (fileData.Length > 4 && fileData[0] == 0x25 && fileData[1] == 0x50 && fileData[2] == 0x44 && fileData[3] == 0x46)
        {
            return "application/pdf";
        }
        else
        {
            return "image/jpeg";
        }
    }

}