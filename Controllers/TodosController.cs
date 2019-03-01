using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noel_repository_pattern.ViewModels;

namespace noel_repository_pattern.Controllers
{
    public class TodosController: Controller
    {
        private static List<TodoViewModel> model = new List<TodoViewModel>{
                new TodoViewModel {
                    Id=0,
                    What ="Buy milk",
                    Done = true
                },
                new TodoViewModel {
                    Id=1,
                    What ="Buy coffee powder",
                    Done = false
                },
                new TodoViewModel {
                    Id=2,
                    What ="Make coffee",
                    Done = false
                }
            };

        public TodosController()  
        {  
        }  

        [HttpGet]  
        public IActionResult Index()  
        {
            // todo: load todos from in-memory Database
            return View("Index", TodosController.model);  
        }

        // ----------------------- CREATE ---------------------------------
        [HttpGet("Todos/create")] 
        public IActionResult CreateTodo()  
        {
            // todo: create form for new Todo
            return View("Create");  
        }  

        [HttpPost("Todos/add")]  
        public IActionResult AddTodo(TodoViewModel model)  
        {
            TodosController.model.Add(
                new TodoViewModel {
                    Id = TodosController.model.Count,
                    What = model.What,
                    Done = model.Done
                }
            );
            return RedirectToAction("Index", "Todos", new object{});  
        }

        // ----------------------- EDIT ---------------------------------
        [HttpGet("Todos/edit/{id}")]  
        public IActionResult EditTodo(int id)  
        {
            /* try  
            {  
                if (ModelState.IsValid)  
                { */
            // todo: update todo in in-memory
            TodoViewModel currentModel = TodosController.model[id];
            return View("Edit", currentModel);
                /* &}  
            }  
            catch (Exception ex)  
            {  
                throw ex;  
            } */   
        }

        [HttpPost("Todos/update")]
        public IActionResult UpdateTodo(TodoViewModel model)
        {
            // todo: update todo in in-memory database
            TodosController.model[model.Id] = model;
            return RedirectToAction("Index", "Todos", new object{});
        }


        // ----------------------- DELET ---------------------------------
        [HttpGet("Todos/delete/{id}")]
        public IActionResult DeleteTodo(int id)
        {
            // todo: load the todo and display it
            TodoViewModel currentModel = TodosController.model[id];
            // todo: ask user if he is really sure to delete the todo
            return View("Delete", currentModel);
        }

        [HttpPost("Todos/remove")]
        public IActionResult DeleteCustomer(TodoViewModel model)
        {
            // todo: really delete the todo if the user has said OK
            TodosController.model.RemoveAt(model.Id);

            // reseting the id, if one model gets deleted
            foreach (var mod in TodosController.model)
            {
                // for reseting the id, if one model gets deleted
                if (mod.Id > model.Id)
                {
                    mod.Id -= 1;
                }
            }
            return RedirectToAction("Index", "Todos", new object{});
        }
    }
}