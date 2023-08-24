using BaretProject.Application.DTOs;
using BaretProject.Core.Domain;
using Mapster;

namespace BaretProject.Application.Extention
{
    public static class Mapping
    {
        public static TDTO ToDTO<TDTO>(this BaseEntity entity)
        {
            var dto = entity.Adapt<TDTO>();
            return dto;
        }

        public static TEntity ToEntity<TEntity>(this IBaseDTO baseDto)
        {
            var entity = baseDto.Adapt<TEntity>();
            return entity;
        }
    }
}
