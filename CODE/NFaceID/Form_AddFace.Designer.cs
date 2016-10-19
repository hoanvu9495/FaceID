namespace NFaceID
{
    partial class Form_AddFace
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
            this.label_progressing = new System.Windows.Forms.Label();
            this.button_CameraURL = new System.Windows.Forms.Button();
            this.btn_FaceDetect = new System.Windows.Forms.Button();
            this.txt_HoTen = new System.Windows.Forms.TextBox();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_profile = new System.Windows.Forms.CheckBox();
            this.btn_createProfile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_Train_Enroll = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_progressing
            // 
            this.label_progressing.AutoSize = true;
            this.label_progressing.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label_progressing.ForeColor = System.Drawing.Color.White;
            this.label_progressing.Location = new System.Drawing.Point(13, 184);
            this.label_progressing.Name = "label_progressing";
            this.label_progressing.Size = new System.Drawing.Size(40, 15);
            this.label_progressing.TabIndex = 16;
            this.label_progressing.Text = "label5";
            // 
            // button_CameraURL
            // 
            this.button_CameraURL.BackColor = System.Drawing.Color.White;
            this.button_CameraURL.FlatAppearance.BorderSize = 0;
            this.button_CameraURL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CameraURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CameraURL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.button_CameraURL.Location = new System.Drawing.Point(178, 260);
            this.button_CameraURL.Name = "button_CameraURL";
            this.button_CameraURL.Size = new System.Drawing.Size(105, 25);
            this.button_CameraURL.TabIndex = 3;
            this.button_CameraURL.Text = "Lấy khuôn mặt";
            this.button_CameraURL.UseVisualStyleBackColor = false;
            this.button_CameraURL.Click += new System.EventHandler(this.button_OpenCameraStream);
            // 
            // btn_FaceDetect
            // 
            this.btn_FaceDetect.BackColor = System.Drawing.Color.White;
            this.btn_FaceDetect.FlatAppearance.BorderSize = 0;
            this.btn_FaceDetect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FaceDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FaceDetect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.btn_FaceDetect.Location = new System.Drawing.Point(97, 260);
            this.btn_FaceDetect.Name = "btn_FaceDetect";
            this.btn_FaceDetect.Size = new System.Drawing.Size(75, 25);
            this.btn_FaceDetect.TabIndex = 4;
            this.btn_FaceDetect.Text = "Chọn";
            this.btn_FaceDetect.UseVisualStyleBackColor = false;
            this.btn_FaceDetect.Click += new System.EventHandler(this.click_FaceDetect);
            // 
            // txt_HoTen
            // 
            this.txt_HoTen.Location = new System.Drawing.Point(238, 19);
            this.txt_HoTen.Name = "txt_HoTen";
            this.txt_HoTen.Size = new System.Drawing.Size(194, 21);
            this.txt_HoTen.TabIndex = 5;
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Location = new System.Drawing.Point(238, 47);
            this.txt_DiaChi.Multiline = true;
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(194, 47);
            this.txt_DiaChi.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(172, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Họ tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(172, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.label3.Location = new System.Drawing.Point(172, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(11, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 200);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_profile);
            this.groupBox1.Controls.Add(this.btn_createProfile);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txt_HoTen);
            this.groupBox1.Controls.Add(this.txt_DiaChi);
            this.groupBox1.Controls.Add(this.label_progressing);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(373, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 239);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // chk_profile
            // 
            this.chk_profile.AutoSize = true;
            this.chk_profile.Enabled = false;
            this.chk_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_profile.ForeColor = System.Drawing.Color.White;
            this.chk_profile.Location = new System.Drawing.Point(238, 136);
            this.chk_profile.Name = "chk_profile";
            this.chk_profile.Size = new System.Drawing.Size(84, 21);
            this.chk_profile.TabIndex = 19;
            this.chk_profile.Text = "Cập nhật";
            this.chk_profile.UseVisualStyleBackColor = true;
            // 
            // btn_createProfile
            // 
            this.btn_createProfile.BackColor = System.Drawing.Color.White;
            this.btn_createProfile.FlatAppearance.BorderSize = 0;
            this.btn_createProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_createProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.btn_createProfile.Location = new System.Drawing.Point(238, 105);
            this.btn_createProfile.Name = "btn_createProfile";
            this.btn_createProfile.Size = new System.Drawing.Size(121, 25);
            this.btn_createProfile.TabIndex = 18;
            this.btn_createProfile.Text = "Cập nhật thông tin";
            this.btn_createProfile.UseVisualStyleBackColor = false;
            this.btn_createProfile.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(246, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(344, 31);
            this.label5.TabIndex = 20;
            this.label5.Text = "Thêm khuôn mặt nhận dạng";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(16, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // button_Train_Enroll
            // 
            this.button_Train_Enroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.button_Train_Enroll.FlatAppearance.BorderSize = 0;
            this.button_Train_Enroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Train_Enroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Train_Enroll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.button_Train_Enroll.Image = global::NFaceID.Properties.Resources.save__2_;
            this.button_Train_Enroll.Location = new System.Drawing.Point(745, 8);
            this.button_Train_Enroll.Name = "button_Train_Enroll";
            this.button_Train_Enroll.Size = new System.Drawing.Size(32, 32);
            this.button_Train_Enroll.TabIndex = 8;
            this.button_Train_Enroll.UseVisualStyleBackColor = false;
            this.button_Train_Enroll.Click += new System.EventHandler(this.button_Click_Enroll);
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.button_Exit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Exit.FlatAppearance.BorderSize = 0;
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.button_Exit.Image = global::NFaceID.Properties.Resources.close1;
            this.button_Exit.Location = new System.Drawing.Point(790, 8);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(32, 32);
            this.button_Exit.TabIndex = 15;
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // Form_AddFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(828, 293);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Train_Enroll);
            this.Controls.Add(this.btn_FaceDetect);
            this.Controls.Add(this.button_CameraURL);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_AddFace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_AddFace_FormClosed);
            this.Load += new System.EventHandler(this.Form_AddFace_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Train_Enroll;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.Label label_progressing;
        private System.Windows.Forms.Button button_CameraURL;
        private System.Windows.Forms.Button btn_FaceDetect;
        private System.Windows.Forms.TextBox txt_HoTen;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chk_profile;
        private System.Windows.Forms.Button btn_createProfile;

    }
}