using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using Prism.Mvvm;

namespace IDea.ViewModels {
    public class FilesOpen{
        public DelegateCommand<string> OpenCommand { get; set; }
        public ProcessStartInfo ProcessStartInfo { get; set; }
        public FilesOpen() {
            OpenCommand = new DelegateCommand<string>(Open);
        }
        void Open(string path) {
            ProcessStartInfo = new ProcessStartInfo {
                FileName = path,
                UseShellExecute = true,
            };
            try {
                Process.Start(ProcessStartInfo);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
