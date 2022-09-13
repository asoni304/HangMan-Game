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

        Console.CursorVisible = false;

    

        for (int i = 0; i < counting.Length; i++)
        {
            Console.WriteLine(messages[0]);

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

            alreadyGuessedChar += currentGuessedChar + ",";

            if (startWord.Contains(currentGuessedChar))
            {
                for (int i = 0; i < startWord.Length; i++)
                {
                    if (startWord[i] == Convert.ToChar(currentGuessedChar))
                    {
                        maskStartWord[i] = Convert.ToChar(currentGuessedChar);
                    }

                }
            }

            tries --;
            Console.Clear();

            if (tries == 0)
            {
                gameOver = true;
                Console.WriteLine(messages[2]);
            }
            else if (!(new String(maskStartWord).Contains("-")))
            {
                gameOver = true;
                Console.WriteLine(messages[1]);
                
            }
            
        }
    }
}

