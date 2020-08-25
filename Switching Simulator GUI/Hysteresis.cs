using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Hysteresis : Form
    {
        public Hysteresis()
        {
            InitializeComponent();
            cbMunits.SelectedIndex = 1;
            cbHunits.SelectedIndex = 1;
            cbShotNoise.Checked = false;
        }

        public Magnetic_Parameters mp = new Magnetic_Parameters();// initiates the parameters
        public MLApp.MLApp matlab = new MLApp.MLApp();
        bool submit_status = false;

        private void btn_convert_Click(object sender, EventArgs e)
        {
            // Inputs the parameters into the parameter object
            if (cbMunits.SelectedIndex != -1 && cbHunits.SelectedIndex != -1)
            {
                mp.M_convert_to_emu(double.Parse(M_ent.Text), cbMunits.SelectedItem.ToString());
                mp.H_to_unitless(double.Parse(Hx_ent.Text), double.Parse(Hy_ent.Text), double.Parse(Hz_ent.Text), cbHunits.SelectedItem.ToString());
                mp.alpha = double.Parse(Alpha_ent.Text);
                mp.area = double.Parse(Area_ent.Text);
                mp.thick = double.Parse(Thickness_ent.Text);
                mp.nxx = double.Parse(Nxx_ent.Text);
                mp.nyy = double.Parse(Nyy_ent.Text);
                mp.nzz = double.Parse(Nzz_ent.Text);
                mp.px = double.Parse(Px_ent.Text);
                mp.py = double.Parse(Py_ent.Text);
                mp.pz = double.Parse(Pz_ent.Text);
                if (cbFreqHyst.Checked == true)
                {
                    mp.px = double.Parse(tbPxx.Text);
                    mp.py = double.Parse(tbPyy.Text);
                    mp.pz = double.Parse(tbPzz.Text);
                }
                mp.delta_time = 0.01;
                mp.delta_time_min = 0.001;
                mp.Temp_to_d_th(double.Parse(Temp_ent.Text));
                mp.I_to_j_dc(double.Parse(tbIMin.Text));
                mp.I_to_j_ac(double.Parse(tbIMax.Text));
                if (cbFreqHyst.Checked == true)
                {
                    mp.I_to_j_dc(0.0);
                    mp.I_to_j_ac(double.Parse(tbIac.Text));
                }
                if (cbShotNoise.Checked == true)
                {
                    mp.I_to_d_sh(double.Parse(tbIMin.Text));
                }
                mp.period = double.Parse(tbPeriod.Text);
                mp.type = "hysteresis";
                mp.savedirectory = tbSaveDirectory.Text;
                submit_status = true;
            }
            else
            {
                MessageBox.Show("Select Units for the magnetization and the magnetic field before proceeding.");
                submit_status = false;
            }

            if (cbFreqHyst.Checked == false && cbCurrentHyst.Checked == false)
            {
                MessageBox.Show("Check the box for the time of hysteresis loop to perform.");
                submit_status = false;
            }


            // updates the unitless variables to they can be checked before running simulations
            d_th_ent.Text = mp.d_th.ToString();
            tb_d_sh_ent.Text = Math.Round(mp.d_sh, 9).ToString();
            h_x_ent.Text = Math.Round(mp.hx, 9).ToString();
            h_y_ent.Text = Math.Round(mp.hy, 9).ToString();
            h_z_ent.Text = Math.Round(mp.hz, 9).ToString();
            jx_ent.Text = Math.Round((mp.j_ac * mp.px), 9).ToString();
            jy_ent.Text = Math.Round((mp.j_ac * mp.py), 9).ToString();
            jz_ent.Text = Math.Round((mp.j_ac * mp.pz), 9).ToString();
            tbDelta_time.Text = Math.Round(mp.delta_time, 9).ToString();
        }

        private void btn_start_simulation_Click(object sender, EventArgs e)
        {
            // Initiates the classes to be used by the program
            // runs the major loop the switching simulator.
            if (submit_status == true)
            {
                //Lock_Interface(true);
                Thread sim = new Thread(new ThreadStart(Sim));
                sim.Start();
                submit_status = false;
            }
            else
            {
                MessageBox.Show("Convert values to unitless before starting simulations.");
            }
        }

        private void Sim()
        {
            Magnetic_Simulator_Demag Switcher = new Magnetic_Simulator_Demag();
            if (cbCurrentHyst.Checked == true)
            {
                Switcher.Hysteresis_Loop_Current_Amplitude(ref matlab, mp, mp.j_ac, mp.j_dc, int.Parse(tbSteps.Text));
                submit_status = false;
            }
            else if (cbFreqHyst.Checked == true)
            {
                mp.I_to_j_dc(0.0);
                mp.I_to_j_ac(double.Parse(tbIac.Text));
                double PerMin = double.Parse(tbPerMin.Text);
                double PerMax = double.Parse(tbPerMax.Text);
                double tpf = 1000.0;
                Switcher.Hysteresis_Loop_Frequency(ref matlab, ref mp, PerMin, PerMax, tpf, true);
                submit_status = false;
            }
        }
    }
}
