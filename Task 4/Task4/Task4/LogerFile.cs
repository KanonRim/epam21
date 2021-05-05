using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task4
{
    class LogerFile
    {
        List<ChangesFileInfo> list = new List<ChangesFileInfo>();
        public string PathFile { get ;}
        public string ChangesFileFolder { get;}
        internal List<ChangesFileInfo> List { get => list; set => list = value; }

        public LogerFile(string path, string changesFileFolder )
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), nameof(path) + @" Is Null or Empty stiring ");
            }
            if (string.IsNullOrEmpty(changesFileFolder))
            {
                throw new ArgumentNullException(nameof(changesFileFolder), nameof(changesFileFolder) + @" Is Null or Empty stiring ");
            }
            ChangesFileFolder = changesFileFolder;
            PathFile = path;
            SearchAllChangesFile(changesFileFolder);
        }


  
        public bool Update()
        {
            if (List.Count > 0)
            {
                if (List[List.Count - 1].ThereAnyChanges())
                {
                    if(File.Exists(PathFile))
                    List.Add(new ChangesFileInfo(ChangesFileFolder, DateTime.Now, PathFile));
                    else
                    List.Add(new ChangesFileInfo(ChangesFileFolder, DateTime.Now, PathFile,TypeChanges.Deleted));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                List.Add(new ChangesFileInfo(ChangesFileFolder, DateTime.Now, PathFile));
                return true;
            }

        }
        public void RollingBackChanges(int howManyChangesAgo)
        {
            if (howManyChangesAgo > List.Count||howManyChangesAgo<0)
                throw new ArgumentException(nameof(howManyChangesAgo));
            Update();
            List[howManyChangesAgo].RollingBackChanges();
        }
        public void RollingBackChanges(DateTime dateTime)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[list.Count-i-1].TimeChanges<dateTime)
                {
                    RollingBackChanges(list.Count - i-1);
                    return;
                }
            }
            Update();
            File.Delete(PathFile);
        }
        public void SearchAllChangesFile(string changesFileFolder)
        {
            if (!Directory.Exists(changesFileFolder))
            {
                Directory.CreateDirectory(changesFileFolder);
                return;
            }
            String[] pathChangesFile = Directory.GetFiles(changesFileFolder, "*.ChangesFile");
     
            foreach (var item in pathChangesFile)
            { // TODO check for possibility Deserialize
                using StreamReader ChangFile = File.OpenText(item);
                var Read = ChangFile.ReadToEnd();
                var ChangesFile =JsonSerializer.Deserialize<ChangesFileInfo>(Read);
                if (ChangesFile.PathOriginalFile == PathFile)
                {
                    List.Add(ChangesFile);
                }

            }
            List.Sort((x, y) => x.TimeChanges.CompareTo(y.TimeChanges));

        }
    }

}
