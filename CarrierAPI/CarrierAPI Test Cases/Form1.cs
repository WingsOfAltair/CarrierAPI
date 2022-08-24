using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarrierAPI;

namespace CarrierAPI_Test_Cases
{
    public partial class Form1 : Form
    {
        CarrierAPIXML.CarrierAPIXMLClient carrierAPIXML = new CarrierAPIXML.CarrierAPIXMLClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShipPackage_Click(object sender, EventArgs e)
        {
            rtbResults.AppendText(carrierAPIXML.PerformShipping(cmbServiceUsed.SelectedIndex, cmbServiceID.SelectedIndex,
                (double)nudWidth.Value, (double)nudHeight.Value, (double)nudLength.Value, (double)nudWeight.Value) + Environment.NewLine);
        }
    }
}
