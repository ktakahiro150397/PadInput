using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using PadInput.GamePadInput;
using PadInput.GamePadInputDisplay.Interface;
using PadInput.GamePadSettings;
using PadInput.GamePadSettings.Interface;
using System.Windows;

namespace PadInput.GamePadInputDisplay
{
    /// <summary>
    /// 単一のゲームパッドボタン入力データを表します。
    /// </summary>
    public class GamePadSingleButtonData : IGamePadSingleButtonData
    {

        /// <summary>
        /// ボタンを指定して初期化します。
        /// </summary>
        /// <param name="button"></param>
        public GamePadSingleButtonData(GamePadButtons button, IGamePadSettingsModel settings)
        {
            Button = button;

            var buttonSetting = settings.GetGamePadButtonSetting(Button);



            ButtonSetting = new GamePadButtonSetting(
                    Button,
                    buttonSetting == null ? null : buttonSetting.OverlayImage,
                    buttonSetting == null ? new Vector(0,0) : buttonSetting.OverlayImagePosition.Value
            );

        }

        public GamePadButtons Button { get; }

        public string ButtonString => Button.ToString();

        public IGamePadButtonSetting ButtonSetting { get; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is GamePadSingleButtonData)
            {
                var data = (GamePadSingleButtonData)obj;

                if (data.Button == Button && data.ButtonSetting.Equals(ButtonSetting))
                {
                    return true;
                }
            }

            return false;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Button, ButtonSetting);
        }



    }
}
