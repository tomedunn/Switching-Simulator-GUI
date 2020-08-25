using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Magnetic_Parameters
    {
        public int id; // the id number to be used when storing data in the trials table
        public long id_unique; // id constructed from the data and time to be used in the filename
        public string type; // the kind of simulation (Switch, Noise)
        public string savedirectory;
        public int trials = 1; // number of trials. One by default.
        // Material parameters. These will be used to convert and revert units to the other variables
        public double magn;// magnetization cgs units
        public double d_th;// unitless thermal noise parameter
        public double d_sh;// unitless shot noise parameter
        public double alpha;// dissipation constant
        public double area;// area measured in nanometers squared
        public double thick;// thickness measured in nanometers

        public double nxx;///////////////////////////////////////////
        public double nyy;// unitless demag tensor - checksum is 1 //
        public double nzz;///////////////////////////////////////////

        public bool h_on;// tells the program whether the magntic fields are turned on or not
        public double hx;/////////////////////////////////////////////////////////
        public double hy;// unitless magnetic field in the x, y and z direction //
        public double hz;/////////////////////////////////////////////////////////

        public bool j_on;// tell the program whether the current is on
        public double j_dc;// unitless spin current
        public double j_ac;// unitless ac spin current
        public double period;// unitless period value
        public double tau;// number of cycles for the ac current
        public double px; /////////////////////////////////////////////////////
        public double py; // Spin Polarization in the x, y, and z directions //
        public double pz; /////////////////////////////////////////////////////
        public double pxf;///////////////////////////////////////////////////////////////////////////
        public double pyf;// Spin Polarization in the x, y, and z directions for field like torque //
        public double pzf;///////////////////////////////////////////////////////////////////////////

        public double theta_initial;
        public double phi_initial; 

        public double spin_accum = 0.0; // is the spin accumulation coefficient.
        // these are physics constants and will not be modified through the program.
        public double gamma = 1.7 * Math.Pow(10, 7); // gyromagnetic ratio in cgs units
        public double k_b = 1.38 * Math.Pow(10, -16); // botlzmann constant
        public double h_bar = 1.055 * Math.Pow(10, -27); // Planck's constant in cgs units.
        public double q_e = 1.602 * Math.Pow(10, -19); // electron charge

        public double res_min;
        public double res_max;

        public double delta_time;// the timestep constant for the simulation
        public double delta_time_min;

        public void M_convert_to_emu(double m, string state)
        {
            if (state == "A/m")
            {
                magn = m*0.001;// converts the magnetization to Emu/cm^3 units.
            }
            else if (state == "Emu/cm^3")
            {
                magn =  m;
            }
        }
        
        public void H_to_unitless(double Hx, double Hy, double Hz, string state)
        {
            if (state == "Oe")
            {
                hx = Hx / magn; // sets the unitless values for the external field
                hy = Hy / magn;
                hz = Hz / magn;
            }
            else if (state == "A/m")
            {
                hx = 4 * Math.PI * 0.001 * (Hx / magn); // If the external field is set to A/m
                hy = 4 * Math.PI * 0.001 * (Hy / magn); // convert to Oe and then convert to
                hz = 4 * Math.PI * 0.001 * (Hz / magn); // unitless variables to be used.
            }
        }

        public void Temp_to_d_th(double temp)
        {
            //d_th = (alpha * k_b * temp) / ( area * thick * Math.Pow(10,-21) * 
            //    Math.Pow(magn, 2));
            d_th = (alpha * k_b * temp) / (area * thick * Math.Pow(10, -21) *
                4 * Math.PI * Math.Pow(magn, 2));
            // not sure if this is right but should make a unitless form of the noise.
            // The units on this work out well the factor of 10^-21 is due to the volume
            // being measured in Ergs per cm^3 not in terms of Ergs per m^3
        }

        public void I_to_d_sh(double i)
        {
            d_sh = 1000 * (gamma * Math.Pow(h_bar, 2)) / (64 * q_e * Math.PI * Math.Pow(area * thick * Math.Pow(10, -21), 2) * Math.Pow(magn, 3)) * i;
            // Calculates the shot noise in unitless parameters
        }

        public void I_to_j_dc(double i)
        {
            j_dc = (i * h_bar) / (2 * 4 * Math.PI * Math.Pow(magn, 2) * q_e * area * thick * Math.Pow(10, -21));
        }

        public void I_to_j_ac(double i)
        {
            j_ac = (i * h_bar) / (2 * 4 * Math.PI * Math.Pow(magn, 2) * q_e * area * thick * Math.Pow(10, -21));
        }

        public void Construct_File_Name(ref string ofilename)
        {
            ofilename = savedirectory + "\\";
            if (!System.IO.Directory.Exists(savedirectory))
                System.IO.Directory.CreateDirectory(savedirectory);
            Construct_Id();
            ofilename += id_unique.ToString();
            ofilename += " - " + type.ToString();
        }

        private void Construct_Id()
        {
            DateTime dt = DateTime.Now;
            id_unique = dt.Year;
            id_unique = id_unique * 1000 + dt.DayOfYear;
            id_unique = id_unique * 100 + dt.Hour;
            id_unique = id_unique * 100 + dt.Minute;
            id_unique = id_unique * 100 + dt.Second;
        }
    }
}
