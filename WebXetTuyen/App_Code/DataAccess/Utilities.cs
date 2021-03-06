using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using PDSA.PDSACryptography;
using System.Runtime.InteropServices;
using System.Web.Configuration;
using System.Text;
using System.Net;
using System.Net.Mail;
using DataAccess;
using Business;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace DataAccess
{

    public class Utilities
    {
        //Keys for crypto functions
      
        private const string CRYPT_KEY = "LvYS7jGJA/XnX6ZOnThgOTBso66vEBzD";
        private const string CRYPT_IV = "RoJAC3pTRP0=";
           
        public static SqlConnection conDBConnection = null;

        private static string sConnStr;

        // Login info

        public static UserInformation uiUserInfo = null;
        private static Users m_CurrentUser;
        private static bool m_IsUserAdmin;
        private static string m_CurrentLanguageID;
        private static string m_DefaultLanguageID;
        private static bool _isDebugMode = false;

        public static bool IsDebugMode
        {
            get { return _isDebugMode; }
            set { _isDebugMode = value; }
        }

        //DateTime, Number Format
        //private static clsUserProfile m_UserProfile;
        //public static clsUserProfile UserProfile
        //{
        //    get { return m_UserProfile; }
        //    set { m_UserProfile = value; }
        //}        
        //END
        public static string StandardString(string strInput)
        {
            string strResult = "";
            if (strInput.Length > 0)
            {
                strInput = strInput.Trim().ToLower();
                while (strInput.Contains("  "))
                    strInput = strInput.Replace("  ", " ");
                
                string[] arrResult = strInput.Split(' ');
                foreach (string item in arrResult)
                    strResult += item.Substring(0, 1).ToUpper() + item.Substring(1) + " ";
            }
            return strResult.TrimEnd();
        }
        public static Users CurrentUser
        {
            get { return m_CurrentUser; }
            set { m_CurrentUser = value; }
        }
        public static bool IsAdminUser
        {
            get { return m_IsUserAdmin; }
            set { m_IsUserAdmin = value; }
        }
        public static string CurrentLanguageID
        {
            get { return m_CurrentLanguageID; }
            set { m_CurrentLanguageID = value; }
        }
        public static string DefaultLanguageID
        {
            get { return m_DefaultLanguageID; }
            set { m_DefaultLanguageID = value; }
        }


        public Utilities()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// GetServerTime
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            DateTime dtServer = Convert.ToDateTime(db.ExecuteScalar("spGetSystemDate"));
            return dtServer;
        }

        public static string UploadFile(System.Web.UI.WebControls.FileUpload strObject, string strPath)
        {
            string strFolderpath = "~/addmin/Tinbai/" + strPath;
            if (strObject.PostedFile != null)
            {
                System.Web.HttpPostedFile pFile = strObject.PostedFile;
                int iFileLen = pFile.ContentLength;
                if (iFileLen == 0)
                {
                    return string.Empty;
                }
                string strEx = System.IO.Path.GetExtension(pFile.FileName);
                switch (strEx.ToLower())
                {
                    case ".gif":
                        break;
                    case ".jpg":
                        break;
                    case ".doc":
                        break;
                    case ".ppt":
                        break;
                    case ".xls":
                        break;
                    default:
                        {
                            return string.Empty;
                        }
                }
                byte[] DataFile = new Byte[iFileLen];
                pFile.InputStream.Read(DataFile, 0, iFileLen);

                string strFileName = System.IO.Path.GetFileName(pFile.FileName);
                int iEx = 0;

                while (System.IO.File.Exists(HttpContext.Current.Server.MapPath(strFolderpath + strFileName)))
                {
                    iEx++;
                    strFileName = System.IO.Path.GetFileNameWithoutExtension(pFile.FileName) + "_" + iEx.ToString() + strEx;
                }
                System.IO.FileStream newFile = new System.IO.FileStream(HttpContext.Current.Server.MapPath(strFolderpath + strFileName), System.IO.FileMode.Create);
                newFile.Write(DataFile, 0, DataFile.Length);
                newFile.Close();
                return strFileName;
            }
            else
            {
                return string.Empty;
            }

        }

        public static string RTESate(string strText)
        {
            string tmString = "";
            tmString = strText.Trim();
            tmString = tmString.Replace(char.ConvertFromUtf32(145), char.ConvertFromUtf32(39));
            tmString = tmString.Replace(char.ConvertFromUtf32(146), char.ConvertFromUtf32(39));
            tmString = tmString.Replace("'", "&#39;");

            tmString = tmString.Replace(char.ConvertFromUtf32(147), char.ConvertFromUtf32(34));
            tmString = tmString.Replace(char.ConvertFromUtf32(148), char.ConvertFromUtf32(34));
            tmString = tmString.Replace(char.ConvertFromUtf32(10), " ");
            tmString = tmString.Replace(char.ConvertFromUtf32(13), " ");
         
            return tmString;
        }
        public static  bool SendMailToQueue(string sMailTo,string sTite,string sBcc,string sCC, string sContent,int iPriority){
            MailQueue mailQueue = new MailQueue();
            mailQueue.ToAddress = sMailTo;
            mailQueue.Tite = sTite;
            mailQueue.Bcc = sBcc;
            mailQueue.Cc = sBcc;
            mailQueue.DateProcessed = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1));
            mailQueue.DateToProcess = DateTime.Now;
            mailQueue.Body = sContent;
            mailQueue.Priority = iPriority;
            return  MailQueueServices.Insert(mailQueue);
        }
        public static bool SendMail(string sMailFrom,string sDisplayName, string sPassword,string sMailTo, string sTite, string sContent)
        {
              try
            {
               // OpenFileDialog dlg = new OpenFileDialog();
               // string filename = dlg.FileName;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer;
                if (sMailFrom.IndexOf("yahoo") >= 0) {
                    SmtpServer = new SmtpClient("smtp.mail.yahoo.com",25);
                    SmtpServer.EnableSsl = false;
                }else
                    if (sMailFrom.IndexOf("gmail") >= 0 || sMailFrom.IndexOf("hpu.edu.vn") > 0)
                    {
                        SmtpServer = new SmtpClient("smtp.gmail.com", 587);//or 465
                        SmtpServer.Credentials = new System.Net.NetworkCredential(sMailFrom, sPassword);
                        SmtpServer.EnableSsl = true;
 
                    }
                    else {
                        int Kytu = -1;
                        Kytu = sMailTo.IndexOf("@")+1;
                        string smtp = sMailFrom;
                        string str = sMailFrom.Substring(0,Kytu);
                        smtp = smtp.Replace(str,"mail.");

                        SmtpServer = new SmtpClient(smtp);
                        SmtpServer.EnableSsl = false;
                    }

                SmtpServer.Timeout = 20000;
                mail.From = new MailAddress(sMailFrom,sDisplayName);
                mail.To.Add(sMailTo);
                mail.Subject = sTite;
                mail.IsBodyHtml = true;
                mail.Body = sContent;
              //  Attachment attachment = new Attachment(filename);
              //  mail.Attachments.Add(attachment);
                
                SmtpServer.Send(mail);
                
            }catch(Exception ex){
                return false;
                  }
            return true;
        }
        #region "Database connection functions"

        public static bool getConnection()
        {
            
                conDBConnection = new SqlConnection();
                      
                buildConnStr();
                conDBConnection.ConnectionString = sConnStr;
                conDBConnection.Open();
                 return true;
        }

        private static void buildConnStr()
        {
            sConnStr = "";

            sConnStr = WebConfigurationManager.ConnectionStrings["XetTuyenConStr"].ConnectionString.ToString();
        }
        #endregion

        
        #region "Security functions"

        // Hashing function
        public static string hashString(string sSource)
        {
            SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
            byte[] bytValue;
            byte[] bytHash;

            // Convert the original string to array of Bytes
            bytValue = System.Text.Encoding.UTF8.GetBytes(sSource);

            // Compute the Hash, returns an array of Bytes
            bytHash = SHA1.ComputeHash(bytValue);

            SHA1.Clear();
            return Convert.ToBase64String(bytHash);
        }

        // Check password
        public static bool checkPassword(string sPassword, string sOriginal)
        {
            return sOriginal.Equals(hashString(sPassword));
        }

        // Encrypt function
        public static string encryptString(string sOriginal)
        {
            PDSASymmetric ps = new PDSASymmetric(PDSASymmetric.PDSAEncryptionType.TripleDES);
            ps.KeyString = CRYPT_KEY;
            ps.IVString = CRYPT_IV;
            return ps.Encrypt(sOriginal);

        }
        
        
        // Decrypt function
        public static string decryptString(string sEncrypted)
        {
            PDSASymmetric ps = new PDSASymmetric(PDSASymmetric.PDSAEncryptionType.TripleDES);
            ps.KeyString = CRYPT_KEY;
            ps.IVString = CRYPT_IV;
            return ps.Decrypt(sEncrypted);
        }
        public static string encryptMD5String(string sOriginal)
        {
            // byte[] pass = Encoding.UTF8.GetBytes(sOriginal);
            
             //MD5 md5 = new MD5CryptoServiceProvider();
            // string strPassword = Encoding.UTF8.GetString(md5.ComputeHash(pass));
            // return strPassword;
            return FormsAuthentication.HashPasswordForStoringInConfigFile(sOriginal, "MD5");

         }
       
        #endregion
    }
}
