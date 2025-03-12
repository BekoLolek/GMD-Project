Roll-a-Ball

At first, I started by completing the tutorial. I have had no difficulties during this, as I have experience with Unity and also because the tutorial was very clear and straightforward. Next, I added a second level, an obstacle course. This level can be accessed, once the player has collected all the PickUp items (rotating yellow cubes). The moment the player collects the last cube, the level one enemy deactivates and the middle of the North wall opens up. This leads to a small corridor that is blocked by a green wall. When the player goes through this green wall, they get into a wider straight corridor, populated by different obstacles. As soon as the player crosses the green wall, two very fast enemies activate and start to chase the player. The goal on this level is to get to the end (marked by another green wall) as fast as possible without getting caught or falling off the map. There are also optional hidden PickUps in this area up for grabs.

Player

The player has a standard RigidBody3D and adjustable speed and acceleration. In my experience playing this game, the movement is a bit weird and takes some time to get used to. The acceleration can be turned off, but it is way more fun to play having the ability to reach crazy speeds and hit jumps that seem impossible at first.

Enemy

All enemies chase players, as their NavMeshAgent destination is set to the Player's current position at all times. In the first level, the single enemy is slower as the Player does not have much space to outmaneuvre the Enemy, while on the second level, the two Enemies are significantly faster due to the size of the second level (almost 5 times as the first).

PickUp

All PickUps are the same Prefab. They rotate around their 3 axes and disappear when they collide with the Player. The moment they disappear, a count is updated, displaying how many cubes the Player has picked up yet.
