// csc filesio.cs && filesio && del filesio.exe
using System;
using System.Collections.Generic;
using System.IO;   // for File
using System.Text; // for UTF8Encoding
using System.Threading;

interface IExample {
    void Run();
}

class UserInput : IExample {
    // ReadLine, Read, ReadKey
    public void Run() {
        // ReadLine
        Console.WriteLine("Type some text: ");
        string userInput = Console.ReadLine();
        Console.WriteLine("You wrote: '" + userInput + "'");
        Console.WriteLine("==========");

        // Read
        Console.WriteLine("Hit a key: ");
        int x = Console.Read();
        Console.WriteLine("You hit: '" + x + "'");
        Console.WriteLine("Which has a char value of '" + Convert.ToChar(x) + "'");
        Console.WriteLine("==========");
    
        // Read to change the console background
        Console.WriteLine("g = green, r = red, b = blue, w = white");
        int a = Console.Read();
        char currentInput = Convert.ToChar(a);
        while (currentInput != 'z') {
            switch (currentInput) {
                case 'g':
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case 'r':
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case 'b':
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case 'w':
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                default:
                    break;
            }
            Console.Clear();
            Console.WriteLine("g = green, r = red, b = blue, w = white");
            currentInput = Convert.ToChar(Console.Read());
        }

        // ReadKey
        ConsoleKeyInfo keyInfo;
        Console.TreatControlCAsInput = true;
        do {
            keyInfo = Console.ReadKey();
            if ((keyInfo.Modifiers & ConsoleModifiers.Alt) != 0) {
                Console.Write("ALT+");
            }
            if ((keyInfo.Modifiers & ConsoleModifiers.Shift) != 0) {
                Console.Write("SHIFT+");
            }
            if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0) {
                Console.Write("CRTL+");
            }
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}

class NumericUserInput : IExample {
    public void Run() {
        Console.WriteLine("Please enter a number: ");
        do {
            int number;
            string userInput = Console.ReadLine();
            if (userInput.Contains("z")) {
                Console.WriteLine("Exiting...");
                break;
            }
            if(!int.TryParse(userInput, out number)) {
                Console.WriteLine("You entered invalid input!");
                Console.WriteLine("Please enter a number: ");
            } else {
                Console.WriteLine("Thanks! Please enter another number: ");
            }
        } while(true);
    }
}

class WorkingWithFiles : IExample {
    public void Run() {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\MyBasicExample.txt";
        if (!File.Exists(path)) {
            File.Create(path);
        }

        FileStream fs = File.Open(path, FileMode.Append);
        byte[] info = new UTF8Encoding(true).GetBytes("Hello World");
        fs.Write(info, 0, info.Length);
        fs.Close();

        StreamReader sr = new StreamReader(path);
        string fileText = sr.ReadToEnd();
        Console.WriteLine(fileText);
    }
}

class TicTacToe : IExample {
    static char[] spaces = new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
    static int player = 1;
    static int choice;
    static int flag;

    /// <summary>
    /// Draws the game board.
    /// </summary>
    static void DrawBoard() {
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" {0} | {1} | {2} ", spaces[0], spaces[1], spaces[2]);
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" {0} | {1} | {2} ", spaces[3], spaces[4], spaces[5]);
        Console.WriteLine("___|___|___");
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" {0} | {1} | {2} ", spaces[6], spaces[7], spaces[8]);
        Console.WriteLine("   |   |   ");
    }

    /// <summary>
    /// Checks if the game was won, tied, or should continue.
    /// </summary>
    static int CheckWin() {
        if (spaces[0] == spaces[1] &&
            spaces[1] == spaces[2] || // row1
            spaces[3] == spaces[4] &&
            spaces[4] == spaces[5] || // row2
            spaces[6] == spaces[7] &&
            spaces[7] == spaces[8] || // row3
            spaces[0] == spaces[3] &&
            spaces[3] == spaces[6] || // col1
            spaces[1] == spaces[4] &&
            spaces[4] == spaces[7] || // col2
            spaces[2] == spaces[5] &&
            spaces[5] == spaces[8] || // col3
            spaces[0] == spaces[4] &&
            spaces[4] == spaces[8] || // diag1
            spaces[2] == spaces[4] &&
            spaces[4] == spaces[6])   // diag2
        {
            return 1;
        }
        else if (
            spaces[0] != '1' &&
            spaces[1] != '2' &&
            spaces[2] != '3' &&
            spaces[3] != '4' &&
            spaces[4] != '5' &&
            spaces[5] != '6' &&
            spaces[6] != '7' &&
            spaces[7] != '8' &&
            spaces[8] != '9'
        ) {
            return -1;
        }
        return 0;
    }

    /// <summary>
    /// Draws an X on the game board.
    /// </summary>
    static void DrawX(int pos) {
        spaces[pos] = 'X';
    }

    /// <summary>
    /// Draws an O on the game board.
    /// </summary>
    static void DrawO(int pos) {
        spaces[pos] = 'O';
    }

    /// <summary>
    /// the main game loop.
    /// </summary>
    public void Run() {
        do {
            Console.Clear();
            Console.WriteLine("Player 1: X and Player 2: O \n");
            if (player %2 == 0) {
                Console.WriteLine("Player 2's turn");
            } else {
                Console.WriteLine("Player 1's turn");
            }

            Console.WriteLine("\n");
            DrawBoard();
            choice = int.Parse(Console.ReadLine()) - 1;
            if (spaces[choice] != 'X' && spaces[choice] != 'O') {
                if (player % 2 == 0) {
                    DrawO(choice);
                } else {
                    DrawX(choice);
                }
                player++;
            } else {
                Console.WriteLine("Sorry, the row {0} is already marked with {1}", choice, spaces[choice]);
                Console.WriteLine("Please wait 1 second for the board to reload...");
                Thread.Sleep(1000);
            }

            flag = CheckWin();
        } while(flag != 1 && flag != -1);

        Console.Clear();
        DrawBoard();
        if (flag == 1) {
            Console.WriteLine("Player {0} has won", (player % 2) + 1);
        } else {
            Console.WriteLine("Tie Game");
        }

        Console.ReadLine();
    }
}

class Program {
    public static void Main() {
        Console.WriteLine("Startup...");
        var examples = new List<IExample> {
            new TicTacToe()
            //new NumericUserInput(),
            //new UserInput(),
            //new WorkingWithFiles(),
        };

        Console.WriteLine(examples.Count + " Examples...");
        foreach(var example in examples) {
            Console.WriteLine("Example: " + example.GetType().Name + "...");
            example.Run();
            Console.WriteLine("==========");
        }
    }
}

// Program.Main(); // dotnet-script filesio.cs
