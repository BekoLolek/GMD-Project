# GMD - Milestone 2 - Rhythm Invasion

## Features added
* Enemy animation
* Floor checkerboard animation
* Pulsing floor lane lines

## Enemy Animation

### Idea
I wanted the enemies to move in unison on every single beat, emphasizing that the user has to do things on the beat of the song.

### Execution
Now it was time to make the game look good. The enemies are little demons I got from the asset store and luckily their default animation fit with my game perfectly, except for one thing. Their animation was not in sync with the beat, so I had to manually restart it on every beat. Then came another problem: on every second beat they would be halfway through the animation, so I edited the EnemyAnimation script to account for this, making the animation smooth and flawless.

![EnemyMoveGif](./Blog%20Post%20Images/Milestone%201/EnemyMoveGif.gif)
![Enemy Animation Script](./Blog%20Post%20Images/Milestone%202/EnemyAnimationScript.png)

## Floor Checkerboard Animation

### Idea
To make beats more prominent, the colored tiles of the floor swap colors on every beat.
### Execution
I had to tile the floor and decided to do so in an alternating checkboard pattern using a custom ShaderGraph. In the graph, I create the pattern using simple calculations on the x and y values of the UV, influenced by a SwapValue property that determines if the pattern should be flipped or not. Then I just lerp 2 colors using this mask and output it to the floor object. The SwapValue is changed on beat by the FloorAlternatePattern script, creating an amazing animation under my little demons.

![FloorCheckerboardShaderGraph](./Blog%20Post%20Images/Milestone%202/FloorCheckerboardShaderGraph.png)
![FloorLaneCheckerboardGif](./Blog%20Post%20Images/Milestone%202/FloorCheckerboardPatternGif.gif)


## Pulsing Floor Lane Lines

### Idea
Being inspired by the game Rift of the Necrodancer, I decided to add vibrating lines to the middle of each lane. These lines would go from straight to a sine wave like form on each beat, making the floor feel more alive, putting more weight on the music part of the game
### Execution
This could be achieved through creating a line on the y part of the UV and changing the frequency of the sine wave to achieve a wave effect, then using a Fraction node and some extras I positioned them in the middle of each lane. At first it looked good, but I noticed that the lines started breaking up and becoming dotted the further they were from the camera. After some research, I found out that this was due to aliasing. The solution was to take the integral and derivative of the lines and Smoothstep between them using the original line as the input. This made the effect disappear, giving me a custom ShaderGraph anti-aliasing process. 
During my testing, something felt off about the lines in the middle of the lanes. The game did not feel as good to play as it was before I added them. I tried tweaking the line frequency, even added some delay after the beat, but I noticeably performed worse in hitting the demons accurately than before, so I decided to remove this feature completely. I spent a lot of time trying to make it feel better, but to no avail. This feature would look very cool, but until I figure out how to implement it properly, I will not use it.

![FloorLaneLineShaderGraph](./Blog%20Post%20Images/Milestone%202/FloorLaneLineShaderGraph.png)
![FloorLaneLineShaderGraph](./Blog%20Post%20Images/Milestone%202/FloorLaneLinesGif.gif)




 



