using AutoMapper;
using DuckCoin.Dto;
using DuckCoin.FullNode.DomainModels;

namespace DuckCoin.FullNode.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Operation, OperationDto>().ReverseMap();
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}
