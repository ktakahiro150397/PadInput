using PadInput.GamePadInput;
using PadInput.GamePadInputDisplay;
using PadInput.GamePadInputDisplay.Interface;
using PadInput.GamePadSettings;
using PadInput.GamePadSettings.Interface;
using PadInput.Win32Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PadInput.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {

        public MainWindowViewModel()
        {

            var xmlFilePath = "./Settings/PadInputSettings.xml";
            settings = new GamePadSettingsModel(xmlFilePath);

            //テスト用モッククラス
            //gamePadInput = new GamePadInput_Test();
            gamePadInput = new GamepadInput(settings);

            displayInfo = new List<IGamePadDisplayInfo>();


        }

        private uint frameCounter;
        private string structureInputInfoCurrentFrame;
        private string structureInputInfoPreviousFrame;
        private string inputHistory;
        private List<string> inputHistoryList;
        private IGamePadInput gamePadInput;
        private IGamePadSettingsModel settings;
        private IList<IGamePadDisplayInfo> displayInfo;

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

        /// <summary>
        /// ボタン入力のベース画像。
        /// </summary>
        public ImageSource GamePadBaseImage
        {
            get
            {
                return settings.BaseImage;
            }
        }
        public IGamePadInputDisplaySettings DisplaySettings
        {
            get
            {
                return settings.DisplaySettings;
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

        public IList<IGamePadDisplayInfo> GamePadDisplayInfos
        {
            get
            {
                return displayInfo;
            }
            set
            {
                displayInfo = value;
                OnPropertyChanged(nameof(GamePadDisplayInfos));
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


            if (gamePadInput.IsInputChangeFromPreviousFrame)
            {
                //前フレームと入力が異なる場合に表示
                var copy = new List<IGamePadDisplayInfo>(displayInfo).Take(settings.DisplaySettings.MaxDisplayCount).ToList();

                var add = new GamePadDisplayInfo(
                    gamePadInput.GetPushedButtonsFromCurrentState(),
                    gamePadInput.GetPOVDirectionFromCurrentState()
                );
                copy.Insert(0, add);
                displayInfo = copy;
            }
            else
            {
                var first = displayInfo.FirstOrDefault();
                if (first != null)
                {
                    first.IncrementFrameCount();
                    OnPropertyChanged(nameof(GamePadDisplayInfos));
                }


            }

        }

        #endregion


    }
}
