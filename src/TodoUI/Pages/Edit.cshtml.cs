using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoUI.Models;

namespace TodoUI.Pages
{
    public class EditModel : PageModel
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Todo EditTodo { get; private set; }

        public async Task OnGetAsync(int id)
        {
            await GetEditTodo(id);
        }

        public async Task<IActionResult> OnPostAsync(Todo todo)
        {
            await _httpClientFactory.CreateClient("todoapi").PutAsJsonAsync("Items/Todo", todo);
            return RedirectToPage("Index");
        }

        private async Task GetEditTodo(int id)
        {
            EditTodo = await _httpClientFactory.CreateClient("todoapi").GetFromJsonAsync<Todo>($"Items/Todo/{id}");
        }
    }
}