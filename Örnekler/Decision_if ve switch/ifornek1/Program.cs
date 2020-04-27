using System;
//using nswcasem;

class IfSelect
{
    public static void Main()
    {
        string myInput;
        int myInt;
        Console.Write("Please enter a number: ");
        myInput = Console.ReadLine();
        myInt = Int32.Parse(myInput);
        // Single Decision and Action with brackets 
        if (myInt > 0)
        {
            Console.WriteLine("Your number {0} is greater than zero.", myInt);
        }
        // Single Decision and Action without brackets 
        if (myInt < 0)
            Console.WriteLine("Your number {0} is less than zero.", myInt);
        // Either/Or Decision 
        if (myInt != 0)
        {
            Console.WriteLine("Your number {0} is not equal to zero.", myInt);
        }
        else
        {
            Console.WriteLine("Your number {0} is equal to zero.", myInt);
        }
        // Multiple Case Decision 
        if (myInt < 0 || myInt == 0)
        {
            Console.WriteLine("Your number {0} is less than or equal to zero.", myInt);
        }
        else if (myInt > 0 && myInt <= 10)
        {
            Console.WriteLine("Your number {0} is between 1 and 10.", myInt);
        }
        else if (myInt > 10 && myInt <= 20)
        {
            Console.WriteLine("Your number {0} is between 11 and 20.", myInt);
        }
        else if (myInt > 20 && myInt <= 30)
        {
            Console.WriteLine("Your number {0} is between 21 and 30.", myInt);
        }
        else
        {
            Console.WriteLine("Your number {0} is greater than 30.", myInt);
        }
        //switchase gitmek için 1 gir, çıkmak için başka bi tuşa basın

        Console.WriteLine("Switch case önrğini çalıtırmak için 1e bas, çıkmak için başka tuşa");
        string a = Console.ReadLine();
        byte b = Byte.Parse(a);
        if (b == 1) swcase_metod();
    }
         
        
        public static void swcase_metod()
    {
        string myInput;
        int myInt;

    begin:
        Console.Write("Please enter a number between 1 and 3: ");
        myInput = Console.ReadLine();
        myInt = Int32.Parse(myInput);
        // switch with integer type
        switch (myInt)
        {
            case 1:
                Console.WriteLine("Your number is {0}.", myInt);
                break;
            case 2:
                Console.WriteLine("Your number is {0}.", myInt);
                break;
            case 3:
                Console.WriteLine("Your number is {0}.", myInt);
                break;
            default://vb'deki "case else" anlamında
                Console.WriteLine("Your number {0} is not between 1 and 3.", myInt);
                break;
        }
    decide:
        Console.Write("Type \"continue\" to go on or \"quit\" to stop: ");
        myInput = Console.ReadLine();
        // switch with string type 
        switch (myInput)
        {
            case "continue":
                goto begin;
            case "quit": Console.WriteLine("Bye."); 
                break;

            default:
                Console.WriteLine("Your input {0} is incorrect.", myInput);
                goto decide;
        }
    
        //Console.ReadLine();//buranın amacı bi değişkene değer input almak değil, ekranın kaybolmasını engellemek
    }
}