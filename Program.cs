using System;
using System.Threading;

internal class Program
{
    static void Main()
    {
        string[] messages = { @" _           _        _        _           _     _  _  _     _           _        _        _           _ 
(_)         (_)     _(_)_     (_) _       (_) _ (_)(_)(_) _ (_) _     _ (_)     _(_)_     (_) _       (_)
(_)         (_)   _(_) (_)_   (_)(_)_     (_)(_)         (_)(_)(_)   (_)(_)   _(_) (_)_   (_)(_)_     (_)
(_) _  _  _ (_) _(_)     (_)_ (_)  (_)_   (_)(_)    _  _  _ (_) (_)_(_) (_) _(_)     (_)_ (_)  (_)_   (_)
(_)(_)(_)(_)(_)(_) _  _  _ (_)(_)    (_)_ (_)(_)   (_)(_)(_)(_)   (_)   (_)(_) _  _  _ (_)(_)    (_)_ (_)
(_)         (_)(_)(_)(_)(_)(_)(_)      (_)(_)(_)         (_)(_)         (_)(_)(_)(_)(_)(_)(_)      (_)(_)
(_)         (_)(_)         (_)(_)         (_)(_) _  _  _ (_)(_)         (_)(_)         (_)(_)         (_)
(_)         (_)(_)         (_)(_)         (_)   (_)(_)(_)(_)(_)         (_)(_)         (_)(_)         (_)
                                                                                                         ",
            @" _           _   _  _  _  _    _            _           _             _  _  _  _  _           _ 
(_)_       _(_)_(_)(_)(_)(_)_ (_)          (_)         (_)           (_)(_)(_)(_)(_) _       (_)
  (_)_   _(_) (_)          (_)(_)          (_)         (_)           (_)   (_)   (_)(_)_     (_)
    (_)_(_)   (_)          (_)(_)          (_)         (_)     _     (_)   (_)   (_)  (_)_   (_)
      (_)     (_)          (_)(_)          (_)         (_)   _(_)_   (_)   (_)   (_)    (_)_ (_)
      (_)     (_)          (_)(_)          (_)         (_)  (_) (_)  (_)   (_)   (_)      (_)(_)
      (_)     (_)_  _  _  _(_)(_)_  _  _  _(_)         (_)_(_)   (_)_(_) _ (_) _ (_)         (_)
      (_)       (_)(_)(_)(_)    (_)(_)(_)(_)             (_)       (_)  (_)(_)(_)(_)         (_)
                                                                                                " ,
        @"    _  _  _           _        _           _  _  _  _  _  _             _  _  _  _    _           _  _  _  _  _  _  _  _  _  _    
 _ (_)(_)(_) _      _(_)_     (_) _     _ (_)(_)(_)(_)(_)(_)          _(_)(_)(_)(_)_ (_)         (_)(_)(_)(_)(_)(_)(_)(_)(_)(_) _ 
(_)         (_)   _(_) (_)_   (_)(_)   (_)(_)(_)                     (_)          (_)(_)         (_)(_)            (_)         (_)
(_)    _  _  _  _(_)     (_)_ (_) (_)_(_) (_)(_) _  _                (_)          (_)(_)_       _(_)(_) _  _       (_) _  _  _ (_)
(_)   (_)(_)(_)(_) _  _  _ (_)(_)   (_)   (_)(_)(_)(_)               (_)          (_)  (_)     (_)  (_)(_)(_)      (_)(_)(_)(_)   
(_)         (_)(_)(_)(_)(_)(_)(_)         (_)(_)                     (_)          (_)   (_)   (_)   (_)            (_)   (_) _    
(_) _  _  _ (_)(_)         (_)(_)         (_)(_) _  _  _  _          (_)_  _  _  _(_)    (_)_(_)    (_) _  _  _  _ (_)      (_) _ 
   (_)(_)(_)(_)(_)         (_)(_)         (_)(_)(_)(_)(_)(_)           (_)(_)(_)(_)        (_)      (_)(_)(_)(_)(_)(_)         (_)
                                                                                                                                  "};
        string[] counting = { @" _  _  _  _  _ 
(_)(_)(_)(_)(_)
(_) _  _  _    
(_)(_)(_)(_) _ 
            (_)
 _          (_)
(_) _  _  _ (_)
   (_)(_)(_)   
               ", 
            @"
          _    
       _ (_)   
    _ (_)(_)   
 _ (_)   (_)   
(_) _  _ (_) _ 
(_)(_)(_)(_)(_)
         (_)   
         (_)   " ,
            @"
   _  _  _  _   
 _(_)(_)(_)(_)_ 
(_)          (_)
         _  _(_)
        (_)(_)_ 
 _           (_)
(_)_  _  _  _(_)
  (_)(_)(_)(_)  ",
        @"    _  _  _    
 _ (_)(_)(_) _ 
(_)         (_)
          _ (_)
       _ (_)   
    _ (_)      
 _ (_) _  _  _ 
(_)(_)(_)(_)(_)
               ",
        @"    _    
 _ (_)   
(_)(_)   
   (_)   
   (_)   
   (_)   
 _ (_) _ 
(_)(_)(_)"};

        bool gameOver = false;

        string startWord = "nash";
        string currentGuessedChar ="";
        string alreadyGuessedChar = "" ;
        char [] maskStartWord = new String ('-',startWord.Length).ToCharArray();
        int tries = startWord.Length * 2;
        int violations = 0;

        Console.CursorVisible = false;

    

        for (int i = 0; i < counting.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(messages[0]);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(counting[i]);
            Thread.Sleep(1000);
            Console.Clear();
            

        }

        while (!gameOver)
        {
            Console.Clear();
            Console.WriteLine("Guess the word {0}",new String(maskStartWord));
            Console.WriteLine("Guessed Characters : {0}",alreadyGuessedChar);
            Console.WriteLine("No. of tries left : {0}",tries);
            Console.WriteLine();
            Console.Write("Your next guess is : ");

            currentGuessedChar = Console.ReadLine();

            alreadyGuessedChar += currentGuessedChar[0] + ",";

            if(currentGuessedChar.Length >1)
            {
                if (violations >= 1)
                {
                    tries --;
                }

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("You have to input only one character !");
                Console.WriteLine("You will lose 2 tries for each violation!");
                Thread.Sleep(500);
                Console.ResetColor();

                violations++;

            }

            if (startWord.Contains(currentGuessedChar[0].ToString()))
            {
                for (int i = 0; i < startWord.Length; i++)
                {
                    if (startWord[i] == currentGuessedChar[0])
                    {
                        maskStartWord[i] = currentGuessedChar[0];
                    }

                }
            }

            tries --;
            Console.Clear();

            if (tries == 0)
            {
                gameOver = true;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(messages[2]);
                Console.ResetColor();
            }
            else if (!(new String(maskStartWord).Contains("-")))
            {
                gameOver = true;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(messages[1]);
                
                
                
            }
            
        }
    }
}

