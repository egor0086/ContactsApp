using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppBL 
{
    /// <summary>
    /// Класс контакт.
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Дата рождения.
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// Е-меил.
        /// </summary>
        private string _email;

        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Ссылка ВКонтакте.
        /// </summary>
        private string _vk;

        /// <summary>
        /// Номер.
        /// </summary>
        public PhoneNumber Number;

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public Contact()
        {
            Number = new PhoneNumber();
        }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Фамилия должна быть меньше 50 символов.");
                }
                else
                {
                    _surname = value;
                }
            }
        }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                
                if (value.Length > 50)
                {
                    throw new ArgumentException("Имя должно быть меньше 50 символов");
                }
                else
                    _name = value;
            }
        }

        /// <summary>
        /// Е-меил.
        /// </summary>
        public string Email
        {
           get { return _email; }
           set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длина Email должна быть менее 50");
                }
                else
                    _email = value;
            }
        }

        /// <summary>
        /// Ссылка ВКонтакте.
        /// </summary>
        public string Vk
        {
           get { return _vk; }
           set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("Длина id vk должна быть менее 15");
                }
                else
                    _vk = value;
            }
        }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("Дата не должна быть больше " + DateTime.Today.ToShortDateString() + ", а была " + value.Date.ToShortDateString());
                }
                else
                    _birthday = value;
            }
        }

        /// <summary>
        /// Клонирование объекта.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var newContact = new Contact();

            newContact.Name = Name;
            newContact.Surname = Surname;
            newContact.Birthday = Birthday;
            newContact.Email = Email;
            newContact.Vk = Vk;
            newContact.Number.Number = Number.Number;

            return newContact;
        }
    }
}
