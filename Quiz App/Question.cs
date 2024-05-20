using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App
{
    public class Question
    {
        public string Questions { get; set; }
        public string[] Options { get; set; }

        public int Answer { get; set; }
        public int QuestionID { get; set; }
    }
}
