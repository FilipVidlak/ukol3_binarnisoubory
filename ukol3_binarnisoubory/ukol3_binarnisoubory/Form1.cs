using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ukol3_binarnisoubory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream aktualnisoubor = new FileStream(@"..\..\texty.dat", FileMode.Open, FileAccess.Read);
                BinaryReader precist = new BinaryReader(aktualnisoubor);
                precist.BaseStream.Position = 0;
                while (precist.BaseStream.Position < precist.BaseStream.Length)
                {
                    textBox1.AppendText(Convert.ToString(precist.ReadChar()));
                }
                aktualnisoubor.Close();
                precist.Close();
            } catch
            {
                MessageBox.Show("Něco se nepovedlo!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream prepsanysoubor = new FileStream(@"..\..\texty.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter prepis = new BinaryWriter(prepsanysoubor);
                for (int i = 0; i < textBox1.Lines.Count(); i++)
                {
                    char[] radek = textBox1.Lines[i].ToCharArray();
                    int znak = 0;
                    while (znak < radek.Length)
                    {
                        if (radek[znak] == '.')
                        {
                            radek[znak] = '!';
                            prepis.Write(radek[znak].ToString() + Environment.NewLine);
                        }
                        else
                        {
                            prepis.Write(radek[znak].ToString());
                        }
                        znak++;
                    }
                }
                prepsanysoubor.Close();
                prepis.Close();

                FileStream opravenysoubor = new FileStream(@"..\..\texty.dat", FileMode.Open, FileAccess.Read);
                BinaryReader precist = new BinaryReader(opravenysoubor);
                precist.BaseStream.Position = 0;
                while (precist.BaseStream.Position < precist.BaseStream.Length)
                {
                    textBox2.AppendText(precist.ReadString());
                }
                precist.Close();
                opravenysoubor.Close();
            }
            catch
            {
                MessageBox.Show("Něco se nepovedlo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
