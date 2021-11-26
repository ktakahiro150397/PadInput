using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using PadInput.GamePadInput;
using PadInput.GamePadSettings.Interface;

namespace PadInput.GamePadSettings
{
    /// <summary>
    /// 方向キーの設定情報を表します。
    /// </summary>
    class GamePadDirectionSetting : IGamePadDirectionSetting
    {

        /// <summary>
        /// 方向キーと、それに対応する画像データで初期化します。
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="directionImage"></param>
        public GamePadDirectionSetting(GamePadPOVDirection direction,ImageSource directionImage)
        {
            Direction = direction;
            DirectionImages = directionImage;

            if(DirectionImages.CanFreeze && DirectionImages.IsFrozen == false)
            {
                DirectionImages.Freeze();
            }
        }

        public GamePadPOVDirection Direction { get; }

        public ImageSource DirectionImages { get; }
    }
}
