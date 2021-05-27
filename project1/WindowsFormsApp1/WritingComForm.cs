using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WritingComForm : Form
    {
        SNSForm sns;
        public WritingComForm(SNSForm sns)
        {    
            InitializeComponent();
            this.sns = sns;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sns.addComment(txtComment.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
