using System.Data;
using System.IO;
using System.Linq;

namespace GetDataFromTable
{
    public class TableInfo
    {
        public FileInfo File { get; set; }

        public DataTable Table { get; set; }
    }
}
