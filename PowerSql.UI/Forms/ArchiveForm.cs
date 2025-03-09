using PowerSql.UI.Domain;
using PowerSql.UI.Domain.Models;

namespace PowerSql.Forms
{
    public partial class ArchiveForm : UserControl
    {
        private readonly ApplicationService _applicationService;

        public ArchiveForm(ApplicationService applicationService)
        {
            InitializeComponent();
            _applicationService = applicationService;

            LoadQueries();
        }

        #region Event Handlers

        private void ActivateButton_Click(object sender, EventArgs e)
        {
            if (queriesListBox.SelectedItem == null)
            {
                return;
            }

            var query = (Query)queriesListBox.SelectedItem;
            query.Archived = false;
            _applicationService.UpdateQuery(query);

            LoadQueries();
        }

        private void QueriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayQuery((Query)queriesListBox.SelectedItem);
        }

        #endregion

        private void DisplayQuery(Query query)
        {
            connectionsTextBox.Text = _applicationService.GetConnection(query?.ConnectionId ?? default)?.ToString() ?? "--unknown--";
            queryTextBox.Text = query?.Sql ?? "";
        }

        private void LoadQueries()
        {
            var queries = _applicationService.GetQueries()?.Where((q) => q.Archived)?.ToList();
            queriesListBox.DataSource = queries;
        }
    }
}
