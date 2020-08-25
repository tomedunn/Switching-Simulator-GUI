This was a program I used as part of my graduate research. The program was originally 
written in C# using Visual Studio and included heavy integration with Matlab.

# Key Files
Most of the files are there to support the old GUI and aren't strictly needed to run 
simulations using the program. The files needed to run simulations are:

 * Magnetic_Parameters.cs
   * Magnetic_Parameters - Class containing all the magnetic parameters needed to characterize 
     the macro-spin free layer to be simulated.
 * MersenneTwister.cs
   * MersenneTwister - Random number generator used throughout the program.
 * Magnetic_Simulator_Demag.cs
   * Energy - Calculates the total energy of the free layer.
   * Noise - Adds random motion to the free layer spin.
     * Normal_Distribution - Converts a random number between 0 and 1 to a random number 
       following a normal distribution.
   * RK42 - 4th order Runge-Kutta function used to integrate the system forward in time.
     * D_Phi2
     * D_Theta2
   * Coord_Correction - Function for adjusting theta and phi to keep them within their normal bounds.

The rest of the program is effectively there to plot results via Matlab.


