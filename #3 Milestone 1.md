# GMD - Milestone 1 - Rhythm Invasion

## Features added
* Floor
* Beat detection
* Enemy spawning
* Enemy movement
* Player input detection and hit handling

## Floor

### Idea
I imagined the play platform to be a rectangular game object, split into square tiles, using two different colors in a checkboard pattern. The player has this floor in the middle of their field of view, with a portal at the end of the floor. 

### Execution
The process started by creating a rectangle 6 units wide and 16 units long. Then aligned the camera in the middle of the short side and changed its rotation on the X axis to 25, so it would face a bit down, creating a sense of direction and depth in 2.5D.

![Floor and Portal](./Blog%20Post%20Images/Milestone%201/Floor%20and%20portal.png)

## Beat Detection

### Idea
At first I wrote beat detection logic for every single component that needed it, but realizing that violates the DRY principle, I decided to move all that logic into one single class called BeatManager and handle beats as events of type System.Action<int>, called OnBeat.
### Execution
First, I determine the beat interval by dividing 60 (seconds in a minute) by the BPM of the song. This value is then used to divide the current time in the song, giving me the number of the beat that the song is at currently. After some error and exception handling, the event is triggered. 

![BeatManager](./Blog%20Post%20Images/Milestone%201/BeatManager.png)

## Enemy Spawning

### Idea
The enemies are spawned at the further end of the platform and need 8 beats to reach the arrows, to be decimated by the player.
### Execution
The spawning is controlled by the EnemySpawner object, that instantiates an enemy prefab on a lane, rotates it to face the camera. The spawning logic entirely depends on a BeatMapSO object, which is a Sriptable Object containing data for enemy type, lane and beat numbers to spawn on. The drawback of this approach is that I must manually enter all values if I want an enemy to spawn, but this way I have complete control over the actions that need to be taken by the player to be successful, hence making the game feel more natural and fun. I also had to make sure that the nex value in the beatmap is also checked on the current beat, as there might be cases where I want more enemies to spawn simultaneously, for example on lanes 0 and 2.

![Enemy Spawn](./Blog%20Post%20Images/Milestone%201/EnemySpawn.png)

## Enemy Movement

### Idea
Enemies move one tile per beat (2 units in Unity distance). They snap to their next location with very high speed, eliminating the need for move animation, while also giving the player a mechanic to get used to.
### Execution
Movement is very simple. At first I made the movement happen exactly on the beat in a coroutine with very high speed, basically enemies just snapped to the next position, but something was off. How can the player hit the enemies on beat if they move on the beat? They cannot. So I added a slight delay of 0.2 seconds to their movement, so technically they do not move on beat, but the user feels like they do. This has solved this problem amazingly.

![EnemyMove](./Blog%20Post%20Images/Milestone%201/EnemyMove.png)



## Player Input Detection and Hit Handling

### Idea
This part is quite straightforward. When enemies reach the hit zones, the player has to input the correct lane on the beat so the enemy gets destroyed.
### Execution
Despite wanting to keep the code DRY, I had to repeat the beat number logic in the hit detection script called RhythmInputManager, as I needed access to the previous and next beats to determine if the user hit the target in a given time window (0.2 seconds). This goes against my beliefs, but I could not figure out a better solution yet.

 

