using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesWithInterface
{
    public interface IShape
    {
        
        // Properties
        Position Position { get; set; }
        int Length { get;  set; }

        int Width { get; set; }

        int Height { get; set; }
        // Methods
        void Draw();
    }

    public class HorizontalLine : IShape
    {
        public int Length { get; set; }
        public Position Position { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }

        public HorizontalLine(Position position,int length)
        {
            this.Length = length;
            this.Position = position;
           
        }


        public void Draw()
        {
            try
            {
                
                for (int i = 0; i < this.Length; i++)
                {
                    Console.SetCursorPosition(Position.X,Position.Y);
                    Console.Write("─");
                }
                Console.WriteLine();
               
                Console.WriteLine();

                
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            } 
        }
    }


    public class VerticalLine:IShape
    {
        public int Length { get; set; }
        public Position Position { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }
        public VerticalLine(Position position, int length)
        {
            this.Position = position;
            this.Length = length;
        }
        public void Draw()
        {
            try
            {
                 

                for (int i = 0; i < this.Length; i++)
                {
                    
                    Console.SetCursorPosition(Position.X, Position.Y+i);
                    Console.Write("│");

                }


            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            } 
        }

    }

    public class FilledRectangel : IShape 
    {
        public int Length { get; set; }
        public Position Position { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }
        public FilledRectangel(Position position, int height,int width)
        {
            this.Position = position;
            this.Height = height;
            this.Width = width;
        }

        public void Draw()
        {
            try
            {


                for (int i = 0; i < this.Width; i++)
                {
                    
                    for (int j = 0; j < this.Height;j++ )
                    {
                        if(((i%2==0)&&(j%2==0))||((i%2==1)&&(j%2==1))) // Om bägge koordinaterna är udda eller bägge koordinaterna är jämna
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        

                        Console.SetCursorPosition(Position.X+i, Position.Y + j);
                        

                        Console.Write("█");
                    }
                    Console.WriteLine();
                }


            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

    }

    public class Dot : IShape
    {
        public int Length { get; set; }
        public Position Position { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }
        public Dot(Position position, int length)
        {
            this.Position = position;
        }

        public void Draw()
        {
            
        }
    
    }
    public class Position
    {

        public int X{get; private set;}
        public int Y{get; private set;}

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class FilledRow : IShape
    {
        public int Length { get; set; }
        public Position Position { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }
        public FilledRow(Position position, int length)
        {
            this.Position = position;
            this.Length = length;
        }
        public void Draw()
        {
            try
            {


                for (int i = 0; i < this.Length; i++)
                {

                    Console.SetCursorPosition(Position.X+i, Position.Y );
                    Console.Write("█");

                }


            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

    }

}

