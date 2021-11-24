using PadInput.Win32Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadInput.GamePadInput
{

    /// <summary>
    /// ゲームパッド入力の設定情報を保持する機能を提供するインターフェース。
    /// </summary>
    interface IGamePadSettingsModel
    {

        //各ボタンに対して：
        //表示するもの(文字・画像)

        /// <summary>
        /// ゲームパッド設定のリストを取得します。
        /// </summary>
        /// <returns></returns>
        IList<GamePadSetting> GetGamePadSettings();

    }
}