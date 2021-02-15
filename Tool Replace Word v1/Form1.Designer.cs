namespace Tool_Replace_Word_v1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_browser_result = new System.Windows.Forms.Button();
            this.bt_browse_fileEdit = new System.Windows.Forms.Button();
            this.bt_browse_hosomau = new System.Windows.Forms.Button();
            this.txt_path_result = new System.Windows.Forms.TextBox();
            this.txt_path_fileEdit = new System.Windows.Forms.TextBox();
            this.txt_path_hosomau = new System.Windows.Forms.TextBox();
            this.bt_submit = new System.Windows.Forms.Button();
            this.lb_result = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_exportFileName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hồ sơ mẫu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Edit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thư mục kết quả";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bt_browser_result);
            this.panel1.Controls.Add(this.bt_browse_fileEdit);
            this.panel1.Controls.Add(this.bt_browse_hosomau);
            this.panel1.Controls.Add(this.txt_exportFileName);
            this.panel1.Controls.Add(this.txt_path_result);
            this.panel1.Controls.Add(this.txt_path_fileEdit);
            this.panel1.Controls.Add(this.txt_path_hosomau);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(25, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 171);
            this.panel1.TabIndex = 3;
            // 
            // bt_browser_result
            // 
            this.bt_browser_result.Location = new System.Drawing.Point(434, 95);
            this.bt_browser_result.Name = "bt_browser_result";
            this.bt_browser_result.Size = new System.Drawing.Size(75, 23);
            this.bt_browser_result.TabIndex = 8;
            this.bt_browser_result.Text = "...";
            this.bt_browser_result.UseVisualStyleBackColor = true;
            this.bt_browser_result.Click += new System.EventHandler(this.bt_browser_result_Click);
            // 
            // bt_browse_fileEdit
            // 
            this.bt_browse_fileEdit.Location = new System.Drawing.Point(434, 55);
            this.bt_browse_fileEdit.Name = "bt_browse_fileEdit";
            this.bt_browse_fileEdit.Size = new System.Drawing.Size(75, 23);
            this.bt_browse_fileEdit.TabIndex = 7;
            this.bt_browse_fileEdit.Text = "...";
            this.bt_browse_fileEdit.UseVisualStyleBackColor = true;
            this.bt_browse_fileEdit.Click += new System.EventHandler(this.bt_browse_fileEdit_Click);
            // 
            // bt_browse_hosomau
            // 
            this.bt_browse_hosomau.Location = new System.Drawing.Point(434, 16);
            this.bt_browse_hosomau.Name = "bt_browse_hosomau";
            this.bt_browse_hosomau.Size = new System.Drawing.Size(75, 23);
            this.bt_browse_hosomau.TabIndex = 6;
            this.bt_browse_hosomau.Text = "...";
            this.bt_browse_hosomau.UseVisualStyleBackColor = true;
            this.bt_browse_hosomau.Click += new System.EventHandler(this.bt_browse_hosomauOnClick);
            // 
            // txt_path_result
            // 
            this.txt_path_result.Location = new System.Drawing.Point(102, 97);
            this.txt_path_result.Name = "txt_path_result";
            this.txt_path_result.Size = new System.Drawing.Size(314, 20);
            this.txt_path_result.TabIndex = 5;
            // 
            // txt_path_fileEdit
            // 
            this.txt_path_fileEdit.Location = new System.Drawing.Point(102, 58);
            this.txt_path_fileEdit.Name = "txt_path_fileEdit";
            this.txt_path_fileEdit.Size = new System.Drawing.Size(314, 20);
            this.txt_path_fileEdit.TabIndex = 4;
            // 
            // txt_path_hosomau
            // 
            this.txt_path_hosomau.Location = new System.Drawing.Point(102, 16);
            this.txt_path_hosomau.Name = "txt_path_hosomau";
            this.txt_path_hosomau.Size = new System.Drawing.Size(314, 20);
            this.txt_path_hosomau.TabIndex = 3;
            // 
            // bt_submit
            // 
            this.bt_submit.Location = new System.Drawing.Point(460, 217);
            this.bt_submit.Name = "bt_submit";
            this.bt_submit.Size = new System.Drawing.Size(75, 23);
            this.bt_submit.TabIndex = 4;
            this.bt_submit.Text = "Submit";
            this.bt_submit.UseVisualStyleBackColor = true;
            this.bt_submit.Click += new System.EventHandler(this.bt_submit_Click);
            // 
            // lb_result
            // 
            this.lb_result.AutoSize = true;
            this.lb_result.Location = new System.Drawing.Point(70, 217);
            this.lb_result.Name = "lb_result";
            this.lb_result.Size = new System.Drawing.Size(46, 13);
            this.lb_result.TabIndex = 5;
            this.lb_result.Text = "Result : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "File name";
            // 
            // txt_exportFileName
            // 
            this.txt_exportFileName.Location = new System.Drawing.Point(102, 134);
            this.txt_exportFileName.Name = "txt_exportFileName";
            this.txt_exportFileName.Size = new System.Drawing.Size(314, 20);
            this.txt_exportFileName.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 257);
            this.Controls.Add(this.lb_result);
            this.Controls.Add(this.bt_submit);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Tool Replace Word";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_path_result;
        private System.Windows.Forms.TextBox txt_path_fileEdit;
        private System.Windows.Forms.TextBox txt_path_hosomau;
        private System.Windows.Forms.Button bt_browser_result;
        private System.Windows.Forms.Button bt_browse_fileEdit;
        private System.Windows.Forms.Button bt_browse_hosomau;
        private System.Windows.Forms.Button bt_submit;
        private System.Windows.Forms.Label lb_result;
        private System.Windows.Forms.TextBox txt_exportFileName;
        private System.Windows.Forms.Label label4;
    }
}

