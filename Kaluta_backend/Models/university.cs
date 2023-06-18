using static System.Reflection.Metadata.BlobBuilder;
using Kaluta_backend.Models;
namespace Kaluta_backend.Models
{
    public class university
    {
        public int id { get; set; }
        public List<group>? groups { get; set; }
        //public List<student>? student { get; set; }

        public university()
        {
            //student = new List<student>();
            groups = new List<group>();
        }

        //public university(List<group>? group)
        //{
        //    this.id = id;
        //    this.group = group;
        //    this.student = student;
        //}
    }
}