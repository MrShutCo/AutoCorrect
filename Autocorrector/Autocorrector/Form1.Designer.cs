namespace Autocorrector {
    partial class form1 {
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
            this.ErrorCheckButton = new System.Windows.Forms.Button();
            this.TextEnterField = new System.Windows.Forms.TextBox();
            this.WordPredictor = new System.Windows.Forms.TextBox();
            this.guess1 = new System.Windows.Forms.Label();
            this.guess2 = new System.Windows.Forms.Label();
            this.guess3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextArea = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ErrorCheckButton
            // 
            this.ErrorCheckButton.Location = new System.Drawing.Point(12, 527);
            this.ErrorCheckButton.Name = "ErrorCheckButton";
            this.ErrorCheckButton.Size = new System.Drawing.Size(120, 23);
            this.ErrorCheckButton.TabIndex = 1;
            this.ErrorCheckButton.Text = "Check for errors";
            this.ErrorCheckButton.UseVisualStyleBackColor = true;
            this.ErrorCheckButton.Click += new System.EventHandler(this.ErrorCheckButton_Click_1);
            // 
            // TextEnterField
            // 
            this.TextEnterField.Location = new System.Drawing.Point(12, 501);
            this.TextEnterField.Name = "TextEnterField";
            this.TextEnterField.Size = new System.Drawing.Size(710, 20);
            this.TextEnterField.TabIndex = 2;
            // 
            // WordPredictor
            // 
            this.WordPredictor.Location = new System.Drawing.Point(19, 35);
            this.WordPredictor.Name = "WordPredictor";
            this.WordPredictor.Size = new System.Drawing.Size(100, 20);
            this.WordPredictor.TabIndex = 3;
            this.WordPredictor.TextChanged += new System.EventHandler(this.WordPredictor_TextChanged);
            // 
            // guess1
            // 
            this.guess1.AutoSize = true;
            this.guess1.Location = new System.Drawing.Point(16, 71);
            this.guess1.Name = "guess1";
            this.guess1.Size = new System.Drawing.Size(52, 13);
            this.guess1.TabIndex = 4;
            this.guess1.Text = "Guess 1: ";
            // 
            // guess2
            // 
            this.guess2.AutoSize = true;
            this.guess2.Location = new System.Drawing.Point(16, 95);
            this.guess2.Name = "guess2";
            this.guess2.Size = new System.Drawing.Size(49, 13);
            this.guess2.TabIndex = 5;
            this.guess2.Text = "Guess 2:";
            // 
            // guess3
            // 
            this.guess3.AutoSize = true;
            this.guess3.Location = new System.Drawing.Point(16, 121);
            this.guess3.Name = "guess3";
            this.guess3.Size = new System.Drawing.Size(52, 13);
            this.guess3.TabIndex = 6;
            this.guess3.Text = "Guess 3: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Word Predictor";
            // 
            // TextArea
            // 
            this.TextArea.Location = new System.Drawing.Point(12, 366);
            this.TextArea.Name = "TextArea";
            this.TextArea.ReadOnly = true;
            this.TextArea.Size = new System.Drawing.Size(710, 129);
            this.TextArea.TabIndex = 8;
            this.TextArea.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fake word detector";
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 711);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guess3);
            this.Controls.Add(this.guess2);
            this.Controls.Add(this.guess1);
            this.Controls.Add(this.WordPredictor);
            this.Controls.Add(this.TextEnterField);
            this.Controls.Add(this.ErrorCheckButton);
            this.Name = "form1";
            this.Text = "MrShutCo\'s Autocorrector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ErrorCheckButton;
        private System.Windows.Forms.TextBox TextEnterField;
        private System.Windows.Forms.TextBox WordPredictor;
        private System.Windows.Forms.Label guess1;
        private System.Windows.Forms.Label guess2;
        private System.Windows.Forms.Label guess3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox TextArea;
        private System.Windows.Forms.Label label2;
    }
}

