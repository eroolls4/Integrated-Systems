using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository;
using IntegratedSystems.Service.Interface;
using IntegratedSystems.Domain.DTO;

namespace IntegratedSystems.Web.Controllers
{
    public class VaccinationCentersController : Controller
    {

        private readonly IVaccinationCenterService _vaccCenterService;
        private readonly IPatientService _patientService;



        public VaccinationCentersController(IVaccinationCenterService vaccCenterService, IPatientService patientService)
        {
            _vaccCenterService = vaccCenterService;
            _patientService = patientService;
        }

        // GET: VaccinationCenters
        public async Task<IActionResult> Index()
        {
            return View(_vaccCenterService.GetAll());
        }

        // GET: VaccinationCenters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = _vaccCenterService.FindVaccinationCenterById(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }

            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccinationCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                _vaccCenterService.CreateNewVaccinationCenter(vaccinationCenter);
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = _vaccCenterService.FindVaccinationCenterById(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (id != vaccinationCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _vaccCenterService.UpdateVaccinationCenter(vaccinationCenter);
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = _vaccCenterService.FindVaccinationCenterById(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }

            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _vaccCenterService.DeleteVaccinationCenter(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddPatientToVaccineCenter(Guid id)
        {
            var vaccCenter = _vaccCenterService.FindVaccinationCenterById(id);
            if (vaccCenter.MaxCapacity <= 0)
            {
                return RedirectToAction(nameof(NoMoreCapacity));
            }
            AddPatientToVaccineCenterDTO dto = new AddPatientToVaccineCenterDTO();

            List<String> dummyVaccines = new List<String>() { "AVION", "QR", "TEST123" };

            dto.vaccCenterId = id;
            dto.patients = _patientService.GetPatients();
            dto.manufacturers = dummyVaccines;

            return View(dto);
        }

        [HttpPost,
        ActionName("Schedule")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmSchedule(AddPatientToVaccineCenterDTO dto)
        {
            if (ModelState.IsValid)
            {
                var vaccCenter = _vaccCenterService.FindVaccinationCenterById(dto.vaccCenterId);
                vaccCenter.MaxCapacity--;
                _vaccCenterService.UpdateVaccinationCenter(vaccCenter);
                _vaccCenterService.AddPatientToVaccineCenter(dto);
                return RedirectToAction(nameof(Index));
                
            }

            return View(dto);
        }

        public IActionResult NoMoreCapacity()
        {
            return View();
        }

        private bool VaccinationCenterExists(Guid id)
        {
            return _vaccCenterService.FindVaccinationCenterById(id) != null;
        }
    }
}
