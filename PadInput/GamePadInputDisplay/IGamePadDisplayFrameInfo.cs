using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadInputDisplay
{

    /// <summary>
    /// 表示するフレーム情報を持つデータインターフェース。
    /// </summary>
    interface IGamePadDisplayFrameInfo
    {

        /// <summary>
        /// 経過した合計のフレーム数。
        /// </summary>
        int ElapsedFrameCount { get; }

    }
}
