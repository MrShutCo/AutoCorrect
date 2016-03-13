namespace Autocorrector {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TextArea = new System.Windows.Forms.RichTextBox();
            this.ErrorCheckButton = new System.Windows.Forms.Button();
            this.TextEnterField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextArea
            // 
            this.TextArea.Location = new System.Drawing.Point(12, 12);
            this.TextArea.Name = "TextArea";
            this.TextArea.Size = new System.Drawing.Size(710, 483);
            this.TextArea.TabIndex = 0;
            this.TextArea.Text = "";
            this.TextArea.TextChanged += new System.EventHandler(this.TextArea_TextChanged);
            // 
            // ErrorCheckButton
            // 
            this.ErrorCheckButton.Location = new System.Drawing.Point(12, 527);
            this.ErrorCheckButton.Name = "ErrorCheckButton";
            this.ErrorCheckButton.Size = new System.Drawing.Size(120, 23);
            this.ErrorCheckButton.TabIndex = 1;
            this.ErrorCheckButton.Text = "Check for errors";
            this.ErrorCheckButton.UseVisualStyleBackColor = true;
            this.ErrorCheckButton.Click += new System.EventHandler(this.ErrorCheckButton_Click);
            // 
            // TextEnterField
            // 
            this.TextEnterField.Location = new System.Drawing.Point(12, 501);
            this.TextEnterField.Name = "TextEnterField";
            this.TextEnterField.Size = new System.Drawing.Size(710, 20);
            this.TextEnterField.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 711);
            this.Controls.Add(this.TextEnterField);
            this.Controls.Add(this.ErrorCheckButton);
            this.Controls.Add(this.TextArea);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextArea;
        private System.Windows.Forms.Button ErrorCheckButton;
        private System.Windows.Forms.TextBox TextEnterField;
    }
}

