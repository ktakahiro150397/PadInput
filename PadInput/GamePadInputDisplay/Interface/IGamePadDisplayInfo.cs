﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Text;
using PadInput.GamePadSettings.Interface;

namespace PadInput.GamePadInputDisplay.Interface
{

    /// <summary>
    /// 画面に表示するキー入力情報のデータを表します。
    /// </summary>
    interface IGamePadDisplayInfo : IGamePadDisplayFrameInfo, IGamePadDisplayButtonsInfo
    {

        /// <summary>
        /// 現在フレームを1増やします。
        /// </summary>
        void IncrementFrameCount();


    }
}
