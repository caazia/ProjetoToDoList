using Microsoft.AspNetCore.Mvc;
using ProjetoImpacta04.Models;
using System.Diagnostics;

namespace ProjetoImpacta04.Controllers
{
    public class ToDoListController : Controller
    {
        private static List<ToDoList> _todolist = new List<ToDoList>()
    {
        new ToDoList { ToDoListId= 1, Content="Lavar roupa", Category="Casa", Status="Concluído"},
        new ToDoList { ToDoListId= 2, Content="Lavar pratos", Category="Casa", Status="A Fazer"},
        new ToDoList { ToDoListId= 3, Content="Estudar .Net", Category="Estudos", Status="Concluído"},
        new ToDoList { ToDoListId= 4, Content="Malhar perna", Category="Academia", Status = "A Fazer"}
        
    };
        public IActionResult Index()
        {
            return View(_todolist);
        }


        public IActionResult Details(int id)
        {

            var todolist = _todolist.FirstOrDefault(p => p.ToDoListId == id);
            if (todolist == null)
                return NotFound();
            return View(todolist);
        }


        [HttpGet] //pegar
        public IActionResult Create()
        {  //chama o form de cadastro
            return View();
        }

        [HttpPost] //Enviar
        public IActionResult Create(ToDoList todolist)
        { //recebe os dados do form    

            if (ModelState.IsValid)
            {
                todolist.ToDoListId = _todolist.Count > 0 ? _todolist.Max(c => c.ToDoListId) + 1 : 1;
                _todolist.Add(todolist);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var todolist = _todolist.FirstOrDefault(c => c.ToDoListId == id);
            if (todolist == null)
            {
                return NotFound();
            }
            _todolist.Remove(todolist);
            return RedirectToAction("Index");
        }

        //edit para alimentar o form (get)
        public IActionResult Edit(int id)
        {
            var todolist = _todolist.FirstOrDefault(c => c.ToDoListId == id);
            if (todolist == null)
            {
                return NotFound();
            }

            return View(todolist);
        }

        [HttpPost]
        public IActionResult Edit(ToDoList todolist)
        {
            if (ModelState.IsValid)
            {
                
                var existingToDo = _todolist.FirstOrDefault(c => c.ToDoListId == todolist.ToDoListId);
                if (existingToDo != null)
                {
                    existingToDo.Content = todolist.Content;
                    existingToDo.Category = todolist.Category;
                    existingToDo.DateExpiration = todolist.DateExpiration;
                    existingToDo.Status = todolist.Status;

                }
                return RedirectToAction("Index");
            }
            return View(todolist);
        }

        //[HttpPost]
        //public IActionResult MarcarCompleto([FromRoute] string status, ToDoList todolistSelecionado)
        //{
        //    todolistSelecionado = _todolist.Find(todolistSelecionado.ToDoListId);
        //    if (todolistSelecionado == null)
        //    {
        //        todolistSelecionado.Status = "Concluído";
        //        _todolist.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}
        public IActionResult Done()
        {
            return View(_todolist);
        }

        public IActionResult ToDo()
        {
            return View(_todolist);
        }



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
