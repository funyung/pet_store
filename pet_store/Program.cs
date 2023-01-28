using System.Text.Json;

namespace pet_store
{
	class Product
	{
		public string	Name { get; set; }
		public string	Description { get; set; }
		public decimal	Price { get; set; }
		public int		Quantity { get; set; }

	}

	class CatFood : Product
	{
		public double	WeightPounds { get; set; }
		public bool		KittenFood { get; set; }
	}

	class DogLeash : Product
	{
		public int		LengthInches { get; set; }

		public string	Material { get; set; }

	}

	internal class Program
	{
		static void Main(string[] args)
		{
			string	userInput = "enter";
			int		userNumber = 0;
			Random	randoNumber = new Random();

			// temporary storage for product inputs
			decimal	price;
			int		quantity;
			int		length;
			double	weight;

			while (userInput.ToLower() != "exit")
			{
				if( int.TryParse(userInput, out userNumber) && userNumber == 1 )
				{
					//Use random number between 1 and 300 to decide on whether we add Cat Food or a Dog Leash
					if (randoNumber.Next(1, 300) >= 150)
					{
						Console.WriteLine("Let's add a new Dog Leash to inventory!");
						DogLeash leash = new DogLeash();

						Console.WriteLine("How long is the leash in whole inches? (ex. 1, 20, 400)");
						userInput = Console.ReadLine();
						if( int.TryParse(userInput, out length) )
						{
							leash.LengthInches = length;
						}
						else
						{
							while( !int.TryParse(userInput, out length) )
							{
								Console.WriteLine("Not a valid length, please use a number (ex. 1, 20, 400)");
								userInput = Console.ReadLine();
							}

							leash.LengthInches = length;
						}	

						Console.WriteLine("What material is it made of?");
						leash.Material = Console.ReadLine();

						Console.WriteLine("What brand leash is it?");
						leash.Name = Console.ReadLine();

						Console.WriteLine("Give me a description of it.");
						leash.Description = Console.ReadLine();

						Console.WriteLine("How much does it cost? (ex. 0.10, 1.00, 1.23)");
						userInput = Console.ReadLine();
						if (decimal.TryParse(userInput, out price))
						{
							leash.Price = price;
						}
						else
						{
							while (!decimal.TryParse(userInput, out price))
							{
								Console.WriteLine("Not a valid price, please use a number");
								userInput = Console.ReadLine();
							}

							leash.Price = price;
						}

						Console.WriteLine("How many are we adding in?");
						userInput = Console.ReadLine();
						if (int.TryParse(userInput, out quantity))
						{
							leash.Quantity = quantity;
						}
						else
						{
							while (!int.TryParse(userInput, out quantity))
							{
								Console.WriteLine("Not a valid quantity, please use a number");
								userInput = Console.ReadLine();
							}

							leash.Quantity = quantity;
						}

						Console.WriteLine("Added leash - " + JsonSerializer.Serialize(leash));
						Console.WriteLine("----------------------------------------------------");
						Console.WriteLine(" ");
					}
					else
					{
						Console.WriteLine("Let's add a new Cat Food to inventory!");
						CatFood food = new CatFood();

						Console.WriteLine("How much does the cat food weigh?");
						userInput = Console.ReadLine();
						if (double.TryParse(userInput, out weight))
						{
							food.WeightPounds = weight;
						}
						else
						{
							while (!double.TryParse(userInput, out weight))
							{
								Console.WriteLine("Not a valid weight, please use a number");
								userInput = Console.ReadLine();
							}

							food.WeightPounds = weight;
						}

						Console.WriteLine("Is it kitten food? (y/n)");
						userInput = Console.ReadLine();

						if (userInput == "y")
						{
							food.KittenFood = true;
						}
						else if (userInput == "n")
						{
							food.KittenFood = false;
						}
						else
						{
							while (userInput != "y" && userInput != "n")
							{
								Console.WriteLine("Not a valid input, please use either y or n");
								userInput = Console.ReadLine();

								if (userInput == "y")
								{
									food.KittenFood = true;
								}
								else if (userInput == "n")
								{
									food.KittenFood = false;
								}
							}
						}

						Console.WriteLine("What brand cat food is it?");
						food.Name = Console.ReadLine();

						Console.WriteLine("Give me a description of it.");
						food.Description = Console.ReadLine();

						Console.WriteLine("How much does it cost? (ex. 0.10, 1.00, 1.23)");
						userInput = Console.ReadLine();
						if (decimal.TryParse(userInput, out price))
						{
							food.Price = price;
						}
						else
						{
							while (!decimal.TryParse(userInput, out price))
							{
								Console.WriteLine("Not a valid price, please use a number (ex. 0.10, 1.00, 1.23)");
								userInput = Console.ReadLine();
							}

							food.Price = price;
						}

						Console.WriteLine("How many are we adding in?");
						userInput = Console.ReadLine();
						if (int.TryParse(userInput, out quantity))
						{
							food.Quantity = quantity;
						}
						else
						{
							while (!int.TryParse(userInput, out quantity))
							{
								Console.WriteLine("Not a valid quantity, please use a number (ex. 1, 20, 400)");
								userInput = Console.ReadLine();
							}

							food.Quantity = quantity;
						}

						Console.WriteLine("Added cat food - " + JsonSerializer.Serialize(food));
						Console.WriteLine("----------------------------------------------------");
						Console.WriteLine(" ");
					}
				}

				Console.WriteLine("Press 1 to add a product");
				Console.WriteLine("Type 'exit' to quit");
				userInput = Console.ReadLine();
			}
		}
	}
}