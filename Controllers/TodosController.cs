using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noel_repository_pattern.ViewModels;

namespace noel_repository_pattern.Controllers
{
    public class TodosController: Controller
    {
  
        public TodosController()  
        {  
        }  

        [HttpGet]  
        public IActionResult Index()  
        {  
            // todo: load todos from in-memory Database
            List<TodoViewModel> model = new List<TodoViewModel>{
                new TodoViewModel { 
                    Id=1,
                    What ="Buy milk",
                    Done = true
                }, 
                new TodoViewModel { 
                    Id=2,
                    What ="Buy coffee powder",
                    Done = false
                }, 
                new TodoViewModel { 
                    Id=3,
                    What ="Make coffee",
                    Done = false
                }
            };
            return View("Index", model);  
        }  
  
        [HttpGet]  
        public IActionResult CreateTodo(TodoViewModel model)  
        {  
            // todo: AddTodo to in-memory Database

            return View("Create");  
        }  

        [HttpPost]  
        public IActionResult AddTodo(TodoViewModel model)  
        {  
            // todo: AddTodo to in-memory Database

            return RedirectToAction("Index", "Todos", new object{});  
        }  


        [HttpPost]  
        public ActionResult EditTodo(long? id, TodoViewModel model)  
        {  
            try  
            {  
                if (ModelState.IsValid)  
                {  
                    // todo: update todo in in-memory database
                }  
            }  
            catch (Exception ex)  
            {  
                throw ex;  
            }  
            return RedirectToAction("Index");  
        }  
  
        [HttpGet]  
        public IActionResult DeleteTodo(long id)  
        {  
            // todo: load the todo and display it
            TodoViewModel model = null;
            // todo: ask user if he is really sure to delete the todo    
            return View(model);  
        }  

        [HttpPost]  
        public IActionResult DeleteCustomer(long id, FormCollection form)  
        {  
            // todo: really delete the todo if the user has said OK
            return RedirectToAction("Index");  
        }  
    }  
}