using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotBaDoshkaClasses.DTO
{
    public class MessageVector
    {
        public double CharsToLim { get; set; }
        public double CapsToChars { get; set; }
        public double NonAlphaToChars { get; set; }
        public double EmotesToWords { get; set; }
        public double UnintelligibilityLevel { get; set; }
    }
}
