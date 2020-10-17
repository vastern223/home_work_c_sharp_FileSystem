using System;
using System.IO;


namespace _01_FileWork
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int chois;
            do
            {
                Console.Clear();
                DirectoryInfo dir = new DirectoryInfo(path);

                Console.WriteLine("Directory: \t{0}", dir.FullName);
                Console.WriteLine("CreationTime: {0}", dir.CreationTime);
                Console.WriteLine("Extension: {0}", dir.Extension);
                Console.WriteLine("LastAccessTime: {0}", dir.LastAccessTime);
                Console.WriteLine("LastWriteTime: {0}", dir.LastWriteTime);
                Console.WriteLine("Name: {0}", dir.Name);

                Console.WriteLine("Directories ----------------------");
                foreach (var d in dir.GetDirectories())
                {
                    Console.WriteLine($"Directory: {d.Name}  time:  {d.CreationTime} atr: {d.Attributes}");
                }
                Console.WriteLine("Files --------------------------");
                foreach (var file in dir.GetFiles())
                {
                    Console.WriteLine($"File: {file.Name}  time:  {file.CreationTime} atr: {file.Attributes}");
                }


                Console.WriteLine("1-go to folder");
                Console.WriteLine("2-go to file");
                Console.WriteLine("3-go back");
                Console.WriteLine("4-create directory");
                Console.WriteLine("5-delete directory");
                Console.WriteLine("6-delete file");
                Console.WriteLine("7-moving file");
                Console.WriteLine("8-exit");
                chois = int.Parse(Console.ReadLine());

                switch (chois)
                {
                    case 1:
                        {
                            Console.WriteLine("enter name folder");
                            Console.Write("->");
                            string next = Console.ReadLine();
                            path = Path.Combine(path, next);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("enter name directory");
                            Console.Write("->");
                            string next = Console.ReadLine();                           
                            foreach (var file in dir.GetFiles())
                            {
                                if (file.Name == next) { Console.WriteLine($"File: {file.Name}  time:  {file.CreationTime} atr: {file.Attributes}"); }
                            }                          
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            string next = "..";
                            path = Path.Combine(path, next);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("enter name");
                            Console.Write("->");
                            string subpath = Console.ReadLine();
                            if (!dir.Exists)
                            {
                                dir.Create();
                            }
                            dir.CreateSubdirectory(subpath);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("enter name");
                            Console.Write("->");
                            string dirName = Console.ReadLine();
                            path = Path.Combine(path, dirName);
                            try
                            {

                                dir.Delete(true);
                                Console.WriteLine("Каталог удален");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        }
                    case 6:
                        {
                            if (dir.Exists)
                            {
                                dir.Delete();                             
                            }
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("enter new Path");
                            Console.Write("->");
                            string newPath = Console.ReadLine();                      
                            if (dir.Exists)
                            {
                                dir.MoveTo(newPath);
                             
                            }
                            break;
                        }
                    case 8:
                        {
                            chois = 8;
                            break;
                        }
                }

            } while (chois!=8);


        }
    }
}
