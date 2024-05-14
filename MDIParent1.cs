using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        private readonly QL_Tài_Khoản___Khách_Hàng_Thân_Thiết ___Khách_Hàng_Thân_Thiết;

        public MDIParent1()
        {
            InitializeComponent();
            ___Khách_Hàng_Thân_Thiết = new QL_Tài_Khoản___Khách_Hàng_Thân_Thiết();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {

        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }



        //private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.Cascade);
            
        //}

        //private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.TileVertical);
        //}

        //private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.TileHorizontal);
        //}

        //private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    LayoutMdi(MdiLayout.ArrangeIcons);
        //}

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void viewMenu_Click(object sender, EventArgs e)
        {

        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýThôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ___Khách_Hàng_Thân_Thiết.Show();
            }
            catch 
            {

            }
  
            
        }
    }
}
