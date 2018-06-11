namespace DOTUONGTU
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
            this.bt_do_hanh_vi = new System.Windows.Forms.Button();
            this.bt_upload_solution = new System.Windows.Forms.Button();
            this.bt_upload_users = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐỘ TƯƠNG TỰ VỀ HÀNH VI CỦA CHƯƠNG TRÌNH ";
            // 
            // bt_do_hanh_vi
            // 
            this.bt_do_hanh_vi.Location = new System.Drawing.Point(49, 63);
            this.bt_do_hanh_vi.Name = "bt_do_hanh_vi";
            this.bt_do_hanh_vi.Size = new System.Drawing.Size(97, 23);
            this.bt_do_hanh_vi.TabIndex = 1;
            this.bt_do_hanh_vi.Text = "Đo hành vi";
            this.bt_do_hanh_vi.UseVisualStyleBackColor = true;
            this.bt_do_hanh_vi.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_upload_solution
            // 
            this.bt_upload_solution.Location = new System.Drawing.Point(152, 63);
            this.bt_upload_solution.Name = "bt_upload_solution";
            this.bt_upload_solution.Size = new System.Drawing.Size(102, 23);
            this.bt_upload_solution.TabIndex = 2;
            this.bt_upload_solution.Text = "Upload Solution";
            this.bt_upload_solution.UseVisualStyleBackColor = true;
            this.bt_upload_solution.Click += new System.EventHandler(this.bt_upload_solution_Click);
            // 
            // bt_upload_users
            // 
            this.bt_upload_users.Location = new System.Drawing.Point(260, 63);
            this.bt_upload_users.Name = "bt_upload_users";
            this.bt_upload_users.Size = new System.Drawing.Size(116, 23);
            this.bt_upload_users.TabIndex = 3;
            this.bt_upload_users.Text = "Upload Users";
            this.bt_upload_users.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 20);
            this.textBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 349);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bt_upload_users);
            this.Controls.Add(this.bt_upload_solution);
            this.Controls.Add(this.bt_do_hanh_vi);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_do_hanh_vi;
        private System.Windows.Forms.Button bt_upload_solution;
        private System.Windows.Forms.Button bt_upload_users;
        private System.Windows.Forms.TextBox textBox1;
    }
}

