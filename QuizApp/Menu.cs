using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using QuizApi;
using QuizApi.Account;
using QuizApi.Exceptions;

namespace QuizApp
{
    class Menu
    {
        private Authorizer authorizer;

        public void Entrance()
        {
            Console.Clear();
            int choice = 0;
            Console.Write("1. Authorization\n" +
                    "2. Registration\n" +
                    "3. Exit\n\n" +
                    "Your action -> ");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
            }
            
            switch(choice)
            {
                case 1:
                    Authentication();
                    if (authorizer != null)
                        MainMenu();
                    break;
                case 2:
                    Registration();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }


        private void Authentication()
        {
            Console.Clear();
            Console.Write("Your login -> ");
            var login = Console.ReadLine();
            Console.Write("Your password -> ");
            var password = Console.ReadLine();
            Console.WriteLine();

            try
            {
                Authentication auth = new();
                authorizer = auth.Authenticate(login, password);
                Console.WriteLine("You are successfully logged in");

            }
            catch (NoUserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidUserPasswordException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (RootCannotAuthorizationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nPress any button!");
                Console.ReadKey();
            }
        }
        private void Registration()
        {
            Console.Clear();
            Console.Write("Your login -> ");
            var login = Console.ReadLine();
            Console.Write("Your password -> ");
            var password = Console.ReadLine();
            Console.Write("Your birthday (31.01.1991) -> ");
            var birthday = Console.ReadLine();
            Console.WriteLine();

            try
            {
                Registration registration = new();
                registration.Registry(login, password, DateTime.Parse(birthday));
                Console.WriteLine("You have successfully registered");

            }
            catch (UserAlreadyExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nPress any button!");
                Console.ReadKey();
            }
        }


        private void MainMenu()
        {
            do
            {
                Console.Clear();
                Console.Write("Your account: " + authorizer.Login + "\n\n" +
                    "1. New quiz\n\n" +
                    "2. Statistics\n" +
                    "3. Settings\n" +
                    "4. Log out\n\n" +
                    "Your action -> ");
                int choice = 0;

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                { }

                switch(choice)
                {
                    case 1:
                        NewQuiz();
                        break;
                    case 2:
                        Statistics();
                        break;
                    case 3:
                        Settings();
                        break;
                    case 4:
                        authorizer = null;
                        return;
                }

            } while (true);
        }
        private void Statistics()
        {
            Handbook handbook = new Handbook();
            int choice = 0;
            int i;
            string buffer;

            do
            {
                Console.Clear();
                Console.Write("1. Result of past quizzes\n" +
                    "2. TOP20 users\n" +
                    "3. TOP20 users on a specific quiz\n" +
                    "4. Back\n\n" +
                    "Your action -> ");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                { }
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        foreach (var result in handbook.GetResults())
                        {
                            Console.WriteLine(result.AccountLogin +
                                "   Quiz: " +
                                (result.QuizId != null ? (from quiz in handbook.GetQuiz() where quiz.Id == result.QuizId select quiz.Name).First() : "MIXED") +
                                "   Section: " + result.SectionName + "   Number of correct answer: " + result.NumberCorrectAnswer);
                        }
                        break;
                    case 2:
                        i = 1;
                        var queryTop20Account = (from result in handbook.GetResults()
                                    group result by new { result.AccountLogin, result.NumberCorrectAnswer } into groups
                                    where groups.Key.NumberCorrectAnswer == (from r in handbook.GetResults() 
                                                                             where r.AccountLogin == groups.Key.AccountLogin select r.NumberCorrectAnswer).Max()
                                    orderby groups.Key.NumberCorrectAnswer descending
                                    select new { groups.Key.AccountLogin, groups.Key.NumberCorrectAnswer }).Take(20);

                        foreach (var result in queryTop20Account)
                        {
                            Console.WriteLine((i++) + ". " + result.AccountLogin + "   Result: " + result.NumberCorrectAnswer);
                        }
                        break;
                    case 3:
                        Console.Write("Enter name quiz or id -> ");
                        buffer = Console.ReadLine();
                        int _id = -1;

                        Regex regId = new Regex(@"^[0-9]+$");
                        if (regId.IsMatch(buffer))
                        {
                            _id = int.Parse(buffer);
                            var quizIdQuery = from quiz in handbook.GetQuiz() select quiz.Id;
                            if (!quizIdQuery.Contains(_id))
                            {
                                Console.WriteLine("The is no such id");
                                break;
                            }
                        }
                        else
                        {
                            var quizNameQuery = from quiz in handbook.GetQuiz() select quiz.Name;
                            if (quizNameQuery.Contains(buffer))
                            {
                                _id = (from quiz in handbook.GetQuiz() where quiz.Name == buffer select quiz.Id).First();
                            }
                            else
                            {
                                Console.WriteLine("The is no such quiz name");
                                break;
                            }
                        }

                        i = 1;
                        var queryTop20AccountByQuiz = (from result in handbook.GetResults()
                                                       where result.QuizId == _id
                                                       group result by new { result.AccountLogin, result.NumberCorrectAnswer } into groups
                                                       where groups.Key.NumberCorrectAnswer == (from r in handbook.GetResults()
                                                                                                where r.AccountLogin == groups.Key.AccountLogin
                                                                                                select r.NumberCorrectAnswer).Max()
                                                       orderby groups.Key.NumberCorrectAnswer descending
                                                       select new { groups.Key.AccountLogin, groups.Key.NumberCorrectAnswer }).Take(20);
                        foreach (var result in queryTop20AccountByQuiz)
                        {
                            Console.WriteLine((i++) + ". " + result.AccountLogin + "   Result: " + result.NumberCorrectAnswer);
                        }
                        break;
                    case 4:
                        return;
                    default:
                        break;
                }

                Console.WriteLine("\nPress any button!");
                Console.ReadKey();
            } while (true);
        }
        private void Settings()
        {
            Console.Clear();
            Console.Write("1. Edit password\n" +
                "2. Edit birtday\n" +
                "3. Back\n\n" +
                "Your action -> ");
            int choice = 0;

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            { }
            Console.WriteLine();

            Edit edit = new Edit(authorizer);

            switch(choice)
            {
                case 1:
                    Console.Write("Enter you old password -> ");
                    var oldPass = Console.ReadLine().Trim();
                    Console.Write("Enter new password -> ");
                    var newPass = Console.ReadLine().Trim();

                    try
                    {
                        edit.EditPassword(oldPass, newPass);
                        Console.WriteLine("\nYour password has been changed");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidUserPasswordException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("\nPress any button!");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    Console.Write("Your birthday (31.01.1991) -> ");
                    var birthday = Console.ReadLine();

                    try
                    {
                        edit.EditBirtday(DateTime.Parse(birthday));
                        Console.WriteLine("\nYour birtday has been changed");

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("\nPress any button!");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    return;
                default:
                    break;
            }

        }


        private void NewQuiz()
        {
            Handbook handbook = new Handbook();
            Console.Clear();
            Console.WriteLine("Choice knowledge section:\n");

            var section = ChoiceSection();
            if (section == null)
                return;

            Console.Clear();
            Console.WriteLine("Choice quiz:\n");

            var quizId = ChoiceQuizId();

            IQuiz quiz = new Quiz(section, quizId, authorizer);
            var result = PlayQuiz(quiz);
            Console.Clear();

            Console.WriteLine("Number of correct answer: " + result.NumberCorrectAnswer);
            //var query = from result in handbook.GetResults()
            //            where result.AccountLogin == authorizer.Login
            ////Console.WriteLine("Place in the table: "  + )
            //handbook.GetResults().OrderByDescending(result => result.NumberCorrectAnswer).Last();

            Console.WriteLine("\nPress any button!");
            Console.ReadKey();
        }
        private int? ChoiceQuizId()
        {
            Handbook handbook = new Handbook();

            Console.WriteLine("0. Mixed");
            for (int i = 0; i < handbook.GetQuiz().Count(); i++)
            {
                Console.WriteLine((i + 1) + ". " + handbook.GetQuiz().ElementAt(i).Name);
            }

            int number = -1;
            Console.Write("\nEnter number of quiz -> ");
            try
            {
                number = int.Parse(Console.ReadLine());
                if (number > 0 && number < handbook.GetSections().Count() + 1)
                    return handbook.GetQuiz().ElementAt(number - 1).Id;
                else if (number == 0)
                    return null;
                else
                    throw new IndexOutOfRangeException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPress any button!");
            Console.ReadKey();

            return null;
        }
        private string ChoiceSection()
        {
            Handbook handbook = new Handbook();

            for (int i = 0; i < handbook.GetSections().Count(); i++)
            {
                Console.WriteLine((i+1) + ". " + handbook.GetSections().ElementAt(i));
            }

            int number = -1;
            Console.Write("\nEnter number of quiz -> ");
            try
            {
                number = int.Parse(Console.ReadLine());
                if (number > 0 && number < handbook.GetSections().Count() + 1)
                    return handbook.GetSections().ElementAt(number - 1);
                else
                    throw new IndexOutOfRangeException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPress any button!");
            Console.ReadKey();

            return null;
        }
        private ResultItem PlayQuiz(IQuiz quiz)
        {
            while (quiz.Position != quiz.UpperLimitPosition)
            {
                Console.Clear();
                Console.WriteLine("Answer " + (quiz.Position + 1) + ". " + quiz.Question 
                    + (quiz.IsSeveralCorrectAnswers ? "\n(several correct answers)" : "\n(only one correct answer)"));
                Console.WriteLine();
                for (int i = 0; i < quiz.Answers.Count(); i++)
                {
                    Console.WriteLine((i + 1) + ". " + quiz.Answers.ElementAt(i));
                }
                Console.WriteLine();
                Console.Write("Enter answer numbers (ex: \"1\" or \"1 3 5\") -> ");
                var stringOfNumber = Console.ReadLine();

                Regex regNumber = new Regex(@"[0-9]");
                var matchCollection = regNumber.Matches(stringOfNumber);
                var myAnswers = new List<string>();
                foreach(Match match in matchCollection)
                {
                    myAnswers.Add(quiz.Answers.ElementAt(int.Parse(match.Value) - 1));
                }
                quiz.SetAnswer(myAnswers);

                quiz.NextPosition();
            }
            return quiz.FinishQuiz();
        }
    }
}
