using Autofac;
using BaseProject.WebAPI.Business.Abstract;
using BaseProject.WebAPI.Business.Concrete;
using BaseProject.WebAPI.Core.Entities.Concrete;
using BaseProject.WebAPI.Core.Utilities.Security.Jwt;
using BaseProject.WebAPI.DataAccess.Abstract;
using BaseProject.WebAPI.DataAccess.Concrete;



namespace BaseProject.WebAPI.Business.DependencyResolver.AutoFac
{
    public class AutofacBusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper < User, OperationClaim >>().As<ITokenHelper<User, OperationClaim>>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();



        }
    }
}
