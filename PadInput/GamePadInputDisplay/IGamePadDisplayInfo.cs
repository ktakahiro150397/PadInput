using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadInputDisplay
{

    /// <summary>
    /// 画面に表示するキー入力情報のデータを表します。
    /// </summary>
    interface IGamePadDisplayInfo : IGamePadDisplayFrameInfo, IGamePadDisplayButtonsInfo
    {
    }
}
