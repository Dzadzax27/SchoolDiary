using DiaryData2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDiary.ConnectiontoBase
{
    public class SubjectsStudent
    {
        public int Id { get; set; }
        public Studenti Student { get; set; }
        public Subjects Subjects { get; set; }
        public int Grade { get; set; }
    }
}
