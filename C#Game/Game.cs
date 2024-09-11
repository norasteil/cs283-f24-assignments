// Set up and run a game loop. Update the obstacles and players in the game.
// September 2024
// Nora Steil

using System;
using System.Drawing;
using System.Media;
using System.Security.Principal;
using System.Windows.Forms;

public class Game
{
    private Image bkgrd = Image.FromFile("gameBkg.jpg");
    private Player player;
    private Obstacle[] obstacles;

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
    }
}
