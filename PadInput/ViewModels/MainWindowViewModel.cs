using PadInput.GamePadInput;
using PadInput.Win32Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadInput.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {

        public MainWindowViewModel()
        {
            gamePadInput = new GamepadInput();
        }

        private uint frameCounter;
        private string structureInputInfoCurrentFrame;
        private string structureInputInfoPreviousFrame;
        private string inputHistory;
        private IGamePadInput gamePadInput;

        /// <summary>
        /// 経過したフレーム数の累計数。
        /// </summary>
        public uint FrameCounter
        {
            get
            {
                return frameCounter;
            }
            set
            {
                frameCounter = value;
                OnPropertyChanged(nameof(FrameCounterStr));
            }
        }

        #region "通知プロパティ"

        /// <summary>
        /// 経過したフレーム数の累計を表示します。
        /// </summary>
        public string FrameCounterStr
        {
            get
            {
                return "経過フレーム数 / " + frameCounter.ToString();
            }
        }

        /// <summary>
        /// 現在フレームの入力情報を表示します。
        /// </summary>
        public string StructureInputInfoStrCurrentFrame
        {
            get
            {
                return structureInputInfoCurrentFrame;
            }
            set
            {
                structureInputInfoCurrentFrame = value;
                OnPropertyChanged(nameof(StructureInputInfoStrCurrentFrame));
            }
        }

        /// <summary>
        /// 前フレームの入力情報を表示します。
        /// </summary>
        public string StructureInputInfoStrPreviousFrame
        {
            get
            {
                return structureInputInfoPreviousFrame;
            }
            set
            {
                structureInputInfoPreviousFrame = value;
                OnPropertyChanged(nameof(StructureInputInfoStrPreviousFrame));
            }
        }

        /// <summary>
        /// パッドの入力値を履歴形式で表示
        /// </summary>
        public string InputHistoryStr
        {
            get
            {
                return inputHistory;
            }
            set
            {
                inputHistory = value;
                OnPropertyChanged(nameof(InputHistoryStr));
            }
        }

        
        #endregion

        #region "1フレームごとに呼び出されるメソッド"

        /// <summary>
        /// 1フレームごとに呼び出されるメソッド。
        /// </summary>
        public void Timer_loop()
        {
            FrameCounter += 1;

            //パッドの入力を取得
            gamePadInput.GetPadInput(JoyStickIDs.JOYSTICKID1);

            //入力情報を表示(生の構造体)
            StructureInputInfoStrPreviousFrame = gamePadInput.GetStructureInfoPreviousFrame();
            StructureInputInfoStrCurrentFrame = gamePadInput.GetStructureInfoCurrentFrame();

            //入力情報を反映
            InputHistoryStr = gamePadInput.GetInputInfo() + InputHistoryStr;

        }

        #endregion


    }
}
