using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cpuRAM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            float processorCpu = CPU.NextValue();
            float memoriaRam = RAM.NextValue();
            float logicalDisk = DISK.NextValue();

            circularProgressBar1.Value = (int)processorCpu;
            circularProgressBar1.Text = string.Format("{0:0.00}%", processorCpu);

            circularProgressBar2.Value = (int)memoriaRam;
            circularProgressBar2.Text = string.Format("{0:0.00}%", memoriaRam);

            circularProgressBar3.Value = (int)logicalDisk;
            circularProgressBar3.Text = string.Format("{0:0.00}%", logicalDisk);

            if (memoriaRam >= 75.0 || processorCpu >= 75.0 || logicalDisk >= 90.0) {
                try
                {
                  
                    MySqlConnection objcon = new MySqlConnection("server=localhost; port=3306; User Id=root; database=dbProject; password=rkprado*");
                    objcon.Open();
                    Console.Write("Conectado ao Banco\n");

                    MySqlCommand cmdObj = new MySqlCommand("insert into tblrecursos(memoria_ram, cpu, disco, data_tmp) values (?, ?, ?,now());", objcon);
        
                    cmdObj.Parameters.Add("@memoria_ram", MySqlDbType.Double).Value = memoriaRam;
                    cmdObj.Parameters.Add("@cpu", MySqlDbType.Double).Value = processorCpu;
                    cmdObj.Parameters.Add("@disco", MySqlDbType.Double).Value = logicalDisk;
                    cmdObj.ExecuteNonQuery();
                }

                catch
                {
                    Console.Write("Não conectado!\n");
                }

                /*if (logicalDisk >= 95)
                {
                    Console.WriteLine("Disco: " + string.Format("{0:0.00}%", logicalDisk));
                }
                */
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
             
        }
    }
}
