using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tetris;

namespace tetriss
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //asset gambar
        public readonly ImageSource[] tileImages = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png", UriKind.Relative))
        };
        public readonly ImageSource[] blockImages = new ImageSource[]
       {
            new BitmapImage(new Uri("Assets/Block-Empty.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png", UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png", UriKind.Relative))
       };
        public readonly Image[,] imageControls;
        //untuk mengatur kecepatan turun block
        public readonly int maxDelay = 1000;
        public readonly int minDelay = 25;
        public readonly int delayDecrease = 50;
        private StatusGame gamestatus = new StatusGame();
        
        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gamestatus.Grid);
        }
        public async void RestartGame(object sender, RoutedEventArgs e)
        {

        }
        public Image[,] SetupGameCanvas(GameGrid grid)
        {
            Image[,] imageControls = new Image[grid.row, grid.col];
            int ukuran = 25;

            for (int r = 0; r < grid.row; r++)
            {
                for (int c = 0; c < grid.col; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = ukuran,
                        Height = ukuran
                    };

                    Canvas.SetTop(imageControl, (r - 2) * ukuran + 10);
                    Canvas.SetLeft(imageControl, c * ukuran);
                    GameCanvas.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }

            return imageControls;
        }
        //method untuk menampilkan grid
        public void DrawGrid(GameGrid grid)
        {
            for (int r = 0; r < grid.row; r++)
            {
                for (int c = 0; c < grid.col; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Opacity = 1;
                    imageControls[r, c].Source = tileImages[id];
                }
            }
        }
        //method untuk menampilkan block
        public void DrawBlock(Balok balok)
        {
            foreach (Posisi p in balok.TilePosisi())
            {
                imageControls[p.Baris, p.Kolom].Opacity = 1;
                imageControls[p.Baris, p.Kolom].Source = tileImages[balok.Id];
            }
        }
        //method untuk menampilkan next block
        public void DrawNextBlock(nextBalok balokSelanjutnya)
        {
            Balok next = balokSelanjutnya.NextBalok;
            NextImage.Source = blockImages[next.Id];
        }
        //method untuk menampilkan ghost block agar tahu baloknya jatuh di mana
        public void DrawGhostBlock(Balok block)
        {
            int dropDistance = gamestatus.JarakBalokTurun();

            foreach (Posisi p in block.TilePosisi())
            {
                imageControls[p.Baris + dropDistance, p.Kolom].Opacity = 0.30;
                imageControls[p.Baris + dropDistance, p.Kolom].Source = tileImages[block.Id];
            }
        }
        //menampilkan tetrisnya
        private void Draw(StatusGame gameState)
        {
            DrawGrid(gameState.Grid);
            DrawGhostBlock(gameState.CurrentBlock);
            DrawBlock(gameState.CurrentBlock);
            DrawNextBlock(gameState.Nextblock);
            ScoreText.Text = $"Score: {gameState.Score}";
        }
        //untuk looping hingga gameover
        public async Task GameLoop()
        {
            Draw(gamestatus);

            while (!gamestatus.GameOver)
            {
                int delay = Math.Max(minDelay, maxDelay - (gamestatus.Score * delayDecrease));
                await Task.Delay(delay);
                gamestatus.BalokTurun();
                Draw(gamestatus);
            }
            if (gamestatus.GameOver)
            {
                GameOverMenu.Visibility = Visibility.Visible;
                FinalScoreText.Text = $"Score: {gamestatus.Score}";
            }
            
        }
        //memasukkan key untuk menggerakkan block
        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gamestatus.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                case Key.A:
                    gamestatus.MoveBlockLeft();
                    break;
                case Key.Right:
                case Key.D:
                    gamestatus.MoveBlockRight();
                    break;
                case Key.Down:
                case Key.S:
                    gamestatus.BalokTurun();
                    break;
                case Key.Up:
                case Key.W:
                    gamestatus.RotateBlockCW();
                    break;
                case Key.Space:
                    gamestatus.DropBlock();
                    break;
                default:
                    return;
            }

            Draw(gamestatus);
        }
        public async void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            await GameLoop();
        }
        //untuk play again ketika sudah game over
        public async void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            gamestatus = new StatusGame();
            GameOverMenu.Visibility = Visibility.Hidden;
            await GameLoop();
        }

    }
}
