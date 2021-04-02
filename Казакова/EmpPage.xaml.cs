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
    /// Логика взаимодействия для EmpPage.xaml
    /// </summary>
    public partial class EmpPage : Page
    {
        private ПодЗадание подЗадачи = null;

        private Задание задания = null;

        public EmpPage(Задание задания)
        {
            InitializeComponent();

            this.задания = задания;

            CBE.ItemsSource = КазаковаEntities.Get().Сотрудники.ToList();

            CBE.Visibility = Visibility.Hidden;
            AddTaskEmpBtn.Visibility = Visibility.Hidden;
            DBtn.Visibility = Visibility.Hidden;

        }

        public EmpPage(ПодЗадание подЗадачи)
        {
            InitializeComponent();

            CBE.ItemsSource = КазаковаEntities.Get().Сотрудники.ToList();

            this.подЗадачи = подЗадачи;
        }

        private void GoBackBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            updata();
        }

        private void AddTaskEmpBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CZ = new ЗадачиСотрудники 
                {
                    ПодЗадание = подЗадачи.КодПодзадание,
                    Сотрудники = (CBE.SelectedItem as Сотрудники).КодСотрудники
                };

                КазаковаEntities.Get().ЗадачиСотрудники.Add(CZ);
                КазаковаEntities.Get().SaveChanges();
                updata();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updata()
        {
            if (задания != null)
            {
                List<Сотрудники> сотрудники = new List<Сотрудники>();
                List<ЗадачиСотрудники> подзадачи = new List<ЗадачиСотрудники>();

                foreach (var emp in КазаковаEntities.Get().ЗадачиСотрудники.ToList().Where(p => p.ПодЗадание1.Задача == задания.КодЗадание).ToList())
                {
                    сотрудники.Add(emp.Сотрудники1);
                }


                DG.ItemsSource = сотрудники.Distinct().ToList();
            }
            else
            {
                List<Сотрудники> сотрудники = new List<Сотрудники>();
                foreach (var emp in КазаковаEntities.Get().ЗадачиСотрудники.ToList().Where(p => p.ПодЗадание == подЗадачи.КодПодзадание).ToList())
                {
                    сотрудники.Add(emp.Сотрудники1);
                }
                DG.ItemsSource = сотрудники.Distinct().ToList();
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы дельствительно хотете удалить это", "Подверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var zc in КазаковаEntities.Get().ЗадачиСотрудники.ToList().Where(p => p.ПодЗадание == подЗадачи.КодПодзадание && p.Сотрудники == ((sender as Button).DataContext as Сотрудники).КодСотрудники))
                {
                    КазаковаEntities.Get().ЗадачиСотрудники.Remove(zc);
                }

                КазаковаEntities.Get().SaveChanges();

                updata();
            }
        }
    }
}
