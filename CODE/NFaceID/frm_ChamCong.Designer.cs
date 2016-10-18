namespace NFaceID
{
    partial class frm_ChamCong
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_CC = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_year = new System.Windows.Forms.TextBox();
            this.cbx_Month = new System.Windows.Forms.ComboBox();
            this.dgv_Detail = new System.Windows.Forms.DataGridView();
            this.STT_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMG_IN_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMG_OUT_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_EMP_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME_IN_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIME_OUT_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GHICHU_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Excel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_CC
            // 
            this.dgv_CC.AllowUserToAddRows = false;
            this.dgv_CC.AllowUserToDeleteRows = false;
            this.dgv_CC.BackgroundColor = System.Drawing.Color.White;
            this.dgv_CC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CC.Location = new System.Drawing.Point(17, 118);
            this.dgv_CC.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_CC.Name = "dgv_CC";
            this.dgv_CC.ReadOnly = true;
            this.dgv_CC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CC.Size = new System.Drawing.Size(701, 446);
            this.dgv_CC.TabIndex = 0;
            this.dgv_CC.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CC_RowEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(541, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bảng chấm công";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(217, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tháng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(333, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Năm";
            // 
            // txt_year
            // 
            this.txt_year.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_year.Location = new System.Drawing.Point(373, 90);
            this.txt_year.Margin = new System.Windows.Forms.Padding(4);
            this.txt_year.Name = "txt_year";
            this.txt_year.Size = new System.Drawing.Size(56, 21);
            this.txt_year.TabIndex = 7;
            this.txt_year.Text = "2016";
            // 
            // cbx_Month
            // 
            this.cbx_Month.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_Month.FormattingEnabled = true;
            this.cbx_Month.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbx_Month.Location = new System.Drawing.Point(268, 88);
            this.cbx_Month.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_Month.Name = "cbx_Month";
            this.cbx_Month.Size = new System.Drawing.Size(59, 23);
            this.cbx_Month.TabIndex = 8;
            // 
            // dgv_Detail
            // 
            this.dgv_Detail.AllowUserToAddRows = false;
            this.dgv_Detail.AllowUserToDeleteRows = false;
            this.dgv_Detail.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT_D,
            this.IMG_IN_D,
            this.IMG_OUT_D,
            this.NAME_D,
            this.ID_D,
            this.ID_EMP_D,
            this.DATE_D,
            this.TIME_IN_D,
            this.TIME_OUT_D,
            this.GHICHU_D});
            this.dgv_Detail.Location = new System.Drawing.Point(723, 118);
            this.dgv_Detail.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Detail.Name = "dgv_Detail";
            this.dgv_Detail.ReadOnly = true;
            this.dgv_Detail.Size = new System.Drawing.Size(456, 446);
            this.dgv_Detail.TabIndex = 9;
            // 
            // STT_D
            // 
            this.STT_D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.STT_D.DataPropertyName = "STT";
            this.STT_D.HeaderText = "STT";
            this.STT_D.Name = "STT_D";
            this.STT_D.ReadOnly = true;
            this.STT_D.Width = 54;
            // 
            // IMG_IN_D
            // 
            this.IMG_IN_D.DataPropertyName = "IMG_IN";
            this.IMG_IN_D.HeaderText = "IMG_IN";
            this.IMG_IN_D.Name = "IMG_IN_D";
            this.IMG_IN_D.ReadOnly = true;
            this.IMG_IN_D.Visible = false;
            // 
            // IMG_OUT_D
            // 
            this.IMG_OUT_D.DataPropertyName = "IMG_OUT";
            this.IMG_OUT_D.HeaderText = "IMG_OUT";
            this.IMG_OUT_D.Name = "IMG_OUT_D";
            this.IMG_OUT_D.ReadOnly = true;
            this.IMG_OUT_D.Visible = false;
            // 
            // NAME_D
            // 
            this.NAME_D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NAME_D.DataPropertyName = "NAME";
            this.NAME_D.HeaderText = "Nhân viên";
            this.NAME_D.Name = "NAME_D";
            this.NAME_D.ReadOnly = true;
            this.NAME_D.Width = 87;
            // 
            // ID_D
            // 
            this.ID_D.DataPropertyName = "ID";
            this.ID_D.HeaderText = "ID";
            this.ID_D.Name = "ID_D";
            this.ID_D.ReadOnly = true;
            this.ID_D.Visible = false;
            // 
            // ID_EMP_D
            // 
            this.ID_EMP_D.DataPropertyName = "ID_EMP";
            this.ID_EMP_D.HeaderText = "ID_EMP_D";
            this.ID_EMP_D.Name = "ID_EMP_D";
            this.ID_EMP_D.ReadOnly = true;
            this.ID_EMP_D.Visible = false;
            // 
            // DATE_D
            // 
            this.DATE_D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DATE_D.DataPropertyName = "DATE_ATT";
            this.DATE_D.HeaderText = "Ngày";
            this.DATE_D.Name = "DATE_D";
            this.DATE_D.ReadOnly = true;
            this.DATE_D.Width = 60;
            // 
            // TIME_IN_D
            // 
            this.TIME_IN_D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TIME_IN_D.DataPropertyName = "TIME_IN";
            this.TIME_IN_D.HeaderText = "Đến";
            this.TIME_IN_D.Name = "TIME_IN_D";
            this.TIME_IN_D.ReadOnly = true;
            this.TIME_IN_D.Width = 55;
            // 
            // TIME_OUT_D
            // 
            this.TIME_OUT_D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TIME_OUT_D.DataPropertyName = "TIME_OUT";
            this.TIME_OUT_D.HeaderText = "Về";
            this.TIME_OUT_D.Name = "TIME_OUT_D";
            this.TIME_OUT_D.ReadOnly = true;
            this.TIME_OUT_D.Width = 46;
            // 
            // GHICHU_D
            // 
            this.GHICHU_D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GHICHU_D.DataPropertyName = "GHICHU";
            this.GHICHU_D.HeaderText = "Ghi chú";
            this.GHICHU_D.Name = "GHICHU_D";
            this.GHICHU_D.ReadOnly = true;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.btn_Exit.Image = global::NFaceID.Properties.Resources.close1;
            this.btn_Exit.Location = new System.Drawing.Point(1148, 10);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(32, 32);
            this.btn_Exit.TabIndex = 10;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.button1.Image = global::NFaceID.Properties.Resources.Search1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(551, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Lọc";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Excel
            // 
            this.btn_Excel.BackColor = System.Drawing.Color.White;
            this.btn_Excel.FlatAppearance.BorderSize = 0;
            this.btn_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Excel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.btn_Excel.Image = global::NFaceID.Properties.Resources.Excel;
            this.btn_Excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Excel.Location = new System.Drawing.Point(636, 72);
            this.btn_Excel.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(79, 40);
            this.btn_Excel.TabIndex = 1;
            this.btn_Excel.Text = "Excel";
            this.btn_Excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Excel.UseVisualStyleBackColor = false;
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // frm_ChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(1192, 573);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.dgv_Detail);
            this.Controls.Add(this.cbx_Month);
            this.Controls.Add(this.txt_year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Excel);
            this.Controls.Add(this.dgv_CC);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_ChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frm_ChamCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_CC;
        private System.Windows.Forms.Button btn_Excel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_year;
        private System.Windows.Forms.ComboBox cbx_Month;
        private System.Windows.Forms.DataGridView dgv_Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMG_IN_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMG_OUT_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_EMP_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_IN_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIME_OUT_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn GHICHU_D;
        private System.Windows.Forms.Button btn_Exit;
    }
}