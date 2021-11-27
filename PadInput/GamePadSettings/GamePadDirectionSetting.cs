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
    public class GamePadDirectionSetting : IGamePadDirectionSetting
    {

        /// <summary>
        /// 方向キーと、それに対応する画像データで初期化します。
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="directionImage"></param>
        public GamePadDirectionSetting(GamePadPOVDirection direction, ImageSource directionImage)
        {
            Direction = direction;
            DirectionImages = directionImage;

            if(DirectionImages.CanFreeze && DirectionImages.IsFrozen == false)
            {
                DirectionImages.Freeze();
            }
        }

        public GamePadDirectionSetting(GamePadPOVDirection direction,IGamePadSettingsModel settings)
        {
            this.GamePadDirect


            Direction = direction;
            DirectionImages = settings.GetGamePadDirectionSetting(direction).DirectionImages;
        }

        public GamePadPOVDirection Direction { get; }

        public ImageSource DirectionImages { get; }


        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            if(obj is GamePadDirectionSetting)
            {
                GamePadDirectionSetting other = (GamePadDirectionSetting)obj;

                return (this.Direction == other.Direction 
                    && this.DirectionImages.ToString() == other.DirectionImages.ToString());

            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
