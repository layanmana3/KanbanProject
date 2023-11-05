using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.BusinessLayer.User;
using IntroSE.Kanban.Backend.BussinessLayer.Board;
using IntroSE.Kanban.Backend.ServiceLayer;
//using IntroSE.Kanban.BackendTest;

namespace BackendTests
{
    internal class Porgram
    {
        static void Main(String[] args)
        {


            GradingService grading = new GradingService();
            grading.DeleteData();
            string email = "mail@mail.com";
            string password = "Password1";
            Console.WriteLine(grading.Register(email, password));
            //Console.WriteLine(grading.Login(email, password));
            Console.WriteLine("??????????????????????????????????????????");
            Console.WriteLine(grading.GetUserBoards(email));

           // Console.WriteLine(grading.Register(email,password));
            Console.WriteLine(grading.CreateBoard(email, "board1"));
            Console.WriteLine("??????????????????????????????????????????");
            Console.WriteLine(grading.GetUserBoards(email));

            Console.WriteLine(grading.CreateBoard(email, "board2"));
            Console.WriteLine("??????????????????????????????????????????");
            Console.WriteLine(grading.GetUserBoards(email));

            

            /* BoardService boardService;
             UserService userService;
             UserController userController = new UserController();
             BoardController boardController = new BoardController();
             userService = new UserService();
             boardService = new BoardService();
             TaskTests task = new TaskTests(boardService);
             BoardTests board = new BoardTests(boardService);
             UserTests user = new UserTests(userService);
             //user.MainTests();
             //board.MainTests();
             //task.MainTests();
             user.RegisterTest();
             board.AddBoardTest();
             task.addTaskTest();
             task.advanceTasktest();
             board.InProgressTest();
             //boardService.GetColumnName("essabsh@post.bgu.ac.il","essa",0);
             //task.addTaskTest();
             //task.advanceTasktest();
             //board.InProgressTest();
             //board.JoinBoardTest();
             //board.GetBoardNameTest();

             //GradingService grading = new GradingService();
             //grading.DeleteData();
             //string email = "gmail@gmail.com";
             //string password = "Password1";
             //Console.WriteLine(grading.Register(email, password));
             //Console.WriteLine(grading.CreateBoard(email, "board1"));
             //Console.WriteLine(grading.CreateBoard(email, "board2"));

             //Console.WriteLine(grading.AddTask(email, "board1", "title1", "desc1", new DateTime(2025, 10, 10)));
             //Console.WriteLine(grading.AssignTask(email, "board1", 0, 0, email));
             //Console.WriteLine(grading.AdvanceTask(email, "board1", 0, 0));
             //Console.WriteLine(grading.AdvanceTask(email, "board1", 1, 0));
             //Console.WriteLine(grading.AddTask(email, "board1", "title2", "desc2", new DateTime(2025, 10, 10)));
             //Console.WriteLine(grading.AssignTask(email, "board1", 0, 1, email));
             //Console.WriteLine(grading.AdvanceTask(email, "board1", 0, 1));
             //Console.WriteLine(grading.AddTask(email, "board1", "title4", "desc4", new DateTime(2025, 10, 10)));
             //Console.WriteLine(grading.AssignTask(email, "board1", 0, 2, email));*/

        }
    }
}
