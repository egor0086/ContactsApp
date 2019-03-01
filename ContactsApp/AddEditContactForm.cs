using System;
using System.Windows.Forms;
using ContactsAppBL;

namespace ContactsApp
{
    public partial class AddEditContactForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private Contact _newContact;

        public AddEditContactForm()
        {
            InitializeComponent();

            NewContact = new Contact();
        }

        /// <summary>
        /// 
        /// </summary>
        public Contact NewContact
        {
            get { return _newContact; }
            set
            { 
                _newContact = value;
                EnterData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (NewContact == null)
                NewContact = new Contact();

            if (EnterContact() == null)
                return;

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public void EnterData()
        {
            SurnameTextBox.Text = _newContact.Surname;
            NameTextBox.Text = _newContact.Name;
            EmailTextbox.Text = _newContact.Email;
            VkTextBox.Text = _newContact.Vk;

            if (_newContact.Number.Number != 0)
                PhoneMaskedTextBox.Text = _newContact.Number.Number.ToString();

            if (_newContact.Birthday.Date != DateTime.MinValue)
                BirthdayDateTimePicker.Value = _newContact.Birthday.Date;
        }

        public Contact EnterContact()
        {

            try
            {
                NewContact.Surname = SurnameTextBox.Text;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                NewContact.Name = NameTextBox.Text;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                NewContact.Email = EmailTextbox.Text;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                NewContact.Vk = VkTextBox.Text;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                NewContact.Birthday = BirthdayDateTimePicker.Value.Date;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            string str = PhoneMaskedTextBox.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Replace("+", "");
            
            try
            {
                NewContact.Number.Number = Convert.ToInt64(str.Remove(0, 1));
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return NewContact;
        }
    }
}
