using PowerSql.UI.Domain;
using PowerSql.UI.Domain.Models;

namespace PowerSql.Forms
{
    public partial class ConnectionsForm : UserControl
    {
        private readonly ApplicationService _applicationService;

        public ConnectionsForm(ApplicationService applicationService)
        {
            InitializeComponent();
            this.Text = "Connections";

            _applicationService = applicationService;

            LoadConnections();
            if (connectionsListBox.Items.Count > 0)
            {
                connectionsListBox.SelectedIndex = 0;
            }
            else
            {
                DisplayConnection(null);
            }
        }

        #region Event Handlers

        private void ConnectionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayConnection((Connection)connectionsListBox.SelectedItem);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var index = connectionsListBox.SelectedIndex;
            var connection = (Connection)connectionsListBox.SelectedItem;
            _applicationService.DeleteConnection(connection);
            connectionsListBox.Items.Remove(connection);
            if (connectionsListBox.Items.Count > 0)
            {
                connectionsListBox.SelectedIndex = Math.Min(index, connectionsListBox.Items.Count - 1);
            }
        }

        private void NewConnectionButton_Click(object sender, EventArgs e)
        {
            var connection = new Connection();
            _applicationService.AddConnection(connection);
            connectionsListBox.Items.Add(connection);
            connectionsListBox.SelectedItem = connection;
        }

        private void SaveConnectionButton_Click(object sender, EventArgs e)
        {
            var connection = (Connection)connectionsListBox.SelectedItem;
            connection.Database = databaseTextBox.Text;
            connection.IntegratedSecurity = integratedSecurityCheckBox.Checked;
            connection.Password = passwordTextBox.Text;
            connection.Server = serverTextBox.Text;
            connection.Username = usernameTextBox.Text;

            _applicationService.UpdateConnection(connection);

            connectionsListBox.SelectedIndexChanged -= ConnectionsListBox_SelectedIndexChanged;
            int selectedIndex = connectionsListBox.SelectedIndex;
            connectionsListBox.Items[selectedIndex] = connection;
            connectionsListBox.SelectedIndexChanged += ConnectionsListBox_SelectedIndexChanged;
        }

        #endregion

        private void DisplayConnection(Connection connection)
        {
            var connectionExists = connection != null;

            databaseTextBox.Enabled = connectionExists;
            integratedSecurityCheckBox.Enabled = connectionExists;
            passwordTextBox.Enabled = connectionExists;
            serverTextBox.Enabled = connectionExists;
            usernameTextBox.Enabled = connectionExists;

            saveConnectionButton.Enabled = connectionExists;

            if (connection != null)
            {
                databaseTextBox.Text = connection.Database;
                integratedSecurityCheckBox.Checked = connection.IntegratedSecurity;
                passwordTextBox.Text = connection.Password;
                serverTextBox.Text = connection.Server;
                usernameTextBox.Text = connection.Username;
            }
            else
            {
                databaseTextBox.Text = "";
                integratedSecurityCheckBox.Checked = false;
                passwordTextBox.Text = "";
                serverTextBox.Text = "";
                usernameTextBox.Text = "";
            }
        }

        private void LoadConnections()
        {
            var connections = _applicationService.GetConnections();
            connectionsListBox.Items.AddRange(connections);
        }
    }
}
