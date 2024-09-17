// Set up and run a game loop. Update the obstacles and players in the game.
// September 2024
// Nora Steil

using System;
using System.Drawing;
using System.Media;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Windows.Forms;

public class Game
{
    private Image bkgrd = Image.FromFile("gameBkg.jpg");
    private Player player;
    private Obstacle[] obstacles;
    private int rectWidth = 150;
    private int rectHeight = 75;
    private int fontSize = 10;
    private int rectY = 420;
    private int stringX = 525;
    private bool maximized = false;
    
    public void Setup()
    {
        player = new Player();
        obstacles = new Obstacle[6];

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i] = new Obstacle();
            obstacles[i].Reset();
        }
        player.Reset();
    }

    public void Update(float dt)
    {
        // update obstacles and player
        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.Update(dt);
        }
        player.Update(dt);
    }

    public void Draw(Graphics g)
    {
        // draw obstacles and player
        g.DrawImage(bkgrd, 0, 0, Window.width, Window.height);

        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.Draw(g);
        }

        player.Draw(g);

        DrawRectangle(g);
    }

    public void DrawRectangle(Graphics g)
    {
        Color rectColor = Color.FromArgb(200, 235, 148, 210);
        Brush brush = new SolidBrush(rectColor);
        g.FillRectangle(brush, 450, rectY, rectWidth, rectHeight);

        Font font = new Font("Times", fontSize);
        SolidBrush fontBrush = new SolidBrush(Color.Black);

        StringFormat format = new StringFormat();
        format.LineAlignment = StringAlignment.Center;
        format.Alignment = StringAlignment.Center;

        g.DrawString("Nora Steil\n9/12/24\nCS 283 Assignment 2", font, fontBrush, stringX, 450, format);
    }

    public void MouseClick(MouseEventArgs mouse)
    {
        if (mouse.Button == MouseButtons.Left)
        {
            System.Console.WriteLine(mouse.Location.X + ", " + mouse.Location.Y);
        }
    }

    public void KeyDown(KeyEventArgs key)
    {
        if (key.KeyCode == Keys.D || key.KeyCode == Keys.Right)
        {
            player.MoveRight();
        }
        else if (key.KeyCode== Keys.S || key.KeyCode == Keys.Down)
        {
            player.MoveDown();
        }
        else if (key.KeyCode == Keys.A || key.KeyCode == Keys.Left)
        {
            player.MoveLeft();
        }
        else if (key.KeyCode == Keys.W || key.KeyCode == Keys.Up)
        {
            player.MoveUp();
        }
        else if (key.KeyCode == Keys.Oemplus)
        {
            if (!maximized)
            {
                rectWidth += 20;
                rectHeight += 10;
                fontSize += 2;
                rectY -= 5;
                stringX += 10;
                maximized = true;
            }
            else
            {
                rectWidth = 150;
                rectHeight = 75;
                fontSize = 10;
                rectY = 420;
                stringX = 525;
                maximized = false;
            }
        }
    }
}
