using Battleship.Abstracts;
using Battleship.Classes;
using Battleship.Interfaces;
using Battleship.Values;
using SeaBattle.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{

    public class Program
    {

        public static void Main()
        {
            int consoleY = 3;
            Console.WriteLine("Hello, it`s Battleship!");
            BoardBuilder userBuilder = new DefaultBuilder();
            BoardBuilder botBuilder = new DefaultBuilder();
            Game CurrentGame = Game.getInstance(userBuilder, botBuilder);
            while (true)
            {
                if (consoleY > 27)
                {
                    consoleY = 3;
                    Console.Clear();
                }
                DrawBoards(Game.UserBoard, Game.BotBoard);
                Console.SetCursorPosition(30, consoleY);
                Console.Write("Your shot: ");
                try
                {
                    var shotCoordinates = Console.ReadLine()
                        .Split(new char[] { ' ', ',', ':' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(i => int.Parse(i))
                        .ToArray();
                    Game.UserStrategy.StrikeCell(Game.BotBoard, Cell.New(Position.New(shotCoordinates[0], shotCoordinates[1])));
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(30, consoleY);
                    Console.Write("Incorrect input");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.SetCursorPosition(30, consoleY);
                    Console.Write("Incorrect input");
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(30, consoleY);
                    Console.Write(e.Message);
                }

                consoleY++;
                if (Game.UserBoard.Lose())
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, consoleY);
                    Console.Write("You lose =(");
                    break;
                }
                Game.BotStrategy.StrikeCell(Game.UserBoard);
                if (Game.BotBoard.Lose())
                {
                    Console.Clear();
                    Console.SetCursorPosition(30, consoleY);
                    Console.Write("You won! =)");
                    break;
                }
            }
            Console.ReadKey();
        }


        static public void DrawBoards(IBoard userBoard, IBoard botBoard)
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Player: " + botBoard.SunkenCells + ", bot: " + userBoard.SunkenCells);
            DrawTopBorder();
            for (int i = 0; i < 10; i++)
            {
                //if(i==9) Console.Write(i + 1 + "| ");
                //else
                Console.Write(i + " | ");
                for (int j = 0; j < 10; j++)
                {
                    if (userBoard._cells[i * 10 + j].State.Equals(State.Empty)) Console.Write("· ");
                    else if (userBoard._cells[i * 10 + j].State.Equals(State.Busy)) Console.Write("■ ");
                    else if (userBoard._cells[i * 10 + j].State.Equals(State.OnFire)) Console.Write("X ");
                    else Console.Write("° ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            DrawTopBorder();
            for (int i = 0; i < 10; i++)
            {
                //if(i==9) Console.Write(i + 1 + "| ");
                //else
                Console.Write(i + " | ");
                for (int j = 0; j < 10; j++)
                {
                    if (botBoard._cells[i * 10 + j].State.Equals(State.OnFire)) Console.Write("X ");
                    else if (botBoard._cells[i * 10 + j].State.Equals(State.Checked)) Console.Write("° ");
                    else Console.Write("· ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
        static public void DrawTopBorder()
        {
            Console.Write("    ");
            for (int i = 0; i < 10; i++) Console.Write(i + " ");
            Console.WriteLine();
            Console.Write("    ");
            for (int i = 0; i < 10; i++) Console.Write("--");
            Console.WriteLine();
        }

    }
}
