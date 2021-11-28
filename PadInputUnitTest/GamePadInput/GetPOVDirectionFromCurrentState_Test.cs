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
using PadInput.GamePadInputDisplay;

namespace PadInputUnitTest.GamePadInput
{
    public class GetPOVDirectionFromCurrentState_Test : TestBase
    {

        private const string traitBase = "パッド入力クラス";

        private readonly GamepadInput gamepadInput;
        private readonly GamePadSettingsModel settings;

        public GetPOVDirectionFromCurrentState_Test(ITestOutputHelper output) : base(output)
        {
            var xmlFilePath = "./Settings/PadInputSettings.xml";
            settings = new GamePadSettingsModel(xmlFilePath);

            gamepadInput = new GamepadInput(settings);

        }

        private void Inner_Assert_Method(JOYINFOEX input,GamePadPOVDirection expectedDirection)
        {
            gamepadInput.joyInfo = input;

            //実データの取得
            IGamePadDirectionData actual = gamepadInput.GetPOVDirectionFromCurrentState();

            IGamePadDirectionData expected = new GamePadDirectionData(expectedDirection, settings);

            //アサート
            Assert.Equal(expected, actual);

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

            Inner_Assert_Method(input, GamePadPOVDirection.Neutral);

        }

        [Fact(DisplayName = "方向キー上")]
        [Trait(traitBase, "方向キー入力テスト")]
        public void GetPOVDirectionFromCurrentState_Test_2()
        {


            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwXpos = POVInputValues.POV_NEUTRAL_VALUE,
                dwYpos = POVInputValues.POV_ZERO_VALUE
            };

            Inner_Assert_Method(input, GamePadPOVDirection.Up);


        }

        [Fact(DisplayName = "方向キー左上")]
        [Trait(traitBase, "方向キー入力テスト")]
        public void GetPOVDirectionFromCurrentState_Test_3()
        {


            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwXpos = POVInputValues.POV_ZERO_VALUE,
                dwYpos = POVInputValues.POV_ZERO_VALUE
            };

            Inner_Assert_Method(input, GamePadPOVDirection.UpLeft);

        }

        [Fact(DisplayName = "方向キー右上")]
        [Trait(traitBase, "方向キー入力テスト")]
        public void GetPOVDirectionFromCurrentState_Test_4()
        {


            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwXpos = POVInputValues.POV_MAX_VALUE,
                dwYpos = POVInputValues.POV_ZERO_VALUE
            };

            Inner_Assert_Method(input, GamePadPOVDirection.UpRight);
        }

        [Fact(DisplayName = "方向キー下")]
        [Trait(traitBase, "方向キー入力テスト")]
        public void GetPOVDirectionFromCurrentState_Test_5()
        {


            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwXpos = POVInputValues.POV_NEUTRAL_VALUE,
                dwYpos = POVInputValues.POV_MAX_VALUE
            };

            Inner_Assert_Method(input, GamePadPOVDirection.Down);


        }

        [Fact(DisplayName = "方向キー左下")]
        [Trait(traitBase, "方向キー入力テスト")]
        public void GetPOVDirectionFromCurrentState_Test_6()
        {


            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwXpos = POVInputValues.POV_ZERO_VALUE,
                dwYpos = POVInputValues.POV_MAX_VALUE
            };

            Inner_Assert_Method(input, GamePadPOVDirection.DownLeft);

        }

        [Fact(DisplayName = "方向キー右下")]
        [Trait(traitBase, "方向キー入力テスト")]
        public void GetPOVDirectionFromCurrentState_Test_7()
        {


            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwXpos = POVInputValues.POV_MAX_VALUE,
                dwYpos = POVInputValues.POV_MAX_VALUE
            };

            Inner_Assert_Method(input, GamePadPOVDirection.DownRight);


        }

        [Fact(DisplayName = "方向キー右")]
        [Trait(traitBase, "方向キー入力テスト")]
        public void GetPOVDirectionFromCurrentState_Test_8()
        {


            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwXpos = POVInputValues.POV_MAX_VALUE,
                dwYpos = POVInputValues.POV_NEUTRAL_VALUE
            };

            Inner_Assert_Method(input, GamePadPOVDirection.Right);


        }

        [Fact(DisplayName = "方向キー左")]
        [Trait(traitBase, "方向キー入力テスト")]
        public void GetPOVDirectionFromCurrentState_Test_9()
        {


            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwXpos = POVInputValues.POV_ZERO_VALUE,
                dwYpos = POVInputValues.POV_NEUTRAL_VALUE
            };

            Inner_Assert_Method(input, GamePadPOVDirection.Left);


        }


    }
}
