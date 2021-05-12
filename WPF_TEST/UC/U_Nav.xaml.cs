using System;
using System.Collections.Generic;
using System.IO;
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
    /// U_Nav.xaml 的交互逻辑
    /// </summary>
    public partial class U_Nav : UserControl
    {
        public U_Nav()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 注册文本属性
        /// </summary>
        public static readonly DependencyProperty TextProperty =
                   DependencyProperty.Register("Text", typeof(string),
                   typeof(U_Nav),
                   new PropertyMetadata("TextBlock", new PropertyChangedCallback(OnTextChanged)));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }

            set { SetValue(TextProperty, value); }
        }

        static void OnTextChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            U_Nav source = (U_Nav)sender;
            source.tb.Text = (string)args.NewValue;
        }

        /// <summary>
        /// 注册图片路径属性
        /// </summary>
        public static readonly DependencyProperty SrcProperty = DependencyProperty.Register("Src", typeof(string), typeof(U_Nav), new PropertyMetadata("Image", new PropertyChangedCallback(OnSrcChanged)));
        public string Src
        {
            get { return (string)GetValue(SrcProperty); }
            set { SetValue(SrcProperty, value); }
        }

        static void OnSrcChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            U_Nav source = (U_Nav)sender;
            if (args.NewValue != null)
                source.icon.Source = GetSource((string)args.NewValue);
        }

        /// <summary>
        /// 注册背景属性
        /// </summary>
        public static readonly DependencyProperty BGProperty =
                   DependencyProperty.Register("BG", typeof(string),
                   typeof(U_Nav),
                   new PropertyMetadata("Grid", new PropertyChangedCallback(OnBGChanged)));
        public string BG
        {
            get { return (string)GetValue(BGProperty); }

            set { SetValue(BGProperty, value); }
        }

        static void OnBGChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            U_Nav source = (U_Nav)sender;
            source.Nav_Item.Background = (Brush)args.NewValue;
        }

        /// <summary>
        /// 获取图片数据
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        static BitmapImage GetSource(string uri)
        {
            string path = Directory.GetCurrentDirectory();
            FileInfo directory = new FileInfo(path);
            FileInfo directory2 = new FileInfo(directory.DirectoryName);
            string sss = directory2.DirectoryName + uri;
            return new BitmapImage(new Uri(sss, UriKind.Absolute));
        }

        /// <summary>
        /// 点击控件导航
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mf = (MainWindow)Application.Current.MainWindow;
            mf.GoForm(this.tb.Text);
        }
    }
}
