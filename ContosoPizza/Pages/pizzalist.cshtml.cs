using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class pizzalistModel : PageModel
    {
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
    }
}
