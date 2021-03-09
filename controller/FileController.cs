using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace learning.softing.app2
{
    class FileController : File, IReadable
    {

        private static FileController instance;

        protected FileController() { }

        public static FileController GetInstance()
        {
            if(instance == null)
            {
                instance = new FileController();
            }
            return instance;
        }



        public List<File> GetDuplicatesFileBySize(List<File> files)
        {
            List<File> duplicates = new List<File>();

            for (int i = 0; i < files.Count - 1; i++)
            {
                if (files[i].Size == files[i + 1].Size)
                {
                    duplicates.Add(files[i]);
                }
            }
            return duplicates;
        }

        private bool IsDuplicated(string s1, string s2)
        {
            return s1.ToLower().Equals(s2.ToLower());
        }

        public List<File> GetDuplicatesFileByName(List<File> files)
        {
            List<File> duplicates = new List<File>();

            for (int i = 0; i < files.Count - 1; i++)
            {
                string first = files[i].Name.ToLower();
                first = Regex.Replace(first, ".mp3", String.Empty);
                first = Regex.Replace(first, ".m4a", String.Empty);
                first = Regex.Replace(first, "[^\x61-\x7A]", String.Empty);

                for (int j = i + 1; j < files.Count; j++)
                {
                    string second = files[j].Name.ToLower();
                    second = Regex.Replace(second, ".mp3", String.Empty);
                    second = Regex.Replace(second, ".m4a", String.Empty);
                    second = Regex.Replace(second, "[^\x61-\x7A]", String.Empty);

                    if (IsDuplicated(first, second))
                    {
                        duplicates.Add(files[j]);
                    }
                }
            }

            if(duplicates.Count == 0)
            {
                Console.WriteLine("No duplicates found");
            }

            return duplicates;
        }

        public List<File> GetDuplicatesFileByLength(List<File> files)
        {
            List<File> duplicates = new List<File>();

            for (int i = 0; i < files.Count - 1; i++)
            {
                int ts1 = files[i].Length;
                int ts2 = files[i + 1].Length;

                if (ts1 == ts2)
                {
                    if (files[i].Size > files[i + 1].Size)
                    {
                        duplicates.Add(files[i + 1]);
                    }
                    else
                    {
                        duplicates.Add(files[i]);
                    }

                }

            }

            if(duplicates.Count == 0)
            {
                Console.WriteLine("No duplicates found");
            }

            return duplicates;
        }

        public void RemoveFilesByLength()
        {
            List<File> duplicates = GetDuplicatesFileByLength(files);

            foreach (File duplicate in duplicates)
            {
                RemoveFile(duplicate);
            }

            Console.WriteLine($"Succesfully deleted {duplicates.Count} files.");
        }

        public void RemoveFilesByName()
        {
            List<File> duplicates = GetDuplicatesFileByName(files);

            foreach (File duplicate in duplicates)
            {
                RemoveFile(duplicate);
            }

            Console.WriteLine($"Succesufully deleted {duplicates.Count} files.");
        }

        public void RemoveFilesBySize()
        {
            List<File> duplicates = GetDuplicatesFileBySize(files);

            foreach (File duplicate in duplicates)
            {
                RemoveFile(duplicate);
            }

        }

        public void RemoveFile(File file)
        {
            System.IO.File.Delete(file.Path);
            files.Remove(file);
        }

        public List<File> GetFiles()
        {
            if (files.Count > 0)
            {
                return files;
            }
            else
            {
                return null;
            }
        }

        public void ReadFiles(Folder folder)
        {
            try
            {
                string[] filesName = Directory.GetFiles(folder.path);
                List<FileInfo> fileInfos = new List<FileInfo>();

                foreach (string fileName in filesName)
                {
                    fileInfos.Add(new FileInfo(fileName));
                }

                int index = 1;
                foreach (var file in fileInfos)
                {
                    files.Add(new File(index++, file.FullName, file.Name, file.Length));
                }

            } catch(System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine("Invalid path");
            }
        }

    }
}
