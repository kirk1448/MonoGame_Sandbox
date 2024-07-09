using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TestMonogameProject
{
    internal class World
    {
        public double gameTime;

        public int TILE_SIZE = 3;
        public int WORLD_SIZE = 480/3;

        public int[,] tiles;

        double lastUpdateTime;

        Random r = new Random();
        public World()
        {

            tiles = new int[WORLD_SIZE*2, WORLD_SIZE];

            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    tiles[x,y] = 1;
                }
            }
        }

        public void WorldUpdate()
        {
            if (gameTime > lastUpdateTime + 0)
            { 
            for (int x = 0; x < WORLD_SIZE * 2; x++)
            {
                for (int y = 0; y < WORLD_SIZE; y++)
                {
                    if (x < WORLD_SIZE * 2 && y < WORLD_SIZE-1 && x > 0 && y > 0)
                    {
                            //sand
                        if (tiles[x, y] == 1 && tiles[x, y + 1] == 0)
                        {
                            tiles[x, y] = 0;
                            tiles[x, y + 1] = 1;
                        }
                        else
                        if (tiles[x, y] == 1 && tiles[x + 1, y + 1] == 0 && x < WORLD_SIZE - 2)
                        {
                            tiles[x, y] = 0;
                            tiles[x + 1, y + 1] = 1;
                        }
                        else
                        if (x > 0 && tiles[x, y] == 1 && tiles[x - 1, y + 1] == 0)
                        {
                            tiles[x, y] = 0;
                            tiles[x - 1, y + 1] = 1;
                        }

                            //fire
                            int rf = r.Next(10);
                            if (tiles[x, y] == 2 && rf == 0)
                            {
                                int df = r.Next(10);
                                if (df > 5)
                                    tiles[x, y] = 3;
                                else
                                    tiles[x, y] = 0;
                            }
                        if (tiles[x, y] == 2 && tiles[x, y - 1] == 0)
                        {
                            tiles[x, y] = 0;
                            tiles[x, y - 1] = 2;
                        }
                        if (tiles[x, y] == 2 && tiles[x + 1, y - 1] == 0 && rf > 5)
                        {
                            tiles[x, y] = 0;
                            tiles[x + 1, y - 1] = 2;
                        }
                        if (tiles[x, y] == 2 && tiles[x - 1, y - 1] == 0 && rf < 5)
                        {
                            tiles[x, y] = 0;
                            tiles[x - 1, y - 1] = 2;
                        }
 
                        //smoke
                        rf = r.Next(10);
                        if (tiles[x, y] == 3 && rf == 0)
                        {
                                tiles[x, y] = 0;
                        }
                        if (tiles[x, y] == 3 && tiles[x, y - 1] == 0)
                        {
                            tiles[x, y] = 0;
                            tiles[x, y - 1] = 3;
                        }
                        if (tiles[x, y] == 2 && tiles[x + rf/2, y - 1] == 0 && rf > 5)
                        {
                            tiles[x, y] = 0;
                            tiles[x + rf/2, y - 1] = 2;
                        }
                        }
                }
            }
            lastUpdateTime = gameTime;
            }
        }

        public void createTile(Vector2 pos, int wichTile = 1)
        {
            if (pos.X < WORLD_SIZE * 2 - 1 && pos.Y < WORLD_SIZE-1 && pos.X > 0 && pos.Y > 0)
                tiles[(int)pos.X, (int)pos.Y] = wichTile;
        }

        public void createMoreTile(Vector2 pos, int wichTile = 1)
        {
            if (pos.X < WORLD_SIZE * 2 - 2 && pos.Y < WORLD_SIZE - 2 && pos.X > 1 && pos.Y > 1)
                tiles[(int)pos.X, (int)pos.Y] = wichTile;
                tiles[(int)pos.X-1, (int)pos.Y] = wichTile;
                tiles[(int)pos.X+1, (int)pos.Y] = wichTile;
                tiles[(int)pos.X, (int)pos.Y-1] = wichTile;
                tiles[(int)pos.X, (int)pos.Y+1] = wichTile;
        }
    }
}
