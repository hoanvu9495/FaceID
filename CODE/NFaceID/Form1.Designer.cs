namespace NFaceID
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.LiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngKýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CaiDatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.càiĐặtHệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.càiĐặtCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.càiĐặtChứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bậtChấmCôngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BaoCaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêDữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_video = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView_thumbnail = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView_report = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel_right_info = new System.Windows.Forms.Panel();
            this.lbl_HoTen = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.lbl_TrongSo = new System.Windows.Forms.Label();
            this.label_progressing = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_db_img = new System.Windows.Forms.Panel();
            this.panel_img = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel_right_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LiveToolStripMenuItem,
            this.đăngKýToolStripMenuItem,
            this.CaiDatToolStripMenuItem,
            this.BaoCaoToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1366, 29);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // LiveToolStripMenuItem
            // 
            this.LiveToolStripMenuItem.AutoSize = false;
            this.LiveToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.LiveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.LiveToolStripMenuItem.Image = global::NFaceID.Properties.Resources.Computer;
            this.LiveToolStripMenuItem.Name = "LiveToolStripMenuItem";
            this.LiveToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.LiveToolStripMenuItem.Text = "Live";
            // 
            // đăngKýToolStripMenuItem
            // 
            this.đăngKýToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.đăngKýToolStripMenuItem.Image = global::NFaceID.Properties.Resources.register;
            this.đăngKýToolStripMenuItem.Name = "đăngKýToolStripMenuItem";
            this.đăngKýToolStripMenuItem.Size = new System.Drawing.Size(80, 25);
            this.đăngKýToolStripMenuItem.Text = "Đăng ký";
            this.đăngKýToolStripMenuItem.Click += new System.EventHandler(this.đăngKýToolStripMenuItem_Click);
            // 
            // CaiDatToolStripMenuItem
            // 
            this.CaiDatToolStripMenuItem.AutoSize = false;
            this.CaiDatToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.CaiDatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.càiĐặtHệThốngToolStripMenuItem,
            this.càiĐặtCameraToolStripMenuItem,
            this.càiĐặtChứcNăngToolStripMenuItem,
            this.bậtChấmCôngToolStripMenuItem});
            this.CaiDatToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.CaiDatToolStripMenuItem.Image = global::NFaceID.Properties.Resources.Application;
            this.CaiDatToolStripMenuItem.Name = "CaiDatToolStripMenuItem";
            this.CaiDatToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.CaiDatToolStripMenuItem.Text = "Cài đặt";
            // 
            // càiĐặtHệThốngToolStripMenuItem
            // 
            this.càiĐặtHệThốngToolStripMenuItem.Name = "càiĐặtHệThốngToolStripMenuItem";
            this.càiĐặtHệThốngToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.càiĐặtHệThốngToolStripMenuItem.Text = "Cài đặt hệ thống";
            this.càiĐặtHệThốngToolStripMenuItem.Click += new System.EventHandler(this.càiĐặtHệThốngToolStripMenuItem_Click);
            // 
            // càiĐặtCameraToolStripMenuItem
            // 
            this.càiĐặtCameraToolStripMenuItem.Name = "càiĐặtCameraToolStripMenuItem";
            this.càiĐặtCameraToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.càiĐặtCameraToolStripMenuItem.Text = "Cài đặt camera";
            this.càiĐặtCameraToolStripMenuItem.Click += new System.EventHandler(this.càiĐặtCameraToolStripMenuItem_Click);
            // 
            // càiĐặtChứcNăngToolStripMenuItem
            // 
            this.càiĐặtChứcNăngToolStripMenuItem.Name = "càiĐặtChứcNăngToolStripMenuItem";
            this.càiĐặtChứcNăngToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.càiĐặtChứcNăngToolStripMenuItem.Text = "Cài đặt chức năng";
            this.càiĐặtChứcNăngToolStripMenuItem.Click += new System.EventHandler(this.càiĐặtChứcNăngToolStripMenuItem_Click);
            // 
            // bậtChấmCôngToolStripMenuItem
            // 
            this.bậtChấmCôngToolStripMenuItem.Name = "bậtChấmCôngToolStripMenuItem";
            this.bậtChấmCôngToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.bậtChấmCôngToolStripMenuItem.Text = "Bật chấm công";
            this.bậtChấmCôngToolStripMenuItem.Click += new System.EventHandler(this.bậtChấmCôngToolStripMenuItem_Click);
            // 
            // BaoCaoToolStripMenuItem
            // 
            this.BaoCaoToolStripMenuItem.AutoSize = false;
            this.BaoCaoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.BaoCaoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemDữLiệuToolStripMenuItem,
            this.thốngKêDữLiệuToolStripMenuItem});
            this.BaoCaoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.BaoCaoToolStripMenuItem.Image = global::NFaceID.Properties.Resources.Notes;
            this.BaoCaoToolStripMenuItem.Name = "BaoCaoToolStripMenuItem";
            this.BaoCaoToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.BaoCaoToolStripMenuItem.Text = "Báo cáo";
            // 
            // xemDữLiệuToolStripMenuItem
            // 
            this.xemDữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lịchSửNhânViênToolStripMenuItem,
            this.lịchSửToolStripMenuItem});
            this.xemDữLiệuToolStripMenuItem.Name = "xemDữLiệuToolStripMenuItem";
            this.xemDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.xemDữLiệuToolStripMenuItem.Text = "Xem dữ liệu";
            // 
            // lịchSửNhânViênToolStripMenuItem
            // 
            this.lịchSửNhânViênToolStripMenuItem.Name = "lịchSửNhânViênToolStripMenuItem";
            this.lịchSửNhânViênToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.lịchSửNhânViênToolStripMenuItem.Text = "Nhân viên";
            this.lịchSửNhânViênToolStripMenuItem.Click += new System.EventHandler(this.lịchSửNhânViênToolStripMenuItem_Click);
            // 
            // lịchSửToolStripMenuItem
            // 
            this.lịchSửToolStripMenuItem.Name = "lịchSửToolStripMenuItem";
            this.lịchSửToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.lịchSửToolStripMenuItem.Text = "Lịch sử";
            this.lịchSửToolStripMenuItem.Click += new System.EventHandler(this.lịchSửToolStripMenuItem_Click);
            // 
            // thốngKêDữLiệuToolStripMenuItem
            // 
            this.thốngKêDữLiệuToolStripMenuItem.Name = "thốngKêDữLiệuToolStripMenuItem";
            this.thốngKêDữLiệuToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.thốngKêDữLiệuToolStripMenuItem.Text = "Bảng chấm công";
            this.thốngKêDữLiệuToolStripMenuItem.Click += new System.EventHandler(this.thốngKêDữLiệuToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.AutoSize = false;
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Image = global::NFaceID.Properties.Resources.Help_book_3d;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(75, 25);
            this.helpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(121, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.thoátToolStripMenuItem.Image = global::NFaceID.Properties.Resources.Exit;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(67, 25);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // panel_video
            // 
            this.panel_video.BackColor = System.Drawing.Color.White;
            this.panel_video.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_video.Location = new System.Drawing.Point(3, 31);
            this.panel_video.Name = "panel_video";
            this.panel_video.Size = new System.Drawing.Size(929, 523);
            this.panel_video.TabIndex = 15;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(938, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(428, 723);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.tabPage1.Controls.Add(this.listView_thumbnail);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(420, 695);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hình ảnh tổng hợp";
            // 
            // listView_thumbnail
            // 
            this.listView_thumbnail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_thumbnail.Location = new System.Drawing.Point(3, 6);
            this.listView_thumbnail.Name = "listView_thumbnail";
            this.listView_thumbnail.Size = new System.Drawing.Size(414, 683);
            this.listView_thumbnail.TabIndex = 0;
            this.listView_thumbnail.UseCompatibleStateImageBehavior = false;
            this.listView_thumbnail.DoubleClick += new System.EventHandler(this.listView_thumbnail_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.tabPage2.Controls.Add(this.listView_report);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(420, 695);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Danh sách tổng hợp";
            // 
            // listView_report
            // 
            this.listView_report.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_report.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView_report.ForeColor = System.Drawing.Color.Green;
            this.listView_report.GridLines = true;
            this.listView_report.Location = new System.Drawing.Point(2, 8);
            this.listView_report.Name = "listView_report";
            this.listView_report.Size = new System.Drawing.Size(416, 695);
            this.listView_report.TabIndex = 1;
            this.listView_report.UseCompatibleStateImageBehavior = false;
            this.listView_report.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã NV";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên NV";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Vào";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ra";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Công";
            this.columnHeader6.Width = 50;
            // 
            // panel_right_info
            // 
            this.panel_right_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_right_info.BackColor = System.Drawing.Color.White;
            this.panel_right_info.Controls.Add(this.lbl_HoTen);
            this.panel_right_info.Controls.Add(this.label3);
            this.panel_right_info.Controls.Add(this.lbl_Time);
            this.panel_right_info.Controls.Add(this.lbl_TrongSo);
            this.panel_right_info.Controls.Add(this.label_progressing);
            this.panel_right_info.Controls.Add(this.label4);
            this.panel_right_info.Controls.Add(this.label2);
            this.panel_right_info.Controls.Add(this.label1);
            this.panel_right_info.Controls.Add(this.panel_db_img);
            this.panel_right_info.Controls.Add(this.panel_img);
            this.panel_right_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_right_info.Location = new System.Drawing.Point(3, 560);
            this.panel_right_info.Name = "panel_right_info";
            this.panel_right_info.Size = new System.Drawing.Size(929, 193);
            this.panel_right_info.TabIndex = 17;
            // 
            // lbl_HoTen
            // 
            this.lbl_HoTen.AutoSize = true;
            this.lbl_HoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HoTen.ForeColor = System.Drawing.Color.Green;
            this.lbl_HoTen.Location = new System.Drawing.Point(454, 45);
            this.lbl_HoTen.Name = "lbl_HoTen";
            this.lbl_HoTen.Size = new System.Drawing.Size(0, 17);
            this.lbl_HoTen.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(485, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "%";
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.ForeColor = System.Drawing.Color.Green;
            this.lbl_Time.Location = new System.Drawing.Point(454, 74);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(0, 17);
            this.lbl_Time.TabIndex = 12;
            // 
            // lbl_TrongSo
            // 
            this.lbl_TrongSo.AutoSize = true;
            this.lbl_TrongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TrongSo.ForeColor = System.Drawing.Color.Green;
            this.lbl_TrongSo.Location = new System.Drawing.Point(454, 104);
            this.lbl_TrongSo.Name = "lbl_TrongSo";
            this.lbl_TrongSo.Size = new System.Drawing.Size(17, 17);
            this.lbl_TrongSo.TabIndex = 11;
            this.lbl_TrongSo.Text = "0";
            // 
            // label_progressing
            // 
            this.label_progressing.AutoSize = true;
            this.label_progressing.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_progressing.ForeColor = System.Drawing.Color.ForestGreen;
            this.label_progressing.Location = new System.Drawing.Point(11, 152);
            this.label_progressing.Name = "label_progressing";
            this.label_progressing.Size = new System.Drawing.Size(72, 30);
            this.label_progressing.TabIndex = 10;
            this.label_progressing.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.label4.Location = new System.Drawing.Point(345, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tỷ lệ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.label2.Location = new System.Drawing.Point(345, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Giờ xuất hiện";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(106)))));
            this.label1.Location = new System.Drawing.Point(345, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Họ và tên:";
            // 
            // panel_db_img
            // 
            this.panel_db_img.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel_db_img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_db_img.Location = new System.Drawing.Point(176, 12);
            this.panel_db_img.Name = "panel_db_img";
            this.panel_db_img.Size = new System.Drawing.Size(141, 137);
            this.panel_db_img.TabIndex = 1;
            // 
            // panel_img
            // 
            this.panel_img.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel_img.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_img.Location = new System.Drawing.Point(16, 12);
            this.panel_img.Name = "panel_img";
            this.panel_img.Size = new System.Drawing.Size(141, 137);
            this.panel_img.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.panel_right_info);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel_video);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel_right_info.ResumeLayout(false);
            this.panel_right_info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem LiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CaiDatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem càiĐặtHệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem càiĐặtCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem càiĐặtChứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BaoCaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêDữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.Panel panel_video;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel_right_info;
        private System.Windows.Forms.Panel panel_db_img;
        private System.Windows.Forms.Panel panel_img;
        private System.Windows.Forms.ToolStripMenuItem đăngKýToolStripMenuItem;
        private System.Windows.Forms.Label label_progressing;
        private System.Windows.Forms.ListView listView_thumbnail;
        private System.Windows.Forms.ToolStripMenuItem lịchSửNhânViênToolStripMenuItem;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label lbl_TrongSo;
        private System.Windows.Forms.Label lbl_HoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem lịchSửToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bậtChấmCôngToolStripMenuItem;
        private System.Windows.Forms.ListView listView_report;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

