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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(Сотрудники сотрудник)
        {
            InitializeComponent();

            if(сотрудник.Доступ == false)
            {
                AddEmployeesBtn.Visibility = Visibility.Hidden;
                AddKlintBtn.Visibility = Visibility.Hidden;
                BonBtn.Visibility = Visibility.Hidden;
            }
        }

        private void AddTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddTaskPage(new Задание(), null));
        }

        private void PodTaskUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new BeneathTaskPage((sender as Button).DataContext as Задание));
        }

        private void AddEmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new EmpLookPage());
        }

        private void UpTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddTaskPage((sender as Button).DataContext as Задание, null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            updata();
        }

        private void EmpBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new EmpPage((sender as Button).DataContext as Задание));
        }

        private void DelTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы дельствительно хотете удалить это", "Подверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    foreach (var zc in КазаковаEntities.Get().ЗадачиСотрудники.ToList().Where(p => p.ПодЗадание1.Задача == ((sender as Button).DataContext as Задание).КодЗадание).ToList())
                    {
                        КазаковаEntities.Get().ЗадачиСотрудники.Remove(zc);
                    }
                    КазаковаEntities.Get().SaveChanges();

                    foreach (var zc in КазаковаEntities.Get().ПодЗадание.ToList().Where(p => p.Задача == ((sender as Button).DataContext as Задание).КодЗадание).ToList())
                    {
                        КазаковаEntities.Get().ПодЗадание.Remove(zc);
                    }
                    КазаковаEntities.Get().SaveChanges();

                    КазаковаEntities.Get().Задание.Remove((sender as Button).DataContext as Задание);
                    КазаковаEntities.Get().SaveChanges();

                    updata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updata()
        {
            if (CB.IsChecked == true)
            {
                DG.ItemsSource = КазаковаEntities.Get().Задание.ToList().Where(p => p.СтатусЗадания == true && p.НазваниеЗадачи.ToLower().Contains(TBN.Text.ToLower())).ToList();
            }
            else
            {
                DG.ItemsSource = КазаковаEntities.Get().Задание.ToList().Where(p => p.НазваниеЗадачи.ToLower().Contains(TBN.Text.ToLower())).ToList(); 
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            updata();
        }

        private void TBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            updata();
        }

        private void AddKlintBtn_Click(object sender, RoutedEventArgs e)
        {

            MenegerFrame.Frame.Navigate(new KlientLookPage());
        }

        private void BonuzBtn_Click(object sender, RoutedEventArgs e)
        {
            var win = new BonusWindow((sender as Button).DataContext as Задание);
            win.Show();
        }
    }
}
