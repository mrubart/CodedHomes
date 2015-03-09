using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using CodedHomes.Models;


namespace CodedHomes.Data.Configuration
{
	public class CustomDatabaseInitializer : 
		DropCreateDatabaseIfModelChanges<DataContext>
		//CreateDatabaseIfNotExists<DataContext>
	{
		protected override void Seed(DataContext context)
		{
			string[] descriptions = new string[10]
			                        {
				                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
				                        "Sed ut perspiciatis unde omnis iste natus error sit voluptatem",
				                        "accusantium doloremque laudantium, totam rem aperiam, eaque",
				                        "ipsa quae ab illo inventore veritatis et quasi",
				                        "incididunt ut labore et dolore magna aliqua. Ut enim ad minim",
				                        "veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex",
				                        "commodo consequat. Duis aute irure dolor in reprehenderit in voluptate",
				                        "velit esse cillum dolore eu fugiat nulla pariatur",
				                        "Excepteur sint occaecat cupidatat non proident, sunt in culpa",
				                        "qui officia deserunt mollit anim id est laborum"
			                        };

			int count = 10;
			while ((count--) != 0)
			{
				Home home = new Home();
				home.StreetAddress = string.Format("12{0} Street St.", count);
				home.City = "Yourtown";
				home.ZipCode = 84101;
				home.Bedrooms = ((count%2) == 1) ? 4 : 3;
				home.Bathrooms = (home.Bedrooms - 2);
				home.SquareFeet = 2800 + count;
				home.Price = 275000 + (count*1000);
				home.ImageName = string.Format("home-{0}.jpg", ((count%2) == 1) ? 1 : 2);
				home.Description = descriptions[count];
				context.Homes.Add(home);
			}

			base.Seed(context);
		}
	}
}
