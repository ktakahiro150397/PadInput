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

namespace PadInputUnitTest.Settings.GamePadSettingsModel
{
    public class GamePadSettingsModel_XmlParse : TestBase
    {

        private const string traitBase = "XMLファイルパース";


        public GamePadSettingsModel_XmlParse(ITestOutputHelper output) : base(output)
        {




        }


        [Fact(DisplayName ="正常ファイル読み取り")]
        public void XmlParse_Test_1()
        {

            var xmlFilePath = "./Settings/PadInputSettings.xml";


            var settings = new PadInput.GamePadSettings.GamePadSettingsModel(xmlFilePath);

            Assert.NotNull(settings);


        }




    }
}
