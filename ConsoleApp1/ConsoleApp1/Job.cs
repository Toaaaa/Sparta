using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Job
    {
        public JobType Type { get; set; }
        public Job(JobType type)
        {
            Type = type;
        }

        public enum JobType
        {
            전사,
            도적,
            개발자,
        }


    }
}
