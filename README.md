# Micro Lab Simulator – Guided Titration (Unity)

## Overview

Micro Lab Simulator is a Unity-based interactive 3D application that simulates a **guided titration experiment**.
The project focuses on **step-by-step workflow, user interaction, and clear UI/UX**, replicating a simplified laboratory environment.

This assignment demonstrates **Unity fundamentals, state-driven interaction, UI flow, and simulation logic**.

### Guided Workflow

* Step-by-step instructions with narration
* Enforced order (users cannot skip steps)

###  Interactive Controls

* Start, Fill, Titrate, and Finish buttons
* Slider-controlled liquid flow (burette → flask)

### Titration Simulation

* Burette liquid decreases dynamically
* Flask liquid increases in real time
* Endpoint detection (threshold-based)

### Visual Feedback

* Liquid transfer animation using transform scaling
* Color change at endpoint
* Instruction panel updates dynamically

### Narration System

* Audio + text-based guidance
* Typewriter text animation
* Centralized narration manager

### Result System

* Displays final reading
* Accurate value captured at Finish step

### Reset Functionality

* Restart experiment with one click

---

## Project Structure

```
Assets/
│
├── Scenes/
├── Scripts/
│   ├── NarrationManager.cs
│   ├── UIbuttons.cs
│   ├── SliderController.cs
│   ├── LiquidController.cs
│
├── Prefabs/
├── Materials/
├── UI/
├── Models/
```

---

## Core Systems

### 1. Narration Manager

* Controls audio playback and instruction text
* Ensures no overlapping narration
* Handles typing animation

### 2. UI Manager (UIbuttons)

* Handles button interactions
* Controls object visibility (ON/OFF states)
* Triggers narration per step

### 3. Slider Controller

* Manages titration flow
* Detects endpoint threshold
* Triggers UI and result activation

### 4. Liquid Controller

* Simulates liquid transfer using scaling
* Maintains realistic flow behavior
* Syncs with slider input

---

## How It Works

1. **Start Application**

   * Welcome narration plays automatically

2. **Click Start**

   * Lab setup appears
   * Instruction to fill burette

3. **Fill Burette**

   * Enables titration controls

4. **Titration**

   * Use slider to control flow
   * Liquid transfers from burette to flask

5. **Endpoint Detection**

   * Triggered at threshold (≈0.80)
   * Flask color changes

6. **Finish**

   * Final value is recorded
   * Result displayed

---

## Tools & Technologies

* Unity Engine (3D Core)
* C#
* TextMeshPro (UI)
* Unity UI System (UGUI)
* Basic 3D primitives (for lab setup)

---

## How to Run

1. Clone the repository
2. Open project in Unity Hub
3. Open the main scene
4. Click Play

---

## Design Decisions

* Used **transform scaling instead of physics** for liquid simulation (performance-friendly)
* Implemented **state-based UI flow** to prevent invalid interactions
* Centralized narration system for **clean architecture**

---

## Possible Improvements

* Smooth liquid shader (instead of scale-based)
* XR/VR interaction support
* Sound effects for interactions
* Better UI animations
* Real-world measurement units (mL mapping)

---

## Note

This project was built as part of a **Unity Developer assignment** to demonstrate:

* Clean coding practices
* Interactive system design
* User-guided simulation

---
