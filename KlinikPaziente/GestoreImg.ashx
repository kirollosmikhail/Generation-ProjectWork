<%@ WebHandler Language="C#" Class="GestoreImg" %>

using System;
using System.Web;

public class GestoreImg : IHttpHandler
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
        context.Response.ContentType = "image/*"; //per specificare di che tipo è il file
                                                  //context.Response.ContentType = "application/pdf"; //per specificare di che tipo è il file
        context.Response.BinaryWrite(ImgData); //la stringa esadecimale che è effettivamente il file, come sta nel DB
        context.Response.Flush(); //fa si che il file venga creato e strutturato secondo le mie direttive
        context.Response.End(); //mette il carattere di chiusura del file
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}