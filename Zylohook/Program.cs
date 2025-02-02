using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zylohook
{
    internal class Program
    {
        static void Main(string[] args)
        {
        Main:
            Console.Clear();
            Console.Title = "Zylohook - Compact webhook tools for Discord - Created by @26zylo - github.com/ZyloSG";
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\r\n__________       .__         .__                   __    \r\n\\____    /___.__.|  |   ____ |  |__   ____   ____ |  | __\r\n  /     /<   |  ||  |  /  _ \\|  |  \\ /  _ \\ /  _ \\|  |/ /\r\n /     /_ \\___  ||  |_(  <_> )   Y  (  <_> |  <_> )    < \r\n/_______ \\/ ____||____/\\____/|___|  /\\____/ \\____/|__|_ \\\r\n        \\/\\/                      \\/                   \\/\r\n");
            Console.WriteLine("---------------------");
            Console.WriteLine("1 - Spam webhook");
            Console.WriteLine("2 - Delete webhook");
            Console.WriteLine("---------------------");
            Console.WriteLine("Choose an option: ");
            string FirstChoice = Console.ReadLine();
            switch (FirstChoice)
            {
                case "1":
                    SpamWebhook();
                    break;
                case "2":
                    DeleteWebhook();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    goto Main;
            }
        }

        static void SpamWebhook()
        {
            Console.WriteLine("\nOption chosen: Spam Webhook");
            Console.WriteLine("Please enter your webhook's URL: ");
            string WebhookURL = Console.ReadLine();
            Console.WriteLine("Please enter the message you wanna send: ");
            string Message = Console.ReadLine();
            Console.WriteLine("Please enter the delay between messages (in ms): ");
            string Delay = Console.ReadLine();
            Console.WriteLine("Please enter the amount of messages you want to send: ");
            string Amount = Console.ReadLine();
            int Counter = 0;
            JsonPact json = JsonPact.CreateJson();
            json.Add("content", Message);
            while (Counter < Convert.ToInt32(Amount))
            {
                Thread.Sleep(Convert.ToInt32(Delay));
                Requester.Send(WebhookURL, json, "POST");
                Counter++;
                Console.WriteLine("Sent! Messages sent: " + Counter.ToString());
            }
            Console.WriteLine("[+] Successfully spammed webhook!");
            Console.WriteLine("Press any key to go to menu");
            Console.ReadKey();
            Main(null);
        }

        static void DeleteWebhook()
        {
            Console.WriteLine("\nOption chosen: Delete Webhook");
            Console.WriteLine("Please enter your webhook's URL: ");
            string WebhookURL = Console.ReadLine();
            Requester.Send(WebhookURL, null, "DELETE");
            Console.WriteLine("[+] Successfully deleted webhook!");
            Console.WriteLine("Press any key to go to menu");
            Console.ReadKey();
            Main(null);
        }
    }
}
