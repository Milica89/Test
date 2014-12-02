namespace SlagalicaKvadrati
{
    partial class Slagalica
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label = new System.Windows.Forms.Label();
            this.RestartDugme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(194, 39);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 35);
            this.label.TabIndex = 0;
            // 
            // RestartDugme
            // 
            this.RestartDugme.Location = new System.Drawing.Point(518, 377);
            this.RestartDugme.Name = "RestartDugme";
            this.RestartDugme.Size = new System.Drawing.Size(75, 23);
            this.RestartDugme.TabIndex = 1;
            this.RestartDugme.Text = "Restart";
            this.RestartDugme.UseVisualStyleBackColor = true;
            this.RestartDugme.Click += new System.EventHandler(this.RestartDugme_Click);
            // 
            // Slagalica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 477);
            this.Controls.Add(this.RestartDugme);
            this.Controls.Add(this.label);
            this.DoubleBuffered = true;
            this.Name = "Slagalica";
            this.Text = "Slagalica";
            this.Load += new System.EventHandler(this.Slagalica_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Slagalica_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Slagalica_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Slagalica_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button RestartDugme;
    }
}

