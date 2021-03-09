using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace learning.softing.app2
{
     interface IReadable
    {
        public List<File> GetDuplicatesFileBySize(List<File> files);


        public List<File> GetDuplicatesFileByName(List<File> files);


        public List<File> GetDuplicatesFileByLength(List<File> files);


        public void RemoveFilesByLength();


        public void RemoveFilesByName();


        public void RemoveFilesBySize();

        public void RemoveFile(File file);


        public void ReadFiles(Folder folder);
    }
}