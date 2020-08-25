using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using NPack;

namespace WindowsFormsApplication1
{
    public partial class Quality_Factor_Check : Form
    {
        public Quality_Factor_Check()
        {
            InitializeComponent();
            cbMunits.SelectedIndex = 1;
            cbHunits.SelectedIndex = 1;
            cbShotNoise.Checked = false;
        }

        public Magnetic_Parameters mp = new Magnetic_Parameters();// initiates the parameters
        public MLApp.MLApp matlab = new MLApp.MLApp();
        bool submit_status = false;

        private void btn_convert_Click_1(object sender, EventArgs e)
        {
            // Inputs the parameters into the parameter object
            if (cbMunits.SelectedIndex != -1 && cbHunits.SelectedIndex != -1)
            {
                mp.M_convert_to_emu(double.Parse(tbM.Text), cbMunits.SelectedItem.ToString());
                //mp.H_to_unitless(double.Parse(tbHx.Text), double.Parse(tbHy.Text), double.Parse(tbHz.Text), cbHunits.SelectedItem.ToString());
                mp.alpha = double.Parse(tbAlpha.Text);
                mp.area = double.Parse(tbArea.Text);
                mp.thick = double.Parse(tbThickness.Text);
                mp.nxx = double.Parse(tbNxx.Text);
                mp.nyy = double.Parse(tbNyy.Text);
                mp.nzz = double.Parse(tbNzz.Text);
                mp.px = double.Parse(tbPx.Text);
                mp.py = double.Parse(tbPy.Text);
                mp.pz = double.Parse(tbPz.Text);
                if (cbFieldTorque.Checked == true)
                {
                    mp.pxf = 0.3 * mp.px;
                    mp.pyf = 0.3 * mp.py;
                    mp.pzf = 0.3 * mp.pz;
                }
                else
                {
                    mp.pxf = 0.0;
                    mp.pyf = 0.0;
                    mp.pzf = 0.0;
                }
                mp.delta_time = 0.01;
                mp.delta_time_min = 0.001;
                mp.Temp_to_d_th(double.Parse(tbTemp.Text));
                mp.I_to_j_dc(0);
                mp.I_to_j_ac(double.Parse(tbIac.Text));
                if (cbShotNoise.Checked == true)
                {
                    mp.I_to_d_sh(0);
                }
                if (cbSpinAccum.Checked == true)
                {
                    mp.spin_accum = 0.4;
                }
                mp.type = "switching prob";
                mp.savedirectory = tbSaveDirectory.Text;
                //prgBar.Maximum = int.Parse(tb_Q_steps.Text) * int.Parse(tb_h_steps.Text);
                //mp.hx = 15 * mp.j_dc * mp.px;
                //mp.hy = 10 * mp.j_dc * mp.py;
                //mp.hz = 15 * mp.j_dc * mp.pz;
            }
            else
            {
                MessageBox.Show("Select Units for the magnetization and the magnetic field before proceeding.");
            }
            // updates the unitless variables to they can be checked before running simulations
            d_th_ent.Text = mp.d_th.ToString();
            tb_d_sh_ent.Text = Math.Round(mp.d_sh, 9).ToString();
            //h_x_ent.Text = Math.Round(mp.hx, 9).ToString();
            //h_y_ent.Text = Math.Round(mp.hy, 9).ToString();
            //h_z_ent.Text = Math.Round(mp.hz, 9).ToString();
            jx_ent.Text = Math.Round((mp.j_ac * mp.px), 9).ToString();
            jy_ent.Text = Math.Round((mp.j_ac * mp.py), 9).ToString();
            jz_ent.Text = Math.Round((mp.j_ac * mp.pz), 9).ToString();
            //tbDelta_time.Text = Math.Round(mp.delta_time, 9).ToString();
            submit_status = true;
        }

        private void btn_start_simulation_Click(object sender, EventArgs e)
        {
            // Initiates the classes to be used by the program
            if (submit_status == true)
            {
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
            Lock_Interface(true);
            Magnetic_Simulator_Demag Q_check = new Magnetic_Simulator_Demag();
            double[] Q = tb_Q_values.Text.Split(',').Select(s => double.Parse(s)).ToArray();
            int h_steps = int.Parse(tb_h_steps.Text);
            Q_check.Quality_Factor_Check(mp, Q, h_steps, ref matlab, prgBar);
            Lock_Interface(false);
        }

        private void Lock_Interface(bool locked)
        {
            locked = !locked;
            this.Invoke((MethodInvoker)delegate
            {
                btn_convert.Enabled = locked;
                btn_start_simulation.Enabled = locked;
            });

        }
   }
}
