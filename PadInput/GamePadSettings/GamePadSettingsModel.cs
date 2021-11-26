using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PadInput.GamePadInput;
using PadInput.GamePadSettings.Interface;
using System.Windows.Media;

namespace PadInput.GamePadSettings
{

    /// <summary>
    /// ゲームパッド入力の表示設定に関する情報を保持します。
    /// </summary>
    class GamePadSettingsModel : IGamePadSettingsModel
    {

        /// <summary>
        /// 設定情報リストを使用して初期化します。
        /// </summary>
        /// <param name="gamePadButtonSettings"></param>
        /// <param name="gamePadDirectionSettings"></param>
        public GamePadSettingsModel(
            ImageSource baseImage,
            IList<IGamePadButtonSetting> gamePadButtonSettings,
            IList<IGamePadDirectionSetting> gamePadDirectionSettings
            )
        {
            BaseImage = baseImage;
            this.gamePadButtonSettings = gamePadButtonSettings;
            this.gamePadDirectionSettings = gamePadDirectionSettings;
        }

        public GamePadSettingsModel(string settingFilePath)
        {
            //TODO : xmlファイルからパースして設定情報を格納する
            throw new NotImplementedException();
        }

        private IList<IGamePadButtonSetting> gamePadButtonSettings;
        private IList<IGamePadDirectionSetting> gamePadDirectionSettings;

        public ImageSource BaseImage { get; }

        IList<IGamePadButtonSetting> IGamePadSettingsModel.GetGamePadButtonSettings => gamePadButtonSettings;

        IList<IGamePadDirectionSetting> IGamePadSettingsModel.GetGamePadDirectionSettings => gamePadDirectionSettings;

        public IGamePadButtonSetting GetGamePadButtonSetting(GamePadButtons button)
        {
            return gamePadButtonSettings.Where(elem => elem.Button == button).FirstOrDefault();
        }
        
        public IGamePadDirectionSetting GetGamePadDirectionSetting(GamePadPOVDirection direction)
        {
            return gamePadDirectionSettings.Where(elem => elem.Direction == direction).FirstOrDefault();
        }

    }
}
