/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using IntroSE.Kanban.Backend.ServiceLayer;
using IntroSE.Forum.Backend.ServiceLayer;
using IntroSE.Kanban.Backend.BusinessLayer.User;
using IntroSE.Kanban.Backend.BussinessLayer.Board;

namespace BackendTests
{
    internal class BoardTests
    {
        private BoardService boardService;
//private UserService userService;
        public BoardTests(BoardService boardService)
        {
            this.boardService= boardService;
        }
        public void MainTests()
        {
            AddBoardTest();
            //ColumnLimitTest();
            //GetColumnLimitTest();
            //GetNameTest();
            //GetColumnTest();
            //RemoveBoardTest();
            //InProgressTest();
        }
        //<summary>
        // testing for addBoard
        //<summary>
        //<example> for json the function should print Board added succesfully<example>
        public void AddBoardTest()
        {
            //should be added
            string json = boardService.AddBoard("essabsh@post.bgu.ac.il", "essa");
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);

            string json1 = boardService.AddBoard("essabsh@post.bgu.ac.il", "essa1");
            Response response1 = JsonSerializer.Deserialize<Response>(json1);
            Console.WriteLine(response1.ErrorMessage);

            string json2 = boardService.AddBoard("essabsh@post.bgu.ac.il", "essa2");
            Response response2 = JsonSerializer.Deserialize<Response>(json2);
            Console.WriteLine(response2.ErrorMessage);


            ////should be added
            //string json1 = boardService.AddBoard("essabsh@post.bgu.ac.il", "shushu");
            //Response response1 = JsonSerializer.Deserialize<Response>(json1);
            //Console.WriteLine(response1.ErrorMessage);

            ////should not be added
            //string json2 = boardService.AddBoard("layan@gmail.com", "layan");
            //Response response2 = JsonSerializer.Deserialize<Response>(json2);
            //Console.WriteLine(response2.ErrorMessage);

            //string json3 = boardService.AddBoard("alaa@gmail.com", "alaa");
            //Response response3 = JsonSerializer.Deserialize<Response>(json3);
            //Console.WriteLine(response2.ErrorMessage);
        }
        //<summary>
        // testing for LimitColumn
        //<summary>
        // <example> for each json the function should print column limit set succesfully<example>
        public void ColumnLimitTest()
        {
            //should be added
            string json = boardService.LimitColumn("essabsh@post.bgu.ac.il", "essa", 1, 100);
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);

            //should be added
            string json1 = boardService.LimitColumn("essabsh@post.bgu.ac.il", "essa", 2, 100);
            Response response1 = JsonSerializer.Deserialize<Response>(json1);
            Console.WriteLine(response1.ErrorMessage);

            //should be added
            string json2 = boardService.LimitColumn("essabsh@post.bgu.ac.il", "essa", 3, 100);
            Response response2 = JsonSerializer.Deserialize<Response>(json2);
            Console.WriteLine(response2.ErrorMessage);
        }
        //<summary>
        //testing for GetColumnLimit
        //<summary> 
        //<example> for json the column limit should be returned successfully<example>
        public void GetColumnLimitTest()
        {
            string json = boardService.GetColumnLimit("essabsh@post.bgu.ac.il", "essa", 0);
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);

            string json1 = boardService.GetColumnLimit("layan@gmail.com", "layan", 0);
            Response response1 = JsonSerializer.Deserialize<Response>(json1);
            Console.WriteLine(response1.ErrorMessage);

            string json2 = boardService.GetColumnLimit("alaa@gmail.com", "alaa", 0);
            Response response2 = JsonSerializer.Deserialize<Response>(json2);
            Console.WriteLine(response2.ErrorMessage);
        }
        //<summary>
        //testing for GetColumnNameTest
        //<summary>
        //<example> for json the function should return the column name successfully<example>
        public void GetNameTest()
        {
            string json = boardService.GetColumnName("essabsh@post.bgu.ac.il", "essa", 2);
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);

            string json1 = boardService.GetColumnLimit("layan@gmail.com", "layan", 0);
            Response response1 = JsonSerializer.Deserialize<Response>(json1);
            Console.WriteLine(response1.ErrorMessage);

            string json2 = boardService.GetColumnLimit("alaa@gmail.com", "alaa", 0);
            Response response2 = JsonSerializer.Deserialize<Response>(json2);
            Console.WriteLine(response2.ErrorMessage);

        }
        //<summary>
        //testing for GetColumnTest
        //<summary>
        //<example> for json the function should return the column successfully<example>
        public void GetColumnTest()
        {
            string json = boardService.GetColumn("essabsh@post.bgu.ac.il", "essa", 2);
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);
        }
        // <summary>
        // testing for RemoveBoard
        // </summary>
        // <example> for json the function should print Board removed successfully</example>
        public void RemoveBoardTest()
        {
            string json = boardService.RemoveBoard("essabsh@post.bgu.ac.il", "essa");
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);
        }

        //<summary>
        //testing for InProgressTasks
        //<summary>
        //<example> for json the function print InProgressTasks shown successfully<example>
        public void InProgressTest()
        {
           
            //string json = boardService.AddBoard("essabsh@post.bgu.ac.il", "essa");
            //Response response = JsonSerializer.Deserialize<Response>(json);
            //Console.WriteLine(response.ErrorMessage);
            
            string json1 = boardService.InProgressTasks("essabsh@post.bgu.ac.il");
            Response response2 = JsonSerializer.Deserialize<Response>(json1);
            Console.WriteLine(response2.ErrorMessage);
        }
        //<summary>
        //testing for AdvanceTask
        //<summary>
        //<example> for json the function print the task has been advanced successfully<example>

        public void AdvanceTaskTest()
        {
            string json = boardService.AdvanceTask("essabsh@post.bgu.ac.il", "essa", 0, 1);
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);
        }
        // <summary>
        // This is a test function for GetUserBoards
        // </summary>
        // <example> For json the function should print user's Boards returned successfully</example>
        public void GetUserBoardsTest()
        {
            string json = boardService.GetUserBoards("essa@gmail.com");
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);
        }

        //<summary>
        //testing for joinboard
        //<summary>
        //<example> for json the function should print user joined the board succesfully <example>
        //<example> for json1 the function should print user board id is invalid <example>
        public void JoinBoardTest()
        {
            //good example
            string json = boardService.JoinBoard("essa@post.bgu.ac.il",0);
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);
            ////invalid board id
            //string json1 = boardService.JoinBoard("essa@gmail.com",-1);
            //Response response1 = JsonSerializer.Deserialize<Response>(json1);
            //Console.WriteLine(response1.ErrorMessage);
        }
        //<summary>
        //testing for LeaveBoard
        //<summary>
        //<example> for json the function should print user left the board succesfully <example>
        //<example> for json1 the function should print user board id is invalid <example>
        //<example> for json2 the function should print user email is null <example>
        public void LeaveBoardTest()
        {
            //good example
            string json = boardService.LeaveBoard("essa@gmail.com",2);
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);
            //invalid board id
            string json1 = boardService.LeaveBoard("essa@gmail.com",-1);
            Response response1 = JsonSerializer.Deserialize<Response>(json1);
            Console.WriteLine(response1.ErrorMessage);
            //null email
            string json2 = boardService.LeaveBoard("",2);
            Response response2 = JsonSerializer.Deserialize<Response>(json2);
            Console.WriteLine(response2.ErrorMessage);
        }

        //<summary>
        //testing for AssignTask
        //<summary>
        //<example> for json the function print user assigned for the task <example>
        public void AssignTaskTest()
        {
            string json = boardService.AssignTask("essa@gmail.com", "essa", 0, 12, "essabsh@gmail.com");
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);
        }

        //<summary>
        //testing for GetBoardName
        //<summary>
        //<example> for json the function print the board name <example>
        public void GetBoardNameTest()
        {
            string json = boardService.GetBoardName(0);
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);

            string json1 = boardService.GetBoardName(1);
            Response response1 = JsonSerializer.Deserialize<Response>(json1);
            Console.WriteLine(response1.ErrorMessage);

            string json2 = boardService.GetBoardName(2);
            Response response2 = JsonSerializer.Deserialize<Response>(json2);
            Console.WriteLine(response2.ErrorMessage);
        }

        //<summary>
        //testing for TransferOwnership
        //<summary>
        //<example> for json the function print the ownership transferded <example>
        //<example> for json1 the function print the user is not the owner of the board <example>
        public void TransferOwnershipTest()
        {
            //good example
            string json = boardService.TransferOwnership("essa@gmail.com", "essabsh@gmail.com", "essa");
            Response response = JsonSerializer.Deserialize<Response>(json);
            Console.WriteLine(response.ErrorMessage);
            //not the owner
            string json1 = boardService.TransferOwnership("alaa@gmail.com", "essabsh@gmail.com", "essa");
            Response response1 = JsonSerializer.Deserialize<Response>(json1);
            Console.WriteLine(response1.ErrorMessage);
        }



    }
}*/
