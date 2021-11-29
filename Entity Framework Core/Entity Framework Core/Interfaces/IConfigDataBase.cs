using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework_Core.Interfaces
{
    public interface IConfigDataBase
    {
        string GetFullPath(string databaseFileName);
    }

}
