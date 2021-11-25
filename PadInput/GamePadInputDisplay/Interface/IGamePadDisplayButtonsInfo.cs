using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Media.Imaging;

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
        /// ボタン押下状態を表す<see cref="BitmapSource"/>の画像。
        /// </summary>
        BitmapSource PressedButtonBitMap { get; set; }

        /// <summary>
        /// 現在押下されている方向キー情報。
        /// </summary>
        IGamePadDirectionData Direction { get; }

    }

}
