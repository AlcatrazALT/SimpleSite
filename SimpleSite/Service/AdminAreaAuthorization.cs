using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Linq;

namespace SimpleSite.Service
{
    public class AdminAreaAuthorization : IControllerModelConvention
    {
        private readonly string area;
        private readonly string policy;

        public AdminAreaAuthorization(string area, string policy)
        {
            this.area = area;
            this.policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            var isAttributes = controller.Attributes.Any(attr =>
                attr is AreaAttribute && (attr as AreaAttribute).RouteValue.Equals(area, StringComparison.OrdinalIgnoreCase));

            var isRoute = controller.RouteValues.Any(route =>
                route.Key.Equals("area", StringComparison.OrdinalIgnoreCase) && route.Value.Equals(area, StringComparison.OrdinalIgnoreCase));

            if (isAttributes || isRoute)
            {
                controller.Filters.Add(new AuthorizeFilter(policy));
            }
        }
    }
}