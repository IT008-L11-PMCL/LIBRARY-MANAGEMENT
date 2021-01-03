using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Data;

namespace LIBRARY.BUSS
{
    class Word
    {
        public void createDocument(string fileName,string name, string maThe,string DiaChi, string maDG)
        {
            word.Application winword = new Application();
            winword.Visible = false;
            object misValue = System.Reflection.Missing.Value;
            object path = @"D:\NguyenNhutTan\DO_AN_QUAN_LY_THU_VIEN\LIBRARY MANAGEMENT\LIBRARY\Card\TheThuVien.docx";
            Document document = new Document();
            
            document = winword.Documents.Open(path, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue);
            document.Activate();
            foreach (FormField field in document.FormFields)
            {
                switch(field.Name)
                {
                    case "Name":
                        field.Range.Text = name;
                        break;
                    case "MaThe":
                        field.Range.Text = maThe;
                        break;
                    //case "NgayHetHan":
                    //    field.Range.Text = ngayHH;
                    //    break;
                    case "MaDG":
                        field.Range.Text = maDG;
                        break;
                    case "DiaChi":
                        field.Range.Text = DiaChi;
                        break;
                    default:
                        break;
                }    
            }



            document.SaveAs2(fileName);
            document.Close(false, misValue,misValue);

            winword.Quit();

            releaseObject(winword);
            releaseObject(document);

            System.Diagnostics.Process.Start(fileName);


        }

        public void createLendingForm(string fileName, string soPhieu, string ngayMuon, string maDG, string tenDG, string maThe)
        {
            word.Application winword = new Application();
            winword.Visible = false;
            object misValue = System.Reflection.Missing.Value;
            object path = @"D:\NguyenNhutTan\DO_AN_QUAN_LY_THU_VIEN\LIBRARY MANAGEMENT\LIBRARY\Card\PMT.docx";
            Document document = new Document();

            document = winword.Documents.Open(path, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue, ref misValue);
            document.Activate();
            foreach (FormField field in document.FormFields)
            {
                switch (field.Name)
                {
                    case "sophieu":
                        field.Range.Text = soPhieu;
                        break;
                    case "ngaymuon":
                        field.Range.Text = ngayMuon;
                        break;
                    case "madg":
                        field.Range.Text = maDG;
                        break;
                    case "tendg":
                        field.Range.Text = tenDG;
                        break;
                    case "mathe":
                        field.Range.Text = maThe;
                        break;
                    default:
                        break;
                }
            }

          

            foreach(DataRow row in (new muonTra_BUS().getCTMTList(soPhieu).Rows))
            {
                DataRow data = new sach_BUS().timkiem(row["MaSach"].ToString()).Rows[0];
                Paragraph paragraph = document.Paragraphs.Add(ref misValue);
                paragraph.Range.Text = data["MaSach"].ToString() + "\t" + data["Ten"].ToString();
                paragraph.Range.Font.Name = "Time News Roman";
                paragraph.Range.Font.Size = 14;
                paragraph.Range.ListFormat.ApplyNumberDefault(ref misValue);
                paragraph.Range.InsertParagraphAfter();
            }

            document.SaveAs2(fileName);
            document.Close(false, misValue, misValue);

            winword.Quit();

            releaseObject(winword);
            releaseObject(document);

            System.Diagnostics.Process.Start(fileName);

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
