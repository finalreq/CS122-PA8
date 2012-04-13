﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    class Player : Block
    {
        public int acceleration;
        public int velocity;
        public bool onTopOfBlock;
        public int whichBlock;

        public bool airbourne;

        public void jump()
        {
            velocity = -35;
        }

        public override void Initialize(Texture2D initTexture, Vector2 initPosition)
        {
            base.Initialize(initTexture, initPosition);
            acceleration = 3;
            velocity = 0;
            onTopOfBlock = false;
        }

        public bool willCollide(Block obj2, int direction, int speed)
        {
            Rectangle obj1Rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            switch (direction)
            {
                case 1: obj1Rectangle.Y -= speed; break;    //up
                case 2: obj1Rectangle.Y += speed; break;    //down
                case 3: obj1Rectangle.X -= speed; break;    //left
                case 4: obj1Rectangle.X += speed; break;    //right
            }
            String box = "Hello";
            switch (box)
            {
                case "Hello":
                    box = "too";
                    break;
            }
            Rectangle obj2Rectangle = new Rectangle((int)obj2.position.X, (int)obj2.position.Y, obj2.width, obj2.height);

            return obj1Rectangle.Intersects(obj2Rectangle);
        }
    }
}
