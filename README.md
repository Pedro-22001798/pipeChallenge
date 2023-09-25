# Circuit Conundrum

## Brief overview:
### 1. How the project works:
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
