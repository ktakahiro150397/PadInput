using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PadInput.GamePadInputDisplay.Interface;
using PadInput.Model;

namespace PadInput.GamePadInputDisplay
{

    /// <summary>
    /// 【表示テスト用】ゲームパッド入力情報を持つクラス。
    /// </summary>
    class GamePadDisplayInfo_Test : NotifyPropertyChangedModel,IGamePadDisplayInfo
    {
        /// <summary>
        /// 押されているパッドの情報から、入力情報を初期化します。
        /// </summary>
        /// <param name="PressedButtonList">入力されているボタンのリスト。</param>
        /// <param name="gamePadDirectionData">入力されている方向キー。</param>
        public GamePadDisplayInfo_Test(IList<IGamePadSingleButtonData> pressedButtonList, IGamePadDirectionData gamePadDirectionData)
        {
            elapsedFrameCount = 1;
            PressedButtonList = pressedButtonList;
            Direction = gamePadDirectionData;
        }

        private int elapsedFrameCount;
        
        public int ElapsedFrameCount
        {
            get
            {
                return elapsedFrameCount;
            }
        }

        public IList<IGamePadSingleButtonData> PressedButtonList { get; }

        public IGamePadDirectionData Direction {get;}

        public void IncrementFrameCount()
        {
            elapsedFrameCount++;
            OnPropertyChanged(nameof(ElapsedFrameCount));
        }


        

    }
}
