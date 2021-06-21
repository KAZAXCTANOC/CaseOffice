using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CaseOffice
{
    public partial class Window : Form
    {
        private List<string> AllWords = new List<string>();
        private int SelectedIndex;
        public Window()
        {
            var a = Globals.ThisAddIn.Application;
            InitializeComponent();
            int CountPage = a.ActiveDocument.ComputeStatistics(WdStatistic.wdStatisticPages);
            for(int i = 1; i <= CountPage;i++)
            {
                var Start = a.Application.Selection.GoTo(WdGoToItem.wdGoToPage, WdGoToDirection.wdGoToAbsolute, i).Start;
                var End = a.Application.Selection.GoTo(WdGoToItem.wdGoToPage, WdGoToDirection.wdGoToAbsolute, i+1).End;
                ComboBoxPageDescription.Items.Add(i);
                if (Convert.ToInt32(Start.ToString()) != Convert.ToInt32(End.ToString()))
                {
                    AllWords.Add(a.ActiveDocument.Range(Start, End).Text); 
                }
                else
                {
                    AllWords.Add(a.ActiveDocument.Range(Start).Text);
                }
            }
        }

        private void CopuButton_Click(object sender, EventArgs e)
        {
            if(ComboBoxPageDescription.SelectedItem != null)
            {
                SelectedIndex = (int)ComboBoxPageDescription.SelectedItem - 1;
                if(AllWords.ElementAt(SelectedIndex) != null)
                {
                    Clipboard.SetText(AllWords.ElementAt(SelectedIndex));
                    MessageBox.Show(AllWords.ElementAt(SelectedIndex).ToString());
                }
                else
                {
                    Clipboard.SetText(" ");
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
