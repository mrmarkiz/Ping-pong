namespace Lab3
{
    public partial class Form1 : Form
    {
        private int step = 5;
        private Ball ball;
        private bool continueGame;
        private int collisions;
        private int point1;
        private int point2;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            continueGame = true;
            gameBall.Location = new Point((this.Width - gameBall.Width) / 2, (this.Height) / 2 - gameBall.Height);
            ball = new Ball(gameBall.Location.X, gameBall.Location.Y, -0.6f, -0.4f, gameBall);
            point1 = 0;
            point2 = 0;
            collisions = 0;
            timer1.Start();
            updateSpeed();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (pictureBox1.Top - step >= 0)
                        moveBoard(pictureBox1, 0, -step);
                    break;
                case Keys.S:
                    if (pictureBox1.Bottom + step <= this.Height - pictureBox2.Height / 2)
                        moveBoard(pictureBox1, 0, step);
                    break;

                case Keys.Up:
                    if (pictureBox2.Top - step >= 0)
                        moveBoard(pictureBox2, 0, -step);
                    break;
                case Keys.Down:
                    if (pictureBox2.Bottom + step <= this.Height - pictureBox2.Height / 2)
                        moveBoard(pictureBox2, 0, step);
                    break;
            }
        }

        private void moveBoard(PictureBox board, int x, int y)
        {
            board.Location = new Point(board.Location.X + x, board.Location.Y + y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (continueGame)
            {
                if (gameBall.Top <= 0 || gameBall.Bottom >= this.Height - gameBall.Height)
                    ball.ReflectVertical();
                if (gameBall.Left > pictureBox1.Left && gameBall.Left <= pictureBox1.Right && gameBall.Top + gameBall.Height / 2 >= pictureBox1.Top && gameBall.Bottom <= pictureBox1.Bottom + gameBall.Height / 2 ||
                   gameBall.Right < pictureBox2.Right && gameBall.Right >= pictureBox2.Left && gameBall.Top + gameBall.Height / 2 >= pictureBox2.Top && gameBall.Bottom <= pictureBox2.Bottom + gameBall.Height / 2)
                {
                    ball.ReflectHorizontal();
                    collisions++;
                    if (collisions % 3 == 0)
                    {
                        step++;
                        collisions = 0;
                        updateSpeed();
                    }
                }
                if (gameBall.Left <= 0)
                {
                    ball.RandomiseDirection();
                    ball.ResetPosition(new Point((this.Width - gameBall.Width) / 2, (this.Height) / 2 - gameBall.Height));
                    point2++;
                    updatePoints();
                }
                if (gameBall.Right >= this.Width)
                {
                    ball.RandomiseDirection();
                    ball.ResetPosition(new Point((this.Width - gameBall.Width) / 2, (this.Height) / 2 - gameBall.Height));
                    point1++;
                    updatePoints();
                }
                ball.UpdatePosition(step);
            }
        }

        private void updatePoints()
        {
            points.Text = $"{point1}:{point2}";
        }

        private void updateSpeed()
        {
            speed.Text = $"Speed: {step}";
        }
    }
}
/*
// Приклад використання
// Ball ball = new Ball(0, 0, 1, 1);
// ball.UpdatePosition(0.016f);  // Припустимо, що deltaTime = 0.016 (при 60 FPS)
// if (перевірка_на_відбивання_від_вертикальної_стінки) ball.ReflectVertical();
// if (перевірка_на_відбивання_від_горизонтальної_стінки_або_ракетки) ball.ReflectHorizontal();
*/