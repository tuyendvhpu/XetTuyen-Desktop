using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using BusinessLogic;
using BusinessService;
using DataAccess;

namespace XetTuyen
{
    public partial class frmNganhXT : frmBase
    {
        #region "Declare Variables and Properties"
        //private bool bIsMultilangData = false;
        List<NganhXetTuyen> listNganhXT = new List<NganhXetTuyen>();
        List<NganhXetTuyen> listDeletedNganhXT = new List<NganhXetTuyen>();
        List<NganhXetTuyen> listNewNganhXT = new List<NganhXetTuyen>();
        
       
        private NhomNganhService nhomNganhnBS = new NhomNganhService();
        private NganhService nganhnBS = new NganhService();
        private NganhXetTuyenService nganhXTBS = new NganhXetTuyenService();
        private NhomNganhCollection currentNhomNganhCollection = new NhomNganhCollection();
        private NganhXetTuyenCollection currentNganhXetTuyenCollection = new NganhXetTuyenCollection();
        private int mainPanelWidth;

        TreeNode tnGroupSelectedNode = null;
        TreeNode tnFunctionGroupSelectedNode = null;

        private bool isProgrammingCheckedListView = true;
        private bool isProgrammingSelectedTreeNode = true;

        private HoSo mHoSo =null;
        private string _title = string.Empty;
        private string IDNganh;
        private string maNganh;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        #endregion

        #region "Form"
        public frmNganhXT()
        {
            InitializeComponent();

        }
        public void ShowDialog(HoSo mHoSo)
        {
            this.mHoSo = mHoSo;
            this.WindowState = FormWindowState.Maximized;
            this.ShowDialog();
           
        }  
        /// <summary>
        /// frmAuthorization_Load
        /// </summary>        
        private void frmNganhXT_Load(object sender, EventArgs e)
        {
           
            isProgrammingSelectedTreeNode = true;
            
            InitData();

            mainPanelWidth = splitContainer2.Panel1.Width;
            VisibleButtons(false);

            


            //Set Authorization
           // ucDataButton1.EditVisible = new AuthorizationsService().IsAuthorized(AuthorizationsService.Action.Update);
            ucDataButton1.EditVisible =  nganhXTBS.IsAuthorized(NganhXetTuyenService.NganhXetTuyenAction.Update);
        }

        //2008/10/20
        private const string sSpace = "      ";//6
        private bool bIsAutoCheck = false;
        private bool bIsClickCheckAll = false;
        private int nCheckedItemsCount = 0;
        
        private void frmAuthorization_SetHeaderTextHandler()
        {
            clmItemDescription.Text = sSpace + clmItemDescription.Text.Trim();
        }
        //END

        /// <summary>
        /// Init Data for controls on Form
        /// </summary>
        private void InitData()
        {
            DotXetTuyenService dotXTBS = new DotXetTuyenService();
            cmbDotXT.DataSource = dotXTBS.LoadAll();
            cmbDotXT.DisplayMember = "TenDot";
            cmbDotXT.ValueMember = "MaDot";
           string  dotxetuyen = dotXTBS.LoadByDate(DateTime.Now).Rows[0]["Madot"].ToString();
           cmbDotXT.SelectedValue = dotxetuyen;
            LoadNganXTCureent();
            DisplayGroups();
            DisplayFunctionGroups();

           
            
           
           // MessageBox.Show(currentNganhXetTuyenCollection.Count.ToString());
            txtGroupName.Text = mHoSo.MaHS;
            txtHoTen.Text = mHoSo.HoTen;
            txtSoCMTND.Text = mHoSo.SoCMTND;
            txtGroupName.Left = lblGroupName.Left + lblGroupName.Width;
            lblNumber.Left = lblAuthorizationCount.Left + lblAuthorizationCount.Width;
            txtGroupName.Width = pnlAuthorization.Width - (lblGroupName.Width + 15);
        }
        private void LoadNganXTCureent()
        {
            if (cmbDotXT.SelectedValue != null && mHoSo != null)
            {
                currentNganhXetTuyenCollection = nganhXTBS.GetNganhXetTuyenByID(mHoSo.Idhs, cmbDotXT.SelectedValue.ToString(), mHoSo.Nam);
                listNganhXT = nganhXTBS.GetNganhXetTuyenByID(mHoSo.Idhs, cmbDotXT.SelectedValue.ToString(), mHoSo.Nam);
                if (listNewNganhXT.Count < 0)
                {
                    btnDiem.Visible = false;
                }
                else {
                    btnDiem.Visible = true;
                }
            }
        }

        /// <summary>
        /// Find Selected Note before Change Language
        /// </summary>
        private TreeNode FindSelectedNote(bool bIsGroup)
        {
            if (bIsGroup)
            {
                Guid selectedGroupID = (Guid)tnGroupSelectedNode.Tag;
                foreach (TreeNode node in treGroup.Nodes)
                {
                    if ((Guid)node.Tag == selectedGroupID)
                        return node;
                }
            }

            return null;
        }

        /// <summary>
        /// frmAuthorization_Shown
        /// </summary>        
        private void frmNganhXT_Shown(object sender, EventArgs e)
        {
            isProgrammingSelectedTreeNode = false;
            if (treGroup.Nodes.Count > 0)
            {
                treGroup.SelectedNode = null;
                treGroup.SelectedNode = treGroup.Nodes[0];

                
             
            }
        }
        #endregion

        #region "ListView MethodDescription Functions"
        /// <summary>
        /// IsCheckedMethod
        /// </summary>
        /// <param name="roleID"></param>
        /// <param name="authID"></param>
        /// <returns></returns>
        private bool IsCheckedMethod(NganhXetTuyen nganhXT)
        {
            foreach (NganhXetTuyen nganhXetTuyen in currentNganhXetTuyenCollection)
            {
                if (nganhXetTuyen==nganhXT)
                    return true;
            }

            return false;
        }
        private bool IsEnabledMethod(NganhXetTuyen nganhXT)
        {
            foreach (NganhXetTuyen nganhXetTuyen in currentNganhXetTuyenCollection)
            {
                if (nganhXetTuyen == nganhXT && nganhXetTuyen.TrangThai!=0)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// DisplayMethodDesc
        /// </summary>
        private void DisplayMethodDescription()
        {
           
            if ( tnFunctionGroupSelectedNode == null) return;
            //MessageBox.Show(treFunctionGroup.SelectedNode.Parent.Tag.ToString());
            lstMethod.Items.Clear();

            isProgrammingCheckedListView = true;

            //2008/10/20
            nCheckedItemsCount = 0;
            //END

            //AuthorizationCollection authCollection = clsAuthorization.GetAuthorizationCollectionByTitle((ModuleType)tnFunctionGroupSelectedNode.Parent.Tag, tnFunctionGroupSelectedNode.Text);
            if (tnFunctionGroupSelectedNode.Parent!=null)
            maNganh = tnFunctionGroupSelectedNode.Parent.Tag.ToString();
           // NganhCollection nganhCollection = nganhnBS.GetListNganhLoadKhoiByNganh(maNganh, DateTime.Now.Year);
            IDNganh = tnFunctionGroupSelectedNode.Tag.ToString();
           NganhCollection nganhCollection = nganhnBS.GetListNganhLoadKhoiByIDNganh(IDNganh,DateTime.Now.Year);
           //MessageBox.Show(maNganh);
          
           foreach (Nganh nganh in nganhCollection)
            {
                ListViewItem item = new ListViewItem();
                item.Text = nganh.MaKhoi;
                item.Tag = nganh.MaKhoi;
                NganhXetTuyen nganhXT = GetNganh(nganh);
               
                item.Checked = IsCheckedMethod(nganhXT);
                if (item.Checked){
                    nCheckedItemsCount++;
                    //tnFunctionGroupSelectedNode.ForeColor = Color.AliceBlue;
                }
               string sKhoi = nganh.MaKhoi;
               if (sKhoi.Length > 3) {
                   int iStar = sKhoi.IndexOf("_") +1;
                   sKhoi = sKhoi.Substring(iStar, sKhoi.Length - iStar);
                  // sKhoi = sKhoi.IndexOf("_").ToString(); 
               }
               string sqlToHop = string.Format("Select * From TeamMonKhoi  Where MaKhoi = N'{0}'",sKhoi);
               DataTable dtToHop = nganhnBS.FinNganh(sqlToHop);
               if(dtToHop.Rows.Count>0)

                   item.ToolTipText = "Tổ hợp các môn: " + dtToHop.Rows[0]["Mon1"].ToString().Trim() + " - " + dtToHop.Rows[0]["Mon2"].ToString().Trim() + " - " + dtToHop.Rows[0]["Mon3"].ToString().Trim();
                lstMethod.Items.Add(item);
            }
            isProgrammingCheckedListView = false;
        }

        /// <summary>
        /// UpdateCurrentNganhXT
        /// </summary>        
        private void UpdateCurrentNganhXT(NganhXetTuyen nganhXT, bool isDeleted)
        {
            if (isDeleted)
            {
                for (int i=0;i<currentNganhXetTuyenCollection.Count;i++)  
                {
                    if (currentNganhXetTuyenCollection[i] == nganhXT)
                    {
                        currentNganhXetTuyenCollection.RemoveAt(i);
                        break;
                    }
                }
            }
            else
            {
               
                //Add new Nganh Xet Tuyen for displaying only
                currentNganhXetTuyenCollection.Add(nganhXT);
            }

            UpdateAuthorizationCount();
        }

        private NganhXetTuyen GetNganh(ListViewItem item) {
            NganhXetTuyen nganhXT = new NganhXetTuyen();
            nganhXT.Idhs = mHoSo.Idhs;
            nganhXT.Nam = mHoSo.Nam;
            nganhXT.IDNganh = IDNganh;
            nganhXT.MaKhoi = item.Tag.ToString();
            nganhXT.MaDot = cmbDotXT.SelectedValue.ToString();
            nganhXT.MaNganh = maNganh;
            nganhXT.NgayDK = Utilities.GetServerTime();
            KhuVucService khuVucBS = new KhuVucService();
            KhuVuc objKhuVuc = khuVucBS.GetKhuVucByID(mHoSo.MaKV);
            if (objKhuVuc != null)
                nganhXT.DiemUTKV = objKhuVuc.DienUT;

            DoiTuongUTService doiTuongUTBS = new DoiTuongUTService();
            DoiTuongUT objDoiTuongUT = doiTuongUTBS.GetDoiTuongByID(mHoSo.MaDT);
            if (objDoiTuongUT != null)
                nganhXT.DiemUTDT = objDoiTuongUT.DiemUT;
            return nganhXT;
        
        }
        private NganhXetTuyen GetNganh(string MaNganh,string iDNganh, string MaKhoi)
        {
            NganhXetTuyen nganhXT = new NganhXetTuyen();
            nganhXT.Idhs = mHoSo.Idhs;
            nganhXT.Nam = mHoSo.Nam;
            nganhXT.IDNganh = iDNganh;
            nganhXT.MaKhoi = MaKhoi;
            nganhXT.MaDot = cmbDotXT.SelectedValue.ToString();
            nganhXT.MaNganh = MaNganh;
            nganhXT.NgayDK = Utilities.GetServerTime();
            KhuVucService khuVucBS = new KhuVucService();
            KhuVuc objKhuVuc = khuVucBS.GetKhuVucByID(mHoSo.MaKV);
            if (objKhuVuc != null)
                nganhXT.DiemUTKV = objKhuVuc.DienUT;

            DoiTuongUTService doiTuongUTBS = new DoiTuongUTService();
            DoiTuongUT objDoiTuongUT = doiTuongUTBS.GetDoiTuongByID(mHoSo.MaDT);
            if (objDoiTuongUT != null)
                nganhXT.DiemUTDT = objDoiTuongUT.DiemUT;
            return nganhXT;

        }
        private NganhXetTuyen GetNganh(Nganh nganh)
        {
            NganhXetTuyen nganhXT = new NganhXetTuyen();
            nganhXT.Idhs = mHoSo.Idhs;
            nganhXT.Nam = mHoSo.Nam;
            nganhXT.IDNganh = nganh.IDNganh;
            nganhXT.MaKhoi = nganh.MaKhoi;
            nganhXT.MaDot = cmbDotXT.SelectedValue.ToString();
            nganhXT.MaNganh = nganh.MaNganh;
            nganhXT.NgayDK = Utilities.GetServerTime();
            KhuVucService khuVucBS = new KhuVucService();
            KhuVuc objKhuVuc = khuVucBS.GetKhuVucByID(mHoSo.MaKV);
            if (objKhuVuc != null)
                nganhXT.DiemUTKV = objKhuVuc.DienUT;

            DoiTuongUTService doiTuongUTBS = new DoiTuongUTService();
            DoiTuongUT objDoiTuongUT = doiTuongUTBS.GetDoiTuongByID(mHoSo.MaDT);
            if (objDoiTuongUT != null)
                nganhXT.DiemUTDT = objDoiTuongUT.DiemUT;
            return nganhXT;

        }
        /// <summary>
        /// lstMethod_ItemChecked
        /// </summary>        
        private void lstMethod_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (isProgrammingCheckedListView) return;

            //MessageBox.Show(e.Item.Tag.ToString());
            NganhXetTuyen nganhXT = GetNganh(e.Item);
           // MessageBox.Show(nganhXT.MaNganh +"-"+ nganhXT.IDNganh);
            if (e.Item.Checked)
            {

               // MessageBox.Show(nganhXT.MaNganh + " - IDNganh: " + nganhXT.IDNganh + " - Khoi: " + nganhXT.MaKhoi + " - Dot: " + nganhXT.MaDot + "- IDHS: " + nganhXT.Idhs);
                if (IsNewItem(nganhXT) && IsNewItemContain(nganhXT) == false)
                {
                   // MessageBox.Show("Mới");
                    listNewNganhXT.Add(nganhXT);
                }

                else
                    listDeletedNganhXT.Remove(nganhXT);

                //Add new AuthorizarionRole into Current Collection
                UpdateCurrentNganhXT(nganhXT, false);

                //2008/10/20
                if (bIsClickCheckAll == false)
                    nCheckedItemsCount++;
                //END
            }
            else
            {
                //MessageBox.Show("a Thêm xóa");
                //MessageBox.Show(IsDeletedItem(nganhXT).ToString());
                //MessageBox.Show(IsDeletedItemContain(nganhXT).ToString());
                if (IsDeletedItem(nganhXT) && IsDeletedItemContain(nganhXT) == false && IsXetTuyenItem(nganhXT) == false)
                {
                    listDeletedNganhXT.Add(nganhXT);
                   // MessageBox.Show("Thêm xóa");
                    UpdateCurrentNganhXT(nganhXT, true);
                }
                else
                {
                    if (IsXetTuyenItem(nganhXT) == false)
                    {
                        // listNewNganhXT.Remove(nganhXT);
                        RemoveNewItem(nganhXT);
                        UpdateCurrentNganhXT(nganhXT, true);
                        //MessageBox.Show("xóa");
                    }
                }

                //Remove delete AuthorizationRole for displaying only
                

                //2008/10/20
                if (bIsClickCheckAll == false)
                    nCheckedItemsCount--;
                //END
            }

            if (bIsClickCheckAll == false)
            {
                bIsAutoCheck = true;
                if (nCheckedItemsCount < lstMethod.Items.Count)
                    chkAll.Checked = false;
                else
                    chkAll.Checked = true;
                bIsAutoCheck = false;
            }
        }

        #endregion

        #region "TreeView Groups"
        /// <summary>
        /// DisplayGroups
        /// </summary>
        private void DisplayGroups()
        {
            treGroup.Nodes.Clear();
            //GroupCollection groupCollection = new GroupsService().GetListGroup();
            //foreach (Groups objGroup in groupCollection)
            //{
                TreeNode tnGroup = new TreeNode("Đại học");
                tnGroup.ImageIndex = 0;
                tnGroup.Tag = "ĐH";
                treGroup.Nodes.Add(tnGroup);

                 tnGroup = new TreeNode("Cao đẳng");
                tnGroup.ImageIndex = 0;
                tnGroup.Tag = "C";
                treGroup.Nodes.Add(tnGroup);
            //}
        }

        /// <summary>
        /// treAuth_AfterSelect
        /// </summary>        
        private string loaiNganh;
        private void treGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isProgrammingSelectedTreeNode) return;

            if (treGroup.SelectedNode != null)
            {
                loaiNganh = treGroup.SelectedNode.Tag.ToString();

                //tnGroupSelectedNode = treGroup.SelectedNode;
                //txtGroupName.Text = tnGroupSelectedNode.Text;

               currentNhomNganhCollection = NhomNganhService.GetNhomNganhCollectionByLoaiNganh(loaiNganh);
                //MessageBox.Show(loaiNganh);

                //currentNhomNganhCollection = NhomNganhService.NhomNganhCollection;

                ////Menu Section                
              
                //End
            }
            else
                currentNhomNganhCollection = NhomNganhService.NhomNganhCollection;

            UpdateAuthorizationCount();
            DisplayFunctionGroups();
            //Clear ListViewItem
            treFunctionGroup.SelectedNode = null;
            lstMethod.Items.Clear();
        }

        #endregion

        #region "TreeView Function Groups"
        private void DisplayFunctionGroups()
        {
            treFunctionGroup.Nodes.Clear();
          
            NhomNganhCollection nhomNgahCollection = currentNhomNganhCollection;
            if (nhomNgahCollection.Count > 0)
            {
                foreach (NhomNganh nhomNganh in nhomNgahCollection)
                    AddNhomNganhNode(nhomNganh.MaNganh, nhomNganh);
            }
            else
            {
                //foreach (ModuleType moduleType in Enum.GetValues(typeof(ModuleType)))
                //    AddModuleTypeNode(moduleType, null);
            }

            treFunctionGroup.ExpandAll();
        }

        /// <summary>
        /// AddModuleTypeNode
        /// </summary>
        /// <param name="moduleType"></param>
        private void AddNhomNganhNode(string maNganh, NhomNganh nhomNganh)
        {
            if (nhomNganh == null)
            {
               
            }

            
            TreeNode tnModule = new TreeNode(nhomNganh.TenNganh);
            tnModule.ImageIndex = 0;
            tnModule.Tag = maNganh;

            treFunctionGroup.Nodes.Add(tnModule);

            //Add functions belong to this node
            AddNganhInNhomNganh(tnModule);
        }

        /// <summary>
        /// AddAuthorizationInModuleType
        /// </summary>
        /// <param name="tnModule"></param>
        /// <param name="moduleType"></param>
        private void AddNganhInNhomNganh(TreeNode tnModule)
        {
            TreeNode tnAuth = null;
            List<string> lstTitle = new List<string>();

            NganhCollection nganhCollection = new NganhCollection();
            nganhCollection = nganhnBS.GetListNganhGroupByIDNganh(DateTime.Today.Year);

            foreach (Nganh nganh in nganhCollection)
            {
                if (tnModule.Tag.ToString().Equals(nganh.MaNganh) )
                {
                    lstTitle.Add(nganh.TenNganh);
                    tnAuth = new TreeNode(nganh.TenNganh);
                    tnAuth.Tag = nganh.IDNganh;
                    tnAuth.ImageIndex = 1;
                    tnAuth.SelectedImageIndex = 2;
                   
                  //Đổi màu nếu ngày đã được chọn
                    foreach (NganhXetTuyen nganhXT in currentNganhXetTuyenCollection) {
                        if (nganhXT.IDNganh.Equals(nganh.IDNganh) && nganhXT.MaDot.Equals(cmbDotXT.SelectedValue.ToString()))
                        {
                            tnAuth.ForeColor = Color.Red; 
                            tnAuth.ToolTipText = "Ngành đã đăng ký xét tuyển!";
                           // return;
                        }
                    }
                    tnModule.Nodes.Add(tnAuth);
                }
            }
        }

        /// <summary>
        /// treFunctionGroup_AfterSelect
        /// </summary>        
        private void treFunctionGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            if (treFunctionGroup.SelectedNode != null)
            {

                tnFunctionGroupSelectedNode = treFunctionGroup.SelectedNode;
               
                DisplayMethodDescription();

                //2008/10/20                         
                bIsAutoCheck = true;

                bool bIsCheckAll = true;
                for (int i = 0; i < lstMethod.Items.Count; i++)
                {
                    if (lstMethod.Items[i].Checked == false)
                    {
                        bIsCheckAll = false;
                        break;
                    }
                }

                chkAll.Checked = bIsCheckAll;

                bIsAutoCheck = false;
                //END
            }
            else
            {
                lstMethod.Items.Clear();
            }
        }

        /// <summary>
        /// treFunctionGroup_NodeMouseDoubleClick
        /// </summary>        
        private void treFunctionGroup_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
          
            //if (bIsMultilangData && e.Node.Parent != null)
            //{
                /*
                frmAuthorizationLanguage frm = new frmAuthorizationLanguage();

                frm.m_Module = (Module)e.Node.Parent.Tag;
                frm.AuthorizationID = (Guid)e.Node.Tag;
                frm.Title = e.Node.Text.Trim();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    e.Node.Text = frm.Title;
                    e.Node.Parent.Text = frm.m_Module.ModuleName;

                    //Refresh Collection
                    tnFunctionGroupSelectedNode.Text = frm.Title;
                    clsAuthorization.AuthorizationCollection = null;
                    treFunctionGroup_AfterSelect(sender, null);
                }
                */
            //}
        }

        #endregion

        #region "Common Functions"
        /// <summary>
        /// SetAuthorization
        /// </summary>
        private void SetAuthorization()
        {
            ucDataButton1.EditVisible = nganhXTBS.IsAuthorized(NganhXetTuyenService.NganhXetTuyenAction.Update);
            
            //ucDataButton1.MultiLanguageVisible = authorizationBS.IsAuthorized(clsAuthorizationBS.Action.MultilangUI);
            //bIsMultilangData = authorizationBS.IsAuthorized(clsAuthorizationBS.Action.MultilangData);
        }

        /// <summary>
        /// VisibleGenerateButton
        /// </summary>        

        /// <summary>
        /// VisibleButtons
        /// </summary>
        /// <param name="isVisibled"></param>
        private void VisibleButtons(bool bIsVisibled)
        {
            //btnGenerate.Visible = bIsVisibled;

            lstMethod.Enabled = bIsVisibled;
            chkAll.Enabled = bIsVisibled;
            cmbDotXT.Enabled = !bIsVisibled;

            //SplitContainer1.Panel1
            //tsMain.Visible = !(isVisibled);
            //treGroup.Visible = tsMain.Visible;
            treGroup.Visible = !bIsVisibled;


            if (bIsVisibled)
            {
                splitContainer2.SplitterDistance = 0;
                splitContainer2.IsSplitterFixed = true;
            }
            else
            {
                splitContainer2.SplitterDistance = mainPanelWidth;
                splitContainer2.IsSplitterFixed = false;
            }

            clmItemDescription.Width = lstMethod.Width - 10;

              
        }

        /// <summary>
        /// IsNewItem
        /// </summary>
        /// <param name="nganhXT"></param>
        /// <returns></returns>
        private bool IsNewItem(NganhXetTuyen nganhXT)
        {
            //NganhXetTuyen nganhXT = GetNganh(item);

            foreach (NganhXetTuyen nganhXTL in listDeletedNganhXT)
            {
                if (nganhXTL == nganhXT)
                    return false;
            }
            
           return true;
        }
        /// <summary>
        /// RemoveNewItem
        /// </summary>
        /// <param name="nganhXT"></param>
        
        private void  RemoveNewItem(NganhXetTuyen nganhXT)
        {
            //NganhXetTuyen nganhXT = GetNganh(item);

            for (int i=0;i<listNewNganhXT.Count;i++)
            {
                if (listNewNganhXT[i] == nganhXT){
                    listNewNganhXT.RemoveAt(i);
                }
                    
            }

           
        }
        /// <summary>
        /// IsNewItemContain
        /// </summary>
        /// <param name="nganhXT"></param>
        /// <returns></returns>
        private bool IsNewItemContain(NganhXetTuyen nganhXT)
        {
            //NganhXetTuyen nganhXT = GetNganh(item);

            foreach (NganhXetTuyen nganhXTL in listNewNganhXT)
            {
                if (nganhXTL == nganhXT)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// IsDeletedItem
        /// </summary>
        /// <param name="nganhXT"></param>
        /// <returns></returns>
        private bool IsDeletedItem(NganhXetTuyen nganhXT)
        {
          //  NganhXetTuyen nganhXT = GetNganh(item);
            //MessageBox.Show(listNganhXT.Count.ToString());
            foreach (NganhXetTuyen nganhXTL in listNganhXT)
            {

                if (nganhXTL==nganhXT )
                    return true;
            }
            return false;
        }
        /// <summary>
        /// IsXetTuyenItem
        /// </summary>
        /// <param name="nganhXT"></param>
        /// <returns></returns>
        private bool IsXetTuyenItem(NganhXetTuyen nganhXT)
        {
          //  NganhXetTuyen nganhXT = GetNganh(item);
            //MessageBox.Show(listNganhXT.Count.ToString());
            foreach (NganhXetTuyen nganhXTL in listNganhXT)
            {

                    if (nganhXTL == nganhXT && nganhXTL.TrangThai != 0 && clsCommon.IsAdminUser==false) {
                      
                            MessageBox.Show("Ngành đã được xét tuyển. Bạn không thể bỏ được");
                            return true;

                    }
                       
                
                
            }
            return false;
        }
        /// <summary>
        /// IsDeletedItemContain
        /// </summary>
        /// <param name="nganhXT"></param>
        /// <returns></returns>
        private bool IsDeletedItemContain(NganhXetTuyen nganhXT)
        {
            //  NganhXetTuyen nganhXT = GetNganh(item);
            //MessageBox.Show(listNganhXT.Count.ToString());
            foreach (NganhXetTuyen nganhXTL in listDeletedNganhXT)
            {
                if (nganhXTL == nganhXT)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// ClearLists
        /// </summary>
        private void ClearLists()
        {
            listNewNganhXT.Clear();
            listNganhXT.Clear();
            listDeletedNganhXT.Clear();
        }

        /// <summary>
        /// UpdateAuthorizationCount
        /// </summary>
        private void UpdateAuthorizationCount()
        {
           lblNumber.Text = "[" + currentNganhXetTuyenCollection.Count + "]";
        }

        /// <summary>
        /// Check data has been changed ?
        /// </summary>
        /// <returns></returns>
        private bool IsDataChanged()
        {
            //MessageBox.Show(listNewNganhXT.Count.ToString());
            if (listDeletedNganhXT.Count > 0 || listNewNganhXT.Count > 0)
                               return true;
            MessageBox.Show("Không có thay đổi gì!");
            VisibleButtons(false);
            ucDataButton1.DataMode = DataState.View;
            return false;
        }

        /// <summary>
        /// Update data in DB
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {


            bool bResult = false,
            bResultdell = false;
            //1. GroupAuthorization
            //Deleted Objects
            for (int intIndex = 0; intIndex < listDeletedNganhXT.Count; intIndex++)
            {
                //MessageBox.Show()
               bResultdell = nganhXTBS.Delete(listDeletedNganhXT[intIndex].Idhs, listDeletedNganhXT[intIndex].MaNganh, listDeletedNganhXT[intIndex].MaKhoi, listDeletedNganhXT[intIndex].MaDot, listDeletedNganhXT[intIndex].Nam, listDeletedNganhXT[intIndex].IDNganh);
            }
            if (listDeletedNganhXT.Count == 0) bResultdell = true;
            //Added Objects
           //MessageBox.Show(listNewNganhXT.Count.ToString());
            for (int intIndex = 0; intIndex < listNewNganhXT.Count; intIndex++)
            {
               bResult=  nganhXTBS.Insert(listNewNganhXT[intIndex]);
              
            }
            if (listNewNganhXT.Count == 0) bResult = true;

           
            //UPDATE DATA IN DB
          // bool bResult = groupAuthorizationBS.UpdateData(lstAddedGroupAuthorization, lstDeletedGroupAuthorization, lstAddedMenuGroup, lstDeletedMenuGroup);
           // bool bResult = false;                                  
            if (bResult && bResultdell)
            {
                clsCommon.SaveSuccessfully();

             //   InitData();
                ClearLists();
               LoadNganXTCureent();
               
                //Them điêm xt
               foreach (NganhXetTuyen objNganhXT in listNganhXT)
               {
                   string sqlDiemXT = string.Format("Select * From t_DiemXetTuyen Where idHS ={0} AND MaKhoi =N'{1}'", objNganhXT.Idhs, objNganhXT.MaKhoi);
                   DataTable dtDiem = nganhXTBS.FinNganhXetTuyen(sqlDiemXT);
                   //MessageBox.Show(dtDiem.Rows.Count.ToString());
                   if (dtDiem.Rows.Count == 0)
                   {
                       KhoiMonService khoiMonBS = new KhoiMonService();
                       DiemXetTuyenService diemXTBS = new DiemXetTuyenService();
                       DataTable dtMon = khoiMonBS.LoadTenMonByPrimaryKey(mHoSo.Nam, objNganhXT.MaKhoi);
                       for (int indexM = 0; indexM < dtMon.Rows.Count; indexM++)
                       {
                           DiemXetTuyen objDiemXT = new DiemXetTuyen();
                           objDiemXT.Idhs = mHoSo.Idhs;
                           objDiemXT.MaKhoi = dtMon.Rows[indexM]["MaKhoi"].ToString().Trim();
                           objDiemXT.MaMon = Convert.ToInt32(dtMon.Rows[indexM]["MaMon"].ToString().Trim());
                           objDiemXT.Diem = 0;
                           diemXTBS.Insert(objDiemXT);


                       }
                   }
               }

                //DisplayGroups();
               DisplayFunctionGroups();
                UpdateAuthorizationCount();

                //Controls on Forms
                VisibleButtons(false);
                ucDataButton1.DataMode = DataState.View;
               
            }
            else
                clsCommon.SaveNotSuccessfully();

            return bResult;
        }

        #endregion

        #region "UCDataButton & Button Generate"
        /// <summary>
        /// btnGenerate_Click
        /// </summary>        
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            //bool bResult = true;
            //try
            //{
            //    //1. Update Module                 
            //    ModulesCollection moduleCollection = new ModulesCollection();
              
            //    foreach (ModuleType moduleType in Enum.GetValues(typeof(ModuleType)))
            //    {
            //        Modules objModule = new Modules();
            //        objModule.ModuleID = (int)moduleType;                    
            //        objModule.ModuleName = GetModuleTypeName.GetString(moduleType);

            //        moduleCollection.Add(objModule);
                   
            //    }
            //    //End

            //    //2. Update Authorization
            //    //bResult = clsSecurityManager.CheckAllAssemblies();
            //    bResult = SecurityManager.CheckAllAssemblies(moduleCollection);

            //    //Refresh Authorization Collection by setting is null
            //    AuthorizationsService.AuthorizationCollection = null;

            //    //Refresh Functions List
            //    treFunctionGroup.Nodes.Clear();
            //    DisplayFunctionGroups();
            //    DisplayMethodDescription();
            //}
            //catch
            //{
            //    bResult = false;
            //}

            //Cursor = Cursors.Default;
            //if (bResult)                
            //    clsCommon.SaveSuccessfully();
            //else
            //    //MessageBoxExLib.MessageBoxEx.Show(ResourceManager.GetString("Common", "UpdateFailed"), MessageBoxButtons.OK, MessageBoxExLib.MessageBoxExIcon.Error);
            //    clsCommon.SaveNotSuccessfully();
        }

        


        /// <summary>
        /// ucDataButton1_EditHandler
        /// </summary>
        private void ucDataButton1_EditHandler()
        {
            if (tnFunctionGroupSelectedNode == null) return;

            //clear listview
            //Clearlists();

            VisibleButtons(true);

            //store currentauthrolecollection in list to check the changes during modifying mode
           // foreach (groupauthorization authrole in currentgroupauthorizationcollection)
                //listauthid.add(authrole.authorizationid);

            //get groupid
         //   groupid = (guid)tregroup.selectednode.tag;

            //if application in debug mode => show generate button
            //btngenerate.visible = clscommon.isadminuser && securitymanager.isdebugmode;

            ////test
            btnDiem.Visible = false;
        }

        /// <summary>
        /// ucDataButton1_SaveHandler
        /// </summary>
        private void ucDataButton1_SaveHandler()
        {
            if (IsDataChanged())
                SaveData();
            else
                ucDataButton1.DataMode = DataState.View;

            //2008/10/20
            
            //End
        }

        /// <summary>
        /// ucDataButton1_CancelHandler
        /// </summary>
        private void ucDataButton1_CancelHandler()
        {
            VisibleButtons(false);

            //2008/10/20
            if(listNganhXT.Count>0)
            btnDiem.Visible = true ;
            //End

            ucDataButton1.DataMode = DataState.View;

            //Refresh Current AuthorizationCollection
            //currentGroupAuthorizationCollection = new GroupAuthorizationService().GetGroupAuthorizationCollectionByGroupID((Guid)tnGroupSelectedNode.Tag);
            UpdateAuthorizationCount();

            //Set CurrentRolID in case of New Mode
           // groupID = (Guid)tnGroupSelectedNode.Tag;

            //Restore ListView's state
            isProgrammingCheckedListView = true;
            //for (int intIndex = 0; intIndex < lstMethod.Items.Count; intIndex++)
            //    lstMethod.Items[intIndex].Checked = IsCheckedMethod(groupID, (Guid)lstMethod.Items[intIndex].Tag);
            isProgrammingCheckedListView = false;

         
        }

        /// <summary>
        /// ucDataButton1_CloseHandler
        /// </summary>
        private void ucDataButton1_CloseHandler()
        {            
            this.Close();
        }

        /// <summary>
        /// btnMultiLanguage_Click
        /// </summary>        
        private void btnMultiLanguage_Click(object sender, EventArgs e)
        {            
        }
        #endregion

        /// <summary>
        /// chkAll_CheckedChanged
        /// </summary>        
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (bIsAutoCheck) return;

            bIsClickCheckAll = true;
            if (chkAll.Checked)
                nCheckedItemsCount = lstMethod.Items.Count;
            else
                nCheckedItemsCount = 0;

            for (int i = 0; i < lstMethod.Items.Count; i++)
            {
                lstMethod.Items[i].Checked = chkAll.Checked;
            }

            bIsClickCheckAll = false;
        }

        private void cmbDotXT_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbDotXT.SelectedValue == null)
                return;
            LoadNganXTCureent();
            ///DisplayGroups();
            lblNumber.Text = currentNganhXetTuyenCollection.Count.ToString();
            DisplayFunctionGroups();
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            frmDiemXetTuyen frmdiemXT = new frmDiemXetTuyen();
            frmdiemXT.ShowDialog(mHoSo.Idhs);
        }
    }
}

