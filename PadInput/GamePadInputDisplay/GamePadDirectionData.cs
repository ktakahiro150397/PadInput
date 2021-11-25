using PadInput.GamePadInput;
using System;
using System.Collections.Generic;
using System.Text;
using PadInput.GamePadInputDisplay.Interface;

namespace PadInput.GamePadInputDisplay
{

    /// <summary>
    /// ゲームパッドの方向キー入力データを表します。
    /// </summary>
    class GamePadDirectionData : IGamePadDirectionData
    {

        /// <summary>
        /// 入力方向を指定して初期化します。
        /// </summary>
        /// <param name="gamePadPOVDirection"></param>
        public GamePadDirectionData(GamePadPOVDirection gamePadPOVDirection)
        {
            Direction = gamePadPOVDirection;
        }

        public GamePadPOVDirection Direction { get; }
    }
}
