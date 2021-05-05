using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task4
{
    class LogerFolder
    {

        private List<LogerFile> logersFile = new List<LogerFile>();
        public string WorkingFolder { get; private set; }
        public string ChangesFileFolder { get; private set; }
        public List<LogerFile> LogersFile { get => new List<LogerFile>(logersFile); }
        public List<string> PathsFile { get => _pathsFile; set => _pathsFile = value; }

        private List<string> _pathsFile = new List<string>();
  

        
        public LogerFolder(string workingFolder, string changesFileFolder)
        {
            WorkingFolder = workingFolder;
            ChangesFileFolder = changesFileFolder;
        }

        void AddPathFile(string path)
        {

                if (PathsFile.IndexOf(path) == -1)
                {
                    PathsFile.Add(path);
                }

        }


        public void StartSupervision()
        {
            String[] pathsFiles = Directory.GetFiles(WorkingFolder,"*.txt", SearchOption.AllDirectories);
            foreach (var item in pathsFiles)
            {
                using StreamReader ChangFile = File.OpenText(item);
                AddPathFile(item);
            }

            if(File.Exists(ChangesFileFolder + @"\LogerFolder.PathsFile"))
            {
                using StreamReader PathsFile = File.OpenText(ChangesFileFolder + @"\LogerFolder.PathsFile");
                var Read = PathsFile.ReadToEnd();
                foreach (var item in JsonSerializer.Deserialize<List<string>>(Read))
                {
                    AddPathFile(item);
                }
            }

            foreach (var item in PathsFile)
            {
                logersFile.Add(new LogerFile(item, ChangesFileFolder));
            }
        }
        public void  StopSupervision()
        {
            using StreamWriter swPathsFile = File.CreateText(ChangesFileFolder + @"\LogerFolder.PathsFile");
            swPathsFile.WriteLine( JsonSerializer.Serialize<List<string>>(PathsFile));
        }
        public void UpdateSupervision()
        {
            StartSupervision();
            foreach (var item in logersFile)
            {
                item.Update();
            }
        }


    }

}
