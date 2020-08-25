function [ m ] = make_m( time, theta, phi )
%MAKE_M Summary of this function goes here
%   Detailed explanation goes here
m.t = time;
m.x = sin(theta).*cos(phi);
m.y = sin(theta).*sin(phi);
m.z = cos(theta);

end

