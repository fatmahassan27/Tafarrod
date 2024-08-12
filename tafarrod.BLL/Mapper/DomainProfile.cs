using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tafarrod.BLL.ViewModel;
using tafarrod.DAL.Entities;
using AutoMapper;
using tafarrod.BLL.DTOs;


namespace tafarrod.BLL.Mapper
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<Worker,WorkerDTO>();
            CreateMap<WorkerDTO, Worker>();
            //--------------------------------
            CreateMap<Contract, ContractDTO>();
            CreateMap<ContractDTO, Contract>();
            //---------------------------------
            CreateMap<Expenses, ExpensesDTO>();
            CreateMap<ExpensesDTO, Expenses>();
            //----------------------------------
            CreateMap<User, RegistrationDTO>();
            CreateMap<RegistrationDTO, User>();
            //----------------------------------
            CreateMap<Nationality, NationalityDTO>();
            CreateMap<NationalityDTO, Nationality>();
            //--------------------------------
            CreateMap<Occupation,OccupationDTO>();
            CreateMap<OccupationDTO, Occupation>();
            //------------------------------------
            CreateMap<Problem, ProblemDTO>();
            CreateMap<ProblemDTO, Problem>();



        }
    }
}
