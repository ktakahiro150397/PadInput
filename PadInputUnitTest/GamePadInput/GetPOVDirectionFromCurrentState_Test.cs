using System;
using Xunit;
using PadInput.GamePadInput;
using PadInput.Win32Api;
using Xunit.Abstractions;
using PadInput.GamePadInputDisplay.Interface;
using PadInput.GamePadInputDisplay;
using System.Collections.Generic;
using PadInput.GamePadSettings.Interface;
using PadInput.GamePadSettings;

namespace PadInputUnitTest.GamePadInput
{
    public class GetPOVDirectionFromCurrentState_Test : TestBase
    {

        private const string traitBase = "パッド入力クラス";

        private readonly GamepadInput gamepadInput;
        private readonly GamePadSettingsModel settings;

        public GetPOVDirectionFromCurrentState_Test(ITestOutputHelper output) : base(output)
        {

            settings = new GamePadSettingsModel();

            gamepadInput = new GamepadInput(settings);

        }

        [Fact(DisplayName = "方向キー未入力")]
        [Trait(traitBase,"方向キー入力テスト")]
        public void GetPOVDirectionFromCurrentState_Test_1()
        {


            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwXpos = POVInputValues.POV_NEUTRAL_VALUE,
                dwYpos = POVInputValues.POV_NEUTRAL_VALUE
            };
            gamepadInput.joyInfo = input;

            //実データの取得
            var actual = gamepadInput.GetPOVDirectionFromCurrentState();

            IGamePadDirectionData answer = new GamePadDirectionSetting(GamePadPOVDirection.Neutral, settings);



        }


    }
}
