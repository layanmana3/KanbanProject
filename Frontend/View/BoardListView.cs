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
using Frontend.ViewModel;
using Frontend.Model;
using System.Windows.Markup;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for BoardsList.xaml
    /// </summary>
    public partial class BoardListView : Window
    {
        private BoardListViewModel viewModel;
        private UserModel userModel;
        public BoardListView(UserModel u)
        {
            InitializeComponent();
            this.viewModel = new BoardListViewModel(u);
            this.DataContext = viewModel;
            this.userModel = u;
        }

        private void View_Button(object sender, RoutedEventArgs e)
        {
            string id=viewModel.get_id();
            id = id.Substring(11);
            int idd = int.Parse(id);
            string name=viewModel.get_title();
            JObject jsonObject = JObject.Parse(name);
            string boardValue = (string)jsonObject["ReturnValue"];
            BoardView view = new BoardView(userModel, boardValue, idd);
            view.Show();
            this.Close();
        }
        private void Logout_Button(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("pressing logout");
            viewModel.Logout();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

     


    }
}