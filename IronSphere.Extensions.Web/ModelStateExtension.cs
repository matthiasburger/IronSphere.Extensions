using System.Collections.Generic;
using System.Web.Mvc;

namespace IronSphere.Extensions.Web
{
    public static class ModelStateExtension
    {
        public static void CopyErrors(this ModelStateDictionary @this, ModelStateDictionary original)
        {
            foreach (KeyValuePair<string, ModelState> modelState in original)
                @this.Add(modelState);
        }
    }
}
