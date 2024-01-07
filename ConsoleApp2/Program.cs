using System;

class Calculator
{
    static void Main()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("when a first symbol on line is ‘>’ – enter operand(number)");
        Console.WriteLine("when a first symbol on line is ‘@’ – enter operation");
        Console.WriteLine("operation is one of ‘+’, ‘-‘, ‘/’, ‘*’ or ‘#’ followed with number of evaluation step");
        Console.WriteLine("‘q’ to exit");
        Console.Write("> ");
        double.TryParse(Console.ReadLine(), out double result);
        int numofcount = 1;
        double[] resultsArray = new double[1000];
        resultsArray[1] = result;
        while (true)
        {
            Found: Console.WriteLine($"[#{numofcount}]: {result}");
            Console.Write("@ ");
            string operationInput = Console.ReadLine();

            if (operationInput.ToLower() == "q")
                break;
            if (operationInput.StartsWith("#") == true)
            {
                string valueXString = operationInput.Substring(1);
                if (int.TryParse(valueXString, out int valueX))
                {
                    result = resultsArray[valueX];
                }
                else
                {
                    Console.WriteLine("Неверный формат числа после символа '#'.");
                    continue;
                }
                numofcount++;
                goto Found;
            }
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double num2))
            {
                Console.WriteLine("Ошибка: введено некорректное число!");
                continue;
            }

            switch (operationInput)
            {
                case "+":
                    result += num2;
                    break;
                case "-":
                    result -= num2;
                    break;
                case "*":
                    result *= num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result /= num2;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: деление на ноль!");
                        continue;
                    }
                    break;
                default:
                    Console.WriteLine("Ошибка: введена неверная операция!");
                    continue;
            }
            numofcount++;
            resultsArray[numofcount] = result;
        }
        Console.WriteLine("Программа завершена.");
    }
}


