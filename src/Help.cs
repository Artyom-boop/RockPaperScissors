class Help
{
    RockPaperScissors rockPaperScissors;

    public Help(RockPaperScissors rockPaperScissors)
    {
        this.rockPaperScissors = rockPaperScissors;
    }
  
    public void PrintHelp()
    {
        Console.Write("               |");
        foreach (string player in rockPaperScissors.movements)
        {
            Console.Write("{0,15}|", player);
        }
        Console.WriteLine();
        foreach (string player in rockPaperScissors.movements)
        {
            Console.Write("{0,15}|", player);
            foreach (string computer in rockPaperScissors.movements)
            {
                Console.Write("{0,15}|", rockPaperScissors.GetResultGame(player, computer));
            }
            Console.WriteLine();
        }
    }
}

