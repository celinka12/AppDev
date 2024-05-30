using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Posisi
    {
        public int Baris { get; set; }
        public int Kolom { get; set; }

        public Posisi(int row, int column)
        {
            Baris = row;
            Kolom = column;
        }
    }
}