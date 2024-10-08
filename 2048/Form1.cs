namespace _2048
{
    public partial class Form1 : Form
    {
        private Button[,] cells;
        private int[,] number = new int[4, 4];
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            cells = new Button[,]{
                {button1,button2,button3,button4},
                {button5,button6,button7,button8},
                {button9,button10,button11,button12},
                {button13,button14,button15,button16}
            }; 
            for (int i = 0; i < number.GetLength(0); i++)
            {
                for (int j = 0; j < number.GetLength(1); j++)
                {
                    number[i, j] = 0;
                }
            }
        }
        private void StartNewGame()
        {
            number = new int[4, 4];
            NewTile();
        }
        private void NewTile()
        {
            int x, y;
            do
            {
                x = random.Next(0, 4);
                y = random.Next(0, 4);
            } while (number[x, y] != 0);
            number[x, y] = random.Next(1, 3) * 2;
        }
        private void Show()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j].Text = number[i, j].ToString();
                    if (cells[i, j].Text == "0")
                    {
                        cells[i, j].Text = "";
                    }
                }
            }
        }
        private void newNumber(int n = 0)
        {
            int x = new Random().Next(4);
            int y = new Random().Next(4);
            if (number[x, y] == 0)
            {
                number[x, y] = 2; 
                return;
            }
            if (n > 100)
            {
                MessageBox.Show("Game over");
                return;
            }
            newNumber(n + 1);
        }
        private void move(int x, int y)
        {
            bool moved = false;
            bool merged = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int currentX = (y == 0) ? i : (y == 1 ? i : 3 - i);
                    int currentY = (x == 0) ? j : (x == 1 ? j : 3 - j);
                    if (number[currentX, currentY] != 0)
                    {
                        int nextX = currentX + (y == 1 ? 1 : (y == -1 ? -1 : 0));
                        int nextY = currentY + (x == 1 ? 1 : (x == -1 ? -1 : 0));
                        while (nextX >= 0 && nextX < 4 && nextY >= 0 && nextY < 4 && number[nextX, nextY] == 0)
                        {
                            number[nextX, nextY] = number[currentX, currentY];
                            number[currentX, currentY] = 0;
                            currentX = nextX;
                            currentY = nextY;
                            nextX += (y == 1 ? 1 : (y == -1 ? -1 : 0));
                            nextY += (x == 1 ? 1 : (x == -1 ? -1 : 0));
                            moved = true;
                        }
                        if (nextX >= 0 && nextX < 4 && nextY >= 0 && nextY < 4 && number[nextX, nextY] == number[currentX, currentY] && !merged)
                        {
                            number[nextX, nextY] *= 2;
                            number[currentX, currentY] = 0;
                            merged = true;
                            moved = true;
                        }
                    }
                }
            }
            if (moved) NewTile();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            move(-1, 0);
            newNumber();
            Show();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            move(0, -1);
            newNumber();
            Show();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            move(1, 0);
            newNumber();
            Show();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            move(0, 1);
            newNumber();
            Show();
        }
    }
}