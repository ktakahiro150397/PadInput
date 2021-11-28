using PadInput.GamePadInput;
using PadInput.GamePadSettings.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadSettings
{
    internal class GamePadSimultaneouslySettings : IGamePadSimultaneouslySettings
    {

        public GamePadSimultaneouslySettings(GamePadButtons parentButton,IList<GamePadButtons> childButtons)
        {
            ParentButton = parentButton;
            ChildButtons = childButtons;
        }

        public GamePadButtons ParentButton { get; }

        public IList<GamePadButtons> ChildButtons { get; }
    }
}
