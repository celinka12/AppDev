public class GameGrid
{
    public readonly int[,] grid;
    public int row { get; }
    public int col { get; }
    public int this[int r, int c]
    {
        get => grid[r, c];
        set => grid[r, c] = value;
    }
    public GameGrid(int row, int col)
    {
        this.row = row;
        this.col = col;
        grid = new int[row, col];
    }
    //mengecek row dan columnnya ada di dalam grid tidak
    public bool Terisi(int r, int c)
    {
        return r >= 0 && r < row && c >= 0 && c < col;
    }
    //mengecek apakah cell dalam grid masih kosong
    public bool Kosong(int r, int c)
    {
        return Terisi(r, c) && grid[r, c] == 0;
    }
    //mengecek apakah 1 baris terisi
    public bool BarisTerisi(int r)
    {
        for (int c = 0; c < col; c++)
        {
            if (grid[r, c] == 0)
            {
                return false;
            }
        }
        return true;
    }
    //mengecek apakah 1 baris kosong
    public bool BarisKosong(int r)
    {
        for (int c = 0; c < col; c++)
        {
            if (grid[r, c] != 0)
            {
                return false;
            }
        }
        return true;
    }
    //mengubah value baris yang penuh menjadi 0
    public void BarisPenuh(int r)
    {
        for (int c = 0; c < col; c++)
        {
            grid[r, c] = 0;
        }
    }
    //ketika ada baris yang terhapus, maka baris diatasnya turun sebanyak baris yang di c
    public void TurunBaris(int r, int numRow)
    {
        for (int c = 0; c < col; c++)
        {
            grid[r + numRow, c] = grid[r, c];
            grid[r, c] = 0;
        }
    }
    //ketika 1 baris sudah terisi penuh, maka baris akan dihapus
    public int HapusBaris()
    {
        int clear = 0;
        for (int r = row - 1; r >= 0; r--)
        {
            if (BarisTerisi(r))
            {
                BarisPenuh(r);
                clear++;
            }
            else if (clear > 0)
            {
                TurunBaris(r, clear);
            }
        }
        return clear;
    }
}