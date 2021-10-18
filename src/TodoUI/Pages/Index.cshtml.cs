using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoUI.Models;

namespace TodoUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public string Message { get; set; }

        [BindProperty]
        public IEnumerable<Todo> Todos { get; private set; }

        public async Task OnGetAsync()
        {
            await GetTodos();
        }

        public async Task<IActionResult> OnPostAsync(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _httpClientFactory.CreateClient("todoapi").PostAsJsonAsync<Todo>("Items/Todo", todo);
            Message = $"Added: {todo.Description}";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveAsync(int id)
        {
            if (ModelState.IsValid)
            {
                await _httpClientFactory.CreateClient("todoapi").DeleteAsync($"Items/Todo/{id}");
                return RedirectToPage();
            }
            return Page();
        }
        public IActionResult OnPostEditAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("Edit", new { id = id });
        }

            private async Task GetTodos()
        {
            Todos = await _httpClientFactory.CreateClient("todoapi").GetFromJsonAsync<IEnumerable<Todo>>("Items/Todos");
        }
    }
}
