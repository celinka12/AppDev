namespace Tetris
{
    public class IBlock : Balok
    {
        public readonly Posisi[][] balok = new Posisi[][]
            {
            new Posisi[] { new(1,0), new(1,1), new (1,2), new (1,3) },
            new Posisi[] { new(0,2), new(1,2), new (2,2), new (3,2) },
            new Posisi[] { new(2,0), new(2,1), new (2,2), new (2,3) },
            new Posisi[] { new(0,1), new(1,1), new (2,1), new (3,1) }
            };
        public override int Id => 1;
        public override Posisi StartOffset => new Posisi(0, 3);
        public override Posisi[][] block => balok;

    }
    public class JBlock : Balok
    {
        public readonly Posisi[][] balok = new Posisi[][]
            {
            new Posisi[] { new(0,0), new(1,0), new (1,1), new (1,2) },
            new Posisi[] { new(0,1), new(0,2), new (1,1), new (2,1) },
            new Posisi[] { new(1,0), new(1,1), new (1,2), new (2,2) },
            new Posisi[] { new(0,1), new(1,1), new (2,0), new (2,1) }
            };
        public override int Id => 2;
        public override Posisi StartOffset => new Posisi(0, 3);
        public override Posisi[][] block => balok;
    }
    public class LBlock : Balok
    {
        public readonly Posisi[][] balok = new Posisi[][]
            {
            new Posisi[] { new(0,2), new(1,0), new (1,1), new (1,2) },
            new Posisi[] { new(0,1), new(1,1), new (2,1), new (2,2) },
            new Posisi[] { new(1,0), new(1,1), new (1,2), new (2,0) },
            new Posisi[] { new(0,0), new(0,1), new (1,1), new (2,1) }
            };
        public override int Id => 3;
        public override Posisi StartOffset => new Posisi(0, 3);
        public override  Posisi[][] block => balok;
    }
    public class OBlock : Balok
    {
        public readonly Posisi[][] balok = new Posisi[][]
            {
            new Posisi[] { new(0,0), new(0,1), new (1,0), new (1,1) }
            };
        public override int Id => 4;
        public override Posisi StartOffset => new Posisi(0, 4);
        public override Posisi[][] block => balok;

    }
    public class SBlock : Balok
    {
        public readonly Posisi[][] balok = new Posisi[][]
            {
            new Posisi[] { new(0,1), new(0,2), new (1,0), new (1,1) },
            new Posisi[] { new(0,1), new(1,1), new (1,2), new (2,2) },
            new Posisi[] { new(1,1), new(1,2), new (2,0), new (2,1) },
            new Posisi[] { new(0,0), new(1,0), new (1,1), new (2,1) }
            };
        public override int Id => 5;
        public override Posisi StartOffset => new Posisi(0, 3);
        public override Posisi[][] block => balok;

    }
    public class TBlock : Balok
    {
        public readonly Posisi[][] balok = new Posisi[][]
            {
            new Posisi[] { new(0,1), new(1,0), new (1,1), new (1,2) },
            new Posisi[] { new(0,1), new(1,1), new (1,2), new (2,1) },
            new Posisi[] { new(1,0), new(1,1), new (1,2), new (2,1) },
            new Posisi[] { new(0,1), new(1,0), new (1,1), new (2,1) }
            };
        public override int Id => 6;
        public override Posisi StartOffset => new Posisi(0, 3);
        public override Posisi[][] block => balok;

    }
    public class ZBlock : Balok
    {
        public readonly Posisi[][] balok = new Posisi[][]
            {
            new Posisi[] { new(0,0), new(0,1), new (1,1), new (1,2) },
            new Posisi[] { new(0,2), new(1,1), new (1,2), new (2,1) },
            new Posisi[] { new(1,0), new(1,1), new (2,1), new (2,2) },
            new Posisi[] { new(0,1), new(1,0), new (1,1), new (2,0) }
            };
        public override int Id => 7;
        public override Posisi StartOffset => new Posisi(0, 3);
        public override Posisi[][] block => balok;



    }
}
