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
    /// Логика взаимодействия для BeneathTaskPage.xaml
    /// </summary>
    public partial class BeneathTaskPage : Page
    {
        private Задание задания = null;

        public BeneathTaskPage(Задание задания)
        {
            InitializeComponent();

            this.задания = задания;

        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }

        private void AddBeneathTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddBeneathTaskPage(new ПодЗадание(), задания));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            updata();
        }

        private void EmpBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new EmpPage((sender as Button).DataContext as ПодЗадание));
        }

        private void UpTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.Navigate(new AddBeneathTaskPage((sender as Button).DataContext as ПодЗадание, задания));
        }

        private void DelTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы дельствительно хотете удалить это", "Подверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    if (MessageBox.Show("Вы дельствительно хотете удалить это", "Подверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        foreach (var zc in КазаковаEntities.Get().ЗадачиСотрудники.ToList().Where(p => p.ПодЗадание == ((sender as Button).DataContext as ПодЗадание).КодПодзадание).ToList())
                        {
                            КазаковаEntities.Get().ЗадачиСотрудники.Remove(zc);
                        }

                        КазаковаEntities.Get().SaveChanges();

                        КазаковаEntities.Get().ПодЗадание.Remove((sender as Button).DataContext as ПодЗадание);

                        КазаковаEntities.Get().SaveChanges();
                        updata();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void updata()
        {
            
            DG.ItemsSource = КазаковаEntities.Get().ПодЗадание.ToList().Where(p => p.Задача == задания.КодЗадание).ToList();
        }
    }
}
