using ChalupaHaj.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ChalupaHaj.Views.Shared.Components.News
{
    public class NewsViewComponent : ViewComponent
    {


        //creates database context
        private readonly ApplicationDbContext _ctx;


        //creates instansce of database context - to be used, when returning view
        public NewsViewComponent(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        //returns view component with news articles
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var news = await _ctx.News.ToListAsync();
            return View(news);
            
        }

      
    }
}
