using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers;
public class UsersController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    public UsersController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    // GET: UsersController
    public IActionResult Login()
    {
        return View();
    }

    // GET: UsersController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: UsersController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: UsersController/Create
    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            returnUrl ??= Url.Content("~/");
            var isLoggedIn = await _authenticationService.Authenticate(login.Email, login.Password);
            if (isLoggedIn)
                return LocalRedirect(returnUrl);
        }
        ModelState.AddModelError("", "Log In Attempt Failed. Please try again.");
        return View(login);
    }

    // GET: UsersController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: UsersController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: UsersController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: UsersController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
