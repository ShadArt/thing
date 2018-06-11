using System;
using System.Windows.Forms;

namespace BotBaDoshka
{
    public partial class BotBaDoshkaForm : Form
    {
        public BotBaDoshkaForm()
        {
            InitializeComponent();
        }

        private void RunConsole_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath.ToString() + @"\BotBaDoshkaConsole.exe");
        }
    }
}
