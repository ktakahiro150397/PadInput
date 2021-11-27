using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using PadInput.GamePadInput;
using PadInput.GamePadSettings.Interface;

namespace PadInput.GamePadSettings
{

    /// <summary>
    /// 単一のゲームパッド設定を表します。
    /// </summary>
    public class GamePadButtonSetting : IGamePadButtonSetting
    {

        /// <summary>
        /// ボタン設定を、対応する画像とその座標を使用して初期化します。
        /// </summary>
        /// <param name="button"></param>
        /// <param name="overlayImage"></param>
        /// <param name="overlayImagePos"></param>
        public GamePadButtonSetting(GamePadButtons button, ImageSource overlayImage, Vector overlayImagePos)
        {
            Button = button;
            OverlayImage = overlayImage;
            OverlayImagePosition = overlayImagePos;
        }

        public GamePadButtons Button { get; }

        public ImageSource OverlayImage { get; }

        public Vector? OverlayImagePosition { get; }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is GamePadButtonSetting)
            {
                GamePadButtonSetting other = (GamePadButtonSetting)obj;

                if (other.OverlayImage == null)
                {
                    if (OverlayImage == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

                if (other.Button == Button &&
                    other.OverlayImage.ToString() == OverlayImage.ToString() &&
                    other.OverlayImagePosition == OverlayImagePosition)
                {
                    return true;
                }

            }

            return false;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Button, OverlayImage, OverlayImagePosition);
        }

    }
}
