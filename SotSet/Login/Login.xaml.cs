using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SotSet.Login
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly DatabaseSet.user5Entities connection;
        public ObservableCollection<DatabaseSet.Profile> Profiles { get; set; }
        public Login()
        {
            InitializeComponent();
            connection = new DatabaseSet.user5Entities();
            Profiles = new ObservableCollection<DatabaseSet.Profile>(connection.Profiles);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Class1.RegPage);
            
        }

        private void Button_Click_V(object sender, RoutedEventArgs e)
        {
            var right = false;

            foreach (var profile in Profiles)
            {
                if (txtEmail.Text == profile.Email & txtPassword.Password == profile.Passwords)
                {
                    right = true;
                    NavigationService.Navigate(Class1.ProfilePage);
                    connection.SaveChanges();


                }


            }
            if (!right)
            {
                MessageBox.Show("Такой аккаунт не существует!");
            }
        }
    }
}
