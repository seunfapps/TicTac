# TicTac
A REST Service written in .NET to play TicTacToe

## How it works

This service should be used by TicTacToe Game AI clients, to determine the next moves during game matches. 

The board state is sent to the service as a two-dimensional array of equal width and height e.g.

```js
[
    [0, 0, 0],
    [0, 2, 0],
    [0, 0, 0]
]
/*O is in row 1, column 1*/
```

Where 

```
 - Blank: 0
 - X: 1
 - O: 2
```

If available, service will select a tile in the best possible position to be played next.

If there is no such available tile _(e.g. if all tiles are full)_, the service will indicate a Draw or Game Over where appropriate.

We are yet to determine what algorithm will be used to select the best position tile position for play. The candidates however are:

 - Decision Tree - [UCI Machine Learning TicTacToe Endgame Datasets](http://archive.ics.uci.edu/ml/datasets/Tic-Tac-Toe+Endgame)

 - Recursion [as used in this stackoverflow thread](http://stackoverflow.com/questions/8880064/tic-tac-toe-recursive-algorithm)

 - Greedy Search [from this quora article](https://www.quora.com/Is-there-a-way-to-never-lose-at-Tic-Tac-Toe/answer/Raziman-T-V)