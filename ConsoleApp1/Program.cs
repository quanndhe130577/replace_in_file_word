
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\DELL\Desktop\Lớp 6 môn Toán tập 2");//Assuming Test is your Folder
            //DirectoryInfo d = new DirectoryInfo(@"E:\New folder");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.docx"); //Getting Text files

            foreach (FileInfo file in Files)
            {
                try
                {
                    ReadDocxWithSpire(file);

                    string oldName = file.Name;
                    int start = oldName.IndexOf("Bài");
                    if (start == -1) continue;
                    string newName = oldName.Substring(0, start) + "Câu" + oldName.Substring(start + 3);
                    Console.WriteLine(newName);
                    file.MoveTo(Path.Combine(file.Directory.FullName, newName));
                }
                catch
                {
                    Console.WriteLine("Error: {0} ", file.Name);
                    continue;
                }
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static void ReadDocxWithSpire(FileInfo file)
        {
            //Load Document
            Document document = new Document();
            document.LoadFromFile(file.FullName);

            //Update Text of Title
            Section section = document.Sections[0];
            Paragraph para1 = section.Paragraphs[0];
            string oldString = para1.Text;
            int start = oldString.IndexOf("Bài");
            if (start == -1)
            {
                return;
            }
            string newString = oldString.Substring(0, start) + "Câu" + oldString.Substring(start + 3);
            Console.WriteLine(newString);
            para1.Text = newString;

            document.SaveToFile(file.FullName, FileFormat.Docx);

        }
    }
}
