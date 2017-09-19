using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Form_Rewriter
/// </summary>
public class FormRewriterControlAdapter : System.Web.UI.Adapters.ControlAdapter
{

    protected override void Render(System.Web.UI.HtmlTextWriter writer)
    {

        base.Render(new RewriteFormHtmlTextWriter(writer));

    }

}

public class RewriteFormHtmlTextWriter : HtmlTextWriter
{

    public RewriteFormHtmlTextWriter(HtmlTextWriter writer)
        : base(writer)
    {

        this.InnerWriter = writer.InnerWriter;

    }

    public override void WriteAttribute(string name, string value, bool fEncode)
    {

        if (name == "action")
        {

            HttpContext Context;

            Context = HttpContext.Current;

            if (Context.Items["ActionAlreadyWritten"] == null)
            {

                value = Context.Request.RawUrl;

                Context.Items["ActionAlreadyWritten"] = true;

            }

        }

        base.WriteAttribute(name, value, fEncode);

    }

}


