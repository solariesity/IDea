using IDea.Models;
using MySql.Data.MySqlClient;
using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Schema;

namespace IDea.ViewModels {
    public class FilesControl : BindableBase {
        private string connectionString = "Server=localhost;Database=MyManager;Uid=root;pwd=Huyuejing517-";
        private ObservableCollection<FilesInfo> files;
        public ObservableCollection<FilesInfo> Files {
            get { return files; }
            set { SetProperty(ref files, value); }
        }
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;
        string query;
        public DelegateCommand<String> AddCommand { get; set; }
        // 初始化，连接数据库
        public void init() {
            Files = new ObservableCollection<FilesInfo>();
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        // 将数据库中的内容加载到页面中
        public void load() {
            query = "SELECT * FROM FILESINFO";
            command = new MySqlCommand(query, connection);

            reader = command.ExecuteReader();
            while (reader.Read()) {
                Files.Add(new FilesInfo {
                    Id = reader.GetInt32("Id"),
                    Name = reader.GetString("Name"),
                    Path = reader.GetString("Path")
                });
            }
            reader.Close();
        }
        // 增添数据库的内容
        public void Add(string path) {
            init();
            MessageBox.Show("Add");
            int lastIndex = path.LastIndexOf("\\");
            string name = path.Substring(lastIndex + 1);
            MessageBox.Show(path);
            MessageBox.Show(name);
            query = $"INSERT INTO FILESINFO(PATH,NAME) VALUES(\"{path}\", \"{name}\");";
            MessageBox.Show(query);
            command = new MySqlCommand(query, connection);
            try {
                int isInserted = command.ExecuteNonQuery();
                if (isInserted == 1) {
                    MessageBox.Show("succesful");
                }
                else {
                    MessageBox.Show("failed");
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            terminate();
        }
        public void terminate() {
            connection.Close();
        }
        public FilesControl() {
            AddCommand = new DelegateCommand<string>(Add);
            init();
            load();
            terminate();
        }
    }
}
