using AutoMapper;

namespace Rigel.Mapping
{
    public static class MappingExtensions
    {
        public static TO Map<FROM, TO>(this FROM from)
        {
            Mapper.CreateMap<FROM, TO>();
            return Mapper.Map<FROM, TO>(from);
        }

        public static void MapFrom<FROM, TO>(this FROM from, TO to)
        {
            Mapper.CreateMap<TO, FROM>();
            Mapper.Map(to, from);
        }

        public static T Clone<T>(this T from)
        {
            Mapper.CreateMap<T, T>();
            return Mapper.Map<T, T>(from);
        }
    }
}
