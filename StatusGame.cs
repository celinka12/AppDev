using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;

namespace tetriss
{
    public class StatusGame
    {
        public Balok currentBlock;

        public Balok CurrentBlock
        {
            get => currentBlock;
            set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        public GameGrid Grid { get; }
        public int Score { get; set; }
        public nextBalok Nextblock { get; }
        public bool GameOver { get; set; }

        public StatusGame()
        {
            //panjang dan lebar grid, seharusnya 20 x 10, tetapi ditulis 22 untuk spawn block awal
            Grid = new GameGrid(22, 10);
            //block yang akan muncul berikutnya
            Nextblock = new nextBalok();
            //block yang sedang digerakkan
            CurrentBlock = Nextblock.GetAndUpdate();
        }
        //mengecek apakah block bisa fit dengan tile yang tersisa
        private bool Blockfit()
        {
            foreach (Posisi p in CurrentBlock.TilePosisi())
            {
                if (!Grid.Kosong(p.Baris, p.Kolom))
                {
                    return false;
                }
            }
            return true;
        }
        //merotate block searah jarum jam
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();

            if (!Blockfit())
            {
                CurrentBlock.RotateCCW();
            }
        }
        //menggeser block ke kiri
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!Blockfit())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        //menggeser block ke kanan
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!Blockfit())
            {
                CurrentBlock.Move(0, -1);
            }
        }
        //mengecek apakah kalah
        private bool Lose()
        {
            return !(Grid.BarisKosong(0) && Grid.BarisKosong(1));
        }
        //meletakkan block pada grid yang ada
        private void PlaceBlock()
        {
            foreach (Posisi p in CurrentBlock.TilePosisi())
            {
                Grid[p.Baris, p.Kolom] = CurrentBlock.Id;
            }

            //score yang didapat berdasarkan baris yang dihapus
            Score += Grid.HapusBaris();            

            if (Lose())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = Nextblock.GetAndUpdate();
            }
        }
        //block turun terus hingga mengenai grid paling bawah atau block lainnya
        public void BalokTurun()
        {
            CurrentBlock.Move(1, 0);

            if (!Blockfit())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
        //jumlah baris turun
        public int JarakBarisTurun(Posisi p)
        {
            int drop = 0;

            while (Grid.Kosong(p.Baris + drop + 1, p.Kolom))
            {
                drop++;
            }

            return drop;
        }
        //jumlah block turun
        public int JarakBalokTurun()
        {
            int drop = Grid.row;

            foreach (Posisi p in CurrentBlock.TilePosisi())
            {
                drop = System.Math.Min(drop, JarakBarisTurun(p));
            }

            return drop;
        }
        //function agar balok langsung turun ke paling bawah
        public void DropBlock()
        {
            CurrentBlock.Move(JarakBalokTurun(), 0);
            PlaceBlock();
        }
    }
}
