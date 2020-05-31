using System;

namespace Exercise.Models
{
    public class ToDo
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public Boolean IsDone { get; set; }
        public ToDo(string ID, string Description, Boolean IsDone)
        {
            this.ID = ID;
            this.Description = ToTitleCase(Description);
            this.IsDone = IsDone;
        }
        public override string ToString()
        {
            return this.ID + "," + this.Description + "," + this.IsDone;
        }
        public static string ToTitleCase(string todo)
        {
            var fs = todo.IndexOf(' ', 1);
            if (fs == -1)
            {
                if (todo.Length > 1)
                {
                    if (todo[0] == ' ')
                    {
                        return String.Concat(todo[0], Char.ToUpper(todo[1]), todo.Substring(2));
                    }
                    else
                    {
                        return String.Concat(Char.ToUpper(todo[0]), todo.Substring(1));
                    }
                }
                else
                {
                    return todo.ToUpper();
                }
            }
            else
            {
                if (fs > 1)
                {
                    if (todo[0] == ' ')
                    {
                        return String.Concat(todo[0], Char.ToUpper(todo[1]), todo.Substring(2, fs - 2)) + ToTitleCase(todo.Substring(fs));
                    }
                    else
                    {
                        return String.Concat(Char.ToUpper(todo[0]), todo[1..fs]) + ToTitleCase(todo.Substring(fs));
                    }
                }
                else
                {
                    return " " + ToTitleCase(todo.Substring(fs));
                }
            }
        }
    }
}
