using System.Collections.Generic;

namespace EnglishLearning
{
    class Quiz
    {
        public string Question { get; set; }
        public List<string> Answers;
        public int CorrectAnswer { get; set; }

        public Quiz(string question, string answer1, string answer2, string answer3, string answer4, int correctAnswer)
        {
            Answers = new List<string>();
            Question = question;
            Answers.Add(answer1);
            Answers.Add(answer2);
            Answers.Add(answer3);
            Answers.Add(answer4);
            CorrectAnswer = correctAnswer;
        }
    }
}
