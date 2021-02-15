using ExcelDataReader;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tool_Replace_Word_v1
{
    class Program
    {
        static ConfigClass conf;
        static int count = 0;
        static void Main(string[] args)
        {
            try
            {
                conf = ConfigClass.GetConfig();
                if (conf == null)
                {
                    throw new Exception("Can not find folder scan.");
                }
                Console.WriteLine("Folder ho so :" + conf.short_part_hosomau);
                Console.WriteLine("Folder file edit :" + conf.short_part_fileEdit);

                FileInfo f_edit = new FileInfo(Environment.CurrentDirectory + conf.short_part_fileEdit);


                List<EditDetailModel> listEdit = new List<EditDetailModel>();

                //read file edit
                using (var stream = File.Open(f_edit.FullName, FileMode.Open, FileAccess.Read))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        // Choose one of either 1 or 2:
                        // 1. Use the reader methods
                        do
                        {
                            while (reader.Read())
                            {
                                count++;
                                //Console.WriteLine(reader.GetString(0));
                                EditDetailModel ed = new EditDetailModel();
                                ed.MaCode = reader.GetString(0) == null ? "" : reader.GetString(0);
                                ed.NoiDungThayThe = reader.GetString(1) == null ? "" : reader.GetString(1);
                                ed.Description = reader.GetString(2) == null ? "" : reader.GetString(2);

                                listEdit.Add(ed);
                            }
                        } while (reader.NextResult());
                    }
                }

                //read file ho so 
                FileInfo f_hoso = new FileInfo(Environment.CurrentDirectory + conf.short_part_hosomau);
                Document document = new Document();
                document.LoadFromFile(f_hoso.FullName);

                for (int i = 1; i < listEdit.Count; i++)
                {
                    document.Replace(listEdit[i].MaCode, listEdit[i].NoiDungThayThe, false, true);
                }

                document.SaveToFile(conf.folder_result + "Replace.docx", FileFormat.Docx);
                //System.Diagnostics.Process.Start("Replace.docx");

                Console.WriteLine("Done");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n " + count);
                Console.ReadLine();
                return;
            }
            Console.ReadLine();

        }


    }
}
