namespace ForumSystem.Web.Controllers
{
    using System.Diagnostics;

    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels;
    using ForumSystem.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : BaseController
    {
        //private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly ICategoriesService categoriesService;
        private readonly ILogger<HomeController> logger;

        public HomeController(
            ICategoriesService categoriesService,
            ILogger<HomeController> logger)
        {
            this.categoriesService = categoriesService;
            this.logger = logger;
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
            this.logger.LogDebug(this.HttpContext.Request.ContentType);
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
