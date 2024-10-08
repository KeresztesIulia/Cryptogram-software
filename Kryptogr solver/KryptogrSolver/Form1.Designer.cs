
namespace KryptogrSolver
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
            this.kryptoTextSpace = new System.Windows.Forms.Panel();
            this.cryptoTextEnter = new System.Windows.Forms.TextBox();
            this.newText = new System.Windows.Forms.Button();
            this.bgPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // kryptoTextSpace
            // 
            this.kryptoTextSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptoTextSpace.AutoScroll = true;
            this.kryptoTextSpace.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.kryptoTextSpace.Location = new System.Drawing.Point(33, 32);
            this.kryptoTextSpace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kryptoTextSpace.Name = "kryptoTextSpace";
            this.kryptoTextSpace.Size = new System.Drawing.Size(1267, 665);
            this.kryptoTextSpace.TabIndex = 0;
            // 
            // cryptoTextEnter
            // 
            this.cryptoTextEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cryptoTextEnter.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.cryptoTextEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cryptoTextEnter.ForeColor = System.Drawing.Color.White;
            this.cryptoTextEnter.Location = new System.Drawing.Point(14, 15);
            this.cryptoTextEnter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cryptoTextEnter.Multiline = true;
            this.cryptoTextEnter.Name = "cryptoTextEnter";
            this.cryptoTextEnter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cryptoTextEnter.Size = new System.Drawing.Size(1300, 682);
            this.cryptoTextEnter.TabIndex = 0;
            // 
            // newText
            // 
            this.newText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newText.BackColor = System.Drawing.Color.Goldenrod;
            this.newText.Location = new System.Drawing.Point(518, 706);
            this.newText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.newText.Name = "newText";
            this.newText.Size = new System.Drawing.Size(306, 95);
            this.newText.TabIndex = 1;
            this.newText.Text = "Generate";
            this.newText.UseVisualStyleBackColor = false;
            this.newText.Click += new System.EventHandler(this.Cryptofy);
            // 
            // bgPanel
            // 
            this.bgPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bgPanel.AutoScroll = true;
            this.bgPanel.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.bgPanel.Location = new System.Drawing.Point(14, 15);
            this.bgPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bgPanel.Name = "bgPanel";
            this.bgPanel.Size = new System.Drawing.Size(1303, 684);
            this.bgPanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(1330, 816);
            this.Controls.Add(this.newText);
            this.Controls.Add(this.cryptoTextEnter);
            this.Controls.Add(this.kryptoTextSpace);
            this.Controls.Add(this.bgPanel);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Kryptogr solver";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InsertLetter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel kryptoTextSpace;
        private System.Windows.Forms.Button newText;
        private System.Windows.Forms.TextBox cryptoTextEnter;
        private System.Windows.Forms.Panel bgPanel;
    }
}

