using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.IO;
using Spire.Doc.Fields;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ConsoleApp1
{
    class Program
    {
        static ConfigClass conf;
        static void Main(string[] args)
        {
            try
            {
                conf = ConfigClass.GetConfig();
                if (conf == null)
                {
                    throw new Exception("Can not find folder scan.");
                }
                ScanFolder(conf.folder_scan);
                /*Console.WriteLine("Folder scan :" + conf.folder_scan);
                DirectoryInfo d = new DirectoryInfo(conf.folder_scan);

                String[] subfolder = Directory.GetDirectories(d.FullName);
                foreach(var item in subfolder)
                {
                    Console.WriteLine(item);
                }


                FileInfo[] Files = d.GetFiles("*.docx"); //Getting Text files

                int total_file = Files.Length;
                int fix_file_number = 0;

                foreach (FileInfo file in Files)
                {
                    try
                    {
                        Console.WriteLine(file.Name);
                        //RemoveWordInDocx(file, "quảng cáo");
                        AddHeaderFooter(file);
                        fix_file_number += 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error in : " + file.Name);
                        Console.WriteLine("error: " + ex.Message);
                        continue;
                    }
                }

                Console.WriteLine("Done");
                Console.WriteLine("Total file : " + total_file);
                Console.WriteLine("Fix file : " + fix_file_number);*/
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

        public static void ScanFolder(string fullPath)
        {
            Console.WriteLine("=================");
            Console.WriteLine("Folder : " + fullPath);
            DirectoryInfo d = new DirectoryInfo(fullPath);
            FileInfo[] Files = d.GetFiles("*.docx"); //Getting Text files

            int total_file = Files.Length;
            int fix_file_number = 0;

            foreach (FileInfo file in Files)
            {
                try
                {
                    Console.WriteLine(file.Name);
                    //RemoveWordInDocx(file, "quảng cáo");
                    AddHeaderFooter(file);
                    fix_file_number += 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error in : " + file.Name);
                    Console.WriteLine("error: " + ex.Message);
                    continue;
                }
            }

            Console.WriteLine("Total file : " + total_file);
            Console.WriteLine("Fix file : " + fix_file_number);

            // đệ quy
            String[] subfolder = Directory.GetDirectories(fullPath);
            foreach(var item in subfolder)
            {
                try { 
                    ScanFolder(item);
                }
                catch
                {
                    continue;
                }
            }
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
            for (int i = 0; i < numberPara; i++)
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
        }

        public static HeadersFooters GetDefaultHeaderFooter(FileInfo file)
        {
            Document document = new Document();
            document.LoadFromFile(file.FullName);

            Section section = document.Sections[0];

            HeadersFooters para_header_default = section.HeadersFooters;

            return para_header_default;
        }

        public static void AddHeaderFooter(FileInfo file)
        {
            if (String.IsNullOrEmpty(conf.filepath_default_header_footer))
            {
                throw new Exception("Cant not find default headerfooter file");
            }
            //Console.WriteLine("Default file Header_Footer : " + conf.filepath_default_header_footer);

            Document doc = new Document();
            doc.LoadFromFile(file.FullName);

            Section section = doc.Sections[0];

            //remove header, footer from all page
            section.HeadersFooters.Header.ChildObjects.Clear();
            section.HeadersFooters.Footer.ChildObjects.Clear();


            HeadersFooters default_headerfooter = GetDefaultHeaderFooter(new FileInfo(conf.filepath_default_header_footer));

            //change header
            HeaderFooter current_header = section.HeadersFooters.Header;

            foreach (DocumentObject obj in default_headerfooter.Header.ChildObjects)
            {
                current_header.ChildObjects.Add(obj.Clone());
            }

            //change footer
            HeaderFooter current_footer = section.HeadersFooters.Footer;

            foreach (DocumentObject obj in default_headerfooter.Footer.ChildObjects)
            {
                current_footer.ChildObjects.Add(obj.Clone());
            }

            // change LeftIndent
            current_header.Paragraphs[0].Format.LeftIndent = -72;
            current_footer.Paragraphs[0].Format.LeftIndent = -71;

            section.PageSetup.HeaderDistance = 0;
            section.PageSetup.FooterDistance = 0;

            doc.SaveToFile(file.FullName, FileFormat.Docx);
        }

    }
}
