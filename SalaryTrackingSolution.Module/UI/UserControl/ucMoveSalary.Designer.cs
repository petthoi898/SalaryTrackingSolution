
namespace SalaryTrackingSolution.Module.UI.UserControl
{
    partial class ucMoveSalary
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
            DevExpress.XtraPivotGrid.DataSourceColumnBinding dataSourceColumnBinding1 = new DevExpress.XtraPivotGrid.DataSourceColumnBinding();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.moveSalaryModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnExport = new System.Windows.Forms.Button();
            this.timeFrom = new System.Windows.Forms.DateTimePicker();
            this.timeTo = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.moveSalaryModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.moveSalaryModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveSalaryModelBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.AreaIndex = 0;
            dataSourceColumnBinding1.ColumnName = "Salary.BaseSalary";
            this.pivotGridField2.DataBinding = dataSourceColumnBinding1;
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(1051, 576);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(157, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // timeFrom
            // 
            this.timeFrom.Location = new System.Drawing.Point(90, 577);
            this.timeFrom.Name = "timeFrom";
            this.timeFrom.Size = new System.Drawing.Size(200, 22);
            this.timeFrom.TabIndex = 5;
            // 
            // timeTo
            // 
            this.timeTo.Location = new System.Drawing.Point(375, 577);
            this.timeTo.Name = "timeTo";
            this.timeTo.Size = new System.Drawing.Size(200, 22);
            this.timeTo.TabIndex = 6;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(809, 576);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(137, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // moveSalaryModelBindingSource1
            // 
            this.moveSalaryModelBindingSource1.DataSource = typeof(SalaryTrackingSolution.Module.UI.Model.MoveSalaryModel);
            // 
            // ucMoveSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.timeTo);
            this.Controls.Add(this.timeFrom);
            this.Controls.Add(this.btnExport);
            this.Name = "ucMoveSalary";
            this.Size = new System.Drawing.Size(1615, 687);
            ((System.ComponentModel.ISupportInitialize)(this.moveSalaryModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveSalaryModelBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource moveSalaryModelBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private System.Windows.Forms.BindingSource moveSalaryModelBindingSource1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DateTimePicker timeFrom;
        private System.Windows.Forms.DateTimePicker timeTo;
        private System.Windows.Forms.Button btnLoad;
    }
}
