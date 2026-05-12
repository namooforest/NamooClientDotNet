using DevExpress.XtraEditors;
using Namoo.Frame;
using Namoo.Frame.DataObject.DTO;

namespace Namoo.Client.UserControls
{
    public partial class DbConnector : ComboBoxEdit
    {
        public DbConnector()
        {
            InitializeComponent();
            if (NaFunctions.IsInDesignMode(this) == false)
                LoadData();
        }

        public void LoadData()
        {
            this.Properties.Items.Clear();
            this.Properties.AutoHeight = false;
            NaClientConfig.GetConnectorList().ForEach(conn => this.Properties.Items.Add(conn.ConnectorName));
        }

        /// <summary>선택된 커넥터 이름 반환</summary>
        public string GetSelectedConnectorName()
        {
            if (this.SelectedItem == null)
                return null;

            return this.SelectedItem.ToString();
        }

        /// <summary>선택된 커넥터 반환</summary>
        public NaConnector GetSelectedConnector()
        {
            var connectorName = GetSelectedConnectorName();
            if (string.IsNullOrEmpty(connectorName))
                return null;

            return NaClientConfig.GetConnector(connectorName);
        }
    }
}
