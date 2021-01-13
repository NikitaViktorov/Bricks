﻿using System;
using Bricks.Exceptions;
using Bricks.Interfaces;

namespace Bricks.Classes
{
    class EazyMenu : IMenu
    {
        Game game;

        IMenuFunction menuFunction = new MenuFunction();
        public EazyMenu(Game game)
        {
            this.game = game;
        }
        public void GameProcess()
        {
            GameHistory gameHistory = new GameHistory();

            Invoker invoker = new Invoker();

            Console.Write("Input of height:");

            int height = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input of width:");

            int width = Convert.ToInt32(Console.ReadLine());

            invoker.SetCommand(new InputDatesOfField(menuFunction, game, height,width));

            invoker.Run();

            Console.Clear();
            do
            {
                try
                {
                    if (menuFunction.Win(game.CurrentField.Bricks))
                    {
                        menuFunction.ShowField(game.CurrentField);

                        break;
                    }
                    else
                    {
                        while (!menuFunction.Win(game.CurrentField.Bricks))
                        {
                            menuFunction.ShowField(game.CurrentField);

                            Console.WriteLine("1.Input number");
                            Console.WriteLine("2.Save");
                            Console.WriteLine("3.Restore");
                            Console.Write("Your choice:");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 1:

                                    Console.Write("Input of number:");

                                    string number = Console.ReadLine();

                                    invoker = new Invoker();

                                    invoker.SetCommand(new InputNumber(menuFunction, game, number));

                                    invoker.Run();

                                    Console.Clear();

                                    break;

                                case 2:

                                    gameHistory.History.Push(game.CurrentField.Bricks);

                                    break;

                                case 3:

                                    game.CurrentField.Bricks = gameHistory.History.Pop();

                                    break;
                            }

                            //Console.Write("Input of number:");

                            //string number = Console.ReadLine();

                            //invoker = new Invoker();

                            //invoker.SetCommand(new InputNumber(menuFunction,game,number));

                            //invoker.Run();

                            //Console.Clear();

                        }

                        break;
                    }
                }
                catch (NumberException ex)
                {
                    Console.Clear();

                    Console.WriteLine(ex.Message);

                }
            }while (true);

            Console.WriteLine("Победа");
        }
    }
}
