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
Every tile and map has its own objects and respective interfaces. The 'Levels' script creates a list containing every map. A 'LevelLoader' then takes those maps and will take them one by one to the 'FileReader' where the map is read and created (ILevel is created). By this stage, if there was a previous Save File from 'SaveManager' every 'ILevel' created will have its maximum score replaced by the score saved and also if the level is locked or not, but if there isn't one, the created maps will be sent to 'View' that will create every level button for the player to choose which level he wants to play (by default only the first will be available). Every level button has an ILevel on it (defined inside 'View', indicating the game what level should be loaded when clicking that button. When a level is being loaded (level button click) the 'ILevel' will be sent to 'LevelLoader' where the CurrentLevel being played will be updated to the ILevel's level number. After that, the 'View' will receive the 'ILevel' being loaded and will analyze every 'IPipe' inside it. Every 'IPipe' has both Row and Col coordinates to know where the pipe should be placed on the level grid and also its rotation and pipe type. The 'View' will analyze every one of them inside the 'ILevel' creating a new gameobject for each one of them. Since Pipe and IPipe were not designed to be MonoBehaviours they cannot be attached to gameobjects and for that reason, I had to create a 'PipeClick' script that holds the pipe crucial information and sends every extra information to the respective 'IPipe', for example, a pipe rotation. Once everything is loaded, the 'LevelTimer' will start and the 'GameStateMachine' will update the GameState from "Paused" to "Playing" allowing the player clicks to be detected by the 'InputManager'.
