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
using System.Windows.Shapes;

namespace Казакова
{
    /// <summary>
    /// Логика взаимодействия для BonusWindow.xaml
    /// </summary>
    public partial class BonusWindow : Window
    {
        private Задание задание = null;

        public BonusWindow(Задание задание)
        {
            InitializeComponent();

            this.задание = задание;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            List<Сотрудники> сотрудники = new List<Сотрудники>();

            foreach (var zs0 in задание.ПодЗадание)
                foreach (var zs1 in zs0.ЗадачиСотрудники)
                    сотрудники.Add(zs1.Сотрудники1);
            сотрудники.Distinct().ToList();
            try
             {
                foreach (var s0 in сотрудники)
                {
                    var s1 = КазаковаEntities.Get().Сотрудники.Find(s0.КодСотрудники);
                    s1.Премия += Convert.ToInt32(TB.Text);
                    КазаковаEntities.Get().SaveChanges();
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ощибка");
            }
            
        }
    }
}
