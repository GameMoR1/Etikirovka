;home_y,home_z,home_a,home_b
G28 Y0 Z0 A0 B0 
;acceleration_b
M201 B2000
G90
;clamp_b,feedrate_b
G0 B1 F1
;rotate_a
G0 A1
;start_z,start_y,feedrate_all 
G0 Z1 Y1 F1
G91
;start_x,feedrate_x
G0 X1 F1
;clamp_y
G0 Y1
;end_z,end_a,feedrate_all
G0 Z1 A1 F1
;home_x
G28 X0 
;delay_s
G4 S1
