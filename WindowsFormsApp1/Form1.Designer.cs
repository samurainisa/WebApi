namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnAthletes = new System.Windows.Forms.Button();
            this.btnTreners = new System.Windows.Forms.Button();
            this.btnSportPlaces = new System.Windows.Forms.Button();
            this.btnSport = new System.Windows.Forms.Button();
            this.btnClub = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnAthletes);
            this.panelMenu.Controls.Add(this.btnTreners);
            this.panelMenu.Controls.Add(this.btnSportPlaces);
            this.panelMenu.Controls.Add(this.btnSport);
            this.panelMenu.Controls.Add(this.btnClub);
            this.panelMenu.Controls.Add(this.panelLogo);
            resources.ApplyResources(this.panelMenu, "panelMenu");
            this.panelMenu.Name = "panelMenu";
            // 
            // btnAthletes
            // 
            resources.ApplyResources(this.btnAthletes, "btnAthletes");
            this.btnAthletes.FlatAppearance.BorderSize = 0;
            this.btnAthletes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAthletes.Name = "btnAthletes";
            this.btnAthletes.UseVisualStyleBackColor = true;
            this.btnAthletes.Click += new System.EventHandler(this.btnAthletes_Click);
            // 
            // btnTreners
            // 
            resources.ApplyResources(this.btnTreners, "btnTreners");
            this.btnTreners.FlatAppearance.BorderSize = 0;
            this.btnTreners.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTreners.Name = "btnTreners";
            this.btnTreners.UseVisualStyleBackColor = true;
            this.btnTreners.Click += new System.EventHandler(this.btnTreners_Click);
            // 
            // btnSportPlaces
            // 
            resources.ApplyResources(this.btnSportPlaces, "btnSportPlaces");
            this.btnSportPlaces.FlatAppearance.BorderSize = 0;
            this.btnSportPlaces.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSportPlaces.Name = "btnSportPlaces";
            this.btnSportPlaces.UseVisualStyleBackColor = true;
            this.btnSportPlaces.Click += new System.EventHandler(this.btnSportPlaces_Click);
            // 
            // btnSport
            // 
            resources.ApplyResources(this.btnSport, "btnSport");
            this.btnSport.FlatAppearance.BorderSize = 0;
            this.btnSport.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSport.Name = "btnSport";
            this.btnSport.UseVisualStyleBackColor = true;
            this.btnSport.Click += new System.EventHandler(this.btnSport_Click);
            // 
            // btnClub
            // 
            resources.ApplyResources(this.btnClub, "btnClub");
            this.btnClub.FlatAppearance.BorderSize = 0;
            this.btnClub.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnClub.Name = "btnClub";
            this.btnClub.UseVisualStyleBackColor = true;
            this.btnClub.Click += new System.EventHandler(this.btnClub_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.label2);
            this.panelLogo.Controls.Add(this.label1);
            resources.ApplyResources(this.panelLogo, "panelLogo");
            this.panelLogo.Name = "panelLogo";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.btnCloseChildForm);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            resources.ApplyResources(this.panelTitleBar, "panelTitleBar");
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            // 
            // panelDesktopPanel
            // 
            resources.ApplyResources(this.panelDesktopPanel, "panelDesktopPanel");
            this.panelDesktopPanel.Name = "panelDesktopPanel";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCloseChildForm
            // 
            resources.ApplyResources(this.btnCloseChildForm, "btnCloseChildForm");
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.Image = global::WindowsFormsApp1.Properties.Resources.cross_out__2_;
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ControlBox = false;
            this.Controls.Add(this.panelDesktopPanel);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnClub;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnAthletes;
        private System.Windows.Forms.Button btnTreners;
        private System.Windows.Forms.Button btnSportPlaces;
        private System.Windows.Forms.Button btnSport;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDesktopPanel;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.Button btnClose;
    }
}

