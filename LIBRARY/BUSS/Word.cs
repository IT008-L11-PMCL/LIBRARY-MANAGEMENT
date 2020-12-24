using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;

namespace LIBRARY.BUSS
{
    class Word
    {
        public void createDocument()
        {
            word.Application winword = new Application();
            winword.ShowAnimation = false;
            winword.Visible = false;
            object misValue = System.Reflection.Missing.Value;

            Document document = winword.Documents.Add(ref misValue, ref misValue, ref misValue, ref misValue);

        }
    }
}
