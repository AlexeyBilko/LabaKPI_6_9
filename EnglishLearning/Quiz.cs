using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishLearning
{
    class Quiz
    {
        string Question;
        public List<String> Tests;
        int Answer;
        public Quiz(string question, int answer, string test1, string test2, string test3, string test4)
        {
            Tests = new List<string>();
            Question = question;
            Tests.Add(test1);
            Tests.Add(test2);
            Tests.Add(test3);
            Tests.Add(test4);
            Answer = answer;

        }

    }
}
