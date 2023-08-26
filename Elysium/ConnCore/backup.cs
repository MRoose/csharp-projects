using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConnCore
{
    public class backup
    {
        connection_strings cstr = new connection_strings();

        public void b_with()
        {
            string backup_folder = cstr.backups + DateTime.Now.ToString("dd.MM.yyyy.HH.mm.ss") + "\\";
            Directory.CreateDirectory(backup_folder);
        }

        public void b_without()
        {

        }
    }
}
