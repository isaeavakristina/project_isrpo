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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }
 


        private void EyeBtn1(object sender, RoutedEventArgs e)
        {

        }

        private void EyeBtn2(object sender, RoutedEventArgs e)
        {

        }


        private void create(object sender, RoutedEventArgs e)
        {
            var em = email.Text;
            var login = log.Text;
            var password = pass1.Password;
            var context = new AppDbContext();


            if (login.Length > 0)
            {
                if (email.Text.Length > 0) 
                {

                    if (pass1.Password.Length > 0 && pass2.Password.Length > 0)
                    {
                        if (pass1.Password == pass2.Password)
                        {
                            if (password.Contains("+") || password.Contains("-") || password.Contains("$") || password.Contains("#"))
                            {
                                var user_exist = context.Users.FirstOrDefault(x => x.Login == login);

                                if (user_exist is not null)
                                {
                                    MessageBox.Show("Такой пользователь уже зарегистрирован!",
                                    "Message");
                                    return;
                                }
                                else
                                {
                                    var user = new User { Login = login, Password = password };
                                    context.Users.Add(user);
                                    context.SaveChanges();
                                    this.Hide();
                                    Autor mw = new Autor();
                                    mw.Show();
                                    MessageBox.Show("Вы успешно авторизовались в системе! Выполните вход!",
                                        "Message");
                                }

                            }
                            else MessageBox.Show("Спец символы где?!");
                        }
                        else MessageBox.Show("Пароли не совпадают!");

                    }
                    else MessageBox.Show("Где пароль?!");

                }
                else MessageBox.Show("Где почта?!");
            }
            else MessageBox.Show("Где логин?!");


        }

       

         private void log_in(object sender, RoutedEventArgs e)
         {
              this.Hide();
              Autor mw = new Autor();
              mw.Show();
         }
    }
}
