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
    public class CompaniesController : Controller
    {
        private readonly MvcCompanyContext _context;

        public CompaniesController(MvcCompanyContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var mvcCompanyContext = _context.Company
                                            .Include(d => d.Departments)
                                            .ThenInclude(e => e.Employees);
            var companies = await mvcCompanyContext.ToListAsync();

            return View(companies);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .SingleOrDefaultAsync(m => m.CompanyID == id);
            if (company == null)
            {
                return NotFound();
            }

            //return View(company);
            return Redirect("/Departments?=" + id);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyID,Name,Adres")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.SingleOrDefaultAsync(m => m.CompanyID == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyID,Name,Adres")] Company company)
        {
            if (id != company.CompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.CompanyID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .SingleOrDefaultAsync(m => m.CompanyID == id);
            if (company == null)
            {
                return NotFound();
            }

            var departments = await _context.Department
                                            .Where(x => x.CompanyID == id)
                                            .ToArrayAsync();
            var depCount = departments.Length;

            var empCount = 0;
            foreach(var dep in departments){
                var employees = await _context.Employee
                                              .Where(x => x.DepartmentID == dep.DepartmentID)
                                              .ToArrayAsync();
                empCount = empCount + employees.Length;
            }


            ViewData["DepCount"] = depCount;
            ViewData["EmpCount"] = empCount;
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.SingleOrDefaultAsync(m => m.CompanyID == id);
            _context.Company.Remove(company);

            var departments = await _context.Department
                                            .Where(x => x.CompanyID == id)
                                            .ToArrayAsync();
            foreach (var dep in departments)
            {
                var employees = await _context.Employee
                                              .Where(x => x.DepartmentID == dep.DepartmentID)
                                              .ToArrayAsync();
                foreach (var emp in employees)
                {
                    _context.Employee.Remove(emp);
                }
                _context.Department.Remove(dep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.CompanyID == id);
        }
    }
}
