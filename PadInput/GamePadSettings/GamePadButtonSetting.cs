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
    class GamePadButtonSetting : IGamePadButtonSetting
    {

        /// <summary>
        /// ボタン設定を、対応する画像とその座標を使用して初期化します。
        /// </summary>
        /// <param name="button"></param>
        /// <param name="overlayImage"></param>
        /// <param name="overlayImagePos"></param>
        public GamePadButtonSetting(GamePadButtons button,ImageSource overlayImage,Vector overlayImagePos)
        {
            Button = button;
            OverlayImage = overlayImage;
            OverlayImagePosition = overlayImagePos;
        }

        public GamePadButtons Button { get; }

        public ImageSource OverlayImage { get; }

        public Vector OverlayImagePosition { get; }
    }
}
