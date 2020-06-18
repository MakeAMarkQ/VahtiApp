using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace VahtiApp
{
    public partial class FrmVahti : Form
    {
        //Hilma clHilma = new Hilma();
        //PienHankinta clPienHankinta = new PienHankinta();
        TarjousPalvelu clPienHankinta = new TarjousPalvelu();
        public FrmVahti()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            String source = ("viewsource.txt");
            StreamWriter writer = File.CreateText(source);
            writer.Write(webBrowser1.Document.Body.InnerHtml);
            writer.Close();
            Process.Start("notepad.exe", source);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            webBrowser1.Navigate(textBox1.Text);
        }

        private void FrmVahti_Shown(object sender, EventArgs e)
        {
            ///Lataa olemassaolevat kansiot
            bool bOk = clPienHankinta.LataaTiedot(clPienHankinta.Tallenne()); 
            Trace.WriteLine($"Pientarjoukset LataaTiedot {bOk}");
            RTbx_VahtiLog.AppendText(Environment.NewLine + $"Pientarjoukset LataaTiedot {bOk}");
        }

        private void TSMIA_Etusivut_Click(object sender, EventArgs e)
        {
            //Hilma clHilma = new Hilma();
            //clHilma.HaeEtusivu();
            //Console.ReadLine();
            
            Trace.WriteLine("Alku");
            RTbx_VahtiLog.AppendText(Environment.NewLine + "Alku");
            string strEHWReq = "Ohi";
            bool bOk = clPienHankinta.GetWebPage();
            Trace.WriteLine($"GetWebPage {bOk}");
            RTbx_VahtiLog.AppendText(Environment.NewLine + $"GetWebPage {bOk}");
            if (bOk) bOk = clPienHankinta.PuraEtusivu();
            RTbx_VahtiLog.AppendText(Environment.NewLine + $"PuraEtusivu {bOk} sivuja {clPienHankinta.sivuja()}");
            Trace.WriteLine($"PuraEtusivu {bOk} sivuja {clPienHankinta.sivuja()}");
            if (bOk) bOk = clPienHankinta.PuraAlaSivut();
            RTbx_VahtiLog.AppendText(Environment.NewLine + $"PuraAlaSivut {bOk}");
            Trace.WriteLine($"PuraAlaSivut {bOk}");
            //Console.WriteLine("strEHWReq");
            //clPienHankinta.lstTajoukset.Sort();
            //foreach (var clTar in clPienHankinta.lstTajoukset)
            //{
            //    Console.WriteLine(clTar);
            //}
        }
    }
}
