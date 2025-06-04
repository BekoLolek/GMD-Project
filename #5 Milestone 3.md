# GMD - Milestone 3 - Rhythm Invasion

## Features added
* Main Menu UI
* Leaderboard UI and Score
* Game Scene UI

## Main Menu UI

### Idea
Every game needs a main menu, so I have decided to go with the standard Play, Options and Quit menu panels. The Play button takes the user to a Level Selector, Options allows them to change volume levels and Quit is quite self-explanatory. 

### Execution
The level selector shows the title, bpm and cover image of the songs and the artist. The user can select a level using a carousel, with left and right buttons to navigate and a select button to play the level. If this button is pressed, a static LevelManager object is created that holds and passes the selected level data to the PlayScene. The data for each level is stored in a LevelDataSO Scriptable Object, so enable serialization and unifying type, allowing for easy editing and adding.

![MainMenuUIGif](./Blog%20Post%20Images/Milestone%203/MainMenuUIGif.gif)

## Leaderboard UI and Score

### Idea
To create goals for the player and something to work towards, I introduced a leaderboard display to track the best players through all levels.
### Execution
A quite substantial challenge arose during the creation of the leaderboard panel. I had to edit my LevelDataSO object to house additional data for the song. I created a LeaderboardDataSO Scriptable Object and additional scripts to load and store these data entries. The LeaderboardStorage script stores all data in the Application’s persistent storage in json format to make sure nothing is lost if the game is restarted and to enable loading new entries during (or should I say after) gameplay. 

![LeaderboardUIGif](./Blog%20Post%20Images/Milestone%203/LeaderboardUIGif.gif)
![LeaderboardUIGif](./Blog%20Post%20Images/Milestone%203/ScoreGif.gif)



## Game Scene UI

### Idea
What do I store in the leaderboard you might ask. Well, the score of the levels of course. The goal was to reward skilled players, while not making new users feel bad to ensure that they stick around, practice and have motivation to get better at the game.
### Execution
After the song starts, 50 points are added to the total score per second until it ends. If the user hits a demon correctly, they are awarded 100 points, but misses deduct 50 points each. After every 10 consecutive correct hit the multiplier increases by one (up to 10), influencing the constant score gain, successful hit gain, but also miss point loss. On mistake, the multiplier resets to 1 and it has to be stacked up again to take effect again. This way, good players are rewarded with higher scores as the passive score increase takes up a significant amount of the total final score, but new players do not feel left behind as if they miss on a multiplier of 1 or 2, the miss does not deduct a huge amount.

![ScoreScript](./Blog%20Post%20Images/Milestone%203/ScoreScript.png)

