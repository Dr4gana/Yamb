namespace Yamb
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
            this.timerTbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timerTbox
            // 
            this.timerTbox.BackColor = System.Drawing.SystemColors.Control;
            this.timerTbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timerTbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerTbox.Location = new System.Drawing.Point(313, 2);
            this.timerTbox.Name = "timerTbox";
            this.timerTbox.ReadOnly = true;
            this.timerTbox.Size = new System.Drawing.Size(60, 15);
            this.timerTbox.TabIndex = 0;
            this.timerTbox.TabStop = false;
            this.timerTbox.Text = "00:00:00";
            this.timerTbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 516);
            this.Controls.Add(this.timerTbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yamb";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox timerTbox;
    }
}

