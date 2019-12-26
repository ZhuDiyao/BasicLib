namespace 测试启动项
{
    partial class 打印模型窗体
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(260, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 1500);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(761, 1088);
            this.panel2.TabIndex = 1;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button13.Location = new System.Drawing.Point(60, 307);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(457, 56);
            this.button13.TabIndex = 27;
            this.button13.Text = "打印";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Location = new System.Drawing.Point(25, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(230, 86);
            this.label16.TabIndex = 7;
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(216, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 39);
            this.label8.TabIndex = 6;
            this.label8.Text = "内右下角";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(25, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 39);
            this.label7.TabIndex = 5;
            this.label7.Text = "内左下角";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(216, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 39);
            this.label6.TabIndex = 4;
            this.label6.Text = "内右上角";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(-1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 39);
            this.label5.TabIndex = 3;
            this.label5.Text = "内左上角";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 打印模型窗体
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 1061);
            this.Controls.Add(this.panel1);
            this.Name = "打印模型窗体";
            this.Text = "打印模型窗体";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button13;
    }
}