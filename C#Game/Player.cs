using System;
using System.Security.Principal;
using System.Drawing;

public class Player 
{
    private float x = Window.width * 0.5f;
    private float y = Window.height * 0.5f;
    private float speed = 60;
    private float dx, dy;

    public void Reset()
    {
        x = Window.width * 0.5f;
        y = Window.height * 0.5f;
        dx = 0;
        dy = 0;
    }

    public void Draw(Graphics g)
    {
        Color c = Color.FromArgb(255, 177, 3, 252);
        Pen pen = new Pen(c, 2);
        g.DrawArc(pen, x, y, 10, 15, 270, 180);

        Brush brush = new SolidBrush(c);
        g.FillEllipse(brush, x + 10, y - 2f, 20, 20);
    }

    public void Update(float dt)
    {
        x += dx * speed * dt;
        y += dy * speed * dt;
    }


    // flip direction for movement? can change tail arc
    public void MoveRight()
    {
        dx = 1;
        dy = 0;
        
    }

    public void MoveLeft()
    {
        dx = -1;
        dy = 0;
    }

    public void MoveDown()
    {
        dx = 0;
        dy = 1;
    }

    public void MoveUp()
    {
        dx = 0;
        dy = -1;
    }
}