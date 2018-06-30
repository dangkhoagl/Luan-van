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
            this.tb_submittions = new System.Windows.Forms.TextBox();
            this.bt_sse = new System.Windows.Forms.Button();
            this.bt_pse = new System.Windows.Forms.Button();
            this.bt_rs = new System.Windows.Forms.Button();
            this.lb_thongbao = new System.Windows.Forms.Label();
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
            this.bt_do_hanh_vi.Location = new System.Drawing.Point(50, 174);
            this.bt_do_hanh_vi.Name = "bt_do_hanh_vi";
            this.bt_do_hanh_vi.Size = new System.Drawing.Size(101, 23);
            this.bt_do_hanh_vi.TabIndex = 1;
            this.bt_do_hanh_vi.Text = "Đo hành vi";
            this.bt_do_hanh_vi.UseVisualStyleBackColor = true;
            this.bt_do_hanh_vi.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_upload_solution
            // 
            this.bt_upload_solution.Location = new System.Drawing.Point(49, 64);
            this.bt_upload_solution.Name = "bt_upload_solution";
            this.bt_upload_solution.Size = new System.Drawing.Size(102, 23);
            this.bt_upload_solution.TabIndex = 2;
            this.bt_upload_solution.Text = "Upload Solution";
            this.bt_upload_solution.UseVisualStyleBackColor = true;
            this.bt_upload_solution.Click += new System.EventHandler(this.bt_upload_solution_Click);
            // 
            // bt_upload_users
            // 
            this.bt_upload_users.Location = new System.Drawing.Point(49, 116);
            this.bt_upload_users.Name = "bt_upload_users";
            this.bt_upload_users.Size = new System.Drawing.Size(102, 23);
            this.bt_upload_users.TabIndex = 3;
            this.bt_upload_users.Text = "Upload Users";
            this.bt_upload_users.UseVisualStyleBackColor = true;
            this.bt_upload_users.Click += new System.EventHandler(this.bt_upload_users_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(157, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Path Solution.....";
            // 
            // tb_submittions
            // 
            this.tb_submittions.Location = new System.Drawing.Point(157, 118);
            this.tb_submittions.Name = "tb_submittions";
            this.tb_submittions.Size = new System.Drawing.Size(352, 21);
            this.tb_submittions.TabIndex = 5;
            this.tb_submittions.Text = "Path Submittion....";
            // 
            // bt_sse
            // 
            this.bt_sse.Location = new System.Drawing.Point(275, 174);
            this.bt_sse.Name = "bt_sse";
            this.bt_sse.Size = new System.Drawing.Size(116, 23);
            this.bt_sse.TabIndex = 9;
            this.bt_sse.Text = "Độ đo SSE";
            this.bt_sse.UseVisualStyleBackColor = true;
            this.bt_sse.Click += new System.EventHandler(this.bt_sse_Click);
            // 
            // bt_pse
            // 
            this.bt_pse.Location = new System.Drawing.Point(397, 174);
            this.bt_pse.Name = "bt_pse";
            this.bt_pse.Size = new System.Drawing.Size(112, 23);
            this.bt_pse.TabIndex = 10;
            this.bt_pse.Text = "Độ đo PSE";
            this.bt_pse.UseVisualStyleBackColor = true;
            this.bt_pse.Click += new System.EventHandler(this.bt_pse_Click);
            // 
            // bt_rs
            // 
            this.bt_rs.Location = new System.Drawing.Point(157, 174);
            this.bt_rs.Name = "bt_rs";
            this.bt_rs.Size = new System.Drawing.Size(112, 23);
            this.bt_rs.TabIndex = 11;
            this.bt_rs.Text = "Độ đo RS";
            this.bt_rs.UseVisualStyleBackColor = true;
            this.bt_rs.Click += new System.EventHandler(this.bt_rs_Click);
            // 
            // lb_thongbao
            // 
            this.lb_thongbao.AutoSize = true;
            this.lb_thongbao.Location = new System.Drawing.Point(252, 219);
            this.lb_thongbao.Name = "lb_thongbao";
            this.lb_thongbao.Size = new System.Drawing.Size(19, 13);
            this.lb_thongbao.TabIndex = 12;
            this.lb_thongbao.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 260);
            this.Controls.Add(this.lb_thongbao);
            this.Controls.Add(this.bt_rs);
            this.Controls.Add(this.bt_pse);
            this.Controls.Add(this.bt_sse);
            this.Controls.Add(this.tb_submittions);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bt_upload_users);
            this.Controls.Add(this.bt_upload_solution);
            this.Controls.Add(this.bt_do_hanh_vi);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_do_hanh_vi;
        private System.Windows.Forms.Button bt_upload_solution;
        private System.Windows.Forms.Button bt_upload_users;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tb_submittions;
        private System.Windows.Forms.Button bt_sse;
        private System.Windows.Forms.Button bt_pse;
        private System.Windows.Forms.Button bt_rs;
        private System.Windows.Forms.Label lb_thongbao;
    }
}

