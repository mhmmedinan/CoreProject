using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Castle.Core.Configuration;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace MvcWebUI.Extension
{
    public static class ServiceExtension
    {
        public static void AddSingletonService(this IServiceCollection services)
        {
            services.AddSingleton<IAboutService, AboutManager>();
            services.AddSingleton<IAboutDal, EfAboutDal>();

            services.AddSingleton<IContactService, ContactManager>();
            services.AddSingleton<IContactDal, EfContactDal>();

            services.AddSingleton<IExperienceService, ExperienceManager>();
            services.AddSingleton<IExperienceDal, EfExperienceDal>();

            services.AddSingleton<IFeatureService, FeatureManager>();
            services.AddSingleton<IFeatureDal, EfFeatureDal>();

            services.AddSingleton<IMessageService, MessageManager>();
            services.AddSingleton<IMessageDal, EfMessageDal>();

            services.AddSingleton<IPortfolioService, PortfolioManager>();
            services.AddSingleton<IPortfolioDal, EfPortfolioDal>();

            services.AddSingleton<IServiceService, ServiceManager>();
            services.AddSingleton<IServiceDal, EfServiceDal>();

            services.AddSingleton<ISkillService, SkillManager>();
            services.AddSingleton<ISkillDal, EfSkillDal>();

            services.AddSingleton<ISocialMediaService, SocialMediaManager>();
            services.AddSingleton<ISocialMediaDal, EfSocialMediaDal>();

            services.AddSingleton<ITestimonialService, TestimonialManager>();
            services.AddSingleton<ITestimonialDal, EfTestimonialDal>();

            services.AddSingleton<IToDoListService, ToDoListManager>();
            services.AddSingleton<IToDoListDal, EfToDoListDal>();

            services.AddSingleton<IUserMessageService, UserMessageManager>();
            services.AddSingleton<IUserMessageDal, EfUserMessageDal>();

            services.AddSingleton<IAnnouncementService, AnnouncementManager>();
            services.AddSingleton<IAnnouncementDal, EfAnnouncementDal>();

        }
    }
}
