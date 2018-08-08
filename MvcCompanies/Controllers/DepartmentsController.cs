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
    public class DepartmentsController : Controller
    {
        private readonly MvcCompanyContext _context;

        public DepartmentsController(MvcCompanyContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index(int? id)
        {
            /*
             * var mvcCompanyContext =  _context.Department.Include(d => d.Company);
             * return View(await mvcCompanyContext.ToListAsync());
             */

            if (id == null)
            {
                return NotFound();
            }

            var com = _context.Company
                              .Where(d => d.CompanyID == id);
            var company = await com.ToListAsync();

            var mvcCompanyContext =  _context.Department
                                             .Where(x => x.CompanyID == id)
                                             .Include(d => d.Company);
            var departments = await mvcCompanyContext.ToListAsync();
            if (departments == null)
            {
                return NotFound();
            }

            ViewData["CompanyID"] = id;
            ViewData["CompanyName"] = company.First().Name;
            return View(departments);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .Include(d => d.Company)
                .SingleOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }

            //return View(department);

            return Redirect("/Employees?=" + id);
        }

        // GET: Departments/Create
        public IActionResult Create(int? id)
        {
            //ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID");
            ViewData["CompanyID"] = id;
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentID,Name,CompanyID")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            //ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID", department.CompanyID);
            //return View(department);
            return Redirect("/Departments?=" + department.CompanyID);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department.SingleOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            //ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID", department.CompanyID);
            ViewData["CompanyID"] = department.CompanyID;
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentID,Name,CompanyID")] Department department)
        {
            if (id != department.DepartmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentID))
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
            //ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyID", department.CompanyID);
            //return View(department);
            return Redirect("/Departments?=" + department.CompanyID);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Department
                .Include(d => d.Company)
                .SingleOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }

            var employees = await _context.Employee
                                         .Where(x => x.DepartmentID == id)
                                         .ToArrayAsync();
            var empCount = employees.Length;

            ViewData["CompanyID"] = department.CompanyID;
            ViewData["EmpCount"] = empCount;
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Department.SingleOrDefaultAsync(m => m.DepartmentID == id);
            _context.Department.Remove(department);

            var employees = await _context.Employee
                                         .Where(x => x.DepartmentID == id)
                                         .ToArrayAsync();
            foreach(var emp in employees){
                _context.Employee.Remove(emp);
            }

            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return Redirect("/Departments?=" + department.CompanyID);
        }

        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.DepartmentID == id);
        }
    }
}
