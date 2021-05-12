using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_TEST.UC
{
    /// <summary>
    /// U_Btn.xaml 的交互逻辑
    /// </summary>
    public partial class U_Btn : UserControl
    {
        public U_Btn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public static readonly DependencyProperty UNameProperty =
                   DependencyProperty.Register("UName", typeof(string),
                   typeof(U_Btn),
                   new PropertyMetadata("TextBlock", new PropertyChangedCallback(OnUNameChanged)));
        public string UName
        {
            get { return (string)GetValue(UNameProperty); }

            set { SetValue(UNameProperty, value); }
        }

        static void OnUNameChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            U_Btn source = (U_Btn)sender;
            source.UserName.Text = (string)args.NewValue;
        }

        /// <summary>
        /// 编号
        /// </summary>
        public static readonly DependencyProperty UNumberProperty =
                   DependencyProperty.Register(" UNumber", typeof(string),
                   typeof(U_Btn),
                   new PropertyMetadata("TextBlock", new PropertyChangedCallback(OnUNumberChanged)));
        public string UNumber
        {
            get { return (string)GetValue(UNumberProperty); }

            set { SetValue(UNumberProperty, value); }
        }

        static void OnUNumberChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            U_Btn source = (U_Btn)sender;
            source.UserNumber.Text = (string)args.NewValue;
        }

        /// <summary>
        /// 鼠标悬浮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void on_MouseEnter(object sender, MouseEventArgs e)
        {
            this.off.Visibility = Visibility.Visible;
            this.offText.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void on_MouseLeave(object sender, MouseEventArgs e)
        {
            this.off.Visibility = Visibility.Hidden;
            this.offText.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// 点击下机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void off_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UserOff();
        }

        private void offText_MouseUp(object sender, MouseButtonEventArgs e)
        {
            UserOff();
        }

        /// <summary>
        /// 用户下机
        /// </summary>
        private void UserOff()
        {
            if (MessageBox.Show("确认下机用户" + this.UserName.Text + "?", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MainWindow mf = (MainWindow)Application.Current.MainWindow;
                mf.OffUser(this.UserName.Text);
            }
        }
    }
}
