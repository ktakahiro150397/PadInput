using PadInput.GamePadSettings.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadSettings
{
    public class GamePadInputDisplaySettings : IGamePadInputDisplaySettings
    {

        public GamePadInputDisplaySettings(int maxDisplayCount,string backgroundColor)
        {
            MaxDisplayCount = maxDisplayCount;
            BackgroundColor = backgroundColor;
        }

        public int MaxDisplayCount { get; }

        public string BackgroundColor { get; }
    }
}
