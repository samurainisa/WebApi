namespace WebClient.Forms
{
    partial class UserForm
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
            this.dataControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.IdCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameSportSoor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Capacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.City = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Country = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CoverType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.разлогинитьсяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавлениеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.спортсменToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клубToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спортивноеСооружениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видСпортаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тренерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dataControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataControl
            // 
            this.dataControl.Controls.Add(this.tabPage1);
            this.dataControl.Controls.Add(this.tabPage2);
            this.dataControl.Controls.Add(this.tabPage3);
            this.dataControl.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.dataControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataControl.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dataControl.ItemSize = new System.Drawing.Size(60, 25);
            this.dataControl.Location = new System.Drawing.Point(41, 189);
            this.dataControl.Multiline = true;
            this.dataControl.Name = "dataControl";
            this.dataControl.RightToLeftLayout = true;
            this.dataControl.SelectedIndex = 0;
            this.dataControl.Size = new System.Drawing.Size(772, 365);
            this.dataControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(764, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Клубы";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdCol,
            this.NameCol});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(-4, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(772, 334);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // IdCol
            // 
            this.IdCol.Text = "ID";
            this.IdCol.Width = 100;
            // 
            // NameCol
            // 
            this.NameCol.Text = "Name";
            this.NameCol.Width = 250;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.ForeColor = System.Drawing.Color.Black;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(764, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Виды спорта";
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(-4, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(772, 334);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 250;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pictureBox4);
            this.tabPage3.Controls.Add(this.listView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(764, 332);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Спорт.сооружения";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.NameSportSoor,
            this.Capacity,
            this.Address,
            this.City,
            this.Country,
            this.CoverType});
            this.listView3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(-4, 0);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(772, 334);
            this.listView3.TabIndex = 2;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "ID";
            this.Id.Width = 50;
            // 
            // NameSportSoor
            // 
            this.NameSportSoor.Text = "Name";
            this.NameSportSoor.Width = 180;
            // 
            // Capacity
            // 
            this.Capacity.Text = "Capacity";
            // 
            // Address
            // 
            this.Address.Text = "Address";
            this.Address.Width = 120;
            // 
            // City
            // 
            this.City.Text = "City";
            this.City.Width = 100;
            // 
            // Country
            // 
            this.Country.Text = "Country";
            this.Country.Width = 100;
            // 
            // CoverType
            // 
            this.CoverType.Text = "CoverType";
            this.CoverType.Width = 100;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEmail.Location = new System.Drawing.Point(38, 148);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 18);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRole.Location = new System.Drawing.Point(36, 106);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(68, 29);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Role";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.menuStrip1.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.добавлениеToolStripMenuItem,
            this.добавлениеToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(849, 27);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.разлогинитьсяToolStripMenuItem});
            this.менюToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(57, 23);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // разлогинитьсяToolStripMenuItem
            // 
            this.разлогинитьсяToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.разлогинитьсяToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.разлогинитьсяToolStripMenuItem.Name = "разлогинитьсяToolStripMenuItem";
            this.разлогинитьсяToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.разлогинитьсяToolStripMenuItem.Text = "Логаут";
            this.разлогинитьсяToolStripMenuItem.Click += new System.EventHandler(this.разлогинитьсяToolStripMenuItem_Click);
            // 
            // добавлениеToolStripMenuItem
            // 
            this.добавлениеToolStripMenuItem.Name = "добавлениеToolStripMenuItem";
            this.добавлениеToolStripMenuItem.Size = new System.Drawing.Size(12, 23);
            // 
            // добавлениеToolStripMenuItem1
            // 
            this.добавлениеToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.спортсменToolStripMenuItem,
            this.клубToolStripMenuItem,
            this.спортивноеСооружениеToolStripMenuItem,
            this.видСпортаToolStripMenuItem,
            this.тренерToolStripMenuItem});
            this.добавлениеToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.добавлениеToolStripMenuItem1.Name = "добавлениеToolStripMenuItem1";
            this.добавлениеToolStripMenuItem1.Size = new System.Drawing.Size(111, 23);
            this.добавлениеToolStripMenuItem1.Text = "Добавление";
            // 
            // спортсменToolStripMenuItem
            // 
            this.спортсменToolStripMenuItem.Name = "спортсменToolStripMenuItem";
            this.спортсменToolStripMenuItem.Size = new System.Drawing.Size(267, 24);
            this.спортсменToolStripMenuItem.Text = "Спортсмен";
            // 
            // клубToolStripMenuItem
            // 
            this.клубToolStripMenuItem.Name = "клубToolStripMenuItem";
            this.клубToolStripMenuItem.Size = new System.Drawing.Size(267, 24);
            this.клубToolStripMenuItem.Text = "Клуб";
            this.клубToolStripMenuItem.Click += new System.EventHandler(this.клубToolStripMenuItem_Click);
            // 
            // спортивноеСооружениеToolStripMenuItem
            // 
            this.спортивноеСооружениеToolStripMenuItem.Name = "спортивноеСооружениеToolStripMenuItem";
            this.спортивноеСооружениеToolStripMenuItem.Size = new System.Drawing.Size(267, 24);
            this.спортивноеСооружениеToolStripMenuItem.Text = "Спортивное сооружение";
            this.спортивноеСооружениеToolStripMenuItem.Click += new System.EventHandler(this.спортивноеСооружениеToolStripMenuItem_Click);
            // 
            // видСпортаToolStripMenuItem
            // 
            this.видСпортаToolStripMenuItem.Name = "видСпортаToolStripMenuItem";
            this.видСпортаToolStripMenuItem.Size = new System.Drawing.Size(267, 24);
            this.видСпортаToolStripMenuItem.Text = "Вид спорта";
            this.видСпортаToolStripMenuItem.Click += new System.EventHandler(this.видСпортаToolStripMenuItem_Click);
            // 
            // тренерToolStripMenuItem
            // 
            this.тренерToolStripMenuItem.Name = "тренерToolStripMenuItem";
            this.тренерToolStripMenuItem.Size = new System.Drawing.Size(267, 24);
            this.тренерToolStripMenuItem.Text = "Тренер";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.button3.FlatAppearance.BorderSize = 2;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(6, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 33);
            this.button3.TabIndex = 0;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(127, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(33, 33);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Location = new System.Drawing.Point(644, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(169, 69);
            this.panel3.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.pictureBox2.Image = global::WebClient.Properties.Resources.free_icon_refresh_4701365;
            this.pictureBox2.Location = new System.Drawing.Point(706, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.pictureBox1.BackgroundImage = global::WebClient.Properties.Resources.free_icon_refresh_4701365;
            this.pictureBox1.Image = global::WebClient.Properties.Resources.free_icon_refresh_4701365;
            this.pictureBox1.Location = new System.Drawing.Point(706, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.pictureBox4.Image = global::WebClient.Properties.Resources.free_icon_refresh_4701365;
            this.pictureBox4.Location = new System.Drawing.Point(707, 27);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 33);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(849, 587);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.dataControl);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.dataControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TabControl dataControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader IdCol;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader NameSportSoor;
        private System.Windows.Forms.ColumnHeader Capacity;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader City;
        private System.Windows.Forms.ColumnHeader Country;
        private System.Windows.Forms.ColumnHeader CoverType;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem разлогинитьсяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавлениеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem спортсменToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клубToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спортивноеСооружениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видСпортаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тренерToolStripMenuItem;
    }
}