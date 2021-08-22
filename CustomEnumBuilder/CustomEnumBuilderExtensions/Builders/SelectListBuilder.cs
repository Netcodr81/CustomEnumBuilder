using CustomEnum;
using CustomEnum.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CustomEnumBuilderExtensions.Builders
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
