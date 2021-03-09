using System;
using System.Collections.Generic;
using System.Text;

namespace learning.softing.app2
{
    class Folder : File
    {
        public string path { get; set; }


        public Folder() { }
        public Folder(string path)
        {
            this.path = path;
        }
    }
}
