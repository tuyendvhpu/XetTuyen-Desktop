<%@ Page Language="C#" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Security.Cryptography" %>
<%@ Import Namespace="System.Text" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Bitmap bitmap = null;

        if (Session["vtext"] != null)
            bitmap = (Bitmap)CreateVerticalTextImage(
                (Decryption((Session["vtext"]).ToString(), Session["CapSecretKey"].ToString()).Replace("plus", "+").Replace("minus", "-")),                
                Request["size"] == null ? 10.0F : (float) Convert.ToDouble(Request["size"]),
                Request["bold"] == "true",
                Request["italic"] == "true");
        // else if ... - Add other parameters and image generators here

        if (bitmap != null)
        {
            // returns image as transparent GIF, as array of bytes
            bitmap.MakeTransparent(Color.White);
            Response.AddHeader("ContentType", "image/gif");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            byte[] bytes = (byte[])System.ComponentModel
                .TypeDescriptor.GetConverter(bitmap)
                .ConvertTo(bitmap, typeof(byte[]));

            bitmap.Dispose();
            Response.BinaryWrite(bytes);
            Response.Flush();
        }
    }

   
    private System.Drawing.Image CreateVerticalTextImage(string text, float fsize, bool bold, bool italic)
    {
        // set font
        FontStyle fstyle = FontStyle.Regular;
        if (bold) fstyle |= FontStyle.Bold;
        if (italic) fstyle |= FontStyle.Italic;
        Font font = new Font(FontFamily.GenericSerif, fsize, fstyle);

        
        StringFormat format = new StringFormat();
        

        // creates 1Kx1K image buffer
        System.Drawing.Image imageg
            = (System.Drawing.Image)new Bitmap(1000, 1000);
        Graphics g = Graphics.FromImage(imageg);
        SizeF size = g.MeasureString(text, font, 55, format);
        imageg.Dispose();

        System.Drawing.Image image = (System.Drawing.Image)
            new Bitmap((int)size.Width, (int)size.Height);

        g = Graphics.FromImage(image);
        g.FillRectangle(Brushes.White, 0, 0, image.Width, image.Height);
        
        
        // draw text
        g.DrawString(text, font, Brushes.Black, 0, 0, format);
        
        return image;
    }

    public string b64decode(string StrDecode)
    {
        string decodedString = "";
        decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(StrDecode));
        return decodedString;
    }






    public TripleDES CreateDES(string key)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        TripleDES des = new TripleDESCryptoServiceProvider();
        des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(key));
        des.IV = new byte[des.BlockSize / 8];
        return des;
    }


    public string Encryption(string PlainText, string key)
    {
        TripleDES des = CreateDES(key);
        ICryptoTransform ct = des.CreateEncryptor();
        byte[] input = Encoding.Unicode.GetBytes(PlainText);
        return Convert.ToBase64String(ct.TransformFinalBlock(input, 0, input.Length));
    }


    public string Decryption(string CypherText, string key)
    {
        byte[] b = Convert.FromBase64String(CypherText);
        TripleDES des = CreateDES(key);
        ICryptoTransform ct = des.CreateDecryptor();
        byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
        return Encoding.Unicode.GetString(output);
    }
    
    
    
    
    
</script>