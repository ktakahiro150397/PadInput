using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadInputDisplay.Interface
{
    
    /// <summary>
    /// 表示するボタン情報を持つデータインターフェース。
    /// </summary>
    interface IGamePadDisplayButtonsInfo
    {

        /// <summary>
        /// 現在押下されているボタン情報のリスト。
        /// </summary>
        IList<IGamePadSingleButtonData> PressedButtonList { get; }

        /// <summary>
        /// 現在押下されている方向キー情報。
        /// </summary>
        IGamePadDirectionData Direction { get; }

    }

}
