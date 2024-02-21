using DatabaseSet;
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
using System.Xml.Linq;

namespace SotSet.Panel
{
    /// <summary>
    /// Логика взаимодействия для PanelPage.xaml
    /// </summary>
    public partial class PanelPage : Page
    {
        private readonly DatabaseSet.user5Entities connection;
        public ObservableCollection<DatabaseSet.Post> Posts { get; set; }
        private static PanelPage _context;

        public PanelPage()
        {
            InitializeComponent();
            Posts = new ObservableCollection<DatabaseSet.Post>();
            connection = new DatabaseSet.user5Entities();
           
            


        }
        public static PanelPage GetContext()
        {
            if(_context == null)
                _context= new PanelPage();
            return _context;
        }

        private void Add(object sender, RoutedEventArgs e)
        {

            string productName = tb.Text.Trim();
            if (productName.Length == 0)
            {
                MessageBox.Show("Введите чёнить");
                return;
            }
            else { lb.Items.Add(new Product(productName)); }

            var post = new DatabaseSet.Post()
            {
                Post_content = tb.Text.Trim(),
            };
            connection.Posts.Add(post);
            Posts.Add(post);
            connection.SaveChanges();
            tb.Clear();
            
            MessageBox.Show("Пост добавлен");

            

           

        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGig.ItemsSource = PanelPage.GetContext().Posts.ToList();



        }
        public class Product
        {
            public Product(string name)
            {
                Name = name;
            }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void testlb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void DGig_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
