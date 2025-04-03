using Microsoft.AspNetCore.Mvc.Filters;

namespace SmartTransit.Application.Mappings;

public class ObjectRequestFilterAttribute : ActionFilterAttribute
{
    private IServiceProvider _serviceProvider;

    public ObjectRequestFilterAttribute(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
    }
}