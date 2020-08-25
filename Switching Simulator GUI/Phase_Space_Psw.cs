using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Phase_Space_Psw : Form
    {
        public Phase_Space_Psw()
        {
            InitializeComponent();
            cbMunits.SelectedIndex = 1;
            cbHunits.SelectedIndex = 1;
            cbShotNoise.Checked = false;
        }

        public Magnetic_Parameters mp = new Magnetic_Parameters();// initiates the parameters
        bool submit_status = false;

        private void btn_convert_Click(object sender, EventArgs e)
        {
            // Inputs the parameters into the parameter object
            if (cbMunits.SelectedIndex != -1 && cbHunits.SelectedIndex != -1)
            {
                mp.trials = int.Parse(tbTrials.Text);
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
                mp.Temp_to_d_th(double.Parse(Temp_ent.Text));
                //mp.I_to_j_dc(double.Parse(tbImax.Text));
                //mp.I_to_j_ac(double.Parse(tbImin.Text));
                if (cbShotNoise.Checked == true)
                {
                    mp.I_to_d_sh(double.Parse(tbImax.Text));
                }
                if (cbSpinAccum.Checked == true)
                {
                    mp.spin_accum = 0.4;
                }
                mp.period = double.Parse(tbPmin.Text);
                mp.type = "switching prob";
                mp.savedirectory = tbSaveDirectory.Text;
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
            h_x_ent.Text = Math.Round(mp.hx, 9).ToString();
            h_y_ent.Text = Math.Round(mp.hy, 9).ToString();
            h_z_ent.Text = Math.Round(mp.hz, 9).ToString();
            if (rbAC.Checked == true)
            {
                tbj_ac.Text = Math.Round((1.0), 9).ToString();

            }
            else
            {
                tbj_dc.Text = Math.Round((1.0), 9).ToString();
            }
            submit_status = true;
        }

        private void btn_start_simulation_Click(object sender, EventArgs e)
        {
            // runs the major loop the switching simulator.
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
            // gets the parameter values for the simulations
            double Pmin, Pmax, Imin, Imax, Cycles;
            Pmin = double.Parse(tbPmin.Text); Pmax = double.Parse(tbPmax.Text);
            Imin = double.Parse(tbImin.Text); Imax = double.Parse(tbImax.Text);
            Cycles = double.Parse(tbCycles.Text);
            int nPeriods, nCurrents, trials;
            nPeriods = int.Parse(tbNPeriods.Text); nCurrents = int.Parse(tbNCurrents.Text);
            trials = int.Parse(tbTrials.Text);
            string type;
            if(rbAC.Checked == true)
            {
                type = "AC";
            }
            else
            {
                type = "DC";
            };
            // Initiates the classes to be used by the program
            Lock_Interface(true);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Magnetic_Simulator_Demag Switcher = new Magnetic_Simulator_Demag();
            Switcher.Ac_Switching_A_w_Phase_Space(mp, trials, Pmin, Pmax, nPeriods, Imin, Imax, nCurrents, Cycles, type, tbCompleted, prgBar);
            sw.Stop();
            Lock_Interface(false);
            MessageBox.Show(sw.Elapsed.ToString());
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
