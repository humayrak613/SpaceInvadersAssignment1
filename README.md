# Space Invaders - Assignment 1

**Student Name:** Humayra Khanom

**Course:** CSCI 381

## Required Tasks Completed

* Remaining aliens move faster as their numbers decrease.
* The game detects when aliens reach the bottom of the screen (making a win impossible). 
* The spaceship is prevented from moving off-screen using Mathf.Clamp.
* **3 Code Improvements:**
  1. Removed the per-frame Update() in the counter and replaced it with an event-driven SetCount() that only fires when an alien is destroyed.
  2. Removed the unnecessary GetComponent<AlienFleet>() call by having the alien directly call a new OnAlienDestroyed() method so the fleet manages its own list.
  3. Merged the two loops in AlienFleet.cs' FixedUpdate method.
  4. Removed empty methods.

## Additional Features Completed

* Starting and Ending Screens: Added a start, game, and end screen. The end screen displays "YOU WIN!" or "GAME OVER" based on if player met requirements to win game.
* Lives System: The player has 3 lives, displayed with a heart UI. Taking damage respawns the ship and grants brief invulnerability.
* Collision Animations: Added a particle system that instantiates at the exact collision point when an alien is destroyed or the ship is hit.
* Background: Replaced skybox background with a drawing of a space background.
