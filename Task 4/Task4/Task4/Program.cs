using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "12345";
            int[] b1 = new int[s1.Length];

            for (int i = 0; i < s1.Length; i++)
            {
                b1[i]= Convert.ToInt32(s1[i]);
            }

            var s2 = "12346";
            int[] b2 = new int[s2.Length];

            for (int i = 0; i < s2.Length; i++)
            {
                b2[i] = Convert.ToInt32(s2[i]);
            }

            int[] b3 = new int[s2.Length];//
            for (int i = 0; i < b3.Length; i++)
            {
                b3[i] = (b1[i] ^ b2[i]);
            }


            Console.WriteLine();

        }
    }


    class ChangesFile
    {
        string _patchChangesFile;
        string _patchOriginalFile;
        int _hachFullFile;
        int[] _Changes;
        DateTime TimeChanges;


        ChangesFile(string pachNewFileChanges, string fullFileOld)
        {
            if (pachNewFileChanges == string.Empty)
            {
                throw new ArgumentNullException(nameof(pachNewFileChanges));
            }

          
            int[] oldFile = new int[fullFileOld.Length];
            for (int i = 0; i < fullFileOld.Length; i++)
            {
                oldFile[i] = Convert.ToInt32(fullFileOld[i]);
            }

            using StreamReader srOriginalFile = File.OpenText(_patchOriginalFile);
            var file = srOriginalFile.ReadToEnd();
            int[] newFile = new int[file.Length];
            for (int i = 0; i < file.Length; i++)
            {
                newFile[i] = Convert.ToInt32(file[i]);
            }

            int[] changes = new int[newFile.Length];
            
            for (int i = 0; i < changes.Length; i++)
            {
                changes[i] = (oldFile[i] ^ newFile[i]);
            }

            using StreamWriter streamWriter = File.CreateText(pachNewFileChanges);
            streamWriter.Write(changes);
            

        }

        public bool thereAnyChanges()
        {
            using StreamReader srOriginalFile = File.OpenText(_patchOriginalFile);
            var file = srOriginalFile.ReadToEnd();
            int hachOrig = file.GetHashCode();
            return hachOrig == _hachFullFile;
        }



    }

}
