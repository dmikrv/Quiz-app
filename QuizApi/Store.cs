using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using QuizLibrary.Entities;
using QuizLibrary.Security;
using QuizLibrary.Stores;
using QuizLibrary.Stores.Operations;

namespace QuizApi
{
    public sealed class Store
    {
        private static GeneralStore _instance;
        
        public GeneralStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GeneralStore(new JsonLoader("quiz", "accounts", "results"));

                    _instance.AccountStore_ = _instance.Loader.LoadAccountStore() ?? GenerateAccountStore(new JsonSaver("accounts"));
                    _instance.ResultStore_ = _instance.Loader.LoadResultStore() ?? GenerateResultStore(new JsonSaver("results"));
                    _instance.QuizStore_ = _instance.Loader.LoadQuizStore() ?? GenerateQuizStore(new JsonSaver("quiz"));
                    QuizLibrary.Entities.Quiz.IdInc = (from quiz in _instance.QuizStore_.Quiz select quiz.Id).Max() + 1;

                    _instance.AccountStore_.Saver = new JsonSaver("accounts");
                    _instance.QuizStore_.Saver = new JsonSaver("quiz");
                    _instance.ResultStore_.Saver = new JsonSaver("results");
                }
                return _instance;
            }
        }

        ////////////////////////////////////////////////////

        private AccountStore GenerateAccountStore(ISaveAccountStore saver)
        {
            var accounts = new AccountStore();
            accounts.Saver = saver;
            accounts.Add(new QuizLibrary.Entities.Account("root", "toor", new DateTime(1970, 1, 1)));
            return accounts;
        }

        private ResultStore GenerateResultStore(ISaveResultStore saver)
        {
            var results = new ResultStore();
            results.Saver = saver;
            results.Add(new Result("oleg", "History", 1, 15));
            results.Add(new Result("misha", "Geography", 1, 7));
            results.Add(new Result("dasha", "Maths", 1, 5));
            results.Add(new Result("vika", "Geography", null, 13));
            return results;
        }

        private QuizStore GenerateQuizStore(ISaveQuizStore saver)
        {
            var quizStore = new QuizStore();
            quizStore.Saver = saver;
            var quiz = new QuizLibrary.Entities.Quiz
            {
                Name = "Древний мир и Средние века (русский)",
                AuthorLogin = "root",
                Sections =
                {
                    new Section
                    {
                        Name = "History",
                        Questions =
                        {
                            new Question {
                                Text = "Столица  Древнего Египта",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Вавилон", false), new Answer("Мемфис", true), new Answer("Каир", false) }
                            },
                            new Question {
                                Text = "Как называются гробницы  фараонов Древнего Египта",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("храмы", false), new Answer("пирамиды", true), new Answer("катакомбы", false) }
                            },
                            new Question {
                                Text = "Кому принадлежала верховная власть в Древнем Египте",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("фараону", true), new Answer("вельможам", false), new Answer("жрецам", false) }
                            },
                            new Question {
                                Text = "Какому  фараону была  построена  самая большая  пирамида",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Хеопсу", true), new Answer("Хефрену", false), new Answer("Джосеру", false) }
                            },
                            new Question {
                                Text = "Как  называли  бога Солнца – самого могущественного бога Древнего Египта",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Осирис", false), new Answer("Амон-Ра", true), new Answer("Анубис", false) }
                            },
                            new Question {
                                Text = "Как звали  жену фараона Эхнатона,  скульптура  которой до сих пор является символом красоты, гармонии и естественности",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Хатшепсут", false), new Answer("Нефертити", true), new Answer("Клеопатра", false) }
                            },
                            new Question {
                                Text = "Какой древнегреческий историк назвал Египет «дар Нила»",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Аристотель", false), new Answer("Тацит", false), new Answer("Геродот", true) }
                            },
                            new Question {
                                Text = "Какому богу были посвящены Олимпийские игры в Древней Греции:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Зевсу", true), new Answer("Аполлону", false), new Answer("Посейдону", false) }
                            },
                            new Question {
                                Text = "У какого бога древние греки просили успешного плавания кораблю:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Зевса", false), new Answer("Аполлона", false), new Answer("Посейдона", true) }
                            },
                            new Question {
                                Text = "Рождение греческого театра связано с праздниками в честь бога:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Зевса", false), new Answer("Диониса", true), new Answer("Посейдона", false) }
                            },
                            new Question {
                                Text = "Автором поэм «Илиада» и «Одиссея» был   древнегреческий поэт:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Эсхил", false), new Answer("Гомер", true), new Answer("Аристофан", false) }
                            },
                            new Question {
                                Text = "Какой  знаменитый храм  греческого архитектора находится на вершине афинского Акрополя:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("зиккурат", false), new Answer("Парфенон", true), new Answer("Пантеон", false) }
                            },
                            new Question {
                                Text = "По легенде, братьев Ромула и Рема –  основателей Древнего Рима,  выкормила:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("лиса", false), new Answer("волчица", true), new Answer("медведица", false) }
                            },
                            new Question {
                                Text = "Древний Рим располагался:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("на Пиренейском полуострове", false),
                                    new Answer("на Балканском полуострове", false), new Answer("на Апеннинском полуострове", true) }
                            },
                            new Question {
                                Text = "Как называется огромный амфитеатр Рима, где сражались гладиаторы  и в котором могло находиться  до 50 тысяч зрителей:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Колизей", true), new Answer("Пантеон", false), new Answer("Форум", false) }
                            },
                            new Question {
                                Text = "В честь военных побед полководцев в Древнем Риме воздвигали:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("храмы", false), new Answer("обелиски", false), new Answer("триумфальные арки", true) }
                            },
                            new Question {
                                Text = "Как назывался народ, издавна населявший Англию:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("бритты", true), new Answer("англы", false), new Answer("норманны", false) }
                            },
                            new Question {
                                Text = "К какой королевской династии принадлежал Карл Великий:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("Меровинги", true), new Answer("Каролинги", false), new Answer("Бурбоны", false) }
                            },
                            new Question {
                                Text = "Кого в средние века называли рыцарем:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("королевских приближённых", false), new Answer("крупных феодалов", false),
                                    new Answer("владельцев поместий, нёсших военную службу", true) }
                            },
                            new Question {
                                Text = "Как  в средние века называлось земельное владение, за которое несли военную службу:",
                                IsSeveralCorrectAnswers = false,
                                Answers = { new Answer("оброк", false), new Answer("феод", true), new Answer("титул", false) }
                            },
                        }
                    }
                }
            };
            quizStore.Add(quiz);
            return quizStore;
        }
    }
}
