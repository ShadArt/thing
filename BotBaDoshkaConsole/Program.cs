using System;
using BotBaDoshkaClasses.IRC;
using System.Net.Sockets;
using BotBaDoshkaClasses.Python;
using System.Threading;
using System.Collections.Generic;

namespace BotBaDoshkaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isConnected = false;

            while(isConnected != true)
            {
                try
                {
                    Console.WriteLine("Enter the bot's username:");
                    string BotUsername = Console.ReadLine();
                    Console.WriteLine("Enter the Twitch token:");
                    string TwitchToken = Console.ReadLine();
                    Console.WriteLine("Enter the channel you want to join:");
                    string ChannelName = Console.ReadLine();
                    Console.WriteLine("Enter the full path to the Python executable");
                    string pyPath = @Console.ReadLine();

                    pyCalc calc = new pyCalc();
                    calc.tcpProcessStart(pyPath);

                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect("127.0.0.1", 5005);
                    Bot bot = new Bot();
                    bot.Connect(BotUsername, TwitchToken, ChannelName, pyPath, socket, calc);
                    isConnected = true;
                    Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Invalid credentials.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
