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

namespace WPF_TEST
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // this.dataPanel.DataContext = new List<MyData>() {
            //     new MyData(){ Name="test1"},
            //     new MyData(){ Name="test2"},
            //     new MyData(){ Name="test3"},
            //     new MyData(){ Name="test4"},
            // };
            //this.listBoxData.ItemsSource = new List<MyData>() {
            //    new MyData(){ Name="test1"},
            //    new MyData(){ Name="test2"},
            //    new MyData(){ Name="test3"},
            //    new MyData(){ Name="test4"},
            //};
            //this.listBoxData.DisplayMemberPath = "Name";
        }

        private void CommonClickHandler(object sender, RoutedEventArgs e)
        {
            FrameworkElement feSource = e.Source as FrameworkElement;
            this.result.Value = "you click " + feSource.Name;
            switch (feSource.Name)
            {
                case "YesButton":
                    // do something here ...
                    break;
                case "NoButton":
                    // do something ...
                    break;
                case "CancelButton":
                    // do something ...
                    break;
            }
            e.Handled = true;
        }

        private void NavContent_MyButtonClick(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.result.Value = "you click Nav";
        }
    }
}
