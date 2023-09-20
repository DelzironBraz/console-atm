using System;

/*card class*/
public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    /*object constructor*/
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    /*getters and setters*/
    public string getCardNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setCardNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }


    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    /*Main*/
    public static void Main(string[] args)
    {
        /*Display a menu options*/
        void printMenuOptions()
        {
            Console.WriteLine("Please choose from one of the fallowing options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        //1.Deposit
        void deposit(cardHolder user)
        {
            Console.WriteLine("How much money would you like to deposit?");
            double deposit =  Double.Parse(Console.ReadLine());
            user.setBalance(user.getBalance() + deposit); 
            Console.WriteLine("Thank you for your money. Your new balance is: " + user.getBalance());
        }

        //2. Withdraw
        void withdraw(cardHolder user)
        {
            Console.WriteLine("How much money would you like to withdraw?");
            double withdraw = Double.Parse(Console.ReadLine());
            if (user.getBalance() < withdraw) 
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                user.setBalance((user.getBalance() - withdraw));
                Console.WriteLine("You're good to go! Thank you");
            }
        }


        //3. Show Balance
        void showBalance(cardHolder user)
        {
            Console.WriteLine("Current Balance: " + user.getBalance());
        }

        //List of Users
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1111111111111111", 1234, "Matheus", "Lacerda", 150.31));
        cardHolders.Add(new cardHolder("2222222222222222", 5678, "Luisa", "Landim", 34.67));
        cardHolders.Add(new cardHolder("3333333333333333", 9101, "Giovanna", "Castro", 531.21));
        cardHolders.Add(new cardHolder("4444444444444444", 1213, "Isabella", "Landim", 98.56));
        cardHolders.Add(new cardHolder("5555555555555555", 1415, "Dhiellen", "Araujo", 209.12));


        // Prompt user
        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder user;

        while (true)
        {
            try
            {
                Console.WriteLine("Digit your card number: ");
                debitCardNum = Console.ReadLine();
                //Check against our list
                user = cardHolders.FirstOrDefault(currentUser => currentUser.cardNum ==  debitCardNum);
                if (user != null) { break; };
                Console.WriteLine("Card not recognizes. Please try again");
            }
            catch { Console.WriteLine("Card not recognizes. Please try again"); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                Console.WriteLine("Digit your card number: ");
                userPin = int.Parse(Console.ReadLine());
                //Check against our list
                if (user.getPin() == userPin) { break; };
                Console.WriteLine("Incorrect pin. Please try again");
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + user.getFirstName());

        int option = 0;

        do
        {
            printMenuOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            switch (option)
            {
                case 1:
                    deposit(user); 
                    break;
                case 2:
                    withdraw(user);
                    break;
                case 3:
                    showBalance(user);
                    break;
                default:
                    break;
            }


        } while (option != 4);
    }
}