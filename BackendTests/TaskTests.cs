/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using IntroSE.Kanban.Backend.ServiceLayer;
using IntroSE.Forum.Backend.ServiceLayer;

namespace BackendTests
{
    internal class TaskTests

    {
        private BoardService boardService;
        public TaskTests(BoardService boardService)
        {
            this.boardService = boardService;
        }

        public void MainTests()
        {

            addTaskTest();

            //UpdateTaskDueDateTest();
            //UpdateTaskTitleTest();
            //UpdateTaskDescription();

        }
        //<summary>
        // testing for addTask
        //<summary>
        //<example> for Toadd1 should print task added successfully <example>
        //<example> for Toadd2 should print "title should not be empty" <example>
        //<example> for Toadd3 should print "title should be 50 chars max" <example>
        //<example> for Toadd4 should print "description should be 300 chars max" <example>
        //<example> for Toadd5 should print "dueDate expired" <example>
        //<example> for Toadd6 should print task added successfully <example>
        public void addTaskTest()
        {

            //should be successfull 
            string Toadd1 = boardService.AddTask("essabsh@post.bgu.ac.il", "essa", "university", "going everyday", new DateTime(2023, 8, 20));
            Response response1 = JsonSerializer.Deserialize<Response>(Toadd1);
            Console.WriteLine(response1.ErrorMessage);
            //empty title 
            string Toadd2 = boardService.AddTask("essabsh@post.bgu.ac.il", "essa", "jaja", "going everydayy", new DateTime(2023, 8, 20));
            Response response2 = JsonSerializer.Deserialize<Response>(Toadd2);
            Console.WriteLine(response2.ErrorMessage);
            ////more than 50 charcteres in the title 
            //string Toadd3 = boardService.AddTask("essabsh@post.bgu.ac.il", "essa", "university111", "going everyday", new DateTime(2023, 8, 20));
            //Response response3 = JsonSerializer.Deserialize<Response>(Toadd3);
            //Console.WriteLine(response3.ErrorMessage);
            ////more than 300 charcteres in the description 
            //string Toadd4 = boardService.AddTask("jassarshahd@gmail.com", "entering the university", "university", "going everydayuniversity111111111111111111111111111111111111111111university111111111111111111111111111111111111111111university111111111111111111111111111111111111111111university111111111111111111111111111111111111111111university111111111111111111111111111111111111111111university111111111111111111111111111111111111111111university111111111111111111111111111111111111111111", new DateTime(2023, 4, 20));
            //Response response4 = JsonSerializer.Deserialize<Response>(Toadd4);
            //Console.WriteLine(response4.ErrorMessage);
            ////not in time 
            //string Toadd5 = boardService.AddTask("jassarshahd@gmail.com", "entering the university", "university", "going everyday", new DateTime(2020, 4, 20));
            //Response response5 = JsonSerializer.Deserialize<Response>(Toadd5);
            //Console.WriteLine(response5.ErrorMessage);
            ////without description 
            //string Toadd6 = boardService.AddTask("jassarshahd@gmail.com", "entering the university", "university", "", new DateTime(2023, 4, 20));
            //Response response6 = JsonSerializer.Deserialize<Response>(Toadd6);
            //Console.WriteLine(response6.ErrorMessage);
        }
        //<summary>
        // testing for UpdateTaskDueDate
        //<summary>
        //<example> for Toupdate1 should print task updated successfully <example>
        //<example> for Toupdate2 should print "task already updated" <example>
        //<example> for Toupdate3 should print "due date expired " <example>
        public void UpdateTaskDueDateTest()
        {
            //successfully update
            string ToUpdate1 = boardService.UpdateTaskDueDate("essabsh@posr.bgu.ac.il", "university", 10, 2, new DateTime(2023, 4, 25));
            Response response1 = JsonSerializer.Deserialize<Response>(ToUpdate1);
            Console.WriteLine(response1.ErrorMessage);
            //already done
            string ToUpdate2 = boardService.UpdateTaskDueDate("essabsh@posr.bgu.ac.il", "university", 10, 2, new DateTime(2023, 4, 25));
            Response response2 = JsonSerializer.Deserialize<Response>(ToUpdate2);
            Console.WriteLine(response2.ErrorMessage);
            //time expired
            string ToUpdate3 = boardService.UpdateTaskDueDate("essabsh@posr.bgu.ac.il", "university", 10, 2, new DateTime(2020, 4, 25));
            Response response3 = JsonSerializer.Deserialize<Response>(ToUpdate3);
            Console.WriteLine(response3.ErrorMessage);
        }
        //<summary>
        // testing for UpdateTaskTitle
        //<summary>
        //<example> for Toupdate1 should print tasktitle updated successfully <example>
        //<example> for Toupdate2 should print "tasktitle already updated" <example>
        //<example> for Toupdate3 should print cant update an empty task title <example>
        public void UpdateTaskTitleTest()
        {
            //successfully updated
            string ToUpdate1 = boardService.UpdateTaskTitle("essabsh@post.bgu.ac.il", "university", 10, 2, "study");
            Response response1 = JsonSerializer.Deserialize<Response>(ToUpdate1);
            Console.WriteLine(response1.ErrorMessage);
            //already done
            string ToUpdate2 = boardService.UpdateTaskTitle("essabsh@post.bgu.ac.il", "university", 10, 2, "study");
            Response response2 = JsonSerializer.Deserialize<Response>(ToUpdate2);
            Console.WriteLine(response2.ErrorMessage);
            //empty title
            string ToUpdate3 = boardService.UpdateTaskTitle("essabsh@post.bgu.ac.il", "university", 10, 2, "");
            Response response3 = JsonSerializer.Deserialize<Response>(ToUpdate3);
            Console.WriteLine(response3.ErrorMessage);
            //title longer than 50 char's
            string ToUpdate4 = boardService.UpdateTaskTitle("essabsh@post.bgu.ac.il", "university", 10, 2, "studystudystudystudystudystudystudystudystudystudystudy");
            Response response4 = JsonSerializer.Deserialize<Response>(ToUpdate4);
            Console.WriteLine(response4.ErrorMessage);
        }

        //<summary>
        // testing for UpdateTaskDescription
        //<summary>
        //<example> for Toupdate1 should print task description updated successfully <example>
        //<example> for Toupdate2 should print "task description already updated" <example>
        //<example> for Toupdate2 should print cant update a task with more than 300 char's in the description <example>
        //<example> for Toupdate4 should print  updating with an empty description <example>
        public void UpdateTaskDescription()
        {
            //successfully updated
            string ToUpdate1 = boardService.UpdateTaskDescription("jassarshahd@gmail.com", "beauty and the beast", 100, 1, "disney");
            Response response1 = JsonSerializer.Deserialize<Response>(ToUpdate1);
            Console.WriteLine(response1.ErrorMessage);
            //already done
            string ToUpdate2 = boardService.UpdateTaskDescription("jassarshahd@gmail.com", "beauty and the beast", 100, 1, "disney");
            Response response2 = JsonSerializer.Deserialize<Response>(ToUpdate2);
            Console.WriteLine(response2.ErrorMessage);
            //more than 300 chars in description
            string ToUpdate3 = boardService.UpdateTaskDescription("jassarshahd@gmail.com", "beauty and the beast", 100, 1, "disneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisneydisney");
            Response response3 = JsonSerializer.Deserialize<Response>(ToUpdate3);
            Console.WriteLine(response3.ErrorMessage);
            //empty description
            string ToUpdate4 = boardService.UpdateTaskDescription("jassarshahd@gmail.com", "beauty and the beast", 100, 1, "");
            Response response4 = JsonSerializer.Deserialize<Response>(ToUpdate4);
            Console.WriteLine(response4.ErrorMessage);


        }
        public void advanceTasktest()
        {
            string tomove = boardService.AdvanceTask("essabsh@post.bgu.ac.il", "essa", 0, 0);
            Response response1 = JsonSerializer.Deserialize<Response>(tomove);
            Console.WriteLine(response1.ErrorMessage);

            string tomove2 = boardService.AdvanceTask("essabsh@post.bgu.ac.il", "essa", 0, 1);
            Response response2 = JsonSerializer.Deserialize<Response>(tomove2);
            Console.WriteLine(response2.ErrorMessage);
        }
    }
}*/
