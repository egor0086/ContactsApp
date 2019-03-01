using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppBL
{
    /// <summary>
    /// Класс проекта.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Поле хронящее список контактов.
        /// </summary>
        public List<Contact> Contacts;

        public Project()
        {
            Contacts = new List<Contact>();
        }
    }
}
