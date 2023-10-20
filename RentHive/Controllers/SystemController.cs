using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RentHive.Models;

namespace RentHive.Controllers
{
    public class SystemController : Controller
    {
        //---------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> Profile(int TempuserId)
        {
            /*return View();*/

            string url = "https://renthive.000webhostapp.com/Admin_API/UpdateGet.php";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    int userId = TempuserId;
                    var data = new Dictionary<string, string>
                    {
                        {"userId", userId.ToString()}
                    };
                    var content = new FormUrlEncodedContent(data);
                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();

                        if (responseData == "Something went wrong.")
                        {
                            return RedirectToAction("HiveUserList", "Home");
                        }
                        else
                        {
                            var userObject = JsonConvert.DeserializeObject<userLogin>(responseData);
                            return View(userObject);
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "API request failed: " + response.ReasonPhrase;
                        return RedirectToAction("HiveUserLog", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("HivePaymentHistory", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Profile(userLogin updatedProfile)
        {
            string url = "https://renthive.000webhostapp.com/Admin_API/Update.php";
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var data = new Dictionary<string, string>
                    {
                        { "userId", updatedProfile.Acc_id.ToString() },
                        { "firstname", updatedProfile.Acc_FirstName },
                        { "lastname", updatedProfile.Acc_LastName },
                        { "middlename", updatedProfile.Acc_MiddleName },
                        { "displayname", updatedProfile.Acc_DisplayName },
                        { "birthdate", updatedProfile.Acc_Birthdate },
                        { "phonenum", updatedProfile.Acc_PhoneNum },
                        { "address", updatedProfile.Acc_Address }
                    };
                    var content = new FormUrlEncodedContent(data);
                    var response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();

                        if (responseData == "Something went wrong.")
                        {
                            return RedirectToAction("HiveUserList", "Home");
                        }
                        else
                        {
                            /*var userObject = JsonConvert.DeserializeObject<userLogin>(responseData);
                            return View(userObject);*/
                            return RedirectToAction("Profile", new { TempuserId = updatedProfile.Acc_id });
                            
                        }
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "API request failed: " + response.ReasonPhrase;
                        return RedirectToAction("HiveUserLog", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("HivePaymentHistory", "Home");
            }

            /*ViewBag.userdisplayname = updatedProfile.Acc_DisplayName;
            ViewBag.userfirstname = updatedProfile.Acc_FirstName;
            ViewBag.usermiddlename = updatedProfile.Acc_MiddleName;
            ViewBag.userlastname = updatedProfile.Acc_LastName;
            ViewBag.usercontact = updatedProfile.Acc_PhoneNum;
            ViewBag.userbirthdate = updatedProfile.Acc_Birthdate;
            ViewBag.useraddress = updatedProfile.Acc_Address;
            ViewBag.useremail = updatedProfile.Acc_Email;
            return View();*/
        }
        //---------------------------------------------------------------------------------
        public IActionResult Notification()
        {
            return View();
        }
        //---------------------------------------------------------------------------------


        //---------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int TempuserId, string confirmation)
        {
            if(confirmation == "yes")
            {
                string url = "https://renthive.000webhostapp.com/Admin_API/DeleteAccount.php";
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        int _TempuserId = TempuserId;

                        // Create a dictionary with username and password
                        var data = new Dictionary<string, string>
                    {
                        {"userId", _TempuserId.ToString()}
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

                            if (responseData == "User deleted successfully.")
                            {
                                return RedirectToAction("Login", "Account");
                            }
                            else
                            {
                                return RedirectToAction("Profile", "System");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("HivePaymentHistory", "Home");
                }
            }
            return RedirectToAction("Profile",new { TempuserId = TempuserId } );
        }

        public IActionResult ErrorPage() {
            return View();
        }
    }
}
