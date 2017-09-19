using System;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using PDSA.PDSACryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;
using XetTuyen;
using System.Text;
using System.Net.Mail;
using BusinessLogic;
using BusinessService;
using DataAccess;
using System.Globalization;
using System.Text.RegularExpressions;
namespace Common
{
    class Utilities
    {
        //Keys for crypto functions
        private const string SETTING_FILENAME = "SETTING.DAT";
        private const string COMPANY_FILENAME = "COMPANY.DAT";
        private const string PARAMASTER_FILENAME = "PARAMASTER.DAT";
        private const string CRYPT_KEY = "LQC/6AWACzRJhD62WT8tyg96USOXJXx5";
        private const string CRYPT_IV = "n0D4I3Z2qcc=";
        private static Users m_CurrentUser;
        private static bool m_IsUserAdmin;
        private static string m_CurrentLanguageID;
        private static string m_DefaultLanguageID;
        public enum FormMode
        {
            Normal,
            AddNew,
            Edit
        }
        public enum FormLoadAction
        {
            Normal,
            AddNew,
            Edit
        }
       
        #region "Class members"
        public const string sDefaultDBName = "Cuongnt";
        // Configuration info
        public static ApplicationConfig acAppConfig = new ApplicationConfig();
        
        // Company config
        public static CompanyConfig acCompConfig = new CompanyConfig();
        
        // Company config
        public static ParamasterConfig acParaConfig = new ParamasterConfig();
        // Database connection info
        public static SqlConnection conDBConnection = null;

        public static string sConnStr;

        // Login info

        public static UserInformation uiUserInfo = null;
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
        #endregion

        #region Common


        /// <summary> 
        /// Get datetime in server
        /// input no 
        /// </summary> 
        public static DateTime GetServerTime()
        {
            DbAccess db = new DbAccess();
            db.CreateNewSqlCommand();
            DateTime dtServer = Convert.ToDateTime(db.ExecuteScalar("spGetSystemDate"));
            return dtServer;
        }
        /// <summary> 
        /// Read number to curent
        /// input decimal number
        /// </summary> 

        public static string str = " ";

        public static string ToStringMoney(decimal number)
        {
            str = " ";
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;

            bool booAm = false;
            decimal decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "năm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            return str;// = str+ "đồng chẵn";

        }
        private static string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
        private static string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
      
        // Hàm đọc số thành chữ

        public static string DocTienBangChu(long SoTien, string strTail)
        {
            int lan, i;
            long so;
            string KetQua = "", tmp = "";
             int[] ViTri = new int[6];
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
            {
                so = SoTien;
            }
            else
            {
                so = -SoTien;
            }
            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }
            for (i = lan; i >= 0; i--)
            {
                
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i].ToString();
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + " " + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        // Hàm đọc số có 3 chữ số
        private static string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " năm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }

        public static string getDateString(DateTime d)
        {
            string s;
            if (d.Month.ToString().Length > 1)
            {
                s = d.Month.ToString() + "/";
            }
            else
            {
                s = "0" + d.Month.ToString() + "/";
            }

            if (d.Day.ToString().Length > 1)
            {
                s = s + d.Day.ToString() + "/";
            }
            else
            {
                s = s + "0" + d.Day.ToString() + "/";
            }




            s = s + d.Year.ToString();
            return s;
        }

        ///Diffdate
        public enum DateInterval
        {
            Year,
            Month,
            Weekday,
            Day,
            Hour,
            Minute,
            Second
        }

        /// <summary> 
        ///Send mail
        /// input decimal number
        /// </summary> 
        public static bool SendMail(string sMailFrom, string sDisplayName, string sPassword, string sMailTo, string sTite, string sContent)
        {
            try
            {
                // OpenFileDialog dlg = new OpenFileDialog();
                // string filename = dlg.FileName;

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer;
                if (sMailFrom.IndexOf("yahoo") >= 0)
                {
                    SmtpServer = new SmtpClient("smtp.mail.yahoo.com", 25);
                    SmtpServer.EnableSsl = false;
                }
                else
                    if (sMailFrom.IndexOf("gmail") >= 0 || sMailFrom.IndexOf("hpu.edu.vn") > 0)
                    {
                        SmtpServer = new SmtpClient("smtp.gmail.com", 587);//or 465
                        SmtpServer.Credentials = new System.Net.NetworkCredential(sMailFrom, sPassword);
                        SmtpServer.EnableSsl = true;

                    }
                    else
                    {
                        int Kytu = -1;
                        Kytu = sMailTo.IndexOf("@") + 1;
                        string smtp = sMailFrom;
                        string str = sMailFrom.Substring(0, Kytu);
                        smtp = smtp.Replace(str, "mail.");

                        SmtpServer = new SmtpClient(smtp);
                        SmtpServer.EnableSsl = false;
                    }

                SmtpServer.Timeout = 20000;
                mail.From = new MailAddress(sMailFrom, sDisplayName);
                mail.To.Add(sMailTo);
                mail.Subject = sTite;
                mail.IsBodyHtml = true;
                mail.Body = sContent;
                //  Attachment attachment = new Attachment(filename);
                //  mail.Attachments.Add(attachment);

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary> 
        ///Compare date
        /// input decimal number
        /// </summary> 
        public static long DateDiff(DateInterval interval, DateTime date1, DateTime date2)
        {

            TimeSpan ts = date2 - date1;

            switch (interval)
            {
                case DateInterval.Year:
                    return date2.Year - date1.Year;
                case DateInterval.Month:
                    return (date2.Month - date1.Month) + (12 * (date2.Year - date1.Year));
                case DateInterval.Weekday:
                    return Fix(ts.TotalDays) / 7;
                case DateInterval.Day:
                    return Fix(ts.TotalDays);
                case DateInterval.Hour:
                    return Fix(ts.TotalHours);
                case DateInterval.Minute:
                    return Fix(ts.TotalMinutes);
                default:
                    return Fix(ts.TotalSeconds);
            }
        }

        private static long Fix(double Number)
        {
            if (Number >= 0)
            {
                return (long)Math.Floor(Number);
            }
            return (long)Math.Ceiling(Number);
        }


        public static NumberFormatInfo NumberFormat
        {
            get { return CultureInfo.CurrentCulture.NumberFormat; }

        }

        private static string VALID_CHARACTERS_EMAIL = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";


        /// <summary>        
        /// Check inputed string is right email format
        /// </summary>
        /// <param name="strEmailAddress">Email Address</param>
        /// <returns>true/false</returns>
        public static bool CheckEmailAddress(string strEmailAddress)
        {
            Match emailAddressMatch = Regex.Match(strEmailAddress, VALID_CHARACTERS_EMAIL);

            if (emailAddressMatch.Success)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Save Successfully
        /// </summary>
        public static void SaveSuccessfully()
        {
            MessageBox.Show("Lưu thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Save Not Successfully
        /// </summary>
        public static void SaveNotSuccessfully()
        {
            MessageBox.Show("Lưu không thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Delete Confirmation
        /// </summary>
        public static DialogResult ConfirmDeletion()
        {
            return MessageBox.Show("Bạn có chắc chắn muốn xoá hay không ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult DeleteSuccessfully()
        {
            return MessageBox.Show("Xoá thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult DeleteNotSuccessfully()
        {
            return MessageBox.Show("Xoá không thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Delete Confirmation
        /// </summary>
        public static DialogResult ConfirmChangedData()
        {
            return MessageBox.Show("Dữ liệu đã thay đổi, bạn có muốn lưu hay không ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion





        #region "Database connection functions"

        public static bool getConnection()
        {
            if (conDBConnection == null)
            {
                conDBConnection = new SqlConnection();
            }
            bool bConnected = false;
            frmConfig frm = null;
            frmConnecting frmConnect = new frmConnecting();
            DialogResult dlgResult;

            if (!loadConfig())
            {
                createDefaultConfig();
            }

            while (!bConnected)
            {
                try
                {
                    frmConnect.Show();
                   Application.DoEvents();
                    buildConnStr();
                    conDBConnection.ConnectionString = sConnStr;
                    conDBConnection.Open();
                    bConnected = true;
                    frmConnect.Close();
                }
                catch
                {
                    if (frm == null)
                    {
                        frm = new frmConfig();
                    }
                    frmConnect.Hide();
                    dlgResult = frm.ShowDialog();
                    if (dlgResult == DialogResult.Cancel)
                    {
                        MessageBox.Show("Không kết nối được tới cơ sở dữ liệu." + Environment.NewLine + "Hãy kiểm tra lại máy chủ cơ sở dữ liệu và khởi động lại chương trình!", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        return false;
                    }
                }
            }
            return true;
        }


        public static Boolean checkForSQLInjection(string userInput)
        {
            bool isSQLInjection = false;
            string[] sqlCheckList = { "--",
                                       ";--",
                                       ";",
                                       "/*",
                                       "*/",
                                        "@@",
                                        "@",
                                        "char",
                                       "nchar",
                                       "varchar",
                                       "nvarchar",
                                       "alter",
                                       "begin",
                                       "cast",
                                       "create",
                                       "cursor",
                                       "declare",
                                       "delete",
                                       "drop",
                                       "end",
                                       "exec",
                                       "execute",
                                       "fetch",
                                            "insert",
                                          "kill",
                                             "select",
                                           "sys",
                                            "sysobjects",
                                            "syscolumns",
                                           "table",
                                           "update"
                                       };

            string CheckString = userInput.Replace("'", "''");
            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if ((CheckString.IndexOf(sqlCheckList[i],
    StringComparison.OrdinalIgnoreCase) >= 0))
                { isSQLInjection = true; }
            }
            return isSQLInjection;
        }
        public static void buildConnStr()
        {
            sConnStr = "";

            sConnStr = "Data Source=" + acAppConfig.sDBServer + ";Initial Catalog=" + acAppConfig.sDBDatabase + ";Connection Timeout=5";
            if (acAppConfig.bDBTrustedConnection)
                sConnStr = sConnStr + ";Integrated Security=True";
            else
                sConnStr = sConnStr + ";User ID=" + acAppConfig.sDBUserName + ";Password=" + acAppConfig.sDBPassword;
        }
        #endregion

        #region "Configuration functions"

        public static bool saveCompany(CompanyConfig CompSetting)
        {
            string sFileName;
            FileStream fs = null;
            try
            {
                sFileName = Application.StartupPath + "\\" + COMPANY_FILENAME;
                fs = new FileStream(sFileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, CompSetting);
                fs.Close();
            }
            catch
            {

                fs.Close();
                return false;
            }
            return true;
        }

        public static bool saveParamaster(ParamasterConfig ParaSetting)
        {
            string sFileName;
            FileStream fs = null;
            try
            {
                sFileName = Application.StartupPath + "\\" + PARAMASTER_FILENAME;
                fs = new FileStream(sFileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, ParaSetting);
                fs.Close();
            }
            catch
            {

                fs.Close();
                return false;
            }
            return true;
        }

        public static bool loadCompany()
        {
            string sFileName;
            FileStream fs = null;
            try
            {
                sFileName = Application.StartupPath + "\\" + COMPANY_FILENAME;
                fs = new FileStream(sFileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                acCompConfig = (CompanyConfig)bf.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                fs.Close();
                return false;
            }
            return true;
        }
        public static bool loadParamaster()
        {
            string sFileName;
            FileStream fs = null;
            try
            {
                sFileName = Application.StartupPath + "\\" + PARAMASTER_FILENAME;
                fs = new FileStream(sFileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                acParaConfig = (ParamasterConfig)bf.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                fs.Close();
                return false;
            }
            return true;
        }

        public static bool saveConfig(ApplicationConfig AppSetting)
        {
            string sFileName;
            FileStream fs = null;
            try
            {
                sFileName = Application.StartupPath + "\\" + SETTING_FILENAME;
                fs = new FileStream(sFileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, acAppConfig);
                fs.Close();
            }
            catch
            {
                fs.Close();
                return false;
            }
            return true;
        }

        public static bool createDefaulCompany()
        {
            acCompConfig.Header = "ĐẠI HỌC DÂN LẬP HẢI PHÒNG";
            acCompConfig.Name = "Đại học Dân lập Hải Phòng";
            acCompConfig.Address = "Địa chỉ: Số 36 - Đường Dân Lập - Phường Dư Hàng Kênh - Quận Lê Chân - TP Hải Phòng ";
            acCompConfig.Phone = "0313740577 - 0313833802";
            acCompConfig.Fax = "0313740577";
            acCompConfig.Mail = "webmaster@hpu.edu.vn";
            acCompConfig.Logo = "";
            acCompConfig.so = 1;
            return saveCompany(acCompConfig);
        }
     
        public static bool createDefaultConfig()
        {
            acAppConfig.sDBServer = ".\\SQLEXPRESS";
            acAppConfig.sDBDatabase = sDefaultDBName;
            acAppConfig.sDBUserName = "sa";
            acAppConfig.sDBPassword = "123456";
            acAppConfig.bDBTrustedConnection = false;
            return saveConfig(acAppConfig);
        }

        public static bool loadConfig()
        {
            string sFileName;
            FileStream fs = null;
            try
            {
                sFileName = Application.StartupPath + "\\" + SETTING_FILENAME;
                fs = new FileStream(sFileName, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                acAppConfig = (ApplicationConfig)bf.Deserialize(fs);
                fs.Close();
            }
            catch
            {
                fs.Close();
                return false;
            }
            return true;
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
        public static bool MyDbBackup(string sDisk){

            string sqlstr = string.Format("BACKUP DATABASE [{0}] TO DISK = '{1}' ", conDBConnection.Database.ToString(), sDisk);
            SqlCommand Backupcmd = conDBConnection.CreateCommand();
            Backupcmd.CommandText = sqlstr;
            Backupcmd.CommandType = CommandType.Text;
            if (conDBConnection.State == ConnectionState.Closed) conDBConnection.Open();
            int i = Backupcmd.ExecuteNonQuery();
            if (i != 0) return true;
            return false;
        }
        public static bool MyDbRestore(string location)
        {

            string sqlstr = string.Format("use Master RESTORE DATABASE {0} FROM DISK = '{1}' ", conDBConnection.Database.ToString(), location);
            SqlCommand Restorecmd = conDBConnection.CreateCommand();
          
         //   MessageBox.Show(sqlstr);
             Restorecmd.CommandType = CommandType.Text;
            Restorecmd.CommandText = sqlstr;
            //Restorecmd.CommandType = CommandType.StoredProcedure;
            //Restorecmd.CommandText = "proc_util_restore";
            //SqlParameter lc = new SqlParameter("@location", SqlDbType.VarChar ,255);
            //lc.Value = location;
            //Restorecmd.Parameters.Add(lc);
            //SqlParameter dataname = new SqlParameter("@database_name", SqlDbType.VarChar, 255);
            //dataname.Value = conDBConnection.Database.ToString();
            //Restorecmd.Parameters.Add(dataname);
           if (conDBConnection.State == ConnectionState.Closed) conDBConnection.Open();
            int i = Restorecmd.ExecuteNonQuery();
            conDBConnection.Close();
            if (i != 0) return true;
            return false;
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

            byte[] originalBytes = Encoding.UTF8.GetBytes(sOriginal);
            MD5 md5 = MD5.Create();
            byte[] encodedBytes = md5.ComputeHash(originalBytes);

            return BitConverter.ToString(encodedBytes).Replace("-","");
          // return HashPasswordForStoringInConfigFile(sOriginal, "MD5");
            
            //return System.Security.Cryptography.MD5.Create(sOriginal);

        }
        #endregion

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
    }
}
