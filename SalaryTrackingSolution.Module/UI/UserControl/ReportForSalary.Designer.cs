
namespace SalaryTrackingSolution.Module.UI.UserControl
{
    partial class ReportForSalary
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
            this.showDetailSalaryInformationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listDetailSalaryModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnExport = new System.Windows.Forms.Button();
            this.showDetailSalaryInformationBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.listSalary = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlobalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSegment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJoinDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsibility = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHouseTransport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShuiPayToEmployee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalaryForShui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShui = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalGross = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.showDetailSalaryInformationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDetailSalaryModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showDetailSalaryInformationBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // showDetailSalaryInformationBindingSource
            // 
            this.showDetailSalaryInformationBindingSource.DataSource = typeof(SalaryTrackingSolution.Module.UI.Model.ShowDetailSalaryInformation);
            // 
            // listDetailSalaryModelBindingSource
            // 
            this.listDetailSalaryModelBindingSource.DataSource = typeof(SalaryTrackingSolution.Module.UI.Model.ListDetailSalaryModel);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(37, 32);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(113, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // showDetailSalaryInformationBindingSource1
            // 
            this.showDetailSalaryInformationBindingSource1.DataSource = typeof(SalaryTrackingSolution.Module.UI.Model.ShowDetailSalaryInformation);
            // 
            // listSalary
            // 
            this.listSalary.DataSource = this.showDetailSalaryInformationBindingSource1;
            this.listSalary.Location = new System.Drawing.Point(3, 86);
            this.listSalary.MainView = this.gridView1;
            this.listSalary.Name = "listSalary";
            this.listSalary.Size = new System.Drawing.Size(1301, 499);
            this.listSalary.TabIndex = 2;
            this.listSalary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.listSalary.Click += new System.EventHandler(this.listSalary_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFullName,
            this.colLocalId,
            this.colGlobalId,
            this.colSegment,
            this.colNote,
            this.colActive,
            this.colJoinDate,
            this.colEndDate,
            this.colBaseSalary,
            this.colResponsibility,
            this.colHouseTransport,
            this.colTelephone,
            this.colShuiPayToEmployee,
            this.colTotal,
            this.colSalaryForShui,
            this.colShui,
            this.colPIT,
            this.colTotalGross});
            this.gridView1.GridControl = this.listSalary;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colFullName
            // 
            this.colFullName.FieldName = "FullName";
            this.colFullName.MinWidth = 25;
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.ReadOnly = true;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 0;
            this.colFullName.Width = 94;
            // 
            // colLocalId
            // 
            this.colLocalId.FieldName = "LocalId";
            this.colLocalId.MinWidth = 25;
            this.colLocalId.Name = "colLocalId";
            this.colLocalId.Visible = true;
            this.colLocalId.VisibleIndex = 1;
            this.colLocalId.Width = 94;
            // 
            // colGlobalId
            // 
            this.colGlobalId.FieldName = "GlobalId";
            this.colGlobalId.MinWidth = 25;
            this.colGlobalId.Name = "colGlobalId";
            this.colGlobalId.Visible = true;
            this.colGlobalId.VisibleIndex = 2;
            this.colGlobalId.Width = 94;
            // 
            // colSegment
            // 
            this.colSegment.FieldName = "Segment";
            this.colSegment.MinWidth = 25;
            this.colSegment.Name = "colSegment";
            this.colSegment.Visible = true;
            this.colSegment.VisibleIndex = 3;
            this.colSegment.Width = 94;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.MinWidth = 25;
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 4;
            this.colNote.Width = 94;
            // 
            // colActive
            // 
            this.colActive.FieldName = "Active";
            this.colActive.MinWidth = 25;
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 5;
            this.colActive.Width = 94;
            // 
            // colJoinDate
            // 
            this.colJoinDate.FieldName = "JoinDate";
            this.colJoinDate.MinWidth = 25;
            this.colJoinDate.Name = "colJoinDate";
            this.colJoinDate.Visible = true;
            this.colJoinDate.VisibleIndex = 6;
            this.colJoinDate.Width = 94;
            // 
            // colEndDate
            // 
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.MinWidth = 25;
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 7;
            this.colEndDate.Width = 94;
            // 
            // colBaseSalary
            // 
            this.colBaseSalary.FieldName = "BaseSalary";
            this.colBaseSalary.MinWidth = 25;
            this.colBaseSalary.Name = "colBaseSalary";
            this.colBaseSalary.Visible = true;
            this.colBaseSalary.VisibleIndex = 8;
            this.colBaseSalary.Width = 94;
            // 
            // colResponsibility
            // 
            this.colResponsibility.FieldName = "Responsibility Allowance";
            this.colResponsibility.MinWidth = 25;
            this.colResponsibility.Name = "colResponsibility";
            this.colResponsibility.Visible = true;
            this.colResponsibility.VisibleIndex = 9;
            this.colResponsibility.Width = 94;
            // 
            // colHouseTransport
            // 
            this.colHouseTransport.FieldName = "House, Transport Allowance";
            this.colHouseTransport.MinWidth = 25;
            this.colHouseTransport.Name = "colHouseTransport";
            this.colHouseTransport.Visible = true;
            this.colHouseTransport.VisibleIndex = 10;
            this.colHouseTransport.Width = 94;
            // 
            // colTelephone
            // 
            this.colTelephone.FieldName = "Telephone";
            this.colTelephone.MinWidth = 25;
            this.colTelephone.Name = "colTelephone";
            this.colTelephone.Visible = true;
            this.colTelephone.VisibleIndex = 11;
            this.colTelephone.Width = 94;
            // 
            // colShuiPayToEmployee
            // 
            this.colShuiPayToEmployee.FieldName = "ShuiPayToEmployee";
            this.colShuiPayToEmployee.MinWidth = 25;
            this.colShuiPayToEmployee.Name = "colShuiPayToEmployee";
            this.colShuiPayToEmployee.Visible = true;
            this.colShuiPayToEmployee.VisibleIndex = 12;
            this.colShuiPayToEmployee.Width = 94;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.MinWidth = 25;
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 13;
            this.colTotal.Width = 94;
            // 
            // colSalaryForShui
            // 
            this.colSalaryForShui.FieldName = "SalaryForShui";
            this.colSalaryForShui.MinWidth = 25;
            this.colSalaryForShui.Name = "colSalaryForShui";
            this.colSalaryForShui.OptionsColumn.ReadOnly = true;
            this.colSalaryForShui.Visible = true;
            this.colSalaryForShui.VisibleIndex = 14;
            this.colSalaryForShui.Width = 94;
            // 
            // colShui
            // 
            this.colShui.FieldName = "Shui";
            this.colShui.MinWidth = 25;
            this.colShui.Name = "colShui";
            this.colShui.OptionsColumn.ReadOnly = true;
            this.colShui.Visible = true;
            this.colShui.VisibleIndex = 15;
            this.colShui.Width = 94;
            // 
            // colPIT
            // 
            this.colPIT.FieldName = "PIT";
            this.colPIT.MinWidth = 25;
            this.colPIT.Name = "colPIT";
            this.colPIT.OptionsColumn.ReadOnly = true;
            this.colPIT.Visible = true;
            this.colPIT.VisibleIndex = 16;
            this.colPIT.Width = 94;
            // 
            // colTotalGross
            // 
            this.colTotalGross.FieldName = "TotalGross";
            this.colTotalGross.MinWidth = 25;
            this.colTotalGross.Name = "colTotalGross";
            this.colTotalGross.OptionsColumn.ReadOnly = true;
            this.colTotalGross.Visible = true;
            this.colTotalGross.VisibleIndex = 17;
            this.colTotalGross.Width = 94;
            // 
            // ReportForSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listSalary);
            this.Controls.Add(this.btnExport);
            this.Name = "ReportForSalary";
            this.Size = new System.Drawing.Size(1304, 585);
            this.Load += new System.EventHandler(this.ReportForSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showDetailSalaryInformationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDetailSalaryModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showDetailSalaryInformationBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource listDetailSalaryModelBindingSource;
        private System.Windows.Forms.BindingSource showDetailSalaryInformationBindingSource;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.BindingSource showDetailSalaryInformationBindingSource1;
        private DevExpress.XtraGrid.GridControl listSalary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colLocalId;
        private DevExpress.XtraGrid.Columns.GridColumn colGlobalId;
        private DevExpress.XtraGrid.Columns.GridColumn colSegment;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colJoinDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsibility;
        private DevExpress.XtraGrid.Columns.GridColumn colHouseTransport;
        private DevExpress.XtraGrid.Columns.GridColumn colTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn colShuiPayToEmployee;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colSalaryForShui;
        private DevExpress.XtraGrid.Columns.GridColumn colShui;
        private DevExpress.XtraGrid.Columns.GridColumn colPIT;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalGross;
    }
}
