
using System;
using System.Collections.Generic;
using System.IO;
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

namespace EnglishLearning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users;

        public MainWindow()
        {
            users = new List<User>();
            GetUsers();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var item in users)
            {
                if (LoginTextBox.Text == item.Login && passwordBox.Password == item.Password)
                {
                    MessageBox.Show("Log In successfull! The application is under construction)");
                    Environment.Exit(0);
                }
            }
        }

        private void GetUsers()
        {
            try
            {
                List<string> list = File.ReadAllLines("users.txt").ToList();
                foreach (var item in list)
                {
                    string[] tmp = item.Split(' ');
                    users.Add(new User(tmp[0], tmp[1], int.Parse(tmp[2]), int.Parse(tmp[3])));
                }
            }
            catch
            {
                MessageBox.Show("Error in file!");
                Environment.Exit(0);
            }
        }

        private void SaveUsers()
        {
            try
            {
                File.WriteAllText("users.txt", "");

                List<string> buf = new List<string>();
                foreach (var item in users)
                {
                    buf.Add(item.Login + " " + item.Password + " " + item.Level + " " + item.Progress);
                }
                
                File.AppendAllLines("users.txt", buf);
            }
            catch(Exception)
            {
                Environment.Exit(0);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Reg.Visibility = Visibility.Hidden;
            Login.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Visible;
            Register.Visibility = Visibility.Visible;
            LoginLabel.Content = "Enter Login:";
            PasswordLabel.Content = "Enter Password:";
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isTrue = true;
                foreach (var item in users)
                {
                    if (LoginTextBox.Text == item.Login)
                    {
                        isTrue = false;
                        MessageBox.Show("Such login is already exists");
                        break;
                    }
                }
                if (isTrue)
                {
                    users.Add(new User(LoginTextBox.Text, passwordBox.Password));
                    SaveUsers();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error!");
            }
            LoginTextBox.Text = "";
            passwordBox.Password = "";
            LoginLabel.Content = "Login:";
            PasswordLabel.Content = "Password:";
            Reg.Visibility = Visibility.Visible;

            Back.Visibility = Visibility.Hidden;
            Login.Visibility = Visibility.Visible;
            Register.Visibility = Visibility.Hidden;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LoginLabel.Content = "Login:";
            PasswordLabel.Content = "Password:";
            Reg.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Visible;
            Register.Visibility = Visibility.Hidden;
            Back.Visibility = Visibility.Hidden;
        }
    }
}
