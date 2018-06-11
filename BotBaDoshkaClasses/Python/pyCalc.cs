using BotBaDoshkaClasses.DTO;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

namespace BotBaDoshkaClasses.Python
{
    public class pyCalc
    {
        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6);
        string pyTcpUnintelligibilityPath = "\\tcpUnintelligibility.py";
        string pyNeuralPredictorPath = "\\predict.py";
        string clf = "\\clf.pkl";
        string neuralclf = "\\neuralclf.pkl";

        public void tcpProcessStart(string pyLocation)
        {
            string args = path + pyTcpUnintelligibilityPath + " " + path + clf + " " + path + "\\tempCoefficient.txt";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pyLocation;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = false;
            start.RedirectStandardError = false;
            Process process = Process.Start(start);
            Thread.Sleep(10000);
        }

        public double tcpUnintelligibilityProbability(string msg, Socket socket)
        {
            socket.Send(Encoding.UTF8.GetBytes(msg));

            Thread.Sleep(200);
            double ans = Convert.ToDouble(File.ReadAllText(path + "\\tempCoefficient.txt"));

            return ans;
        }

        public int predict(string pyLocation, MessageVector mv)
        {
            string args = (path + pyNeuralPredictorPath + " " + path + neuralclf + " " + string.Format("{0},{1},{2},{3},{4}", mv.CharsToLim.ToString().Replace(',', '.'), mv.CapsToChars.ToString().Replace(',', '.'), mv.NonAlphaToChars.ToString().Replace(',', '.'), mv.UnintelligibilityLevel.ToString().Replace(',', '.'), mv.EmotesToWords.ToString().Replace(',', '.'))) + " " + path + "\\tempPredict.txt";
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = pyLocation;
            start.Arguments = args;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = false;
            start.RedirectStandardError = false;
            Process process = Process.Start(start);
            Thread.Sleep(1000);
            return Convert.ToInt16(File.ReadAllText(path + "\\tempPredict.txt"));
        }
    }
}
