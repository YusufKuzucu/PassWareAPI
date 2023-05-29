using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<ProjectManager>().As<IProjectService>().SingleInstance();
            builder.RegisterType<EfProjectDal>().As<IProjectDal>().SingleInstance();

            builder.RegisterType <CommunicationManager>().As<ICommunicationService>().SingleInstance();
            builder.RegisterType<EfCommunicationDal>().As<ICommunicationDal>().SingleInstance();

            builder.RegisterType<JumpManager>().As<IJumpService>().SingleInstance();
            builder.RegisterType<EfJumpDal>().As<IJumpDal>().SingleInstance();

            builder.RegisterType<LinkManager>().As<ILinkService>().SingleInstance();
            builder.RegisterType<EfLinkDal>().As<ILinkDal>().SingleInstance();

            builder.RegisterType<SqlManager>().As<ISqlService>().SingleInstance();
            builder.RegisterType<EfSqlDal>().As<ISqlDal>().SingleInstance();

            builder.RegisterType<UIManager>().As<IUIService>().SingleInstance();
            builder.RegisterType<EfUIDal>().As<IUIDal>().SingleInstance();

            builder.RegisterType<VpnManager>().As<IVpnService>().SingleInstance();
            builder.RegisterType<EfVpnDal>().As<IVpnDal>().SingleInstance();

            builder.RegisterType<FileLogger>().As<ILogger>().SingleInstance();
            builder.RegisterType<DatabaseLogger>().As<ILogger>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance(); ;
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance(); ;

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance(); ;
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
