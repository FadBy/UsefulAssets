using System.Linq;
using extOSC;
using Logger;
using Zenject;

namespace OSC
{
    public class OSCDebugLogger : IInitializable
    {
        private OSCListener _listener;

        public OSCDebugLogger(OSCListener listener)
        {
            _listener = listener;
        }

        public void Initialize()
        {
            _listener.MessageReceived += LogMessage;
        }

        private void LogMessage(OSCMessage message)
        {
            GameLogger.Instance.LogInfo("OSC", ParseMessageToString(message));
        }
        
        public static string ParseMessageToString(OSCMessage message)
        {
            var valueStrings = message.Values.Select(ParseValueToString);
            return $"{message.Address} {string.Join(" ", valueStrings)}";
        }

        public static string ParseValueToString(OSCValue value)
        {
            switch (value.Type)
            {
                case OSCValueType.String:
                    return value.StringValue;
                case OSCValueType.Float:
                    return value.FloatValue.ToString();
                case OSCValueType.False:
                    return "0";
                case OSCValueType.True:
                    return "1";
                case OSCValueType.Int:
                    return value.IntValue.ToString();
                default:
                    GameLogger.Instance.LogError("OSC", $"Unconsidered OSCValueType {value}");
                    return "";
            }
        }
    }
}