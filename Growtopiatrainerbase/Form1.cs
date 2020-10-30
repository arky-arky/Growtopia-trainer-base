using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace Growtopiatrainerbase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Mem m = new Mem(); // basically whats we are gonna use

        private void button1_Click(object sender, EventArgs e)
        {
            m.WriteMemory("Growtopia.exe+005E7D28,B60,278", "int", textBox1.Text); // an example use of pointer
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                m.WriteMemory("Growtopia.exe+DF960", "bytes", "0x90 0x90 0x90 0x90"); // client side enable
                m.WriteMemory("Growtopia.exe+16FB56", "bytes", "0x90 0x90 0x90 0x90 0x90"); // server side enable
            }
            else
            {
                m.WriteMemory("Growtopia.exe+DF960", "bytes", "0xF3 0x0F 0x11 0x11"); // client side disable
                m.WriteMemory("Growtopia.exe+16FB56", "bytes", "0xF3 0x0F 0x11 0x53 0x20"); // server side disable
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m.OpenProcess("Growtopia");
            m.WriteMemory("Growtopia.exe+24698B", "bytes", "0x74 0x08"); // banbypass so we wont get banned
            m.WriteMemory("Growtopia.exe+3220E3", "bytes", "0x90 0x90"); // anti client ban so we wont get banned on client side
            m.WriteMemory("Growtopia.exe+32D94E", "bytes", "0xE9 0x19 0x01 0x00 0x00"); // Position ban bypass so we wont get banned when changing player position
        }
    }
}
