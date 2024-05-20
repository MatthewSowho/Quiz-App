using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App
{
    public static class Operations
    {
        public static void Begin()
        {
            bool endOfLife = true;
            while (endOfLife)
            {

                Console.WriteLine("Select an option \n 1.Create a Quiz \n 2.Take a Quiz \n 3.Add Question \n 4.Remove Question");
                Console.WriteLine("Type EXIT to quit the program");
                string option = Console.ReadLine();


                switch (option.ToUpper())
                {
                    case "1":
                        CreateQuiz();
                        break;

                    case "2":
                        TakeQuiz();
                        break;
                        
                    case "3":
                        AddQuestion();
                        break;

                    case "4":
                        RemoveQuestion();
                        break;

                    case "EXIT":
                        endOfLife = false;
                        break;
                    default:
                        break;
                }
            }
        }
        static List<Question> myQuestions = new List<Question>();

        public static void CreateQuiz()
        {
            Console.WriteLine("How many questions do you want to add?");
            int numberOfQuestions = int.Parse(Console.ReadLine());
            Random random = new Random();
            int ID = random.Next();

            for (int i = 0; i < numberOfQuestions; i++)
            {   
                Question question = new Question();
                question.Options = new string[4];
                
                Console.WriteLine("Type Question " + (i + 1));
                question.Questions = Console.ReadLine();

                for (int option = 0; option < 4; option++)
                {
                    Console.WriteLine("Type option " + (option + 1) );
                    question.Options[option] = Console.ReadLine();
                }

            Console.WriteLine("Which option is correct?(1-4)");
            question.Answer = int.Parse(Console.ReadLine()) - 1;

                question.QuestionID = ID;

                myQuestions.Add(question);

            }
            Console.WriteLine("Question ID= " + ID);

        }

        public static void TakeQuiz()
        {
            int answer = 0;
            int score = 0;

            takeQuiz:
            Console.WriteLine("Input Question ID");
            int ID = int.Parse(Console.ReadLine());

            

            foreach (Question question in myQuestions)
            {
                if(question.QuestionID == ID)
                {
                    Console.WriteLine(question.Questions);
                    Console.WriteLine("Select an Option 1-4");
                    for (int i = 0; i < question.Options.Length; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + (question.Options[i]));
                    }

                    answer = int.Parse(Console.ReadLine());
                    if (answer == question.Answer)
                    {
                        score++;
                    }
                }

                else
                {
                    Console.WriteLine("Input a Valid Question ID");
                    goto takeQuiz;
                }
                
            }
            Console.WriteLine("Quiz Finished");
            Console.WriteLine("Your score is " + score);
        }

        public static void AddQuestion()
        {
            input:
            Console.WriteLine("Input Quiz ID");
            if (!int.TryParse(Console.ReadLine(), out int ID))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                goto input;
            }

            Question question = new Question();
            question.Options = new string[4];

            Console.WriteLine("Type the question");
            question.Questions = Console.ReadLine();

            for (int option = 0; option < 4; option++)
            {
                Console.WriteLine("Type option " + (option + 1));
                question.Options[option] = Console.ReadLine();
            }

            Console.WriteLine("Which option is correct?(1-4)");
            question.Answer = int.Parse(Console.ReadLine()) - 1;

            question.QuestionID = ID;

            myQuestions.Add(question);
            Console.WriteLine("Question added successfully.");
        }

        public static void RemoveQuestion()
        {
            Console.WriteLine("Questions:");
            for (int i = 0; i < myQuestions.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + (myQuestions[i].Questions));
            }

            Console.WriteLine("Input the number of the question to remove");
            int questionNumber = int.Parse(Console.ReadLine());

            if (questionNumber >= 1 && questionNumber <= myQuestions.Count)
            {
                myQuestions.RemoveAt(questionNumber - 1);
                Console.WriteLine("Question removed successfully.");
            }
            else
            {
                Console.WriteLine("Invalid question number.");
            }
        }
    }
}
