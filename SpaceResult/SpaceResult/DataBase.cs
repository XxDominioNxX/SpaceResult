using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace SpaceResult
{
    public class DataBase : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
