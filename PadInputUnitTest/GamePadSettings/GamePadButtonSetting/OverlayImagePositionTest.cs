using System;
using Xunit;
using PadInput.GamePadInput;
using PadInput.Win32Api;
using Xunit.Abstractions;
using PadInput.GamePadInputDisplay.Interface;
using PadInput.GamePadInputDisplay;
using System.Collections.Generic;
using PadInput.GamePadSettings.Interface;
using PadInput.GamePadSettings;
using System.Windows;

namespace PadInputUnitTest.GamePadSettings.GamePadButtonSetting
{
    public class OverlayImagePositionTest : TestBase
    {

        public OverlayImagePositionTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact()]
        public void Equality_Test_1()
        {

            Vector left = new Vector(1, 1);

            Vector right = new Vector(1, 1);

            Assert.Equal(left, right);

        }

        [Fact()]
        public void Equality_Test_2()
        {

            Vector left = new Vector(1, 1);

            Vector right = new Vector(1, 2);

            Assert.NotEqual(left, right);

        }

    }
}
