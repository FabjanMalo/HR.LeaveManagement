﻿using HR.LeaveManagement.MVC.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers;
public class LeaveTypesController(ILeaveTypeService _leaveTypeService) : Controller
{
    // GET: LeaveTypesController
    public async Task<ActionResult> Index()
    {
        var model = await _leaveTypeService.GetLeaveTypes();

        return View(model);
    }

    // GET: LeaveTypesController/Details/5
    public async Task<ActionResult>  Details(int id)
    {
        return View();
    }

    // GET: LeaveTypesController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: LeaveTypesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
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

    // GET: LeaveTypesController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: LeaveTypesController/Edit/5
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

    // GET: LeaveTypesController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: LeaveTypesController/Delete/5
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
