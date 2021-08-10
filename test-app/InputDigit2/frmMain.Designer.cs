namespace InputDigit2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.idcFracSign = new InputDigit2.InputDigitControl();
            this.idcFracNoSign = new InputDigit2.InputDigitControl();
            this.idcIntegerNum = new InputDigit2.InputDigitControl();
            this.idcNaturalNum = new InputDigit2.InputDigitControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Целые без знака:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Целые со знаком:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дробные без знака:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дробные со знаком:";
            // 
            // idcFracSign
            // 
            this.idcFracSign.Fractional = true;
            this.idcFracSign.Location = new System.Drawing.Point(118, 88);
            this.idcFracSign.Name = "idcFracSign";
            this.idcFracSign.Negative = true;
            this.idcFracSign.Separator = ',';
            this.idcFracSign.Size = new System.Drawing.Size(227, 20);
            this.idcFracSign.TabIndex = 7;
            // 
            // idcFracNoSign
            // 
            this.idcFracNoSign.Fractional = true;
            this.idcFracNoSign.Location = new System.Drawing.Point(118, 62);
            this.idcFracNoSign.Name = "idcFracNoSign";
            this.idcFracNoSign.Separator = ',';
            this.idcFracNoSign.Size = new System.Drawing.Size(227, 20);
            this.idcFracNoSign.TabIndex = 5;
            // 
            // idcIntegerNum
            // 
            this.idcIntegerNum.Location = new System.Drawing.Point(118, 36);
            this.idcIntegerNum.Name = "idcIntegerNum";
            this.idcIntegerNum.Negative = true;
            this.idcIntegerNum.Size = new System.Drawing.Size(227, 20);
            this.idcIntegerNum.TabIndex = 3;
            // 
            // idcNaturalNum
            // 
            this.idcNaturalNum.Location = new System.Drawing.Point(118, 10);
            this.idcNaturalNum.Name = "idcNaturalNum";
            this.idcNaturalNum.Size = new System.Drawing.Size(227, 20);
            this.idcNaturalNum.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 117);
            this.Controls.Add(this.idcFracSign);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.idcFracNoSign);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.idcIntegerNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idcNaturalNum);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputDigitControl Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private InputDigitControl idcNaturalNum;
        private InputDigitControl idcIntegerNum;
        private System.Windows.Forms.Label label2;
        private InputDigitControl idcFracNoSign;
        private System.Windows.Forms.Label label3;
        private InputDigitControl idcFracSign;
        private System.Windows.Forms.Label label4;

    }
}

