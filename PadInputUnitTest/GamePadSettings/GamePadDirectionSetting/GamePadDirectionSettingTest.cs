using System;
using Xunit;
using PadInput.GamePadInput;
using PadInput.Win32Api;
using Xunit.Abstractions;
using PadInput.GamePadSettings;
using System.Windows.Media.Imaging;

namespace PadInputUnitTest.GamePadSettings.GamePadDirectionSetting
{
    public class GamePadDirectionSettingTest : TestBase
    {
        public GamePadDirectionSettingTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Equality_Test_1()
        {

            //テスト用設定読み込み
            var currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            var directionImage_Up = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\Direction_Up.png")
                )
            );

            var left = new PadInput.GamePadSettings.GamePadDirectionSetting(
                    GamePadPOVDirection.Up,
                    directionImage_Up
            );

            var right = new PadInput.GamePadSettings.GamePadDirectionSetting(
                    GamePadPOVDirection.Up,
                    directionImage_Up
            );

            Assert.Equal(left, right);

        }

        [Fact]
        public void Equality_Test_2()
        {

            //テスト用設定読み込み
            var currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            var directionImage_Up = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\Direction_Up.png")
                )
            );
            var directionImage_Down = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\Direction_Down.png")
                )
            );

            var left = new PadInput.GamePadSettings.GamePadDirectionSetting(
                    GamePadPOVDirection.Up,
                    directionImage_Up
            );

            var right = new PadInput.GamePadSettings.GamePadDirectionSetting(
                    GamePadPOVDirection.Up,
                    directionImage_Down
            );

            Assert.NotEqual(left, right);

        }


    }
}
