using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions;
using Exercise.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;

namespace Exercise.Todos.Controllers
{
    // Routes get api/todos
    // Routes get api/todos/:id
    // Routes delete api/todo/:id
    // Routes post api/todos
    // Routes put api/todos/:id
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetList()
        {
            List<ToDo> ToDos = new System.Collections.Generic.List<ToDo>();
            System.IO.StreamReader Database = new System.IO.StreamReader("Todos.txt");
            string line;
            while ((line = Database.ReadLine()) != null)
            {
                // Get line
                ToDos.Add(new ToDo(line.Split(",")[0], ToTitleCase(line.Split(",")[1]), line.Split(",")[2] == "true"));
            }

            Database.Close();
            
            return Ok(JsonConvert.SerializeObject(ToDos, Formatting.Indented));
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetTodo(int id)
        {
            return Ok(id);
        }

        public static string ToTitleCase(string todo)
        {
            var fs = todo.IndexOf(' ', 1);
            if(fs == -1)
            {
                if (todo.Length > 1)
                {
                    if(todo[0] == ' ')
                    {
                        return String.Concat(todo[0], Char.ToUpper(todo[1]), todo.Substring(2));
                    } else
                    {
                        return String.Concat(Char.ToUpper(todo[0]), todo.Substring(1));
                    }
                }
                else
                {
                    return todo.ToUpper();
                }
            } else
            {
                if(fs > 1)
                {
                    if (todo[0] == ' ')
                    {
                        return String.Concat(todo[0], Char.ToUpper(todo[1]), todo.Substring(2, fs-2)) + ToTitleCase(todo.Substring(fs));
                    }
                    else
                    {
                        return String.Concat(Char.ToUpper(todo[0]), todo[1..fs]) + ToTitleCase(todo.Substring(fs));
                    }
                } else
                {
                    return " " + ToTitleCase(todo.Substring(fs));
                }
            }
        }
    }
}