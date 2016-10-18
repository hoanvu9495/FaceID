using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NFaceID
{
    public partial class frm_init : Form
    {
        public frm_init()
        {
            InitializeComponent();
        }
        private void FormClose()
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string server = txt_SV.Text;
            string constr = "data source=" + server + ";initial catalog=NFACE;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            _config.ConnectionStrings.ConnectionStrings["DBEntities"].ConnectionString = constr;
            _config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(_config.ConnectionStrings.SectionInformation.Name);
            Properties.Settings.Default.Reload();
            this.Close();

        }
    }
}
