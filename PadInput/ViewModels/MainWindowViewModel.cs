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

            //テスト用モッククラス
            gamePadInput = new GamePadInput_Test();
            //gamePadInput = new GamepadInput();

            displayInfo = new List<IGamePadDisplayInfo>();


            //テスト用設定読み込み
            var currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ImageSource baseImage = new BitmapImage(new Uri(
                 System.IO.Path.Combine(currentDir, @"Settings\Pic\Base.png")
             ));
            IList<IGamePadButtonSetting> buttonSettings = new List<IGamePadButtonSetting>();
            IList<IGamePadDirectionSetting> directionSettings = new List<IGamePadDirectionSetting>();

            var buttonImage_1 = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\A_Press.png")
                )
            );
            buttonSettings.Add(
                new GamePadButtonSetting(
                    GamePadButtons.PAD_BUTTON_0,
                    buttonImage_1,
                    new System.Windows.Vector(0, 0)
                )
            );

            var directionImage_Up = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\Direction_Up.png")
                )
            );
            directionSettings.Add(
                new GamePadDirectionSetting(
                    GamePadPOVDirection.Up,
                    directionImage_Up
                )
            );

            settings = new GamePadSettingsModel(baseImage, buttonSettings, directionSettings);

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

        public ImageSource GamePadBaseImage
        {
            get
            {
                return settings.BaseImage;
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
                var copy = new List<IGamePadDisplayInfo>(displayInfo);

                var add = new GamePadDisplayInfo_Test(
                    gamePadInput.GetPushedButtonsFromCurrentState(),
                    gamePadInput.GetPOVDirectionFromCurrentState()
                );
                copy.Add(add);

                displayInfo = copy;

                //入力に変化がある場合は表示内容を更新
                //copy.Insert(0, gamePadInput.GetInputInfo());
                //InputHistoryStrList = copy;
            }
            else
            {
                var first = displayInfo.LastOrDefault();
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
