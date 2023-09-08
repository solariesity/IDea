using IDea.ViewModels;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace IDea.Views {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MyDatacontext();
        }
    }
    public class MyDatacontext : BindableBase {
        private FilesControl filesControls;
        public FilesControl FilesControls {
            get { return filesControls; }
            set { SetProperty(ref filesControls, value); }
        }

        private FilesOpen filesOpens;
        public FilesOpen FilesOpens {
            get { return filesOpens; }
            set { SetProperty(ref filesOpens, value); }
        }
        public MyDatacontext() {
            FilesOpens = new FilesOpen();
            FilesControls = new FilesControl();
        }
    }
}
