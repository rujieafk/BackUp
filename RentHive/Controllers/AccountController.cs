using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using RentHive.Models;

namespace RentHive.Controllers
{
    public class AccountController : Controller
    {
        public int userId;
        public string userEmail;
        public string userType;
        //-----------------------------------------------------------------------
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        /*public IActionResult Login(userLogin _userLogin)*/
        public async Task<ActionResult> Login(userLogin _userLogin)
        {
            // Replace with your PHP API URL hosted on 000webhost
            string url = "https://renthive.000webhostapp.com/Admin_API/Login.php";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string Username = _userLogin.Acc_Email;
                    string Password = _userLogin.Acc_Password;

                    // Create a dictionary with username and password
                    var data = new Dictionary<string, string>
                    {
                        {"username", Username},
                        {"password", Password}
                    };

                    // Serialize the credentials as JSON and send them in the request body.
                    var content = new FormUrlEncodedContent(data);

                    // Make a POST request to the PHP API
                    var response = await httpClient.PostAsync(url, content);

                    // Ensure a successful response
                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response content
                        var responseData = await response.Content.ReadAsStringAsync();

                        // Check if login was successful
                        if (responseData == "failed to login")
                        {
                            ViewBag.ErrorMessage = "Login failed. Invalid credentials.";
                            return RedirectToAction("HiveUserList", "Home");
                        }
                        else
                        {
                            // Deserialize the JSON response into a dynamic object
                            var userObject = JsonConvert.DeserializeObject<userLogin>(responseData);

                            // Access individual properties from the JSON response
                            userId = userObject.Acc_id;
                            userEmail = userObject.Acc_Email;
                            userType = userObject.Acc_UserType;

                            return RedirectToAction("Index", "Home", new {userId = userId, userEmail = userEmail, userType = userType});
                        }
                    }
                    else
                    {
                        // Handle API request failure (e.g., log error, display an error message)
                        ViewBag.ErrorMessage = "API request failed: " + response.ReasonPhrase;
                        return RedirectToAction("HiveUserLog", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network errors, timeouts)
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return RedirectToAction("HivePaymentHistory", "Home");
            }
        }

        //----------------------------------------------------------------------



        //------------------------------------------------------------------------
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> SignUp(userLogin _userLogin)
        {
            // Replace with your PHP API URL hosted on 000webhost
            string url = "https://renthive.000webhostapp.com/Admin_API/Signup.php";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string Firstname = _userLogin.Acc_FirstName;
                    string Lastname = _userLogin.Acc_LastName;
                    string Middlename = _userLogin.Acc_MiddleName;
                    string DisplayName = _userLogin.Acc_DisplayName;
                    string Birthdate = _userLogin.Acc_Birthdate;
                    string PhoneNum = _userLogin.Acc_PhoneNum;
                    string Address = _userLogin.Acc_Address;
                    string Username = _userLogin.Acc_Email;
                    string Password = _userLogin.Acc_Password;

                    // Create a dictionary with username and password
                    var data = new Dictionary<string, string>
                    {
                        {"firstname", Firstname},
                        {"lastname", Lastname},
                        {"middlename", Middlename},
                        {"displayname", DisplayName},
                        {"birthdate", Birthdate},
                        {"phonenum", PhoneNum},
                        {"address", Address},
                        {"username", Username},
                        {"password", Password},
                    };

                    // Serialize the credentials as JSON and send them in the request body.
                    var content = new FormUrlEncodedContent(data);

                    // Make a POST request to the PHP API
                    var response = await httpClient.PostAsync(url, content);


                    // Ensure a successful response
                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response content
                        var responseData = await response.Content.ReadAsStringAsync();

                        if (responseData == "Registration failed") 
                        {
                            //User Registration failed (Email is already taken)
                            return RedirectToAction("HiveUserList", "Home");
                        }
                        else
                        {
                            //User Registration successful
                            return RedirectToAction("Login", "Account");
                        }
                    }
                    else
                    {
                        // Handle API request failure (e.g., log error, display an error message)
                        return RedirectToAction("HiveUserLog", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network errors, timeouts)
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
                return RedirectToAction("HivePaymentHistory", "Home");
            }
        }
        //--------------------------------------------------------------------------

        public IActionResult ForgetPassword()
        {
            return View();
        }
        public IActionResult ForgetPassword_EnterCode()
        {
            return View();
        }
        public IActionResult ForgetPassword_Reset()
        {
            return View();
        }
        public IActionResult Logout(string confirmation)
        {
            if (confirmation == "yes")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Profile","System");
            }
        }
    }
}
