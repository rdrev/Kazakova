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

namespace Казакова
{
    /// <summary>
    /// Логика взаимодействия для AuthorizPage.xaml
    /// </summary>
    public partial class AuthorizPage : Page
    {
        public AuthorizPage()
        {
            InitializeComponent();
        } 

        private void VxodBtn_Click(object sender, RoutedEventArgs e)
        {
            var vxodC = КазаковаEntities.Get().Сотрудники.ToList().Find(p => p.Логин == login.Text && p.Пароль == Convert.ToString(password.Password));
            //проверка успеха поиска
            if (vxodC != null)
                MenegerFrame.Frame.Navigate(new MainPage(vxodC));//откртие главной формы 
            else
            {
                var vxodK = КазаковаEntities.Get().Клиенты.ToList().Find(p => p.Логин == login.Text && p.Пароль == Convert.ToString(password.Password));
                if (vxodK != null)
                    MenegerFrame.Frame.Navigate(new AddTaskPage(new Задание(), vxodK));
                else
                {
                    MessageBox.Show("не верный лошин или пароль", "упс");//вывод собщене об ощибки
                }
            }
        }
    }
}
