class Program
{
    public static void Main(string[] args)
    {
        RockPaperScissors rockPaperScissors = new(new List<string>(args[1..args.Length]));
        if (rockPaperScissors.movements.Count % 2 == 0 || rockPaperScissors.movements.Count <= 1)
        {
            Console.WriteLine("The number of moves must be odd and more than one");
            return;
        }
        if (new HashSet<string>(rockPaperScissors.movements).Count != rockPaperScissors.movements.Count)
        {
            Console.WriteLine("The elements should not be repeated");
            return;
        }

        Help help = new(rockPaperScissors);
        KeyGenerator keyGenerator = new KeyGenerator();
        for (; ; )
        {
            Console.WriteLine("New Game:");
            string moveComputer = rockPaperScissors.MoveComputer();
            keyGenerator.GenerateKey();
            Console.WriteLine("HMAC: " + keyGenerator.GetHMAC(moveComputer));
            rockPaperScissors.PrintMenu();
            string movePlayer = rockPaperScissors.MovePlayer();
            if (movePlayer.Equals("?"))
            {
                help.PrintHelp();
                continue;
            }
            Console.WriteLine("Your move - " + movePlayer);
            Console.WriteLine("Move Computer - " + moveComputer);
            Console.WriteLine("Result - " + rockPaperScissors.GetResultGame(movePlayer, moveComputer));
            Console.WriteLine("HMAC key: " + keyGenerator.key + "\n");

            Console.Write("Продолжить?(y/n) ");
            if("y".Equals(Console.ReadLine()))
            {
                continue;
            }
            break;
        }
    }
}