using PadInput.GamePadInput;
using PadInput.GamePadSettings.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadInputDisplay.Interface
{

    /// <summary>
    /// 単一のボタン情報を表すインターフェース。
    /// </summary>
    public interface IGamePadSingleButtonData
    {

        /// <summary>
        /// ボタン。
        /// </summary>
        GamePadButtons Button { get; }

        /// <summary>
        /// このボタンを表す文字列。
        /// </summary>
        string ButtonString { get; }

        /// <summary>
        /// 押下されているボタンの設定情報。
        /// </summary>
        IGamePadButtonSetting ButtonSetting { get; }


}

    /// <summary>
    /// 方向キー入力の情報を表すインターフェース。
    /// </summary>
    public interface IGamePadDirectionData
    {
        /// <summary>
        /// 入力されている方向キー。
        /// </summary>
        GamePadPOVDirection Direction { get; }

        /// <summary>
        /// この入力の方向キーの設定情報。
        /// </summary>
        IGamePadDirectionSetting DirectionSetting { get; }
    }

}
