using System;
using System.Collections.Generic;
using System.Text;

namespace PadInput.GamePadInputDisplay
{

    /// <summary>
    /// 【表示テスト用】ゲームパッド入力情報を持つクラス。
    /// </summary>
    class GamePadDisplayInfo_Test : IGamePadDisplayInfo
    {
        /// <summary>
        /// 押されているパッドの情報から、入力情報を初期化します。
        /// </summary>
        /// <param name="PressedButtonList">入力されているボタンのリスト。</param>
        /// <param name="gamePadDirectionData">入力されている方向キー。</param>
        public GamePadDisplayInfo_Test(IList<IGamePadSingleButtonData> pressedButtonList, IGamePadDirectionData gamePadDirectionData)
        {
            elapsedFrameCount = 1;
            gamePadSingleButtonDatas = pressedButtonList;
            gamePadDirectionData = gamePadDirectionData;
        }

        private int elapsedFrameCount;
        private IList<IGamePadSingleButtonData> gamePadSingleButtonDatas;
        private IGamePadDirectionData gamePadDirectionData;

        public int ElapsedFrameCount => throw new NotImplementedException();

        public IList<IGamePadSingleButtonData> PressedButtonList => throw new NotImplementedException();

        public IGamePadDirectionData Direction => throw new NotImplementedException();

        public void IncrementFrameCount()
        {
            elapsedFrameCount++;
        }
    }
}
