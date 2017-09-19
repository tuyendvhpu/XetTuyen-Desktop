<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        Application["Visited"] = 0;
        Application["Online"] = 0;
        Application["nam"] =2015;
        Application["HeSo"] = 1;
        
        //Kiểm tra file count_visit.txt nếu không tồn tại thì
        if (System.IO.File.Exists(Server.MapPath("Nam.data")) == false)
        {
            Application["nam"] = 2015;
        }
        // Ngược lại thì
        else
        {
            // Đọc dử liều từ file count_visit.txt
            System.IO.StreamReader read = new System.IO.StreamReader(Server.MapPath("Nam.data"));
            Application["nam"]  = int.Parse(read.ReadLine());
            read.Close();

            // Đọc dử liều từ file count_visit.txt
             read = new System.IO.StreamReader(Server.MapPath("HeSo.data"));
            Application["HeSo"] = int.Parse(read.ReadLine());
            read.Close();
            
            // Tăng biến count_visit thêm 1
            
        }
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //  Session["num1"] = "";
        // Code that runs when a new session is started
        /*
        int count_visit = 0;

            //Kiểm tra file count_visit.txt nếu không tồn tại thì
            if(System.IO.File.Exists(Server.MapPath("count_visit.txt"))==false)
            {
            count_visit = 1;
            }
            // Ngược lại thì
            else{
            // Đọc dử liều từ file count_visit.txt
            System.IO.StreamReader read = new System.IO.StreamReader(Server.MapPath("count_visit.txt"));
            count_visit = int.Parse(read.ReadLine());
            read.Close();

            // Tăng biến count_visit thêm 1
            count_visit ++;
            }

            // khóa website
            Application.Lock();

            // gán biến Application count_visit
            Application["Visited"] = count_visit;
            Session["IDLang"] = "vi";
            // Mở khóa website
            Application.UnLock();

            // Lưu dử liệu vào file count_visit.txt
            System.IO.StreamWriter writer = new System.IO.StreamWriter(Server.MapPath("count_visit.txt"));
            writer.WriteLine(count_visit);
            writer.Close();
            */

            Application.Lock();
            Application["Online"] = Convert.ToInt32(Application["Online"]) + 1;
        /*
            Session["User"] = null;
            Session["UserID"] = null;
            Session["cart"] = null;
            Session["Addmin"] = null;
            Session["AddStatus"] = null;
            Session["Lang"] = null;
         */
            Session["HinhThuc"] = null;
            Session["step1"] = null;
            Session["step2"] = null;
            Session["num1"] = "";
            Session["soCMTND"] = null;
            Session["soBaoDanh"] = null;
            Session["HinhThuc"] = null;
            Session["objHoSo"] = null;
            Session["CapNhat"] = null;
            Session["User"] = null;
            Session["AddStatus"] = null;
            Session["snganh"] = null;
            Application.UnLock();
            

       

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application.Lock();
        Application["Online"] = Convert.ToInt32(Application["Online"]) - 1;
        Session["HinhThuc"] = null;
        Application.UnLock();
    }
       
</script>

