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
    public class GamePadDirectionData : IGamePadDirectionData
    {

        /// <summary>
        /// 入力方向を指定して初期化します。
        /// </summary>
        /// <param name="gamePadPOVDirection"></param>
        [Obsolete("設定モデルを使用して初期化する")]
        public GamePadDirectionData(GamePadPOVDirection gamePadPOVDirection)
        {
            Direction = gamePadPOVDirection;

            //テスト用設定読み込み
            var currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);


            var directionImage_Up = new BitmapImage(new Uri(
            System.IO.Path.Combine(currentDir, @"Settings\Pic\Direction_Up.png")
            )
            );
            DirectionSetting = new GamePadDirectionSetting(
                    GamePadPOVDirection.Up,
                    directionImage_Up
                );
        }

        public GamePadDirectionData(GamePadPOVDirection gamePadPOVDirection,IGamePadSettingsModel settings)
        {
            Direction = gamePadPOVDirection;

            DirectionSetting = settings.GetGamePadDirectionSetting(gamePadPOVDirection);
        }


        public GamePadPOVDirection Direction { get; }

        public IGamePadDirectionSetting DirectionSetting { get; }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is GamePadDirectionData)
            {

                var other = (GamePadDirectionData)obj;

                return (Direction == other.Direction) && DirectionSetting.Equals(other.DirectionSetting);
            }

            return false;

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Direction.GetHashCode(), DirectionSetting.GetHashCode());
        }


    }
}
