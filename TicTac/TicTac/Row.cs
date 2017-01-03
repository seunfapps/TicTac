using System.Collections.Generic;

namespace TicTac
{
    public class Row: List<Tile>
    {
        public Row()
        {

        }

        public Row(int size)
        {
            for (int i = 0; i < size; i++)
            {
                this.Add(Tile.Blank);
            }
        }

        public bool isEmpty()
        {
            return this.All((tile) => tile == 0);
        }
    }
}