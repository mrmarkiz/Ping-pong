using System.Diagnostics;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private int step;
        private Ball ball;
        public bool continueGame;
        private int collisions;
        private int point1;
        private int point2;
        public int botStep;
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            _init();
        }

        private void _init()
        {
            gameBall.Location = new Point((this.Width - gameBall.Width) / 2, (this.Height) / 2 - gameBall.Height);
            pictureBox1.Top = this.Height / 2 - pictureBox1.Height;
            pictureBox2.Top = pictureBox1.Top;
            ball = new Ball(gameBall.Location.X, gameBall.Location.Y, 0, 0, gameBall);
            ball.RandomiseDirection();
            point1 = 0;
            point2 = 0;
            step = 5;
            collisions = 0;
            timer1.Start();
            updatePoints();
            updateSpeed();
            continueGame = false;
            this.Enabled = false;
            FormMenu menu = new FormMenu(this);
            menu.Show();
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
                moveBot();

                checkFormCollision();

                checkPlayersCollision();

                checkOutOfForm();

                ball.UpdatePosition(step);

                checkWinner();
            }
        }

        private void checkFormCollision()
        {
            if (gameBall.Top <= 0 || gameBall.Bottom >= this.Height - gameBall.Height)
                ball.ReflectVertical();
        }

        private void checkPlayersCollision()
        {
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
        }

        private void moveBot()
        {
            if (gameBall.Top < pictureBox2.Top)
            {
                if (pictureBox2.Top - botStep >= 0)
                    moveBoard(pictureBox2, 0, -botStep);
            }
            if (gameBall.Bottom > pictureBox2.Bottom)
            {
                if (pictureBox2.Bottom + botStep <= this.Height - pictureBox2.Height / 2)
                    moveBoard(pictureBox2, 0, botStep);
            }
        }

        private void checkOutOfForm()
        {
            if (gameBall.Left <= 0 || gameBall.Right >= this.Width)
            {
                if (gameBall.Left <= 0)
                    point2++;
                else
                    point1++;
                ball.RandomiseDirection();
                ball.ResetPosition(new Point((this.Width - gameBall.Width) / 2, (this.Height) / 2 - gameBall.Height));
                updatePoints();
                pictureBox1.Top = this.Height / 2 - pictureBox1.Height;
                pictureBox2.Top = pictureBox1.Top;
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

        private void checkWinner()
        {
            if (point1 == 5)
            {
                continueGame = false;
                MessageBox.Show("You won!!!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                restart();
            }
            else if (point2 == 5)
            {
                continueGame = false;
                MessageBox.Show("You lost!!!", "Unluck", MessageBoxButtons.OK, MessageBoxIcon.Information);
                restart();
            }

        }

        private void restart()
        {
            _init();
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