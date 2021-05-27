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
    public partial class WritingPostForm : Form
    {
        SNSForm sns;
        public WritingPostForm(SNSForm sns)
        {
            InitializeComponent();
            this.sns = sns;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sns.addPost(txtWriting.Text);
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
