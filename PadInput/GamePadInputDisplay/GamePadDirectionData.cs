using PadInput.GamePadInput;
using System;
using System.Collections.Generic;
using System.Text;
using PadInput.GamePadInputDisplay.Interface;
using PadInput.GamePadSettings.Interface;
using PadInput.GamePadSettings;
using System.Windows.Media.Imaging;

namespace PadInput.GamePadInputDisplay
{

    /// <summary>
    /// ゲームパッドの方向キー入力データを表します。
    /// </summary>
    class GamePadDirectionData : IGamePadDirectionData
    {

        /// <summary>
        /// 入力方向を指定して初期化します。
        /// </summary>
        /// <param name="gamePadPOVDirection"></param>
        public GamePadDirectionData(GamePadPOVDirection gamePadPOVDirection)
        {
            Direction = gamePadPOVDirection;
        }

        public GamePadPOVDirection Direction { get; }

        public IGamePadDirectionSetting DirectionSetting
        {
            get
            {
                //テスト用設定読み込み
                var currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);


                var directionImage_Up = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\Direction_Up.png")
                )
                );
                return
                    new GamePadDirectionSetting(
                        GamePadPOVDirection.Up,
                        directionImage_Up
                    );
            }
        }
    }
}
