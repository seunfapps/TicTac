using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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