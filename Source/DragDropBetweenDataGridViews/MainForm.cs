using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                object[] a = {  (3 * i).ToString(), (3 * i + 1).ToString(), (3 * i + 2).ToString() };
                source_DataGridView.Rows.Add(a);
            }

            for (int i = 1; i <= 2; i++)
            {
                object[] a = { (10 * i).ToString(), (10 * i + 1).ToString(), (10 * i + 2).ToString() };
                destination_DataGridView.Rows.Add(a);
            }
        }

        private void sourceDataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //This is the trick part. With this 'info', you can decide which cell you dropped.
            DataGridView.HitTestInfo info = source_DataGridView.HitTest(e.X, e.Y);

            List<string> a = new List<string>();
            a.Add(source_DataGridView.Rows[info.RowIndex].Cells[0].Value.ToString());
            a.Add(source_DataGridView.Rows[info.RowIndex].Cells[1].Value.ToString());
            a.Add(source_DataGridView.Rows[info.RowIndex].Cells[2].Value.ToString());

            source_DataGridView.DoDragDrop(a, DragDropEffects.Move);
            source_DataGridView.Rows.RemoveAt(info.RowIndex);
        }

        private void Dest_DataGridView2_DragEnter(object sender, DragEventArgs e)
        {
            bool bIsList = (e.Data.GetDataPresent(typeof(List<string>)) == true);
            if (bIsList)
                e.Effect = DragDropEffects.Move;
        }

        private void Dest_DataGridView2_DragDrop(object sender, DragEventArgs e)
        {
            List<string> robj = (List<string>)e.Data.GetData(typeof(List<string>));
            object[] b = { robj[0], robj[1], robj[2] };
            destination_DataGridView.Rows.Add(b);
        }
    }
}
