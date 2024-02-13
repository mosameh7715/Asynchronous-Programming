Console.WriteLine("MAIN STARTED");
SayHello();
Console.WriteLine("MAIN ENDED");
Console.ReadKey();


async void SayHello()
{
    Console.WriteLine("HELLO STARTED");
	WaitingMethod();
	Console.WriteLine("HELLO ENDED");
}

async void WaitingMethod()
{
	await Task.Delay(TimeSpan.FromSeconds(5));
	Console.WriteLine("WAITING ENDED");	
}