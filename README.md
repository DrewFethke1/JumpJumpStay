# JumpJumpStay
I made it so either player can die from falling off the edge, which will display their loss in the console. This can change the strategy because now pushing off the edge is a valid strategy.

Players are now able to dash in any direction by pressing either Q or U, depending on the player.

The camera has been moved directly above the map so no player is at a disadvantage because of camera angle.

The map has been made slightly bigger so it looks better in the rectangular camera space.

The changed Game design tools are Goal because you can now try to knock the other person off of the map, Direct action becuase of the Dash and Skill becuse new movement tequniques makes there a larger amount of skill that can be used

Added simple UI to display each players scores and fixed some issues with both players scroing at same time



Added cubes that have rigid body


Added orbs that when collected increases the players speed by 25% but this is not always good


Added an inventory manager that can track both of the players scores as well as displaying them



Inventory manager was doing no good for the game and is useless for the context of the gameplay so I switched back to score

Cubes now reduce the speed of the other player by 25% when pushed off

Changed points to health and when one player lose 10 points they get pushed off the map and die

Game now resets on player death and when a player dies it give the other player a win, Wins save after reset

Both players speed sightly increases over time

Players are now cubes with updated box coliders and overhauled the way movement works

When two players come into contact they both will be pused back by a factor of the other players speed

Gameplay is now a 2 player stradigy about trying to figure out how to knock off the other player using speed management as you can manage both the speed of yourself or the opponent, players are still able to jump over each to reduce there health as another way of fighting the opponent

