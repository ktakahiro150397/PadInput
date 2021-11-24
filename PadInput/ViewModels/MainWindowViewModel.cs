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

            InputHistoryStrList.Add("test");
            InputHistoryStrList.Add("test2");
            InputHistoryStrList.Add("test3");
        }

        private uint frameCounter;
        private string structureInputInfoCurrentFrame;
        private string structureInputInfoPreviousFrame;
        private string inputHistory;
        private List<string> inputHistoryList;
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

        public List<string> InputHistoryStrList
        {
            get
            {
                if (inputHistoryList == null)
                {
                    inputHistoryList = new List<string>();
                }
                return inputHistoryList;
            }
            set
            {
                inputHistoryList = value;
                OnPropertyChanged(nameof(InputHistoryStrList));
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
            //InputHistoryStr = gamePadInput.GetInputInfo() + InputHistoryStr


            var copy = new List<string>(InputHistoryStrList);

            if (gamePadInput.IsInputChangeFromPreviousFrame)
            {
                //入力に変化がある場合は表示内容を更新
                copy.Insert(0, gamePadInput.GetInputInfo());
                InputHistoryStrList = copy;
            }
            //copy.Add(gamePadInput.GetInputInfo());
            //OnPropertyChanged(nameof(InputHistoryStrList));

        }

        #endregion


    }
}
