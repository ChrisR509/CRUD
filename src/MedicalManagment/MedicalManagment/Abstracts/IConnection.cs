using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagment.Abstracts
{
    public interface IConnection
    {
        public Task OpenConnection();
        public Task CloseConnection();
    }
}
