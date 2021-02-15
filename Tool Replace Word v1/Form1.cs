using ExcelDataReader;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_Replace_Word_v1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDefaultText();
        }

        private void bt_browse_hosomauOnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Office Files|*.doc;*.docx"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txt_path_hosomau.Text = ofd.FileName;
                }
            }
        }

        private void bt_browse_fileEdit_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txt_path_fileEdit.Text = ofd.FileName;
                }
            }
        }

        private void bt_browser_result_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txt_path_result.Text = fbd.SelectedPath;
                }
            }
        }

        int count = 0;

        private void bt_submit_Click(object sender, EventArgs e)
        {
            try
            {
                /*conf = ConfigClass.GetConfig();
                if (conf == null)
                {
                    throw new Exception("Can not find folder scan.");
                }*/

                FileInfo f_edit = new FileInfo(txt_path_fileEdit.Text);

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
                FileInfo f_hoso = new FileInfo(txt_path_hosomau.Text);
                Document document = new Document();
                document.LoadFromFile(f_hoso.FullName);

                for (int i = 1; i < listEdit.Count; i++)
                {
                    document.Replace(listEdit[i].MaCode, listEdit[i].NoiDungThayThe, false, true);
                }

                if (!string.IsNullOrEmpty(txt_exportFileName.Text))
                {
                    document.SaveToFile(txt_path_result.Text + txt_exportFileName.Text + ".docx", FileFormat.Docx);
                }
                else
                {
                    throw new Exception("Invalid File Name !!!");
                }

                //System.Diagnostics.Process.Start("Replace.docx");

                SetResult("Success");

                UpdateDefaultText();
            }
            catch (Exception ex)
            {
                SetResult(ex.Message);
                return;
            }
        }

        private void SetResult(string ms)
        {
            lb_result.Text = "Result : " + ms;
        }

        ConfigClass conf;
        private void LoadDefaultText()
        {
            try
            {
                conf = ConfigClass.GetConfig();
                if (conf == null)
                {
                    throw new Exception("Load default file error");
                }
                txt_path_hosomau.Text = conf.short_part_hosomau;
                txt_path_fileEdit.Text = conf.short_part_fileEdit;
                txt_path_result.Text = conf.folder_result;
                txt_exportFileName.Text = conf.file_name;
            }
            catch (Exception ex)
            {
                SetResult(ex.Message);
                return;
            }
        }

        private void UpdateDefaultText()
        {
            conf.short_part_hosomau = txt_path_hosomau.Text;
            conf.short_part_fileEdit = txt_path_fileEdit.Text;
            conf.folder_result = txt_path_result.Text;
            conf.file_name = txt_exportFileName.Text;

            ConfigClass.UpdateConfig(conf);
        }
    }
}
