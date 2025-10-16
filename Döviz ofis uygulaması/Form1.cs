using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace Döviz_ofis_uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);
            string dolaralis=xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lbldol1.Text = dolaralis;
            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
           lbldol2.Text= dolarsatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lbleusat.Text = euroalis;
            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbleual.Text = eurosatis;
        }

        private void btndolaral_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldol1.Text;
        }

        private void btndolarsat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldol2.Text;
        }

        private void btneuroal_Click(object sender, EventArgs e)
        {
            txtkur.Text=lbleual.Text;
        }

        private void btneurosat_Click(object sender, EventArgs e)
        {
            txtkur.Text=lbleusat.Text;
        }

        private void btnislem_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur=Convert.ToDouble(txtkur.Text);
            miktar=Convert.ToDouble(txtmiktar.Text);
            tutar = miktar * kur;
            txttutar.Text=tutar.ToString();
        }
    }
}
