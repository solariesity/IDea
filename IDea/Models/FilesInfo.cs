using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace IDea.Models {
    public class FilesInfo {
        public int Id { set; get; }
        public string Path { set; get; }
        public string Name { set; get; }
    }
}
