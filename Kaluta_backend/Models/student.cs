using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Kaluta_backend.Models
{
    public class student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]
        virtual public group? group { get; set; }
        //[System.Text.Json.Serialization.JsonIgnore]
        public int groupId { get; set; }
        public int YearOfBirth { get; set; }
        //public static System.Text.Json.Serialization.ReferenceHandler IgnoreCycles { get; }


        //public student(int ID, string Name, string Surname, group group, int groupId, int YearOfBirth)
        //{
        //    this.ID = ID;
        //    this.Name = Name;
        //    this.group = group;
        //    this.groupId = groupId;
        //    this.Surname = Surname;
        //    this.YearOfBirth = YearOfBirth;
        //}
    }



}