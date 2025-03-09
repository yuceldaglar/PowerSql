using PowerSql.UI.Database;
using PowerSql.UI.Domain;
using PowerSql.UI.Domain.Models;
using PowerSql.UI.Domain.Repositories;
using PowerSql.UI.Library;

namespace PowerSql.Forms
{
    public partial class MainForm : Form
    {
        private readonly ApplicationService _applicationService;

        public MainForm()
        {
            InitializeComponent();

            var db = new JsonDatabase(new FileSystem());
            _applicationService = new ApplicationService(new ConnectionRepository(db), new QueryRepository(db));
            _applicationService.QueryUpdated += QueryUpdated;

            LoadQueries();
        }

        #region Event Handlers

        private void ArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tabPage = NewTab(new ArchiveForm(_applicationService));
            NameUpdated("Archive", tabPage);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            var tabPage = tabControl.SelectedTab;
            if (tabPage != null)
            {
                if (tabPage.Controls[0] is QueryForm queryForm)
                {
                    var query = _applicationService.GetQuery(queryForm.GetId());
                    query.Archived = true;
                    _applicationService.UpdateQuery(query);
                }

                var index = tabControl.SelectedIndex - 1;
                tabControl.TabPages.Remove(tabControl.SelectedTab);
                if (index < tabControl.TabCount)
                {
                    tabControl.SelectedIndex = index;
                }
                closeButton.Visible = tabControl.TabPages.Count != 0;
            }
        }

        private void ConnectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tabPage = NewTab(new ConnectionsForm(_applicationService));
            NameUpdated("Connections", tabPage);
        }

        private void NewQueryFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenQueryForm(Guid.Empty);
        }

        #endregion

        private void LoadQueries()
        {
            foreach (var query in _applicationService.GetQueries())
            {
                if (!query.Archived)
                {
                    OpenQueryForm(query.Id);
                }
            }
        }

        private void NameUpdated(string name, TabPage tabPage)
        {
            if (tabPage == null) return;

            var text = name.Length > 15 ? string.Concat(name.AsSpan(0, 15), "...") : name;
            tabPage.Text = text;
        }

        private TabPage NewTab(Control control)
        {
            control.Dock = DockStyle.Fill;
            closeButton.Visible = true;

            var tabPage = new TabPage();
            tabPage.Controls.Add(control);
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;

            return tabPage;
        }

        private void OpenQueryForm(Guid queryId)
        {
            var queryForm = new QueryForm(_applicationService, queryId);
            var tabPage = NewTab(queryForm);
            NameUpdated(queryForm.GetName(), tabPage);
        }

        private void QueryUpdated(object sender, Query query)
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                if (tabPage.Controls.Count > 0 && tabPage.Controls[0] is QueryForm queryForm)
                {
                    if (queryForm.GetId() == query.Id)
                    {
                        NameUpdated(queryForm.GetName(), tabPage);
                        return;
                    }
                }
            }

            if (!query.Archived)
            {
                OpenQueryForm(query.Id);
            }
        }
    }
}
