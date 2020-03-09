using AutoMapper;
using MVC_EF.DAL;
using MVC_EF.Domain;
using MVC_EF.Singleton;
using MVC_EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_EF
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // automapper - creazione istanza mapper, configurazione e salvataggio istanza mapper nel singleton
            var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<VotoStudente, GradeDtoVM>();
                cfg.CreateMap<VotoStudente, EditGradeViewModel>();
                cfg.CreateMap<StudentGrade, VotoStudente>()
                .ForMember(dest => dest.IdCorso, opt => opt.MapFrom(src => src.CourseID))
                .ForMember(dest => dest.Voto, opt => opt.MapFrom(src => src.Grade))
                .ForMember(dest => dest.IdStudente, opt => opt.MapFrom(src => src.StudentID))
                //.ForMember(dest => dest.CognomeStudente, opt => opt.Ignore())
                //.ForMember(dest => dest.NomeStudente, opt => opt.Ignore())
                ;
                cfg.CreateMap<GetStudentGrades2_Result, VotoStudente>()
                    .ForMember(dest => dest.IdCorso, opt => opt.MapFrom(src => src.CourseID))
                    .ForMember(dest => dest.Voto, opt => opt.MapFrom(src => src.Grade))
                    .ForMember(dest => dest.IdStudente, opt => opt.MapFrom(src => src.StudentID))
                    .ForMember(dest => dest.CognomeStudente, opt => opt.Ignore())
                    .ForMember(dest => dest.NomeStudente, opt => opt.Ignore())
                    ;

                cfg.CreateMap<VotoStudente, StudentGrade>()
                .ForMember(dest => dest.CourseID, opt => opt.MapFrom(src => src.IdCorso))
                .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.Voto))
                .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.IdStudente))
                ;
            });
            IMapper mapper = new Mapper(config);
            MySingleton.AssignMapper(mapper);
        }
    }
}
