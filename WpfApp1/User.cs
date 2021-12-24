using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace WpfApp1.database
{
    public class User
    {
        internal object name;
        internal object emailid;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
     
        [MaxLength(12)]
        public string password { get; set; }
        [MaxLength(10)]
        public string  contact{ get; set; }
        public object EmailId { get; internal set; }

        public User()
        {
        }
    }
}
