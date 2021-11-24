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

        public GamePadDisplayInfo_Test()
        {
            elapsedFrameCount = 0;
            gamePadSingleButtonDatas = new List<IGamePadSingleButtonData>();
            gamePadDirectionData = 
        }

        private int elapsedFrameCount;
        private IList<IGamePadSingleButtonData> gamePadSingleButtonDatas;
        private IGamePadDirectionData gamePadDirectionData;

        public int ElapsedFrameCount => throw new NotImplementedException();

        public IList<IGamePadSingleButtonData> PressedButtonList => throw new NotImplementedException();

        public IGamePadDirectionData Direction => throw new NotImplementedException();

    }
}
