using System;
using Xunit;
using PadInput.GamePadInput;
using PadInput.Win32Api;

namespace PadInputUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var pad = new GamepadInput();



            var inputInfo = pad.GetPadInput(JoyStickIDs.JOYSTICKID1);




            Assert.False(1 == 1);


        }
    }
}
