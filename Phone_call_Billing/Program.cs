using System;

class Program
{
    const double REGULAR_RATE = 2.0;  // R2 per minute
    const double DISCOUNT_RATE = 0.5; // 50% discount
    const double LONG_CALL_DISCOUNT = 0.15; // 15% discount for calls longer than 60 minutes
    const double TAX_RATE = 0.04; // 4% tax

    static void Main(string[] args)
    {
        Console.Write("Enter the start time of the call (24-hour format): ");
        int startTime = int.Parse(Console.ReadLine());
        Console.Write("Enter the duration of the call in minutes: ");
        int duration = int.Parse(Console.ReadLine());

        var (grossCost, netCost) = CalculateCallCost(startTime, duration);
        PrintBill(startTime, duration, grossCost, netCost);
    }

    static (double grossCost, double netCost) CalculateCallCost(int startTime, int duration)
    {
        double grossCost = duration * REGULAR_RATE;

        // Determine if the call is eligible for a time-based discount
        if ((startTime >= 18 && startTime < 24) || (startTime >= 0 && startTime < 8))
        {
            grossCost *= (1 - DISCOUNT_RATE);
        }

        // Apply long call discount if applicable
        if (duration > 60)
        {
            grossCost *= (1 - LONG_CALL_DISCOUNT);
        }

        // Calculate net cost with tax
        double netCost = grossCost * (1 + TAX_RATE);

        return (grossCost, netCost);
    }

    static void PrintBill(int startTime, int duration, double grossCost, double netCost)
    {
        Console.WriteLine("Call Summary:");
        Console.WriteLine("Start Time: " + startTime + ":00");
        Console.WriteLine("Duration: " + duration + " minutes");
        Console.WriteLine("Gross Cost: R" + Math.Round(grossCost, 2));
        Console.WriteLine("Net Cost (with tax): R" + Math.Round(netCost, 2));
    }
}