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
    /// Логика взаимодействия для AddEmpPage.xaml
    /// </summary>
    public partial class AddEmpPage : Page
    {
        private Сотрудники сотрудник = null;

        public AddEmpPage(Сотрудники сотрудники)
        {
            InitializeComponent();

            this.сотрудник = сотрудники;

            DataContext = this.сотрудник;
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (сотрудник.КодСотрудники == 0)
                {
                     КазаковаEntities.Get().Сотрудники.Add(сотрудник);
                     КазаковаEntities.Get().SaveChanges();
                }
                else
                {
                    var сотрудник =  КазаковаEntities.Get().Сотрудники.Find(this.сотрудник.КодСотрудники);
                    сотрудник = this.сотрудник;
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
