<%@ WebHandler Language="C#" Class="GestoreFotoSanitari" %>

using System;
using System.Web;
using System.Data;

public class GestoreFotoSanitari : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int chiave = int.Parse(context.Request.QueryString["c"].ToString());
        //devo mettere il context prima di tutto, perchè lavora su un livello più alto

        //connessione al DB
        SANITARI s = new SANITARI();
        s.idSanitario = chiave;
        s.SelectId();

        byte[] ImgData = s.Foto;

        context.Response.Buffer = true;
        context.Response.Charset = "";
        //context.Response.AppendHeader("Content-Disposition", "attachement; filename=image.jpeg");
        context.Response.ContentType = "image/*"; //per specificare di che tipo è il file
        context.Response.BinaryWrite(ImgData); //la stringa esadecimale che è effettivamente il file, come sta nel DB
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