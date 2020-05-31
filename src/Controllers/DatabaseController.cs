using System;
using System.Collections.Generic;
using System.IO;
using Exercise.Models;

namespace Exercise.Controllers
{
    public static class DatabaseController
    {
        private static string DatabaseFilePath = "Todos.txt";
        public static ToDo GetByID(string ID)
        {
            // Search by ID in the file and serialize content to a ToDo Object
            ToDo todo = null;
            foreach (string line in File.ReadLines(DatabaseFilePath))
            {
                if (line.Split(",")[0].Equals(ID))
                {
                    todo = new ToDo(line.Split(",")[0], line.Split(",")[1], line.Split(",")[2] == "true");
                }
            }
            return todo;
        }
        public static List<ToDo> GetAll()
        {
            // Search by ID in the file and serialize content to a ToDo Object
            List<ToDo> todos = new List<ToDo>();
            foreach (string line in File.ReadLines(DatabaseFilePath))
            {
                todos.Add(new ToDo(line.Split(",")[0], line.Split(",")[1], line.Split(",")[2] == "true"));
            }
            return todos;
        }
        public static string Insert(string description)
        {
            // Generate a new ID and Insert as a new line the received ToDo object
            string ID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            ToDo todo = new ToDo(ID, description, false);
            StreamWriter tmpFile = File.AppendText(DatabaseFilePath);
            tmpFile.WriteLine(todo.ToString());
            tmpFile.Close();
            tmpFile.Dispose();
            return ID;
        }
        public static void Delete(string ID)
        {
            // Search by ID in the file and remove that line
            string tmpFilePath = Path.GetTempFileName();
            StreamWriter tmpFile = new StreamWriter(tmpFilePath);
            foreach (string line in File.ReadLines(DatabaseFilePath))
            {
                if (!line.Split(",")[0].Equals(ID))
                {
                    //Write line to tmpfile
                    tmpFile.WriteLine(line);
                }
            }
            tmpFile.Close();
            tmpFile.Dispose();
            File.Delete(DatabaseFilePath);
            File.Move(tmpFilePath, DatabaseFilePath);
        }
        public static void Update(ToDo todo)
        {
            // Search by ID and update that line of the file
            string tmpFilePath = Path.GetTempFileName();
            StreamWriter tmpFile = new StreamWriter(tmpFilePath);
            foreach (string line in File.ReadLines(DatabaseFilePath))
            {
                if (!line.Split(",")[0].Equals(todo.ID))
                {
                    //Write line to tmpfile
                    tmpFile.WriteLine(line);
                } else
                {
                    tmpFile.WriteLine(todo.ToString());
                }
            }
            tmpFile.Close();
            tmpFile.Dispose();
            File.Delete(DatabaseFilePath);
            File.Move(tmpFilePath, DatabaseFilePath);
        }
    }
}
