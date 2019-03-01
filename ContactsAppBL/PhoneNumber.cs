using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppBL
{
    /// <summary>
    /// Класс номера телефона.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Создание приватной переменной номера телефона.
        /// </summary>
        private long _number;

        /// <summary> 
        /// Возвращает и задает номер телефона.
        /// </summary>
        public long Number
        {
            get { return _number; }
            set
            {
           
                if (value.ToString() == string.Empty)
                {
                    throw new ArgumentException("Поле номера телефона не может быть пустым.");
                }
                else if (value.ToString().Length > 11)
                {
                    throw new ArgumentException("Длина номера телефона должна быть меньше 11.");
                }

                _number = value;
            }
        }

    }
}
