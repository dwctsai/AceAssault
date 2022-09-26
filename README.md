# AceAssault
"Ace Assault" is a rail shooter game created with Unity 3D.

<p align="center">
    <img src="Docs/gameplay.gif" width="500">
</p>

## How to Play

### Controls
Press `Arrow Keys` or `WASD` to move your spaceship.

Press `CTRL` to shoot lasers.

## Technical Implementation

### Technologies Used
The project is implemented using the following:
- C#
- The rail system is implemented using Unity's Timeline feature and Animation tracks.  A Master Timeline organizes the player spaceship's rail as well as control tracks controlling enemy waves.
- The lasers, explosions, and special VFX are implemented using Unity's Particle System.
- The map is created using Unity's Terrain Tools.
- Bloom, Ambient Occlusion, Color Grading, Vignetting, and Auto Exposure are implemented using Unity's Post Processing package.

## Build Notes 

### Unity Version
The project is built using `Unity 2021.3.10f1`.

### Render Pipeline
The project uses Unity's built-in render pipeline.

When launching the project in Unity, you might see the "HDRP Wizard" pop up.  If so, simply close the wizard and do NOT click "Fix All", "Fix", or any other buttons in the wizard.

> The "HDRP Wizard" detects that the game is using Unity's built-in render pipeline and asks if you want to convert to the High Definition Render Pipeline.  Be sure not to convert to HDRP.

> To disable the "HDRP Wizard" from popping up every time you start Unity, scroll down to the bottom of the wizard and un-check `Show on start`

### GitHub Storage Limitations
Due to GitHub's maximum file size limitations, this repository uses Git LFS for files over 100 MB in size.  However, due to GitHub's Git LFS implementation itself having a maximum storage quota (2 GB for base tier), this repository cannot hold all of the Unity assets used in the final build of this project.  However, I have included all of the C# code used in this project, which can be found in `Assets\Scripts`.

## Inspiration
This project was inspired by the "Complete C# Unity Game Developer 3D" course by GameDev.tv on Udemy.