using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace theatrebel.Utility
{
    public static class ModelErrors
    {
        public static IList<string> GetList(ModelStateDictionary modelState)
        {
            return modelState.Values
                .SelectMany(e => e.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
        }
        public static string GetString(ModelStateDictionary modelState)
        {
            var errors = GetList(modelState);
            return string.Join(Environment.NewLine, errors);
        }
    }
}
