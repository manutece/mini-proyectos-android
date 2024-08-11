using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyectos.ProsperDaily.Abstractions
{
     public class TableData
     {
          [PrimaryKey, AutoIncrement]
          public int Id { get; set; }
     }
}
