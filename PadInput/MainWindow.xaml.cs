using PadInput.ViewModels;
using System;
using System.Windows;

namespace PadInput
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel _vm = null;

        //DispatcherTimer loopTimer;
        System.Timers.Timer loopTimer;

        private const int frameCount = 60;

        public MainWindow()
        {
            InitializeComponent();

            loopTimer = new System.Timers.Timer(1000d / frameCount);
            loopTimer.Elapsed += (s, e) => Timer_loop(s, e);
            
            // ウィンドウをマウスのドラッグで移動できるようにする
            this.MouseLeftButtonDown += (sender, e) => { this.DragMove(); };

            //ViewModelのインスタンスを生成し、DataContextに代入
            if (_vm == null)
            {
                _vm = new MainWindowViewModel();
                DataContext = _vm;
                loopTimer.Start();
            }
        }



        /// <summary>
        /// フレーム単位で呼び出されるメソッド。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Timer_loop(object sender, EventArgs e)
        {

            _vm.Timer_loop();


        }


    }
}
