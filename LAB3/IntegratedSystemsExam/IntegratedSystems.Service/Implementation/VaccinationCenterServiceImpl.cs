using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Domain.DTO;
using IntegratedSystems.Repository.Interface;
using IntegratedSystems.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegratedSystems.Service.Implementation
{
    public class VaccinationCenterServiceImpl : IVaccinationCenterService
    {

        private readonly IRepository<VaccinationCenter> vaccinationCenterRepository;
        private readonly IRepository<Vaccine> vaccineRepository;

        public VaccinationCenterServiceImpl(IRepository<VaccinationCenter> repository, IRepository<Vaccine> vaccineRepository)
        {
            vaccinationCenterRepository = repository;
            this.vaccineRepository = vaccineRepository;
        }

        public VaccinationCenter CreateNewVaccinationCenter(VaccinationCenter vaccinationCenter)
        {
            return vaccinationCenterRepository.Insert(vaccinationCenter);
        }

        public VaccinationCenter DeleteVaccinationCenter(Guid id)
        {
            var vaccCenter = this.FindVaccinationCenterById(id);
            return vaccinationCenterRepository.Delete(vaccCenter);
        }

        public VaccinationCenter FindVaccinationCenterById(Guid? id)
        {
            return vaccinationCenterRepository.Get(id);
        }

        public List<VaccinationCenter> GetAll()
        {
            return vaccinationCenterRepository.GetAll().ToList();
        }

        public void AddPatientToVaccineCenter(AddPatientToVaccineCenterDTO dto)
        {
            Vaccine vaccine = new Vaccine();
         
            vaccine.Certificate = Guid.NewGuid();
            vaccine.Manufacturer = dto.manufacturer;
            vaccine.VaccinationCenter = dto.vaccCenterId;
            vaccine.PatientId = dto.patientId;
            vaccine.DateTaken = dto.vaccinationDate;
            vaccine.Center = vaccinationCenterRepository.Get(dto.vaccCenterId);
            vaccineRepository.Insert(vaccine);
        }

        public VaccinationCenter UpdateVaccinationCenter(VaccinationCenter vaccinationCenter)
        {
            return vaccinationCenterRepository.Update(vaccinationCenter);
        }
    }
}
