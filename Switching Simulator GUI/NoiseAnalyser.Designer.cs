namespace WindowsFormsApplication1
{
    partial class NoiseAnalyser
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
            this.btn_convert = new System.Windows.Forms.Button();
            this.btn_start_simulation = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tbPhiAverage = new System.Windows.Forms.TextBox();
            this.tbThetaAverage = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.switch_prog_bar = new System.Windows.Forms.ProgressBar();
            this.tbMaxTime = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tb_d_sh_ent = new System.Windows.Forms.TextBox();
            this.tbDelta_time = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.jz_ent = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.jy_ent = new System.Windows.Forms.TextBox();
            this.jx_ent = new System.Windows.Forms.TextBox();
            this.h_z_ent = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.h_y_ent = new System.Windows.Forms.TextBox();
            this.h_x_ent = new System.Windows.Forms.TextBox();
            this.d_th_ent = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Pz_ent = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.Py_ent = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Px_ent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.I_ent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.H_ent = new System.Windows.Forms.TextBox();
            this.H_theta_ent = new System.Windows.Forms.TextBox();
            this.H_units_cb = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.H_phi_ent = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.M_ent = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Temp_ent = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Nzz_ent = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Nyy_ent = new System.Windows.Forms.TextBox();
            this.M_units_cb = new System.Windows.Forms.ComboBox();
            this.Nxx_ent = new System.Windows.Forms.TextBox();
            this.Alpha_ent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Thickness_ent = new System.Windows.Forms.TextBox();
            this.Area_ent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbShotNoise = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbSaveDirectory = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.prgbarFullRun = new System.Windows.Forms.ProgressBar();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(550, 300);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(126, 23);
            this.btn_convert.TabIndex = 114;
            this.btn_convert.Text = "Convert to Unitless";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // btn_start_simulation
            // 
            this.btn_start_simulation.Location = new System.Drawing.Point(550, 329);
            this.btn_start_simulation.Name = "btn_start_simulation";
            this.btn_start_simulation.Size = new System.Drawing.Size(126, 23);
            this.btn_start_simulation.TabIndex = 113;
            this.btn_start_simulation.Text = "Simulate Noise";
            this.btn_start_simulation.UseVisualStyleBackColor = true;
            this.btn_start_simulation.Click += new System.EventHandler(this.btn_start_simulation_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.tbPhiAverage);
            this.groupBox5.Controls.Add(this.tbThetaAverage);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.switch_prog_bar);
            this.groupBox5.Controls.Add(this.tbMaxTime);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Location = new System.Drawing.Point(12, 278);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(480, 88);
            this.groupBox5.TabIndex = 119;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Switching Time";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(345, 22);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(44, 13);
            this.label31.TabIndex = 61;
            this.label31.Text = "Ave Phi";
            // 
            // tbPhiAverage
            // 
            this.tbPhiAverage.Location = new System.Drawing.Point(395, 19);
            this.tbPhiAverage.Name = "tbPhiAverage";
            this.tbPhiAverage.Size = new System.Drawing.Size(69, 20);
            this.tbPhiAverage.TabIndex = 60;
            // 
            // tbThetaAverage
            // 
            this.tbThetaAverage.Location = new System.Drawing.Point(254, 19);
            this.tbThetaAverage.Name = "tbThetaAverage";
            this.tbThetaAverage.Size = new System.Drawing.Size(66, 20);
            this.tbThetaAverage.TabIndex = 59;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(191, 22);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(57, 13);
            this.label29.TabIndex = 58;
            this.label29.Text = "Ave Theta";
            // 
            // switch_prog_bar
            // 
            this.switch_prog_bar.Location = new System.Drawing.Point(13, 54);
            this.switch_prog_bar.Name = "switch_prog_bar";
            this.switch_prog_bar.Size = new System.Drawing.Size(451, 23);
            this.switch_prog_bar.Step = 100;
            this.switch_prog_bar.TabIndex = 57;
            // 
            // tbMaxTime
            // 
            this.tbMaxTime.Location = new System.Drawing.Point(68, 19);
            this.tbMaxTime.Name = "tbMaxTime";
            this.tbMaxTime.Size = new System.Drawing.Size(100, 20);
            this.tbMaxTime.TabIndex = 1;
            this.tbMaxTime.Text = "50000";
            this.tbMaxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Max Time";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.tb_d_sh_ent);
            this.groupBox4.Controls.Add(this.tbDelta_time);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.jz_ent);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.jy_ent);
            this.groupBox4.Controls.Add(this.jx_ent);
            this.groupBox4.Controls.Add(this.h_z_ent);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.h_y_ent);
            this.groupBox4.Controls.Add(this.h_x_ent);
            this.groupBox4.Controls.Add(this.d_th_ent);
            this.groupBox4.Location = new System.Drawing.Point(498, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(199, 262);
            this.groupBox4.TabIndex = 118;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Unitless Values";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(18, 59);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(30, 13);
            this.label30.TabIndex = 75;
            this.label30.Text = "d_sh";
            // 
            // tb_d_sh_ent
            // 
            this.tb_d_sh_ent.Location = new System.Drawing.Point(56, 52);
            this.tb_d_sh_ent.Name = "tb_d_sh_ent";
            this.tb_d_sh_ent.Size = new System.Drawing.Size(122, 20);
            this.tb_d_sh_ent.TabIndex = 74;
            this.tb_d_sh_ent.Text = "0";
            this.tb_d_sh_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbDelta_time
            // 
            this.tbDelta_time.Location = new System.Drawing.Point(56, 233);
            this.tbDelta_time.Name = "tbDelta_time";
            this.tbDelta_time.Size = new System.Drawing.Size(122, 20);
            this.tbDelta_time.TabIndex = 73;
            this.tbDelta_time.Text = "0";
            this.tbDelta_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(7, 237);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(43, 13);
            this.label28.TabIndex = 72;
            this.label28.Text = "del time";
            // 
            // jz_ent
            // 
            this.jz_ent.Location = new System.Drawing.Point(56, 208);
            this.jz_ent.Name = "jz_ent";
            this.jz_ent.Size = new System.Drawing.Size(122, 20);
            this.jz_ent.TabIndex = 15;
            this.jz_ent.Text = "0";
            this.jz_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(34, 211);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(14, 13);
            this.label25.TabIndex = 14;
            this.label25.Text = "jz";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(36, 185);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(14, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "jy";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(34, 159);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(14, 13);
            this.label27.TabIndex = 12;
            this.label27.Text = "jx";
            // 
            // jy_ent
            // 
            this.jy_ent.Location = new System.Drawing.Point(56, 182);
            this.jy_ent.Name = "jy_ent";
            this.jy_ent.Size = new System.Drawing.Size(122, 20);
            this.jy_ent.TabIndex = 11;
            this.jy_ent.Text = "0";
            this.jy_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // jx_ent
            // 
            this.jx_ent.Location = new System.Drawing.Point(56, 156);
            this.jx_ent.Name = "jx_ent";
            this.jx_ent.Size = new System.Drawing.Size(122, 20);
            this.jx_ent.TabIndex = 10;
            this.jx_ent.Text = "0";
            this.jx_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // h_z_ent
            // 
            this.h_z_ent.Location = new System.Drawing.Point(56, 130);
            this.h_z_ent.Name = "h_z_ent";
            this.h_z_ent.Size = new System.Drawing.Size(122, 20);
            this.h_z_ent.TabIndex = 9;
            this.h_z_ent.Text = "0";
            this.h_z_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(30, 133);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(18, 13);
            this.label24.TabIndex = 8;
            this.label24.Text = "hz";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(30, 107);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(18, 13);
            this.label23.TabIndex = 7;
            this.label23.Text = "hy";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(30, 81);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(18, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "hx";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 30);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "d_th";
            // 
            // h_y_ent
            // 
            this.h_y_ent.Location = new System.Drawing.Point(56, 104);
            this.h_y_ent.Name = "h_y_ent";
            this.h_y_ent.Size = new System.Drawing.Size(122, 20);
            this.h_y_ent.TabIndex = 3;
            this.h_y_ent.Text = "0";
            this.h_y_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // h_x_ent
            // 
            this.h_x_ent.Location = new System.Drawing.Point(56, 78);
            this.h_x_ent.Name = "h_x_ent";
            this.h_x_ent.Size = new System.Drawing.Size(122, 20);
            this.h_x_ent.TabIndex = 2;
            this.h_x_ent.Text = "0";
            this.h_x_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // d_th_ent
            // 
            this.d_th_ent.Location = new System.Drawing.Point(56, 26);
            this.d_th_ent.Name = "d_th_ent";
            this.d_th_ent.Size = new System.Drawing.Size(122, 20);
            this.d_th_ent.TabIndex = 1;
            this.d_th_ent.Text = "0";
            this.d_th_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Pz_ent);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.Py_ent);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.Px_ent);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.I_ent);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 69);
            this.groupBox3.TabIndex = 117;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Spin Current";
            // 
            // Pz_ent
            // 
            this.Pz_ent.Location = new System.Drawing.Point(371, 29);
            this.Pz_ent.Name = "Pz_ent";
            this.Pz_ent.Size = new System.Drawing.Size(59, 20);
            this.Pz_ent.TabIndex = 84;
            this.Pz_ent.Text = "0.5";
            this.Pz_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(346, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(19, 13);
            this.label19.TabIndex = 83;
            this.label19.Text = "Pz";
            // 
            // Py_ent
            // 
            this.Py_ent.Location = new System.Drawing.Point(279, 29);
            this.Py_ent.Name = "Py_ent";
            this.Py_ent.Size = new System.Drawing.Size(61, 20);
            this.Py_ent.TabIndex = 82;
            this.Py_ent.Text = "0.0";
            this.Py_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(254, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(19, 13);
            this.label18.TabIndex = 81;
            this.label18.Text = "Py";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(109, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "Amps";
            // 
            // Px_ent
            // 
            this.Px_ent.Location = new System.Drawing.Point(194, 29);
            this.Px_ent.Name = "Px_ent";
            this.Px_ent.Size = new System.Drawing.Size(54, 20);
            this.Px_ent.TabIndex = 79;
            this.Px_ent.Text = "0.0";
            this.Px_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Px";
            // 
            // I_ent
            // 
            this.I_ent.Location = new System.Drawing.Point(47, 29);
            this.I_ent.Name = "I_ent";
            this.I_ent.Size = new System.Drawing.Size(59, 20);
            this.I_ent.TabIndex = 73;
            this.I_ent.Text = "0.0";
            this.I_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "I";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.H_ent);
            this.groupBox2.Controls.Add(this.H_theta_ent);
            this.groupBox2.Controls.Add(this.H_units_cb);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.H_phi_ent);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(11, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 57);
            this.groupBox2.TabIndex = 116;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "External Field";
            // 
            // H_ent
            // 
            this.H_ent.Location = new System.Drawing.Point(48, 19);
            this.H_ent.Name = "H_ent";
            this.H_ent.Size = new System.Drawing.Size(59, 20);
            this.H_ent.TabIndex = 81;
            this.H_ent.Text = "1200";
            this.H_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // H_theta_ent
            // 
            this.H_theta_ent.Location = new System.Drawing.Point(159, 20);
            this.H_theta_ent.Name = "H_theta_ent";
            this.H_theta_ent.Size = new System.Drawing.Size(59, 20);
            this.H_theta_ent.TabIndex = 82;
            this.H_theta_ent.Text = "90";
            this.H_theta_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // H_units_cb
            // 
            this.H_units_cb.FormattingEnabled = true;
            this.H_units_cb.Items.AddRange(new object[] {
            "A/m",
            "Oe"});
            this.H_units_cb.Location = new System.Drawing.Point(365, 23);
            this.H_units_cb.Name = "H_units_cb";
            this.H_units_cb.Size = new System.Drawing.Size(65, 21);
            this.H_units_cb.TabIndex = 87;
            this.H_units_cb.Text = "Units";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 84;
            this.label14.Text = "H_ext";
            // 
            // H_phi_ent
            // 
            this.H_phi_ent.Location = new System.Drawing.Point(282, 22);
            this.H_phi_ent.Name = "H_phi_ent";
            this.H_phi_ent.Size = new System.Drawing.Size(59, 20);
            this.H_phi_ent.TabIndex = 83;
            this.H_phi_ent.Text = "90";
            this.H_phi_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(250, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 86;
            this.label12.Text = "Phi";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(118, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 85;
            this.label13.Text = "Theta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.M_ent);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Temp_ent);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.Nzz_ent);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.Nyy_ent);
            this.groupBox1.Controls.Add(this.M_units_cb);
            this.groupBox1.Controls.Add(this.Nxx_ent);
            this.groupBox1.Controls.Add(this.Alpha_ent);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Thickness_ent);
            this.groupBox1.Controls.Add(this.Area_ent);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 124);
            this.groupBox1.TabIndex = 115;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 106;
            this.label4.Text = "k";
            // 
            // M_ent
            // 
            this.M_ent.Location = new System.Drawing.Point(48, 21);
            this.M_ent.Name = "M_ent";
            this.M_ent.Size = new System.Drawing.Size(59, 20);
            this.M_ent.TabIndex = 0;
            this.M_ent.Text = "1200";
            this.M_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(250, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 103;
            this.label10.Text = "Nzz";
            // 
            // Temp_ent
            // 
            this.Temp_ent.Location = new System.Drawing.Point(265, 23);
            this.Temp_ent.Name = "Temp_ent";
            this.Temp_ent.Size = new System.Drawing.Size(69, 20);
            this.Temp_ent.TabIndex = 105;
            this.Temp_ent.Text = "30.0";
            this.Temp_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(128, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 13);
            this.label15.TabIndex = 102;
            this.label15.Text = "Nyy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "M";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(25, 13);
            this.label16.TabIndex = 101;
            this.label16.Text = "Nxx";
            // 
            // Nzz_ent
            // 
            this.Nzz_ent.Location = new System.Drawing.Point(282, 91);
            this.Nzz_ent.Name = "Nzz_ent";
            this.Nzz_ent.Size = new System.Drawing.Size(59, 20);
            this.Nzz_ent.TabIndex = 100;
            this.Nzz_ent.Text = "-0.028";
            this.Nzz_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(192, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 13);
            this.label17.TabIndex = 104;
            this.label17.Text = "Temperature";
            // 
            // Nyy_ent
            // 
            this.Nyy_ent.Location = new System.Drawing.Point(159, 91);
            this.Nyy_ent.Name = "Nyy_ent";
            this.Nyy_ent.Size = new System.Drawing.Size(59, 20);
            this.Nyy_ent.TabIndex = 99;
            this.Nyy_ent.Text = "0.0";
            this.Nyy_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // M_units_cb
            // 
            this.M_units_cb.FormattingEnabled = true;
            this.M_units_cb.Items.AddRange(new object[] {
            "A/m",
            "Emu/cm^3"});
            this.M_units_cb.Location = new System.Drawing.Point(113, 21);
            this.M_units_cb.Name = "M_units_cb";
            this.M_units_cb.Size = new System.Drawing.Size(69, 21);
            this.M_units_cb.TabIndex = 90;
            this.M_units_cb.Text = "Units";
            // 
            // Nxx_ent
            // 
            this.Nxx_ent.Location = new System.Drawing.Point(48, 91);
            this.Nxx_ent.Name = "Nxx_ent";
            this.Nxx_ent.Size = new System.Drawing.Size(59, 20);
            this.Nxx_ent.TabIndex = 98;
            this.Nxx_ent.Text = "1";
            this.Nxx_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Alpha_ent
            // 
            this.Alpha_ent.Location = new System.Drawing.Point(416, 23);
            this.Alpha_ent.Name = "Alpha_ent";
            this.Alpha_ent.Size = new System.Drawing.Size(59, 20);
            this.Alpha_ent.TabIndex = 72;
            this.Alpha_ent.Text = "0.01";
            this.Alpha_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(320, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 97;
            this.label9.Text = "nm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Alpha";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 96;
            this.label8.Text = "nm^2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 91;
            this.label7.Text = "Area";
            // 
            // Thickness_ent
            // 
            this.Thickness_ent.Location = new System.Drawing.Point(239, 56);
            this.Thickness_ent.Name = "Thickness_ent";
            this.Thickness_ent.Size = new System.Drawing.Size(75, 20);
            this.Thickness_ent.TabIndex = 95;
            this.Thickness_ent.Text = "2.0";
            this.Thickness_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Area_ent
            // 
            this.Area_ent.Location = new System.Drawing.Point(48, 56);
            this.Area_ent.Name = "Area_ent";
            this.Area_ent.Size = new System.Drawing.Size(59, 20);
            this.Area_ent.TabIndex = 92;
            this.Area_ent.Text = "8200.0";
            this.Area_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "Thickness";
            // 
            // cbShotNoise
            // 
            this.cbShotNoise.AutoSize = true;
            this.cbShotNoise.Location = new System.Drawing.Point(550, 277);
            this.cbShotNoise.Name = "cbShotNoise";
            this.cbShotNoise.Size = new System.Drawing.Size(78, 17);
            this.cbShotNoise.TabIndex = 121;
            this.cbShotNoise.Text = "Shot Noise";
            this.cbShotNoise.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.prgbarFullRun);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.tbSaveDirectory);
            this.groupBox6.Location = new System.Drawing.Point(13, 372);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(684, 75);
            this.groupBox6.TabIndex = 122;
            this.groupBox6.TabStop = false;
            // 
            // tbSaveDirectory
            // 
            this.tbSaveDirectory.Location = new System.Drawing.Point(100, 49);
            this.tbSaveDirectory.Name = "tbSaveDirectory";
            this.tbSaveDirectory.Size = new System.Drawing.Size(563, 20);
            this.tbSaveDirectory.TabIndex = 0;
            this.tbSaveDirectory.Text = "C:\\Users\\Tom Physics\\Documents\\Noise Data";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(8, 52);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(85, 13);
            this.label32.TabIndex = 1;
            this.label32.Text = "Saving Directory";
            // 
            // prgbarFullRun
            // 
            this.prgbarFullRun.Location = new System.Drawing.Point(6, 19);
            this.prgbarFullRun.Name = "prgbarFullRun";
            this.prgbarFullRun.Size = new System.Drawing.Size(657, 23);
            this.prgbarFullRun.TabIndex = 123;
            // 
            // NoiseAnalyser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 470);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.cbShotNoise);
            this.Controls.Add(this.btn_convert);
            this.Controls.Add(this.btn_start_simulation);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NoiseAnalyser";
            this.Text = "NoiseAnalyser";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.Button btn_start_simulation;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbThetaAverage;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ProgressBar switch_prog_bar;
        private System.Windows.Forms.TextBox tbMaxTime;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tb_d_sh_ent;
        private System.Windows.Forms.TextBox tbDelta_time;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox jz_ent;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox jy_ent;
        private System.Windows.Forms.TextBox jx_ent;
        private System.Windows.Forms.TextBox h_z_ent;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox h_y_ent;
        private System.Windows.Forms.TextBox h_x_ent;
        private System.Windows.Forms.TextBox d_th_ent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Pz_ent;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox Py_ent;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Px_ent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox I_ent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox H_ent;
        private System.Windows.Forms.TextBox H_theta_ent;
        private System.Windows.Forms.ComboBox H_units_cb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox H_phi_ent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox M_ent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Temp_ent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox Nzz_ent;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox Nyy_ent;
        private System.Windows.Forms.ComboBox M_units_cb;
        private System.Windows.Forms.TextBox Nxx_ent;
        private System.Windows.Forms.TextBox Alpha_ent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Thickness_ent;
        private System.Windows.Forms.TextBox Area_ent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox tbPhiAverage;
        private System.Windows.Forms.CheckBox cbShotNoise;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox tbSaveDirectory;
        private System.Windows.Forms.ProgressBar prgbarFullRun;
    }
}