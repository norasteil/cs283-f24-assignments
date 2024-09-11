using System;
using System.Security.Principal;
using System.Drawing;

public class Obstacle
{
    // sharks
    public float x;
    public float y;
    public float width = 15f;
    public float height = 15f;
    public float speed;
    private static Random randY = new Random();
    private static Random randSpeed = new Random();

    public void Reset()
    {
        y = randY.Next(75, Window.height);
        x = 0;
        speed = randSpeed.Next(20, 80);
    }

    public void Draw(Graphics g)
    {
        Color c = Color.FromArgb(255, 138, 191, 190);
        Pen pen = new Pen(c, 5);
        g.DrawArc(pen, x-26, y+11, 10, 15, 270, 180); // tail
        g.DrawArc(pen, x, y, 7, 22, 180, 180); // fin

        Brush brush = new SolidBrush(c);
        g.FillEllipse(brush, x-17, y+8, 40, 25);
    }

    public void Update(float dt)
    {
        x += speed * dt;

        if (x > Window.width)
        {
            Reset();
        }
    }
}