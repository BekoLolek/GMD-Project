# GMD - Final Product - Rhythm Invasion
The game is officially ready for deployment!
## Features added
* Double Hit Enemy
* Full Song

## Double Hit Enemy

### Idea
To add a little more spice and difficulty to the game, I introduced a double hit enemy. They have to be hit twice in one beat to kill. 

### Execution
Adding this enemy was quite easy, as I just had to add health to enemies and tweak hit detection logic to check for an additional input withing a set hit window of 0.2 seconds.

![HitDetectionTweakHealth](./Blog%20Post%20Images/Final/HitDetectionTweakHealth.png)
![EnemyHealth](./Blog%20Post%20Images/Final/EnemyHealth.png)


## Full Song

### Idea
This song has very prominent drums and a beat that is easy to follow, making it an ideal first level in the game.
### Execution
First I had to determine precisely where the beats are in the song using a sound editor program called Sonic Visualizer. In this program, I created vertical lines for each beat, numbered them and offset them by 8 (length of the floor) plus 12 (initial delay). From this point I could create a .csv file with beat numbers, lane and enemy type. I started by looking at events in the song, like special drum sequences (double hits) and emphasized beats to give me a starting point in developing the beatmap. Double hits use the double hit enemy with a normal enemy following on the next beat, while on the prominent beats the user has to hit 2 enemies on different lanes on the same beat. The guitar solos and choruses each follow a slightly varied 8 or 6 beat pattern to give the user something to get used to instead of complete randomness, making the game learnable instead of relying on pure skill and sense of rhythm. Around half way through the song as the player gets used to the premise of the game and the basic mechanics, the enemies start to come on every beat instead of every second one, adding some level of difficulty. Towards the end, as the music crescendos, the enemies start to come in waves instead of in a constant flow to signify that the level is ending soon, letting the player rest and cool off a bit. The values from the .csv file are loaded into a BeatmapSO object when the AudioManager is instantiated.

![BeatmapSO](./Blog%20Post%20Images/Final/BeatmapSO.png)
![Beatmap Loader](./Blog%20Post%20Images/Final/BeatmapLoader.png)



## Overall Architecture
The overall architecture of the game is simple. As the user selects a level, the game switches to the play scene and the PlayLevelManager gets the level data from the static LevelManager, ignites the Demon Portal at the end of the floor and instantiates the AudioManager for the level. Then the music starts playing, beat events are sent by AudioManager, making enemy spawning, enemy movement, enemy animations and floor animations come to life. After the song ends, the ScoreManager sends the score to ScoreSubmitter to be stored after the scene is automatically changed back to the main menu, updating the leaderboard.
