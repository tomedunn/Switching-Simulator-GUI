using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class NoiseAnalyser : Form
    {
        
        public NoiseAnalyser()
        {
            InitializeComponent();
        }

        public Magnetic_Parameters mp = new Magnetic_Parameters();// initiates the parameters
        bool submit_status = false;
        public string filename;

        private void btn_convert_Click(object sender, EventArgs e)
        {
            UpdateUnits();
        }

        private void btn_start_simulation_Click(object sender, EventArgs e)
        {
            // Initiates the classes to be used by the program
            int iTheta;
            Magnetic_Simulator_Demag Simulator = new Magnetic_Simulator_Demag();
            for (iTheta = 1; iTheta <= 17; iTheta++)
            {
                H_theta_ent.Text = (iTheta * 10).ToString();
                H_theta_ent.Update();
                UpdateUnits();
                filename = tbSaveDirectory.Text + "\\maxima data Temp = " + Temp_ent.Text + " Theta = " + H_theta_ent.Text + ".dat";
                // runs the major loop the switching simulator.
                if (submit_status == true)
                {
                    Simulator.Noise_Analyser(mp, double.Parse(tbMaxTime.Text), ref switch_prog_bar, ref tbThetaAverage, ref tbPhiAverage, filename);
                }
                else
                {
                    MessageBox.Show("Convert values to unitless before starting simulations.");
                }
                prgbarFullRun.Value = (int)(100 * iTheta / 17.0);
                prgbarFullRun.Update();
            }
            MessageBox.Show("Finished!");
        }

        private void UpdateUnits()
        {
            // Inputs the parameters into the parameter object
            if (M_units_cb.SelectedIndex != -1 && H_units_cb.SelectedIndex != -1)
            {
                double hx, hy, hz;
                hx = double.Parse(H_ent.Text) * Math.Sin(Math.PI * double.Parse(H_theta_ent.Text) / 180) * Math.Cos(Math.PI * double.Parse(H_phi_ent.Text) / 180);
                hy = double.Parse(H_ent.Text) * Math.Sin(Math.PI * double.Parse(H_theta_ent.Text) / 180) * Math.Sin(Math.PI * double.Parse(H_phi_ent.Text) / 180);
                hz = double.Parse(H_ent.Text) * Math.Cos(Math.PI * double.Parse(H_theta_ent.Text) / 180);
                mp.M_convert_to_emu(double.Parse(M_ent.Text), M_units_cb.SelectedItem.ToString());
                mp.H_to_unitless(hx, hy, hz, H_units_cb.SelectedItem.ToString());
                mp.alpha = double.Parse(Alpha_ent.Text);
                mp.area = double.Parse(Area_ent.Text);
                mp.thick = double.Parse(Thickness_ent.Text);
                mp.nxx = double.Parse(Nxx_ent.Text);
                mp.nyy = double.Parse(Nyy_ent.Text);
                mp.nzz = double.Parse(Nzz_ent.Text);
                mp.px = double.Parse(Px_ent.Text);
                mp.py = double.Parse(Py_ent.Text);
                mp.pz = double.Parse(Pz_ent.Text);
                mp.delta_time = 0.01;
                mp.Temp_to_d_th(double.Parse(Temp_ent.Text));
                mp.I_to_j_dc(double.Parse(I_ent.Text));
                if (cbShotNoise.Checked == true)
                {
                    mp.I_to_d_sh(double.Parse(I_ent.Text));
                }
                if (cbShotNoise.Checked == false)
                {
                    mp.I_to_d_sh(0);
                }
                mp.type = "noise";
            }
            else
            {
                MessageBox.Show("Select Units for the magnetization and the magnetic field before proceeding.");
            }

            // updates the unitless variables to they can be checked before running simulations
            d_th_ent.Text = Math.Round(mp.d_th, 9).ToString();
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
    }
}
