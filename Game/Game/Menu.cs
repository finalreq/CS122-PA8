﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace Game
{
    class Menu
    {
        public bool is_active;
        private bool exit_flag;
        private bool restart_flag;
        private bool is_directions_viewable;

        //Restart Button
        private Texture2D restart_but;
        private Texture2D restart_but_clicked;
        private Texture2D restart_but_hover;
        private Texture2D restart_but_current;
        private Vector2 restart_but_pos;

        //Exit Button
        private Texture2D exit_but;
        private Texture2D exit_but_clicked;
        private Texture2D exit_but_hover;
        private Texture2D exit_but_current;
        private Vector2 exit_but_pos;

        //Background
        private Texture2D bg;
        private Vector2 bg_pos;
        private Vector2 bg_start_pos;
        private float bg_scale;

        //X Button
        private Texture2D x_but;
        private Texture2D x_but_clicked;
        private Texture2D x_but_current;
        private Vector2 x_but_pos;

        //Directions background
        private Texture2D directions_bg;
        private Vector2 directions_pos;

        //Help Button
        private Texture2D help_but_current;
        private Texture2D help_but_rest;
        private Texture2D help_but_hover;
        private Texture2D help_but_clicked;
        private Vector2 help_but_pos;        

        private MouseState prev_mouse;

        public void Initialize()
        {
            is_directions_viewable = false;
            is_active = false;
            exit_flag = false;
            restart_flag = false;

            restart_but_pos.X = 400;
            restart_but_pos.Y = 232;

            exit_but_pos.X = 650;
            exit_but_pos.Y = 232;

            x_but_pos.X = 800;
            x_but_pos.Y = 125;

            help_but_pos.X = 525;
            help_but_pos.Y = 346;

            //bg_pos.X = 313;
            //bg_pos.Y = 88;
            bg_start_pos.X = 597;
            bg_start_pos.Y = 298;
            bg_pos = bg_start_pos;
            bg_scale = 0.01F;

            directions_pos.X = 0;
            directions_pos.Y = -600;
        }

        public void LoadContent(ContentManager Content)
        {
            restart_but = Content.Load<Texture2D>("MenuContent/RestartButton");
            restart_but_clicked = Content.Load<Texture2D>("MenuContent/RestartButtonClicked");
            restart_but_hover = Content.Load<Texture2D>("MenuContent/RestartButtonHover");
            exit_but = Content.Load<Texture2D>("MenuContent/ExitButton");
            exit_but_clicked = Content.Load<Texture2D>("MenuContent/ExitButtonClicked");
            exit_but_hover = Content.Load<Texture2D>("MenuContent/ExitButtonHover");
            x_but = Content.Load<Texture2D>("MenuContent/xButton");
            x_but_clicked = Content.Load<Texture2D>("MenuContent/xButtonClicked");
            help_but_rest = Content.Load<Texture2D>("MenuContent/HelpButton");
            help_but_clicked = Content.Load<Texture2D>("MenuContent/HelpButtonClicked");
            help_but_hover = Content.Load<Texture2D>("MenuContent/HelpButtonHover");

            bg = Content.Load<Texture2D>("MenuContent/MenuBackground");
            directions_bg = Content.Load<Texture2D>("MenuContent/DirectionsScreen");

            restart_but_current = restart_but;
            exit_but_current = exit_but;
            x_but_current = x_but;
            help_but_current = help_but_rest;
           

        }

        public void draw(ref SpriteBatch sprites)
        {
            if (is_active)
            {
                if (is_directions_viewable)
                {
                    sprites.Draw(directions_bg, directions_pos, Color.White);
                }

                sprites.Draw(bg, bg_pos, null, Color.White, 0, new Vector2(0,0), bg_scale, 0, 0);

                if (bg_scale >= 1)
                {
                    sprites.Draw(restart_but_current, restart_but_pos, Color.White);
                    sprites.Draw(exit_but_current, exit_but_pos, Color.White);
                    sprites.Draw(x_but_current, x_but_pos, Color.White);
                    sprites.Draw(help_but_current, help_but_pos, Color.White);
                }
            }
        }

        public void setActive()
        {
            is_active = true;
        }

        public void Update(bool isEscapeKeyPressed, bool previousKeyState)
        {
            if (isEscapeKeyPressed && !previousKeyState)
            {
                if (is_active)
                {
                    exit();
                }
                else
                {
                    is_active = true;
                }
            }

            if (is_active)
            {
                MouseState mouse = Mouse.GetState();

                //Check for the restart button.
                if ((mouse.X <= restart_but_pos.X + 140 && restart_but_pos.X <= mouse.X)
                                        &&
                    (mouse.Y <= restart_but_pos.Y + 68 && restart_but_pos.Y <= mouse.Y))
                {
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        restart_but_current = restart_but_clicked;
                    }
                    else if (mouse.LeftButton == ButtonState.Released && prev_mouse.LeftButton == ButtonState.Pressed)
                    {
                        restart_flag = true;
                        exit();
                    }
                    else
                    {
                        restart_but_current = restart_but_hover;
                    }
                }

                //Let's check for the exit button. 
                else if ((mouse.X <= exit_but_pos.X + 140 && exit_but_pos.X <= mouse.X)
                                                    &&
                         (mouse.Y <= exit_but_pos.Y + 68 && exit_but_pos.Y <= mouse.Y))
                {
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        exit_but_current = exit_but_clicked;

                    }
                    else if (mouse.LeftButton == ButtonState.Released && prev_mouse.LeftButton == ButtonState.Pressed)
                    {
                        exit_flag = true;
                        exit();
                    }
                    else
                    {
                        exit_but_current = exit_but_hover;
                    }
                }

                //Checks for the menu x button to exit the menu.
                else if ((mouse.X <= x_but_pos.X + 43 && x_but_pos.X + 7 <= mouse.X)
                                                    &&
                         (mouse.Y <= x_but_pos.Y + 43 && x_but_pos.Y + 7 <= mouse.Y))
                {
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        x_but_current = x_but_clicked;

                    }
                    else if (mouse.LeftButton == ButtonState.Released && prev_mouse.LeftButton == ButtonState.Pressed)
                    {
                        exit();
                    }
                    else
                    {
                        x_but_current = x_but_clicked;
                    }

                }

                //Check for the help button
                else if ((mouse.X <= help_but_pos.X + 140 && help_but_pos.X <= mouse.X)
                                                    &&
                         (mouse.Y <= help_but_pos.Y + 68 && help_but_pos.Y <= mouse.Y))
                {
                    if (mouse.LeftButton == ButtonState.Pressed)
                    {
                        help_but_current = help_but_clicked;

                    }
                    else if (mouse.LeftButton == ButtonState.Released && prev_mouse.LeftButton == ButtonState.Pressed)
                    {                        
                        is_directions_viewable = true;
                    }
                    else
                    {
                        help_but_current = help_but_hover;
                    }

                }

                else
                {
                    exit_but_current = exit_but;
                    restart_but_current = restart_but;
                    x_but_current = x_but;
                    help_but_current = help_but_rest;
                }

                prev_mouse = mouse;

                if (is_directions_viewable && directions_pos.Y != 0)
                {
                    directions_pos.Y += 25;
                }

                if (bg_scale < 1)
                {
                    bg_scale += 0.05F;
                    bg_pos.X -= (bg.Width / 2) * 0.05F;
                    bg_pos.Y -= (bg.Height / 2) * 0.05F;
                }

            }            
        }

        private void exit()
        {
            is_active = false;
            is_directions_viewable = false;
            directions_pos.Y = -600;
            bg_scale = .01F;
            bg_pos = bg_start_pos; 
        }
        public bool isPause()
        {
            if (is_active)
            {
                return true;
            }
            return false;
        }

        //This function only returns true once for every occurence.
        public bool isRestart()
        {
            bool flag = restart_flag;
            restart_flag = false;
            return flag;
        }

        public bool isExit()
        {
            return exit_flag;
        }
    }
}
