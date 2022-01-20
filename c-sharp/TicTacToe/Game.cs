using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;

namespace TicTacToe
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X {get; set;}
        public int Y {get; set;}
    }

    public class Tile
    {
        public Tile(Position position, char symbol)
        {
            Position = position;
            Symbol = symbol;
        }
        public Position Position {get; set;}
        public char Symbol {get; set;}
        
    }

    public class Board
    {
       private List<Tile> _plays = new List<Tile>();
       
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile (new Position(i, j), ' '));
                }  
            }       
        }
       public Tile TileAt(Position position)
       {
           return _plays.Single(tile => tile.Position.X == position.X && tile.Position.Y == position.Y);
       }

       public void AddTileAt(char symbol, int x, int y)
       {
           _plays.Single(tile => tile.Position.X == x && tile.Position.Y == y).Symbol = symbol;
       }
    }

    public class Game
    {
        private char _lastSymbol = ' ';
        private Board _board = new Board();
        
        public void Play(char symbol, int x, int y)
        {
            //if first move
            if(_lastSymbol == ' ')
            {
                //if player is X
                if(symbol == 'O')
                {
                    throw new Exception("Invalid first player");
                }
            } 
            //if not first move but player repeated
            else if (symbol == _lastSymbol)
            {
                throw new Exception("Invalid next player");
            }
            //if not first move but play on an already played tile
            else if (_board.TileAt(new Position(x,y)).Symbol != ' ')
            {
                throw new Exception("Invalid position");
            }

            // update game state
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        public char Winner()
        {   //if the positions in first row are taken
            if(_board.TileAt(new Position(0,0)).Symbol != ' ' &&
               _board.TileAt(new Position(0,1)).Symbol != ' ' &&
               _board.TileAt(new Position(0,2)).Symbol != ' ')
               {
                    //if first row is full with same symbol
                    if (_board.TileAt(new Position(0,0)).Symbol == 
                        _board.TileAt(new Position(0,1)).Symbol &&
                        _board.TileAt(new Position(0,2)).Symbol == 
                        _board.TileAt(new Position(0,1)).Symbol )
                        {
                            return _board.TileAt(new Position(0,0)).Symbol;
                        }
               }
                
             //if the positions in first row are taken
             if(_board.TileAt(new Position(1,0)).Symbol != ' ' &&
                _board.TileAt(new Position(1,1)).Symbol != ' ' &&
                _board.TileAt(new Position(1,2)).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(new Position(1,0)).Symbol == 
                        _board.TileAt(new Position(1,1)).Symbol &&
                        _board.TileAt(new Position(1,2)).Symbol == 
                        _board.TileAt(new Position(1,1)).Symbol)
                        {
                            return _board.TileAt(new Position(1,0)).Symbol;
                        }
                }

            //if the positions in first row are taken
             if(_board.TileAt(new Position(2,0)).Symbol != ' ' &&
                _board.TileAt(new Position(2,1)).Symbol != ' ' &&
                _board.TileAt(new Position(2,2)).Symbol != ' ')
                {
                    //if middle row is full with same symbol
                    if (_board.TileAt(new Position(2,0)).Symbol == 
                        _board.TileAt(new Position(2,1)).Symbol &&
                        _board.TileAt(new Position(2,2)).Symbol == 
                        _board.TileAt(new Position(2,1)).Symbol)
                        {
                            return _board.TileAt(new Position(2,0)).Symbol;
                        }
                }

            return ' ';
        }
    }
}