using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                if(textBox1.Text.Length > 0)
                {
                    if(listBox1.Items.Contains(textBox1.Text.Trim().ToLower()))
                    {
                        DialogResult result = MessageBox.Show("Taki element już istnieje. Czy chcesz go dodać ponownie?", "Uwaga!",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(result == DialogResult.No)
                        {
                            textBox1.Text = "";
                            return;
                        }
                    }
                    listBox1.Items.Add(textBox1.Text.Trim().ToLower());
                    ProgressActu();
                    textBox1.Text = "";
                }
                else
                { 
                    MessageBox.Show("Nie wpisałeś wartości...", "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("Lista jest już pełna.", "Błąd", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                       
        }

        private void ProgressActu()
        {
            int amountElements = listBox1.Items.Count;
            progressBar1.Value = amountElements * 10;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int selIndex = listBox1.SelectedIndex;
            if(selIndex != -1)
            {
                listBox1.Items.RemoveAt(selIndex);
                ProgressActu();
            }
            else 
            {
                MessageBox.Show("Nie zaznaczyłeś elementu...", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ProgressActu();
        }
    }
}
