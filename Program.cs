// See https://aka.ms/new-console-template for more information

using Temp.Publisher;
using Temp.Listener;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Reflection;

class Program
{
    public static void Main()
    {

        int cnt = 10;
        while (cnt>0)
        {

            var message = "Write Your Own Message";
            Publisher.SendMessage(message);
            cnt--;
        }

        Listener.StartListening();
       

    }
}