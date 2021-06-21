using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CaseOffice
{
    public partial class RibbonElement
    {
        private void RibbonElement_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void buttonCase_Click(object sender, RibbonControlEventArgs e)
        {
            Window window = new Window();
            window.Show();
        }
    }
}
