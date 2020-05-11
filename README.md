# JumpingBird

`by Tom CHITTY`     
*`Unity version: 2019.3.5f`*

The goal of this game is to go as far as possible with the bird, avoiding obstacles.

# MECHANICS

The bird is subject to gravity.
### CONTROLS
| Key | Action |
| ------ | ------ |
| SPACE or LEFT CLICK | Jump |
| ESCAPE | Enable/Disable Pause Menu | 

### DEATH
You can die in 2 ways:  

*  colliding with an obstacle
*  colliding with the ground

### SCORE
You get 1 point if you pass an obstacles without colliding with it.

# OBSTACLES

### PROCEDURAL GENERATION


The obstacles are **generated** and **deleted** procedurally.       
The positions **x**,**y** are set **randomly**, following some restrictions.    

### MOVING OBSTACLES
The obstacles can move **vertically** OR **horizontally** (following the character ***x*** position).       
The *chances* to have a *moving obstacles* increase over time:      

**VERTICAL MOVE**

| Elapsed time (s)| Chances |
| ------ | ------ |
| 0 | 1/10 |
| 20 | 1/8 | 
| 30 | 1/5 | 
| 60 | 1/2 | 

**HORIZONTAL MOVE**

| Elapsed time (s)| Chances |
| ------ | ------ |
| 0 | 1/30 |
| 20 | 1/10 | 
| 45 | 1/8 | 
| 60 | 1/5 | 


**SCROLLING SPEED**     
The scrolling speed increase every 15 seconds.

# UI

## SOUND & MUSIC

In the "Options" menu, you can enable or disable the music and the sounds effects.      

**PAUSE MENU**      
During the game, pressing the *ESCAPE* key freeze the game and allow you to go back to the main
menu.


