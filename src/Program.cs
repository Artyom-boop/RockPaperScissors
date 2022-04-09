class Program
{
    public static void Main(string[] args)
    {
        RockPaperScissors rockPaperScissors = new(new List<string>(args[1..args.Length]));
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

        }
    }
}