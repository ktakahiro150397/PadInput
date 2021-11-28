using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
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
            this.baseImage = baseImage;
            this.gamePadButtonSettings = gamePadButtonSettings;
            this.gamePadDirectionSettings = gamePadDirectionSettings;
        }

        public GamePadSettingsModel(string settingFilePath)
        {
            //TODO : xmlファイルからパースして設定情報を格納する
            LoadSettingsFromXmlFile(settingFilePath);
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

            this.baseImage = baseImage;
            gamePadButtonSettings = buttonSettings;
            gamePadDirectionSettings = directionSettings;


        }

        private ImageSource baseImage;
        private IList<IGamePadButtonSetting> gamePadButtonSettings;
        private IList<IGamePadDirectionSetting> gamePadDirectionSettings;
        private IGamePadInputDisplaySettings displaySettings;

        public ImageSource BaseImage => baseImage;

        IList<IGamePadButtonSetting> IGamePadSettingsModel.GetGamePadButtonSettings => gamePadButtonSettings;

        IList<IGamePadDirectionSetting> IGamePadSettingsModel.GetGamePadDirectionSettings => gamePadDirectionSettings;

        public IGamePadInputDisplaySettings DisplaySettings => displaySettings;

        public IGamePadButtonSetting GetGamePadButtonSetting(GamePadButtons button)
        {
            return gamePadButtonSettings.Where(elem => elem.Button == button).FirstOrDefault();
        }

        public IGamePadDirectionSetting GetGamePadDirectionSetting(GamePadPOVDirection direction)
        {
            return gamePadDirectionSettings.Where(elem => elem.Direction == direction).FirstOrDefault();
        }

        private void LoadSettingsFromXmlFile(string filePath)
        {

            if (!File.Exists(filePath))
            {
                throw new ApplicationException($"設定ファイルが見つかりませんでした。指定されたファイルパス：{filePath}");
            }

            PadInputSettings parseResult = null;
            var serializer = new XmlSerializer(typeof(PadInputSettings));

            try
            {

                using (StreamReader sr = new StreamReader(filePath))
                {
                    parseResult = (PadInputSettings)serializer.Deserialize(sr);
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"設定ファイルの読み込みに失敗しました。" +
                    $"{ex.ToString()}"
                );
            }


            //カレントディレクトリ
            var currentDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //ベースイメージ
            baseImage = GetImageSourceFromCurrentDirectory(
                    currentDir,
                    parseResult.ButtonOverlaySettings.BaseOverlayImage);



            //表示設定の取得
            displaySettings = new GamePadInputDisplaySettings(
                parseResult.InputDisplaySettings.MaxDisplayCount,
                parseResult.InputDisplaySettings.BackgroundColor
            );

            //ボタン設定の追加
            this.gamePadButtonSettings = new List<IGamePadButtonSetting>();
            foreach (var buttonSetting in parseResult.ButtonOverlaySettings.ButtonOverlayImages)
            {

                GamePadButtons inputButton;
                if (!Enum.TryParse(buttonSetting.button.ToString(), out inputButton) || !Enum.IsDefined(typeof(GamePadButtons), inputButton))
                {
                    //存在しないボタンIDが指定
                    continue;
                }

                gamePadButtonSettings.Add(
                    new GamePadButtonSetting(
                        inputButton,
                        GetImageSourceFromCurrentDirectory(currentDir, buttonSetting.ImageName),
                        new System.Windows.Vector(buttonSetting.OverlayImagePosition.x, buttonSetting.OverlayImagePosition.y)
                ));
            }


            //方向キー設定の追加
            this.gamePadDirectionSettings = new List<IGamePadDirectionSetting>();
            foreach (var directionSetting in parseResult.POVDirectionImages)
            {

                GamePadPOVDirection inputDirection;
                if (!Enum.TryParse(directionSetting.direction, out inputDirection))
                {
                    //存在しない方向キーが指定
                    continue;
                }

                if (!gamePadDirectionSettings.Any(elem => elem.Direction == inputDirection))
                {
                    gamePadDirectionSettings.Add(
                        new GamePadDirectionSetting(
                            inputDirection,
                            GetImageSourceFromCurrentDirectory(currentDir, directionSetting.Value
                        )
                    ));
                }

            }

        }

        private ImageSource GetImageSourceFromCurrentDirectory(string currentDir, string imagePath)
        {

            string filePath = Path.Combine(currentDir, imagePath);

            if (!File.Exists(filePath))
            {
                return null;
            }
            else
            {
                return new BitmapImage(new Uri(filePath));
            }
        }

    }
}
