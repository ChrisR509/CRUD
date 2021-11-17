using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagment.Models
{
    public class MedicalManagmentContext
    {
        public string? ConnectionString { get; private set; }
        public MedicalManagmentContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MedicalConnection"].ToString();
        }
    }
}
