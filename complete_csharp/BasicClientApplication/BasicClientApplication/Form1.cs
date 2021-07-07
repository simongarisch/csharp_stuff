using System;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BasicClientApplication
{
    public partial class MainForm : Form
    {
        MyWebReference.BasicWebService proxy = new MyWebReference.BasicWebService();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string countriesJson = proxy.Countries();
            DataTable dtCountries = JsonConvert.DeserializeObject<DataTable>(countriesJson);
            dataGridView1.DataSource = dtCountries;
        }
    }
}
