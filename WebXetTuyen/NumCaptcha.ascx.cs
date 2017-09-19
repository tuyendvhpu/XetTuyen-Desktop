using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

public partial class Controls_Levioza_levcaptcha : System.Web.UI.UserControl
{
    /***************Extend the control plz dont modify********************/
    int num1 = 0, num2 = 0, operators = 0, n = 0, _CalcMode = 1;
    protected string _message = "Wrong Verification.";
    protected bool _enable = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Page.IsPostBack)
        {
            DisplayImage();
            
            //NotMatching();
        }

        if (this.Enable == true)
        {
            TextBoxNo.Enabled = true;
        }
        else
        {
            TextBoxNo.Enabled = false;
        }
    }

    /* no need * */
    public int value {
        get { return Convert.ToInt32(TextBoxNo.Text); }
    }


    public int CalcMode
    {
        get { return _CalcMode; }
        set { _CalcMode = value; }
    }


    public string message {
        get { return _message; }
        set { _message = value; }
    }

    public bool Enable {
        get { return _enable; }
        set {_enable = value;}
    }

    public void Refresh()
    {
        DisplayImage();
        TextBoxNo.Text = "";
        lblMessage.Text = "";
    }

    private void DisplayImage()
    {
        Random randNum = new Random();
        num1 = randNum.Next(1, 9);
        num2 = randNum.Next(1, 9);

        if (_CalcMode == 1)
            operators = randNum.Next(0, 9);
        else if (_CalcMode == 2)
            operators = 1;
        else if (_CalcMode == 3)
            operators = 7;
        else
            operators = randNum.Next(0, 9);

        int keylen = randNum.Next(5, 9);


        Session["num1"] = "";
        if (operators <= 5)
        {
            if (num2 > num1)
            {
                string CapSecretKey = CreateRandomKey(keylen);
                Session["CapSecretKey"] = CapSecretKey;
                Session["vtext"] = Encryption(num2 + " minus " + num1, CapSecretKey);
                Image1.ImageUrl = "Captcha.aspx?bold=true&italic=true&size=14";
                Session["result"] = Convert.ToString(num2 - num1);
            }
            else
            {
                string CapSecretKey = CreateRandomKey(keylen);
                Session["CapSecretKey"] = CapSecretKey;
                Session["vtext"] = Encryption(num1 + " minus " + num2, CapSecretKey);
                Image1.ImageUrl = "Captcha.aspx?bold=true&italic=true&size=14";
                Session["result"] = Convert.ToString(num1 - num2);
            }
        }
        else
        {
            string CapSecretKey = CreateRandomKey(keylen);
            Session["CapSecretKey"] = CapSecretKey;
            Session["vtext"] = Encryption(num1 + " plus " + num2, CapSecretKey);
            Image1.ImageUrl = "Captcha.aspx?bold=true&italic=true&size=14";
            Session["result"] = Convert.ToString(num2 + num1);
        }
    }

    public static string CreateRandomKey(int RandKeyLength)
    {
        string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        Random randNum = new Random();
        char[] chars = new char[RandKeyLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < RandKeyLength; i++)
        {
            int KeyPosition = (int)((_allowedChars.Length) * (Math.Truncate(randNum.NextDouble() * 100) / 100));
            chars[i] = _allowedChars[KeyPosition];
        }
        return new string(chars);
    }

    public string b64encode(string StrEncode)
    {
        string encodedString = "";
        encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(StrEncode)));
        return encodedString;
    }


    public bool Decide()
    {
        if (Session["result"] != null)
        {

	try{
	    lblMessage.Text = "";
	    int userno = Convert.ToInt32(TextBoxNo.Text);
	    int controlno = Convert.ToInt32(Session["result"].ToString());
            if (userno != controlno)
            {
                TextBoxNo.Text = "";
                lblMessage.Visible = true;
                lblMessage.Focus();
                TextBoxNo.Focus();
                lblMessage.Text = _message; //"Wrong Verification.";
                DisplayImage();
                return false;
            }
            else
            {
                return true;
            }
	}
	catch(Exception e)
	{
		TextBoxNo.Text = "";
                lblMessage.Visible = true;
                lblMessage.Focus();
                TextBoxNo.Focus();
                lblMessage.Text = _message; //"Wrong Verification.";
                DisplayImage();
                return false;
	}

        }
        else
        {
            DisplayImage();
            return false;
        }
    }

    public void NotMatching() {
        if (Session["result"] != null) {

	try{
	    lblMessage.Text = "";
	    int userno = Convert.ToInt32(TextBoxNo.Text);
	    int controlno = Convert.ToInt32(Session["result"].ToString());
            if (userno != controlno)
            {

            if (TextBoxNo.Text != Session["result"].ToString()) {
                lblMessage.Visible = true;
                DisplayImage();
                lblMessage.Focus();
                lblMessage.Text = _message;  //"Wrong Verification.";
                DisplayImage();
            } else {
                DisplayImage();
            }
}
	}
	catch(Exception e)
	{
		TextBoxNo.Text = "";
                lblMessage.Visible = true;
                lblMessage.Focus();
                TextBoxNo.Focus();
                lblMessage.Text = _message; //"Wrong Verification.";
                DisplayImage();
	}
        } else {
            DisplayImage();
        }
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

}

