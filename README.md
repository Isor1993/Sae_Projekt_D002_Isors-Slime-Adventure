# 📘 README

### SAE Institute Stuttgart

**Module:** D002 – Game Programming 2D (K2 / S2)  
**Student:** Eric Rosenberg  
**Project:** 2D Jump’n’Run Controller (Unity)

---

## 1. Base Module

This project is the submission of **Eric Rosenberg** for the module  
**D002 – Game Programming 2D (K2 / S2)** at **SAE Institute Stuttgart**.

The project **“2D Jump’n’Run Controller”** was developed using the **Unity Game Engine** as a **2D gameplay prototype**.  
The focus is on a **modular, physics-based and configurable player controller**, designed to implement common jump’n’run mechanics and later be adapted for a full game project.

---

## 2. Missing Submission

*(not applicable – all required components are included)*

---

## 3. Multiple Submissions in One Folder

*(not applicable – single project)*

---

## 4. Group Work

*(not applicable – individual work by Eric Rosenberg)*

---

## 5. Feature Overview

### 🎮 Player Controller – Core Features

- horizontal movement (left / right)
- physics-based movement using **Rigidbody2D**
- ground jump
- **coyote time**
- **jump buffer**
- **air multi-jump** (configurable)
- **wall jump** (configurable)
- sprint movement
- separated ground and air movement logic
- full configuration via the Unity Inspector

---

### 🧠 Movement & Jump System

**MoveBehaviour**
- separate ground and air movement
- acceleration, deceleration and speed clamping
- sprint support
- reduced air control

**JumpBehaviour**
- ground, coyote, air and wall jumps
- decision-making via `JumpStateData`
- internal jump counter and state handling

---

### 🧱 Collision & Environment Detection

**GroundCheck**
- overlap box based ground detection
- configurable size, offset and layer mask
- optional gizmo visualization

**WallCheck**
- multiple overlap box wall checks
- configurable per side
- optional gizmo visualization

---

### 🎛️ Configuration

**MoveConfig (ScriptableObject)**
- walk & sprint speed
- maximum speeds
- acceleration / deceleration
- air control factor

**JumpConfig (ScriptableObject)**
- jump force
- coyote time duration
- jump buffer time
- maximum air jumps

---

### ⌨️ Input System

- Unity Input System
- action map: **Slime**
- actions: Move, Jump, Sprint
- clean separation of `Update` and `FixedUpdate`

---

## ⚙️ Technical Details

- **Engine:** Unity (2D)
- **Language:** C#
- **Physics:** Unity 2D Physics
- **Input:** Unity Input System
- **Platform:** Windows
- **IDE:** Visual Studio
- **Architecture:** Modular / SRP-oriented

---

## 📂 Folder Structure

```
2_2D Jump'n'Run Controller (K2, S2)/
│
├── src/
│   ├── Assets/
│   ├── Packages/
│   ├── ProjectSettings/
│   └── Isor Slime Adventure.sln
│
├── release/
│   ├── Isor Slime Adventure.exe
│   ├── Isor Slime Adventure_Data/
│   ├── UnityPlayer.dll
│   └── UnityCrashHandler64.exe
│
└── other/
    ├── Documents/
    ├── Screenshots/
    └── Gameplay.mp4
```

---

## 🧾 Submission Details

- **Submission type:** Individual work  
- **Media:** Gameplay video, screenshots  
- **Required file:** README.md  
- **Requirements met:** Yes  

---

## 🧠 Summary

This project demonstrates a **clean and extensible 2D jump’n’run controller** with a strong focus on structure, physics and maintainability.  
It is intended as a **technical foundation for future 2D game projects**.

---

**Stuttgart, December 2025**  
*© 2025 Eric Rosenberg – SAE Institute Stuttgart*
