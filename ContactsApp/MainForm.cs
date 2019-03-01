using System;
using System.Windows.Forms;
using ContactsAppBL;

namespace ContactsApp
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private Project _project;

        // <summary>
        /// Поле для хранения пути файла.
        /// </summary>
        private readonly string _address = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\ContactApp.json";

        public MainForm()
        {
            InitializeComponent();

            _project = new Project();

            _project = ProjectManager.LoadFromFile(_address);
            ShowListBoxContact();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowListBoxContact()
        {
            ContactListBox.Items.Clear();
            ClearAll();

            if (_project.Contacts.Count <= 0)
                return;

            foreach (Contact t in _project.Contacts)
            {
                ContactListBox.Items.Add(t.Surname);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearAll()
        {
            SurnameTextBox.Text = "";
            NameTextBox.Text = "";
            EmailTextBox.Text = "";
            VkTextBox.Text = "";
            PhoneMaskedTextBox.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        private void ContactListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ContactListBox.SelectedIndex < 0)
                return;

            var contact = _project.Contacts;
            var selectIndex = ContactListBox.SelectedIndex;

            SurnameTextBox.Text = contact[selectIndex].Surname;
            NameTextBox.Text = contact[selectIndex].Name;
            EmailTextBox.Text = contact[selectIndex].Email;
            VkTextBox.Text = contact[selectIndex].Vk;
            BirthdayDateTimePicker.Value = contact[selectIndex].Birthday.Date;
            PhoneMaskedTextBox.Text = contact[selectIndex].Number.Number.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddContactButton_Click(object sender, EventArgs e)
        {
            MethAddContact();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContactButton_Click(object sender, EventArgs e)
        {
            MethEditContact();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            MethRemoveContact();
        }

        public void MethAddContact()
        {
            var addContactForm = new AddEditContactForm();

            addContactForm.ShowDialog();

            if (addContactForm.DialogResult == DialogResult.OK)
            {
                _project.Contacts.Add(addContactForm.NewContact);
                ContactListBox.Items.Add(addContactForm.NewContact.Surname);

                ProjectManager.SaveToFile(_project ,_address);
            }
        }

        public void MethEditContact()
        {
            if (ContactListBox.SelectedItem == null)
            {
                MessageBox.Show("Контакт не выбран!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var addContactForm = new AddEditContactForm();
            var selectContact = _project.Contacts[ContactListBox.SelectedIndex];

            addContactForm.NewContact = selectContact;
            addContactForm.ShowDialog();

            ProjectManager.SaveToFile(_project, _address);

            ShowListBoxContact();
        }

        public void MethRemoveContact()
        {
            if (ContactListBox.SelectedItem == null)
            {
                MessageBox.Show("Контакт не выбран!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = new System.Windows.Forms.DialogResult();
            result = MessageBox.Show("Вы точно хотите удалить контакт: " + ContactListBox.Items[ContactListBox.SelectedIndex],
                "Удаление контакта", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                var selectContact = _project.Contacts[ContactListBox.SelectedIndex];

                _project.Contacts.Remove(selectContact);
                ContactListBox.Items.Remove(selectContact);

                ProjectManager.SaveToFile(_project, _address);

                ShowListBoxContact();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MethAddContact();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MethEditContact();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MethRemoveContact();
        }
    }
}
