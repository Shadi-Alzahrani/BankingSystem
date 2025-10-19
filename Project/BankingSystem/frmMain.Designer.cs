namespace BankingSystem
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.flpSideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.pLogo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.panelDragDrop = new System.Windows.Forms.Panel();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnTransfare = new System.Windows.Forms.Button();
            this.btnWithDraw = new System.Windows.Forms.Button();
            this.btnDeposite = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.ClientMangmentPanel = new System.Windows.Forms.Panel();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnClientMangments = new System.Windows.Forms.Button();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.btnAdminDashbourd = new System.Windows.Forms.Button();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pMainContent = new System.Windows.Forms.Panel();
            this.DropDownTimer = new System.Windows.Forms.Timer(this.components);
            this.ClientMangmentTimer = new System.Windows.Forms.Timer(this.components);
            this.btnManageAccounts = new System.Windows.Forms.Button();
            this.flpSideBar.SuspendLayout();
            this.pLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panelDragDrop.SuspendLayout();
            this.ClientMangmentPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // flpSideBar
            // 
            this.flpSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.flpSideBar.Controls.Add(this.pLogo);
            this.flpSideBar.Controls.Add(this.btnDashboard);
            this.flpSideBar.Controls.Add(this.panelDragDrop);
            this.flpSideBar.Controls.Add(this.btnReports);
            this.flpSideBar.Controls.Add(this.ClientMangmentPanel);
            this.flpSideBar.Controls.Add(this.btnAdminDashbourd);
            this.flpSideBar.Controls.Add(this.btnManageUsers);
            this.flpSideBar.Controls.Add(this.btnManageAccounts);
            this.flpSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpSideBar.Location = new System.Drawing.Point(0, 0);
            this.flpSideBar.Margin = new System.Windows.Forms.Padding(2);
            this.flpSideBar.Name = "flpSideBar";
            this.flpSideBar.Size = new System.Drawing.Size(208, 700);
            this.flpSideBar.TabIndex = 0;
            // 
            // pLogo
            // 
            this.pLogo.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pLogo.Controls.Add(this.pbLogo);
            this.pLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pLogo.Location = new System.Drawing.Point(2, 2);
            this.pLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pLogo.Name = "pLogo";
            this.pLogo.Size = new System.Drawing.Size(225, 92);
            this.pLogo.TabIndex = 1;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(61, 17);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(2);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(65, 58);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(2, 98);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(195, 50);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "       Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // panelDragDrop
            // 
            this.panelDragDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panelDragDrop.Controls.Add(this.btnTransactions);
            this.panelDragDrop.Controls.Add(this.btnTransfare);
            this.panelDragDrop.Controls.Add(this.btnWithDraw);
            this.panelDragDrop.Controls.Add(this.btnDeposite);
            this.panelDragDrop.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelDragDrop.Location = new System.Drawing.Point(3, 153);
            this.panelDragDrop.MaximumSize = new System.Drawing.Size(192, 183);
            this.panelDragDrop.MinimumSize = new System.Drawing.Size(192, 61);
            this.panelDragDrop.Name = "panelDragDrop";
            this.panelDragDrop.Size = new System.Drawing.Size(192, 61);
            this.panelDragDrop.TabIndex = 6;
            // 
            // btnTransactions
            // 
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTransactions.Image = global::BankingSystem.Properties.Resources.icons8_down_button_32;
            this.btnTransactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Location = new System.Drawing.Point(-5, -1);
            this.btnTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnTransactions.Size = new System.Drawing.Size(345, 63);
            this.btnTransactions.TabIndex = 2;
            this.btnTransactions.Text = "       Transactions";
            this.btnTransactions.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTransfare
            // 
            this.btnTransfare.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnTransfare.FlatAppearance.BorderSize = 0;
            this.btnTransfare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfare.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfare.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTransfare.Image = ((System.Drawing.Image)(resources.GetObject("btnTransfare.Image")));
            this.btnTransfare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransfare.Location = new System.Drawing.Point(0, 138);
            this.btnTransfare.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransfare.Name = "btnTransfare";
            this.btnTransfare.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnTransfare.Size = new System.Drawing.Size(195, 43);
            this.btnTransfare.TabIndex = 7;
            this.btnTransfare.Text = "       Transfare";
            this.btnTransfare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTransfare.UseVisualStyleBackColor = false;
            this.btnTransfare.Click += new System.EventHandler(this.btnTransfare_Click);
            // 
            // btnWithDraw
            // 
            this.btnWithDraw.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnWithDraw.FlatAppearance.BorderSize = 0;
            this.btnWithDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWithDraw.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnWithDraw.Image = ((System.Drawing.Image)(resources.GetObject("btnWithDraw.Image")));
            this.btnWithDraw.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWithDraw.Location = new System.Drawing.Point(0, 100);
            this.btnWithDraw.Margin = new System.Windows.Forms.Padding(2);
            this.btnWithDraw.Name = "btnWithDraw";
            this.btnWithDraw.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnWithDraw.Size = new System.Drawing.Size(195, 42);
            this.btnWithDraw.TabIndex = 6;
            this.btnWithDraw.Text = "       WithDraw";
            this.btnWithDraw.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWithDraw.UseVisualStyleBackColor = false;
            this.btnWithDraw.Click += new System.EventHandler(this.btnWithDraw_Click);
            // 
            // btnDeposite
            // 
            this.btnDeposite.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDeposite.FlatAppearance.BorderSize = 0;
            this.btnDeposite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeposite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposite.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeposite.Image = ((System.Drawing.Image)(resources.GetObject("btnDeposite.Image")));
            this.btnDeposite.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeposite.Location = new System.Drawing.Point(-1, 59);
            this.btnDeposite.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeposite.Name = "btnDeposite";
            this.btnDeposite.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnDeposite.Size = new System.Drawing.Size(195, 42);
            this.btnDeposite.TabIndex = 5;
            this.btnDeposite.Text = "       Deposite";
            this.btnDeposite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeposite.UseVisualStyleBackColor = false;
            this.btnDeposite.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnReports
            // 
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(2, 219);
            this.btnReports.Margin = new System.Windows.Forms.Padding(2);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(195, 50);
            this.btnReports.TabIndex = 7;
            this.btnReports.Text = "       Reports";
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ClientMangmentPanel
            // 
            this.ClientMangmentPanel.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientMangmentPanel.Controls.Add(this.btnChangePassword);
            this.ClientMangmentPanel.Controls.Add(this.btnClientMangments);
            this.ClientMangmentPanel.Controls.Add(this.btnEditInfo);
            this.ClientMangmentPanel.Location = new System.Drawing.Point(3, 274);
            this.ClientMangmentPanel.MaximumSize = new System.Drawing.Size(214, 164);
            this.ClientMangmentPanel.MinimumSize = new System.Drawing.Size(214, 53);
            this.ClientMangmentPanel.Name = "ClientMangmentPanel";
            this.ClientMangmentPanel.Size = new System.Drawing.Size(214, 53);
            this.ClientMangmentPanel.TabIndex = 9;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.FlatAppearance.BorderSize = 0;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChangePassword.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.Image")));
            this.btnChangePassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePassword.Location = new System.Drawing.Point(2, 106);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnChangePassword.Size = new System.Drawing.Size(214, 45);
            this.btnChangePassword.TabIndex = 9;
            this.btnChangePassword.Text = "  Change Password";
            this.btnChangePassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnClientMangments
            // 
            this.btnClientMangments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnClientMangments.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientMangments.FlatAppearance.BorderSize = 0;
            this.btnClientMangments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientMangments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientMangments.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClientMangments.Image = ((System.Drawing.Image)(resources.GetObject("btnClientMangments.Image")));
            this.btnClientMangments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientMangments.Location = new System.Drawing.Point(0, 0);
            this.btnClientMangments.Margin = new System.Windows.Forms.Padding(2);
            this.btnClientMangments.Name = "btnClientMangments";
            this.btnClientMangments.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnClientMangments.Size = new System.Drawing.Size(214, 53);
            this.btnClientMangments.TabIndex = 8;
            this.btnClientMangments.Text = " Client Management";
            this.btnClientMangments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientMangments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientMangments.UseVisualStyleBackColor = false;
            this.btnClientMangments.Click += new System.EventHandler(this.btnClientMangments_Click);
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.FlatAppearance.BorderSize = 0;
            this.btnEditInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditInfo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnEditInfo.Image")));
            this.btnEditInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditInfo.Location = new System.Drawing.Point(0, 52);
            this.btnEditInfo.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnEditInfo.Size = new System.Drawing.Size(214, 50);
            this.btnEditInfo.TabIndex = 8;
            this.btnEditInfo.Text = "      Edit Info";
            this.btnEditInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditInfo.UseVisualStyleBackColor = true;
            this.btnEditInfo.Click += new System.EventHandler(this.btnEditInfo_Click);
            // 
            // btnAdminDashbourd
            // 
            this.btnAdminDashbourd.FlatAppearance.BorderSize = 0;
            this.btnAdminDashbourd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminDashbourd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminDashbourd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdminDashbourd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdminDashbourd.Image")));
            this.btnAdminDashbourd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminDashbourd.Location = new System.Drawing.Point(2, 332);
            this.btnAdminDashbourd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdminDashbourd.Name = "btnAdminDashbourd";
            this.btnAdminDashbourd.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnAdminDashbourd.Size = new System.Drawing.Size(195, 50);
            this.btnAdminDashbourd.TabIndex = 10;
            this.btnAdminDashbourd.Text = "       Dashboard";
            this.btnAdminDashbourd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdminDashbourd.UseVisualStyleBackColor = true;
            this.btnAdminDashbourd.Click += new System.EventHandler(this.btnAdminDashbourd_Click);
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.FlatAppearance.BorderSize = 0;
            this.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUsers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnManageUsers.Image")));
            this.btnManageUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageUsers.Location = new System.Drawing.Point(2, 386);
            this.btnManageUsers.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnManageUsers.Size = new System.Drawing.Size(195, 50);
            this.btnManageUsers.TabIndex = 11;
            this.btnManageUsers.Text = "  Manage Users";
            this.btnManageUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.pbTitle);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(208, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1052, 94);
            this.panel1.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(960, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(89, 94);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pbTitle
            // 
            this.pbTitle.Image = global::BankingSystem.Properties.Resources.dashboard;
            this.pbTitle.Location = new System.Drawing.Point(519, 12);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(36, 39);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTitle.TabIndex = 1;
            this.pbTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(472, 48);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(131, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Dashboard";
            // 
            // pMainContent
            // 
            this.pMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMainContent.Location = new System.Drawing.Point(208, 94);
            this.pMainContent.Margin = new System.Windows.Forms.Padding(2);
            this.pMainContent.Name = "pMainContent";
            this.pMainContent.Size = new System.Drawing.Size(1052, 606);
            this.pMainContent.TabIndex = 2;
            this.pMainContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pMainContent_Paint);
            // 
            // DropDownTimer
            // 
            this.DropDownTimer.Interval = 10;
            this.DropDownTimer.Tick += new System.EventHandler(this.DropDownTimer_Tick);
            // 
            // ClientMangmentTimer
            // 
            this.ClientMangmentTimer.Interval = 10;
            this.ClientMangmentTimer.Tick += new System.EventHandler(this.ClientMangmentTimer_Tick);
            // 
            // btnManageAccounts
            // 
            this.btnManageAccounts.FlatAppearance.BorderSize = 0;
            this.btnManageAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageAccounts.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnManageAccounts.Image = ((System.Drawing.Image)(resources.GetObject("btnManageAccounts.Image")));
            this.btnManageAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageAccounts.Location = new System.Drawing.Point(2, 440);
            this.btnManageAccounts.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageAccounts.Name = "btnManageAccounts";
            this.btnManageAccounts.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnManageAccounts.Size = new System.Drawing.Size(206, 50);
            this.btnManageAccounts.TabIndex = 12;
            this.btnManageAccounts.Text = " Manage Accounts\r\n";
            this.btnManageAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnManageAccounts.UseVisualStyleBackColor = true;
            this.btnManageAccounts.Click += new System.EventHandler(this.btnManageAccounts_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 700);
            this.Controls.Add(this.pMainContent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpSideBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.flpSideBar.ResumeLayout(false);
            this.pLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panelDragDrop.ResumeLayout(false);
            this.ClientMangmentPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSideBar;
        private System.Windows.Forms.Panel pLogo;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pMainContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnDeposite;
        private System.Windows.Forms.Panel panelDragDrop;
        private System.Windows.Forms.Button btnTransfare;
        private System.Windows.Forms.Button btnWithDraw;
        private System.Windows.Forms.Timer DropDownTimer;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnClientMangments;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Panel ClientMangmentPanel;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnEditInfo;
        private System.Windows.Forms.Timer ClientMangmentTimer;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAdminDashbourd;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.Button btnManageAccounts;
    }
}