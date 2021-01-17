using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Interface;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigClass conf = ConfigClass.GetConfig();
            Console.WriteLine(conf.folder);
            DirectoryInfo d = new DirectoryInfo(conf.folder);//Assuming Test is your Folder
            /*//DirectoryInfo d = new DirectoryInfo(@"E:\New folder");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.docx"); //Getting Text files

            foreach (FileInfo file in Files)
            {
                try
                {
                    //ReadDocxWithSpire(file);

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
            }*/

            //DirectoryInfo d = new DirectoryInfo(@"F:\Tools\ConsoleReadDocx");//Assuming Test is your Folder
            try { 
                FileInfo[] Files = d.GetFiles("*.docx"); //Getting Text files
                foreach (FileInfo file in Files)
                {
                    try
                    {
                        RemoveWordInDocx(file, "quảng cáo");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error in : " + file.Name);
                        Console.WriteLine("error" + ex.Message);
                        continue;
                    }
                }

                Console.WriteLine("Done");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("khong tim thay duong dan !!");
                Console.ReadLine();
                return;
            }
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

        public static void RemoveWordInDocx(FileInfo file, string word)
        {
            Document document = new Document();
            document.LoadFromFile(file.FullName);

            Section section = document.Sections[0];

            int numberPara = section.Paragraphs.Count;
            for(int i = 0; i < numberPara; i++)
            {
                Paragraph para = section.Paragraphs[i];
                string oldString = para.Text;
                int start = oldString.ToLower().IndexOf(word);
                
                if (start == -1)
                {
                    continue;
                }
                else
                {                 
                    string newString = oldString.Substring(0, start) + oldString.Substring(start + word.Length);
                    Console.WriteLine("Fixed in :" + file.Name);
                    Console.WriteLine("new: " + newString);
                    para.Text = newString;
                    document.SaveToFile(file.FullName, FileFormat.Docx);
                }
            }

            //Update Text of Title
            /*Section section = document.Sections[0];
            Paragraph para1 = section.Paragraphs[0];
            string oldString = para1.Text;
            int start = oldString.IndexOf("Bài");
            if (start == -1)
            {
                return;
            }
            string newString = oldString.Substring(0, start) + "Câu" + oldString.Substring(start + 3);
            Console.WriteLine(newString);
            para1.Text = newString;*/

            //document.SaveToFile(file.FullName, FileFormat.Docx);
        }
    }
}
