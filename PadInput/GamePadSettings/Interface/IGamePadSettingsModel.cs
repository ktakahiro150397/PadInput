using PadInput.GamePadInput;
using PadInput.Win32Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PadInput.GamePadSettings.Interface
{

    /// <summary>
    /// ゲームパッド入力の設定情報を保持する機能を提供するインターフェース。
    /// </summary>
    public interface IGamePadSettingsModel
    {

        ImageSource BaseImage { get; }

        /// <summary>
        /// ゲームパッド設定のリストを取得します。
        /// </summary>
        /// <returns></returns>
        IList<IGamePadButtonSetting> GetGamePadButtonSettings { get; }

        /// <summary>
        /// 指定したボタンの設定情報を取得します。
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        IGamePadButtonSetting GetGamePadButtonSetting(GamePadButtons button);

        /// <summary>
        /// 方向キー設定情報のリストを取得します。
        /// </summary>
        /// <returns></returns>
        IList<IGamePadDirectionSetting> GetGamePadDirectionSettings { get; }

        /// <summary>
        /// 指定した方向キーの設定情報を取得します。
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        IGamePadDirectionSetting GetGamePadDirectionSetting(GamePadPOVDirection direction);

    }
}