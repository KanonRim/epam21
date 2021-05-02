using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task4
{
    public enum TypeChanges
    {
        Changed = 0,
        Deleted = 1
    }
    class ChangesFileInfo
    {
        public DateTime TimeChanges { get; private set; }
        public string HachCodeFile { get; private set; }
        public string PathOriginalFile { get; private set; }
        public string PathChangesFile { get; private set; }
        public TypeChanges TypeChange { get; private set; }

        public ChangesFileInfo(string pathFileChanges,
            DateTime time, string pathOriginalFile,
            TypeChanges typeChange = TypeChanges.Changed)
        {
            if (string.IsNullOrEmpty(pathOriginalFile))
            {
                throw new ArgumentNullException(nameof(PathOriginalFile), nameof(PathOriginalFile) + @" equal Null or "" ");
            }
            TypeChange = typeChange;
            PathOriginalFile = pathOriginalFile;
            TimeChanges = time;
            WriteChangesFile(pathFileChanges);
        }


        [JsonConstructor]
        public ChangesFileInfo(DateTime timeChanges, string hachCodeFile, string pathOriginalFile, string pathChangesFile, TypeChanges typeChange)
        {
            TypeChange = typeChange;
            TimeChanges = timeChanges;
            HachCodeFile = hachCodeFile;
            PathOriginalFile = pathOriginalFile;
            PathChangesFile = pathChangesFile;
        }

        void WriteChangesFile(string pathNewFileChanges)
        {
            if (string.IsNullOrEmpty(pathNewFileChanges))
            {
                throw new ArgumentNullException(nameof(pathNewFileChanges), nameof(pathNewFileChanges) + @" equal Null or "" ");
            }

            if (TypeChange != TypeChanges.Deleted)
            {
                using StreamReader srOriginalFile = File.OpenText(PathOriginalFile);
                var Changes = srOriginalFile.ReadToEnd();
                HachCodeFile = GetHash(Changes);

                if (!Directory.Exists(pathNewFileChanges + @"/backup/"))
                    Directory.CreateDirectory(pathNewFileChanges + @"/backup/");

                PathChangesFile = pathNewFileChanges + @"/backup/" +
                    TimeChanges.ToString("yyyyMMddhhmmss") +
                        Path.GetFileName(PathOriginalFile)+
                        ".backup";

                using StreamWriter swChanges = File.CreateText(PathChangesFile);
                swChanges.Write(Changes);
            }
            else
            {
                HachCodeFile = "";
            }


            using StreamWriter swNewFileChange =
                File.CreateText(pathNewFileChanges +
                TimeChanges.ToString("yyyyMMddhhmmss") +
                Path.GetFileName(PathOriginalFile) + @".ChangesFile");
            swNewFileChange.Write(JsonSerializer.Serialize<ChangesFileInfo>(this));
        }

        public bool ThereAnyChanges()
        {
            if (!File.Exists(PathOriginalFile))
                if (TypeChange == TypeChanges.Deleted)
                    return false;
                else
                    return true;
            using StreamReader srOriginalFile = File.OpenText(PathOriginalFile);
            var file = srOriginalFile.ReadToEnd();
            string hachOrig = GetHash(file);
            return hachOrig != HachCodeFile;
        }
        public void RollingBackChanges()
        {
            if (TypeChange != TypeChanges.Deleted)
            {
                using StreamReader srChanges = File.OpenText(PathChangesFile);
                var Changes = srChanges.ReadToEnd();

                using StreamWriter swChanges = File.CreateText(PathOriginalFile);
                swChanges.Write(Changes);
            }
            else
            {
                File.Delete(PathOriginalFile);
            }

        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.Unicode.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        public override string ToString()
        {
            return TimeChanges.ToString() + " " + PathOriginalFile.ToString();
        }

    }
}

    
