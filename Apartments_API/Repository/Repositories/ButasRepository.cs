using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Apartments_API.DTO;
using Apartments_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Apartments_API.Repository.Repositories
{
    public class ButasRepository : IButasRepository
    {
        private RepositoryContext _repository;

        public ButasRepository(RepositoryContext repositoryContext)
        {
            _repository = repositoryContext;
        }

        public IEnumerable<Butas> FindAll()
        {
            return _repository.Set<Butas>()
                .Include(o => o.BusenaNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation.IdIsNaudotojasNavigation)
                .Include(o => o.Darbas)
                .Include(o => o.NuomosLaikotarpis)
                .Include(o => o.Privalumas)
                .Include(o => o.Reitingas)
                .Include(o => o.Skundas)
                .AsNoTracking();
        }

        public IEnumerable<Butas> FindByCondition(Expression<Func<Butas, bool>> expression)
        {
            return _repository.Set<Butas>().Where(expression)
                .Include(o => o.BusenaNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation.IdIsNaudotojasNavigation)
                .Include(o => o.Darbas)
                .Include(o => o.NuomosLaikotarpis)
                .Include(o => o.Privalumas)
                .Include(o => o.Reitingas)
                .Include(o => o.Skundas)
                .AsNoTracking();
        }

        public void Update(Butas entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Butas> Search(ApartmentsSearchDto searchDto)
        {
            // TODO: add null check to new search options
            var apartments = _repository.Set<Butas>()
                .Include(o => o.BusenaNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation.IdIsNaudotojasNavigation)
                .Include(o => o.Darbas)
                .Include(o => o.NuomosLaikotarpis)
                .Include(o => o.Privalumas)
                .Include(o => o.Reitingas)
                .Include(o => o.Skundas)
                .AsNoTracking().AsEnumerable();

            var foundApartments = new List<Butas>();
            foreach (var apartment in apartments)
            {
                if ((searchDto.OwnerId != null && apartment.FkSavininkasidIsNaudotojas == searchDto.OwnerId) ||
                    (searchDto.TenantId != null &&
                     apartment.NuomosLaikotarpis.Any(o => o.FkNuomininkasidIsNaudotojas.Equals(searchDto.TenantId))))
                {
                    foundApartments.Add(apartment);
                }
            }

            return foundApartments;
        }
        public IEnumerable<Butas> Search(ReportDto searchDto)
        {
            // TODO: add null check to new search options
            var apartments = _repository.Set<Butas>()
                .Include(o => o.BusenaNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation)
                .Include(o => o.FkSavininkasidIsNaudotojasNavigation.IdIsNaudotojasNavigation)
                .Include(o => o.Darbas)
                .Include(o => o.NuomosLaikotarpis)
                .Include(o => o.Privalumas)
                .Include(o => o.Reitingas)
                .Include(o => o.Skundas)
                .AsNoTracking().AsEnumerable();

            var foundApartments = new List<Butas>();
            foreach (var apartment in apartments)
            {
                
                if (searchDto.UserID != null && apartment.FkSavininkasidIsNaudotojas == searchDto.UserID)
                {
                    foundApartments.Add(apartment);
                }
            }

            return foundApartments;
        }

        public Reitingas Rate(RatingDto ratingDto)
        {
            var foundRating = _repository
                .Set<Reitingas>()
                .FirstOrDefault(o => o.FkButasidButas.Equals(ratingDto.FkButasidButas) &&
                                     o.FkNuomininkasidIsNaudotojas.Equals(ratingDto.FkNuomininkasidIsNaudotojas));

            if (foundRating != null)
            {
                foundRating.Ivertinimas = ratingDto.Ivertinimas;
            }
            else
            {
                foundRating = _repository.Mapper.Map<RatingDto, Reitingas>(ratingDto);
                _repository.Set<Reitingas>().Add(foundRating);
            }

            _repository.SaveChanges();
            return foundRating;
        }
        public Butas Add(ApartmentCreateDto apartmentCreateDto)
        {
           

            var apartment = _repository.Mapper.Map<ApartmentCreateDto,Butas> (apartmentCreateDto);
             //to do : Save uniqueFileName  to your db table   
            
            _repository.Set<Butas>().Add(apartment);
            _repository.SaveChanges();

            return apartment;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        public void Update(ApartmentUpdateDto apartmentUpdateDto)
        {


            //var apartment = _repository.Mapper.Map<ApartmentCreateDto, Butas>(apartmentCreateDto);
            var apartment = _repository.Set<Butas>()
                  .Include(o => o.FkSavininkasidIsNaudotojasNavigation)
                   .Where(o => o.IdButas.Equals(apartmentUpdateDto.idButas) &&
                               o.FkSavininkasidIsNaudotojas.Equals(apartmentUpdateDto.FkSavininkasidIsNaudotojas));
            apartment.First().Adresas = apartmentUpdateDto.Adresas;
            apartment.First().Dydis = apartmentUpdateDto.Dydis;

            apartment.First().KambaruSkaicius = apartmentUpdateDto.KambaruSkaicius;

            apartment.First().KainaUzNakti = apartmentUpdateDto.KainaUzNakti;
            apartment.First().NuotraukaUrl = apartmentUpdateDto.NuotraukaUrl;
            apartment.First().Aprašas = apartmentUpdateDto.Aprašas;
            apartment.First().Pavadinimas = apartmentUpdateDto.Pavadinimas;
            apartment.First().Miestas = apartmentUpdateDto.Miestas;
            apartment.First().Šalis = apartmentUpdateDto.Šalis;
            _repository.Set<Butas>().Update(apartment.First());
            _repository.SaveChanges();

            //return apartment;
        }

        public bool Delete(ApartmentDeleteDto apartmentDeleteDto)
        {
            
            var apartment = _repository.Set<Butas>()
                   .Include(o => o.FkSavininkasidIsNaudotojasNavigation)
                    .Where(o => o.IdButas.Equals(apartmentDeleteDto.IdButas) &&
                                o.FkSavininkasidIsNaudotojas.Equals(apartmentDeleteDto.FkSavininkasidIsNaudotojas));

                if (!apartment.Any())
                {
                    return false;
                }
            var rent = _repository.Set<NuomosLaikotarpis>()
            .Include(o => o.FkNuomininkasidIsNaudotojasNavigation)
            .Where(o => o.FkButasidButas.Equals(apartmentDeleteDto.IdButas));

            if (!rent.Any())
            {
                return false;
            }

            _repository.Set<NuomosLaikotarpis>().Remove(rent.First());
            _repository.SaveChanges();


            _repository.Set<Butas>().Remove(apartment.First());
                _repository.SaveChanges();

                return true;
            
        }
    }
}