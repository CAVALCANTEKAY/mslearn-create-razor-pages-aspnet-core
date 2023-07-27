using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class pizzalistModel : PageModel
    {
        [BindProperty]
        public Pizza Newpizza { get; set; } = default;
        private readonly PizzaService _service;
        public IList<Pizza> pizzalist { get; set; } = default;

        public pizzalistModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            pizzalist = _service.GetPizzas();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Newpizza == null) 
            {
                return Page();
            }

            _service.AddPizza(Newpizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);

            return RedirectToAction("get");
        }

    }
}
