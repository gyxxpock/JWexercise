using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions;
using Exercise.Models;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Exercise.Todos.Controllers
{
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
                ToDos.Add(new ToDo(line.Split(",")[0], line.Split(",")[1], line.Split(",")[2] == "true"));
            }

            Database.Close();
            var json = new JavaScriptSerializer().Serialize(ToDos);
            return Ok();
        }

        public static string ToTitleCase(string todo)
        {
            var fs = todo.IndexOf(' ', 1);

            if (todo[0] == ' ')
            {
                if (todo.Length > 1)
                {
                    if (fs != -1)
                    {
                        return todo[0].ToString() + Char.ToUpper(todo[1]) + todo.Substring(2, fs - 2) + ToTitleCase(todo.Substring(fs));
                    }
                    else
                    {
                        return todo[0].ToString() + Char.ToUpper(todo[1]) + todo.Substring(2);
                    }
                }
                else
                {
                    return todo.ToUpper();
                }
            }
            else
            {
                if (fs == -1)
                {
                    return Char.ToUpper(todo[0]) + todo.Substring(1);
                }
                else
                {
                    return Char.ToUpper(todo[0]) + todo.Substring(1, fs - 1) + ToTitleCase(todo.Substring(fs));
                }
            }
        }
    }
}