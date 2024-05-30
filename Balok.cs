using System.Collections.Generic;

namespace Tetris
{
    public abstract class Balok
    {
        public abstract Posisi[][] block { get; }
        public abstract Posisi StartOffset { get; }
        public abstract int Id { get; }

        private int posisiRotasi;
        private Posisi offset;

        public Balok()
        {
            offset = new Posisi(StartOffset.Baris, StartOffset.Kolom);
        }

        public IEnumerable<Posisi> TilePosisi()
        {
            foreach (Posisi p in block[posisiRotasi])
            {
                yield return new Posisi(p.Baris + offset.Baris, p.Kolom + offset.Kolom);
            }
        }
        //rotate searah jarum jam
        public void RotateCW()
        {
            posisiRotasi = (posisiRotasi + 1) % block.Length;
        }
        //rotate tak searah jarum jam
        public void RotateCCW()
        {
            if (posisiRotasi == 0)
            {
                posisiRotasi = block.Length - 1;
            }
            else
            {
                posisiRotasi--;
            }
        }
        //menggerakkan block
        public void Move(int rows, int columns)
        {
            offset.Baris += rows;
            offset.Kolom += columns;
        }
        //mengembalikan posisi block baru
        public void Reset()
        {
            posisiRotasi = 0;
            offset.Baris = StartOffset.Baris;
            offset.Kolom = StartOffset.Kolom;
        }
    }
}