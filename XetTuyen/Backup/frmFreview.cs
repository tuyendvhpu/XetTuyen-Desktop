using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XetTuyen
{
    public partial class frmPreview : Form
    {
        public frmPreview()
        {
            InitializeComponent();
            _selt = this;
        }
        public void setReportSource(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt)
        {
          
            crpvPreview.ReportSource = rpt;
            
            
        }
    }
}
