
namespace SalaryTrackingSolution.Module.UI.UserControl
{
    partial class ucSummary
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.summaryModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.detail = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colDetail = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEJan = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffJan = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEFeb = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffFeb = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEMar = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffMar = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEApr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffApr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEMay = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffMay = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEJun = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffJun = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEJul = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffJul = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEAug = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffAug = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEESep = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffSep = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEENov = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffNov = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEOct = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffOct = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNoOfEEDec = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSalaryDiffDec = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colOid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.summaryModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1267, 648);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // summaryModelBindingSource
            // 
            this.summaryModelBindingSource.DataSource = typeof(SalaryTrackingSolution.Module.UI.Model.SummaryModel);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.detail,
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9,
            this.gridBand10,
            this.gridBand11,
            this.gridBand12});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colDetail,
            this.colNoOfEEJan,
            this.colSalaryDiffJan,
            this.colNoOfEEFeb,
            this.colSalaryDiffFeb,
            this.colNoOfEEMar,
            this.colSalaryDiffMar,
            this.colNoOfEEApr,
            this.colSalaryDiffApr,
            this.colNoOfEEMay,
            this.colSalaryDiffMay,
            this.colNoOfEEJun,
            this.colSalaryDiffJun,
            this.colNoOfEEJul,
            this.colSalaryDiffJul,
            this.colNoOfEEAug,
            this.colSalaryDiffAug,
            this.colNoOfEESep,
            this.colSalaryDiffSep,
            this.colNoOfEEOct,
            this.colSalaryDiffOct,
            this.colNoOfEENov,
            this.colSalaryDiffNov,
            this.colNoOfEEDec,
            this.colSalaryDiffDec,
            this.colOid});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            // 
            // detail
            // 
            this.detail.Caption = "detail";
            this.detail.Columns.Add(this.colDetail);
            this.detail.Name = "detail";
            this.detail.VisibleIndex = 0;
            this.detail.Width = 94;
            // 
            // colDetail
            // 
            this.colDetail.FieldName = "Detail";
            this.colDetail.MinWidth = 25;
            this.colDetail.Name = "colDetail";
            this.colDetail.Visible = true;
            this.colDetail.Width = 94;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Columns.Add(this.colNoOfEEJan);
            this.gridBand1.Columns.Add(this.colSalaryDiffJan);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 1;
            this.gridBand1.Width = 188;
            // 
            // colNoOfEEJan
            // 
            this.colNoOfEEJan.FieldName = "NoOfEEJan";
            this.colNoOfEEJan.MinWidth = 25;
            this.colNoOfEEJan.Name = "colNoOfEEJan";
            this.colNoOfEEJan.Visible = true;
            this.colNoOfEEJan.Width = 94;
            // 
            // colSalaryDiffJan
            // 
            this.colSalaryDiffJan.FieldName = "SalaryDiffJan";
            this.colSalaryDiffJan.MinWidth = 25;
            this.colSalaryDiffJan.Name = "colSalaryDiffJan";
            this.colSalaryDiffJan.Visible = true;
            this.colSalaryDiffJan.Width = 94;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "gridBand2";
            this.gridBand2.Columns.Add(this.colNoOfEEFeb);
            this.gridBand2.Columns.Add(this.colSalaryDiffFeb);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 188;
            // 
            // colNoOfEEFeb
            // 
            this.colNoOfEEFeb.FieldName = "NoOfEEFeb";
            this.colNoOfEEFeb.MinWidth = 25;
            this.colNoOfEEFeb.Name = "colNoOfEEFeb";
            this.colNoOfEEFeb.Visible = true;
            this.colNoOfEEFeb.Width = 94;
            // 
            // colSalaryDiffFeb
            // 
            this.colSalaryDiffFeb.FieldName = "SalaryDiffFeb";
            this.colSalaryDiffFeb.MinWidth = 25;
            this.colSalaryDiffFeb.Name = "colSalaryDiffFeb";
            this.colSalaryDiffFeb.Visible = true;
            this.colSalaryDiffFeb.Width = 94;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "gridBand3";
            this.gridBand3.Columns.Add(this.colNoOfEEMar);
            this.gridBand3.Columns.Add(this.colSalaryDiffMar);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 3;
            this.gridBand3.Width = 188;
            // 
            // colNoOfEEMar
            // 
            this.colNoOfEEMar.FieldName = "NoOfEEMar";
            this.colNoOfEEMar.MinWidth = 25;
            this.colNoOfEEMar.Name = "colNoOfEEMar";
            this.colNoOfEEMar.Visible = true;
            this.colNoOfEEMar.Width = 94;
            // 
            // colSalaryDiffMar
            // 
            this.colSalaryDiffMar.FieldName = "SalaryDiffMar";
            this.colSalaryDiffMar.MinWidth = 25;
            this.colSalaryDiffMar.Name = "colSalaryDiffMar";
            this.colSalaryDiffMar.Visible = true;
            this.colSalaryDiffMar.Width = 94;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "gridBand4";
            this.gridBand4.Columns.Add(this.colNoOfEEApr);
            this.gridBand4.Columns.Add(this.colSalaryDiffApr);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 4;
            this.gridBand4.Width = 188;
            // 
            // colNoOfEEApr
            // 
            this.colNoOfEEApr.FieldName = "NoOfEEApr";
            this.colNoOfEEApr.MinWidth = 25;
            this.colNoOfEEApr.Name = "colNoOfEEApr";
            this.colNoOfEEApr.Visible = true;
            this.colNoOfEEApr.Width = 94;
            // 
            // colSalaryDiffApr
            // 
            this.colSalaryDiffApr.FieldName = "SalaryDiffApr";
            this.colSalaryDiffApr.MinWidth = 25;
            this.colSalaryDiffApr.Name = "colSalaryDiffApr";
            this.colSalaryDiffApr.Visible = true;
            this.colSalaryDiffApr.Width = 94;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "gridBand5";
            this.gridBand5.Columns.Add(this.colNoOfEEMay);
            this.gridBand5.Columns.Add(this.colSalaryDiffMay);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 5;
            this.gridBand5.Width = 188;
            // 
            // colNoOfEEMay
            // 
            this.colNoOfEEMay.FieldName = "NoOfEEMay";
            this.colNoOfEEMay.MinWidth = 25;
            this.colNoOfEEMay.Name = "colNoOfEEMay";
            this.colNoOfEEMay.Visible = true;
            this.colNoOfEEMay.Width = 94;
            // 
            // colSalaryDiffMay
            // 
            this.colSalaryDiffMay.FieldName = "SalaryDiffMay";
            this.colSalaryDiffMay.MinWidth = 25;
            this.colSalaryDiffMay.Name = "colSalaryDiffMay";
            this.colSalaryDiffMay.Visible = true;
            this.colSalaryDiffMay.Width = 94;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "gridBand6";
            this.gridBand6.Columns.Add(this.colNoOfEEJun);
            this.gridBand6.Columns.Add(this.colSalaryDiffJun);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 6;
            this.gridBand6.Width = 188;
            // 
            // colNoOfEEJun
            // 
            this.colNoOfEEJun.FieldName = "NoOfEEJun";
            this.colNoOfEEJun.MinWidth = 25;
            this.colNoOfEEJun.Name = "colNoOfEEJun";
            this.colNoOfEEJun.Visible = true;
            this.colNoOfEEJun.Width = 94;
            // 
            // colSalaryDiffJun
            // 
            this.colSalaryDiffJun.FieldName = "SalaryDiffJun";
            this.colSalaryDiffJun.MinWidth = 25;
            this.colSalaryDiffJun.Name = "colSalaryDiffJun";
            this.colSalaryDiffJun.Visible = true;
            this.colSalaryDiffJun.Width = 94;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "gridBand7";
            this.gridBand7.Columns.Add(this.colNoOfEEJul);
            this.gridBand7.Columns.Add(this.colSalaryDiffJul);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 7;
            this.gridBand7.Width = 188;
            // 
            // colNoOfEEJul
            // 
            this.colNoOfEEJul.FieldName = "NoOfEEJul";
            this.colNoOfEEJul.MinWidth = 25;
            this.colNoOfEEJul.Name = "colNoOfEEJul";
            this.colNoOfEEJul.Visible = true;
            this.colNoOfEEJul.Width = 94;
            // 
            // colSalaryDiffJul
            // 
            this.colSalaryDiffJul.FieldName = "SalaryDiffJul";
            this.colSalaryDiffJul.MinWidth = 25;
            this.colSalaryDiffJul.Name = "colSalaryDiffJul";
            this.colSalaryDiffJul.Visible = true;
            this.colSalaryDiffJul.Width = 94;
            // 
            // gridBand8
            // 
            this.gridBand8.Caption = "gridBand8";
            this.gridBand8.Columns.Add(this.colNoOfEEAug);
            this.gridBand8.Columns.Add(this.colSalaryDiffAug);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.VisibleIndex = 8;
            this.gridBand8.Width = 188;
            // 
            // colNoOfEEAug
            // 
            this.colNoOfEEAug.FieldName = "NoOfEEAug";
            this.colNoOfEEAug.MinWidth = 25;
            this.colNoOfEEAug.Name = "colNoOfEEAug";
            this.colNoOfEEAug.Visible = true;
            this.colNoOfEEAug.Width = 94;
            // 
            // colSalaryDiffAug
            // 
            this.colSalaryDiffAug.FieldName = "SalaryDiffAug";
            this.colSalaryDiffAug.MinWidth = 25;
            this.colSalaryDiffAug.Name = "colSalaryDiffAug";
            this.colSalaryDiffAug.Visible = true;
            this.colSalaryDiffAug.Width = 94;
            // 
            // gridBand9
            // 
            this.gridBand9.Caption = "gridBand9";
            this.gridBand9.Columns.Add(this.colNoOfEESep);
            this.gridBand9.Columns.Add(this.colSalaryDiffSep);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.VisibleIndex = 9;
            this.gridBand9.Width = 188;
            // 
            // colNoOfEESep
            // 
            this.colNoOfEESep.FieldName = "NoOfEESep";
            this.colNoOfEESep.MinWidth = 25;
            this.colNoOfEESep.Name = "colNoOfEESep";
            this.colNoOfEESep.Visible = true;
            this.colNoOfEESep.Width = 94;
            // 
            // colSalaryDiffSep
            // 
            this.colSalaryDiffSep.FieldName = "SalaryDiffSep";
            this.colSalaryDiffSep.MinWidth = 25;
            this.colSalaryDiffSep.Name = "colSalaryDiffSep";
            this.colSalaryDiffSep.Visible = true;
            this.colSalaryDiffSep.Width = 94;
            // 
            // gridBand10
            // 
            this.gridBand10.Caption = "gridBand10";
            this.gridBand10.Columns.Add(this.colNoOfEENov);
            this.gridBand10.Columns.Add(this.colSalaryDiffNov);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.VisibleIndex = 10;
            this.gridBand10.Width = 188;
            // 
            // colNoOfEENov
            // 
            this.colNoOfEENov.FieldName = "NoOfEENov";
            this.colNoOfEENov.MinWidth = 25;
            this.colNoOfEENov.Name = "colNoOfEENov";
            this.colNoOfEENov.Visible = true;
            this.colNoOfEENov.Width = 94;
            // 
            // colSalaryDiffNov
            // 
            this.colSalaryDiffNov.FieldName = "SalaryDiffNov";
            this.colSalaryDiffNov.MinWidth = 25;
            this.colSalaryDiffNov.Name = "colSalaryDiffNov";
            this.colSalaryDiffNov.Visible = true;
            this.colSalaryDiffNov.Width = 94;
            // 
            // gridBand11
            // 
            this.gridBand11.Caption = "gridBand11";
            this.gridBand11.Columns.Add(this.colNoOfEEOct);
            this.gridBand11.Columns.Add(this.colSalaryDiffOct);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.VisibleIndex = 11;
            this.gridBand11.Width = 188;
            // 
            // colNoOfEEOct
            // 
            this.colNoOfEEOct.FieldName = "NoOfEEOct";
            this.colNoOfEEOct.MinWidth = 25;
            this.colNoOfEEOct.Name = "colNoOfEEOct";
            this.colNoOfEEOct.Visible = true;
            this.colNoOfEEOct.Width = 94;
            // 
            // colSalaryDiffOct
            // 
            this.colSalaryDiffOct.FieldName = "SalaryDiffOct";
            this.colSalaryDiffOct.MinWidth = 25;
            this.colSalaryDiffOct.Name = "colSalaryDiffOct";
            this.colSalaryDiffOct.Visible = true;
            this.colSalaryDiffOct.Width = 94;
            // 
            // gridBand12
            // 
            this.gridBand12.Caption = "gridBand12";
            this.gridBand12.Columns.Add(this.colNoOfEEDec);
            this.gridBand12.Columns.Add(this.colSalaryDiffDec);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.VisibleIndex = 12;
            this.gridBand12.Width = 188;
            // 
            // colNoOfEEDec
            // 
            this.colNoOfEEDec.FieldName = "NoOfEEDec";
            this.colNoOfEEDec.MinWidth = 25;
            this.colNoOfEEDec.Name = "colNoOfEEDec";
            this.colNoOfEEDec.Visible = true;
            this.colNoOfEEDec.Width = 94;
            // 
            // colSalaryDiffDec
            // 
            this.colSalaryDiffDec.FieldName = "SalaryDiffDec";
            this.colSalaryDiffDec.MinWidth = 25;
            this.colSalaryDiffDec.Name = "colSalaryDiffDec";
            this.colSalaryDiffDec.Visible = true;
            this.colSalaryDiffDec.Width = 94;
            // 
            // colOid
            // 
            this.colOid.FieldName = "Oid";
            this.colOid.MinWidth = 25;
            this.colOid.Name = "colOid";
            this.colOid.Visible = true;
            this.colOid.Width = 94;
            // 
            // ucSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "ucSummary";
            this.Size = new System.Drawing.Size(1267, 648);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.summaryModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource summaryModelBindingSource;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand detail;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDetail;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEJan;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffJan;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEFeb;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffFeb;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEMar;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffMar;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEApr;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffApr;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEMay;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffMay;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEJun;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffJun;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEJul;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffJul;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEAug;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffAug;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEESep;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffSep;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEENov;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffNov;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEOct;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffOct;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNoOfEEDec;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSalaryDiffDec;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colOid;
    }
}
