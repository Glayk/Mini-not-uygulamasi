using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void yENİDOSYAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void aÇToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.OpenRead(ofd.FileName));
                richTextBox1.Text = read.ReadToEnd();
                read.Dispose();
            }
        }

        private void kAYDETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Unicode))
                {
                    sw.WriteLine("Test satırı");
                    sw.WriteLine(richTextBox1.Text);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.OpenRead(ofd.FileName));
                richTextBox1.Text = read.ReadToEnd();
                read.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Unicode))
                {
                    sw.WriteLine("Test satırı");
                    sw.WriteLine(richTextBox1.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void aRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.DeselectAll();
            Color evenColor = Color.Red;
            MatchCollection matches = Regex.Matches(richTextBox1.Text, toolStripTextBox1.Text);
            int matchCount = 0;
            foreach (Match match in matches)
            {
                richTextBox1.Select(match.Index, match.Length);
                matchCount++;
                richTextBox1.SelectionColor = evenColor;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(richTextBox1.Text);
            }
            catch
            {
                MessageBox.Show("Boş alan kopyalanamaz!");
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + Clipboard.GetText();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            float zoom = richTextBox1.ZoomFactor;
            if (zoom * 2 < 64)
                richTextBox1.ZoomFactor = zoom * 2;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            float zoom = richTextBox1.ZoomFactor;
            if (zoom / 2 > 0.015625)
                richTextBox1.ZoomFactor = zoom / 2;
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenu contextMenu = new System.Windows.Forms.ContextMenu();
                MenuItem menuItem = new MenuItem("Kes");
                menuItem.Click += new EventHandler(Kesme);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Kopyala");
                menuItem.Click += new EventHandler(Kopyalama);
                contextMenu.MenuItems.Add(menuItem);
                menuItem = new MenuItem("Yapıştır");
                menuItem.Click += new EventHandler(Yapistirma);
                contextMenu.MenuItems.Add(menuItem);

                richTextBox1.ContextMenu = contextMenu;
            }
        }
        void Kesme(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        void Kopyalama(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Rtf, richTextBox1.SelectedRtf);
            Clipboard.Clear();
        }
        void Yapistirma(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                richTextBox1.SelectedRtf = Clipboard.GetData(DataFormats.Rtf).ToString();
            }
        }

        private void hAKKINDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                Form2 yeniform = new Form2();
                yeniform.Show();
            }
        }
    }
}
