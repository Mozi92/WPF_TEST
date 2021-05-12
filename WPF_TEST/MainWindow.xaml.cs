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
using ViewModel.UserViewModel;
using WPF_TEST.UC;

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

        }

        private List<UserInfo> users { get; set; }
        /// <summary>
        /// 个体上机
        /// </summary>
        /// <param name="userInfo"></param>
        void UpUser(UserInfo userInfo)
        {
            U_Btn u = new U_Btn
            {
                UName = userInfo.UserName,
                UNumber = userInfo.UserNumber
            };
            this.OnlineUser.Children.Add(u);
        }

        /// <summary>
        /// 集体上机
        /// </summary>
        /// <param name="users"></param>
        void UpAllUser(List<UserInfo> users)
        {
            users.Select(x => new U_Btn() { UName = x.UserName, UNumber = x.UserNumber }).ToList().ForEach(x =>
          {
              this.OnlineUser.Children.Add(x);
          });
        }

        /// <summary>
        /// 个体下机
        /// </summary>
        /// <param name="userName"></param>
        public void OffUser(string userName)
        {
            var index = users.FindIndex(x => x.UserName.Equals(userName));
            if (index != -1)
            {
                this.users.RemoveAt(index);
                this.OnlineUser.Children.RemoveAt(index);
            }
        }

        /// <summary>
        /// 集体下机
        /// </summary>
        void OffAllUser()
        {
            if (MessageBox.Show("确认下机所有用户?", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                this.OnlineUser.Children.Clear();
            }
        }

        /// <summary>
        /// 打开内页窗体
        /// </summary>
        public void GoForm(string formName)
        {
            MessageBox.Show("打开" + formName);
            switch (formName)
            {
                case "222":
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            users = CreateUser();
            UpAllUser(users);
        }

        /// <summary>
        /// 构建mock数据
        /// </summary>
        /// <returns></returns>
        List<UserInfo> CreateUser()
        {
            return new List<UserInfo>()
            {
                new UserInfo(){ UserName="张三",UserNumber="10009231221"},
                new UserInfo(){ UserName="刘邦",UserNumber="10009231025"},
                new UserInfo(){ UserName="张作霖",UserNumber="10009232321"},
                new UserInfo(){ UserName="张学良",UserNumber="10009231001"},
                new UserInfo(){ UserName="李大钊",UserNumber="10009231421"},
            };
        }
    }
}
