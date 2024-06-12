using ContactApp.Implementations;
using ContactApp.ViewModels;
using System.Windows;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ContactsViewModel(new DefaultDialogService(), new JsonFileService());
        }
    }
}