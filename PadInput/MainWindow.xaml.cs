using PadInput.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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

            //loopTimer = new DispatcherTimer();
            //loopTimer.Interval = new TimeSpan(0, 0, 0, 0, (int)(1000d / frameCount));
            //loopTimer.Tick += Timer_loop;
            //loopTimer.Start();

            loopTimer = new System.Timers.Timer(1000d / frameCount);
            loopTimer.Elapsed += (s, e) => Timer_loop(s, e);
            loopTimer.Start();

            //CompositionTarget.Rendering += (_1, _2) => Timer_loop(_1,_2);

            // ウィンドウをマウスのドラッグで移動できるようにする
            this.MouseLeftButtonDown += (sender, e) => { this.DragMove(); };

            //ViewModelのインスタンスを生成し、DataContextに代入
            if (_vm == null)
            {
                _vm = new MainWindowViewModel();
                DataContext = _vm;
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
