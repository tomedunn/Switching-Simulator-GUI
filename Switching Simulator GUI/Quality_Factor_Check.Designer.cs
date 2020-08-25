namespace WindowsFormsApplication1
{
    partial class Quality_Factor_Check
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
            this.cbShotNoise = new System.Windows.Forms.CheckBox();
            this.tbSaveDirectory = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.btn_convert = new System.Windows.Forms.Button();
            this.btn_start_simulation = new System.Windows.Forms.Button();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tb_d_sh_ent = new System.Windows.Forms.TextBox();
            this.jz_ent = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.jy_ent = new System.Windows.Forms.TextBox();
            this.jx_ent = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.d_th_ent = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbSpinAccum = new System.Windows.Forms.CheckBox();
            this.cbFieldTorque = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tbIac = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tbPz = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbPy = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbPx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbHx = new System.Windows.Forms.TextBox();
            this.tbHy = new System.Windows.Forms.TextBox();
            this.cbHunits = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbHz = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTemp = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbNzz = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbNyy = new System.Windows.Forms.TextBox();
            this.cbMunits = new System.Windows.Forms.ComboBox();
            this.tbNxx = new System.Windows.Forms.TextBox();
            this.tbAlpha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbThickness = new System.Windows.Forms.TextBox();
            this.tbArea = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tb_Q_values = new System.Windows.Forms.TextBox();
            this.tb_h_steps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbShotNoise
            // 
            this.cbShotNoise.AutoSize = true;
            this.cbShotNoise.Location = new System.Drawing.Point(520, 311);
            this.cbShotNoise.Name = "cbShotNoise";
            this.cbShotNoise.Size = new System.Drawing.Size(91, 17);
            this.cbShotNoise.TabIndex = 134;
            this.cbShotNoise.Text = "Shot noise on";
            this.cbShotNoise.UseVisualStyleBackColor = true;
            // 
            // tbSaveDirectory
            // 
            this.tbSaveDirectory.Location = new System.Drawing.Point(128, 427);
            this.tbSaveDirectory.Name = "tbSaveDirectory";
            this.tbSaveDirectory.Size = new System.Drawing.Size(496, 20);
            this.tbSaveDirectory.TabIndex = 133;
            this.tbSaveDirectory.Text = "C:\\Users\\Tom\\Desktop\\Thesis\\Matlab Figures\\Quality Factor";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(31, 430);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(85, 13);
            this.label34.TabIndex = 132;
            this.label34.Text = "Saving Directory";
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(520, 346);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(126, 23);
            this.btn_convert.TabIndex = 126;
            this.btn_convert.Text = "Convert to Unitless";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click_1);
            // 
            // btn_start_simulation
            // 
            this.btn_start_simulation.Location = new System.Drawing.Point(520, 385);
            this.btn_start_simulation.Name = "btn_start_simulation";
            this.btn_start_simulation.Size = new System.Drawing.Size(126, 23);
            this.btn_start_simulation.TabIndex = 125;
            this.btn_start_simulation.Text = "Start Simulation";
            this.btn_start_simulation.UseVisualStyleBackColor = true;
            this.btn_start_simulation.Click += new System.EventHandler(this.btn_start_simulation_Click);
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(28, 379);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(451, 23);
            this.prgBar.Step = 100;
            this.prgBar.TabIndex = 57;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.tb_d_sh_ent);
            this.groupBox4.Controls.Add(this.jz_ent);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.jy_ent);
            this.groupBox4.Controls.Add(this.jx_ent);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.d_th_ent);
            this.groupBox4.Location = new System.Drawing.Point(499, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(164, 165);
            this.groupBox4.TabIndex = 130;
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
            this.tb_d_sh_ent.Size = new System.Drawing.Size(86, 20);
            this.tb_d_sh_ent.TabIndex = 74;
            this.tb_d_sh_ent.Text = "0";
            this.tb_d_sh_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // jz_ent
            // 
            this.jz_ent.Location = new System.Drawing.Point(56, 130);
            this.jz_ent.Name = "jz_ent";
            this.jz_ent.Size = new System.Drawing.Size(86, 20);
            this.jz_ent.TabIndex = 15;
            this.jz_ent.Text = "0";
            this.jz_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(34, 133);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(14, 13);
            this.label25.TabIndex = 14;
            this.label25.Text = "jz";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(36, 107);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(14, 13);
            this.label26.TabIndex = 13;
            this.label26.Text = "jy";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(34, 81);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(14, 13);
            this.label27.TabIndex = 12;
            this.label27.Text = "jx";
            // 
            // jy_ent
            // 
            this.jy_ent.Location = new System.Drawing.Point(56, 104);
            this.jy_ent.Name = "jy_ent";
            this.jy_ent.Size = new System.Drawing.Size(86, 20);
            this.jy_ent.TabIndex = 11;
            this.jy_ent.Text = "0";
            this.jy_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // jx_ent
            // 
            this.jx_ent.Location = new System.Drawing.Point(56, 78);
            this.jx_ent.Name = "jx_ent";
            this.jx_ent.Size = new System.Drawing.Size(86, 20);
            this.jx_ent.TabIndex = 10;
            this.jx_ent.Text = "0";
            this.jx_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // d_th_ent
            // 
            this.d_th_ent.Location = new System.Drawing.Point(56, 26);
            this.d_th_ent.Name = "d_th_ent";
            this.d_th_ent.Size = new System.Drawing.Size(86, 20);
            this.d_th_ent.TabIndex = 1;
            this.d_th_ent.Text = "0";
            this.d_th_ent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbSpinAccum);
            this.groupBox3.Controls.Add(this.cbFieldTorque);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.tbIac);
            this.groupBox3.Controls.Add(this.label31);
            this.groupBox3.Controls.Add(this.tbPz);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.tbPy);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.tbPx);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(13, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 99);
            this.groupBox3.TabIndex = 129;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Spin Current";
            // 
            // cbSpinAccum
            // 
            this.cbSpinAccum.AutoSize = true;
            this.cbSpinAccum.Location = new System.Drawing.Point(130, 71);
            this.cbSpinAccum.Name = "cbSpinAccum";
            this.cbSpinAccum.Size = new System.Drawing.Size(114, 17);
            this.cbSpinAccum.TabIndex = 92;
            this.cbSpinAccum.Text = "Spin Accumulation";
            this.cbSpinAccum.UseVisualStyleBackColor = true;
            // 
            // cbFieldTorque
            // 
            this.cbFieldTorque.AutoSize = true;
            this.cbFieldTorque.Location = new System.Drawing.Point(21, 71);
            this.cbFieldTorque.Name = "cbFieldTorque";
            this.cbFieldTorque.Size = new System.Drawing.Size(85, 17);
            this.cbFieldTorque.TabIndex = 91;
            this.cbFieldTorque.Text = "Field Torque";
            this.cbFieldTorque.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(112, 32);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(33, 13);
            this.label32.TabIndex = 87;
            this.label32.Text = "Amps";
            // 
            // tbIac
            // 
            this.tbIac.Location = new System.Drawing.Point(47, 29);
            this.tbIac.Name = "tbIac";
            this.tbIac.Size = new System.Drawing.Size(59, 20);
            this.tbIac.TabIndex = 86;
            this.tbIac.Text = "0.0003";
            this.tbIac.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(18, 32);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(25, 13);
            this.label31.TabIndex = 85;
            this.label31.Text = "I ac";
            // 
            // tbPz
            // 
            this.tbPz.Location = new System.Drawing.Point(371, 29);
            this.tbPz.Name = "tbPz";
            this.tbPz.Size = new System.Drawing.Size(59, 20);
            this.tbPz.TabIndex = 84;
            this.tbPz.Text = "-1.0";
            this.tbPz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // tbPy
            // 
            this.tbPy.Location = new System.Drawing.Point(279, 29);
            this.tbPy.Name = "tbPy";
            this.tbPy.Size = new System.Drawing.Size(61, 20);
            this.tbPy.TabIndex = 82;
            this.tbPy.Text = "0.0";
            this.tbPy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // tbPx
            // 
            this.tbPx.Location = new System.Drawing.Point(194, 29);
            this.tbPx.Name = "tbPx";
            this.tbPx.Size = new System.Drawing.Size(54, 20);
            this.tbPx.TabIndex = 79;
            this.tbPx.Text = "-1.0";
            this.tbPx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbHx);
            this.groupBox2.Controls.Add(this.tbHy);
            this.groupBox2.Controls.Add(this.cbHunits);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tbHz);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 57);
            this.groupBox2.TabIndex = 128;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "External Field";
            // 
            // tbHx
            // 
            this.tbHx.Location = new System.Drawing.Point(48, 19);
            this.tbHx.Name = "tbHx";
            this.tbHx.Size = new System.Drawing.Size(59, 20);
            this.tbHx.TabIndex = 81;
            this.tbHx.Text = "0.0";
            this.tbHx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbHy
            // 
            this.tbHy.Location = new System.Drawing.Point(159, 20);
            this.tbHy.Name = "tbHy";
            this.tbHy.Size = new System.Drawing.Size(59, 20);
            this.tbHy.TabIndex = 82;
            this.tbHy.Text = "0.0";
            this.tbHy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbHunits
            // 
            this.cbHunits.FormattingEnabled = true;
            this.cbHunits.Items.AddRange(new object[] {
            "A/m",
            "Oe"});
            this.cbHunits.Location = new System.Drawing.Point(364, 20);
            this.cbHunits.Name = "cbHunits";
            this.cbHunits.Size = new System.Drawing.Size(65, 21);
            this.cbHunits.TabIndex = 87;
            this.cbHunits.Text = "Units";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 84;
            this.label14.Text = "Hx";
            // 
            // tbHz
            // 
            this.tbHz.Location = new System.Drawing.Point(282, 22);
            this.tbHz.Name = "tbHz";
            this.tbHz.Size = new System.Drawing.Size(59, 20);
            this.tbHz.TabIndex = 83;
            this.tbHz.Text = "0.0";
            this.tbHz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(256, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 86;
            this.label12.Text = "Hz";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(136, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 13);
            this.label13.TabIndex = 85;
            this.label13.Text = "Hy";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbM);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbTemp);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.tbNzz);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.tbNyy);
            this.groupBox1.Controls.Add(this.cbMunits);
            this.groupBox1.Controls.Add(this.tbNxx);
            this.groupBox1.Controls.Add(this.tbAlpha);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbThickness);
            this.groupBox1.Controls.Add(this.tbArea);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 124);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // tbM
            // 
            this.tbM.Location = new System.Drawing.Point(46, 22);
            this.tbM.Name = "tbM";
            this.tbM.Size = new System.Drawing.Size(61, 20);
            this.tbM.TabIndex = 107;
            this.tbM.Text = "1200";
            this.tbM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(250, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 103;
            this.label10.Text = "Nzz";
            // 
            // tbTemp
            // 
            this.tbTemp.Location = new System.Drawing.Point(265, 23);
            this.tbTemp.Name = "tbTemp";
            this.tbTemp.Size = new System.Drawing.Size(69, 20);
            this.tbTemp.TabIndex = 105;
            this.tbTemp.Text = "0.0";
            this.tbTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // tbNzz
            // 
            this.tbNzz.Location = new System.Drawing.Point(282, 91);
            this.tbNzz.Name = "tbNzz";
            this.tbNzz.Size = new System.Drawing.Size(59, 20);
            this.tbNzz.TabIndex = 100;
            this.tbNzz.Text = "-0.028";
            this.tbNzz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // tbNyy
            // 
            this.tbNyy.Location = new System.Drawing.Point(159, 91);
            this.tbNyy.Name = "tbNyy";
            this.tbNyy.Size = new System.Drawing.Size(59, 20);
            this.tbNyy.TabIndex = 99;
            this.tbNyy.Text = "0.0";
            this.tbNyy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbMunits
            // 
            this.cbMunits.FormattingEnabled = true;
            this.cbMunits.Items.AddRange(new object[] {
            "A/m",
            "Emu/cm^3"});
            this.cbMunits.Location = new System.Drawing.Point(113, 21);
            this.cbMunits.Name = "cbMunits";
            this.cbMunits.Size = new System.Drawing.Size(69, 21);
            this.cbMunits.TabIndex = 90;
            this.cbMunits.Text = "Units";
            // 
            // tbNxx
            // 
            this.tbNxx.Location = new System.Drawing.Point(48, 91);
            this.tbNxx.Name = "tbNxx";
            this.tbNxx.Size = new System.Drawing.Size(59, 20);
            this.tbNxx.TabIndex = 98;
            this.tbNxx.Text = "1.0";
            this.tbNxx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbAlpha
            // 
            this.tbAlpha.Location = new System.Drawing.Point(416, 23);
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(59, 20);
            this.tbAlpha.TabIndex = 72;
            this.tbAlpha.Text = "0.015";
            this.tbAlpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // tbThickness
            // 
            this.tbThickness.Location = new System.Drawing.Point(239, 56);
            this.tbThickness.Name = "tbThickness";
            this.tbThickness.Size = new System.Drawing.Size(75, 20);
            this.tbThickness.TabIndex = 95;
            this.tbThickness.Text = "2.0";
            this.tbThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbArea
            // 
            this.tbArea.Location = new System.Drawing.Point(48, 56);
            this.tbArea.Name = "tbArea";
            this.tbArea.Size = new System.Drawing.Size(59, 20);
            this.tbArea.TabIndex = 92;
            this.tbArea.Text = "9900.0";
            this.tbArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tb_h_steps);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.tb_Q_values);
            this.groupBox6.Location = new System.Drawing.Point(13, 311);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(480, 58);
            this.groupBox6.TabIndex = 135;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Q values";
            // 
            // tb_Q_values
            // 
            this.tb_Q_values.Location = new System.Drawing.Point(21, 20);
            this.tb_Q_values.Name = "tb_Q_values";
            this.tb_Q_values.Size = new System.Drawing.Size(292, 20);
            this.tb_Q_values.TabIndex = 0;
            this.tb_Q_values.Text = "100,5,2,1";
            // 
            // tb_h_steps
            // 
            this.tb_h_steps.Location = new System.Drawing.Point(398, 19);
            this.tb_h_steps.Name = "tb_h_steps";
            this.tb_h_steps.Size = new System.Drawing.Size(59, 20);
            this.tb_h_steps.TabIndex = 63;
            this.tb_h_steps.Text = "1000";
            this.tb_h_steps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "N h";
            // 
            // Quality_Factor_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 511);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.cbShotNoise);
            this.Controls.Add(this.tbSaveDirectory);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.btn_convert);
            this.Controls.Add(this.btn_start_simulation);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Quality_Factor_Check";
            this.Text = "Quality_Factor_Check";
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

        private System.Windows.Forms.CheckBox cbShotNoise;
        private System.Windows.Forms.TextBox tbSaveDirectory;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.Button btn_start_simulation;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tb_d_sh_ent;
        private System.Windows.Forms.TextBox jz_ent;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox jy_ent;
        private System.Windows.Forms.TextBox jx_ent;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox d_th_ent;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbSpinAccum;
        private System.Windows.Forms.CheckBox cbFieldTorque;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox tbIac;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox tbPz;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbPy;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbPx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbHx;
        private System.Windows.Forms.TextBox tbHy;
        private System.Windows.Forms.ComboBox cbHunits;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbHz;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbTemp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbNzz;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbNyy;
        private System.Windows.Forms.ComboBox cbMunits;
        private System.Windows.Forms.TextBox tbNxx;
        private System.Windows.Forms.TextBox tbAlpha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbThickness;
        private System.Windows.Forms.TextBox tbArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tb_Q_values;
        private System.Windows.Forms.TextBox tb_h_steps;
        private System.Windows.Forms.Label label3;
    }
}