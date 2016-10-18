namespace NFaceID
{
    partial class Polygon
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel_content = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.panel_top.SuspendLayout();
            this.panel_content.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_top.BackColor = System.Drawing.Color.White;
            this.panel_top.Controls.Add(this.label1);
            this.panel_top.Location = new System.Drawing.Point(29, -4);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(803, 67);
            this.panel_top.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(157, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn vùng hoặc đối tượng cần giám sát";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(713, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cập nhật";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel_content
            // 
            this.panel_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_content.BackColor = System.Drawing.SystemColors.Control;
            this.panel_content.Controls.Add(this.panel_bottom);
            this.panel_content.Location = new System.Drawing.Point(29, 64);
            this.panel_content.Name = "panel_content";
            this.panel_content.Size = new System.Drawing.Size(803, 475);
            this.panel_content.TabIndex = 8;
            this.panel_content.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_content_MouseDown);
            this.panel_content.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_content_MouseMove);
            this.panel_content.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_content_MouseUp);
            // 
            // panel_bottom
            // 
            this.panel_bottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.panel_bottom.Controls.Add(this.button2);
            this.panel_bottom.Location = new System.Drawing.Point(1, 426);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(802, 43);
            this.panel_bottom.TabIndex = 0;
            // 
            // Polygon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 535);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.panel_content);
            this.Name = "Polygon";
            this.Text = "Lựa chọn vùng bắt mặt người";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Polygon_FormClosed);
            this.Load += new System.EventHandler(this.Polygon_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel_content.ResumeLayout(false);
            this.panel_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel_content;
        private System.Windows.Forms.Panel panel_bottom;
    }
}