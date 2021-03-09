using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace learning.softing.app2
{
    class File
    {
        public string Name { get; set; }

        public string Path { get; set; }
        public int Index { get; set; }
        public long Size { get; set; }

        public int Length { get; set; }

        protected static List<File> files = new List<File>();

        public File() { }

        public File(int index, string path, string  name, long size)
        {
            Path = path;
            Name = name;
            Index = index;
            Size = size;
            Length = GetLength(path);
        }

      

        private int GetLength(string path)
        {
            MediaFoundationReader reader = new MediaFoundationReader(path);
            double minutes = reader.TotalTime.Minutes;
            double seconds = reader.TotalTime.Seconds;
            string total = minutes.ToString() + seconds.ToString();
            return Int32.Parse(total);
        }
    }
}
