using System;

namespace WordUnscrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool continueProcess = true;
                do
                {
                    Console.WriteLine(Constants.option);
                    string option = Console.ReadLine() ?? string.Empty;
                    switch (option.ToUpper())
                    {
                        case Constants.manual:
                            Console.WriteLine(Constants.manualAdvice);
                            ManualUnscramble.ExecuteScrambledWordsManually();
                            break;
                        case Constants.file:
                            FileUnscrambler.ExecuteScrambledWordsInFile();
                            break;
                        default:
                            Console.WriteLine(Constants.optionNotRecognized);
                            break;
                    }
                    string continueAnswer = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.optionToContinue);
                        continueAnswer = Console.ReadLine() ?? string.Empty;
                    } while (!continueAnswer.Equals(Constants.yes, StringComparison.OrdinalIgnoreCase) &&
                             !continueAnswer.Equals(Constants.no, StringComparison.OrdinalIgnoreCase));
                    continueProcess = continueAnswer.Equals(Constants.yes, StringComparison.OrdinalIgnoreCase);
                } while (continueProcess);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }   
    }
}
