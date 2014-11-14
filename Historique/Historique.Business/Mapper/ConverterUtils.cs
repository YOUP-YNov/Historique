using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Historique.Business.Mapper
{
    public class ConverterUtils
    {
        private ConverterUtils()
        {
        }

        public static IEnumerable<TDest> ConvertList<TSource, TDest>(IEnumerable<TSource> sources)
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

            TDest convertedObject = default(TDest);

            try
            {
                convertedObject = AutoMapper.Mapper.Map<TSource, TDest>(source);
            }
            catch (Exception e)
            {
                // TODO log exceptions + throw ConverterException...
            }

            return convertedObject;
        }

        private static void InitMapper<TSource, TDest>()
        {
            try
            {
                AutoMapper.Mapper.CreateMap<TSource, TDest>();
            }
            catch (Exception e)
            {
                // TODO log exceptions + throw ConverterException "Failed to initialize configuration for classes TSource TO TDest"
            }
        }
    }
}
