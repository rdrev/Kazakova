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
    /// Логика взаимодействия для AddKlientPage.xaml
    /// </summary>
    public partial class AddKlientPage : Page
    {
        private Клиенты клиент = null;

        public AddKlientPage(Клиенты клиент)
        {
            InitializeComponent();

            this.клиент = клиент;

            DataContext = this.клиент;
        }
        
        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (клиент.КодКлиента == 0)
                {
                    КазаковаEntities.Get().Клиенты.Add(клиент);
                    КазаковаEntities.Get().SaveChanges();
                }
                else
                {
                    var клиент = КазаковаEntities.Get().Клиенты.Find(this.клиент.КодКлиента);
                    клиент = this.клиент;
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
