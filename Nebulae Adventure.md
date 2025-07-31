# Project Title - Nebulae Adventure

<img width="1914" height="857" alt="6197ea87e1082759842b4dce300a9833" src="https://github.com/user-attachments/assets/85301363-15e3-410a-9cc5-aec518590c61" />

---

## Overview & Project Description

### Game Introduction
The game is set in a mysterious interstellar environment, where an endlessly extending stone pathway hovers amidst the cosmic nebulae. Players control the character, Lisa, guiding her forward along this path while maneuvering through obstacles by moving left, right, and jumping to evade hazards. Throughout the journey, players must collect reward coins while avoiding various obstacles and hostile entities. Victory is achieved when Lisa accumulates a total score of 25 points, meeting the winning condition.

### Game Mechanics
**Character Controls:** Players use the controller to manoeuvre Lisa to move left, right and jump, navigating narrow paths, avoiding hazards and collecting rewards.

**Random Element Refresh:** A variety of gameplay elements appear randomly on the path, including enemies, obstacles, blood packs and bonus coins.

**Stamina System:**
Lisa initially has 3 health points.
Each time you collide with an enemy, you lose 1 health point.
Eating a blood pack restores 1 health point, but blood packs are less likely to refresh.
If you run out of health (0 points) or fall off a narrow path, the game ends immediately.

**Bonus Coins and Points:** There are three types of bonus coins, which correspond to different points:

Gold Coin: 3 points

Silver Coin: 2 points

Bronze Coin: 1 point

Obstacles: Obstacles will not directly harm Lisa, but they will block the path of progress and make it more difficult to pass the level.

Multiplayer Mode
In multiplayer mode, each player will complete the same mission independently, and the player who takes the shortest time to clear the level will win. If more than one player dies at the same time, the player with the most points at the time of death will win.

### Controller
This controller is a rough controller prototype and consists of 3 four-pin switch buttons corresponding to:

Right shift button (Pin 2)

Jump button (Pin 3)

The left move button (Pin 4)

The three buttons are displayed directly and concisely in front of the player for easy and intuitive operation and are used to send commands to the game to control the character Lisa to perform left/right movement and jumping actions.

---

## Supplies & Materials

The following section provides a detailed explanation of the technical aspects of the project, including all hardware components, software tools, sources of downloaded assets, and relevant visual documentation.

### Components Used:  
Controller Hardware Components: Arduino Leonardo board × 1, Breadboard × 1, Male-to-male Dupont wires × 8, Type-C to Micro USB data cable (for connecting the laptop to the Arduino Leonardo board) × 1

Controller Prototype Materials: Black cardboard, Thin kraft paper, Glue; Dimensions: 14.5 cm × 9.5 cm × 3 cm

Software Tools: Arduino IDE (for writing and uploading controller code), Serial Monitor (for testing controller functionality), Unity (for game development), Visual Studio Code (for writing game logic code)

Source of downloaded assets:
* Obstacle Models: https://assetstore.unity.com/packages/3d/props/street-props-prototype-collection-291021
* Floor Texture Map: https://sketchfab.com/3d-models/stylized-tileable-stone-floor-texture-554b688435e14a5bb13087f79214087b
* Characters, Enemies and Props: https://assetstore.unity.com/packages/3d/characters/quarter-view-3d-action-assets-pack-188720
* HDR Skybox: https://assetstore.unity.com/packages/2d/textures-materials/sky/nebula-skyboxes-219924#reviews

### Images:  
![d3295cb640a2a7585dc856f717b87406](https://github.com/user-attachments/assets/662d5ff2-07c2-4a2a-8be7-66ff76026f5e)

![eb7b68c69775a3b9c8e3a9fc8190b5fb](https://github.com/user-attachments/assets/edb198a3-f480-4ee7-ae5d-84cb2a4d345b)

![2c83dc6b0a4f4c4a4fb53c18162cadcc](https://github.com/user-attachments/assets/8cbd45d3-e959-4e09-a98b-10bcdbbb08d2)

---

## Process

The following outlines the complete process of our project development:

**1. Assembly and Testing of the Controller**

We started by assembling the controller with an Arduino board, breadboard, and jumper wires, then verified button functionality via the Arduino IDE. Once confirmed, we implemented ControlScript in Unity to test its ability to control the character in-game.

<img width="4032" height="3024" alt="d419122737fcdbb8270a2ab2e5e95e60" src="https://github.com/user-attachments/assets/475d480f-4a23-4920-85d7-6360388eb23e" />

**2. Scene Optimization and Redesign**

Based on Lab Scene 3, we optimised the game environment by adjusting ground dimensions, updating scripts, replacing the HDR skybox, and refining materials. These steps helped establish the game’s core visual style and atmosphere.

<img width="815" height="553" alt="1bb1d50da7c77f8d6276fe37c6371943" src="https://github.com/user-attachments/assets/f9348c29-f8e1-42d7-b9c3-8095369c95db" />

**3. Model Import and Code Testing**

We sourced and customised 3D models aligned with the game's sci-fi theme. Many required texture remapping and size adjustments. For each model, we developed interaction scripts (collision, physics, animation triggers) and tested them individually. Peer playtesting helped fine-tune both visuals and mechanics.

<img width="814" height="481" alt="a40699a69f2c9153ff99542243b4972f" src="https://github.com/user-attachments/assets/cb2f1cfc-3f57-4941-8386-455aa19ecbd2" />

<img width="1911" height="480" alt="3f4327bd9dfee34c5fabbc7e7fb1ca29" src="https://github.com/user-attachments/assets/4c0476fa-bfc2-496f-b861-ca41d0f3c999" />

**4. Game Mechanics Programming**

This phase involved scripting core mechanics:

* Procedural element spawning via the "EndlessFloor" script (coins, obstacles, enemies, health packs).

* "Game Over" and "Victory" screens with functional restart logic and score tracking.

* Health system via PlayerHealthScript, enabling healing, damage, and health bar control.

ChatGPT was used for technical guidance and code review during this stage.

<img width="1097" height="637" alt="de1af21e6b6a0205073bc03ae297f234" src="https://github.com/user-attachments/assets/b4d5859d-fb4f-4b1f-ae0c-ac715ea4ae92" />

<img width="1915" height="828" alt="fe1ced76bb8e090f142c3297bb02a3f0" src="https://github.com/user-attachments/assets/81711aa7-2678-45bd-a1fe-043114807ceb" />

<img width="1911" height="847" alt="e4fc336addf672896a2ef8fb66f3ddb1" src="https://github.com/user-attachments/assets/3ce03e4d-862a-427f-bcde-972f998df035" />

**5. Game Refinement and Enhancements**

We added background music and sound effects (coins, damage, game end, victory) to improve immersion. A start screen with a "Start" button was also introduced to complete the game flow.

**6. Controller Prototype Development**

To enhance physical interaction, we designed a minimalist cardboard housing for the Arduino controller. It features concealed wiring, improved button friction, and ergonomic layout for a cleaner user experience.

<img width="1440" height="1897" alt="b6fd7160771701aeeed9e650847f6738" src="https://github.com/user-attachments/assets/26e88718-2b81-443c-bfab-f813b571e5b9" />

---

## Video Demonstration

Link to a demo video: https://mega.nz/file/auZhHTSQ#Hg_HY8EwO_ZfN1-pr5wrFABszesJzBUhf7kY-Bksn1I

---

## Final Images

<img width="1920" height="1080" alt="f45a6b244f74cd24ff9b1de5316f3a65" src="https://github.com/user-attachments/assets/1da96b28-865e-475a-9dc2-418403d3e27e" />

<img width="1920" height="1080" alt="cd0cad33913be5a2f819b0c231d2110c" src="https://github.com/user-attachments/assets/d31230af-8517-42a9-b412-e05b544cd6c8" />

<img width="1920" height="1080" alt="d1b919fdd026f8dffc15d8bc618eedc4" src="https://github.com/user-attachments/assets/1606ac96-345b-4d56-a58c-1829a41677c1" />

---
## Arduino Code

<img width="1920" height="987" alt="be60e1cd8603e140b66b48c84e35adaa" src="https://github.com/user-attachments/assets/f41d5044-45bd-448e-b5b6-368a73548b33" />

---
## Link to Unity Files

MEGA network link: https://mega.nz/file/OmRVzDwR#qJz-DSuB1NABYHy2tzZkGgpSCWt8OaYTWr_8uQIjeOA

---
