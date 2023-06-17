using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {   
        // Write Serial
        string serial = "1234567894";
        string vcmailboxCmd = "";
        if(Regex.IsMatch(serial, @"^\d{10,14}$"))
        {
            vcmailboxCmd = $"vcmailbox 0x00038021 16 16 0 2 0x{serial.Length:X2}{serial[..6]} 0x{serial[6..].PadRight(8, '0')}";
        }
        Console.WriteLine($"Write Serial\n-> {vcmailboxCmd}");
        
        // Read Serial
        Console.WriteLine("\n-------\nRead Serial");
        Console.WriteLine("-> vcmailbox 0x00030021 16 16 0 2 0 0");
        string rawSerialFromOTP = "0x0B123456 0x78940000";
        Console.WriteLine($"<- {rawSerialFromOTP}");
        int serialLength = Convert.ToInt32(rawSerialFromOTP[..4], 16);
        string serialFromOTP = $"{rawSerialFromOTP[4..10]}{rawSerialFromOTP[13..21]}"[..serialLength];
        Console.WriteLine($"Serial: {serialFromOTP}");
    }
}