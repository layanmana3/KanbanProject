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
    internal class UserTests
    {
        private readonly UserService userService;

        public UserTests(UserService userService)
        {
            this.userService = userService;
        }
        public void MainTests()
        {
            RegisterTest();
            //LoginTest();
            //LogoutTest();
        }
        // <summary>
        // This for testing Register .
        // </summary>
        // <example> For register1 the function prints registered successfully<example>
        // <example> For register2 the function prints email already exist<example>
        // <example> For register3 the function prints email is null<example>
        // <example> For register4 the function prints password should include a number<example>
        // <example> For register5 the function prints password should include an upperCase letter<example>
        // <example> For register6 the function prints password should include a lowerCase letter<example>
        // <example> For register7 the function prints password should be less that 20 in length<example>
        // <example> For register8 the function prints password should be more that 6 in length<example>
        public void RegisterTest()
        {
            //good example
            string register1 = FactoryService.Register("essabsh@post.bgu.ac.il", "Nopassword1!");
            Response response1 = JsonSerializer.Deserialize<Response>(register1);
            Console.WriteLine(response1.ErrorMessage);
            //already registered
            string register2 = userService.Register("essa@post.bgu.ac.il", "Nopassword1!");
            Response response2 = JsonSerializer.Deserialize<Response>(register2);
            Console.WriteLine(response2.ErrorMessage);
            ////empty email
            //string register3 = userService.Register("layan@gmail.com", "Nopassword1!");
            //Response response3 = JsonSerializer.Deserialize<Response>(register3);
            //Console.WriteLine(response3.ErrorMessage);
            ////no numbers
            //string register4 = userService.Register("alaa@gmail.com", "Nopassword1!");
            //Response response4 = JsonSerializer.Deserialize<Response>(register4);
            //Console.WriteLine(response4.ErrorMessage);
            ////no uppercase
            //string register5 = userService.Register("essabsh@post.bgu.ac.il", "nopassword1!");
            //Response response5 = JsonSerializer.Deserialize<Response>(register5);
            //Console.WriteLine(response5.ErrorMessage);
            ////no lowercase
            //string register6 = userService.Register("essabsh@post.bgu.ac.il", "NOPHJ1!");
            //Response response6 = JsonSerializer.Deserialize<Response>(register6);
            //Console.WriteLine(response6.ErrorMessage);
            ////pass longer than 20
            //string register7 = userService.Register("essabsh@post.bgu.ac.il", "nopassword!454545454545454545");
            //Response response7 = JsonSerializer.Deserialize<Response>(register7);
            //Console.WriteLine(response7.ErrorMessage);
            ////pass shorter than 6
            //string register8 = userService.Register("essabsh@post.bgu.ac.il", "nopa");
            //Response response8 = JsonSerializer.Deserialize<Response>(register8);
            //Console.WriteLine(response8.ErrorMessage);
        }
        //<summary>
        // This is for testing Login
        // <summary>
        // <example> For login1 the function should print logIn successfully<example>
        // <example> For login2 the function should print password is wrong<example>
        // <example> For login3 the function should print email is not registered<example>
        public void LoginTest()
        {
            //good example
            string login1 = userService.Login("essabsh@post.bgu.ac.il", "Nopassword!1");
            Response response1 = JsonSerializer.Deserialize<Response>(login1);
            Console.WriteLine(response1.ErrorMessage);
            //wrong password
            string login2 = userService.Login("essabsh@post.bgu.ac.il", "Nopassw");
            Response response2 = JsonSerializer.Deserialize<Response>(login2);
            Console.WriteLine(response2.ErrorMessage);
            //email not registered
            string login3 = userService.Login("ebshara9@gmail.com", "Nopassword!1");
            Response response3 = JsonSerializer.Deserialize<Response>(login3);
            Console.WriteLine(response3.ErrorMessage);
        }

        //<summary>
        //this for testing logout
        //<summary>
        //<example> the funvtion should print logged out succesfully 
        public void LogoutTest()
        {
            string logout = userService.Logout("essabsh@post.bgu.ac.il");
            Response response = JsonSerializer.Deserialize<Response>(logout);
            Console.WriteLine(response.ErrorMessage);
        }

        //<summary>
        //this for testing get user board 
        //<summary>
        //<example> the funvtion should print logged out succesfully 
        public void GetUserBoardsTest()
        {

        }
    }
}*/
