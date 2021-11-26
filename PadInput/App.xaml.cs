using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PadInput
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        /// <summary>
        /// Start_Up時に呼び出されるイベントハンドラ。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //アプリ開始時の処理を記載

            //WPFのUIスレッド以外で発生した例外対応
            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                var ex = e.Exception;
                HandleException(ex);

            };

            //最後まで処理されない例外で発生するイベント
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                HandleException(ex);

            };


        }

        /// <summary>
        /// WPFのUIスレッド上で発生した未処理の例外をキャッチしたときに呼び出されるイベントハンドラ。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Exception ex = e.Exception;

            HandleException(ex);

        }

        /// <summary>
        /// 未処理例外を処理し、アプリを終了します。
        /// </summary>
        /// <param name="ex"></param>
        private void HandleException(Exception ex)
        {

            //ログ出力
            try
            {
                
            }catch(Exception e)
            {
                //ログ出力例外はあきらめる
            }


            MessageBox.Show("エラーが発生したため、処理を継続できません。");

            Environment.Exit(-1);

        }

    }
}
