using PadInput.GamePadInput;
using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadSettings.Interface
{

    /// <summary>
    /// 同時押しボタン設定を表すインターフェース。
    /// </summary>
    public interface IGamePadSimultaneouslySettings
    {
        
        /// <summary>
        /// 同時押し設定の親ボタン。
        /// </summary>
        GamePadButtons ParentButton { get; }

        /// <summary>
        /// 親ボタンが押された時に押された状態とする子ボタンのリスト。
        /// </summary>
        IList<GamePadButtons> ChildButtons { get; }

    }
}
