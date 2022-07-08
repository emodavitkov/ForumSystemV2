namespace ForumSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using ForumSystem.Data;
    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Web.ViewModels;
    using ForumSystem.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        //private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }



        //private readonly IEmailSender sender;
        //public HomeController(IEmailSender sender)
        //{
        //    this.sender = sender;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    await this.sender.SendEmailAsync("emodavitkov@gmail.com", "Emo", "emodavitkov@abv.bg", "Testvam si tuka",
        //        "");
        //    return this.View();
        //}

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var categories = this.categoriesService.GetAll<IndexCategoryViewModel>();
            viewModel.Categories = categories;

            //shoter than above: 
            //var viewModel1 = new IndexViewModel
            //{
            //    Categories = this.categoriesService.GetAll<IndexCategoryViewModel>(),
            //};
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
