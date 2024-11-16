using TodoTasks.Contexts;
using TodoTasks.Models;

namespace TodoTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext sql = new AppDbContext();
            List<Todo> todos = [];

            string title = null!;
            string? description = null;

            bool condition = false;
            int id;
            string menuChoice;

            do
            {
                Console.WriteLine("1. Create Task");
                Console.WriteLine("2. Read Task");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Remove Task");
                Console.WriteLine("0. Exit");
                Console.WriteLine(" ");
                Console.WriteLine("Secim edin :");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Title daxil edin :");
                        title = Console.ReadLine();

                        Console.WriteLine(" ");

                        Console.Write("Description daxil edin :");
                        description = Console.ReadLine();

                        if (title is not null)
                        {
                            sql.Todos.Add(new Todo
                            {
                                Title = title,
                                Description = description,
                                Deadline = DateTime.Now,
                            });
                            sql.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Title bos ola bilmez.");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        var todos1 = sql.Todos.ToList();

                        foreach (var todo1 in todos)
                        {
                            if (todo1.Description != null)
                            {
                                Console.WriteLine($"ID: {todo1.Id}, Title: {todo1.Title}, Description: {todo1.Description}, Deadline: {todo1.Deadline}");
                            }
                            else
                            {
                                Console.WriteLine($"ID: {todo1.Id}, Title: {todo1.Title}, Description: Empty, Deadline: {todo1.Deadline}");

                            }
                        }
                        break;
                    case "3":
                        Console.Clear();

                        var todos2 = sql.Todos.ToList();

                        foreach (var todo1 in todos)
                        {
                            if (todo1.Description != null)
                            {
                                Console.WriteLine($"ID: {todo1.Id}, Title: {todo1.Title}, Description: {todo1.Description}, Deadline: {todo1.Deadline}");
                            }
                            else
                            {
                                Console.WriteLine($"ID: {todo1.Id}, Title: {todo1.Title}, Description: Empty, Deadline: {todo1.Deadline}");

                            }
                        }
                        bool condition1 = false;
                        do
                        {
                            Console.WriteLine("Update etmek istediyiniz listin id daxil edin :");
                            condition1 = int.TryParse(Console.ReadLine(), out id);
                        } while (!condition1);

                        var todo = sql.Todos.FirstOrDefault(t => t.Id == id);
                        if (todo != null)
                        {
                            Console.Write("Title daxil edin :");
                            title = Console.ReadLine();

                            Console.WriteLine(" ");

                            Console.Write("Description daxil edin :");
                            description = Console.ReadLine();
                            todo.Description = description;
                            todo.Title = title;
                            todo.Deadline = DateTime.Now.AddDays(1);

                            sql.SaveChanges();

                            Console.WriteLine("Todo obyekt uğurla yeniləndi.");
                        }
                        else
                        {
                            Console.WriteLine("Todo tapılmadı.");
                        }
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Silmek istediyiniz listin id daxil edin :");
                        bool condition2 = false;
                        do
                        {
                            condition2 = int.TryParse(Console.ReadLine(), out id);
                        } while (!condition2);


                        var todo2 = sql.Todos.FirstOrDefault(t => t.Id == id);

                        if (todo2 != null)
                        {
                            sql.Todos.Remove(todo2);

                            sql.SaveChanges();

                            Console.WriteLine("Todo obyekt uğurla silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Todo tapılmadı.");
                        }
                        break;
                    case "0":
                        Console.Clear();
                        condition = true;
                        Console.WriteLine("Program closed...");
                        break;
                    default:
                        Console.WriteLine("Yanlis secim etdiniz.");
                        break;

                }

            } while (!condition);




            //using (AppDbContext sql = new AppDbContext())
            //{
            //    sql.Todos.AddRange(todos);
            //    //sql.Todos.Add(new Todo
            //    //{
            //    //    Title = "Task 2",
            //    //    Deadline = DateTime.Now.AddHours(4),
            //    //});
            //    sql.SaveChanges();
            //    Console.WriteLine("Successfully created!");
            //}

            //using (AppDbContext context = new())
            //{
            //    var data = context.Todos.FirstOrDefault(x => x.Title == "Title 8");
            //    if (data != null)
            //    {
            //        data.Description = "BDU";
            //        context.SaveChanges();
            //    }
            //}
        }
    }
}
