# Mousey the runner

An endless runner game, developed for a mobile device. You can try the apk.

![](Demo/Mousey.gif)   ![](Demo/GameOver.gif)

### Summary of functionalities:
#### UI
- Main menu - a separate scene showing the player name, max score and with option to mute the game.  
- Endless runner scene - HUD with current state of the player (cheese is health, coins are score) and pause button
- Death menu

#### Database
Saved global settings in PlayerPrefs, like player name, max score, last mute or unmute choise. They are saved after closing the game.

#### Navigation
- Navigating in 4 directions - Up (jump), Down (roll), Left (move left), Right (move righ)
- Implemented two consistent types of navigation - using keyboard and using swipe gestures (with custom gesture recognition)

#### Endless path generation
Using an object pool with paths which will be reused.

#### Game elements
Object pool with reused all types of game elements. Easily extendable for more types of game elements.
- Obstacles - big tree, lake, slanted tree - decrease the health on collision with the player
- Bonuses - coins (give score), cheese (gives health)

#### Animations
Rig animations for running, jump and rool, dive and roll. 

#### Audio system
- Looping background music
- Sounds for different actions like click button, earn coin, eat cheese, crash tree, jump

#### Vibration on mobile device when decrease health

#### Camera
- Following the player
- Has shader effect for Game over

