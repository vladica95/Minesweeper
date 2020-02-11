namespace Minesweeper2
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
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.maniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaIgraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zavrsiIgruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.konfiguracijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sacuvajIgruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucitajIgruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucitajKonfiguracijuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_vreme = new System.Windows.Forms.Label();
            this.la_brMina = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(11, 61);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(250, 250);
            this.panel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maniToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(273, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // maniToolStripMenuItem
            // 
            this.maniToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaIgraToolStripMenuItem,
            this.zavrsiIgruToolStripMenuItem,
            this.toolStripSeparator1,
            this.konfiguracijaToolStripMenuItem,
            this.sacuvajIgruToolStripMenuItem,
            this.ucitajIgruToolStripMenuItem,
            this.ucitajKonfiguracijuToolStripMenuItem});
            this.maniToolStripMenuItem.Name = "maniToolStripMenuItem";
            this.maniToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.maniToolStripMenuItem.Text = "Opcije";
            // 
            // novaIgraToolStripMenuItem
            // 
            this.novaIgraToolStripMenuItem.Name = "novaIgraToolStripMenuItem";
            this.novaIgraToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.novaIgraToolStripMenuItem.Text = "Nova igra";
            this.novaIgraToolStripMenuItem.Click += new System.EventHandler(this.novaIgraToolStripMenuItem_Click);
            // 
            // zavrsiIgruToolStripMenuItem
            // 
            this.zavrsiIgruToolStripMenuItem.Name = "zavrsiIgruToolStripMenuItem";
            this.zavrsiIgruToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.zavrsiIgruToolStripMenuItem.Text = "Zavrsi igru";
            this.zavrsiIgruToolStripMenuItem.Click += new System.EventHandler(this.zavrsiIgruToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // konfiguracijaToolStripMenuItem
            // 
            this.konfiguracijaToolStripMenuItem.Name = "konfiguracijaToolStripMenuItem";
            this.konfiguracijaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.konfiguracijaToolStripMenuItem.Text = "Konfiguracija";
            this.konfiguracijaToolStripMenuItem.Click += new System.EventHandler(this.konfiguracijaToolStripMenuItem_Click);
            // 
            // sacuvajIgruToolStripMenuItem
            // 
            this.sacuvajIgruToolStripMenuItem.Name = "sacuvajIgruToolStripMenuItem";
            this.sacuvajIgruToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.sacuvajIgruToolStripMenuItem.Text = "Sacuvaj igru";
            this.sacuvajIgruToolStripMenuItem.Click += new System.EventHandler(this.sacuvajIgruToolStripMenuItem_Click);
            // 
            // ucitajIgruToolStripMenuItem
            // 
            this.ucitajIgruToolStripMenuItem.Name = "ucitajIgruToolStripMenuItem";
            this.ucitajIgruToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.ucitajIgruToolStripMenuItem.Text = "Nastavi igru";
            this.ucitajIgruToolStripMenuItem.Click += new System.EventHandler(this.ucitajIgruToolStripMenuItem_Click);
            // 
            // ucitajKonfiguracijuToolStripMenuItem
            // 
            this.ucitajKonfiguracijuToolStripMenuItem.Name = "ucitajKonfiguracijuToolStripMenuItem";
            this.ucitajKonfiguracijuToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.ucitajKonfiguracijuToolStripMenuItem.Text = "Ucitaj konfiguraciju";
            this.ucitajKonfiguracijuToolStripMenuItem.Click += new System.EventHandler(this.ucitajKonfiguracijuToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vreme:";
            // 
            // lab_vreme
            // 
            this.lab_vreme.AutoSize = true;
            this.lab_vreme.Location = new System.Drawing.Point(55, 42);
            this.lab_vreme.Name = "lab_vreme";
            this.lab_vreme.Size = new System.Drawing.Size(22, 13);
            this.lab_vreme.TabIndex = 3;
            this.lab_vreme.Text = "0:0";
            // 
            // la_brMina
            // 
            this.la_brMina.AutoSize = true;
            this.la_brMina.Location = new System.Drawing.Point(224, 42);
            this.la_brMina.Name = "la_brMina";
            this.la_brMina.Size = new System.Drawing.Size(16, 13);
            this.la_brMina.TabIndex = 5;
            this.la_brMina.Text = "br";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Broj mina:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(106, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = ": )";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.vreme);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 322);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.la_brMina);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lab_vreme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem maniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaIgraToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_vreme;
        private System.Windows.Forms.Label la_brMina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem konfiguracijaToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem zavrsiIgruToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sacuvajIgruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ucitajIgruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ucitajKonfiguracijuToolStripMenuItem;
    }
}

