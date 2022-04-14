using Application.Features.Books.Rules;
using Application.Observer;
using Application.Observer.EventHandler;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<ObserverSubject>(sp =>
            {
                ObserverSubject observerSubject = new();
                observerSubject.Subscribe(new BookCreatedSendEmail(sp));
                observerSubject.Subscribe(new BookCreatedSendSms(sp));

                return observerSubject;
            });
            services.AddScoped<BookBusinessRules>();

            return services;
        }
    }
}
