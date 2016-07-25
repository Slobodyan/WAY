using AutoMapper;
using Web.Models;
using Web.ViewModels;

namespace Web.AutoMapper {
	public class AutoMapperProfile : Profile {
		protected override void Configure() {

			CreateMap<Comment, CommentViewModel>();
		}
	}
}
