namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string ImageUrl)>
            {
                ("Sport", "https://d2v9ipibika81v.cloudfront.net/uploads/sites/256/coronavirus-Information.png"),
                ("Coronavirus", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Sport_balls.svg/200px-Sport_balls.svg.png"),
                ("News", "http://www.bardfieldacademy.org/wp-content/uploads/2016/09/News.jpg"),
                ("Program", "https://catalyst-ca.net/wp-content/uploads/2021/12/top-programing-languages.jpeg"),
                ("Music", "https://img.freepik.com/free-vector/musical-melody-symbols-yellow-splotch_1308-64213.jpg"),
                ("Dogs", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/dog-puppy-on-garden-royalty-free-image-1586966191.jpg"),
                ("Cats", "https://images.theconversation.com/files/457052/original/file-20220408-15-pl446k.jpg?ixlib=rb-1.1.0&q=45&auto=format&w=1000&fit=clip"),
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    Description = category.Name,
                    Title = category.Name,
                    ImageUrl = category.ImageUrl,
                });
            }
        }
    }
}
