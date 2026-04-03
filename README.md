Description:
  This project represents a digital implementation of the classic board game "Ludo" (Nu te supăra, frate) developed in C# using Windows Forms.
  The application allows 2–4 players to compete locally by moving their pieces across the board according to traditional game rules.
  The main purpose of this project was to demonstrate Object-Oriented Programming principles, game logic implementation, and GUI synchronization with the internal game state.

Features:
  2–4 local players
  Dynamic player configuration
  Dice rolling system with special rules
  Piece movement validation
  Capture mechanics
  Safe zones where pieces cannot be captured
  Win condition detection
  Dynamic GUI updates
  Special player type (Lucky Player mechanic)
  Prevention of invalid moves
  Turn management system

OOP Concepts Demonstarted:
  Encapsulation – Game logic separated from UI logic
  Inheritance – Player hierarchy
  Polymorphism – Different dice behavior depending on player type
  Abstraction – Separation between game engine and UI components

Architecture Overview
  Game Engine Layer:
    Game logic
    Movement validation
    Win conditions
    Turn management
  Domain Layer:
    Player classes
    Piece class
    Game state management
  UI Layer:
    Windows Forms interface
    Board rendering
    Token visualization
    Event handling

Technologies Used
  Language: C#
  Framework: .NET
  GUI: Windows Forms
  IDE: Visual Studio 2022
  Documentation: Microsoft Word

Game rules implemented
  A piece can leave the base only when rolling a 6
  Rolling a 6 grants another dice roll
  Rolling three consecutive 6s cancels the last move
  Landing on an opponent sends their piece back to base
  Safe positions prevent captures
  Maximum 2 pieces allowed on the same tile
  Exact roll required to enter the finish zone

GUI Implementation Details
  Dynamic token instantiation
  Memory cleanup using .Dispose()
  Logical-to-visual position mapping
  Event-driven interaction
  Automatic board scaling

Author:
Raluca Maria Frăcea
Computer Engineering Student

References:
C# 12 in a Nutshell – The Definitive Reference
Microsoft Learn – Windows Forms documentation
Object-Oriented Programming principles literature
