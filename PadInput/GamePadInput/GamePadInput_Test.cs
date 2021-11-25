using PadInput.GamePadInputDisplay;
using PadInput.GamePadInputDisplay.Interface;
using PadInput.Win32Api;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PadInput.GamePadInput
{
    class GamePadInput_Test : IGamePadInput
    {

        public GamePadInput_Test()
        {
            joyInfo = new JOYINFOEX();
            joyInfo.dwSize = Marshal.SizeOf(joyInfo);
            joyInfo.dwFlags = JoyReturnFlagValues.JOY_RETURNALL;

            joyInfo.dwXpos = POVInputValues.POV_NEUTRAL_VALUE;
            joyInfo.dwYpos = POVInputValues.POV_NEUTRAL_VALUE;

            joyInfo.dwButtons = 10;//2+8(ボタン1と3が押下状態)
        }

        private JOYINFOEX joyInfo;

        public bool IsInputChangeFromPreviousFrame
        {
            get
            {
                if (DateTime.Now.Second == 10 || DateTime.Now.Second == 40)
                {
                    if (DateTime.Now.Millisecond < 30)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
        }

    public string GetInputInfo()
    {
        return "GamePadInput_Test";
    }

    public JOYINFOEX GetPadInput(int uJoyId, int dwFlags = 255)
    {
        return joyInfo;
    }

    public string GetStructureInfoCurrentFrame()
    {
        return "GetStructureInfoCurrentFrame";
    }

    public string GetStructureInfoPreviousFrame()
    {
        return "GetStructureInfoPreviousFrame";
    }

    public IGamePadDirectionData GetPOVDirectionFromCurrentState()
    {

        if (joyInfo.dwXpos == POVInputValues.POV_NEUTRAL_VALUE
            && joyInfo.dwYpos == POVInputValues.POV_NEUTRAL_VALUE)
        {
            return new GamePadDirectionData(GamePadPOVDirection.Neutral);
        }

        //上方向入力の確認
        if (joyInfo.dwYpos == POVInputValues.POV_ZERO_VALUE)
        {
            if (joyInfo.dwXpos == POVInputValues.POV_NEUTRAL_VALUE)
            {
                return new GamePadDirectionData(GamePadPOVDirection.Up);

            }
            else if (joyInfo.dwXpos == POVInputValues.POV_ZERO_VALUE)
            {

                return new GamePadDirectionData(GamePadPOVDirection.UpLeft);

            }
            else if (joyInfo.dwXpos == POVInputValues.POV_MAX_VALUE)
            {
                return new GamePadDirectionData(GamePadPOVDirection.UpRight);
            }
        }

        //下方向入力の確認
        if (joyInfo.dwYpos == POVInputValues.POV_MAX_VALUE)
        {
            if (joyInfo.dwXpos == POVInputValues.POV_NEUTRAL_VALUE)
            {
                return new GamePadDirectionData(GamePadPOVDirection.Down);

            }
            else if (joyInfo.dwXpos == POVInputValues.POV_ZERO_VALUE)
            {

                return new GamePadDirectionData(GamePadPOVDirection.DownLeft);

            }
            else if (joyInfo.dwXpos == POVInputValues.POV_MAX_VALUE)
            {
                return new GamePadDirectionData(GamePadPOVDirection.DownRight);
            }
        }

        //左右入力の確認
        if (joyInfo.dwYpos == POVInputValues.POV_NEUTRAL_VALUE)
        {
            if (joyInfo.dwXpos == POVInputValues.POV_ZERO_VALUE)
            {
                return new GamePadDirectionData(GamePadPOVDirection.Left);
            }
            else if (joyInfo.dwXpos == POVInputValues.POV_MAX_VALUE)
            {
                return new GamePadDirectionData(GamePadPOVDirection.Right);
            }
        }

        //該当なしの場合例外
        throw new ApplicationException($"方向キー入力が検知できませんでした。" + Environment.NewLine +
            $"入力値 dwXpos : {joyInfo.dwXpos} / dwXpos : {joyInfo.dwYpos} ");

    }


    public IList<IGamePadSingleButtonData> GetPushedButtonsFromCurrentState()
    {
        var ret = new List<IGamePadSingleButtonData>();

        foreach (GamePadButtons button in Enum.GetValues(typeof(GamePadButtons)))
        {
            if (CheckIsButtonPushed(joyInfo.dwButtons, button))
            {
                //このボタンは押下されている
                ret.Add(new GamePadSingleButtonData(button));
                ;
            }
        }

        return ret;
    }

    /// <summary>
    /// 対象のボタンが押下されているかを確認し、その結果を返します。
    /// </summary>
    /// <param name="fieldValue"></param>
    /// <param name="button"></param>
    private bool CheckIsButtonPushed(int fieldValue, GamePadButtons button)
    {
        var checkValue = (GamePadButtons)fieldValue & button;

        return checkValue != 0;

    }


}
}
