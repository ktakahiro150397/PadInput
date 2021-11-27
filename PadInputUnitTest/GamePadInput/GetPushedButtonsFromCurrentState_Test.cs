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

    public class GetPushedButtonsFromCurrentState_Test : TestBase
    {
        private const string traitBase = "�p�b�h���̓N���X";

        private readonly GamepadInput gamepadInput;
        private readonly GamePadSettingsModel settings;

        public GetPushedButtonsFromCurrentState_Test(ITestOutputHelper output) : base(output)
        {
            settings = new GamePadSettingsModel();

            gamepadInput = new GamepadInput(settings);
        }

        [Fact(DisplayName = "�{�^��������")]
        [Trait(traitBase, "�{�^�����̓e�X�g")]
        public void GetPushedButtonsFromCurrentState_Test_1()
        {
            //�C���v�b�g�\����
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 0,
                dwButtons = 0,

            };

            //���֐��Ŏ擾
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //��
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();

            Assert.Equal(answer, actual);

        }

        [Fact(DisplayName = "BUTTON_1����")]
        [Trait(traitBase, "�{�^�����̓e�X�g")]
        public void GetPushedButtonsFromCurrentState_Test_2()
        {

            //�C���v�b�g�\����
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 1,
                dwButtons = 1,

            };

            //���֐��Ŏ擾
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //��
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_0, settings));

            Assert.Equal(answer, actual);

        }

        [Fact(DisplayName = "BUTTON_1,2����")]
        [Trait(traitBase, "�{�^�����̓e�X�g")]
        public void GetPushedButtonsFromCurrentState_Test_3()
        {

            //�C���v�b�g�\����
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 2,
                dwButtons = 3,

            };

            //���֐��Ŏ擾
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //��
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_0, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_1, settings));

            Assert.Equal(answer, actual);


        }

        [Fact(DisplayName = "BUTTON_,1,2,3����")]
        [Trait(traitBase, "�{�^�����̓e�X�g")]
        public void GetPushedButtonsFromCurrentState_Test_4()
        {

            //�C���v�b�g�\����
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 3,
                dwButtons = 7,

            };

            //���֐��Ŏ擾
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //��
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_0, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_1, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_2, settings));

            Assert.Equal(answer, actual);


        }

        [Fact(DisplayName = "BUTTON_1,2,3,4����")]
        [Trait(traitBase, "�{�^�����̓e�X�g")]
        public void GetPushedButtonsFromCurrentState_Test_5()
        {

            //�C���v�b�g�\����
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 4,
                dwButtons = 15,

            };

            //���֐��Ŏ擾
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //��
            IList<IGamePadSingleButtonData> answer = new List<IGamePadSingleButtonData>();
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_0, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_1, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_2, settings));
            answer.Add(new GamePadSingleButtonData(GamePadButtons.PAD_BUTTON_3, settings));

            Assert.Equal(answer, actual);

        }

        [Fact(DisplayName = "BUTTON_1,2,3,4,5����")]
        [Trait(traitBase, "�{�^�����̓e�X�g")]
        public void GetPushedButtonsFromCurrentState_Test_6()
        {

            //�C���v�b�g�\����
            JOYINFOEX input = new JOYINFOEX()
            {
                dwButtonNumber = 4,
                dwButtons = 31,

            };

            //���֐��Ŏ擾
            gamepadInput.joyInfo = input;
            var actual = gamepadInput.GetPushedButtonsFromCurrentState();

            //��
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
