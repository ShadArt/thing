namespace BotBaDoshka
{
    partial class BotBaDoshkaForm
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
            this.RunConsole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RunConsole
            // 
            this.RunConsole.Location = new System.Drawing.Point(12, 12);
            this.RunConsole.Name = "RunConsole";
            this.RunConsole.Size = new System.Drawing.Size(258, 29);
            this.RunConsole.TabIndex = 0;
            this.RunConsole.Text = "Run";
            this.RunConsole.UseVisualStyleBackColor = true;
            this.RunConsole.Click += new System.EventHandler(this.RunConsole_Click);
            // 
            // BotBaDoshkaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 53);
            this.Controls.Add(this.RunConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 100);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 100);
            this.Name = "BotBaDoshkaForm";
            this.ShowIcon = false;
            this.Text = "BotBaDoshka v.1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RunConsole;
    }
}

