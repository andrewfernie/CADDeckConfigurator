namespace ucGeneral
{
    partial class GeneralConfigUserControl
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

        #region Component Designer generated code

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
            this.label5 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tbMenuColorSample = new System.Windows.Forms.TextBox();
            this.tbFunctionColorSample = new System.Windows.Forms.TextBox();
            this.tbLatchColorSample = new System.Windows.Forms.TextBox();
            this.tbBackgroundColorSample = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "General CADDeck Configuration";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Menu Button Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Function Button Color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Latch Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Background Color";
            // 
            // tbMenuColorSample
            // 
            this.tbMenuColorSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMenuColorSample.Location = new System.Drawing.Point(154, 81);
            this.tbMenuColorSample.Name = "tbMenuColorSample";
            this.tbMenuColorSample.Size = new System.Drawing.Size(75, 13);
            this.tbMenuColorSample.TabIndex = 8;
            this.tbMenuColorSample.DoubleClick += new System.EventHandler(this.tbMenuColorSample_DoubleClick);
            // 
            // tbFunctionColorSample
            // 
            this.tbFunctionColorSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbFunctionColorSample.Location = new System.Drawing.Point(154, 104);
            this.tbFunctionColorSample.Name = "tbFunctionColorSample";
            this.tbFunctionColorSample.Size = new System.Drawing.Size(75, 13);
            this.tbFunctionColorSample.TabIndex = 9;
            this.tbFunctionColorSample.Click += new System.EventHandler(this.tbFunctionColorSample_Click);
            this.tbFunctionColorSample.TextChanged += new System.EventHandler(this.tbFunctionColorSample_TextChanged);
            // 
            // tbLatchColorSample
            // 
            this.tbLatchColorSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLatchColorSample.Location = new System.Drawing.Point(154, 130);
            this.tbLatchColorSample.Name = "tbLatchColorSample";
            this.tbLatchColorSample.Size = new System.Drawing.Size(75, 13);
            this.tbLatchColorSample.TabIndex = 10;
            this.tbLatchColorSample.Click += new System.EventHandler(this.tbLatchColorSample_Click);
            // 
            // tbBackgroundColorSample
            // 
            this.tbBackgroundColorSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBackgroundColorSample.Location = new System.Drawing.Point(154, 156);
            this.tbBackgroundColorSample.Name = "tbBackgroundColorSample";
            this.tbBackgroundColorSample.Size = new System.Drawing.Size(75, 13);
            this.tbBackgroundColorSample.TabIndex = 11;
            this.tbBackgroundColorSample.Click += new System.EventHandler(this.tbBackgroundColorSample_Click);
            // 
            // ucGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbBackgroundColorSample);
            this.Controls.Add(this.tbLatchColorSample);
            this.Controls.Add(this.tbFunctionColorSample);
            this.Controls.Add(this.tbMenuColorSample);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucGeneral";
            this.Size = new System.Drawing.Size(800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox tbMenuColorSample;
        private System.Windows.Forms.TextBox tbFunctionColorSample;
        private System.Windows.Forms.TextBox tbLatchColorSample;
        private System.Windows.Forms.TextBox tbBackgroundColorSample;
    }
}
