using PadInput.GamePadInput;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace PadInput.GamePadSettings.Interface
{

    /// <summary>
    /// 単一のゲームパッド設定を表すインターフェース。
    /// </summary>
    public interface IGamePadButtonSetting
    {
        /// <summary>
        /// この設定を表すボタン。
        /// </summary>
        GamePadButtons Button { get; }

        /// <summary>
        /// オーバーレイ表示するイメージ。
        /// </summary>
        ImageSource OverlayImage { get; }

        /// <summary>
        /// オーバーレイ表示する座標。
        /// </summary>
        Vector? OverlayImagePosition { get; }


    }
}
