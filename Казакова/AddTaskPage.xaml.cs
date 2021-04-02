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
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        private Задание задания = null;

        public AddTaskPage(Задание задания, Клиенты клиент)
        {
            InitializeComponent();

            this.задания = задания;

            DataContext = this.задания;

            if (this.задания.КодЗадание == 0)
            {
                this.задания.Начала = DateTime.Today;
                this.задания.Окончание = DateTime.Today;
            }

            if (клиент != null)
            {
                CBK.Visibility = Visibility.Hidden;
                TBK.Visibility = Visibility.Hidden;

                CBS.Visibility = Visibility.Hidden;
                TBS.Visibility = Visibility.Hidden;

                this.задания.Клиенты = клиент;
            }
            else
            {
                CBK.ItemsSource = КазаковаEntities.Get().Клиенты.ToList();

                List<bool> vs = new List<bool> { true, false };
                //CBS.ItemsSource = vs;
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (задания.КодЗадание != 0)
                {
                    var исходЗадание = КазаковаEntities.Get().Задание.Find(задания.КодЗадание);
                    исходЗадание = задания;
                    КазаковаEntities.Get().SaveChanges();
                }
                else
                {
                    КазаковаEntities.Get().Задание.Add(задания);
                    КазаковаEntities.Get().SaveChanges();

                }
                    MenegerFrame.Frame.GoBack();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClerBtn_Click(object sender, RoutedEventArgs e)
        {
            MenegerFrame.Frame.GoBack();
        }
    }
}
