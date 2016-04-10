# ToyRobotSimulatorSolution

Toy Robot Simulator Tests:

Test 1:
place 1,2,south
left
right
left
left
left
left
move
move
report

output: 1,0,South

Test 2:
place -2,0,north
place 2,0,north
move
move
move
move
right
move
move
right
move
move
move
move
right
report

output: 4,0,West

Test 3:
place 1,1,south
place 2,3,north
left
move
move
place 4,4,east
report

output: 4,4,east

Test 4:
place 1,1,west
move 2,4,south
move
move
report

output: 0,1,West
