
using Frontend.View;
using System.Windows;
using Frontend.ViewModel;
using Frontend.Model;
using Frontend.View;
using System.Windows.Controls;
using System;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            this.viewModel = (MainViewModel)DataContext;

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            UserModel u = viewModel.Login();
            if (u != null)
            {
                
                BoardListView boardView = new BoardListView(u);
                boardView.Show();
                this.Close();
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            UserModel v = viewModel.Register();
            if (v != null)
            {
                BoardListView boardsList = new BoardListView(v);
                boardsList.Show();
                this.Close();
            }
        }

        private void Usernamebox(object sender, TextChangedEventArgs e)
        {

        }

        private void Passbox(object sender, TextChangedEventArgs e)
        {

        }
    }
}
