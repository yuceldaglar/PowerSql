using Microsoft.IdentityModel.Tokens;
using PowerSql.UI.Domain;
using PowerSql.UI.Domain.Models;
using System.Data;

namespace PowerSql.Forms
{
    public partial class QueryForm : UserControl
    {
        private readonly ApplicationService _applicationService;
        private DataSet _dataSet;
        private Query _query;

        public QueryForm(ApplicationService applicationService, Guid queryId)
        {
            InitializeComponent();
            _applicationService = applicationService;
            LoadConnections();
            LoadQuery(queryId);
            LoadDatabases();
            DisplayQuery(_query);

            applicationService.ConnectionsUpdated += ApplicationService_ConnectionsUpdated;
            nameTextBox.TextChanged += NameTextBox_TextChanged;
        }

        #region Event Handlers

        private void ApplicationService_ConnectionsUpdated(object sender, EventArgs e)
        {
            LoadConnections();
            SetConnection(_query.ConnectionId);
        }

        private void ConnectionsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _query.ConnectionId = ((Connection)connectionsCombo.SelectedItem).Id;
            _applicationService.UpdateQuery(_query);

            LoadDatabases();
            SetDatabase(_query.Database);
        }

        private void DatabaseCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _query.Database = databaseCombo.SelectedItem.ToString();
            _applicationService.UpdateQuery(_query);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            var sql = queryTextBox.Text;
            var connectionId = ((Connection)connectionsCombo.SelectedItem).Id;
            var result = _applicationService.ExecuteQuery(sql, connectionId, _query.Database);
            messagesTextBox.Text = string.Join(Environment.NewLine, result.Item2);
            ShowResult(result.Item1);
        }

        private void TablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dataSet != null && _dataSet.Tables.Count > 0)
            {
                queryDataGridView.DataSource = _dataSet.Tables[tablesComboBox.SelectedIndex];
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            _query.Name = nameTextBox.Text;
            _applicationService.UpdateQuery(_query);
        }

        private void QueryTextBox_TextChanged(object sender, EventArgs e)
        {
            _query.Sql = queryTextBox.Text;
            _applicationService.UpdateQuery(_query);
        }

        #endregion

        private void DisplayQuery(Query query)
        {
            connectionsCombo.SelectedIndexChanged -= ConnectionsCombo_SelectedIndexChanged;
            databaseCombo.SelectedIndexChanged -= DatabaseCombo_SelectedIndexChanged;
            nameTextBox.TextChanged -= NameTextBox_TextChanged;
            queryTextBox.TextChanged -= QueryTextBox_TextChanged;

            nameTextBox.Text = query.Name;
            queryTextBox.Text = query.Sql;
            SetConnection(query.ConnectionId);
            SetDatabase(query.Database);

            databaseCombo.SelectedIndexChanged += DatabaseCombo_SelectedIndexChanged;
            connectionsCombo.SelectedIndexChanged += ConnectionsCombo_SelectedIndexChanged;
            nameTextBox.TextChanged += NameTextBox_TextChanged;
            queryTextBox.TextChanged += QueryTextBox_TextChanged;
        }

        public Guid GetId()
        {
            return _query.Id;
        }

        public string GetName()
        {
            return _query.Name;
        }

        private void LoadConnections()
        {
            connectionsCombo.SelectedIndexChanged -= ConnectionsCombo_SelectedIndexChanged;
            connectionsCombo.Items.Clear();
            connectionsCombo.Items.AddRange(_applicationService.GetConnections());
            connectionsCombo.SelectedIndexChanged += ConnectionsCombo_SelectedIndexChanged;
        }

        private void LoadDatabases()
        {
            databaseCombo.SelectedIndexChanged -= DatabaseCombo_SelectedIndexChanged;
            databaseCombo.Items.Clear();
            if (_query.ConnectionId != Guid.Empty)
            {
                databaseCombo.Items.AddRange(_applicationService.GetDatabaseNames(_query.ConnectionId));
            }
            databaseCombo.SelectedIndexChanged += DatabaseCombo_SelectedIndexChanged;
        }

        private void LoadQuery(Guid queryId)
        {
            if (queryId == Guid.Empty)
            {
                _query = new Query
                {
                    Name = "New Query"
                };
                _applicationService.AddQuery(_query);
            }
            else
            {
                _query = _applicationService.GetQuery(queryId);
            }

            this.Text = _query.Name;
        }

        private void SetConnection(Guid connectionId)
        {
            if (connectionId != Guid.Empty)
            {
                foreach (var item in connectionsCombo.Items)
                {
                    if (((Connection)item).Id == connectionId)
                    {
                        connectionsCombo.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void SetDatabase(string database)
        {
            if (!database.IsNullOrEmpty())
            {
                foreach (var item in databaseCombo.Items)
                {
                    if (item.ToString() == database)
                    {
                        databaseCombo.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void ShowResult(DataSet dataSet)
        {
            _dataSet = dataSet;

            tablesComboBox.SelectedIndexChanged -= TablesComboBox_SelectedIndexChanged;
            tablesComboBox.Items.Clear();
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                if (dataSet.Tables.Count > 1)
                {
                    var tableNames = new List<string>();
                    for (int i = 0; i < dataSet.Tables.Count; i++)
                    {
                        tablesComboBox.Items.Add($"Table {i + 1}");
                    }
                    tablesComboBox.SelectedIndex = 0;
                    resultPanel.Visible = true;
                    tablesComboBox.SelectedIndexChanged += TablesComboBox_SelectedIndexChanged;
                }
                else
                {
                    resultPanel.Visible = false;
                }

                queryDataGridView.DataSource = dataSet.Tables[0];
            }
            else
            {
                queryDataGridView.DataSource = null;
            }
        }
    }
}
