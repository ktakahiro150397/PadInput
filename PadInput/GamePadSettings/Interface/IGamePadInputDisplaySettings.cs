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
    public interface IGamePadInputDisplaySettings
    {
        /// <summary>
        /// 画面に表示するキー入力履歴の最大数。
        /// </summary>
        int MaxDisplayCount { get; }

        /// <summary>
        /// 背景色。。
        /// </summary>
        string BackgroundColor { get; }
    }
}
