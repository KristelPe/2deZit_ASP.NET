using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCompanies.Models;

namespace MvcCompanies.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MvcCompanyContext _context;

        public EmployeesController(MvcCompanyContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index(int? id)
        {
            /*
             * var mvcCompanyContext = _context.Employee.Include(e => e.Department);
             * return View(await mvcCompanyContext.ToListAsync());
             */

            if (id == null)
            {
                return NotFound();
            }

            var dep = _context.Department
                              .Where(d => d.DepartmentID == id);
            var department = await dep.ToListAsync();

            var mvcCompanyContext = _context.Employee
                                            .Where(x => x.DepartmentID == id)
                                            .Include(e => e.Department);
            var employees = await mvcCompanyContext.ToListAsync();
            if (employees == null)
            {
                return NotFound();
            }

            ViewData["DepartmentID"] = id;
            ViewData["DepartmentName"] = department.First().Name;
            ViewData["CompanyID"] = department.First().CompanyID;
            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create(int? id)
        {
            //ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentID");
            ViewData["DepartmentID"] = id;
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,LastName,FirstName,Gender,Birthdate,Occupation,DepartmentID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            //ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentID", employee.DepartmentID);
            //return View(employee);
            //return Redirect("/Employees?=" + employee.DepartmentID);
            return RedirectToAction("Index", "Companies");
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            var depID = _context.Department
                              .Where(d => d.DepartmentID == employee.DepartmentID);
            var depComp = _context.Department
                                  .Where(d => d.CompanyID == depID.First().CompanyID);
            var departments = await depComp.ToListAsync();

            ViewData["Department"] = new SelectList(departments, "DepartmentID", "Name", employee.Department);
            ViewData["DepartmentID"] = employee.DepartmentID;
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,LastName,FirstName,Gender,Birthdate,Occupation,DepartmentID")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
            }

            ViewData["Department"] = new SelectList(_context.Department, "DepartmentID", "Name", employee.Department);
            //return Redirect("/Employees?=" + employee.DepartmentID);
            return RedirectToAction("Index", "Companies");
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Department)
                .SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = employee.DepartmentID;
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.SingleOrDefaultAsync(m => m.EmployeeID == id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            //return Redirect("/Employees?=" + employee.DepartmentID);
            return RedirectToAction("Index", "Companies");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeID == id);
        }

    }
}
