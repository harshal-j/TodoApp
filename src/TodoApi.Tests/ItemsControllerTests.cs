using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Controllers;
using TodoApi.Models;

namespace TodoApi.Tests
{
    [TestClass]
    public class ItemsControllerTests
    {
        [TestMethod]
        public void TodoItemNotFound_Response()
        {
            var options = new DbContextOptionsBuilder<TodosContext>().
                            UseInMemoryDatabase(databaseName: "mydb").Options;
            using(var context = new TodosContext(options))
            {
                context.Todo.Add(new Todo { Id = 2, Description = "Bungee Jumping" });
                context.SaveChanges();
            }

            using (var context = new TodosContext(options))
            {
                var mockLogger = new Mock<ILogger<ItemsController>>();
                var controller = new ItemsController(mockLogger.Object, context);
                var result = controller.GetTodo(1).Result;
                Assert.AreEqual(typeof(NotFoundResult), result.GetType());
            }            
        }
    }
}
