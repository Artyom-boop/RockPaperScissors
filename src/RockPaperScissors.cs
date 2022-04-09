class RockPaperScissors
{
   public readonly List<string> movements;
    public RockPaperScissors(List<string> movements)
    {
        this.movements = movements;
    }
    public string MoveComputer()
    {
        Random rnd = new Random();
        int i = rnd.Next(movements.Count);
        return movements[i];
    }
    public string MovePlayer()
    {
        Console.Write("Enter your move: ");
        string? movement;
        string? indexMovement = Console.ReadLine();
        if (indexMovement == null || indexMovement == "")
        {
            Console.WriteLine("Your turn cannot be empty");
            MovePlayer();
        }
        if (!IsValidMovePlayer(indexMovement, out movement))
        {
            MovePlayer();
        }
        return movement;
    }
    private bool IsValidMovePlayer(string indexMovement, out string movement)
    {
        int index;
        if ("?".Equals(indexMovement))
        {
            movement = "?";
            return true;
        }
        if (!int.TryParse(indexMovement, out index) || index > movements.Count || index < 1)
        {
            Console.WriteLine("Incorect value");
            movement = "";
            return false;
        }
        movement = movements[index - 1];
        return true;
    }
    public void PrintMenu()
    {
        int i = 1;
        Console.WriteLine("Available moves:");
        foreach (var movement in movements)
        {
            Console.WriteLine(i++ + " - " + movement + "\n");
        }
        Console.WriteLine("? - help");
        Console.WriteLine("Ctrl+C - Exit\n");
    }
    private bool PlayerIsWin(string player, string computer)
    {
        if(player.Equals(computer))
        {
            return false;
        }
        int half = movements.Count / 2;
        int numberPlayer = movements.IndexOf(player) + 1;
        int numberComputer = movements.IndexOf(computer) + 1;

        if ((numberPlayer + half)  >= numberComputer && numberPlayer < numberComputer)
        {
            return true;
        }
        if ((numberPlayer + half) % (movements.Count) >= numberComputer && (numberPlayer + half) > movements.Count)
        {
            return true;
        }
        return false;
    }
    public string GetResultGame(string player, string computer)
    {
        if (player == computer)
        {
            return "Draw";
        }
        return PlayerIsWin(player, computer) ? "Win" : "Lose";
    }
}
