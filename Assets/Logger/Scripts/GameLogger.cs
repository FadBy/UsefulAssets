using System;
using System.IO;
using UnityEngine;

namespace Logger
{
    public class GameLogger : MonoBehaviour
    {
        private static GameLogger _instance;
        
        public static GameLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<GameLogger>();
                }
                return _instance;
            }
            private set { _instance = value; }
        }

        private string logDirectory;
        private string logFilePath;

        private void Awake()
        {
            Instance = this;

            InitLogFile();
        }

        private void OnApplicationQuit()
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            LogMessage($"[Endup at {timestamp}]");
        }

        private void InitLogFile()
        {
            logDirectory = Path.Combine(Application.dataPath, "Logs");
            Directory.CreateDirectory(logDirectory);

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            logFilePath = Path.Combine(logDirectory, $"Log_{timestamp}.txt");

            LogMessage($"[Startup at {timestamp}]");
        }

        private void Log(Status status, string groupName, string message)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string logMessage = FormatMessage(status, groupName, message);
            string logMessageWithTimestamp = FormatMessage(status, groupName, message, time);
            
            Debug.Log(logMessage);
            LogToFile(logMessageWithTimestamp);
        }

        private void LogMessage(string message)
        {
            Debug.Log(message);
            LogToFile(message);
        }

        private string FormatMessage(Status status, string groupName, string message, string time)
        {
            return $"[{time}] {FormatMessage(status, groupName, message)}";
        }
        
        private string FormatMessage(Status status, string groupName, string message)
        {
            return $"[{ConvertStatusToString(status)}] [{groupName}] {message}";
        }
        
        public void LogInfo(string groupName, string message)
        {
            Log(Status.Info, groupName, message);
        }
        
        public void LogWarning(string groupName, string message)
        {
            Log(Status.Warning, groupName, message);
        }
        
        public void LogError(string groupName, string message)
        {
            Log(Status.Error, groupName, message);
        }

        private void LogToFile(string message)
        {
            try
            {
                File.AppendAllText(logFilePath, message + Environment.NewLine);
            }
            catch (Exception e)
            {
                Debug.LogError($"[Logger] Failed to write log: {e.Message}");
            }
        }

        public static string ConvertStatusToString(Status status)
        {
            switch (status)
            {
                case Status.Error:
                    return "ERROR";
                case Status.Warning:
                    return "WARNING";
                case Status.Info:
                    return "INFO";
                default:
                    return "UNKNOWN";
            }
        }

        public enum Status
        {
            Info,
            Warning,
            Error,
        }
    }
}
