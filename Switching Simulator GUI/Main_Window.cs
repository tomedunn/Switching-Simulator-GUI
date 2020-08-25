using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{

    public partial class Main_Window : Form
    {
        public Main_Window()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NoiseAnalyser NoiseAnalyse = new NoiseAnalyser();
            NoiseAnalyse.Show();
        }

        private void Open_DB_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Switching_Simulation_DB.mdf;Integrated Security=True;User Instance=True");
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show(con.State.ToString());
            con.Close();
        }

        private void btnTrajectory_Click(object sender, EventArgs e)
        {
            SwitchingTrajectory SwT = new SwitchingTrajectory();
            SwT.Show();
        }

        private void btn_Hysteresis_Click(object sender, EventArgs e)
        {
            Hysteresis Hyst = new Hysteresis();
            Hyst.Show();
        }

        private void btnShotNoiseTester_Click(object sender, EventArgs e)
        {
            Shot_Noise_Tester SNT = new Shot_Noise_Tester();
            SNT.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Switching_Probability SWPrb = new Switching_Probability();
            SWPrb.Show();
        }

        private void btnPswPS_Click(object sender, EventArgs e)
        {
            Phase_Space_Psw PswPS = new Phase_Space_Psw();
            PswPS.Show();
        }

        private void btnQuality_Click(object sender, EventArgs e)
        {
            Quality_Factor_Check QFC = new Quality_Factor_Check();
            QFC.Show();
        }


    }
}
