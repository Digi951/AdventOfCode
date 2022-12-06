namespace AdventOfCode.Year_2021.Day_21;

public static class DiracDice
{
    private static int _scorePlayer1 = 0;
    private static int _scorePlayer2 = 0;
    private static int _positionPlayer1 = 0;
    private static int _positionPlayer2 = 0;
    private static int _valueOfDice = 1;

    public static void Run()
    {
        _positionPlayer1 = 4;
        _positionPlayer2 = 2;
        
        var index = 1;

        while (_scorePlayer1 < 1000 && _scorePlayer2 < 1000)
        {
                var currentPlayer = index % 2 == 0 ? 2 : 1;
            var moves = RollTheDice();
            MovePawn(moves, currentPlayer);
            index++;
            if(currentPlayer == 1)
            {
                Console.WriteLine($"Player {currentPlayer} rolls {_valueOfDice - 3}+{_valueOfDice - 2}+{_valueOfDice - 1} moves to space {_positionPlayer1}. Score: {_scorePlayer1}");
            }
            else
            {
                Console.WriteLine($"Player {currentPlayer} rolls {_valueOfDice - 3}+{_valueOfDice - 2}+{_valueOfDice - 1} moves to space {_positionPlayer2}. Score: {_scorePlayer2}");
            }
        }

        var loserScore = _scorePlayer1 >= 1000 ? _scorePlayer2 : _scorePlayer1;
        Console.WriteLine($"{loserScore * (_valueOfDice - 1)}");
    }

    private static int RollTheDice()
    {
        var result = 3 * _valueOfDice + 3; 
        _valueOfDice += 3;
        return result;
    }

    private static void MovePawn(int moves, int player)
    {
        if (player == 1)
        {
            _positionPlayer1 += moves % 10;
            if(_positionPlayer1 > 10) { _positionPlayer1 -= 10; }
            _scorePlayer1 += _positionPlayer1;
        }
        else
        {
            _positionPlayer2 += moves % 10;
            if(_positionPlayer2 > 10) { _positionPlayer2 -= 10; }
            _scorePlayer2 += _positionPlayer2;
        }
    }
}