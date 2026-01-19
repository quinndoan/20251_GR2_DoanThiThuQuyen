using System;

namespace TerminalConf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Terminal Configuration Tool (Learning Mode) ---");

            if (args.Length == 0)
            {
                Console.WriteLine("Vui lòng nhập tham số. Ví dụ:");
                Console.WriteLine("TerminalConf.exe -r B1-201 -i 10");
                return;
            }

            // Duyệt qua các tham số đầu vào
            for (int i = 0; i < args.Length; i++)
            {
                // Logic xử lý đơn giản: In ra những gì nhận được
                if (args[i] == "-r") 
                {
                    Console.WriteLine($"Phát hiện cấu hình PHÒNG (Room): {args[i+1]}");
                }
                else if (args[i] == "-i")
                {
                    Console.WriteLine($"Phát hiện cấu hình MÁY (Index): {args[i+1]}");
                }
            }

            Console.WriteLine("Cấu hình giả lập hoàn tất. Nhấn Enter để thoát.");
            Console.ReadLine();
        }
    }
}