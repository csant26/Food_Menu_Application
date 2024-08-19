using Food_Menu_Application.Data;
using Food_Menu_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Food_Menu_Application.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuContext _menucontext;
        public MenuController(MenuContext context)
        {
            _menucontext = context;
        }
        public async Task<IActionResult> Index(string searchDish)
        {
            var dishes = from d in _menucontext.Dishes
                       select d;
            if (!string.IsNullOrEmpty(searchDish))
            {
                dishes = dishes.Where(d => d.Name.Contains(searchDish));
                return View(await dishes.ToListAsync());
            }
            return View(await dishes.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            var dish = await _menucontext.Dishes
                .Include(di=>di.DishIngredients)
                .ThenInclude(i=>i.Ingredient)
                .FirstOrDefaultAsync(x=>x.Id==id);
            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
