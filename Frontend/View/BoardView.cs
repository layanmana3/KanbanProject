using Frontend.Model;
using Frontend.ViewModel;
using IntroSE.Kanban.Backend.BusinessLayer.User;
using System.Windows;
using System.Windows.Controls;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class BoardView : Window
    {
        private BoardViewModel viewModel;
        private UserModel userModel;

       
        public BoardView(UserModel u , string name , int id)
        {
            InitializeComponent();
            this.userModel = u;
            this.viewModel = new BoardViewModel(u,name,id);
            this.DataContext = viewModel;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            BoardListView boardsList = new BoardListView(userModel);
            boardsList.Show();
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
