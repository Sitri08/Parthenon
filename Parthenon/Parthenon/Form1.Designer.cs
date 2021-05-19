namespace Parthenon
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.învațăMaiMulteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeazățiCunoștințeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contulMeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1093, 39);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom;
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1078, 34);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Gluma/fun fact";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.învațăMaiMulteToolStripMenuItem,
            this.testeazățiCunoștințeleToolStripMenuItem,
            this.contulMeuToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 680);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1093, 45);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(83, 41);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // învațăMaiMulteToolStripMenuItem
            // 
            this.învațăMaiMulteToolStripMenuItem.Name = "învațăMaiMulteToolStripMenuItem";
            this.învațăMaiMulteToolStripMenuItem.Size = new System.Drawing.Size(227, 41);
            this.învațăMaiMulteToolStripMenuItem.Text = "Învață mai multe";
            // 
            // testeazățiCunoștințeleToolStripMenuItem
            // 
            this.testeazățiCunoștințeleToolStripMenuItem.Name = "testeazățiCunoștințeleToolStripMenuItem";
            this.testeazățiCunoștințeleToolStripMenuItem.Size = new System.Drawing.Size(306, 41);
            this.testeazățiCunoștințeleToolStripMenuItem.Text = "Testează-ți cunoștințele";
            // 
            // contulMeuToolStripMenuItem
            // 
            this.contulMeuToolStripMenuItem.Name = "contulMeuToolStripMenuItem";
            this.contulMeuToolStripMenuItem.Size = new System.Drawing.Size(167, 41);
            this.contulMeuToolStripMenuItem.Text = "Contul meu";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 725);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "formTemplate";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem învațăMaiMulteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testeazățiCunoștințeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contulMeuToolStripMenuItem;
    }
}

