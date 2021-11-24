using PadInput.GamePadInput;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadInputDisplay
{

    /// <summary>
    /// 単一のボタン情報を表すインターフェース。
    /// </summary>
    interface IGamePadSingleButtonData
    {

        /// <summary>
        /// ボタン。
        /// </summary>
        GamePadButtons Button { get; }

    }

    /// <summary>
    /// 方向キー入力の情報を表すインターフェース。
    /// </summary>
    interface IGamePadDirectionData
    {

        GamePadPOVDirection Direction { get; }
    }

}
