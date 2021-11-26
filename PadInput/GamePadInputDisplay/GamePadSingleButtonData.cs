using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using PadInput.GamePadInput;
using PadInput.GamePadInputDisplay.Interface;
using PadInput.GamePadSettings;
using PadInput.GamePadSettings.Interface;

namespace PadInput.GamePadInputDisplay
{
    /// <summary>
    /// 単一のゲームパッドボタン入力データを表します。
    /// </summary>
    class GamePadSingleButtonData : IGamePadSingleButtonData
    {

        /// <summary>
        /// ボタンを指定して初期化します。
        /// </summary>
        /// <param name="button"></param>
        public GamePadSingleButtonData(GamePadButtons button)
        {
            Button = button;
        }

        public GamePadButtons Button { get; }

        public string ButtonString => Button.ToString();

        public IGamePadButtonSetting ButtonSetting
        {
            get
            {
                //テスト用設定読み込み
                var currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                var buttonImage_1 = new BitmapImage(new Uri(
                   System.IO.Path.Combine(currentDir, @"Settings\Pic\A_Press.png")
                   ));

                    return new GamePadButtonSetting(
                        GamePadButtons.PAD_BUTTON_0,
                        buttonImage_1,
                        new System.Windows.Vector(0,32)
                    );
            }
        }
    }
}
