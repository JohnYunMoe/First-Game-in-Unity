<div align="center">

# First Unity Game – Endless 2D Platform Runner

**Semester:** Fall 2024  
**Course:** Unity for Games  
**Author:** *Your Name (replace if sharing publicly)*

Main Menu | Gameplay | Game Over
:--:|:--:|:--:
<img src="First%20Project%20Submission%20Photos/MainMenu.png" width="260" /> | <img src="First%20Project%20Submission%20Photos/Gameplay.png" width="260" /> | <img src="First%20Project%20Submission%20Photos/GameOver.png" width="260" />

Additional Screenshot:

<img src="First%20Project%20Submission%20Photos/Screenshot%202024-10-20%20183212.png" width="600" />

</div>

## 🎮 Game Overview
This project is my very first game made in Unity: an **endless side‑scrolling 2D platform runner**. The player moves forward across continuously spawning ground segments while avoiding hazards (spikes) and collecting coins (mechanic stubbed / partially implemented). The objective is to survive as long as possible—distance becomes the score.

The game features a moving camera world, procedural ground spawning, hazard spawning, background parallax scrolling, simple physics‑based movement, UI updates, audio feedback, and scene management for menu → gameplay → game over flow.

## ✨ Core Features
- **Player Movement & Jumping** (`PlayerMovement.cs`): Rigidbody2D force-based horizontal movement and jumping gated by ground detection; arrow key controls.
- **Endless Ground Generation** (`GameManager.cs`): Spawns sequential ground tiles ahead of the player based on position; keeps the world feeling infinite.
- **Hazard (Spike) Spawning** (`GameManager.cs`): Timed random spike instantiation within a horizontal range ahead of the camera.
- **(Planned) Coin Collection** (`PlayerMovement.cs` + commented logic in `GameManager.cs`): Trigger-based collection plays SFX and destroys coin. Spawn system scaffolded but disabled/commented for iteration.
- **Scrolling Background** (`Scrolling.cs`): Texture offset update to simulate parallax motion independent of gameplay objects.
- **Score System** (`UIManager.cs`): Displays distance traveled from starting point (using `Vector3.Distance`) formatted to 2 decimals.
- **Audio Management** (`MusicManager.cs` + indexed AudioSources): Background loop, jump, coin, and game over sounds retrieved via tagged manager object.
- **Pause & Scene Flow** (`ButtonManager.cs`): Time scaling to pause/unpause, and menu button that loads the gameplay scene. Game over scene loaded on collision with enemies.
- **Game State Transitions**: SceneManager used for Menu (0) → Gameplay (1) → Game Over (2).

## 🧠 Skills Learned / Practiced
| Area | What I Implemented |
|------|--------------------|
| Unity Basics | Project setup, scenes, prefabs, tagging objects (e.g., Music Manager tag) |
| 2D Physics | Rigidbody2D force application for movement & jumping |
| Input Handling | Polling arrow keys with `Input.GetKey`/`GetKeyDown` |
| Procedural Level Design | Dynamic ground segment spawning & hazard spawning timing logic |
| Game Loops | Using `Update()` & timers (`Time.deltaTime`) to drive spawning and UI updates |
| UI & Text | TextMeshPro integration for live score display |
| Audio | Multiple `AudioSource` components for background music & SFX; playback triggers |
| Scene Management | Loading scenes by index for menu/game/game over flow |
| State & Conditions | Grounded checks, timers, collision tag checks, pause toggle via `Time.timeScale` |
| Code Organization | Separate managers: GameManager, UIManager, MusicManager, ButtonManager |
| Parallax / Visual Polish | Background texture scrolling via material offset manipulation |
| Version Control Mindset | Structuring a Unity repo with Scripts, Prefabs, Sprites, Audio, Materials |

## 🗂️ Project Structure (Key Folders)
```
Assets/
	Scripts/
		PlayerMovement.cs      # Input + movement + jump + SFX trigger + coin collection
		GameManager.cs         # Spawning (ground, spikes), scrolling world logic
		UIManager.cs           # Distance-based scoring UI
		ButtonManager.cs       # Menu & pause logic
		MusicManager.cs        # Background music (manages AudioSources)
		Scrolling.cs           # Background parallax texture offset
	Audio/                  # OGG sound effects (coin, footstep, jump, game over, etc.)
	Sprites/                # Visual assets for player, environment, UI (not enumerated here)
	Prefabs/                # Reusable game objects (player, spikes, ground tiles, etc.)
	Materials/              # Material assets for sprites / backgrounds
	Scenes/                 # Likely: Main Menu, Gameplay, Game Over (indices 0,1,2)
First Project Submission Photos/  # Screenshots used in README
ProjectSettings/          # Unity project & engine config
Packages/                 # Unity package manifest
```

## 🕹️ How to Play
1. Launch the Main Menu scene (index 0) and press Play.
2. Use Arrow Keys:
	 - Up: Jump (only when on ground)
	 - Left / Right: Move horizontally (force-based acceleration)
	 - Down: Quick downward force (situational)
3. Avoid spikes. Collision with an Enemy-tagged spike loads the Game Over scene.
4. Distance traveled is shown as the score (top UI).
5. (Future) Collect coins: touch them to gain points & play coin SFX.
6. Press Pause (UI button / mapped) to freeze and resume (`Time.timeScale`).

## 🔊 Audio System
Multiple `AudioSource` components live on a single tagged Music Manager object. `PlayerMovement` references them by index for:
- Index 0: Background loop (started in `MusicManager`)
- Index 1: Jump SFX
- Index 2: Coin SFX
- Index 3: Game Over SFX

Potential Improvement: Replace positional index access with named serialized fields or an enum-based lookup to reduce brittleness.

## 🧪 Notable Code Snippets
```csharp
// Player jump & grounded control
if (Input.GetKeyDown(KeyCode.UpArrow) && onGround) {
		rb.AddForce(Vector2.up * jumpspeed);
		onGround = false;
		jumpSFX.Play();
}

// Endless ground spawning trigger
if (Player.position.x > nextSpawnPoint - groundLength) {
		SpawnGround();
}

// Background scroll effect
bkg.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
```

## 🧭 Design Notes
- Chose force-based movement instead of directly manipulating transform for more natural physics interaction.
- Score switched from time-based to distance-based for more meaningful player feedback.
- Separated managers to keep single-responsibility structure early on.
- Used `Time.timeScale` for pause to quickly stop all physics & timers.
- Commented-out coin spawning left intentionally for incremental development.

## 🚧 Known Limitations / Future Improvements
- Add proper coin spawning & scoring integration (currently distance only).
- Introduce difficulty scaling (faster camera / more spikes over time).
- Replace raw `FindGameObjectWithTag` with serialized references for performance & clarity.
- Improve grounded detection (raycast vs relying solely on collision tag timing).
- Add animation controller & sprite swaps for run / jump states.
- Implement object pooling for spikes & ground to reduce runtime allocations.
- Add mobile touch controls or WASD mapping.
- Persist high score using `PlayerPrefs`.
- Add layered parallax for depth.
- Replace AudioSource indexing with a ScriptableObject audio registry.

## 🏁 What I Learned (Reflection)
Building this first Unity project taught me how interconnected systems (input, physics, spawning, UI, audio, scenes) form a gameplay loop. I practiced debugging movement feel, timing spawn intervals, organizing scripts into focused roles, and iterating quickly by stubbing future systems (coins). It also gave me foundational confidence to tackle more advanced topics like pooling, animation controllers, and data-driven design next.

## 🛠️ Tech & Tools
- Unity (version from `ProjectSettings/ProjectVersion.txt`)
- C# scripting (MonoBehaviour lifecycle: Start, Update, triggers & collisions)
- TextMeshPro for UI
- Built-in 2D physics (Rigidbody2D, Colliders)
- Audio pipeline (AudioSource components)
---
Thanks for checking out my very first Unity game! Feedback and suggestions are welcome.

