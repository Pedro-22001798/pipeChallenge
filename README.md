# Circuit Conundrum

## Brief overview:
### 1. How the game works:
As soon as the player loads the game he is presented with a level selection menu where he can see the unlocked levels (#1 only for default or more if the player already played before) and also the locked levels. Below every level button, there are 3 stars.
They represent the best level score achieved.
After selecting a level by clicking on it. The level selection closes, sliding to the left of the screen, and the level loads. A timer will start at the top of the screen and it is used to determine the final player score for the played level like this:
| Time To Complete      | Score |
| ----------- | ----------- |
| 2+ min.      | 0 stars       |
| 1.2+m to 2m   | 1 star        |
| 30+s to 1.2m   | 2 stars        |
| 30-s   | 3 stars        |

There are 5 types of tiles available:
1. Normal Pipe (used for vertical or horizontal sequences) (can be rotated)
2. Curve Pipe (used for changing from vertical to horizontal or horizontal to vertical sequences) (can be rotated)
3. Light Pipe (produces light constantly) (can't be rotated)
4. End Pipe (receives light) (can be rotated)
5. Empty Pipe (filler) (not interactable)

**The main goal of the game is to light every end pipe by rotating the available pipes in order to form sequences taking the light from the light pipe to the end pipes**

After every end pipe receives light the player can no longer interact with the game and he will be presented with a level completion message and the score he got from the time taken to complete the level.

### 2. How maps are created:
All the maps are strings that are kept inside the 'Levels' script. I decided to do it this way because of Android security reasons. My first plan was to have several files named "(level number).pipes" but the Android system did not load them so I had to improvise.
A standard 2x2 map is built like this:
"PipeType,PipeRotation,PipeType,PipeRotation\n +"
"PipeType,PipeRotation,PipeType,PipeRotation"

The game will load every string and detect the grid size and also every pipe with it's rotation.

### 3. How the project works:
Every tile and map has its own objects and respective interfaces. The 'Levels' script creates a list containing every map. A 'LevelLoader' then takes those maps and will take them one by one to the 'FileReader' where the map is read and created (ILevel is created). By this stage, if there was a previous Save File from 'SaveManager' every 'ILevel' created will have its maximum score replaced by the score saved and also if the level is locked or not, but if there isn't one, the created maps will be sent to 'View' that will create every level button for the player to choose which level he wants to play (by default only the first will be available). Every level button has an ILevel on it (defined inside 'View', indicating the game what level should be loaded when clicking that button. When a level is being loaded (level button click) the 'ILevel' will be sent to 'LevelLoader' where the CurrentLevel being played will be updated to the ILevel's level number. After that, the 'View' will receive the 'ILevel' being loaded and will analyze every 'IPipe' inside it. Every 'IPipe' has both Row and Col coordinates to know where the pipe should be placed on the level grid and also its rotation and pipe type. The 'View' will analyze every one of them inside the 'ILevel' creating a new gameobject for each one of them. Since Pipe and IPipe were not designed to be MonoBehaviours they cannot be attached to gameobjects and for that reason, I had to create a 'PipeClick' script that holds the pipe crucial information and sends every extra information to the respective 'IPipe', for example, a pipe rotation. Once everything is loaded, the 'LevelTimer' will start and the 'GameStateMachine' will update the GameState from "Paused" to "Playing" allowing the player clicks to be detected by the 'InputManager'. The player will be able to spot which pipes are transporting light and which aren't because of the Bloom effect added to the pipes that are transporting energy, giving visual feedback of level progression. Every pipe rotation has a delay between clicks, not allowing the player to spam rotations, and after one is done the Colliders on each pipe will detect a new collision or an exit of one updating a list inside every 'IPipe' containing all the connections done with that specific pipe. This allowed me to have a recursive method that would check for sequences from the light sources until there were no more connections inside 'ConnectionsController'. This script will check from every light source (knowing light sources are transporting light) and will light every pipe that is inside the sequence created and after that will check with the 'LevelController' that has a list of every end pipe of the chosen map if the level has been beaten or not (every end pipe is transporting light). If the level has been won the 'LevelController' will return "True" and the final score will be calculated according to the elapsed time. If the level had already been won the next level will not be unlocked since it has already been unlocked before and if the score is higher than the previous highest score for that level a new score is defined within the 'ILevel', adding the difference to 'PlayerScore'.

During gameplay the player will be able to click the options menu that is on the bottom center of the screen, showing 5 different options:
### 4. Game Options:
| Options      | Function |
| ----------- | ----------- |
| 1. Volume icon      | Enable/Disable sound effects       |
| 2. Restart icon   | Restarts the current level and also the timer        |
| 3. Levels icon   | Leaves the current level and opens the level selection menu        |
| 4. Brush icon   | Opens the skins menu to change the pipe skins and also the background music menu to choose which music to play        |
| 5. Music note icon   | Enable/Disable background music        |
