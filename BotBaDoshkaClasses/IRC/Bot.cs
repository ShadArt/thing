using BotBaDoshkaClasses.DTO;
using BotBaDoshkaClasses.Generators;
using BotBaDoshkaClasses.Python;
using System;
using System.Net.Sockets;
using System.Threading;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace BotBaDoshkaClasses.IRC
{
    public class Bot
    {
        TwitchClient client;
        bool isFirst = true;

        public void Connect(string BotUsername, string TwitchToken, string ChannelName, string pyLocation, Socket socket, pyCalc calc)
        {
            ConnectionCredentials credentials = new ConnectionCredentials(BotUsername, TwitchToken);
            Console.WriteLine("Connecting...");
            client = new TwitchClient();
            client.Initialize(credentials, ChannelName);
            client.OnMessageReceived += (sender1, e1) => onMessageReceieved(sender1, e1, pyLocation, socket, calc);
            client.OnConnected += (sender2, e2) => onConnected(sender2, e2, ChannelName);

            client.Connect();
        }

        private void onMessageReceieved(object sender, OnMessageReceivedArgs e, string pyLocation, Socket socket, pyCalc calc)
        {

            double unintelligibleProbability = calc.tcpUnintelligibilityProbability(e.ChatMessage.Message, socket);
            isFirst = false;

            MessageVector msgVector = new MessageVector();
            MessageVectorGenerator msgGen = new MessageVectorGenerator();
            msgVector = msgGen.messageVector(e.ChatMessage, unintelligibleProbability);

            int prediction = calc.predict(pyLocation, msgVector);

            if(prediction == 1)
            {
                client.SendMessage(e.ChatMessage.Channel, string.Format("stop, {0}", e.ChatMessage.DisplayName));
            }
        }

        private void onConnected(object sender, OnConnectedArgs e, string ChannelName)
        {
            Console.WriteLine("Connected!");
            client.JoinChannel(ChannelName, false);
        }
    }
}
