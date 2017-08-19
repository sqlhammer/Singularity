using System;
using System.Windows.Forms;
using CombatScript;

namespace TestGUI
{
    public partial class frmTester : Form
    {
        public frmTester()
        {
            InitializeComponent();
        }

        public void Run()
        {
            string script = txtScript.Text;
            string errorMsg = null;

            try
            {
                Interpreter.Instance.Process(script);
            }
            catch (ArgumentException exc)
            {
                errorMsg = exc.Message;
            }
            
            string output = Interpreter.Instance.Output;
            if (!string.IsNullOrWhiteSpace(output))
            {
                txtOutput.Text = output;
            }
            if (!string.IsNullOrWhiteSpace(errorMsg))
            {
                txtOutput.Text = txtOutput.Text + Environment.NewLine + errorMsg;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Run();
        }
    }
}
