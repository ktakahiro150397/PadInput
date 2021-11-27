using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PadInput.GamePadInput;
using PadInput.GamePadSettings.Interface;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PadInput.GamePadSettings
{

    /// <summary>
    /// ゲームパッド入力の表示設定に関する情報を保持します。
    /// </summary>
    public class GamePadSettingsModel : IGamePadSettingsModel
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

        [Obsolete("設定ファイルの読み込み部分を作成したら使用しない")]
        public GamePadSettingsModel()
        {

            //テスト用設定読み込み
            var currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ImageSource baseImage = new BitmapImage(new Uri(
                 System.IO.Path.Combine(currentDir, @"Settings\Pic\Base.png")
             ));

            IList<IGamePadButtonSetting> buttonSettings = new List<IGamePadButtonSetting>();
            IList<IGamePadDirectionSetting> directionSettings = new List<IGamePadDirectionSetting>();

            var buttonImage_1 = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\D_Press.png")
                )
            );
            var buttonImage_2 = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\A_Press.png")
                )
            );
            var buttonImage_3 = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\B_Press.png")
                )
            );
            var buttonImage_4 = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\C_Press.png")
                )
            );

            buttonSettings.Add(
                new GamePadButtonSetting(
                    GamePadButtons.PAD_BUTTON_1,
                    buttonImage_1,
                    new System.Windows.Vector(0, 0)
                )
            );
            buttonSettings.Add(
                new GamePadButtonSetting(
                    GamePadButtons.PAD_BUTTON_0,
                    buttonImage_2,
                    new System.Windows.Vector(0, 32)
                )
            );
            buttonSettings.Add(
                new GamePadButtonSetting(
                    GamePadButtons.PAD_BUTTON_3,
                    buttonImage_3,
                    new System.Windows.Vector(0, 64)
                )
            );
            buttonSettings.Add(
                new GamePadButtonSetting(
                    GamePadButtons.PAD_BUTTON_2,
                    buttonImage_4,
                    new System.Windows.Vector(0, 96)
                )
            );

            var directionImage_Up = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\Direction_Up.png")
                )
            );
            directionSettings.Add(
                new GamePadDirectionSetting(
                    GamePadPOVDirection.Up,
                    directionImage_Up
                )
            );

            BaseImage = baseImage;
            gamePadButtonSettings = buttonSettings;
            gamePadDirectionSettings = directionSettings;


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
