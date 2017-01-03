using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTac
{
    public class Board: List<Row>
    {
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
        
        public bool isEmpty()
        {
            return this.All(row => row.isEmpty());
        }

        public bool isValid()
        {
            return this.Select(row => row.Count).Distinct().Count() == 1 && this.Count >= 3;
        }
    }
}
