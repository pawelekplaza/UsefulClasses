using System.Linq;

namespace UsefulClasses
{
    public static class PropertyMapper
    {
        public static MapTo Map<MapFrom, MapTo>(MapFrom source)
            where MapFrom : class
            where MapTo : new()
        {
            var result = new MapTo();
            var resultProperties = typeof(MapTo).GetProperties();
            foreach (var property in typeof(MapFrom).GetProperties())
            {
                if (!resultProperties.Any(v => v.Name == property.Name))
                    continue;

                var prop = typeof(MapTo).GetProperty(property.Name);
                if (prop.CanWrite)
                    prop.SetValue(result, property.GetValue(source));
            }

            return result;
        }
    }
}
