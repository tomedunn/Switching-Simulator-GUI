using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MLApp;

namespace WindowsFormsApplication1
{
    public partial class SwitchingTrajectory : Form
    {
        public SwitchingTrajectory()
        {
            InitializeComponent();
            cbMunits.SelectedIndex = 1;
            cbHunits.SelectedIndex = 1;
            cbType.SelectedIndex = 1;
            cbShotNoise.Checked = false;
        }

        public Magnetic_Parameters mp = new Magnetic_Parameters();// initiates the parameters
        public MLApp.MLApp matlab = new MLApp.MLApp();
        bool submit_status = false;
        bool manual_initial_conditions = false;

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

                manual_initial_conditions = cb_initial_conditions.Checked;
                mp.theta_initial = double.Parse(tb_theta_initial.Text);
                mp.phi_initial = double.Parse(tb_phi_initial.Text);

                mp.Temp_to_d_th(double.Parse(Temp_ent.Text));
                mp.I_to_j_dc(double.Parse(I_ent.Text));
                mp.I_to_j_ac(double.Parse(tbIac.Text));
                if (cbShotNoise.Checked == true)
                {
                    mp.I_to_d_sh(double.Parse(I_ent.Text));
                }
                mp.period = double.Parse(tbPeriod.Text);
                mp.tau = double.Parse(tbCycles.Text);
                mp.type = "switch";
                mp.savedirectory = tbSaveDirectory.Text;
                mp.spin_accum = 0.0;
                //mp.hx = 10 * mp.j_dc * mp.px;
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
            jx_ent.Text = Math.Round((mp.j_dc * mp.px), 9).ToString();
            jy_ent.Text = Math.Round((mp.j_dc * mp.py), 9).ToString();
            jz_ent.Text = Math.Round((mp.j_dc * mp.pz), 9).ToString();
            tbDelta_time.Text = Math.Round(mp.delta_time, 9).ToString();
            submit_status = true;
        }

        private void btn_start_simulation_Click(object sender, EventArgs e)
        {
            // Initiates the classes to be used by the program
            Magnetic_Simulator_Demag Switcher = new Magnetic_Simulator_Demag();
            double PulseTime = double.Parse(tbPTime.Text);
            double DownPulseTime = double.Parse(tbDownPulse.Text);
            double MaxTime = double.Parse(tbSTime.Text);
            bool Save = cbSave.Checked;
            // runs the major loop the switching simulator.
            if (submit_status == true)
            {
                string type = cbType.SelectedItem.ToString();
                Switcher.Magnetic_Trajectory(ref matlab, ref mp, type, 0.0, MaxTime, PulseTime, DownPulseTime, 3 * Math.PI, 1.0, Save, manual_initial_conditions);
                //Switcher.Magnetic_Trajectory_Fit_Alpha(ref mp, 0.0, MaxTime, PulseTime, DownPulseTime, 3 * Math.PI, 1.0, Save);
                //Switcher.Magnetic_Trajectory_Fit_Freq(ref mp, 0.0, MaxTime, PulseTime, DownPulseTime, 3 * Math.PI, 1.0, Save);
                //Switcher.Magnetic_Trajectory_Fit_Current(ref mp, 0.0, MaxTime, PulseTime, DownPulseTime, 3 * Math.PI, 1.0, Save);
                
                submit_status = false;
            }
            else
            {
                MessageBox.Show("Convert values to unitless before starting simulations.");
            }
        }

    }
}
