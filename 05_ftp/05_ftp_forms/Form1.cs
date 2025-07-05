using FluentFTP;

namespace _05_ftp_forms
{
    public partial class Form1 : Form
    {
        private FtpClient? ftpClient = null;
        private Stack<string> history = new Stack<string>();
        string root = "";
        string currentDirectory = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateList(string[] items)
        {
            if (history.Count > 0)
            {
                items = items.Prepend("..").ToArray();
            }
            listBoxItems.Items.Clear();
            listBoxItems.Items.AddRange(items);
        }

        private void LoadData()
        {
            var items = ftpClient?.GetListing(currentDirectory);
            if (items == null)
            {
                MessageBox.Show("Failed to retrieve items from FTP server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] names = items
                .Select(i => i.Name)
                .ToArray();
            UpdateList(names);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string host = textBoxHost.Text;
            string user = textBoxUser.Text;
            string password = textBoxPassword.Text;

            try
            {
                ftpClient = new FtpClient(host, user, password);
                ftpClient.Connect();
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Back()
        {
            if (history.Count > 0)
            {
                currentDirectory = history.Pop();
                LoadData();
            }
        }

        private void OpenDirectory(string name)
        {
            history.Push(currentDirectory);
            currentDirectory += name + "/";
            LoadData();
        }

        private void FindItem(string name)
        {
            var items = ftpClient?.GetListing(currentDirectory);
            if (items != null)
            {
                var item = items.FirstOrDefault(i => i.Name == name);
                if (item != null)
                {
                    if (item.Type == FtpObjectType.Directory)
                    {
                        OpenDirectory(item.Name);
                    }
                    else if (item.Type == FtpObjectType.File)
                    {
                        var sfd = new SaveFileDialog();
                        sfd.FileName = item.Name;
                        sfd.Filter = "All files (*.*)|*.*";
                        var result = sfd.ShowDialog();
                        if(result == DialogResult.OK)
                        {
                            ftpClient?.DownloadFile(sfd.FileName, item.FullName);
                        }
                    }
                }
            }
        }

        private void listBoxItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var selectedItem = listBoxItems.SelectedItem;
            if (selectedItem != null)
            {
                string name = selectedItem.ToString() ?? string.Empty;
                if (name == "..")
                {
                    Back();
                }
                else
                {
                    FindItem(name);
                }
            }
        }

        private void btnCreateDir_Click(object sender, EventArgs e)
        {
            string dirName = textBoxDirName.Text.Trim();
            if (string.IsNullOrEmpty(dirName))
            {
                MessageBox.Show("Directory name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ftpClient?.CreateDirectory(currentDirectory + dirName);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
