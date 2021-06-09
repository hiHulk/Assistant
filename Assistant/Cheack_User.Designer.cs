namespace Assistant
{
    partial class Cheack_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cheack_User));
            this.cheack_user_title_pwd = new System.Windows.Forms.Label();
            this.cheack_user_pwd_box = new System.Windows.Forms.TextBox();
            this.cheack_user_but_pwd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cheack_user_title_pwd
            // 
            this.cheack_user_title_pwd.AutoSize = true;
            this.cheack_user_title_pwd.Location = new System.Drawing.Point(62, 75);
            this.cheack_user_title_pwd.Name = "cheack_user_title_pwd";
            this.cheack_user_title_pwd.Size = new System.Drawing.Size(35, 12);
            this.cheack_user_title_pwd.TabIndex = 0;
            this.cheack_user_title_pwd.Text = "密 码";
            // 
            // cheack_user_pwd_box
            // 
            this.cheack_user_pwd_box.Location = new System.Drawing.Point(103, 72);
            this.cheack_user_pwd_box.Name = "cheack_user_pwd_box";
            this.cheack_user_pwd_box.PasswordChar = '*';
            this.cheack_user_pwd_box.Size = new System.Drawing.Size(258, 21);
            this.cheack_user_pwd_box.TabIndex = 1;
            this.cheack_user_pwd_box.Text = "8IxdPEYyIOC2BFP2";
            // 
            // cheack_user_but_pwd
            // 
            this.cheack_user_but_pwd.Location = new System.Drawing.Point(368, 72);
            this.cheack_user_but_pwd.Name = "cheack_user_but_pwd";
            this.cheack_user_but_pwd.Size = new System.Drawing.Size(75, 23);
            this.cheack_user_but_pwd.TabIndex = 2;
            this.cheack_user_but_pwd.Text = "验证";
            this.cheack_user_but_pwd.UseVisualStyleBackColor = true;
            this.cheack_user_but_pwd.Click += new System.EventHandler(this.cheack_user_but_pwd_Click);
            // 
            // Cheack_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 297);
            this.Controls.Add(this.cheack_user_but_pwd);
            this.Controls.Add(this.cheack_user_pwd_box);
            this.Controls.Add(this.cheack_user_title_pwd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Cheack_User";
            this.Text = "用户验证";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cheack_User_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cheack_user_title_pwd;
        private System.Windows.Forms.TextBox cheack_user_pwd_box;
        private System.Windows.Forms.Button cheack_user_but_pwd;
    }
}