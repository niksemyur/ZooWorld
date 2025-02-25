# ZooWorld

Техническое задание для вакансии Middle Unity Developer

**Description**

- Zoo world is the 3d game where you can see different animals

**Camera**

- Top down view

**Graphics**

- No graphics required. Box, spheres and any other samples are fine. You are free to use any assets from asset stores or any other resources, but note that this will not affect final results at all

**Gameplay**

- Every (1-2) seconds one animal appears and starts moving randomly. It can collide with
other animals by physics. If animals move out of screen it changed movement direction to return
back to screen

**Food chain**

**Prey**

- If it collided with another prey animal they would just fly apart by physics. If it’s collided with predator it become dead and disappear from screen

**Predators**

- If they collide with other animals, prey or predators they will eat them. If a predator collides with another predator, one of them will survive and the other will become dead (you can choose any easiest way to implement it) Each time a predator eats another animal the label “Tasty!” should appear under predators

**Animals**

**Frog**

- Frog is a prey animal. Its movement is jumps. Every x second make a jump for fixed distance

**Snake**

- Snakes are predators. It moving linear (fixed dispense by second)

**UI**

- On the top right corner should be the counter of dead preys and predators animals. UI should be created by uGUI

**What we are aiming with this test task**

- The most major thing we are looking at is animal architecture. We expect to see clear, easy to extend and easy to understand code here. Let’s assume that we will add 1000 differents animals in near future (birds, spiders, fish, crabs, ets) We also keep an eye on assets you will use. So if you are familiar with DI or any other frameworks better to add them If you have experience with architecture patterns please also please show us
