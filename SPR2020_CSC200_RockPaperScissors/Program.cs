using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* SOLID
 * S - SRP - Single Responsibility Principle
 *      An object shouldn have only one purpose
 * O - OCP - Open Closed Principle
 *      An object should be open for extension, closed for modification
 * L - Liskov Substitution Principle
 *      Any object inheriting an interface should implement that interface
 * I - Interface Segregation Principle
 *      An object should expose only what it needs to, and should code to that interface
 * D - Dependency Inversion Principle
*/
namespace CSC200_RockPaperScissors
{
    class Player
    {
        // 
    }

    class Hand
    {
        // data fields
        private readonly string _value;

        // constructor
        public Hand(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return this._value; }
        }
    }

    class Rule
    {
        private readonly string _handA;
        private readonly string _handB;
        private readonly int _compare;

        public Rule(string handA, string handB, int compare)
        {
            _handA = handA;
            _handB = handB;
            _compare = compare;
        }

        public bool canEvaluate(string handA, string handB)
        {
            return _handA == handA && _handB == handB;
        }

        public int CompareTo()
        {
            return _compare;
        }
    }
    
    class HandSelector
    {
        public Hand GetUserHand()
        {
            bool valid = false;
            Hand result = new Hand("");

            while (valid == false)
            {
                Console.WriteLine("Choose R:Rock, P:Paper, S:Scissors, V:Spock, or L:Lizard (Q to Quit).");
                string userChoice = Console.ReadLine();

                // user could enter an empty line
                if (string.IsNullOrEmpty(userChoice))
                    continue;

                // user could enter an invalid value
                switch (userChoice.ToUpper())
                {
                    case "ROCK":
                    case "R":
                        result = new Hand("rock");
                        valid = true;
                        break;
                    case "PAPER":
                    case "P":
                        result = new Hand("paper");
                        valid = true;
                        break;
                    case "SCISSORS":
                    case "S":
                        result = new Hand("scissors");
                        valid = true;
                        break;
                    case "SPOCK":
                    case "V":
                        result = new Hand("spock");
                        valid = true;
                        break;
                    case "LIZARD":
                    case "L":
                        result = new Hand("lizard");
                        valid = true;
                        break;
                    case "QUIT":
                    case "Q":
                        result = new Hand("quit");
                        valid = true;
                        break;
                }

                Console.Clear();
            }

            return result;
        }

        public Hand GetRandomHand()
        {
            // 1 = rock, 2 = paper, 3 = scissors
            Random random = new Random();
            int value = random.Next(1, 3);
            Hand result;

            if (value == 1)
            {
                result = new Hand("rock");
            }
            else if (value == 2)
            {
                result = new Hand("paper");
            }
            else if (value == 3)
            {
                result = new Hand("scissors");
            }
            else if (value == 4)
            {
                result = new Hand("spock");
            }
            else if (value == 5)
            {
                result = new Hand("lizard");
            }
            else
            {
                result = new Hand(string.Empty);
            }

            return result;
        }
    }
    class GameManager
    {
        // data fields

        // constructor

        private ICollection<Rule> _rules = new List<Rule>();
        private HandSelector _handSelector;


        public GameManager(ICollection<Rule> _rules)
        {
            this._rules = _rules;
            _handSelector = new HandSelector();
        }

        // methods
        public void StartPlay()
        {
            // get the hand from the user
            Hand userHand = _handSelector.GetUserHand();
            while (userHand.Value != "quit")
            {
                // get a hand for the computer
                Hand computerHand = _handSelector.GetRandomHand();
                foreach(Rule rule in _rules)
                {
                    if (rule.canEvaluate(userHand.Value, computerHand.Value))
                    {
                        if (rule.CompareTo() > 0)
                        {

                        } else if (rule.CompareTo() < 0)
                        {

                        } else
                        {

                        }
                    }
                }
                
                }

                Console.WriteLine();

                // get the hand from the user
                userHand = _handSelector.GetUserHand();
            }
        }
    class Program
    {
        static void Main(string[] args)
        {

            ICollection<Rule> RPSLS;

            RPSLS = new List<Rule>();
            RPSLS.Add(new Rule("rock", "scissors", 1));
            RPSLS.Add(new Rule("rock", "paper", -1));
            RPSLS.Add(new Rule("rock", "rock", 0));
            RPSLS.Add(new Rule("rock", "lizard", 1));
            RPSLS.Add(new Rule("rock", "spock", -1));

            RPSLS.Add(new Rule("scissors", "paper", 1));
            RPSLS.Add(new Rule("scissors", "rock", -1));
            RPSLS.Add(new Rule("scissors", "scissors", 0));
            RPSLS.Add(new Rule("scissors", "lizard", 1));
            RPSLS.Add(new Rule("scissors", "spock", -1));

            RPSLS.Add(new Rule("paper", "rock", 1));
            RPSLS.Add(new Rule("paper", "scissors", -1));
            RPSLS.Add(new Rule("paper", "paper", 0));
            RPSLS.Add(new Rule("paper", "spock", 1));
            RPSLS.Add(new Rule("paper", "lizard", -1));

            RPSLS.Add(new Rule("lizard", "spock", 1));
            RPSLS.Add(new Rule("lizard", "rock", -1));
            RPSLS.Add(new Rule("lizard", "lizard", 0));
            RPSLS.Add(new Rule("lizard", "paper", 1));
            RPSLS.Add(new Rule("lizard", "scissors", -1));

            RPSLS.Add(new Rule("spock", "rock", 1));
            RPSLS.Add(new Rule("spock", "lizard", -1));
            RPSLS.Add(new Rule("spock", "spock", 0));
            RPSLS.Add(new Rule("spock", "scissors", 1));
            RPSLS.Add(new Rule("spock", "paper", -1));

            ICollection<Rule> RPS;

            RPS = new List<Rule>();
            RPS.Add(new Rule("rock", "scissors", 1));
            RPS.Add(new Rule("rock", "paper", -1));
            RPS.Add(new Rule("rock", "rock", 0));

            RPS.Add(new Rule("scissors", "paper", 1));
            RPS.Add(new Rule("scissors", "rock", -1));
            RPS.Add(new Rule("scissors", "scissors", 0));

            RPS.Add(new Rule("paper", "rock", 1));
            RPS.Add(new Rule("paper", "scissors", -1));
            RPS.Add(new Rule("paper", "paper", 0));

            GameManager manager = new GameManager(RPSLS);
            
            manager.StartPlay();

            Console.ReadLine();
        }
    }
}
