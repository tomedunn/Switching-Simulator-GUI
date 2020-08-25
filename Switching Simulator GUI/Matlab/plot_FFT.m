function plot_FFT( m )
%PLOT_FFT Summary of this function goes here
%   Detailed explanation goes here
%% Unpack parameters
t = m.t;
x = m.x - mean(m.x);
y = m.y - mean(m.y);
z = m.z - mean(m.z);

%% Calculate FFT amplitude and frequencies
L = length(t);
T = max(m.t)/L;
Fs = 1/T;
NFFT = 2^nextpow2(L);
Y = fft(z,NFFT)/L;
f = Fs/2*linspace(0,1,NFFT/2+1);

%% Plot single-sided amplitude spectrum.
i_start = floor(L*0.01);
fGhz = f(i_start:end)*1e-9;
amplitude = 2*abs(Y(1:NFFT/2+1));
amplitude = amplitude(i_start:end);
h.fig = figure;
hold on;
h.plot = plot(fGhz,amplitude) ;
h.title = title(sprintf('Precessional frequency via FFT - max = %f Ghz',max(fGhz(amplitude == max(amplitude)))));
h.xlabel = xlabel('Frequency (GHz)');
h.ylabel = ylabel('Amplitude');
h.scatter = scatter(fGhz(amplitude == max(amplitude)),max(amplitude),'FaceColor','r','Marker','s');
xlim([f(i_start)*1e-9,50]);
hold off;
end

