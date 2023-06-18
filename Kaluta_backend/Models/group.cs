using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Kaluta_backend.Models
{
    public class group
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public string Department { set; get; }
        [System.Text.Json.Serialization.JsonIgnore]
        public List<student>? students { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public int universityid { get; set; }
        virtual public university? university { get; set; }
        //public static System.Text.Json.Serialization.ReferenceHandler IgnoreCycles { get; }
        //public int Yearbirth { set; get; }

        //public group(int Id, string Title, string Department, List<student> students, int universityid, university university)
        //{
        //    this.Id = Id;
        //    this.Title = Title;
        //    this.Department = Department;
        //    this.students = students;
        //    this.students = students;
        //}

        internal void Addgroup(group? group)
        {
            throw new NotImplementedException();
        }
    }
}