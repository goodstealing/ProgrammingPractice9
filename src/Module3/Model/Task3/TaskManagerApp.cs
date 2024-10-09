using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Module3.Model.Task3
{
    public class TaskModel
    {
        public string Description { get; set; }

        public TaskModel(string description)
        {
            Description = description;
        }
    }


}
