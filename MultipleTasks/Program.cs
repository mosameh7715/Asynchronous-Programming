using MultipleTasks;
using System.Diagnostics;


var stopwatch = new Stopwatch();
stopwatch.Start();
Console.WriteLine("MAIN THREAD STARTED");

List<CreditCard> creditCard = CreditCard.GenerateCreditCards(10);

ProcessCreditCards(creditCard);

Console.WriteLine("MAIN THREAD ENDED");
stopwatch.Stop();
Console.WriteLine($"Main Thread Execution Time {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");

Console.ReadLine();


async Task<string> ProcessCard (CreditCard card)
{
	await Task.Delay(TimeSpan.FromSeconds(1));

	string message = $"Name:{card.Name}\nNumber:{card.Number}";
	//Console.WriteLine($"Credit Card Number: {card.Number} Processed");
	return message;
}

async void ProcessCreditCards (List<CreditCard> cards)
{
	var stopwatch = new Stopwatch();
	stopwatch.Start();

	var tasks = new List<Task<string>>();

	await Task.Run(() =>
	{
		foreach(var card in cards)
		{
			var response = ProcessCard(card);
			tasks.Add(response);
		}
	});


	await Task.WhenAll(tasks);

	stopwatch.Stop();

	Console.WriteLine($"Processing of {cards.Count} Credit Cards Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
}