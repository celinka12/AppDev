using System;
using Tetris;

namespace tetriss
{
    public class nextBalok
    {
            //memasukkan block-block ke dalam class untuk mengetahui jumlah block yang ada
            private readonly Balok[] Baloks = new Balok[]
            {
                new IBlock(),
                new JBlock(),
                new LBlock(),
                new OBlock(),
                new SBlock(),
                new TBlock(),
                new ZBlock(),
             };
            private readonly Random random = new Random();
            public Balok NextBalok { get;  set; }

            public nextBalok()
            {
                NextBalok = RandomBalok();
            }
            //merandom sebanyak jumlah balok yang ada
            public Balok RandomBalok()
            {
                return Baloks[random.Next(Baloks.Length)];
            }
            //untuk looping agar balok yang keluar berbeda
            public Balok GetAndUpdate()
            {
                Balok Balok = NextBalok;
                do
                {
                    NextBalok = RandomBalok();
                }
                while (Balok.Id == NextBalok.Id);

                return Balok;
            }
        }
    }
