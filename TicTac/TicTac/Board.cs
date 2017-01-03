﻿using System.Collections.Generic;
using System.Linq;

namespace TicTac
{
    public class Board: List<Row>
    {
        private State state { get; set; }
        public Board()
        {

        }
        public Board(int size)
        {
            for (int i = 0; i < size; i++)
            {
                this.Add(new Row(size));
            }
            
        }

        public State getState()
        {
            if (state == null) this.state = new State(this);
            state = State.calcScore(this);
            return state;
        } 
        
        public bool isEmpty()
        {
            return this.All(row => row.isEmpty());
        }

        public bool isValid()
        {
            return this.Select(row => row.Count).Distinct().Count() == 1 && this.Count >= 3;
        }

        public State play(Tile tile, int row, int column)
        {
            var state = new Board.State(this);
            this[row][column] = tile;
            return this.getState();
        }

        public class State
        {
            public int size { get; set; }
            public int xWinCount { get; set; }
            public int oWinCount { get; set; }
            public State() { }

            public State(Board board)
            {
                this.size = board.Count;
            }

            public static State calcScore(Board board, State state = null)
            {
                if (state == null) state = new State(board);
                var pivots = Pivot.GetPivots(board);
                pivots.ForEach(pivot =>
                {
                    Tile left = calcLeft(board, pivot);
                    if (left == Tile.X) state.xWinCount++;
                    else if (left == Tile.O) state.oWinCount++;

                    Tile right = calcRight(board, pivot);
                    if (right == Tile.X) state.xWinCount++;
                    else if (right == Tile.O) state.oWinCount++;

                    Tile top = calcTop(board, pivot);
                    if (top == Tile.X) state.xWinCount++;
                    else if (top == Tile.O) state.oWinCount++;

                    Tile bottom = calcBottom(board, pivot);
                    if (bottom == Tile.X) state.xWinCount++;
                    else if (bottom == Tile.O) state.oWinCount++;

                    Tile vertMiddle = calcVerticalMiddle(board, pivot);
                    if (vertMiddle == Tile.X) state.xWinCount++;
                    else if (vertMiddle == Tile.O) state.oWinCount++;

                    Tile horzMiddle = calcHorizontalMiddle(board, pivot);
                    if (horzMiddle == Tile.X) state.xWinCount++;
                    else if (horzMiddle == Tile.O) state.oWinCount++;

                    Tile diagLeft = calcLeftDiagonal(board, pivot);
                    if (diagLeft == Tile.X) state.xWinCount++;
                    else if (diagLeft == Tile.O) state.oWinCount++;

                    Tile diagRight = calcRightDiagonal(board, pivot);
                    if (diagRight == Tile.X) state.xWinCount++;
                    else if (diagRight == Tile.O) state.oWinCount++;
                });
                return state;
            }

            private static Tile calcLeft(Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x - 1];
                Tile b = board[y][x - 1];
                Tile c = board[y + 1][x - 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    a = b = c = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    a = b = c = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcRight(Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x + 1];
                Tile b = board[y][x + 1];
                Tile c = board[y + 1][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    a = b = c = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    a = b = c = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcTop(Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x - 1];
                Tile b = board[y - 1][x];
                Tile c = board[y - 1][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    a = b = c = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    a = b = c = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcBottom(Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y + 1][x - 1];
                Tile b = board[y + 1][x];
                Tile c = board[y + 1][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    a = b = c = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    a = b = c = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcHorizontalMiddle(Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y][x - 1];
                Tile b = board[y][x];
                Tile c = board[y][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    a = b = c = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    a = b = c = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcVerticalMiddle(Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x];
                Tile b = board[y][x];
                Tile c = board[y + 1][x];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    a = b = c = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    a = b = c = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcLeftDiagonal(Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x - 1];
                Tile b = board[y][x];
                Tile c = board[y + 1][x + 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    a = b = c = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    a = b = c = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }

            private static Tile calcRightDiagonal(Board board, Pivot pivot)
            {
                int x = pivot.x, y = pivot.y;
                Tile a = board[y - 1][x + 1];
                Tile b = board[y][x];
                Tile c = board[y + 1][x - 1];

                int prod = (int)a * (int)b * (int)c;
                if (prod == Game.XWON)
                {
                    a = b = c = Tile.Xinvalid;
                    return Tile.X;
                }
                else if (prod == Game.OWON)
                {
                    a = b = c = Tile.Oinvalid;
                    return Tile.O;
                }
                else return Tile.Blank;
            }
        }

        internal class Pivot
        {
            public int x { get; set; }
            public int y { get; set; }

            public static List<Pivot> GetPivots(Board board)
            {
                var pivots = new List<Pivot>();
                for (int x = 1; x < board.Count - 1; x++)
                {
                    for (int y = 1; y < board[0].Count - 1; y++)
                    {
                        pivots.Add(new Pivot() { x = x, y = y });
                    }
                }
                return pivots;
            }
        }
    }
}
