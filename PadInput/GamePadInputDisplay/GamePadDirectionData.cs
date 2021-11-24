using PadInput.GamePadInput;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadInputDisplay
{

    /// <summary>
    /// ゲームパッドの方向キー入力データを表します。
    /// </summary>
    class GamePadDirectionData : IGamePadDirectionData
    {
        public GamePadPOVDirection Direction => throw new NotImplementedException();
    }
}
