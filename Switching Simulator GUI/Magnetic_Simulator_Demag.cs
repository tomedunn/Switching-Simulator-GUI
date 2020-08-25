using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NPack;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using MLApp;

namespace WindowsFormsApplication1
{

    class Magnetic_Simulator_Demag
    {
        // creates the sql connection and data adapter to be used in these parts of the program
        SqlConnection con_sw_database = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom Physics\\Documents\\Visual Studio 2010\\Projects\\Switching Simulator GUI\\Switching Simulator GUI\\Switching_DB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlDataAdapter da_sw_database = new SqlDataAdapter();
        

        // determines if there is a simulation with the current parameters and if one exists
        // saves the id for use later
        private bool Check_Exists_Get_ID(ref Magnetic_Parameters mp)
        {
            bool exists = true;
            // Creates the select command used to determine whether or not there is an entry already with
            // these parameters.
            da_sw_database.SelectCommand = new SqlCommand("SELECT * FROM parameters WHERE magnetization = @magnetization AND d_th = @d_th"
                +" AND alpha = @alpha AND area = @area AND thickness = @thickness AND nxx = @nxx AND nyy = @nyy AND nzz = @nzz"
                +" AND hx = @hx AND hy = @hy AND hz = @hz AND j_dc = @j_dc AND px = @px AND py = @py AND pz = @pz AND delta_time = @delta_time"
                +" AND type = @type"
                , con_sw_database);
            da_sw_database.SelectCommand.Parameters.Add("@magnetization", SqlDbType.Float).Value = mp.magn;
            da_sw_database.SelectCommand.Parameters.Add("@d_th", SqlDbType.Float).Value = mp.d_th;
            da_sw_database.SelectCommand.Parameters.Add("@alpha", SqlDbType.Float).Value = mp.alpha;
            da_sw_database.SelectCommand.Parameters.Add("@area", SqlDbType.Float).Value = mp.area;
            da_sw_database.SelectCommand.Parameters.Add("@thickness", SqlDbType.Float).Value = mp.thick;
            da_sw_database.SelectCommand.Parameters.Add("@nxx", SqlDbType.Float).Value = mp.nxx;
            da_sw_database.SelectCommand.Parameters.Add("@nyy", SqlDbType.Float).Value = mp.nyy;
            da_sw_database.SelectCommand.Parameters.Add("@nzz", SqlDbType.Float).Value = mp.nzz;
            da_sw_database.SelectCommand.Parameters.Add("@hx", SqlDbType.Float).Value = mp.hx;
            da_sw_database.SelectCommand.Parameters.Add("@hy", SqlDbType.Float).Value = mp.hy;
            da_sw_database.SelectCommand.Parameters.Add("@hz", SqlDbType.Float).Value = mp.hz;
            da_sw_database.SelectCommand.Parameters.Add("@j_dc", SqlDbType.Float).Value = mp.j_dc;
            da_sw_database.SelectCommand.Parameters.Add("@px", SqlDbType.Float).Value = mp.px;
            da_sw_database.SelectCommand.Parameters.Add("@py", SqlDbType.Float).Value = mp.py;
            da_sw_database.SelectCommand.Parameters.Add("@pz", SqlDbType.Float).Value = mp.pz;
            da_sw_database.SelectCommand.Parameters.Add("@delta_time", SqlDbType.Float).Value = mp.delta_time;
            da_sw_database.SelectCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = mp.type;
            // runs the query to see if there is an entry with these parameters
            con_sw_database.Open();
            try
            {
                mp.id = Int32.Parse(da_sw_database.SelectCommand.ExecuteScalar().ToString());
            }
            catch
            {
                mp.id = 0;
                exists = false;
            }
            con_sw_database.Close();
            return exists;
        }

        // adds parameters for a new set of trials
        private void Add_Parameters(Magnetic_Parameters mp)
        {
            da_sw_database.InsertCommand = new SqlCommand("INSERT INTO parameters ( magnetization, d_th, alpha, area, thickness, nxx, nyy,"
                + "nzz, hx, hy, hz, j_dc, px, py, pz, delta_time, type) VALUES (@magnetization, @d_th, @alpha, @area, @thickness, @nxx, @nyy,"
                + "@nzz, @hx, @hy, @hz, @j_dc, @px, @py, @pz, @delta_time, @type)", con_sw_database);
            da_sw_database.InsertCommand.Parameters.Add("@magnetization", SqlDbType.Float).Value = mp.magn;
            da_sw_database.InsertCommand.Parameters.Add("@d_th", SqlDbType.Float).Value = mp.d_th;
            da_sw_database.InsertCommand.Parameters.Add("@alpha", SqlDbType.Float).Value = mp.alpha;
            da_sw_database.InsertCommand.Parameters.Add("@area", SqlDbType.Float).Value = mp.area;
            da_sw_database.InsertCommand.Parameters.Add("@thickness", SqlDbType.Float).Value = mp.thick;
            da_sw_database.InsertCommand.Parameters.Add("@nxx", SqlDbType.Float).Value = mp.nxx;
            da_sw_database.InsertCommand.Parameters.Add("@nyy", SqlDbType.Float).Value = mp.nyy;
            da_sw_database.InsertCommand.Parameters.Add("@nzz", SqlDbType.Float).Value = mp.nzz;
            da_sw_database.InsertCommand.Parameters.Add("@hx", SqlDbType.Float).Value = mp.hx;
            da_sw_database.InsertCommand.Parameters.Add("@hy", SqlDbType.Float).Value = mp.hy;
            da_sw_database.InsertCommand.Parameters.Add("@hz", SqlDbType.Float).Value = mp.hz;
            da_sw_database.InsertCommand.Parameters.Add("@j_dc", SqlDbType.Float).Value = mp.j_dc;
            da_sw_database.InsertCommand.Parameters.Add("@px", SqlDbType.Float).Value = mp.px;
            da_sw_database.InsertCommand.Parameters.Add("@py", SqlDbType.Float).Value = mp.py;
            da_sw_database.InsertCommand.Parameters.Add("@pz", SqlDbType.Float).Value = mp.pz;
            da_sw_database.InsertCommand.Parameters.Add("@delta_time", SqlDbType.Float).Value = mp.delta_time;
            da_sw_database.InsertCommand.Parameters.Add("@type", SqlDbType.VarChar).Value = mp.type;
            con_sw_database.Open();
            da_sw_database.InsertCommand.ExecuteNonQuery();
            con_sw_database.Close();
        }

        // saves the data for a trial to the database
        private void Save_Trial_Switching(Magnetic_Parameters mp, double initial_energy, double switching_time)
        {            
            da_sw_database.InsertCommand = new SqlCommand("INSERT INTO trials_switching (id_parameters, initial_energy, switching_time) "
                + "VALUEs (@id_parameters, @initial_energy, @switching_time)", con_sw_database);
            da_sw_database.InsertCommand.Parameters.Add("@id_parameters", SqlDbType.Int).Value = mp.id;
            da_sw_database.InsertCommand.Parameters.Add("@initial_energy", SqlDbType.Float).Value = initial_energy;
            da_sw_database.InsertCommand.Parameters.Add("@switching_time", SqlDbType.Float).Value = switching_time;
            con_sw_database.Open();
            da_sw_database.InsertCommand.ExecuteNonQuery();
            con_sw_database.Close();
        }

        private void Save_Trial_Noise(Magnetic_Parameters mp, double time, double theta, ref StreamWriter outfile){
            //string dataout;

           


            // something like this will be used eventually but for now stick with standard text file writing.
            //string minmax;
            //minmax = (max) ? "MAXIMUM" : "MINIMUM";
            //da_sw_database.InsertCommand = new SqlCommand("INSERT INTO trials_noise (id_parameters, time, theta, minmax) "
            //    + "VALUES (@id_parameters, @time, @theta, @minmax)", con_sw_database);
            //da_sw_database.InsertCommand.Parameters.Add("@id_parameters", SqlDbType.Int).Value = mp.id;
            //da_sw_database.InsertCommand.Parameters.Add("@time", SqlDbType.Float).Value = time;
            //da_sw_database.InsertCommand.Parameters.Add("@theta", SqlDbType.Float).Value = theta;
            //da_sw_database.InsertCommand.Parameters.Add("@minmax", SqlDbType.NVarChar).Value = minmax;
            //con_sw_database.Open();
            //da_sw_database.InsertCommand.ExecuteNonQuery();
            //con_sw_database.Close();
        }

        //calulates the number of trials with a specific id
        private int Number_of_Trials(Magnetic_Parameters mp)
        {
            int count;
            da_sw_database.SelectCommand = new SqlCommand("SELECT COUNT(*) FROM trials_switching WHERE id_parameters = @id_parameters", con_sw_database);
            da_sw_database.SelectCommand.Parameters.Add("@id_parameters", SqlDbType.Int).Value = mp.id;
            // runs the query to count the number of trials for a specific id
            con_sw_database.Open();
            try
            {
                count = (int)da_sw_database.SelectCommand.ExecuteScalar();
            }
            catch
            {
                count = 0;
            }
            con_sw_database.Close();
            return count;
        }

        public void Switching_Time_Loop(ref Magnetic_Parameters mp, int trials, ref TextBox TB_ent, ref ProgressBar Prog_Bar)
        {
            int i;
            double time, energy;
            double theta, phi;
            double total_time = 0.0;
            // first checks to see if a simulation already exists. If it does not asks to add a simulation. If it does asks to append that simulation.
            //if (Check_Exists_Get_ID(ref mp))
            //{
            //    var resultsMB = MessageBox.Show("A simulation with " + Number_of_Trials(mp).ToString() 
            //        +" trials and these parameters already exists with ID = " + mp.id.ToString() + "."
            //        +" Whould you like to add " + trials.ToString() + " new trials to this simulation?", "", MessageBoxButtons.YesNo);
            //    if (resultsMB == DialogResult.Yes)
            //    {
            //        Add_Parameters(mp);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    var resultsMB = MessageBox.Show("No simulation with these parameters exists. Would you like to create one?","", MessageBoxButtons.YesNo);
            //    if (resultsMB == DialogResult.No)
            //    {
            //        return;
            //    }
            //}
            // runs the major loop for some number of trials as declared above

            string ofilename = null;
            mp.Construct_File_Name(ref ofilename);
            ofilename += ".dat";
            StreamWriter outfile = new StreamWriter(ofilename);
            outfile.WriteLine("Header");
            for (i = 1; i <= trials; i++)
            {
                theta = 0.01;
                phi = 0.01;
                // calculates the initial position of the magnetization
                Initial_Distribution(mp, 500.0, ref theta, ref phi);
                // calculates the switching time of the system given the initial condition given above
                time = Switching_Time(mp, ref theta, ref phi);
                energy = Energy(mp, theta, phi);
                outfile.WriteLine(i.ToString() + "\t" + time.ToString());
                //Save_Trial_Switching(mp, energy,time);
                total_time += time;
                // updates the average time in the window
                TB_ent.Text = (total_time / i).ToString();
                TB_ent.Refresh();
                // updates the progress bar in the window
                Prog_Bar.Value = 100 * i / trials;
                Prog_Bar.Update();
            };
            outfile.Close();
        }

        public void Initial_Energy_Loop(Magnetic_Parameters mp, double delta_time, int trials, ref TextBox TB_ent, ref ProgressBar Prog_Bar)
        {
            int i;
            double theta, phi, energy;
            double total_energy = 0.0;
            //System.IO.StreamWriter myfile;
            //myfile = new System.IO.StreamWriter("test.txt");

            for (i = 1; i <= trials; i++)
            {
                theta = 0.01;
                phi = 0.01;
                // calls the initial distribution function which lets the system reach thermal equalibrium
                Initial_Distribution(mp, 500.0, ref theta, ref phi);
                // calculates the energy of the configuration
                energy = Energy(mp, theta, phi);
                //myfile.WriteLine(energy.ToString());
                total_energy += energy;
                // updates the window with the new average energy
                TB_ent.Text = (total_energy / i).ToString();
                TB_ent.Refresh();
                // updates the window's progress bar with the new value
                Prog_Bar.Value = 100 * i / trials;
                Prog_Bar.Update();
            }
            //myfile.Close();
            //myfile = null;
        }

        public void Quality_Factor_Check(Magnetic_Parameters mp, double[] Q, int h_steps, ref MLApp.MLApp matlab, ProgressBar Prog_Bar)
        {
            int Q_steps = Q.Length;
            // Create and populate h array
            double h_min = 0.001;
            double h_max = 60;
            double dh = (h_max - h_min) / h_steps;
            double[] h = new double[h_steps];
            for (int i = 0; i < h_steps; i++)
            {
                h[i] = h_min + dh * (i + 0.5);
            }
            // Create E_max matrix
            double[,] E_max = new double[Q_steps,h_steps];
            // Loop over the Q values
            prgBar_reset(Prog_Bar, Q_steps*h_steps);
            for (int i = 0; i < Q_steps; i++)
            {
                double iQ = Q[i];
                // Loop over h values
                for (int j = 0; j < h_steps; j++)
                {
                    double ih = h[j];
                    mp.nxx = -mp.nzz * ih;
                    double omega_0 = Natural_Frequency(mp);
                    mp.period = 2 * Math.PI / omega_0;
                    mp.alpha = Math.Sqrt(1 + ih) / ((2 + ih) * 6 * iQ);
                    E_max[i,j] = Calculate_E_max(mp);
                    prgBar_update(Prog_Bar);
                }
            }
            Plot_Quality_Factor_Data(mp, E_max, Q, h, ref matlab);
        }

        public double Natural_Frequency(Magnetic_Parameters mp)
        {
            double nzz = mp.nzz;
            double nxx = mp.nxx;
            double nyy = mp.nyy;

            double Hx = nxx - nyy;
            double Hz = nyy - nzz;

            return Math.Sqrt(Hz * (Hx + Hz));
        }

        public double Calculate_E_max(Magnetic_Parameters mp)
        {
            MersenneTwister MTrand = new MersenneTwister();
            double time = 0;
            double dt = mp.delta_time;
            double theta = 0.01;
            double phi = MTrand.NextDoublePositive();
            double dtMax = 1;
            int N = 5;
            double tMax = N*mp.period;

            double E_min = Energy(mp, 0.0, 0.0);
            double E_max = E_min;
            while (time <= tMax)
            {
                double j_total = mp.j_dc;
                if (mp.j_ac != 0 && mp.period != 0)
                {
                    j_total += mp.j_ac * Math.Sin(time * 2 * Math.PI / mp.period);
                }
                RK42(mp, ref dt, dtMax, j_total, ref theta, ref phi, ref time);
                if (mp.d_sh != 0 || mp.d_th != 0)
                {
                    Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                }
                Coord_Correction(ref theta, ref phi);
                double E = Energy(mp, theta, phi);
                if (E > E_max)
                {
                    E_max = E;
                }
            }
            return E_max - E_min;
        }

        public void Plot_Quality_Factor_Data(Magnetic_Parameters mp, double[,] E_max, double[] Q, double[] h, ref MLApp.MLApp matlab)
        {
            double E_min = Energy(mp, 0.0, 0.0);
            double E_sad = Energy(mp, 0.5 * Math.PI, 0.5 * Math.PI);
            double E_b = E_sad - E_min;
            matlab.PutWorkspaceData("E_max", "base", E_max);
            matlab.PutWorkspaceData("h", "base", h);
            matlab.PutWorkspaceData("Q", "base", Q);
            matlab.PutWorkspaceData("E_b", "base", E_b);
            matlab.Execute("h_steps = length(h);");
            matlab.Execute("Q_steps = length(Q);");
            matlab.Execute("for i=1:Q_steps;lgd{i} = sprintf('Q = %.1f',Q(i));end;");
            matlab.Execute("cd('" + mp.savedirectory + "');");
            matlab.Execute("f = figure;hold all;");
            for (int i = 1; i <= Q.Length; i++)
            {
                matlab.Execute("plot(h,E_max(" + i + ",:)/E_b,'LineWidth',2);");
            }
            matlab.Execute("axis([0,max(h),0,1.2]);");
            matlab.Execute("xlabel('h','FontSize',18);");
            matlab.Execute("ylabel('E_{max/}E_b','FontSize',18');");
            matlab.Execute("set(gca,'FontSize',18,'linewidth',2)");
            matlab.Execute("legend(lgd,'FontSize',12);box;");
            matlab.Execute("save('E_max_vs_h_data');");
            matlab.Execute("saveas(f,'E_max_vs_h.fig');");
        }

        public void Noise_Analyser(Magnetic_Parameters mp, double MaxTime, ref ProgressBar Prog_Bar, ref TextBox tbThetaAverage, ref TextBox tbPhiAverage, string filename2)
        {
            MersenneTwister MTrand = new MersenneTwister();
            double theta, phi, time;
            double dt = mp.delta_time;
            double CalibrationTime = 20000;
            double Theta_Average, Phi_Average, LocTime = 0, LocMin, LocMax;
            bool Max = true;
            int m = 0, i = 0;
            Theta_Average = Phi_Average = 0;
            theta = 0.01;
            phi = 0.01;
            time = 0.0;
            // lets the system come into equilibrium
            Find_Noise_Average(mp, mp.j_dc, 2000.0, ref theta, ref phi, ref Theta_Average, ref Phi_Average);
            // find the average theta to be used later
            Find_Noise_Average(mp, mp.j_dc, CalibrationTime, ref theta, ref phi, ref Theta_Average, ref Phi_Average);
            tbThetaAverage.Text = (Theta_Average * 180 / Math.PI).ToString();
            tbPhiAverage.Text = (Phi_Average * 180 / Math.PI).ToString();
            tbThetaAverage.Refresh();
            tbPhiAverage.Refresh();
            // lets the system run picking out the maximas and minimas
            LocMin = LocMax = Theta_Average;

            string filename,outstring;
            filename = "C:\\Users\\Tom Physics\\Desktop\\full data.dat";
            //filename2 = "C:\\Users\\Tom Physics\\Desktop\\maxima data.dat";

            StreamWriter outfile = new StreamWriter(filename);
            StreamWriter outfile2 = new StreamWriter(filename2);

            while (time <= MaxTime)
            {
                RK4(mp, ref dt, mp.j_dc, ref theta, ref phi, ref time);
                Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                Coord_Correction(ref theta, ref phi);
                if (i % 1000 == 0)
                {
                    Prog_Bar.Value = (Int32)(100 * time / MaxTime);
                    Prog_Bar.Update();
                }
                // Pick out maximums and minimums
                if (i % 10 == 0)
                {
                    outstring = time.ToString() + "\t" + theta.ToString();
                    //outfile.WriteLine(outstring);
                    Find_Local_Max(ref m, theta, time, Theta_Average, ref LocMin, ref LocMax, ref LocTime, ref Max, ref outfile2);
                };
                i++;
            }
            outfile.Close();
            outfile2.Close();
        }

        void Find_Local_Max(ref int m, double theta, double time, double Theta_Average, ref double LocMin, ref double LocMax, ref double LocTime, ref bool Max, ref StreamWriter outfile)
        {
            // check for a max
            m++;
            if (Max == true && (theta - Theta_Average) > 0)
            {
                if (theta > LocMax)
                {
                    LocMax = theta;
                    LocTime = time;
                };
            };
            if (Max == true && (theta - Theta_Average) <= 0)
            {
                if (m > 10)
                {
                    outfile.WriteLine(LocTime.ToString() + "\t" + (LocMax - Theta_Average).ToString());
                };
                //MessageBox.Show(LocTime.ToString() + "\t" + LocMax.ToString());
                LocMax = Theta_Average;
                Max = false;
                m = 0;
            };
            if (Max == false && (theta - Theta_Average) < 0)
            {
                if (theta < LocMin)
                {
                    LocMin = theta;
                    LocTime = time;
                };
            };
            if (Max == false && (theta - Theta_Average) > 0)
            {
                if (m > 10)
                {
                    outfile.WriteLine(LocTime.ToString() + "\t" + (LocMin - Theta_Average).ToString());
                };
                LocMin = Theta_Average;
                Max = true;
                m = 0;
            }
        }

        // Sets up the initial distribution by letting the system evolve with no spin current
        // for some period of time
        public void Initial_Distribution(Magnetic_Parameters mp, double time, ref double theta, ref double phi)
        {
            double t = 0;
            double dt = mp.delta_time;
            MersenneTwister MTrand = new MersenneTwister();
            while(t <= time)
            {
                RK42(mp, ref dt, 10.0, 0.0, ref theta, ref phi, ref t);
                Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                Coord_Correction(ref theta, ref phi);
            }
        }

        // Finds the average oscilation position used in noise analysis
        private void Find_Noise_Average(Magnetic_Parameters mp, double j, double timeMax, ref double theta, ref double phi, ref double ThetaAverage, ref double PhiAverage)
        {
            int i;
            double dt = mp.delta_time;
            double time = 0;
            double Theta_Average = 0.0;
            double Phi_Average = 0.0;
            MersenneTwister MTrand = new MersenneTwister();
            for (i = 0; time <= timeMax; i++)
            {
                RK4(mp, ref dt, j, ref theta, ref phi, ref time);
                Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                Coord_Correction(ref theta, ref phi);
                Theta_Average += theta;
                Phi_Average += phi;
            }
            ThetaAverage = mp.delta_time * Theta_Average / timeMax;
            PhiAverage = mp.delta_time * Phi_Average / timeMax;
        }

        // calculates the switching time. The initial conditions should be set by the Initial_Distribution 
        // method unless specifically desired otherwise
        private double Switching_Time(Magnetic_Parameters mp, ref double theta, ref double phi)
        {
            double time = 0.0;
            double dt = mp.delta_time;
            double j_total = 0.0;
            MersenneTwister MTrand = new MersenneTwister();
            // finds the switching time by allowing the system to run until the magnetization has
            // passed the saddle point at theta = PI/2
            while (theta <= Math.PI / 2 )
            {
                //j_total = mp.j_dc*time/(600.0);
                //if (j_total > mp.j_dc)
                //{
                    j_total = mp.j_dc;
                //}
                if (mp.j_ac != 0 && mp.period != 0)
                {
                    j_total += mp.j_ac * Math.Cos(time * 2 * Math.PI / mp.period);
                }
                RK42(mp, ref dt, 0.1, j_total, ref theta, ref phi, ref time);
                Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                Coord_Correction(ref theta, ref phi);
                if (time > 10000 && Convert.ToInt32(time) == time)
                {
                    MessageBox.Show(time.ToString() + " - " + Energy(mp, theta, phi).ToString());
                }
            }

            return time;
        }

        

        public void Ac_Switching_A_w_Phase_Space(Magnetic_Parameters mp, int trials, double Pmin, double Pmax, int nw,
            double IMin, double IMax, int nA, double Cycles, string type, TextBox TB, ProgressBar Prog_Bar)
        {
            double wMin = 2 * Math.PI / Pmax;
            double wMax = 2 * Math.PI / Pmin;
            double dw = (wMax - wMin) / nw;
            double[] w = new double[nw];
            double AMin = IMin;
            double AMax = IMax;
            double dA = (AMax - AMin) / nA;
            double[,] Psw = new double[nw, nA];
            double[] A = new double[nA];
            List<int> Al = new List<int>();
            prgBar_reset(Prog_Bar, nw * nA);

            for (int iw = 0; iw < nw; iw++)
            {
                w[iw] = wMin + (iw + 0.5) * dw;
            }
            for (int iA = 0; iA < nw; iA++)
            {
                A[iA] = AMin + (iA + 0.5) * dA;
                Al.Add(iA);
            }
            for (int iw = 0; iw < nw; iw++)
            {
                //Parallel.ForEach(Al, iAl =>
                //{
                //    Magnetic_Parameters mptemp = mp;
                //    mptemp.j_dc = 0.0;
                //    mptemp.j_ac = A[iAl];
                //    mptemp.period = 2 * Math.PI / w[iw];
                //    double tMax = mptemp.period * 2.0;
                //    mptemp.h_on = false;
                //    lock (this)
                //    {
                //        Psw[iw, iAl] = Ac_Switching_A_w_Phase_Space_Prob_Finder(mptemp, trials, tMax);
                //    }
                //    prgBar_update(Prog_Bar);
                //    tb_update(TB, (iw * nw + iAl).ToString());
                //});

                for (int iA = 0; iA < nA; iA++)
                {
                    if (type == "DC")
                    {
                        mp.j_dc = A[iA];
                        mp.j_ac = 0.0;
                        Cycles = 1;
                    }
                    else
                    {
                        mp.j_dc = 0.0;
                        mp.j_ac = A[iA];
                    }
                    mp.period = 2 * Math.PI / w[iw];
                    double tMax = mp.period * Cycles;
                    mp.h_on = false;
                    Psw[iw, iA] = Ac_Switching_A_w_Phase_Space_Prob_Finder(mp, trials, tMax);
                    tb_update(TB, (iw * nw + iA).ToString());
                    prgBar_update(Prog_Bar);
                }
            }
            Save_Phase_Space_Data(mp, Psw, w, A, nw, nA);
            Plot_Phase_Space_Data(mp, Psw, w, A, Cycles);
        }

        public void tb_update(TextBox tb, string text)
        {
            tb.Invoke((MethodInvoker)delegate{
                tb.Text = text;
                tb.Update();
            });

        }
        public double Ac_Switching_A_w_Phase_Space_Prob_Finder(Magnetic_Parameters mp, int trials, double tMax)
        {
            double prob = 0.0;
            //double j_total;
            MersenneTwister MTrand = new MersenneTwister();
            int total = 0;
            //for (int itrials = 0; itrials < trials; itrials++)
            //{
            //    total += (int)Ac_Switching_A_w_Phase_Space_Prob_Finder_Trial(mp, tMax);
            //}


            Parallel.For<int>(0, trials, () => 0, (itrials, loop, subtotal) =>
                {
                    subtotal += (int)Ac_Switching_A_w_Phase_Space_Prob_Finder_Trial(mp, tMax);
                    return subtotal;
                },
                (x) => Interlocked.Add(ref total, x)
            );

            prob = (total / (double)trials);
            return prob;
        }

        private double Ac_Switching_A_w_Phase_Space_Prob_Finder_Trial(Magnetic_Parameters mp, double tMax)
        {
            MersenneTwister MTrand = new MersenneTwister();
            double j_total = 0.0;
            double theta = 0.01;
            double phi = 2 * Math.PI * MTrand.NextDoublePositive();
            double t = 0.0;
            double dt = 0.01;
            double dtMax = 1;
            // lets the trial come into thermal equilibrium before running
            if (mp.d_th != 0)
            {
                Initial_Distribution(mp, 500.0, ref theta, ref phi);
            }
            //mp.j_on = true;
            //mp.h_on = true;
            while (t <= tMax)
            {
                j_total = mp.j_dc;
                if (mp.j_ac != 0 && mp.period != 0)
                {
                    j_total += mp.j_ac * Math.Sin(t * 2 * Math.PI / mp.period);
                }
                RK42(mp, ref dt, dtMax, j_total, ref theta, ref phi, ref t);
                if (mp.d_sh != 0 || mp.d_th != 0)
                {
                    Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                }
                Coord_Correction(ref theta, ref phi);
            }
            //mp.j_on = false;
            //mp.h_on = false;
            return Switching_Prob(ref mp, dt, false, theta, phi, t);
        }


        public void Save_Phase_Space_Data(Magnetic_Parameters mp, double[,] Psw, double[] w, double[] A, int nw, int nA)
        {
            string ofilename = null;
            mp.Construct_File_Name(ref ofilename);
            ofilename += ".dat";
            StreamWriter outfile = new StreamWriter(ofilename);
            Write_Header(mp, ref outfile);

            outfile.WriteLine("-- w-meshgrid --");
            for (int iA = 0; iA < nA; iA++)
            {
                for (int iw = 0; iw < nw; iw++)
                {
                    outfile.Write((w[iw]).ToString() + "\t");
                }
                outfile.WriteLine();
            }

            outfile.WriteLine("-- A-meshgrid --");
            for (int iA = 0; iA < nA; iA++)
            {
                for (int iw = 0; iw < nw; iw++)
                {
                    outfile.Write((A[iA]).ToString() + "\t");
                }
                outfile.WriteLine();
            }

            outfile.WriteLine("-- Psw-meshgrid --");
            for (int iA = 0; iA < nA; iA++)
            {
                for (int iw = 0; iw < nw; iw++)
                {
                    outfile.Write((Psw[iw,iA]).ToString() + "\t");
                }
                outfile.WriteLine();
            }
            outfile.Close();
        }

        private void Plot_Phase_Space_Data(Magnetic_Parameters mp, double[,] Psw, double[] w, double[] A, double tau)
        {

            MLApp.MLApp matlab = new MLApp.MLApp();
            matlab.PutWorkspaceData("w", "base", w);
            matlab.PutWorkspaceData("A", "base", A);
            matlab.PutWorkspaceData("Psw", "base", Psw);

            matlab.Execute("cd('" + mp.savedirectory + "');");
            matlab.Execute("[mgw,mgA] = meshgrid(w,A);");
            matlab.Execute("v = 0:0.1:1;");
            matlab.Execute("f = figure;");
            matlab.Execute("contourf(mgw,mgA,Psw',v);");
            matlab.Execute("caxis([0, 1]);");
            matlab.Execute("xlabel('frequency');");
            matlab.Execute("ylabel('Spin Current - I_{st}');");
            matlab.Execute("colorbar('eastoutside');");
            matlab.Execute("title('Switching Probability Phase Space: \\tau = " + tau.ToString() + "');");
            matlab.Execute("saveas(f,'PswPS.fig');");
            matlab.Execute("saveas(f,'PswPS.pdf');");
            matlab.Execute("delete(f);");
            matlab.Quit();
            matlab = null;
        }

        public void Switching_Probability_Loop(ref MLApp.MLApp matlab, Magnetic_Parameters mp, int trials, int steps, double Time_Pulse, bool dpulse, ref TextBox TB_ent, ProgressBar Prog_Bar)
        {
            double[] prob = new double[steps];
            double[] tmax = new double[steps];
            double dt_step = Time_Pulse / steps;
            for (int istep = 0; istep < steps; istep++)
            {
                prob[istep] = 0.0;
                tmax[istep] = (istep + 1) * Time_Pulse / steps;
            }
            
            List<int> itrials = new List<int>();
            for (int itrial = 0; itrial < trials; itrial++)
            {
                itrials.Add(itrial);
            }

            // first checks to see if a simulation already exists. If it does not asks to add a simulation. If it does asks to append that simulation.
            //if (Check_Exists_Get_ID(ref mp))
            //{
            //    var resultsMB = MessageBox.Show("A simulation with " + Number_of_Trials(mp).ToString() 
            //        +" trials and these parameters already exists with ID = " + mp.id.ToString() + "."
            //        +" Whould you like to add " + trials.ToString() + " new trials to this simulation?", "", MessageBoxButtons.YesNo);
            //    if (resultsMB == DialogResult.Yes)
            //    {
            //        Add_Parameters(mp);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    var resultsMB = MessageBox.Show("No simulation with these parameters exists. Would you like to create one?","", MessageBoxButtons.YesNo);
            //    if (resultsMB == DialogResult.No)
            //    {
            //        return;
            //    }
            //}
            // runs the major loop for some number of trials as declared above

            prgBar_reset(Prog_Bar, mp.trials);

            Parallel.ForEach(itrials, itrial =>
            {
                MersenneTwister MTrand = new MersenneTwister();
                Magnetic_Parameters mptemp = mp;
                //double prob = 0.0;
                double theta = 0.01;
                double phi = itrial * 2 * Math.PI / trials;
                double time = 0.0;
                double dt = 0.01;
                double j_total;
                // lets the trial come into thermal equilibrium before running
                if (mp.d_th != 0)
                {
                    Initial_Distribution(mptemp, 500.0, ref theta, ref phi);
                }
                int istep = 0;
                //mp.j_on = true;
                mptemp.h_on = true;
                while (time <= tmax[steps - 1])
                {
                    j_total = mptemp.j_dc;
                    if (mptemp.j_ac != 0 && mptemp.period != 0)
                    {
                        j_total += mptemp.j_ac * Math.Cos(time * 2 * Math.PI / mptemp.period);
                    }
                    RK42(mptemp, ref dt, dt_step * 0.1, j_total, ref theta, ref phi, ref time);
                    if (mptemp.d_sh != 0 || mptemp.d_th != 0)
                    {
                        Noise(mptemp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                    }
                    Coord_Correction(ref theta, ref phi);
                    if (time > tmax[istep])
                    {
                        double p = Switching_Prob(ref mptemp, dt, dpulse, theta, phi, time) / trials;
                        lock (this)
                        {
                            prob[istep] += p;
                        }
                        istep++;
                    }
                }
                prgBar_update(Prog_Bar);
            });
            Save_Switching_Probability(ref matlab, mp, tmax, prob, steps, dpulse);
        }

        private void prgBar_reset(ProgressBar prgBar, int trials)
        {
            prgBar.Invoke((MethodInvoker)delegate
            {
                prgBar.Maximum = trials;
                prgBar.Value = 0;
                prgBar.Update();
            });
        }

        private void prgBar_update(ProgressBar prgBar)
        {
            prgBar.Invoke((MethodInvoker)delegate
            {
                prgBar.Value++;
                prgBar.Update();
            });
        }
        

        public double Switching_Prob(ref Magnetic_Parameters mp, double Dt, bool dpulse, double theta, double phi, double Time)
        {
            double time = 0.0;
            double dt = Dt;
            double j_total = 0.0;
            double th = theta;
            double ph = phi;
            double tmax = 200.0;
            MersenneTwister MTrand = new MersenneTwister();
            bool h_on = mp.h_on;
            bool j_on = mp.j_on;
            if (dpulse)
            {
                while (time < Time)
                {
                    j_total = -mp.j_dc;
                    RK42(mp, ref dt, 1.0, j_total, ref th, ref ph, ref time);
                    if (mp.d_sh != 0 || mp.d_th != 0)
                    {
                        Noise(mp, dt, ref th, ref ph, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                    }
                    Coord_Correction(ref th, ref ph);
                }
            }

            // allows the system to evolve until the energy has been lowered below the saddle point
            mp.h_on = false;
            mp.j_on = false;
            double E_sad = Energy(mp, Math.PI / 2, Math.PI / 2);
            while (Energy(mp, th, ph) > E_sad)
            {
                j_total = 0.0;
                RK42(mp, ref dt, 10.0, j_total, ref th, ref ph, ref time);
                if (mp.d_sh != 0 || mp.d_th != 0)
                {
                    Noise(mp, dt, ref th, ref ph, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                }
                Coord_Correction(ref th, ref ph);
            }
            // lets the system evolve for some extra time to make sure thermal noise won't cause a switch
            time = 0.0;
            while (time < tmax)
            {
                j_total = 0;
                RK42(mp, ref dt, 1.0, j_total, ref th, ref ph, ref time);
                if (mp.d_sh != 0 || mp.d_th != 0)
                {
                    Noise(mp, dt, ref th, ref ph, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                }
                Coord_Correction(ref th, ref ph);
            }
            mp.h_on = h_on;
            mp.j_on = j_on;
            // if theta is greater then pi/2 the system has switched. Lower than that and it has not.
            if (th > Math.PI / 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void Save_Switching_Probability(ref MLApp.MLApp matlab, Magnetic_Parameters mp, double[] tmax, double[] prob, int steps, bool dpulse)
        {
            string ofilename = null;
            mp.Construct_File_Name(ref ofilename);
            ofilename += ".dat";
            StreamWriter outfile = new StreamWriter(ofilename);
            Write_Header(mp, ref outfile);
            for (int istep = 0; istep < steps; istep++)
            {
                outfile.WriteLine(tmax[istep].ToString() + "\t" + (prob[istep]).ToString());
            }
            outfile.Close();

            for (int istep = 0; istep < steps; istep++)
            {
                tmax[istep] = tmax[istep] / (mp.magn * 4 * Math.PI * mp.gamma);
            }
            try
            {
                matlab.PutWorkspaceData("t", "base", tmax);
                matlab.PutWorkspaceData("p", "base", prob);
                if (dpulse)
                {
                    matlab.Execute("cd('" + mp.savedirectory + "');");
                    matlab.Execute("f = figure;");
                    matlab.Execute("plot(2*t,p);");
                    matlab.Execute("xlabel('time');");
                    matlab.Execute("ylabel('switching probability');");
                    matlab.Execute("title('Switching Probability');");
                    matlab.Execute("saveas(f,'pvt.fig');");
                    //matlab.Execute("saveas(f,'pvt.pdf');");
                }
                else
                {
                    matlab.Execute("cd('" + mp.savedirectory + "');");
                    matlab.Execute("f = figure;");
                    matlab.Execute("plot(t,p);");
                    matlab.Execute("xlabel('time');");
                    matlab.Execute("ylabel('switching probability');");
                    matlab.Execute("title('Switching Probability: Ist = " + (Math.Round(mp.j_dc, 5)).ToString() + "');");
                    matlab.Execute("saveas(f,'pvt.fig');");
                    matlab.Execute("saveas(f,'pvt.pdf');");
                    //matlab.Execute("delete(f);");
                }
            }
            catch
            {
            }
        }

        private void Write_Header(Magnetic_Parameters mp, ref StreamWriter OutFile)
        {
            OutFile.WriteLine("Unique ID" + "\t" + mp.id_unique.ToString());
            OutFile.WriteLine("type" + "\t" + mp.type.ToString());
            OutFile.WriteLine("trials" + "\t" + mp.trials.ToString());
            OutFile.WriteLine("M" + "\t" + mp.magn.ToString());
            OutFile.WriteLine("d_th" + "\t" + mp.d_th.ToString());
            OutFile.WriteLine("alpha" + "\t" + mp.alpha.ToString());
            OutFile.WriteLine("area" + "\t" + mp.area.ToString());
            OutFile.WriteLine("thick" + "\t" + mp.thick.ToString());
            OutFile.WriteLine("nxx" + "\t" + mp.nxx.ToString());
            OutFile.WriteLine("nyy" + "\t" + mp.nyy.ToString());
            OutFile.WriteLine("nzz" + "\t" + mp.nzz.ToString());
            OutFile.WriteLine("hx" + "\t" + mp.hx.ToString());
            OutFile.WriteLine("hy" + "\t" + mp.hy.ToString());
            OutFile.WriteLine("hz" + "\t" + mp.hz.ToString());
            OutFile.WriteLine("j_dc" + "\t" + mp.j_dc.ToString());
            OutFile.WriteLine("j_ac" + "\t" + mp.j_ac.ToString());
            OutFile.WriteLine("period" + "\t" + mp.period.ToString());
            OutFile.WriteLine("px" + "\t" + mp.px.ToString());
            OutFile.WriteLine("py" + "\t" + mp.py.ToString());
            OutFile.WriteLine("pz" + "\t" + mp.pz.ToString());
            OutFile.WriteLine("pxf" + "\t" + mp.pxf.ToString());
            OutFile.WriteLine("pyf" + "\t" + mp.pyf.ToString());
            OutFile.WriteLine("pzf" + "\t" + mp.pzf.ToString());
            OutFile.WriteLine("End Header");
        }


        private struct Traj_Coord
        {
            public double time;
            public double j;
            public double theta;
            public double phi;

        }
        // calculates the switching time. The initial conditions should be set by the Initial_Distribution 
        // method unless specifically desired otherwise
        public void Magnetic_Trajectory(ref MLApp.MLApp matlab ,ref Magnetic_Parameters mp, string type, double time_min, double time_max, double time_p, double time_dp,
            double theta_max, double dtstep, bool save, bool initial_conditions)
        {
            double time = 0.0;
            double tstep = 0;
            double j_total = 0.0;
            double theta, phi;
            double t_AC = mp.tau*mp.period;
            double dt = mp.delta_time;
            int steps = Convert.ToInt32(Math.Truncate(time_max / dtstep)) + 1;
            Traj_Coord[] tc = new Traj_Coord[steps];
            int istep = 0;

            MersenneTwister MTrand = new MersenneTwister();
            // finds the switching time by allowing the system to run until the magnetization has
            // passed the saddle point at theta = PI/2
            if (initial_conditions)
            {
                theta = mp.theta_initial;
                phi = mp.phi_initial;
            }
            else
            {
                theta = 0.01;
                phi = 2 * Math.PI * MTrand.NextDoublePositive();
            }
            if (mp.d_th != 0)
            {
                mp.h_on = false;
                Initial_Distribution(mp, 500.0, ref theta, ref phi);
                mp.h_on = true;
            }
            // calculates the initial position of the magnetization
            //Initial_Distribution(mp, 500.0, ref theta, ref phi);
            while (/*theta <= theta_max &&*/ time < time_max)
            {
                j_total = 0.0;
                if (time <= t_AC)
                {
                    if (mp.j_ac != 0 && mp.period != 0)
                    {
                        j_total += mp.j_ac * Math.Cos(time * 2 * Math.PI / mp.period);
                    }
                }
                else
                {
                    j_total = mp.j_dc;
                }
                if (time > time_p)
                {
                    j_total = -mp.j_dc;
                }
                if (time > time_p + time_dp)
                {
                    j_total = 0.0;
                    mp.h_on = false;
                }

                RK42(mp, ref dt, 1.0, j_total, ref theta, ref phi, ref time);
                Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                Coord_Correction(ref theta, ref phi);
                if (time > tstep && time > time_min)
                {
                    tc[istep].time = time;
                    tc[istep].phi = phi;
                    tc[istep].theta = theta;
                    tc[istep].j = j_total;
                    tstep = (Math.Truncate(time / dtstep) + 1) * dtstep;
                    istep++;
                }
            }
            if (istep < steps)
            {
                steps = istep;
            }
            if (save == true)
            {
                Save_Trajectory(mp, type, steps, tc);
            }
            Plot_Trajectory(ref matlab, mp, type, steps, tc);
        }


        // calculates the switching time. The initial conditions should be set by the Initial_Distribution 
        // method unless specifically desired otherwise
        public void Magnetic_Trajectory_Fit_Alpha(ref Magnetic_Parameters mp, double time_min, double time_max, double time_p, double time_dp,
            double theta_max, double dtstep, bool save)
        {
            MLApp.MLApp matlab = new MLApp.MLApp();
            //matlab.Visible = 1;
            mp.period = 40;

            int asteps = 100;
            double da = 0.02 / asteps;
            mp.alpha = 0.000;

            Dictionary<double, double> AvL1 = new Dictionary<double, double>();
            Dictionary<double, double> AvL2 = new Dictionary<double, double>();
            Dictionary<double, double> AvEeq = new Dictionary<double, double>();
            Dictionary<double, double> Avdelta = new Dictionary<double, double>();
            MersenneTwister MTrand = new MersenneTwister();
            // finds the switching time by allowing the system to run until the magnetization has
            // passed the saddle point at theta = PI/2

            for (int ia = 0; ia < asteps; ia++)
            {
                int istep = 0;
                double time = 0.0;
                double tstep = 0;
                double j_total = 0.0;
                double theta, phi;
                double dt = mp.delta_time;
                int steps = Convert.ToInt32(Math.Truncate(time_max / dtstep)) + 1;
                Traj_Coord[] tc = new Traj_Coord[steps];

                mp.alpha = mp.alpha + da;
                mp.period = 35;

                theta = 0.01;
                phi = 2 * Math.PI * MTrand.NextDoublePositive();
                if (mp.d_th != 0)
                {
                    mp.h_on = false;
                    Initial_Distribution(mp, 500.0, ref theta, ref phi);
                    mp.h_on = true;
                }
                // calculates the initial position of the magnetization
                //Initial_Distribution(mp, 500.0, ref theta, ref phi);
                while (/*theta <= theta_max &&*/ time < time_max)
                {
                    j_total = mp.j_dc;

                    if (mp.j_ac != 0 && mp.period != 0)
                    {
                        j_total += mp.j_ac * Math.Cos(time * 2 * Math.PI / mp.period);
                    }
                    if (time > time_p)
                    {
                        j_total = -mp.j_dc;
                    }
                    if (time > time_p + time_dp)
                    {
                        j_total = 0.0;
                        mp.h_on = false;
                    }
                    RK42(mp, ref dt, 1.0, j_total, ref theta, ref phi, ref time);
                    Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                    Coord_Correction(ref theta, ref phi);
                    if (time > tstep && time > time_min)
                    {
                        tc[istep].time = time;
                        tc[istep].phi = phi;
                        tc[istep].theta = theta;
                        tc[istep].j = j_total;
                        tstep = (Math.Truncate(time / dtstep) + 1) * dtstep;
                        istep++;
                    }
                }

                if (istep < steps)
                {
                    steps = istep;
                }
                double L1, L2, Eeq, delta;
                L1 = L2 = Eeq = delta = 0;



                double[] ThA = new double[steps];
                double[] PhA = new double[steps];
                double[] TA = new double[steps];
                for (int i = 0; i < steps; i++)
                {
                    ThA[i] = tc[i].theta;
                    PhA[i] = tc[i].phi;
                    TA[i] = tc[i].time;
                }


                double ESad = Energy(mp, Math.PI / 2, Math.PI / 2);
                double EMin = Energy(mp, 0, Math.PI);

                double[] EA = new double[steps];
                for (int i = 0; i < steps; i++)
                {
                    double e = (Energy(mp, tc[i].theta, tc[i].phi) - EMin) / (ESad - EMin);
                    EA[i] = e;
                }

                matlab.Execute("cd('C:\\Users\\Tom\\Desktop\\Matlab');");
                matlab.PutWorkspaceData("t", "base", TA);
                matlab.PutWorkspaceData("En", "base", EA);
                matlab.PutWorkspaceData("th", "base", ThA);
                matlab.PutWorkspaceData("phi", "base", PhA);
                matlab.PutWorkspaceData("w", "base", 2 * Math.PI / mp.period);

                matlab.Execute("x = sin(th).*cos(phi);");

                matlab.Execute("Estimate = Damped_Oscillator_Fit(t,En);");
                matlab.Execute("Eos = Estimate(1);");
                matlab.Execute("Eeq = Estimate(2);");
                matlab.Execute("L1 = Estimate(3);");
                matlab.Execute("L2 = Estimate(4);");

                matlab.Execute("Estimate = Cos_Fit(w, t, x);");
                matlab.Execute("d = Estimate(2);");
                matlab.Execute("Eave = Eeq + Eos;");


                L1 = (double)matlab.GetVariable("L1", "base");
                L2 = (double)matlab.GetVariable("L2", "base");
                Eeq = (double)matlab.GetVariable("Eave", "base");
                delta = (double)matlab.GetVariable("d", "base");

                //MessageBox.Show("delta = " + delta.ToString());
                //Fit_Trajectory(mp, steps, tc, ref L1, ref L2);
                AvL1.Add(mp.alpha, L1);
                AvL2.Add(mp.alpha, L2);
                AvEeq.Add(mp.alpha, Eeq);
                Avdelta.Add(mp.alpha, delta);
            }

            Save_Fit(mp, "A vs L1", AvL1);
            Save_Fit(mp, "A vs L2", AvL2);
            Save_Fit(mp, "A vs Eeq", AvEeq);
            Save_Fit(mp, "A vs delta", Avdelta);
            matlab.Quit();
            matlab = null;
        }

        public void Magnetic_Trajectory_Fit_Freq(ref Magnetic_Parameters mp, double time_min, double time_max, double time_p, double time_dp,
            double theta_max, double dtstep, bool save)
        {
            MLApp.MLApp matlab = new MLApp.MLApp();
            //matlab.Visible = 1;
            int psteps = 100;
            double dp = -5.0 / psteps;
            mp.period = 40;

            Dictionary<double, double> WvL1 = new Dictionary<double, double>();
            Dictionary<double, double> WvL2 = new Dictionary<double, double>();
            Dictionary<double, double> WvEeq = new Dictionary<double, double>();
            Dictionary<double, double> Wvdelta = new Dictionary<double, double>();

            MersenneTwister MTrand = new MersenneTwister();
            // finds the switching time by allowing the system to run until the magnetization has
            // passed the saddle point at theta = PI/2

            for (int ip = 0; ip < psteps; ip++)
            {
                int istep = 0;
                double time = 0.0;
                double tstep = 0;
                double j_total = 0.0;
                double theta, phi;
                double dt = mp.delta_time;
                int steps = Convert.ToInt32(Math.Truncate(time_max / dtstep)) + 1;
                Traj_Coord[] tc = new Traj_Coord[steps];

                mp.period = mp.period + dp;
                theta = 0.01;
                phi = 2 * Math.PI * MTrand.NextDoublePositive();
                if (mp.d_th != 0)
                {
                    mp.h_on = false;
                    Initial_Distribution(mp, 500.0, ref theta, ref phi);
                    mp.h_on = true;
                }
                // calculates the initial position of the magnetization
                //Initial_Distribution(mp, 500.0, ref theta, ref phi);
                while (/*theta <= theta_max &&*/ time < time_max)
                {
                    j_total = mp.j_dc;

                    if (mp.j_ac != 0 && mp.period != 0)
                    {
                        j_total += mp.j_ac * Math.Cos(time * 2 * Math.PI / mp.period);
                    }
                    if (time > time_p)
                    {
                        j_total = -mp.j_dc;
                    }
                    if (time > time_p + time_dp)
                    {
                        j_total = 0.0;
                        mp.h_on = false;
                    }
                    RK42(mp, ref dt, 1.0, j_total, ref theta, ref phi, ref time);
                    Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                    Coord_Correction(ref theta, ref phi);
                    if (time > tstep && time > time_min)
                    {
                        tc[istep].time = time;
                        tc[istep].phi = phi;
                        tc[istep].theta = theta;
                        tc[istep].j = j_total;
                        tstep = (Math.Truncate(time / dtstep) + 1) * dtstep;
                        istep++;
                    }
                }

                if (istep < steps)
                {
                    steps = istep;
                }
                double L1, L2, Eeq, delta;
                L1 = L2 = Eeq = delta = 0;
                double w = 2 * Math.PI / mp.period;

                

                double[] ThA = new double[steps];
                double[] PhA = new double[steps];
                double[] TA = new double[steps];
                for (int i = 0; i < steps; i++)
                {
                    ThA[i] = tc[i].theta;
                    PhA[i] = tc[i].phi;
                    TA[i] = tc[i].time;
                }

                double ESad = Energy(mp, Math.PI / 2, Math.PI / 2);
                double EMin = Energy(mp, 0, Math.PI);

                double[] EA = new double[steps];
                for (int i = 0; i < steps; i++)
                {
                    double e = (Energy(mp, tc[i].theta, tc[i].phi) - EMin) / (ESad - EMin);
                    EA[i] = e;
                }

                matlab.Execute("cd('C:\\Users\\Tom\\Desktop\\Matlab');");
                matlab.PutWorkspaceData("t", "base", TA);
                matlab.PutWorkspaceData("th", "base", ThA);
                matlab.PutWorkspaceData("phi", "base", PhA);
                matlab.PutWorkspaceData("En", "base", EA);
                matlab.PutWorkspaceData("w", "base", 2 * Math.PI / mp.period);

                matlab.Execute("x = sin(th).*cos(phi);");

                matlab.Execute("Estimate = Damped_Oscillator_Fit(t,En);");
                matlab.Execute("Eos = Estimate(1);");
                matlab.Execute("Eeq = Estimate(2);");
                matlab.Execute("L1 = Estimate(3);");
                matlab.Execute("L2 = Estimate(4);");

                matlab.Execute("Estimate = Cos_Fit(w, t, x);");
                matlab.Execute("d = Estimate(2);");
                matlab.Execute("Eave = Eeq + Eos;");

                L1 = (double)matlab.GetVariable("L1", "base");
                L2 = (double)matlab.GetVariable("L2", "base");
                Eeq = (double)matlab.GetVariable("Eave", "base");
                delta = (double)matlab.GetVariable("d", "base");

                //MessageBox.Show("delta = " + delta.ToString());
                //Fit_Trajectory(mp, steps, tc, ref L1, ref L2);
                WvL1.Add(w, L1);
                WvL2.Add(w, L2);
                WvEeq.Add(w, Eeq);
                Wvdelta.Add(w, delta);
            }
            //Plot_Fit(mp, WvL1);
            //Plot_Fit(mp, WvL2);
            Save_Fit(mp, "W vs L1", WvL1);
            Save_Fit(mp, "W vs L2", WvL2);
            Save_Fit(mp, "W vs Eeq", WvEeq);
            Save_Fit(mp, "W vs delta", Wvdelta);

            matlab.Quit();
            matlab = null;
        }

        public void Magnetic_Trajectory_Fit_Current(ref Magnetic_Parameters mp, double time_min, double time_max, double time_p, double time_dp,
            double theta_max, double dtstep, bool save)
        {
            MLApp.MLApp matlab = new MLApp.MLApp();
            //matlab.Visible = 1;
            int jsteps = 100;
            double dj = 0.002 / jsteps;
            mp.period = 35;
            mp.j_ac = 0.002;

            Dictionary<double, double> JvL1 = new Dictionary<double, double>();
            Dictionary<double, double> JvL2 = new Dictionary<double, double>();
            Dictionary<double, double> JvEeq = new Dictionary<double, double>();
            Dictionary<double, double> Jvdelta = new Dictionary<double, double>();

            MersenneTwister MTrand = new MersenneTwister();
            // finds the switching time by allowing the system to run until the magnetization has
            // passed the saddle point at theta = PI/2

            for (int ij = 0; ij < jsteps; ij++)
            {
                int istep = 0;
                double time = 0.0;
                double tstep = 0;
                double j_total = 0.0;
                double theta, phi;
                double dt = mp.delta_time;
                int steps = Convert.ToInt32(Math.Truncate(time_max / dtstep)) + 1;
                Traj_Coord[] tc = new Traj_Coord[steps];

                mp.j_ac = mp.j_ac + dj;
                theta = 0.01;
                phi = 2 * Math.PI * MTrand.NextDoublePositive();
                if (mp.d_th != 0)
                {
                    mp.h_on = false;
                    Initial_Distribution(mp, 500.0, ref theta, ref phi);
                    mp.h_on = true;
                }
                // calculates the initial position of the magnetization
                //Initial_Distribution(mp, 500.0, ref theta, ref phi);
                while (/*theta <= theta_max &&*/ time < time_max)
                {
                    j_total = mp.j_dc;

                    if (mp.j_ac != 0 && mp.period != 0)
                    {
                        j_total += mp.j_ac * Math.Cos(time * 2 * Math.PI / mp.period);
                    }
                    if (time > time_p)
                    {
                        j_total = -mp.j_dc;
                    }
                    if (time > time_p + time_dp)
                    {
                        j_total = 0.0;
                        mp.h_on = false;
                    }
                    RK42(mp, ref dt, 1.0, j_total, ref theta, ref phi, ref time);
                    Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                    Coord_Correction(ref theta, ref phi);
                    if (time > tstep && time > time_min)
                    {
                        tc[istep].time = time;
                        tc[istep].phi = phi;
                        tc[istep].theta = theta;
                        tc[istep].j = j_total;
                        tstep = (Math.Truncate(time / dtstep) + 1) * dtstep;
                        istep++;
                    }
                }

                if (istep < steps)
                {
                    steps = istep;
                }
                double L1, L2, Eeq, delta;
                L1 = L2 = Eeq = delta = 0;
                double w = 2 * Math.PI / mp.period;



                double[] ThA = new double[steps];
                double[] PhA = new double[steps];
                double[] TA = new double[steps];
                for (int i = 0; i < steps; i++)
                {
                    ThA[i] = tc[i].theta;
                    PhA[i] = tc[i].phi;
                    TA[i] = tc[i].time;
                }

                double ESad = Energy(mp, Math.PI / 2, Math.PI / 2);
                double EMin = Energy(mp, 0, Math.PI);

                double[] EA = new double[steps];
                for (int i = 0; i < steps; i++)
                {
                    double e = (Energy(mp, tc[i].theta, tc[i].phi) - EMin) / (ESad - EMin);
                    EA[i] = e;
                }
                matlab.Execute("cd('C:\\Users\\Tom\\Desktop\\Matlab');");
                matlab.PutWorkspaceData("t", "base", TA);
                matlab.PutWorkspaceData("th", "base", ThA);
                matlab.PutWorkspaceData("phi", "base", PhA);
                matlab.PutWorkspaceData("En", "base", EA);
                matlab.PutWorkspaceData("j", "base", mp.j_ac);
                matlab.PutWorkspaceData("w", "base", 2 * Math.PI / mp.period);

                matlab.Execute("x = sin(th).*cos(phi);");

                matlab.Execute("Estimate = Damped_Oscillator_Fit(t,En);");
                matlab.Execute("Eos = Estimate(1);");
                matlab.Execute("Eeq = Estimate(2);");
                matlab.Execute("L1 = Estimate(3);");
                matlab.Execute("L2 = Estimate(4);");

                matlab.Execute("Estimate = Cos_Fit(w, t, x);");
                matlab.Execute("d = Estimate(2);");
                matlab.Execute("Eave = Eeq + Eos;");

                L1 = (double)matlab.GetVariable("L1", "base");
                L2 = (double)matlab.GetVariable("L2", "base");
                Eeq = (double)matlab.GetVariable("Eave", "base");
                delta = (double)matlab.GetVariable("d", "base");

                //MessageBox.Show("delta = " + delta.ToString());
                //Fit_Trajectory(mp, steps, tc, ref L1, ref L2);
                JvL1.Add(mp.j_ac, L1);
                JvL2.Add(mp.j_ac, L2);
                JvEeq.Add(mp.j_ac, Eeq);
                Jvdelta.Add(mp.j_ac, delta);
            }
            //Plot_Fit(mp, WvL1);
            //Plot_Fit(mp, WvL2);
            Save_Fit(mp, "J vs L1", JvL1);
            Save_Fit(mp, "J vs L2", JvL2);
            Save_Fit(mp, "J vs Eeq", JvEeq);
            Save_Fit(mp, "J vs delta", Jvdelta);

            matlab.Quit();
            matlab = null;
        }

        private void Fit_Trajectory(Magnetic_Parameters mp, int steps, Traj_Coord[] tc, ref double L1, ref double L2)
        {
            MLApp.MLApp matlab = new MLApp.MLApp();

            double[] ThA = new double[steps];
            double[] PhA = new double[steps];
            double[] TA = new double[steps];
            double[] JA = new double[steps];
            for (int i = 0; i < steps; i++)
            {
                ThA[i] = tc[i].theta;
                PhA[i] = tc[i].phi;
                TA[i] = tc[i].time;
            }
            matlab.Execute("cd('C:\\Users\\Tom\\Desktop\\Matlab');");
            matlab.PutWorkspaceData("t", "base", TA);

            double ESad = Energy(mp, Math.PI / 2, Math.PI / 2);
            double EMin = Energy(mp, 0, Math.PI);

            double[] EA = new double[steps];
            for (int i = 0; i < steps; i++)
            {
                double e = (Energy(mp, tc[i].theta, tc[i].phi) - EMin) / (ESad - EMin);
                EA[i] = e;
            }
            matlab.PutWorkspaceData("En", "base", EA);
            matlab.Execute("Estimate = Damped_Oscillator_Fit(t,En);");
            matlab.Execute("Eos = Estimate(1);");
            matlab.Execute("Eeq = Estimate(2);");
            matlab.Execute("L1 = Estimate(3);");
            matlab.Execute("L2 = Estimate(4);");
            matlab.Execute("d = Estimate(5);");

            L1 = (double)matlab.GetVariable("L1", "base");
            L2 = (double)matlab.GetVariable("L2", "base");

            matlab.Quit();
            matlab = null;
        }

        private void Plot_Fit(Magnetic_Parameters mp, Dictionary<double, double> Alpha)
        {
            MLApp.MLApp matlab = new MLApp.MLApp();
            int count = Alpha.Count;
            double[] keys = new double[count];
            double[] values = new double[count];
            //string wMax = (1.2 * Alpha.Keys.Max()).ToString();
            Alpha.Keys.CopyTo(keys, 0);
            Alpha.Values.CopyTo(values, 0);

            matlab.PutWorkspaceData("alpha", "base", keys);
            matlab.PutWorkspaceData("L1", "base", values);
            matlab.Visible = 1;
            matlab.Execute("f = figure;");
            matlab.Execute("plot(alpha,L1,'black');");
            MessageBox.Show("pause");
            matlab.Quit();
            matlab = null;
        }

        private void Save_Fit(Magnetic_Parameters mp, string type, Dictionary<double, double> Alpha)
        {
            string ofilename = null;
            mp.Construct_File_Name(ref ofilename);
            ofilename += " - fit " + type + ".dat";
            StreamWriter outfile = new StreamWriter(ofilename);
            
            foreach(var x in Alpha)
            {
                outfile.WriteLine("{0}\t{1}",x.Key,x.Value);
            }

            outfile.Close();
        }

        private void Save_Trajectory(Magnetic_Parameters mp, string type, int steps, Traj_Coord[] tc)
        {
            string ofilename = null;
            mp.Construct_File_Name(ref ofilename);
            ofilename += " - trajectory.dat";
            StreamWriter outfile = new StreamWriter(ofilename);
            if (type == "all")
            {
                outfile.WriteLine("time" + "\t" + "energy"
                    + "\t" + "x" + "\t" + "y"
                    + "\t" + "z" + "\t" + "dx/dt"
                    + "\t" + "dy/dt" + "\t" + "dz/dt");
            }
            double ESad = Energy(mp, Math.PI / 2, Math.PI / 2);
            double EMin = Energy(mp, 0, Math.PI);
            for (int isteps = 0; isteps < steps; isteps++)
            {
                double theta = tc[isteps].theta;
                double phi = tc[isteps].phi;
                double time = tc[isteps].time;
                double j_total = tc[isteps].j;
                
                if (type == "theta")
                {
                    outfile.WriteLine(time.ToString() + "\t" + theta.ToString());
                }
                else if (type == "phi")
                {
                    outfile.WriteLine(time.ToString() + "\t" + phi.ToString());
                }
                else if (type == "energy")
                {
                    double e = (Energy(mp, theta, phi)-EMin)/(ESad - EMin);
                    outfile.WriteLine(time.ToString() + "\t" + e.ToString());
                }
                else if (type == "trajectory")
                {
                    outfile.WriteLine((Math.Sin(theta) * Math.Cos(phi)).ToString() + "\t" + (Math.Sin(theta) * Math.Sin(phi)).ToString()
                        + "\t" + (Math.Cos(theta)).ToString());
                }
                else if (type == "x vs t")
                {
                    outfile.WriteLine(time.ToString() + "\t" + (Math.Sin(theta) * Math.Cos(phi)).ToString());
                }
                else if (type == "y vs t")
                {
                    outfile.WriteLine(time.ToString() + "\t" + (Math.Sin(theta) * Math.Sin(phi)).ToString());
                }
                else if (type == "z vs t")
                {
                    outfile.WriteLine(time.ToString() + "\t" + Math.Cos(theta).ToString());
                }
                else if (type == "resistance")
                {
                    outfile.WriteLine(time.ToString() + "\t" + ((mp.res_min + mp.res_max) / 2 + (mp.res_max - mp.res_min) * Math.Cos(theta)).ToString());

                }
                else if (type == "all")
                {
                    double dx = D_x(mp, j_total, theta, phi);
                    double dy = D_y(mp, j_total, theta, phi);
                    double dz = D_z(mp, j_total, theta, phi);
                    outfile.WriteLine(time.ToString() + "\t" + Energy(mp, theta, phi).ToString()
                        + "\t" + (Math.Sin(theta) * Math.Cos(phi)).ToString() + "\t" + (Math.Sin(theta) * Math.Sin(phi)).ToString()
                        + "\t" + Math.Cos(theta).ToString() + "\t" + dx.ToString() + "\t" + dy.ToString() + "\t" + dz.ToString());
                }
            }
            outfile.Close();
        }

        private void Plot_Trajectory(ref MLApp.MLApp matlab, Magnetic_Parameters mp, string type, int steps, Traj_Coord[] tc)
        {
            //MLApp.MLApp matlab = new MLApp.MLApp();

            double[] ThA = new double[steps];
            double[] PhA = new double[steps];
            double[] TA = new double[steps];
            double[] JA = new double[steps];
            for (int i = 0; i < steps; i++)
            {
                ThA[i] = tc[i].theta;
                PhA[i] = tc[i].phi;
                TA[i] = tc[i].time / (mp.magn * 4 * Math.PI * mp.gamma);
                JA[i] = tc[i].j / (mp.j_ac + mp.j_dc);
            }
            matlab.PutWorkspaceData("theta", "base", ThA);
            matlab.PutWorkspaceData("phi", "base", PhA);
            matlab.PutWorkspaceData("t", "base", TA);
            matlab.PutWorkspaceData("j", "base", JA);
            matlab.Execute("cd('C:\\Users\\Tom\\Documents\\Visual Studio 2010\\Projects\\Switching Simulator GUI\\Switching Simulator GUI\\Matlab')");
            double ESad = Energy(mp, Math.PI / 2, Math.PI / 2);
            double EMin = Energy(mp, 0, Math.PI);
            if (type == "theta")
            {
                matlab.Execute("plot(t,theta);");
            }
            else if (type == "phi")
            {
                matlab.Execute("plot(t,phi);");
            }
            else if (type == "energy")
            {
                double[] EA = new double[steps];
                for(int i = 0; i<steps; i++){
                    double e = (Energy(mp, tc[i].theta, tc[i].phi) - EMin) / (ESad - EMin);
                    EA[i] = e;
                }
                matlab.PutWorkspaceData("energy", "base", EA);
                matlab.Execute("plot(t,energy);");
            }
            else if (type == "trajectory")
            {
                matlab.Execute("plot3(sin(theta).*cos(phi),sin(theta).*sin(phi),cos(theta));");
                matlab.Execute("axis([-1 1 -1 1 -1 1]);");
            }
            else if (type == "x vs t")
            {
                matlab.Execute("plot(t,sin(theta).*cos(phi));");
            }
            else if (type == "y vs t")
            {
                matlab.Execute("plot(t,sin(theta).*sin(phi));");
            }
            else if (type == "z vs t")
            {
                matlab.Execute("plot(t,cos(theta));");
            }
            //else if (type == "resistance")
            //{
            //    outfile.WriteLine(time.ToString() + "\t" + ((mp.res_min + mp.res_max) / 2 + (mp.res_max - mp.res_min) * Math.Cos(theta)).ToString());

            //}
            else if (type == "all")
            {
                matlab.Execute("plot(t,sin(theta).*cos(phi),':',t,sin(theta).*sin(phi),'--',t,cos(theta)),'-';");
                matlab.Execute("hold on;");
                matlab.Execute("plot(t,j,'black');");
                matlab.Execute("xlabel('time');");
                matlab.Execute("legend('m_x','m_y','m_z','I_{st}');");
                matlab.Execute("hold off;");
            }
            matlab.Execute("m = make_m(t,theta,phi);");
            matlab.Execute("delete(theta, phi, t, j);");
            //matlab.Quit();
            //matlab = null;
        }


        public void Hysteresis_Loop_Current_Amplitude(ref MLApp.MLApp matlab, Magnetic_Parameters mp, double jmax, double jmin, int steps)
        {
            
            double j_total = 0.0;
            double theta, phi;
            double dt = mp.delta_time;
            string ofilename = null;
            mp.Construct_File_Name(ref ofilename);
            ofilename += " - hysteresis.dat";
            StreamWriter outfile = new StreamWriter(ofilename);
            MersenneTwister MTrand = new MersenneTwister();
            theta = 0.01;
            phi = Math.PI / 2;
            double j_ac;
            for (int istep = 1; istep <= 2*steps; istep++)
            {
                double time = 0.0;
                j_ac = jmin + (istep - 0.5) * (jmax - jmin) / steps;
                
                if (istep > steps)
                {
                    j_ac = jmax - (istep - 0.5 - steps) * (jmax - jmin) / steps;
                }
                double Ave_Energy = 0;
                // finds the switching time by allowing the system to run until the magnetization has
                // passed the saddle point at theta = PI/2
                while (theta <= Math.PI / 2 && Energy(mp, theta, phi) < 0 && time < 10000.0)
                {
                    if (mp.period != 0)
                    {
                        j_total = j_ac * Math.Cos(time * 2 * Math.PI / mp.period);
                    }
                    RK4(mp, ref dt, j_total, ref theta, ref phi, ref time);
                    Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                    Coord_Correction(ref theta, ref phi);
                    if (time > 2000.0)
                    {
                        Ave_Energy += Energy(mp, theta, phi);
                    }
                }
                if (theta >= Math.PI / 2 || Energy(mp, theta, phi) > 0)
                {
                    MessageBox.Show("Current too high! Switching occured at J = " + j_ac.ToString());
                    outfile.Close();
                    return;
                }
                else
                {
                    outfile.WriteLine(j_ac.ToString() + "\t" + (Ave_Energy * mp.delta_time / 8000.0).ToString());
                }
            }
            outfile.Close();
        }

        public void Hysteresis_Loop_Frequency(ref MLApp.MLApp matlab, ref Magnetic_Parameters mp, double periodMin, double periodMax, double time_per_freq, bool save)
        {
            MersenneTwister MTrand = new MersenneTwister();
            double time = 0.0;
            double j_total = 0.0;
            double theta, phi;
            double dt = mp.delta_time;
            double tpf = time_per_freq;
            double time_max = (periodMax - periodMin) * tpf;
            double per = periodMin;
            double E_Ave = 0;
            double E_Sad = Energy(mp, Math.PI / 2, Math.PI / 2);
            double E_Min = Energy(mp, 0.0, Math.PI);
            Dictionary<double, double> hc = new Dictionary<double, double>();

            // finds the switching time by allowing the system to run until the magnetization has
            // passed the saddle point at theta = PI/2
            theta = 0.01;
            phi = 2 * Math.PI * MTrand.NextDoublePositive();
            phi = 0.0;
            if (mp.d_th != 0)
            {
                bool h_on = mp.h_on;
                mp.h_on = false;
                Initial_Distribution(mp, 500.0, ref theta, ref phi);
                mp.h_on = h_on;
            }

            // calculates the initial position of the magnetization
            while (per < periodMax)
            {
                j_total = mp.j_dc;
                per += dt / tpf;
                j_total += mp.j_ac * Math.Cos(time * 2 * Math.PI / per);
                RK42(mp, ref dt, 1.0, j_total, ref theta, ref phi, ref time);
                Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                Coord_Correction(ref theta, ref phi);
                E_Ave += Energy(mp, theta, phi) * dt;
                if (time > per)
                {
                    double freq = 2 * Math.PI / per;
                    E_Ave = E_Ave / per;
                    E_Ave = (E_Ave - E_Min) / (E_Sad - E_Min);
                    hc.Add(freq, E_Ave);
                    E_Ave = 0;
                    time -= per;
                }
            }
            time = 0.0;
            E_Ave = 0.0;
            while (per > periodMin && (E_Ave / per) < E_Sad)
            {
                j_total = mp.j_dc;
                per -= dt / tpf;
                j_total += mp.j_ac * Math.Cos(time * 2 * Math.PI / per);
                RK42(mp, ref dt, 1.0, j_total, ref theta, ref phi, ref time);
                Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
                Coord_Correction(ref theta, ref phi);
                E_Ave += Energy(mp, theta, phi) * dt;
                if (time > per)
                {
                    double freq = 2 * Math.PI / per;
                    E_Ave = E_Ave / per;
                    E_Ave = (E_Ave - E_Min) / (E_Sad - E_Min);
                    hc.Add(freq, E_Ave);
                    E_Ave = 0;
                    time -= per;
                }
            }
            if (save == true)
            {
                Save_Hysteresis(mp, "freq", hc);
            }
            Plot_Hysteresis(ref matlab, mp, "freq", hc);
        }


        private void Save_Hysteresis(Magnetic_Parameters mp, string type, Dictionary<double,double> hc)
        {
            string ofilename = null;
            mp.Construct_File_Name(ref ofilename);
            ofilename += " - frequency.dat";
            StreamWriter outfile = new StreamWriter(ofilename);
            Write_Header(mp, ref outfile);
            foreach (var i in hc)
            {
                outfile.WriteLine(i.Key.ToString() + "\t" + i.Value.ToString());
            }
            outfile.Close();
        }

        private void Plot_Hysteresis(ref MLApp.MLApp matlab, Magnetic_Parameters mp, string type, Dictionary<double, double> hc)
        {
            int count = hc.Count;
            double[] keys = new double[count];
            double[] values = new double[count];
            string wMax = (1.2 * hc.Keys.Max()).ToString();
            hc.Keys.CopyTo(keys, 0);
            hc.Values.CopyTo(values, 0);
            
            if (type == "freq")
            {
                matlab.PutWorkspaceData("freq", "base", keys);
                matlab.PutWorkspaceData("en", "base", values);
                matlab.Execute("cd('" + mp.savedirectory + "');");
                matlab.Execute("f = figure;");
                matlab.Execute("plot(freq,en,'black');");
                matlab.Execute("xlabel('\\omega');");
                matlab.Execute("ylabel('E/E_{B}');");
                matlab.Execute("title('Average Equilibrium Energy vs Frequency');");
                matlab.Execute("axis([0 " + wMax + " 0 1.2]);");
                matlab.Execute("saveas(f,'Hyst_freq.fig');");
                matlab.Execute("saveas(f,'Hyst_freq.pdf');");
                matlab.Execute("delete(freq, en, f);");
            }
            if (type == "current")
            {
                matlab.PutWorkspaceData("Ist", "base", keys);
                matlab.PutWorkspaceData("en", "base", values);
                matlab.Execute("cd('" + mp.savedirectory + "');");
                matlab.Execute("f = figure;");
                matlab.Execute("plot(Ist,en);");
                matlab.Execute("xlabel('I_{st}/\\gamma M_s');");
                matlab.Execute("ylabel('E/E_{B}');");
                matlab.Execute("title('Average Equilibrium Energy vs Spin Current');");
                matlab.Execute("axis([0 " + wMax + " 0 1.2]);");
                matlab.Execute("saveas(f,'Hyst_curr.fig');");
                matlab.Execute("saveas(f,'Hyst_curr.pdf');");
                matlab.Execute("delete(Ist, en, f);");
            }
        }

        //public void Hysteresis_Loop_Frequency(Magnetic_Parameters mp, double periodMax, double periodMin, int steps)
        //{

        //    double j_total = 0.0;
        //    double theta, phi;
        //    double dt = mp.delta_time;
        //    string ofilename = null;
        //    mp.Construct_File_Name(ref ofilename);
        //    ofilename += " - hysteresis.dat";
        //    StreamWriter outfile = new StreamWriter(ofilename);
        //    MersenneTwister MTrand = new MersenneTwister();
        //    theta = 0.01;
        //    phi = Math.PI / 2;
        //    double freq, freqMin, freqMax;
        //    freqMin = 1 / periodMin;
        //    freqMax = 1 / periodMax;
        //    for (int istep = 1; istep <= 2 * steps; istep++)
        //    {
        //        double time = 0.0;
        //        freq = freqMin + (istep - 0.5) * (freqMax - freqMin) / steps;
        //        if (istep > steps)
        //        {
        //            freq = freqMax - (istep - 0.5 - steps) * (freqMax - freqMin) / steps;
        //        }
        //        double Ave_Energy = 0;
        //        // finds the switching time by allowing the system to run until the magnetization has
        //        // passed the saddle point at theta = PI/2
        //        while (/*theta <= Math.PI / 2 &&*/ time < 10000.0)
        //        {
        //            j_total = mp.j_dc;

        //            j_total += mp.j_ac * Math.Cos(time * 2 * Math.PI * freq);

        //            RK42(mp, ref dt, 1.0, j_total, ref theta, ref phi, ref time);
        //            Noise(mp, dt, ref theta, ref phi, MTrand.NextDoublePositive(), MTrand.NextDoublePositive());
        //            Coord_Correction(ref theta, ref phi);
        //            if (time > 2000.0)
        //            {
        //                Ave_Energy += Energy(mp, theta, phi);
        //            }
        //        }
        //        //if (theta >= Math.PI / 2 )
        //        //{
        //        //    MessageBox.Show("Current too high! Switching occured at J = " + freq.ToString());
        //        //    outfile.Close();
        //        //    return;
        //        //}
        //        //else
        //        //{
        //            double EMin = Energy(mp, 0, Math.PI);
        //            double ESad = Energy(mp, Math.PI / 2, Math.PI / 2);
        //            double e = (Ave_Energy - EMin) / (ESad - EMin);
        //            outfile.WriteLine(freq.ToString() + "\t" + (e * mp.delta_time / 8000.0).ToString());
        //        //}
        //    }
        //    outfile.Close();
        //}

        // simulates noise through random fluxtuations
        public void Noise(Magnetic_Parameters mp, double dt, ref double theta, ref double phi, double rand1, double rand2)
        {
            double d_total = mp.d_th + mp.d_sh * (1 + mp.pz*Math.Cos(theta));
            // generates random motion in both directions using one random variable
            if (theta != 0.0)
            {
                phi += Math.Sin(rand1 * 2 * Math.PI) * Normal_Distribution(rand2) * Math.Sqrt(4 * dt * d_total) / Math.Sin(theta);
            }
            theta += Math.Sin(rand1 * 2 * Math.PI) * Normal_Distribution(rand2) * Math.Sqrt(4 * dt * d_total);
        }
        
        // Calculates the energy of the system
        private double Energy(Magnetic_Parameters mp, double theta, double phi)
        {
            double hx, hy, hz;
            hx = hy = hz = 0.0;
            if (mp.h_on)
            {
                hx = mp.hx;
                hy = mp.hy;
                hz = mp.hz;
            }
            return mp.nxx * Math.Pow(Math.Sin(theta) * Math.Cos(phi), 2) / 2 + mp.nyy * Math.Pow(Math.Sin(theta) * Math.Sin(phi), 2) / 2
                + mp.nzz * Math.Pow(Math.Cos(theta), 2) / 2 - hx * Math.Sin(theta) * Math.Cos(phi) - hy * Math.Sin(theta) * Math.Sin(phi) - hz * Math.Cos(theta);
        }

        // Calculates the theta derivative to be use in the RK4 method later
        private double D_Theta(Magnetic_Parameters mp, double j, double theta, double phi)
        {
            double d_theta = 0.0;
            if (mp.nxx != 0)
            {
                d_theta += mp.nxx * Math.Sin(theta) * Math.Cos(phi) * Math.Sin(phi);
                d_theta += -mp.nxx * mp.alpha * Math.Sin(theta) * Math.Cos(theta) *Math.Cos(phi) * Math.Cos(phi);
            }
            if (mp.nyy != 0)
            {
                d_theta += -mp.nyy * Math.Sin(theta) * Math.Cos(phi) * Math.Sin(phi);
                d_theta += -mp.nyy * mp.alpha * Math.Sin(theta) * Math.Cos(theta) * Math.Sin(phi) * Math.Sin(phi);
            }
            if (mp.nzz != 0)
            {
                d_theta += mp.nzz * mp.alpha * Math.Sin(theta) * Math.Cos(theta);
            }
            //if (mp.hx != 0.0 || mp.pxf != 0.0)
            //{
            //    d_theta += (mp.hx + mp.pxf) * (-Math.Sin(phi) + mp.alpha * Math.Cos(theta) * Math.Cos(phi));
            //}
            //if (mp.hy != 0 || mp.pyf != 0.0)
            //{
            //    d_theta += (mp.hy + mp.pyf) * (Math.Cos(phi) + mp.alpha * Math.Cos(theta) * Math.Sin(phi));
            //}
            //if (mp.hz != 0 || mp.pzf != 0.0)
            //{
            //    d_theta += -(mp.hz + mp.pzf) * mp.alpha * Math.Sin(theta);
            //}
            if (mp.px != 0)
            {
                d_theta += j * mp.px * Math.Cos(theta) * Math.Cos(phi);
            }
            if (mp.py != 0)
            {
                d_theta += j * mp.py * Math.Cos(theta) * Math.Sin(phi);
            }
            if (mp.pz != 0)
            {
                d_theta += -j * mp.pz * Math.Sin(theta);
            }
            return d_theta;
        }

         // Calculates the phi derivative to be used in the RK4 method later
        private double D_Phi(Magnetic_Parameters mp, double j, double theta, double phi)
        {
            double d_phi = 0.0;
            if (mp.nxx != 0)
            {
                d_phi += mp.nxx * Math.Cos(theta) * Math.Cos(phi) * Math.Cos(phi);
                d_phi += mp.nxx * mp.alpha * Math.Cos(phi) * Math.Sin(phi);
            }
            if (mp.nyy != 0)
            {
                d_phi += mp.nyy * Math.Cos(theta) * Math.Sin(phi) * Math.Sin(phi);
                d_phi += -mp.nyy * mp.alpha * Math.Cos(phi) * Math.Sin(phi);
            }
            if (mp.nzz != 0)
            {
                d_phi += -mp.nzz * Math.Cos(theta);
            }
            //if (mp.hx != 0.0 || mp.pxf != 0)
            //{
            //    d_phi += -(mp.hx + j * mp.pxf) * Math.Cos(theta) * Math.Cos(phi) / Math.Sin(theta);
            //    d_phi += -(mp.hx + j * mp.pxf) * mp.alpha * Math.Sin(phi) / Math.Sin(theta);
            //}
            //if (mp.hy != 0 || mp.pyf != 0)
            //{
            //    d_phi += -(mp.hy + j * mp.pyf) * Math.Cos(theta) * Math.Sin(phi) / Math.Sin(theta);
            //    d_phi += (mp.hy + j * mp.pyf) * mp.alpha * Math.Cos(phi) / Math.Sin(theta);
            //}
            //if (mp.hz != 0 || mp.pzf != 0)
            //{
            //    d_phi += mp.hz + j * mp.pzf;
            //}
            if (mp.px != 0)
            {
                d_phi += -j * mp.px * Math.Sin(phi) / Math.Sin(theta);
            }
            if (mp.py != 0)
            {
                d_phi += j * mp.py * Math.Cos(phi) / Math.Sin(theta);
            }
            return d_phi;
        }

        // Calculates the theta derivative to be use in the RK4 method later
        private double D_Theta2(Magnetic_Parameters mp, double j, double theta, double phi, double time)
        {
            double d_theta = 0.0;
            double hx, hy, hz;
            double jx, jy, jz;
            hx = hy = hz = 0;
            jx = jy = jz = 0;
            if (mp.h_on)
            {
                hx = mp.hx;
                hy = mp.hy;
                hz = mp.hz;
            }
            //if (mp.j_on)
            //{
            //    double j_total = (mp.j_dc + mp.j_ac * Math.Cos(2 * Math.PI * time / mp.period));
            //    jx = j_total * mp.px;
            //    jy = j_total * mp.py;
            //    jz = j_total * mp.pz;
            //}

            if (mp.nxx != 0)
            {
                d_theta += mp.nxx * Math.Sin(theta) * Math.Cos(phi) * Math.Sin(phi);
                d_theta += -mp.nxx * mp.alpha * Math.Sin(theta) * Math.Cos(theta) * Math.Cos(phi) * Math.Cos(phi);
            }
            if (mp.nyy != 0)
            {
                d_theta += -mp.nyy * Math.Sin(theta) * Math.Cos(phi) * Math.Sin(phi);
                d_theta += -mp.nyy * mp.alpha * Math.Sin(theta) * Math.Cos(theta) * Math.Sin(phi) * Math.Sin(phi);
            }
            if (mp.nzz != 0)
            {
                d_theta += mp.nzz * mp.alpha * Math.Sin(theta) * Math.Cos(theta);
            }
            if (hx != 0 || mp.pxf != 0)
            {
                d_theta += -(hx + j * mp.pxf) * Math.Sin(phi);
                d_theta += (hx + j * mp.pxf) * mp.alpha * Math.Cos(theta) * Math.Cos(phi);
            }
            if (hy != 0 || mp.pyf != 0)
            {
                d_theta += (hy + j * mp.pyf) * Math.Cos(phi);
                d_theta += (hy + j * mp.pyf) * mp.alpha * Math.Cos(theta) * Math.Sin(phi);
            }
            if (hz != 0 || mp.pzf != 0)
            {
                d_theta += -(hz + j * (mp.pzf + mp.spin_accum*time)) * mp.alpha * Math.Sin(theta);
            }
            if (mp.px != 0)
            {
                d_theta += j * mp.px * Math.Cos(theta) * Math.Cos(phi);///////////////////
                d_theta += mp.alpha * j * mp.px * Math.Sin(phi);
            }
            if (mp.py != 0)
            {
                d_theta += j * mp.py * Math.Cos(theta) * Math.Sin(phi);
                d_theta += -mp.alpha * j * mp.py * Math.Cos(phi);
            }
            if (mp.pz != 0)
            {
                d_theta += -j * mp.pz * Math.Sin(theta);
            }
            return d_theta;
        }

        // Calculates the phi derivative to be used in the RK4 method later
        private double D_Phi2(Magnetic_Parameters mp, double j, double theta, double phi, double time)
        {
            double d_phi = 0.0;
            double hx, hy, hz;
            double jx, jy, jz;
            hx = hy = hz = 0;
            jx = jy = jz = 0;
            if (mp.h_on)
            {
                hx = mp.hx;
                hy = mp.hy;
                hz = mp.hz;
            }
            //if (mp.j_on)
            //{
            //    double j_total = (mp.j_dc + mp.j_ac * Math.Cos(2 * Math.PI * time / mp.period));
            //    jx = j_total * mp.px;
            //    jy = j_total * mp.py;
            //    jz = j_total * mp.pz;
            //}

            if (mp.nxx != 0)
            {
                d_phi += mp.nxx * Math.Cos(theta) * Math.Cos(phi) * Math.Cos(phi);
                d_phi += mp.nxx * mp.alpha * Math.Cos(phi) * Math.Sin(phi);
            }
            if (mp.nyy != 0)
            {
                d_phi += mp.nyy * Math.Cos(theta) * Math.Sin(phi) * Math.Sin(phi);
                d_phi += -mp.nyy * mp.alpha * Math.Cos(phi) * Math.Sin(phi);
            }
            if (mp.nzz != 0)
            {
                d_phi += -mp.nzz * Math.Cos(theta);
            }
            if (hx != 0.0 || mp.pxf != 0.0)
            {
                d_phi += -(hx + j * mp.pxf) * Math.Cos(theta) * Math.Cos(phi) / Math.Sin(theta);
                d_phi += -(hx + j * mp.pxf) * mp.alpha * Math.Sin(phi) / Math.Sin(theta);
            }
            if (hy != 0 || mp.pyf != 0.0)
            {
                d_phi += -(hy + j * mp.pyf) * Math.Cos(theta) * Math.Sin(phi) / Math.Sin(theta);
                d_phi += (hy + j * mp.pyf) * mp.alpha * Math.Cos(phi) / Math.Sin(theta);
            }
            if (hz != 0 || mp.pzf != 0)
            {
                d_phi += hz + j * (mp.pzf + mp.spin_accum * time);
            }
            if (mp.px != 0)
            {
                d_phi += -j * mp.px * Math.Sin(phi) / Math.Sin(theta);
                d_phi += mp.alpha * j * mp.px * Math.Cos(theta) * Math.Cos(phi) / Math.Sin(theta);
            }
            if (mp.py != 0)
            {
                d_phi += j * mp.py * Math.Cos(phi) / Math.Sin(theta);
                d_phi += mp.alpha * j * mp.py * Math.Cos(theta) * Math.Sin(phi) / Math.Sin(theta);
            }
            if (mp.pz != 0)
            {
                d_phi += -mp.alpha * j * mp.pz;
            }
            return d_phi;
        }

        private double D_x(Magnetic_Parameters mp, double j, double theta, double phi)
        {
            double dphi = D_Phi(mp, j, theta, phi);
            double dtheta = D_Theta(mp, j, theta, phi);
            return dtheta * Math.Cos(theta) * Math.Cos(phi) - dphi * Math.Sin(theta) * Math.Sin(phi);
        }

        private double D_y(Magnetic_Parameters mp, double j, double theta, double phi)
        {
            double dphi = D_Phi(mp, j, theta, phi);
            double dtheta = D_Theta(mp, j, theta, phi);
            return dtheta * Math.Cos(theta) * Math.Sin(phi) + dphi * Math.Sin(theta) * Math.Cos(phi);
        }

        private double D_z(Magnetic_Parameters mp, double j, double theta, double phi)
        {
            double dtheta = D_Theta(mp, j, theta, phi);
            return -dtheta * Math.Sin(theta);
        }
        // projects the system through time using the runge-kutta algorithm
        private void RK4(Magnetic_Parameters mp, ref double dt, double j, ref double theta, ref double phi, ref double time)
        {
            double dg = 0.01;
            bool good = false;
            while (good == false)
            {
                // creates dummy variables to be used in the RK4 calculation
                double k11, k12, k21, k22, k31, k32, k41, k42;
                double dtheta, dphi;
                // creates four projections to be used later
                k11 = D_Theta(mp, j, theta, phi);
                k12 = D_Phi(mp, j, theta, phi);
                k21 = D_Theta(mp, j, theta + k11 * dt / 2, phi + k12 * dt / 2);
                k22 = D_Phi(mp, j, theta + k11 * dt / 2, phi + k12 * dt / 2);
                k31 = D_Theta(mp, j, theta + k21 * dt / 2, phi + k22 * dt / 2);
                k32 = D_Phi(mp, j, theta + k21 * dt / 2, phi + k22 * dt / 2);
                k41 = D_Theta(mp, j, theta + k31 * dt, phi + k32 * dt);
                k42 = D_Phi(mp, j, theta + k31 * dt, phi + k32 * dt);
                dtheta = (k11 + 2 * k21 + 2 * k31 + k41) * dt / 6;
                dphi = (k12 + 2 * k22 + 2 * k32 + k42) * dt / 6;
                double dG = Math.Sqrt(dtheta * dtheta + dphi * dphi);
                if (dG < 0.5*dg && dt < 0.5)
                {
                    theta += dtheta;
                    phi += dphi;
                    time += dt;
                    dt *= 2;
                    good = true;
                }
                else if (dG < 2 * dg &&  dG > dg)
                {
                    theta += dtheta;
                    phi += dphi;
                    time += dt;
                    dt *= 0.5;
                    good = true;
                }
                else if (dG > 2 * dg)
                {
                    dt *= 0.5;
                }
                else
                {
                    // calculates the final position based on the results from the prevous four calculations.
                    theta = theta + dtheta;
                    phi = phi + dphi;
                    time += dt;
                    good = true;
                }
            }
        }

        public void RK42(Magnetic_Parameters mp, ref double dt, double dt_max, double j, ref double theta, ref double phi, ref double time)
        {
            double dg = 0.01;
            double dt_min = mp.delta_time_min;
            bool good = false;
            while (good == false)
            {
                // creates dummy variables to be used in the RK4 calculation
                double k11, k12, k21, k22, k31, k32, k41, k42;
                double dtheta, dphi;
                // creates four projections to be used later
                k11 = D_Theta2(mp, j, theta, phi, time);
                k12 = D_Phi2(mp, j, theta, phi, time);
                k21 = D_Theta2(mp, j, theta + k11 * dt / 2, phi + k12 * dt / 2, time + dt / 2);
                k22 = D_Phi2(mp, j, theta + k11 * dt / 2, phi + k12 * dt / 2, time + dt / 2);
                k31 = D_Theta2(mp, j, theta + k21 * dt / 2, phi + k22 * dt / 2, time + dt / 2);
                k32 = D_Phi2(mp, j, theta + k21 * dt / 2, phi + k22 * dt / 2, time + dt / 2);
                k41 = D_Theta2(mp, j, theta + k31 * dt, phi + k32 * dt, time);
                k42 = D_Phi2(mp, j, theta + k31 * dt, phi + k32 * dt, time);
                dtheta = (k11 + 2 * k21 + 2 * k31 + k41) * dt / 6;
                dphi = (k12 + 2 * k22 + 2 * k32 + k42) * dt / 6;
                double dG = Math.Sqrt(dtheta * dtheta + dphi * dphi);
                if (dG < 0.5 * dg && dt < dt_max)
                {
                    theta += dtheta;
                    phi += dphi;
                    time += dt;
                    dt *= 2;
                    good = true;
                }
                else if (dG < 2 * dg && dG > dg && dt > dt_min)
                {
                    theta += dtheta;
                    phi += dphi;
                    time += dt;
                    dt *= 0.5;
                    good = true;
                }
                else if (dG > 2 * dg && dt > dt_min)
                {
                    dt *= 0.5;
                }
                else
                {
                    // calculates the final position based on the results from the prevous four calculations.
                    theta = theta + dtheta;
                    phi = phi + dphi;
                    time += dt;
                    good = true;
                }
            }
        }

        // Changes the coordinates so theta is always between zero and pi
        // and so phi is always between zero and two pi
        public void Coord_Correction(ref double theta, ref double phi)
        {
            theta = theta % (2 * Math.PI);
            if (theta < 0.0)
            {
                theta = -theta;
                phi = phi + Math.PI;
            };
            if (theta > Math.PI)
            {
                theta = 2 * Math.PI - theta;
                phi = phi + Math.PI;
            };
            phi = phi % (2 * Math.PI);
            if (phi < 0.0)
            {
                phi += 2 * Math.PI;
            }
        }

        private double Normal_Distribution(double X)
        {
            double L = 0.0;
            double K = 0.0;
            double dCND = 0.0;
            const double a1 = 0.31938153;
            const double a2 = -0.356563782;
            const double a3 = 1.781477937;
            const double a4 = -1.821255978;
            const double a5 = 1.330274429;

            L = Math.Abs(X);
            K = 1.0 / (1.0 + 0.2316419 * L);
            dCND = 1.0 - 1.0 / Math.Sqrt(2 * Convert.ToDouble(Math.PI.ToString())) * Math.Exp(-L * L / 2.0) * (a1 * K + a2 * K * K + a3 * Math.Pow(K, 3.0) + a4 * Math.Pow(K, 4.0) + a5 * Math.Pow(K, 5.0));
            if (X < 0)
            {
                return 1.0 - dCND;
            }
            else
            {
                return dCND;
            }
        }
    }
}
