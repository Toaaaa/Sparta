namespace Code
{
    internal class Program
    {
        public static void Main()
        {
            String s;
            s = Console.ReadLine();
            int hp = int.Parse(s);
            //Console.Clear();
            if(hp >=0 && hp <= 1000)
                Console.WriteLine(solution(hp));
        }

        static int solution(int hp)
        {
            int answer = 0;

            answer += hp / 5; 
            hp %= 5;          
            answer += hp / 3; 
            hp %= 3;          
            answer += hp;

            return answer;
        }

    }
}
