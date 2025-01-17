﻿using ModelsLibrary.ModelsDto;
using ModelsLibrary.ModelsVM;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace ModelsLibrary.Converters
{
    public class ProductConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(ProductViewModel);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (Product)value;
            var result = new ProductViewModel
            {
                Name = concreteValue.Name,
                Cost = concreteValue.Cost,
                Description = concreteValue.Description,
                Id = concreteValue.Id,
                Images = concreteValue.Images.Select(x => x.Url.Replace("wwwroot", "")).ToList()
            };
            return result;
        }
    }
}
