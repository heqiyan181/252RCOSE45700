# tower_defense_final

## Project Description
This project is a 2D tower defense game made with Unity 6.  
The player places towers on the map to stop enemies from reaching the end of the path.

The game was developed as a small team project for a class assignment.  
The main goal was to understand the basic structure of a tower defense game, including enemy waves, UI flow, and level progression.

---

## Main Features
- Wave-based enemy system
- Tower placement and simple upgrades
- Coin system for building and upgrading towers
- Life system and game over condition
- Level selection menu
- Victory screen after clearing a level

---

## Controls
- Mouse click: place towers and click UI buttons
- UI buttons: control game speed and scene transitions

---

## Levels
- Level 1: available from the start
- Level 2: unlocked after clearing Level 1

Level unlocking is handled using Unity PlayerPrefs.

---

## Game Flow
- Enemies appear in waves.
- If all waves are cleared, the Victory screen is shown.
- If the player's lives reach zero, the Game Over screen is shown.
- From the Victory screen, the player can return to the Level Select scene.

---

## Development Environment
- Engine: Unity 6 (6000.2.2f1)
- Language: C#
- UI: Unity UI / TextMeshPro
- Object pooling is used for enemy spawning.

---

## How to Run
1. Open the project in Unity Hub.
2. Open the `MainMenu` scene.
3. Press Play to start the game.
4. Select a level from the Level Select screen.

---

## Notes
- Some audio-related warnings may appear in the console, but they do not affect gameplay.
- Game balance is kept simple due to the scope of the assignment.

---

## Team Members
- 2023320171 지가영
- 2023320166 하기연

---------------------------------------------

# 타워 디펜스 게임 (Unity 2D)

## 프로젝트 설명
이 프로젝트는 Unity 6를 사용해 제작한 2D 타워 디펜스 게임입니다.  
플레이어는 맵 위에 타워를 설치하여 적이 길의 끝에 도달하지 못하도록 막아야 합니다.

본 게임은 수업 과제로 진행된 소규모 팀 프로젝트이며,  
타워 디펜스 게임의 기본적인 구조를 이해하는 것을 목표로 제작되었습니다.

---

## 주요 기능
- 웨이브 기반 적 등장 시스템
- 타워 설치 및 간단한 업그레이드
- 코인(재화) 시스템
- 생명 수치에 따른 게임 오버 처리
- 레벨 선택 화면
- 레벨 클리어 시 승리 화면 표시

---

## 조작 방법
- 마우스 클릭: 타워 설치 및 UI 버튼 선택
- UI 버튼: 게임 속도 조절 및 화면 이동

---

## 레벨 구성
- Level 1: 처음부터 플레이 가능
- Level 2: Level 1 클리어 후 해금

레벨 해금은 Unity의 PlayerPrefs를 사용하여 구현되었습니다.

---

## 게임 진행 방식
- 적은 웨이브 단위로 등장합니다.
- 모든 웨이브를 클리어하면 Victory 화면이 표시됩니다.
- 생명이 모두 소진되면 Game Over 화면이 표시됩니다.
- Victory 화면에서 Level Select 화면으로 돌아갈 수 있습니다.

---

## 개발 환경
- 엔진: Unity 6 (6000.2.2f1)
- 사용 언어: C#
- UI: Unity UI / TextMeshPro
- 적 생성에 오브젝트 풀링 기법을 사용했습니다.

---

## 실행 방법
1. Unity Hub에서 프로젝트를 엽니다.
2. `MainMenu` 씬을 실행합니다.
3. Level Select 화면에서 레벨을 선택해 게임을 시작합니다.

---
## 참고 사항
- 콘솔에 오디오 관련 경고 메시지가 나타날 수 있으나, 게임 진행에는 영향을 주지 않습니다.
- 과제 범위에 맞춰 전체적인 게임 구조는 단순하게 구성되었습니다.

---

## 팀원
- 2023320171 지가영
- 2023320166 하기연


########################################

## Updates from Midterm to Final

After the midterm submission, several changes and additions were made to the project.

Based on the original Level 1 created for the midterm, we added a **Main Menu**, **Level Select**, and a new **Level 2**.  
The UI for the Main Menu and Level Select scenes was designed in a simple and basic form, focusing on functionality rather than visual detail.

We also adjusted the difficulty of the original level from the midterm.  
Some values such as enemy count and timing were modified to improve the overall game flow.  
For **Level 2**, the difficulty was slightly increased compared to Level 1.

In addition, a **level locking system** was implemented.  
The player cannot access Level 2 before clearing Level 1, and Level 2 becomes available only after Level 1 is completed.

## 중간고사 이후 기말까지의 변경 사항

중간고사 제출 이후 프로젝트에 여러 가지 수정과 추가 작업을 진행하였습니다.

중간고사 때 제작했던 Level 1을 기반으로 **Main Menu**, **Level Select**, 그리고 새로운 **Level 2**를 추가하였습니다.  
Main Menu와 Level Select의 UI는 전체적인 구조를 이해할 수 있도록 간단한 형태로 구현하였습니다.

또한 중간고사 당시의 기존 Level 1에 대해 난이도를 일부 조정하였습니다.  
적의 수나 진행 속도 등을 수정하여 게임 흐름이 더 자연스럽도록 개선하였습니다.  
Level 2의 경우 Level 1보다 약간 더 높은 난이도로 설계하였습니다.

추가로 **관문(레벨 잠금) 기능**을 구현하였습니다.  
Level 1을 클리어하기 전에는 Level 2에 진입할 수 없으며,  
Level 1을 완료한 이후에만 Level 2가 해금되도록 구성하였습니다.

