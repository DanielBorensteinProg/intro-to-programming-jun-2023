# Bowling

## Bowling Game:

We are writing code to calculate a report on a bowling game between two or more players.

So, after they are done playing, they tell us the names and scores of each of the players, and we calculate:

- Who are the winners.
- Who are the losers.
- What is the average of all the scores.


| Name | Score |
| ---- | ----- |
| Jim  | 120   |
| Sue  | 286   |
| Sam  | 180   |
| Ray  | 286   |
| Paul | 120   |


Output for this ame would be something like:

### Winners
    - Sue, 286
    - Ray, 286
### Losers
    - Jim, 120
    - Paul, 120
## Average 
    - 198.4


## Some Rules

- X Player names have to be unique.
- Game has to have at least two players to be scored.
	- it's dumb to have a game with one player because they are the winner and loser.
- X Range of allowed scores:
	- 0 - 300 Inclusive
- X The highest score wins
- X The lowest score loses
- X Average
- X There can be ties for winners and losers.
- What if everyone has the same score?
