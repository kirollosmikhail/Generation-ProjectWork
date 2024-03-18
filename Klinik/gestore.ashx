<%@ WebHandler Language="C#" Class="gestore" %>

using System;
using System.Web;

public class gestore : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        int chiave = int.Parse(context.Request.QueryString["c"].ToString());

        PRESTAZIONI p = new PRESTAZIONI();
        p.idPrestazione = chiave;
        p.SelectId();


        byte[] ImgData = (byte[])p.docPrestazione;
        string contentType = GetContentType(ImgData);

        context.Response.Buffer = true;
        context.Response.Charset = "";
        context.Response.ContentType = contentType;
        context.Response.BinaryWrite(ImgData);
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