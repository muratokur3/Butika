using Application.Mappers;
using Application.Services.AbstractServices;
using Application.Services.ConcreteServices;
using Autofac;
using AutoMapper;

namespace Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BusinessService>().As<IBusinessService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ContactService>().As<IContactService>();
            builder.RegisterType<SocialMediaService>().As<ISocialMediaService>();
            builder.RegisterType<TagService>().As<ITagService>();
            builder.RegisterType<MailService>().As<IMailService>();
            builder.RegisterType<BranchService>().As<IBranchService>();
            builder.RegisterType<CampaignService>().As<ICampaignService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CertificationService>().As<ICertificationService>();
            builder.RegisterType<FeatureService>().As<IFeatureService>();
            builder.RegisterType<MarketingChannelService>().As<IMarketingChannelService>();
            builder.RegisterType<MarketplaceService>().As<IMarketplaceService>();
            builder.RegisterType<CompanyService>().As<ICompanyService>();


            builder.Register(context => new  MapperConfiguration(config =>
            {
                config.AddProfile<Mapping>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();

                return config.CreateMapper(context.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
