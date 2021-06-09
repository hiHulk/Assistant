namespace Assistant
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Replace_thing = new System.Windows.Forms.TabPage();
            this.replace_go = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.Replace_out = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.Domain_list_box = new System.Windows.Forms.TextBox();
            this.Model_S = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.Domain_screening = new System.Windows.Forms.TabPage();
            this.Set_condition_groupBox = new System.Windows.Forms.GroupBox();
            this.Set_cond_sexy = new System.Windows.Forms.CheckBox();
            this.Set_cond_language = new System.Windows.Forms.CheckBox();
            this.Set_cond_bet = new System.Windows.Forms.CheckBox();
            this.Set_cond_null = new System.Windows.Forms.CheckBox();
            this.update_data_checkBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.WriteCookiefile = new System.Windows.Forms.Button();
            this.Query_interval_Textbox = new System.Windows.Forms.TextBox();
            this.Query_interval = new System.Windows.Forms.Label();
            this.Reload_cookie = new System.Windows.Forms.Button();
            this.cookie_lable = new System.Windows.Forms.Label();
            this.cookie_box = new System.Windows.Forms.RichTextBox();
            this.Filter_domain_web_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Key_list = new System.Windows.Forms.ComboBox();
            this.Set_Threads_Tile = new System.Windows.Forms.Label();
            this.Title_Matched_Domains_2 = new System.Windows.Forms.Label();
            this.Set_Threads_Num = new System.Windows.Forms.ComboBox();
            this.Filter_domain_button = new System.Windows.Forms.Button();
            this.out_data_excel = new System.Windows.Forms.Button();
            this.Domain_Box = new System.Windows.Forms.RichTextBox();
            this.All_site_num_show = new System.Windows.Forms.Label();
            this.Query_show_slash = new System.Windows.Forms.Label();
            this.Queried_site_num_lable = new System.Windows.Forms.Label();
            this.DataView = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Web_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domain_url = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Data_Sources = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Out_label = new System.Windows.Forms.Label();
            this.Title_Matched_Domains_1 = new System.Windows.Forms.Label();
            this.Out_box = new System.Windows.Forms.TextBox();
            this.DomainAssistant_Toolbar = new System.Windows.Forms.TabControl();
            this.Little_ico = new System.Windows.Forms.NotifyIcon(this.components);
            this.Menu_ico = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Close_Menu_ico = new System.Windows.Forms.ToolStripMenuItem();
            this.Show_Query_Num_timer500 = new System.Windows.Forms.Timer(this.components);
            this.Reload_number_people = new System.Windows.Forms.Timer(this.components);
            this.Replace_thing.SuspendLayout();
            this.Domain_screening.SuspendLayout();
            this.Set_condition_groupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.DomainAssistant_Toolbar.SuspendLayout();
            this.Menu_ico.SuspendLayout();
            this.SuspendLayout();
            // 
            // Replace_thing
            // 
            this.Replace_thing.Controls.Add(this.replace_go);
            this.Replace_thing.Controls.Add(this.label28);
            this.Replace_thing.Controls.Add(this.Replace_out);
            this.Replace_thing.Controls.Add(this.label27);
            this.Replace_thing.Controls.Add(this.Domain_list_box);
            this.Replace_thing.Controls.Add(this.Model_S);
            this.Replace_thing.Controls.Add(this.label26);
            this.Replace_thing.Location = new System.Drawing.Point(4, 22);
            this.Replace_thing.Name = "Replace_thing";
            this.Replace_thing.Padding = new System.Windows.Forms.Padding(3);
            this.Replace_thing.Size = new System.Drawing.Size(1252, 591);
            this.Replace_thing.TabIndex = 1;
            this.Replace_thing.Text = "字符串替换";
            this.Replace_thing.UseVisualStyleBackColor = true;
            // 
            // replace_go
            // 
            this.replace_go.Location = new System.Drawing.Point(902, 505);
            this.replace_go.Name = "replace_go";
            this.replace_go.Size = new System.Drawing.Size(136, 80);
            this.replace_go.TabIndex = 13;
            this.replace_go.Text = "替换";
            this.replace_go.UseVisualStyleBackColor = true;
            this.replace_go.Click += new System.EventHandler(this.replace_go_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(184, 192);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 12);
            this.label28.TabIndex = 12;
            this.label28.Text = "结果";
            // 
            // Replace_out
            // 
            this.Replace_out.Location = new System.Drawing.Point(186, 207);
            this.Replace_out.Multiline = true;
            this.Replace_out.Name = "Replace_out";
            this.Replace_out.Size = new System.Drawing.Size(710, 378);
            this.Replace_out.TabIndex = 11;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 192);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 12);
            this.label27.TabIndex = 10;
            this.label27.Text = "元素";
            // 
            // Domain_list_box
            // 
            this.Domain_list_box.Location = new System.Drawing.Point(6, 207);
            this.Domain_list_box.Multiline = true;
            this.Domain_list_box.Name = "Domain_list_box";
            this.Domain_list_box.Size = new System.Drawing.Size(172, 378);
            this.Domain_list_box.TabIndex = 9;
            // 
            // Model_S
            // 
            this.Model_S.Location = new System.Drawing.Point(6, 18);
            this.Model_S.Multiline = true;
            this.Model_S.Name = "Model_S";
            this.Model_S.Size = new System.Drawing.Size(890, 171);
            this.Model_S.TabIndex = 8;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 3);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 7;
            this.label26.Text = "模板";
            // 
            // Domain_screening
            // 
            this.Domain_screening.Controls.Add(this.Set_condition_groupBox);
            this.Domain_screening.Controls.Add(this.panel2);
            this.Domain_screening.Controls.Add(this.panel1);
            this.Domain_screening.Controls.Add(this.out_data_excel);
            this.Domain_screening.Controls.Add(this.Domain_Box);
            this.Domain_screening.Controls.Add(this.All_site_num_show);
            this.Domain_screening.Controls.Add(this.Query_show_slash);
            this.Domain_screening.Controls.Add(this.Queried_site_num_lable);
            this.Domain_screening.Controls.Add(this.DataView);
            this.Domain_screening.Controls.Add(this.Out_label);
            this.Domain_screening.Controls.Add(this.Title_Matched_Domains_1);
            this.Domain_screening.Controls.Add(this.Out_box);
            this.Domain_screening.Location = new System.Drawing.Point(4, 22);
            this.Domain_screening.Name = "Domain_screening";
            this.Domain_screening.Padding = new System.Windows.Forms.Padding(3);
            this.Domain_screening.Size = new System.Drawing.Size(1252, 591);
            this.Domain_screening.TabIndex = 0;
            this.Domain_screening.Text = "域名筛选";
            this.Domain_screening.UseVisualStyleBackColor = true;
            // 
            // Set_condition_groupBox
            // 
            this.Set_condition_groupBox.Controls.Add(this.Set_cond_sexy);
            this.Set_condition_groupBox.Controls.Add(this.Set_cond_language);
            this.Set_condition_groupBox.Controls.Add(this.Set_cond_bet);
            this.Set_condition_groupBox.Controls.Add(this.Set_cond_null);
            this.Set_condition_groupBox.Controls.Add(this.update_data_checkBox);
            this.Set_condition_groupBox.Location = new System.Drawing.Point(165, 3);
            this.Set_condition_groupBox.Name = "Set_condition_groupBox";
            this.Set_condition_groupBox.Size = new System.Drawing.Size(81, 127);
            this.Set_condition_groupBox.TabIndex = 21;
            this.Set_condition_groupBox.TabStop = false;
            this.Set_condition_groupBox.Text = "条件设置";
            // 
            // Set_cond_sexy
            // 
            this.Set_cond_sexy.AutoSize = true;
            this.Set_cond_sexy.Location = new System.Drawing.Point(6, 64);
            this.Set_cond_sexy.Name = "Set_cond_sexy";
            this.Set_cond_sexy.Size = new System.Drawing.Size(66, 16);
            this.Set_cond_sexy.TabIndex = 14;
            this.Set_cond_sexy.Text = "不含s词";
            this.Set_cond_sexy.UseVisualStyleBackColor = true;
            // 
            // Set_cond_language
            // 
            this.Set_cond_language.AutoSize = true;
            this.Set_cond_language.Location = new System.Drawing.Point(6, 20);
            this.Set_cond_language.Name = "Set_cond_language";
            this.Set_cond_language.Size = new System.Drawing.Size(72, 16);
            this.Set_cond_language.TabIndex = 12;
            this.Set_cond_language.Text = "只要中文";
            this.Set_cond_language.UseVisualStyleBackColor = true;
            // 
            // Set_cond_bet
            // 
            this.Set_cond_bet.AutoSize = true;
            this.Set_cond_bet.Location = new System.Drawing.Point(6, 42);
            this.Set_cond_bet.Name = "Set_cond_bet";
            this.Set_cond_bet.Size = new System.Drawing.Size(72, 16);
            this.Set_cond_bet.TabIndex = 13;
            this.Set_cond_bet.Text = "不含bc词";
            this.Set_cond_bet.UseVisualStyleBackColor = true;
            // 
            // Set_cond_null
            // 
            this.Set_cond_null.AutoSize = true;
            this.Set_cond_null.Checked = true;
            this.Set_cond_null.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Set_cond_null.Location = new System.Drawing.Point(6, 64);
            this.Set_cond_null.Name = "Set_cond_null";
            this.Set_cond_null.Size = new System.Drawing.Size(72, 16);
            this.Set_cond_null.TabIndex = 15;
            this.Set_cond_null.Text = "去掉空值";
            this.Set_cond_null.UseVisualStyleBackColor = true;
            // 
            // update_data_checkBox
            // 
            this.update_data_checkBox.AutoSize = true;
            this.update_data_checkBox.Location = new System.Drawing.Point(6, 64);
            this.update_data_checkBox.Name = "update_data_checkBox";
            this.update_data_checkBox.Size = new System.Drawing.Size(72, 16);
            this.update_data_checkBox.TabIndex = 14;
            this.update_data_checkBox.Text = "更新数据";
            this.update_data_checkBox.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.WriteCookiefile);
            this.panel2.Controls.Add(this.Query_interval_Textbox);
            this.panel2.Controls.Add(this.Query_interval);
            this.panel2.Controls.Add(this.Reload_cookie);
            this.panel2.Controls.Add(this.cookie_lable);
            this.panel2.Controls.Add(this.cookie_box);
            this.panel2.Controls.Add(this.Filter_domain_web_button);
            this.panel2.Location = new System.Drawing.Point(251, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 124);
            this.panel2.TabIndex = 20;
            // 
            // WriteCookiefile
            // 
            this.WriteCookiefile.Location = new System.Drawing.Point(217, 72);
            this.WriteCookiefile.Name = "WriteCookiefile";
            this.WriteCookiefile.Size = new System.Drawing.Size(82, 20);
            this.WriteCookiefile.TabIndex = 29;
            this.WriteCookiefile.Text = "写入Cookie";
            this.WriteCookiefile.UseVisualStyleBackColor = true;
            this.WriteCookiefile.Click += new System.EventHandler(this.WriteCookiefile_Click);
            // 
            // Query_interval_Textbox
            // 
            this.Query_interval_Textbox.Location = new System.Drawing.Point(217, 18);
            this.Query_interval_Textbox.Name = "Query_interval_Textbox";
            this.Query_interval_Textbox.Size = new System.Drawing.Size(56, 21);
            this.Query_interval_Textbox.TabIndex = 28;
            this.Query_interval_Textbox.Text = "4";
            this.Query_interval_Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Query_interval_Textbox_KeyPress);
            // 
            // Query_interval
            // 
            this.Query_interval.AutoSize = true;
            this.Query_interval.Location = new System.Drawing.Point(215, 3);
            this.Query_interval.Name = "Query_interval";
            this.Query_interval.Size = new System.Drawing.Size(53, 12);
            this.Query_interval.TabIndex = 27;
            this.Query_interval.Text = "间隔(秒)";
            // 
            // Reload_cookie
            // 
            this.Reload_cookie.Location = new System.Drawing.Point(217, 46);
            this.Reload_cookie.Name = "Reload_cookie";
            this.Reload_cookie.Size = new System.Drawing.Size(82, 20);
            this.Reload_cookie.TabIndex = 26;
            this.Reload_cookie.Text = "载入Cookie";
            this.Reload_cookie.UseVisualStyleBackColor = true;
            this.Reload_cookie.Click += new System.EventHandler(this.Reload_cookie_Click);
            // 
            // cookie_lable
            // 
            this.cookie_lable.AutoSize = true;
            this.cookie_lable.Location = new System.Drawing.Point(3, 3);
            this.cookie_lable.Name = "cookie_lable";
            this.cookie_lable.Size = new System.Drawing.Size(47, 12);
            this.cookie_lable.TabIndex = 24;
            this.cookie_lable.Text = "Cookie:";
            // 
            // cookie_box
            // 
            this.cookie_box.Location = new System.Drawing.Point(3, 18);
            this.cookie_box.Name = "cookie_box";
            this.cookie_box.Size = new System.Drawing.Size(208, 101);
            this.cookie_box.TabIndex = 22;
            this.cookie_box.Text = "";
            // 
            // Filter_domain_web_button
            // 
            this.Filter_domain_web_button.Location = new System.Drawing.Point(217, 96);
            this.Filter_domain_web_button.Name = "Filter_domain_web_button";
            this.Filter_domain_web_button.Size = new System.Drawing.Size(82, 24);
            this.Filter_domain_web_button.TabIndex = 4;
            this.Filter_domain_web_button.Text = "开始";
            this.Filter_domain_web_button.UseVisualStyleBackColor = true;
            this.Filter_domain_web_button.Click += new System.EventHandler(this.Filter_domain_web_button_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Key_list);
            this.panel1.Controls.Add(this.Set_Threads_Tile);
            this.panel1.Controls.Add(this.Title_Matched_Domains_2);
            this.panel1.Controls.Add(this.Set_Threads_Num);
            this.panel1.Controls.Add(this.Filter_domain_button);
            this.panel1.Location = new System.Drawing.Point(561, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 57);
            this.panel1.TabIndex = 19;
            // 
            // Key_list
            // 
            this.Key_list.FormattingEnabled = true;
            this.Key_list.Location = new System.Drawing.Point(38, 5);
            this.Key_list.Name = "Key_list";
            this.Key_list.Size = new System.Drawing.Size(217, 20);
            this.Key_list.TabIndex = 9;
            this.Key_list.TextChanged += new System.EventHandler(this.Key_list_TextChanged);
            // 
            // Set_Threads_Tile
            // 
            this.Set_Threads_Tile.AutoSize = true;
            this.Set_Threads_Tile.Location = new System.Drawing.Point(3, 34);
            this.Set_Threads_Tile.Name = "Set_Threads_Tile";
            this.Set_Threads_Tile.Size = new System.Drawing.Size(29, 12);
            this.Set_Threads_Tile.TabIndex = 8;
            this.Set_Threads_Tile.Text = "线程";
            // 
            // Title_Matched_Domains_2
            // 
            this.Title_Matched_Domains_2.AutoSize = true;
            this.Title_Matched_Domains_2.Location = new System.Drawing.Point(9, 8);
            this.Title_Matched_Domains_2.Name = "Title_Matched_Domains_2";
            this.Title_Matched_Domains_2.Size = new System.Drawing.Size(23, 12);
            this.Title_Matched_Domains_2.TabIndex = 2;
            this.Title_Matched_Domains_2.Text = "KEY";
            // 
            // Set_Threads_Num
            // 
            this.Set_Threads_Num.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Set_Threads_Num.FormattingEnabled = true;
            this.Set_Threads_Num.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.Set_Threads_Num.Location = new System.Drawing.Point(38, 31);
            this.Set_Threads_Num.Name = "Set_Threads_Num";
            this.Set_Threads_Num.Size = new System.Drawing.Size(63, 20);
            this.Set_Threads_Num.TabIndex = 10;
            this.Set_Threads_Num.TextChanged += new System.EventHandler(this.Set_Threads_Num_TextChanged);
            // 
            // Filter_domain_button
            // 
            this.Filter_domain_button.Location = new System.Drawing.Point(165, 29);
            this.Filter_domain_button.Name = "Filter_domain_button";
            this.Filter_domain_button.Size = new System.Drawing.Size(90, 22);
            this.Filter_domain_button.TabIndex = 8;
            this.Filter_domain_button.Text = "API筛查域名";
            this.Filter_domain_button.UseVisualStyleBackColor = true;
            this.Filter_domain_button.Click += new System.EventHandler(this.Filter_domain_button_Click);
            // 
            // out_data_excel
            // 
            this.out_data_excel.Location = new System.Drawing.Point(561, 85);
            this.out_data_excel.Name = "out_data_excel";
            this.out_data_excel.Size = new System.Drawing.Size(77, 45);
            this.out_data_excel.TabIndex = 16;
            this.out_data_excel.Text = "导出数据到Excel";
            this.out_data_excel.UseVisualStyleBackColor = true;
            this.out_data_excel.Click += new System.EventHandler(this.out_data_excel_Click);
            // 
            // Domain_Box
            // 
            this.Domain_Box.Location = new System.Drawing.Point(8, 18);
            this.Domain_Box.Name = "Domain_Box";
            this.Domain_Box.Size = new System.Drawing.Size(151, 567);
            this.Domain_Box.TabIndex = 15;
            this.Domain_Box.Text = "";
            // 
            // All_site_num_show
            // 
            this.All_site_num_show.AutoSize = true;
            this.All_site_num_show.Location = new System.Drawing.Point(786, 115);
            this.All_site_num_show.Name = "All_site_num_show";
            this.All_site_num_show.Size = new System.Drawing.Size(11, 12);
            this.All_site_num_show.TabIndex = 14;
            this.All_site_num_show.Text = "0";
            // 
            // Query_show_slash
            // 
            this.Query_show_slash.AutoSize = true;
            this.Query_show_slash.Location = new System.Drawing.Point(775, 115);
            this.Query_show_slash.Name = "Query_show_slash";
            this.Query_show_slash.Size = new System.Drawing.Size(11, 12);
            this.Query_show_slash.TabIndex = 13;
            this.Query_show_slash.Text = "/";
            // 
            // Queried_site_num_lable
            // 
            this.Queried_site_num_lable.Location = new System.Drawing.Point(715, 115);
            this.Queried_site_num_lable.Name = "Queried_site_num_lable";
            this.Queried_site_num_lable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Queried_site_num_lable.Size = new System.Drawing.Size(59, 15);
            this.Queried_site_num_lable.TabIndex = 12;
            this.Queried_site_num_lable.Text = "0";
            this.Queried_site_num_lable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DataView
            // 
            this.DataView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Domain,
            this.Web_Title,
            this.domain_url,
            this.Data_Sources});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataView.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataView.Location = new System.Drawing.Point(165, 136);
            this.DataView.Name = "DataView";
            this.DataView.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DataView.RowTemplate.Height = 23;
            this.DataView.Size = new System.Drawing.Size(1081, 449);
            this.DataView.TabIndex = 7;
            this.DataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_CellContentClick);
            // 
            // Num
            // 
            this.Num.HeaderText = "编号";
            this.Num.Name = "Num";
            this.Num.Width = 40;
            // 
            // Domain
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Domain.DefaultCellStyle = dataGridViewCellStyle2;
            this.Domain.HeaderText = "域名";
            this.Domain.Name = "Domain";
            this.Domain.Width = 120;
            // 
            // Web_Title
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Web_Title.DefaultCellStyle = dataGridViewCellStyle3;
            this.Web_Title.HeaderText = "首页标题";
            this.Web_Title.Name = "Web_Title";
            this.Web_Title.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Web_Title.Width = 400;
            // 
            // domain_url
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.domain_url.DefaultCellStyle = dataGridViewCellStyle4;
            this.domain_url.HeaderText = "链接";
            this.domain_url.Name = "domain_url";
            this.domain_url.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.domain_url.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.domain_url.Width = 420;
            // 
            // Data_Sources
            // 
            this.Data_Sources.HeaderText = "数据来源";
            this.Data_Sources.Name = "Data_Sources";
            // 
            // Out_label
            // 
            this.Out_label.AutoSize = true;
            this.Out_label.Location = new System.Drawing.Point(832, 3);
            this.Out_label.Name = "Out_label";
            this.Out_label.Size = new System.Drawing.Size(59, 12);
            this.Out_label.TabIndex = 6;
            this.Out_label.Text = "输出日志:";
            // 
            // Title_Matched_Domains_1
            // 
            this.Title_Matched_Domains_1.AutoSize = true;
            this.Title_Matched_Domains_1.Location = new System.Drawing.Point(6, 3);
            this.Title_Matched_Domains_1.Name = "Title_Matched_Domains_1";
            this.Title_Matched_Domains_1.Size = new System.Drawing.Size(119, 12);
            this.Title_Matched_Domains_1.TabIndex = 0;
            this.Title_Matched_Domains_1.Text = "放入域名(baidu.com)";
            // 
            // Out_box
            // 
            this.Out_box.Location = new System.Drawing.Point(834, 18);
            this.Out_box.Multiline = true;
            this.Out_box.Name = "Out_box";
            this.Out_box.Size = new System.Drawing.Size(412, 112);
            this.Out_box.TabIndex = 5;
            // 
            // DomainAssistant_Toolbar
            // 
            this.DomainAssistant_Toolbar.Controls.Add(this.Domain_screening);
            this.DomainAssistant_Toolbar.Controls.Add(this.Replace_thing);
            this.DomainAssistant_Toolbar.Location = new System.Drawing.Point(12, 12);
            this.DomainAssistant_Toolbar.Name = "DomainAssistant_Toolbar";
            this.DomainAssistant_Toolbar.SelectedIndex = 0;
            this.DomainAssistant_Toolbar.Size = new System.Drawing.Size(1260, 617);
            this.DomainAssistant_Toolbar.TabIndex = 7;
            // 
            // Little_ico
            // 
            this.Little_ico.ContextMenuStrip = this.Menu_ico;
            this.Little_ico.Icon = ((System.Drawing.Icon)(resources.GetObject("Little_ico.Icon")));
            this.Little_ico.Text = "小助手";
            this.Little_ico.Visible = true;
            this.Little_ico.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Little_ico_MouseDoubleClick);
            // 
            // Menu_ico
            // 
            this.Menu_ico.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Close_Menu_ico});
            this.Menu_ico.Name = "Menu_ico";
            this.Menu_ico.Size = new System.Drawing.Size(137, 26);
            // 
            // Close_Menu_ico
            // 
            this.Close_Menu_ico.Name = "Close_Menu_ico";
            this.Close_Menu_ico.Size = new System.Drawing.Size(136, 22);
            this.Close_Menu_ico.Text = "关闭小助手";
            this.Close_Menu_ico.Click += new System.EventHandler(this.Close_Menu_ico_Click);
            // 
            // Show_Query_Num_timer500
            // 
            this.Show_Query_Num_timer500.Enabled = true;
            this.Show_Query_Num_timer500.Interval = 500;
            this.Show_Query_Num_timer500.Tick += new System.EventHandler(this.Show_Query_Num_timer500_Tick);
            // 
            // Reload_number_people
            // 
            this.Reload_number_people.Interval = 60000;
            this.Reload_number_people.Tick += new System.EventHandler(this.Reload_number_people_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 641);
            this.Controls.Add(this.DomainAssistant_Toolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "小工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Replace_thing.ResumeLayout(false);
            this.Replace_thing.PerformLayout();
            this.Domain_screening.ResumeLayout(false);
            this.Domain_screening.PerformLayout();
            this.Set_condition_groupBox.ResumeLayout(false);
            this.Set_condition_groupBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.DomainAssistant_Toolbar.ResumeLayout(false);
            this.Menu_ico.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Replace_thing;
        private System.Windows.Forms.TabPage Domain_screening;
        private System.Windows.Forms.DataGridView DataView;
        private System.Windows.Forms.Label Out_label;
        private System.Windows.Forms.Label Title_Matched_Domains_1;
        private System.Windows.Forms.TextBox Out_box;
        private System.Windows.Forms.Label Title_Matched_Domains_2;
        private System.Windows.Forms.TabControl DomainAssistant_Toolbar;
        private System.Windows.Forms.Button Filter_domain_button;
        private System.Windows.Forms.ComboBox Key_list;
        private System.Windows.Forms.NotifyIcon Little_ico;
        private System.Windows.Forms.ContextMenuStrip Menu_ico;
        private System.Windows.Forms.ToolStripMenuItem Close_Menu_ico;
        private System.Windows.Forms.Label Set_Threads_Tile;
        private System.Windows.Forms.ComboBox Set_Threads_Num;
        private System.Windows.Forms.Label Queried_site_num_lable;
        private System.Windows.Forms.Label All_site_num_show;
        private System.Windows.Forms.Label Query_show_slash;
        private System.Windows.Forms.Timer Show_Query_Num_timer500;
        private System.Windows.Forms.RichTextBox Domain_Box;
        private System.Windows.Forms.Button out_data_excel;
        private System.Windows.Forms.Button replace_go;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox Replace_out;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox Domain_list_box;
        private System.Windows.Forms.TextBox Model_S;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox Set_cond_sexy;
        private System.Windows.Forms.CheckBox Set_cond_bet;
        private System.Windows.Forms.CheckBox Set_cond_language;
        private System.Windows.Forms.CheckBox Set_cond_null;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox Set_condition_groupBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Filter_domain_web_button;
        private System.Windows.Forms.Label cookie_lable;
        private System.Windows.Forms.RichTextBox cookie_box;
        private System.Windows.Forms.Button Reload_cookie;
        private System.Windows.Forms.Timer Reload_number_people;
        private System.Windows.Forms.TextBox Query_interval_Textbox;
        private System.Windows.Forms.Label Query_interval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Web_Title;
        private System.Windows.Forms.DataGridViewLinkColumn domain_url;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data_Sources;
        private System.Windows.Forms.CheckBox update_data_checkBox;
        private System.Windows.Forms.Button WriteCookiefile;
    }
}