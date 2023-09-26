public class Staff
{
    public bool IsPrinterFree { get; set; }

    public void Print(Customer customer)
    {
        if (IsPrinterFree)
        {
            IsPrinterFree = false;
            // Print customer's documents
        }
    }

    public void MoveToCashier(Customer customer)
    {
        // Move customer to cashier for payment
    }

    public void ReceivePayment(Customer customer)
    {
        // Receive payment from the customer
        IsPrinterFree = true; // Printer is now free
    }
}
