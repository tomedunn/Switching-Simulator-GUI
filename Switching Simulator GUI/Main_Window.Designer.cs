namespace WindowsFormsApplication1
{
    partial class Main_Window
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Window));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_Noise_Analyser = new System.Windows.Forms.Button();
            this.Open_DB_btn = new System.Windows.Forms.Button();
            this.btnTrajectory = new System.Windows.Forms.Button();
            this.btn_Hysteresis = new System.Windows.Forms.Button();
            this.btnShotNoiseTester = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPswPS = new System.Windows.Forms.Button();
            this.btnQuality = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // btn_Noise_Analyser
            // 
            this.btn_Noise_Analyser.Location = new System.Drawing.Point(51, 12);
            this.btn_Noise_Analyser.Name = "btn_Noise_Analyser";
            this.btn_Noise_Analyser.Size = new System.Drawing.Size(140, 23);
            this.btn_Noise_Analyser.TabIndex = 4;
            this.btn_Noise_Analyser.Text = "Noise Analyser";
            this.btn_Noise_Analyser.UseVisualStyleBackColor = true;
            this.btn_Noise_Analyser.Click += new System.EventHandler(this.button2_Click);
            // 
            // Open_DB_btn
            // 
            this.Open_DB_btn.Location = new System.Drawing.Point(51, 96);
            this.Open_DB_btn.Name = "Open_DB_btn";
            this.Open_DB_btn.Size = new System.Drawing.Size(139, 23);
            this.Open_DB_btn.TabIndex = 6;
            this.Open_DB_btn.Text = "Open Database";
            this.Open_DB_btn.UseVisualStyleBackColor = true;
            this.Open_DB_btn.Click += new System.EventHandler(this.Open_DB_btn_Click);
            // 
            // btnTrajectory
            // 
            this.btnTrajectory.Location = new System.Drawing.Point(51, 55);
            this.btnTrajectory.Name = "btnTrajectory";
            this.btnTrajectory.Size = new System.Drawing.Size(139, 23);
            this.btnTrajectory.TabIndex = 7;
            this.btnTrajectory.Text = "Switching Trajectory Sim";
            this.btnTrajectory.UseVisualStyleBackColor = true;
            this.btnTrajectory.Click += new System.EventHandler(this.btnTrajectory_Click);
            // 
            // btn_Hysteresis
            // 
            this.btn_Hysteresis.Location = new System.Drawing.Point(51, 143);
            this.btn_Hysteresis.Name = "btn_Hysteresis";
            this.btn_Hysteresis.Size = new System.Drawing.Size(139, 23);
            this.btn_Hysteresis.TabIndex = 8;
            this.btn_Hysteresis.Text = "Hysteresis";
            this.btn_Hysteresis.UseVisualStyleBackColor = true;
            this.btn_Hysteresis.Click += new System.EventHandler(this.btn_Hysteresis_Click);
            // 
            // btnShotNoiseTester
            // 
            this.btnShotNoiseTester.Location = new System.Drawing.Point(51, 189);
            this.btnShotNoiseTester.Name = "btnShotNoiseTester";
            this.btnShotNoiseTester.Size = new System.Drawing.Size(139, 23);
            this.btnShotNoiseTester.TabIndex = 9;
            this.btnShotNoiseTester.Text = "Shot Noise Tester";
            this.btnShotNoiseTester.UseVisualStyleBackColor = true;
            this.btnShotNoiseTester.Click += new System.EventHandler(this.btnShotNoiseTester_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Switching Probability";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPswPS
            // 
            this.btnPswPS.Location = new System.Drawing.Point(51, 274);
            this.btnPswPS.Name = "btnPswPS";
            this.btnPswPS.Size = new System.Drawing.Size(139, 23);
            this.btnPswPS.TabIndex = 11;
            this.btnPswPS.Text = "Psw Phase Space";
            this.btnPswPS.UseVisualStyleBackColor = true;
            this.btnPswPS.Click += new System.EventHandler(this.btnPswPS_Click);
            // 
            // btnQuality
            // 
            this.btnQuality.Location = new System.Drawing.Point(51, 324);
            this.btnQuality.Name = "btnQuality";
            this.btnQuality.Size = new System.Drawing.Size(139, 23);
            this.btnQuality.TabIndex = 12;
            this.btnQuality.Text = "Quality Factor Check";
            this.btnQuality.UseVisualStyleBackColor = true;
            this.btnQuality.Click += new System.EventHandler(this.btnQuality_Click);
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 377);
            this.Controls.Add(this.btnQuality);
            this.Controls.Add(this.btn_Noise_Analyser);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTrajectory);
            this.Controls.Add(this.btnPswPS);
            this.Controls.Add(this.Open_DB_btn);
            this.Controls.Add(this.btnShotNoiseTester);
            this.Controls.Add(this.btn_Hysteresis);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Window";
            this.Text = "Switching Simulator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btn_Noise_Analyser;
        private System.Windows.Forms.Button Open_DB_btn;
        private System.Windows.Forms.Button btnTrajectory;
        private System.Windows.Forms.Button btn_Hysteresis;
        private System.Windows.Forms.Button btnShotNoiseTester;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPswPS;
        private System.Windows.Forms.Button btnQuality;
    }
}

