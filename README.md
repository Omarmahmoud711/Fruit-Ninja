# Fruit Slicing Game

Welcome to the Fruit Slicing Game! This Unity-based game lets you slice fruits while avoiding bombs. The game mechanics involve interacting with objects in the scene to score points by slicing fruits and avoiding penalties by not slicing bombs.



## Game Overview
In this game, you play as a blade, slicing through fruits to score points. Be careful not to hit bombs, as doing so will trigger a bomb sequence and reset the game. The game continues until you lose all your chances by hitting too many bombs.

## Game Mechanics
- **Slicing Fruits:** Use the mouse to control the blade and slice through fruits.
- **Avoiding Bombs:** Bombs will appear randomly among the fruits. Do not slice them, or you'll trigger an explosion sequence.
- **Scoring:** The goal is to slice as many fruits as possible. Points are displayed as 'X' marks in the score section.
- **Game Over:** If you hit a bomb or reach the score limit, the game resets.

## Scripts
The game uses several C# scripts to manage game mechanics, blade behavior, spawning of fruits and bombs, and game management.

- **Blade:** Handles slicing logic, detecting input, and maintaining slicing trail.
- **Bombing:** Manages what happens when a bomb is triggered.
- **GameManager:** Coordinates game state, including score management, restarting, and handling game over sequences.
- **Slicing:** Handles the logic for fruit slicing and particle effects.
- **Spawner:** Controls the spawning of fruits and bombs in the game.
- **Trigger:** Manages trigger-based events, such as scoring when fruit is sliced.


