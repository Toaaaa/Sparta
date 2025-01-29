using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        public string? Name { get; set; }
        public Job? Job { get; set; }
        public int Score { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }

        public Player(string? name, Job? job)
        {
            Name = name;
            Job = job;
            Score = 0;
            Attack = 10;
            Defense = 5;
            Health = 100;
            Gold = 1500;
        }

        public void levelUp()
        {
            switch (Job?.Type)
            {
                case Job.JobType.전사:
                    Attack += 10;
                    Defense += 5;
                    Health += 100;
                    break;
                case Job.JobType.도적:
                    Attack += 15;
                    Defense += 3;
                    Health += 50;
                    break;
                case Job.JobType.개발자:
                    Attack += 5;
                    Defense += 10;
                    Health += 70;
                    break;
            }
        }
    }
}
