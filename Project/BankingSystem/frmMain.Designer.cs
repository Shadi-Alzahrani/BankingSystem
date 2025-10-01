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
            this.panelDragDrop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pMainContent = new System.Windows.Forms.Panel();
            this.DropDownTimer = new System.Windows.Forms.Timer(this.components);
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnTransfare = new System.Windows.Forms.Button();
            this.btnWithDraw = new System.Windows.Forms.Button();
            this.btnDeposite = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flpSideBar.SuspendLayout();
            this.pLogo.SuspendLayout();
            this.panelDragDrop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // flpSideBar
            // 
            this.flpSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.flpSideBar.Controls.Add(this.pLogo);
            this.flpSideBar.Controls.Add(this.btnDashboard);
            this.flpSideBar.Controls.Add(this.panelDragDrop);
            this.flpSideBar.Controls.Add(this.button1);
            this.flpSideBar.Controls.Add(this.button2);
            this.flpSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpSideBar.Location = new System.Drawing.Point(0, 0);
            this.flpSideBar.Margin = new System.Windows.Forms.Padding(2);
            this.flpSideBar.Name = "flpSideBar";
            this.flpSideBar.Size = new System.Drawing.Size(187, 700);
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
            this.pLogo.Size = new System.Drawing.Size(184, 92);
            this.pLogo.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pbTitle);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(187, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 94);
            this.panel1.TabIndex = 1;
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
            this.pMainContent.Location = new System.Drawing.Point(187, 94);
            this.pMainContent.Margin = new System.Windows.Forms.Padding(2);
            this.pMainContent.Name = "pMainContent";
            this.pMainContent.Size = new System.Drawing.Size(1073, 606);
            this.pMainContent.TabIndex = 2;
            this.pMainContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pMainContent_Paint);
            // 
            // DropDownTimer
            // 
            this.DropDownTimer.Interval = 10;
            this.DropDownTimer.Tick += new System.EventHandler(this.DropDownTimer_Tick);
            // 
            // pbTitle
            // 
            this.pbTitle.Image = global::BankingSystem.Properties.Resources.dashboard;
            this.pbTitle.Location = new System.Drawing.Point(519, 12);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(36, 39);
            this.pbTitle.TabIndex = 1;
            this.pbTitle.TabStop = false;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(58, 17);
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
            // btnTransactions
            // 
            this.btnTransactions.FlatAppearance.BorderSize = 0;
            this.btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactions.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTransactions.Image = global::BankingSystem.Properties.Resources.icons8_down_button_32;
            this.btnTransactions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTransactions.Location = new System.Drawing.Point(-5, 3);
            this.btnTransactions.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnTransactions.Size = new System.Drawing.Size(195, 52);
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
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(2, 219);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(195, 50);
            this.button1.TabIndex = 7;
            this.button1.Text = "       Reports";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(2, 273);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(195, 50);
            this.button2.TabIndex = 8;
            this.button2.Text = "       sttengs";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
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
            this.panelDragDrop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pbTitle;
    }
}