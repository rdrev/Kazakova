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
    /// Логика взаимодействия для AddBeneathTaskPage.xaml
    /// </summary>
    public partial class AddBeneathTaskPage : Page
    {
        private ПодЗадание подЗадача = null;
        

        public AddBeneathTaskPage(ПодЗадание подЗадача, Задание задание)
        {
            InitializeComponent();

            this.подЗадача = подЗадача;
            this.подЗадача.Задача = задание.КодЗадание;

            DataContext = this.подЗадача;
            
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (подЗадача.КодПодзадание != 0)
                {
                    var подзадача = КазаковаEntities.Get().ПодЗадание.Find(подЗадача.КодПодзадание);
                    подзадача = подЗадача;

                    КазаковаEntities.Get().SaveChanges();
                }
                else
                {
                    КазаковаEntities.Get().ПодЗадание.Add(подЗадача); 

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

