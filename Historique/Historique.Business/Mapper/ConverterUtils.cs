using System.Collections.Generic;

namespace Historique.Business.Mapper
{
    public class ConverterUtils
    {
        private ConverterUtils()
        {
        }

        public static List<TDest> ConvertList<TSource, TDest>(IEnumerable<TSource> sources)
        {
            var convertedObjects = new List<TDest>();

            foreach (var source in sources)
            {
                convertedObjects.Add(ConvertObject<TSource, TDest>(source));
            }

            return convertedObjects;
        }

        public static TDest ConvertObject<TSource, TDest>(TSource source)
        {
            InitMapper<TSource, TDest>();

            return AutoMapper.Mapper.Map<TSource, TDest>(source);
        }

        private static void InitMapper<TSource, TDest>()
        {
            AutoMapper.Mapper.CreateMap<TSource, TDest>();
        }
    }
}
