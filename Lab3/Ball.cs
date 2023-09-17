using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Ball
    {
        private List<float> directions = new List<float>()
        {
            -0.8f, -0.6f, -0.4f, -0.2f, 0.2f, 0.4f, 0.6f, 0.8f
        };

        public int X { get; private set; }
        public int Y { get; private set; }
        public float Vx { get; private set; }
        public float Vy { get; private set; }

        public PictureBox reflection { get; private set; }

        public Ball(int x, int y, float vx, float vy, PictureBox reflection)
        {
            X = x;
            Y = y;
            Vx = vx;
            Vy = vy;
            this.reflection = reflection;
        }

        public void UpdatePosition(int step)
        {
            X += (int)(Vx * step);
            Y += (int)(Vy * step);
            reflection.Location = new Point(X, Y);
        }

        public void ResetPosition(Point position)
        {
            X = position.X;
            Y = position.Y;
        }

        public void ReflectVertical()
        {
            Vy = -Vy;
        }

        public void ReflectHorizontal()
        {
            Vx = -Vx;
        }

        public void RandomiseDirection()
        {
            Random rnd = new Random();
            Vx = directions[rnd.Next(directions.Count)];
            Vy = 1 - Math.Abs(Vx);
            if (rnd.Next(2) == 0)
                Vy *= -1;
        }
    }
}
