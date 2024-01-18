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

namespace project_isrpo
{
    /// <summary>
    /// Логика взаимодействия для Autor.xaml
    /// </summary>
    public partial class Autor : Window
    {
        public Autor()
        {
            InitializeComponent();
        }

        private void EyeBtn(object sender, RoutedEventArgs e)
        {

        }

        private void create_an_acc(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Registr reg = new Registr();
            reg.Show();
        }

        private void log_in(object sender, RoutedEventArgs e)
        {
            var login = log.Text;
            var password = pass.Password;
            var context = new AppDbContext();

            if (login.Length > 0)
            {
                if (password.Length > 0)
                {

                    var user = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
                    if (user is null)
                    {
                        MessageBox.Show("Неправильный логин или пароль.",
                        "Message");
                        return;

                    }
                    else 
                    {
                        MessageBox.Show("Вы успешно вошли в систему.",
                         "Message");
                        this.Hide();
                        Account acc = new Account();
                        acc.Show();
                    }
                }
            }
            
        }
    }
}
