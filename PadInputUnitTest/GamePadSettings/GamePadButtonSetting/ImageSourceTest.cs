using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xunit;
using Xunit.Abstractions;

namespace PadInputUnitTest.GamePadSettings.GamePadButtonSetting
{
    public class ImageSourceTest : TestBase
    {
        public ImageSourceTest(ITestOutputHelper output) : base(output)
        {
        }


        [Fact]
        public void Equality_Test_1()
        {

            //テスト用設定読み込み
            var currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ImageSource left = new BitmapImage(new Uri(
                 System.IO.Path.Combine(currentDir, @"Settings\Pic\Base.png")
             ));

            ImageSource right = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\Base.png")
            ));

            //ToStringでソース画像パスが一致していることを確認する
            Assert.Equal(left.ToString(),right.ToString());

        }

        [Fact]
        public void Equality_Test_2()
        {

            //テスト用設定読み込み
            var currentDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ImageSource left = new BitmapImage(new Uri(
                 System.IO.Path.Combine(currentDir, @"Settings\Pic\Base.png")
             ));

            ImageSource right = new BitmapImage(new Uri(
                System.IO.Path.Combine(currentDir, @"Settings\Pic\D_Press.png")
            ));

            //ToStringでソース画像パスが一致していることを確認する
            Assert.NotEqual(left.ToString(), right.ToString());

        }

    }
}
