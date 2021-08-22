using CustomEnum.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumBuilderCoreExtensions.Builders
{
    public static class SelectListBuilder
    {
        public static SelectList GenerateSelectList(IEnumerable<IEnumeratorType> enumToConvert)
        {
            List<SelectListItem> items = new List<SelectListItem>();

            foreach (IEnumeratorType item in enumToConvert.ToList())
            {

                items.Add(new SelectListItem { Value = item.Value.ToString(), Text = item.DisplayName });
            }

            return new SelectList(items);
        }
    }
}
