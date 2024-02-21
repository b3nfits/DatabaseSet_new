using DatabaseSet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Principal;
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

namespace SotSet.Reg
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        private readonly DatabaseSet.user5Entities connection;
        public ObservableCollection<DatabaseSet.Profile> Profiles { get; set; }
        public RegPage()
        {
            InitializeComponent();
            connection= new DatabaseSet.user5Entities();
            Profiles = new ObservableCollection<DatabaseSet.Profile>(connection.Profiles);
            
            DataContext = this;
            
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var profile = new DatabaseSet.Profile()
            {
                Email = txtEmail.Text.Trim(),
                Nickname = txtUsername.Text.Trim(),
                Passwords = txtPassword.Password,
                Date_of_birth= DateTime.UtcNow,


            };
            connection.Profiles.Add(profile);
            Profiles.Add(profile);
            connection.SaveChanges();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtDateOfBirth.Clear();
            MessageBox.Show("Пользователь добавлен!");


        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            
        }
    }
}
