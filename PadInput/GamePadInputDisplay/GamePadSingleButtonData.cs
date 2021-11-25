using System;
using System.Collections.Generic;
using System.Text;
using PadInput.GamePadInput;
using PadInput.GamePadInputDisplay.Interface;

namespace PadInput.GamePadInputDisplay
{
    /// <summary>
    /// 単一のゲームパッドボタン入力データを表します。
    /// </summary>
    class GamePadSingleButtonData : IGamePadSingleButtonData
    {

        /// <summary>
        /// ボタンを指定して初期化します。
        /// </summary>
        /// <param name="button"></param>
        public GamePadSingleButtonData(GamePadButtons button)
        {
            Button = button;
        }

        public GamePadButtons Button { get; }

        public string ButtonString => Button.ToString();
    }
}
