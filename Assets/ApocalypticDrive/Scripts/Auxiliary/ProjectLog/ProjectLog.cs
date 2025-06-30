using System;
using System.Linq;
using UnityEngine;

namespace MeShineFactory.ApocalypticDrive
{
    public class ProjectLog
    {
        private static LogChannel[] ACCEPTED_CHANNELS = { LogChannel.Default };

        public static void Info(string message, LogChannel channel = LogChannel.Default)
        {
            if (IsChannelAccepted(channel))
                Debug.Log(message);
        }

        public static void Error(string message, LogChannel channel = LogChannel.Default)
        {
            if (IsChannelAccepted(channel))
                Debug.LogError(message);
        }

        public static void Warning(string message, LogChannel channel = LogChannel.Default)
        {
            if (IsChannelAccepted(channel))
                Debug.LogWarning(message);
        }

        private static bool IsChannelAccepted(LogChannel channel)
        {
            return ACCEPTED_CHANNELS.Contains(channel);
        }
    }
}
