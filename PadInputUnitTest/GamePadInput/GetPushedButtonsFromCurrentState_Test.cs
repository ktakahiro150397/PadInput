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

namespace PadInputUnitTest
{

    public class GetPushedButtonsFromCurrentState_Test : TestBase
    {
        private const string traitBase = "パッド入力クラス";

        private readonly GamepadInput gamepadInput;
        private readonly GamePadSettingsModel settings;

        public GetPushedButtonsFromCurrentState_Test(ITestOutputHelper output) : base(output)
        {
            settings = new GamePadSettingsModel();

            gamepadInput = new GamepadInput(settings);
        }

        [Fact(DisplayName = "ボタン未入力")]
        [Trait(traitBase, "ボタン入力テスト")]
        public void GetPushedButtonsFromCurrentState_Test_1()
        {
            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 0,
                dwButtons = 0,

            };

            //実関数で取得
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //回答
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();

            Assert.Equal(answer, actual);

        }

        [Fact(DisplayName = "BUTTON_1入力")]
        [Trait(traitBase, "ボタン入力テスト")]
        public void GetPushedButtonsFromCurrentState_Test_2()
        {

            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 1,
                dwButtons = 1,

            };

            //実関数で取得
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //回答
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_0, settings));

            Assert.Equal(answer, actual);

        }

        [Fact(DisplayName = "BUTTON_1,2入力")]
        [Trait(traitBase, "ボタン入力テスト")]
        public void GetPushedButtonsFromCurrentState_Test_3()
        {

            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 2,
                dwButtons = 3,

            };

            //実関数で取得
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //回答
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_0, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_1, settings));

            Assert.Equal(answer, actual);


        }

        [Fact(DisplayName = "BUTTON_,1,2,3入力")]
        [Trait(traitBase, "ボタン入力テスト")]
        public void GetPushedButtonsFromCurrentState_Test_4()
        {

            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 3,
                dwButtons = 7,

            };

            //実関数で取得
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //回答
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_0, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_1, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_2, settings));

            Assert.Equal(answer, actual);


        }

        [Fact(DisplayName = "BUTTON_1,2,3,4入力")]
        [Trait(traitBase, "ボタン入力テスト")]
        public void GetPushedButtonsFromCurrentState_Test_5()
        {

            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 4,
                dwButtons = 15,

            };

            //実関数で取得
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //回答
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_0, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_1, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_2, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_3, settings));

            Assert.Equal(answer, actual);

        }

        [Fact(DisplayName = "BUTTON_1,2,3,4,5入力")]
        [Trait(traitBase, "ボタン入力テスト")]
        public void GetPushedButtonsFromCurrentState_Test_6()
        {

            //インプット構造体
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 4,
                dwButtons = 31,

            };

            //実関数で取得
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //回答
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_0, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_1, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_2, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_3, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_4, settings));

            Assert.Equal(answer, actual);

        }

    }
}
