using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
  static void Main(string[] args)
  {
    int id = int.Parse(Console.ReadLine()); // id of your player.
    int boardSize = int.Parse(Console.ReadLine());

    // game loop
    while (true)
    {
      List<string> validActions = new List<string>();
      List<string> boardRows = new List<string>();

      for (int i = 0; i < boardSize; i++)
      {
        string line = Console.ReadLine(); // rows from top to bottom (viewer perspective).
        boardRows.Add(line);
      }
      int actionCount = int.Parse(Console.ReadLine()); // number of legal actions for this turn.
      for (int i = 0; i < actionCount; i++)
      {
        string action = Console.ReadLine(); // the action
        validActions.Add(action);
      }

      // Write an action using Console.WriteLine()
      // To debug: Console.Error.WriteLine("Debug messages...");
      List<char> tiles = new List<char>();

      for (int i = 0; i < boardRows.Count(); i++)
      {
        string row = boardRows[i];

        for (int j = 0; j < row.Length; j++)
        {
          tiles.Add(row[j]);
        }
      }

      // Board board = new Board(tiles);
      // OthelloAi ai = new OthelloAi(validActions, board);
      BoardTileData boardTileData = new BoardTileData();
      string[] tileData = boardTileData.GetTileDirections("b2");

      Console.Error.WriteLine(tileData[0]);

      Console.WriteLine("c4"); // a-h1-8

    }
  }
}

class OthelloAi
{
  private List<string> moves;
  private Board board;

  public OthelloAi(List<string> moves, Board board)
  {
    this.moves = moves;
    this.board = board;
  }

  public string GetMove()
  {
    Random rnd = new Random();
    int num = rnd.Next(moves.Count() - 1);
    return moves[num];
  }

  public void GetValidMoves()
  {
    // return board.tiles.filter((tile) => {
    //     return tile.IsValidMove();
    // });
  }
}

class Tile
{
  private int x;
  private int y;
  private string tileName;

  private string[] directions;

  public Tile(int x, int y, string tileName)
  {
    this.x = x;
    this.y = y;
    this.tileName = tileName;

    BoardTileData boardTileData = new BoardTileData();
    directions = boardTileData.GetTileDirections(tileName);
  }

  public bool IsValidMove()
  {
    bool isValid = false;

    directions.ForEach((direction) =>
    {


    });
    // Tile[] surroundingTiles = GetSurroundingTiles();
    // Tile[] potentialTileMoves = surroundingTiles.Filter((tile) => !tile.isEmpty() && !tile.isCurrentPlayer() )
    // if (potentialTileMoves.Length === 0) { return false; }
    // Keep traversing in the direction of potentialTiles
  }





}



class BoardTileData
{
  private string[] defaultTiles;
  private string[] defaultDirections;
  private Dictionary<string, string[]> specialTiles;

  public BoardTileData()
  {
    specialTiles = new Dictionary<string, string[]>();
    specialTiles.Add("a1", new string[] { "right", "bottomRight", "bottom" });
    specialTiles.Add("h1", new string[] { "left", "bottom", "bottomLeft" });
    specialTiles.Add("a8", new string[] { "top", "topRight", "right" });
    specialTiles.Add("h8", new string[] { "left", "topLeft", "top" });

    specialTiles.Add("a2", new string[] { "top", "topRight", "right", "bottomRight", "bottom" });
    specialTiles.Add("a3", new string[] { "top", "topRight", "right", "bottomRight", "bottom" });
    specialTiles.Add("a4", new string[] { "top", "topRight", "right", "bottomRight", "bottom" });
    specialTiles.Add("a5", new string[] { "top", "topRight", "right", "bottomRight", "bottom" });
    specialTiles.Add("a6", new string[] { "top", "topRight", "right", "bottomRight", "bottom" });
    specialTiles.Add("a7", new string[] { "top", "topRight", "right", "bottomRight", "bottom" });

    specialTiles.Add("b1", new string[] { "left", "right", "bottomRight", "bottom", "bottomLeft" });
    specialTiles.Add("c1", new string[] { "left", "right", "bottomRight", "bottom", "bottomLeft" });
    specialTiles.Add("d1", new string[] { "left", "right", "bottomRight", "bottom", "bottomLeft" });
    specialTiles.Add("e1", new string[] { "left", "right", "bottomRight", "bottom", "bottomLeft" });
    specialTiles.Add("f1", new string[] { "left", "right", "bottomRight", "bottom", "bottomLeft" });
    specialTiles.Add("g1", new string[] { "left", "right", "bottomRight", "bottom", "bottomLeft" });

    specialTiles.Add("h2", new string[] { "left", "topLeft", "top", "bottom", "bottomLeft" });
    specialTiles.Add("h3", new string[] { "left", "topLeft", "top", "bottom", "bottomLeft" });
    specialTiles.Add("h4", new string[] { "left", "topLeft", "top", "bottom", "bottomLeft" });
    specialTiles.Add("h5", new string[] { "left", "topLeft", "top", "bottom", "bottomLeft" });
    specialTiles.Add("h6", new string[] { "left", "topLeft", "top", "bottom", "bottomLeft" });
    specialTiles.Add("h7", new string[] { "left", "topLeft", "top", "bottom", "bottomLeft" });

    specialTiles.Add("b8", new string[] { "left", "topLeft", "top", "topRight", "right" });
    specialTiles.Add("c8", new string[] { "left", "topLeft", "top", "topRight", "right" });
    specialTiles.Add("d8", new string[] { "left", "topLeft", "top", "topRight", "right" });
    specialTiles.Add("e8", new string[] { "left", "topLeft", "top", "topRight", "right" });
    specialTiles.Add("f8", new string[] { "left", "topLeft", "top", "topRight", "right" });
    specialTiles.Add("g8", new string[] { "left", "topLeft", "top", "topRight", "right" });

    defaultTiles = new string[] {
      "b2", "c2", "d2", "e2", "c2", "c2", "c2",
      "b3", "c3", "d3", "e3", "c3", "c3", "c3",
      "b4", "c4", "d4", "e4", "c4", "c4", "c4",
      "b5", "c5", "d5", "e5", "c5", "c5", "c5",
      "b6", "c6", "d6", "e6", "c6", "c6", "c6",
      "b7", "c7", "d7", "e7", "c7", "c7", "c7",
      "b8", "c8", "d8", "e8", "c8", "c8", "c8"
    };

    defaultDirections = new string[] {
      "left", "topLeft", "top", "topRight", "right", "bottomRight", "bottom", "bottomLeft"
    };
  }

  public string[] GetTileDirections(string tile)
  {
    bool isDefaultTile = Array.Exists(defaultTiles, (tileName) => tile == tileName);

    if (isDefaultTile)
    {
      return defaultDirections;
    }
    string[] tileData;
    specialTiles.TryGetValue(tile, out tileData);
    return tileData;
  }

}

class TileCoordinatesConverter
{

  Dictionary<char, int> letters;

  public TileCoordinatesConverter()
  {
    letters = new Dictionary<char, int>();
    letters.Add("a", 0);
    letters.Add("b", 1);
    letters.Add("c", 2);
    letters.Add("d", 3);
    letters.Add("e", 4);
    letters.Add("f", 5);
    letters.Add("g", 6);
    letters.Add("h", 7);
  }

  public static int[] TileNameToCoordinates(string tileName)
  {
    char[] splitTileName = tileName.ToCharArray();

    int x = letters.TryGetValue(splitTileName[0]);
    int y = splitTileName[1];

    return new int[2] { x, y };
  }

  public static string CoordinatesToTileName(int x, int y)
  {
    string key = letters.Where(pair => pair.Value == x);

    return key.Concat(y + 1);
  }


}