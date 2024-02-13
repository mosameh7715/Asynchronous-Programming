namespace MultipleTasks
{
	public class CreditCard
	{
		public string Name { get; set; }
		public string Number { get; set; }

		public static List<CreditCard> GenerateCreditCards(int number)
		{
			List<CreditCard> creditCards = new List<CreditCard>();
			for(int i = 0;i < number;i++)
			{
				var creditCard = new CreditCard
				{
					Name = $"CreditCard-{i + 1}",
					Number = $"0000-{i + 1}"
				};
				creditCards.Add(creditCard);
			}
			return creditCards;
		}
	}

}
