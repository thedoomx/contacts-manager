using Application.Queries.Common;
using AutoMapper;
using Domain.Models;

namespace Application.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Contact, ContactOutputModel>();
		}
	}
}
