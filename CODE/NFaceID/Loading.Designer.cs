﻿namespace NFaceID
{
    partial class Loading
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
            this.label1 = new System.Windows.Forms.Label();
            this.psb_load = new System.Windows.Forms.ProgressBar();
            this.lbl_TrangThai = new System.Windows.Forms.Label();
            this.lbl_Content = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(164, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khởi tạo";
            // 
            // psb_load
            // 
            this.psb_load.Location = new System.Drawing.Point(12, 63);
            this.psb_load.Name = "psb_load";
            this.psb_load.Size = new System.Drawing.Size(431, 23);
            this.psb_load.TabIndex = 1;
            // 
            // lbl_TrangThai
            // 
            this.lbl_TrangThai.AutoSize = true;
            this.lbl_TrangThai.ForeColor = System.Drawing.Color.White;
            this.lbl_TrangThai.Location = new System.Drawing.Point(9, 41);
            this.lbl_TrangThai.Name = "lbl_TrangThai";
            this.lbl_TrangThai.Size = new System.Drawing.Size(65, 15);
            this.lbl_TrangThai.TabIndex = 2;
            this.lbl_TrangThai.Text = "Trạng thái:";
            // 
            // lbl_Content
            // 
            this.lbl_Content.AutoSize = true;
            this.lbl_Content.ForeColor = System.Drawing.Color.White;
            this.lbl_Content.Location = new System.Drawing.Point(80, 41);
            this.lbl_Content.Name = "lbl_Content";
            this.lbl_Content.Size = new System.Drawing.Size(40, 15);
            this.lbl_Content.TabIndex = 3;
            this.lbl_Content.Text = "label2";
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(457, 100);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_Content);
            this.Controls.Add(this.lbl_TrangThai);
            this.Controls.Add(this.psb_load);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Loading_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar psb_load;
        private System.Windows.Forms.Label lbl_TrangThai;
        private System.Windows.Forms.Label lbl_Content;
    }
}