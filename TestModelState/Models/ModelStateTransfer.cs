using Microsoft.AspNetCore.Mvc.Filters;

namespace TestModelState.Models
{
    public class ModelStateTransfer : ActionFilterAttribute
    {
        protected const string Key = nameof(ModelStateTransfer);
    }
}
