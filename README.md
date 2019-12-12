Design Patterns Examples
======================== 

Engine
==============

Unity 2019.2

About
====================

This repository will hold several implementations of design patterns that I have used in the past or that I'd like to explore.

The implementation will try to be really simple to serve as educational for my university students.

Pattern List
====================

1) Finite State Machine: 
    
    Character FSM Sample: 
    
        The State Machine initialize on Idle State. 
        Use 'Space' bar to switch to Walk State, 'W' to switch to Run State and 'S' to return to Idle State.
        
2) Finite State Machine With Animations: 
    
    Character FSM: 
    
        Based on Sample 1, it integrate Animation control trought FSM states.
        The State Machine initialize on Idle State. 
        Use 'A'  to switch to Color State, 'S' to switch to Scale State and 'D' to return to Idle State.

3) Finite State Machine With Movement and Animations: 
    
    Character FSM: 
    
        Based on Sample 2, it integrate Class structure to handle movement with FSM states in a decoupled way.
        The State Machine initialize on Idle State. 
        Use 'WASD'  to switch to Move State in different directions, 'SpaceBar' to switch to Jump State.
        
        
4) Adapter:
    
    Audio Adapter: 
    
        It propose a base interface (AudioClipAdapter SO) that can integrate different audio engines/implementations 
        while it offers an API to the other systems of the game's architecture.
      
        
