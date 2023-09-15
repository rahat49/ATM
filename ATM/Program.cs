public class cardHolder
{
    string cardNum;
    int pin;
    string FirstName, LastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        FirstName = firstName;
        LastName = lastName;
        this.balance = balance;
    }
    public string getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return FirstName;
    }
    public string getLastName()
    {
        return LastName;
    }
    public double getBalance() 
    { 
        return balance;
    }
    public void setNum(string newcardNum)
    {
        cardNum = newcardNum;
    }
    public void setPin(int newpin)
    {
        pin=newpin;
    }
    public void setFirstName(string newfirstName)
    {
        FirstName = newfirstName;
    }
    public void setLastName(string newlastName)
    {
        LastName = newlastName;
    }
    public void setBalance(double newbalance)
    { 
        balance = newbalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please Choose from one of the following options..");
            Console.WriteLine("1. Deposite");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        void deposit (cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposite?");
            double deposite = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposite);
            Console.WriteLine("Thank you for Taka. Your new balance is: " + currentUser.getBalance());
        }
        void withDraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if the user has enough money
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance: ");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you for your transaction.");
            }
        }
        void balance (cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123456789", 1234, "Rahat", "Sarker", 160.31));   
        cardHolders.Add(new cardHolder("123456788", 1243, "Rejoin", "Ahmed", 2000.00));   
        cardHolders.Add(new cardHolder("123456787", 1423, "Antor", "Ahmed", 65000.00));

        //promt user
        Console.WriteLine("Welcome to FakeATM");
        Console.WriteLine("Please enter your debit card: ");
        string debitcardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitcardNum=Console.ReadLine();
                //check if user card number is avail or not on db
                currentUser = cardHolders.FirstOrDefault(x=> x.cardNum==debitcardNum);
                if(currentUser != null)
                { 
                    break; 
                }
                else
                {
                    Console.WriteLine("Card is not recognize. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card is not recognize. Please try again");
            }

        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Pin. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again");
            }
        }
            Console.WriteLine("Welcome " + currentUser.getFirstName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {

                }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withDraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            {
                Console.WriteLine("Thank you! Have a nice day.");
            }

    }
}