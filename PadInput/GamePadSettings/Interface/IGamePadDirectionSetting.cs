using PadInput.GamePadInput;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace PadInput.GamePadSettings.Interface
{

    /// <summary>
    /// 方向キーの設定情報を表すインターフェース。
    /// </summary>
    public interface IGamePadDirectionSetting
    {
        /// <summary>
        /// この設定を表すボタン。
        /// </summary>
        GamePadPOVDirection Direction { get; }

        /// <summary>
        /// オーバーレイ表示するイメージ。
        /// </summary>
        ImageSource DirectionImages { get; }

    }
}
