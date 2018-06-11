using BotBaDoshkaClasses.DTO;
using System;
using System.Linq;
using TwitchLib.Client.Models;

namespace BotBaDoshkaClasses.Generators
{
    public class MessageVectorGenerator
    {
        public MessageVector messageVector(ChatMessage cm, double UnintelligibilityLevel)
        {
            MessageVector Vector = new MessageVector();

            double CharCount = Convert.ToDouble(cm.Message.Length);
            double AlphaCount = Convert.ToDouble(cm.Message.Count(c => char.IsLetter(c)));
            double CapsCount = Convert.ToDouble(cm.Message.Count(c => char.IsLetter(c) & char.IsUpper(c)));
            double WordCount = Convert.ToDouble(cm.Message.Split(' ').Count());
            double EmoteCount = Convert.ToDouble(cm.EmoteSet.Emotes.Count());

            Vector.CharsToLim = CharCount / 500;
            Vector.CapsToChars = CapsCount / CharCount;
            Vector.NonAlphaToChars = (CharCount - AlphaCount) / CharCount;
            Vector.UnintelligibilityLevel = UnintelligibilityLevel;

            return Vector;
        }
    }
}
