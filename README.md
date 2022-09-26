# AceAssault
"Ace Assault" is a rail shooter game created with Unity 3D.

<p align="center">
    <img src="Docs/gameplay.gif" width="500">
</p>

## How to Play

### Controls
Press the `Arrow Keys` or `WASD` to move your spaceship.

Press `CTRL` to shoot lasers.

## Build Notes 

### Unity Version
The project is built using `Unity 2021.3.10f1`.

### Render Pipeline
The project uses Unity's built-in render pipeline.

When launching the project in Unity, you might see the "HDRP Wizard" pop up.  If so, simply close the wizard and do NOT click "Fix All", "Fix", or any other buttons in the wizard.

> The "HDRP Wizard" detects that the game is using Unity's built-in render pipeline and asks if you want to convert to the High Definition Render Pipeline.  Be sure not to convert to HDRP.

## Technical Implementation

### Unity Technologies Used
The project implements the rail system via Unity's Timeline feature.  The lasers and special VFX are made using Unity's Particle System.

## Inspiration
This project was inspired by the "Complete C# Unity Game Developer 3D" course by GameDev.tv on Udemy.